using Capitech.Client.Employee;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Capitech.Client.Tests
{
   // [Ignore("Live integration tests")]
    public class CapitechClientTests
    {
        public CapitechOptions Options { get; set; }
        public int ClientId { get; set; }


        [SetUp]
        public void Setup()
        {
            Options = ConfigHelper.GetApplicationConfiguration(TestContext.CurrentContext.TestDirectory);
            ClientId = 100;
        }

        [Test]
        public async Task Catalogue_GetCompetences_ReturnsCompetences()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetCompetencesAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetDepartments_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetDepartmentsAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetDutyDefinitions_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetDutyDefinitionsAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetDutyTypes_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetDutyTypesAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetFreeDimesion1s_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetFreeDimension1sAsync(ClientId);

            Assert.NotNull(result);
        }


        [Test]
        public async Task Catalogue_GetFreeDimesion2s_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetFreeDimension2sAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetOrders_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetOrdersAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetProjects_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Catalogue.GetProjectsAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Catalogue_GetPhases_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var projects = await client.Catalogue.GetProjectsAsync(ClientId);
            foreach (var project in projects)
            {
                var subProjects = await client.Catalogue.GetSubProjectsAsync(100, project.ProjectId);
                foreach (var subProject in subProjects)
                {
                    if (subProject.UsesPhases)
                    {
                        var result = await client.Catalogue.GetPhasesAsync(100, projects[0].ProjectId, subProject.SubProjectId);
                        Assert.NotNull(result);
                    }
                }
            }            
        }



        [Test]
        public async Task Catalogue_GetTasksAsync_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var departments = await client.Catalogue.GetDepartmentsAsync(ClientId);
            foreach (var department in departments)
            {
                var result = await client.Catalogue.GetTasksAsync(100, department.DepartmentId);
                Assert.NotNull(result);
            }
        }

        [Test]
        public async Task EmployeeGetPersonalInformation_WithoutFilter_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Employee.GetPersonalInformationAsync(ClientId);

            Assert.NotNull(result);
        }

        [Test]
        public async Task OperationalPlan_WithoutFilter_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.OperationalPlan.GetOperationalPlanAsync(ClientId, DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-1));

            Assert.NotNull(result);
        }

        [Test]
        public async Task Absences_WithOnlyDateFilter_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Absence.GetAbsencesAsync(ClientId, DateTime.Today.AddDays(-30), DateTime.Today);

            Assert.NotNull(result);
        }


        [Test]
        public async Task Times_WithDateFilter_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Time.GetTimeTransactionsAsync(ClientId, DateTime.Today, DateTime.Today);

            Assert.NotNull(result);
        }

        [Test]
        public async Task Times_ForEmployee_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Time.GetTimeTransactionsForEmployeeAsync(ClientId, DateTime.Today.AddDays(-5), DateTime.Today.AddDays(-5), 303);

            Assert.NotNull(result);
        }


        [Test]
        public async Task Times_UpdatedSince_ReturnsData()
        {
            var client = new CapitechClient(Options);

            var result = await client.Time.GetTimeTransactionsUpdatedSinceAsync(ClientId, DateTime.Today.AddDays(-61), DateTime.Today.AddDays(-31), DateTime.Today.AddDays(-10));

            Assert.NotNull(result);
        }

    }
}