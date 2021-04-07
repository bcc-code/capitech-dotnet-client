using Capitech.Client.Common;
using Capitech.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.Absence
{
    public class AbsenceClient : CapitechApiClient
    {
        public const int MAX_NUMBER_OF_DAYS = 366;
        public const int DEFAULT_BATCH_SIZE = 30;

        public AbsenceClient(CapitechApiRequestHandler api) : base(api)
        {
        }

        public Task<AbsenceDto[]> GetAbsencesAsync(int clientId, Action<GetAbsenceRequest> filter = null)
        {
            var options = new GetAbsenceRequest();
            filter?.Invoke(options);
            return Api.PostInDateBatchesAsync<GetAbsenceRequest,AbsenceDto>(clientId, "public/v1/Absence/getAbsence", options, DEFAULT_BATCH_SIZE, MAX_NUMBER_OF_DAYS, a => a.AbsenceId.ToString());

        }

        public Task<AbsenceTransactionDto[]> GetAbsenceTransactionsAsync(int clientId, Action<GetAbsenceTransactionRequest> filter = null)
        {
            var options = new GetAbsenceTransactionRequest();
            filter?.Invoke(options);
            return Api.PostInDateBatchesAsync<GetAbsenceTransactionRequest, AbsenceTransactionDto>(clientId, "public/v1/Absence/getAbsenceTransactions", options, DEFAULT_BATCH_SIZE, MAX_NUMBER_OF_DAYS, a => $"{a.AbsenceId}_{a.DayDate}");
        }
               

        public Task<AbsenceDto[]> GetAbsencesAsync(int clientId, DateTime fromDate, DateTime toDate)
        {
            return GetAbsencesAsync(clientId, o =>
            {
                o.FromDate = fromDate.ToString("yyyy-MM-dd");
                o.ToDate = toDate.ToString("yyyy-MM-dd");
            });
        }

        public Task<AbsenceTransactionDto[]> GetAbsenceTransactionsAsync(int clientId, DateTime fromDate, DateTime toDate)
        {
            return GetAbsenceTransactionsAsync(clientId, o =>
            {
                o.FromDate = fromDate.ToString("yyyy-MM-dd");
                o.ToDate = toDate.ToString("yyyy-MM-dd");
            });
        }

    }
}
