using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI;
using BugTracker.WebAPI.Model.Response.Project;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BugTracker.API.Tests
{
    public class ProjectControllerTests : IAsyncLifetime
    {
        private readonly Mock<IProjectService<int>> _mock = new();

        private HttpClient _httpClient;

        public async Task InitializeAsync()
        {
            var hostBuilder = Program.CreateHostBuilder(new string[0])
                .ConfigureWebHost(webHostBuilder => {
                    webHostBuilder.UseTestServer();
                })
                .ConfigureServices((_, services) => {
                    services.AddSingleton(_mock.Object);
                });

            var host = await hostBuilder.StartAsync();
            _httpClient = host.GetTestClient();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task GetProject_SuccessfulResult()
        {
            var projectId = 1;
            var project = new Project<int>
            {
                Id = projectId,
                Name = "name",
                Description = "description"
            };
            _mock.Setup(projectService => projectService.GetProjectById(projectId))
                .ReturnsAsync(project);

            var response = await _httpClient.GetAsync($"Project?ProjectId={projectId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<ProjectResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(project),
                JsonConvert.SerializeObject(returnedResponse.Project));
        }

        [Fact]
        public async Task GetProject_ProjectNotFoundException_404()
        {
            var projectId = 1;
            _mock.Setup(projectService => projectService.GetProjectById(projectId))
                .ThrowsAsync(new Exception("Project not found"));

            var response = await _httpClient.GetAsync($"Project?ProjectId={projectId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
        /*
        [Fact]
        public async Task GetAllProjects_SuccessfulResult()
        {
            Project<int>[] projects =
            {
                new Project<int>
                {
                    Id = 1,
                    Name = "name1",
                    Description = "description1"
                },
                new Project<int>
                {
                    Id = 2,
                    Name = "name2",
                    Description = "description2"
                }
            };

            _mock.Setup(projectService => projectService.SearchProjects(null))
                    .ReturnsAsync(projects);

            var response = await _httpClient.GetAsync($"Project/all");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<ProjectsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(projects),
                JsonConvert.SerializeObject(returnedResponse.Projects));
        }
        

        [Fact]
        public async Task GetAllProjects_EmptyResult()
        {
            var projects = new Project<int>[] { };
            _mock.Setup(projectService => projectService.SearchProjects(null))
                .ReturnsAsync(projects);

            var response = await _httpClient.GetAsync($"Project/all");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<ProjectsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(projects),
                JsonConvert.SerializeObject(returnedResponse.Projects));
        }
        */

        [Fact]
        public async Task GetAllProjects_Exception_404()
        {
            _mock.Setup(projectService => projectService.SearchProjects(null))
                .ThrowsAsync(new Exception());

            var response = await _httpClient.GetAsync($"Project/all");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task SearchProjects_SuccessfulResult()
        {
            Project<int>[] projects =
            {
                new Project<int>
                {
                    Id = 1,
                    Name = "name1",
                    Description = "description1"
                },
                new Project<int>
                {
                    Id = 2,
                    Name = "name2",
                    Description = "description2"
                }
            };
            var searchStr = "name";
            _mock.Setup(projectService => projectService.SearchProjects(searchStr))
                .ReturnsAsync(projects);

            var response = await _httpClient.GetAsync($"Project/search?SearchString={searchStr}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<ProjectsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(projects),
                JsonConvert.SerializeObject(returnedResponse.Projects));
        }

        [Fact]
        public async Task SearchProjects_SuccessfulEmptyResult()
        {
            var projects = new Project<int>[] { };
            var searchStr = "name";
            _mock.Setup(projectService => projectService.SearchProjects(searchStr))
                .ReturnsAsync(projects);

            var response = await _httpClient.GetAsync($"Project/search?SearchString={searchStr}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<ProjectsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(projects),
                JsonConvert.SerializeObject(returnedResponse.Projects));
        }

    }
}
