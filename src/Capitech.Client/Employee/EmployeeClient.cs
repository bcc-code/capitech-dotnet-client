using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.Employee
{
    public class EmployeeClient : CapitechApiClient
    {
        public EmployeeClient(CapitechApiRequestHandler api) : base(api)
        {
        }

        public Task<PersonalInformationDto[]> GetPersonalInformationAsync(int clientId, Action<GetPersonalInformationRequest> filter = null)
        {
            return Api.PostAsync<GetPersonalInformationRequest,PersonalInformationDto>(clientId, "public/v1/Employee/getPersonalInformation", filter);
        }

        public async Task<PersonalInformationDto> GetPersonalInformationAsync(int clientId, int employeeId)
        {
            return (await GetPersonalInformationAsync(clientId, a =>
            {
                a.EmployeeIdFilter = new int[] { employeeId };
            }).ConfigureAwait(false)).FirstOrDefault();
        }

    }
}
