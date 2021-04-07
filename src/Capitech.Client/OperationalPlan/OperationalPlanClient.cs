using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.OperationalPlan
{
    public class OperationalPlanClient : CapitechApiClient
    {
        public const int MAX_NUMBER_OF_DAYS = 366;
        public const int DEFAULT_BATCH_SIZE = 7;

        public OperationalPlanClient(CapitechApiRequestHandler api) : base(api)
        {
        }

        public Task<OperationalPlanDto[]> GetOperationalPlanAsync(int clientId, Action<OperationalPlanRequest> filter = null)
        {
            var options = new OperationalPlanRequest();
            filter?.Invoke(options);
            return Api.PostInDateBatchesAsync<OperationalPlanRequest,OperationalPlanDto>(clientId, "public/v1/OperationalPlan", options, DEFAULT_BATCH_SIZE, MAX_NUMBER_OF_DAYS, o => o.Id.ToString());
        }

        /// <summary>
        /// Returns operational plan from fromDate to (but excluding) toDate
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public Task<OperationalPlanDto[]> GetOperationalPlanAsync(int clientId, DateTime fromDate, DateTime toDate)
        {
            return GetOperationalPlanAsync(clientId, o =>
            {
                o.FromDate = fromDate.ToString("yyyy-MM-dd");
                o.ToDate = toDate.ToString("yyyy-MM-dd");
            });
        }


    }
}
