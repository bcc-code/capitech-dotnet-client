using Capitech.Client.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.Access
{
    public class AccessClient
    {
        private static HttpClient _http = new HttpClient();
        public AccessClient(CapitechOptions options)
        {
            Options = options;
        }

        protected CapitechOptions Options { get; }

        public async Task<LoginResponse> LoginAsync(LoginRequest request)
        {
            var response = await _http.PostAsync($"{Options.ApiBaseUri}public/v1/Access/login", new StringContent(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), Encoding.UTF8, "text/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonConvert.DeserializeObject<CapitechApiResponse<LoginResponse>>(content);
                if (apiResponse.Success)
                {
                    return apiResponse.Content.FirstOrDefault();
                }
                else
                {
                    throw new Exception($"Capitech login failed. Error: {apiResponse.DisplayErrorMessage ?? ""}. Server Error: {apiResponse.ServerErrorMessage ?? ""}");
                }
            }
            throw new Exception($"Capitech login failed with status code {response.StatusCode}. Reason: {response.ReasonPhrase ?? ""}. Content: {content ?? ""}");
        }

        public async Task LogoutAsync(LogoutRequest request)
        {
            var response = await _http.PostAsync($"{Options.ApiBaseUri}public/v1/Access/logout", new StringContent(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), Encoding.UTF8, "text/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonConvert.DeserializeObject<CapitechApiResponse<object>>(content);
                if (apiResponse.Success)
                {
                    return;
                }
                else
                {
                    throw new Exception($"Capitech logout failed. Error: {apiResponse.DisplayErrorMessage ?? ""}. Server Error: {apiResponse.ServerErrorMessage ?? ""}");
                }
            }
            throw new Exception($"Capitech logout failed with status code {response.StatusCode}. Reason: {response.ReasonPhrase ?? ""}. Content: {content ?? ""}");
        }

        public async Task<LoginResponse> RefreshLoginAsync(RefreshLoginRequest request)
        {
            var response = await _http.PostAsync($"{Options.ApiBaseUri}public/v1/Access/logout", new StringContent(JsonConvert.SerializeObject(request, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            }), Encoding.UTF8, "text/json")).ConfigureAwait(false);
            var content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var apiResponse = JsonConvert.DeserializeObject<CapitechApiResponse<LoginResponse>>(content);
                if (apiResponse.Success)
                {
                    return apiResponse.Content.FirstOrDefault();
                }
                else
                {
                    throw new Exception($"Capitech login refresh failed. Error: {apiResponse.DisplayErrorMessage ?? ""}. Server Error: {apiResponse.ServerErrorMessage ?? ""}");
                }
            }
            throw new Exception($"Capitech login refresh failed with status code {response.StatusCode}. Reason: {response.ReasonPhrase ?? ""}. Content: {content ?? ""}");
        }
    }
}
