using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.Time
{
    public class TimeClient : CapitechApiClient
    {
        public const int MAX_NUMBER_OF_DAYS = 31;
        public const int DEFAULT_REQUEST_BATCH_SIZE = 31;

        public TimeClient(CapitechApiRequestHandler api) : base(api)
        {
        }

        public Task<TimeTransactionDto[]> GetTimeTransactionsAsync(int clientId, Action<GetTimeTransactionsRequest> filter = null)
        {
            var options = new GetTimeTransactionsRequest();
            filter?.Invoke(options);
            return Api.PostInDateBatchesAsync<GetTimeTransactionsRequest, TimeTransactionDto>(clientId, "public/v1/Time/getTimeTransactions", options, DEFAULT_REQUEST_BATCH_SIZE, MAX_NUMBER_OF_DAYS, o => o.Uid.ToString() + "_" + o.TimeCategoryId.ToString());
        }

        public Task<TimeTransactionDto[]> GetTimeTransactionsAsync(int clientId, DateTime fromDate, DateTime toDate)
        {

            return GetTimeTransactionsAsync(clientId, o =>
            {
                o.FromDate = fromDate.ToString("yyyy-MM-dd");
                o.ToDate = toDate.ToString("yyyy-MM-dd");
            });
        }

        public Task<TimeTransactionDto[]> GetTimeTransactionsForEmployeeAsync(int clientId, DateTime fromDate, DateTime toDate, int employeeId)
        {
            return GetTimeTransactionsAsync(clientId, o =>
            {
                o.FromDate = fromDate.ToString("yyyy-MM-dd");
                o.ToDate = toDate.ToString("yyyy-MM-dd");
                o.EmployeeIdFilter = new int[] { employeeId };
            });
        }

        public Task<TimeTransactionDto[]> GetTimeTransactionsUpdatedSinceAsync(int clientId, DateTime fromDate, DateTime toDate, DateTime updatedSince)
        {

            return GetTimeTransactionsAsync(clientId, o =>
            {
                o.FromDate = fromDate.ToString("yyyy-MM-dd");
                o.ToDate = toDate.ToString("yyyy-MM-dd");
                o.LastUpdatedGreaterThanOrEqualToFilter = updatedSince.ToString("yyyy-MM-dd");
            });
        }


    }
}
