using Capitech.Client.Access;
using Capitech.Client.Exceptions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.Common
{
    public class CapitechApiRequestHandler
    {
        public CapitechApiRequestHandler(CapitechOptions options)
        {
            Options = options;
            AccessClient = new AccessClient(options);

        }

        protected CapitechOptions Options { get; }

        protected AccessClient AccessClient { get; }

        protected static HttpClient Http { get; } = new HttpClient();


        private LoginResponse _access = null;
        public async Task<string> GetAccessTokenAsync(bool forceRenew = false)
        {
            if (_access == null || _access.AccessTokenExpires.AddMinutes(-5) < DateTimeOffset.Now || forceRenew)
            {
                _access = await AccessClient.LoginAsync(new LoginRequest
                {
                    Password = Options.ApiPassword,
                    Username = Options.ApiUsername
                }).ConfigureAwait(false);
            }
            return _access.AccessToken.ToString();
        }

        public Task<TResult[]> PostAsync<TRequest, TResult>(int clientId, string uri, Action<TRequest> options = null) where TRequest : CapitechApiRequest, new()
        {
            var request = new TRequest();
            options?.Invoke(request);
            return PostAsync<TRequest, TResult>(clientId, uri, request);
        }
        
        public async Task<TResult[]> PostAsync<TRequest,TResult>(int clientId, string uri, TRequest request) where TRequest : CapitechApiRequest
        {
            var fullUri = $"{Options.ApiBaseUri}{uri}";
            var accessToken = await GetAccessTokenAsync().ConfigureAwait(false);
            int retries = 0;
            retry: 
            request.AccessToken = accessToken;
            request.ClientId = clientId;
            var response = await Http.PostAsync(fullUri, new StringContent(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), Encoding.UTF8, "text/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<CapitechApiResponse<TResult>>(content);
                if (result.Success)
                {
                    return result.Content;
                }
                else
                {
                    if ((result.DisplayErrorMessage?.Contains("Too many results")).GetValueOrDefault(false) || (result.ServerErrorMessage?.Contains("maximum allowed number")).GetValueOrDefault(false))
                    {
                        throw new CapitechApiTooMuchDataException(fullUri, result.DisplayErrorMessage, result.ServerErrorMessage);
                    }
                    throw new CapitechApiException(fullUri, result.DisplayErrorMessage, result.ServerErrorMessage);
                }
            }
            else
            {
                if ((content?.Contains("maximum allowed number")).GetValueOrDefault())
                {
                    var result = JsonConvert.DeserializeObject<CapitechApiResponse<TResult>>(content);
                    throw new CapitechApiTooMuchDataException(fullUri, result.DisplayErrorMessage, result.ServerErrorMessage);
                }
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized && (content?.Contains("Session expired")).GetValueOrDefault())
                {
                    accessToken = await GetAccessTokenAsync(true).ConfigureAwait(false);
                    retries++;
                    if (retries < 5)
                    {
                        goto retry;
                    }
                }

                throw new Exception($"Capitech request to {fullUri} failed with status code {response.StatusCode}. Reason: {response.ReasonPhrase ?? ""}. Content: {content ?? ""}");
            }
            
        }

        public async Task<TResult[]> PostInDateBatchesAsync<TRequest, TResult>(int clientId, string uri, TRequest request, int defaultBatchSize, int maxNumberOfDays, Func<TResult,string> idAccessor) where TRequest : CapitechApiDateFilteredRequest
        {
            var result = new List<TResult>();
            var fromDate = request.GetFromDate();
            var toDate = request.GetToDate();
            var days = (toDate - fromDate).TotalDays;
            try
            {
                if (days < maxNumberOfDays)
                {
                    // Attempt to retrieve all records in one batch
                    result = (await PostAsync<TRequest, TResult>(clientId, uri, request).ConfigureAwait(false)).ToList();
                    goto removeDuplicates;
                }
            }
            catch (CapitechApiTooMuchDataException)
            {
            }

            var batchSize = defaultBatchSize;
            startBatch:
            try
            {
                result = new List<TResult>();
                var currentFromDate = fromDate;
                while (currentFromDate <= toDate)
                {
                    var currentToDate = currentFromDate.AddDays(batchSize);
                    if (currentToDate > toDate)
                    {
                        currentToDate = toDate;
                    }
                    request.FromDate = currentFromDate.ToString("yyyy-MM-dd");
                    request.ToDate = currentToDate.ToString("yyyy-MM-dd");
                    result.AddRange(await PostAsync<TRequest, TResult>(clientId, uri, request).ConfigureAwait(false));
                    currentFromDate = currentFromDate.AddDays(batchSize);
                }
            }
            catch (CapitechApiTooMuchDataException ex)
            {
                if (batchSize > 1)
                {
                    // Retry with smaller batch size
                    batchSize = batchSize / 2;
                    goto startBatch;
                }
                else
                {
                    throw new Exception("Unable to retreive data from Capitech. Too much data (over 1000 records) for a single day. Attempt to apply further filtering to query.", ex);
                }
            }

            removeDuplicates:
            // Remove duplicates (records which span two days and therefore retreived twice)
            var resultWithoutDuplicates = new List<TResult>();
            var resultIds = new HashSet<string>();
            foreach (var item in result)
            {
                var id = idAccessor(item);
                if (!resultIds.Contains(id))
                {
                    resultIds.Add(id);
                    resultWithoutDuplicates.Add(item);
                }
            }
            return resultWithoutDuplicates.ToArray();



        }

    }
}
