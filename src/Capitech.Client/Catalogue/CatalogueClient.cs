using Capitech.Client.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Capitech.Client.Catalogue
{
    public class CatalogueClient : CapitechApiClient
    {
        public CatalogueClient(CapitechApiRequestHandler api) : base(api)
        {
        }

        public Task<CompetenceDto[]> GetCompetencesAsync(int clientId)
        {
            return Api.PostAsync<CapitechApiRequest,CompetenceDto>(clientId, "public/v1/Catalogue/getCompetences");
        }

        public Task<DepartmentDto[]> GetDepartmentsAsync(int clientId)
        {
            return Api.PostAsync<CapitechApiRequest, DepartmentDto>(clientId, "public/v1/Catalogue/getDepartments");
        }

        public Task<DutyDefinitionDto[]> GetDutyDefinitionsAsync(int clientId)
        {
            return Api.PostAsync<CapitechApiRequest, DutyDefinitionDto>(clientId, "public/v1/Catalogue/getDutyDefinitions");
        }

        public Task<DutyTypeDto[]> GetDutyTypesAsync(int clientId)
        {
            return Api.PostAsync<CapitechApiRequest, DutyTypeDto>(clientId, "public/v1/Catalogue/getDutyTypes");
        }

        public async Task<FreeDimension1Dto[]> GetFreeDimension1sAsync(int clientId)
        {
            var result = await Api.PostAsync<CapitechApiRequest, FreeDimension1Dto>(clientId, "public/v1/Catalogue/getFreeDimension1s").ConfigureAwait(false);
            // Work-around
            foreach (var item in result)
            {
                item.ClientId = clientId;
            }
            return result;
        }

        public async Task<FreeDimension2Dto[]> GetFreeDimension2sAsync(int clientId)
        {
            var result = await Api.PostAsync<CapitechApiRequest, FreeDimension2Dto>(clientId, "public/v1/Catalogue/getFreeDimension2s").ConfigureAwait(false);
            // Work-around
            foreach (var item in result)
            {
                item.ClientId = clientId;
            }
            return result;
        }

        public Task<OrderDto[]> GetOrdersAsync(int clientId)
        {
            return Api.PostAsync<CapitechApiRequest, OrderDto>(clientId, "public/v1/Catalogue/getOrders");
        }

        public Task<PhaseDto[]> GetPhasesAsync(int clientId, int projectId, int subProjectId)
        {
            return Api.PostAsync<GetPhasesRequest, PhaseDto>(clientId, "public/v1/Catalogue/getPhases", o => { o.ProjectId = projectId; o.SubProjectId = subProjectId; });
        }

        public Task<ProjectDto[]> GetProjectsAsync(int clientId, bool includePassive = false)
        {
            return Api.PostAsync<GetProjectsRequest, ProjectDto>(clientId, "public/v1/Catalogue/getProjects", o => o.IncludePassive = includePassive);
        }

        public Task<SubProjectDto[]> GetSubProjectsAsync(int clientId, int projectId)
        {
            return Api.PostAsync<GetSubProjectsRequest, SubProjectDto>(clientId, "public/v1/Catalogue/getSubProjects", o => o.ProjectId = projectId);
        }

        public Task<TaskDto[]> GetTasksAsync(int clientId, int departmentId)
        {
            return Api.PostAsync<GetTasksRequest, TaskDto>(clientId, "public/v1/Catalogue/getTasks", o => o.DepartmentId = departmentId);
        }
    }
}
