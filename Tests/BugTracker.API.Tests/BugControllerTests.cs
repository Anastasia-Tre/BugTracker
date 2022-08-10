using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI;
using BugTracker.WebAPI.Model.Response.Bug;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BugTracker.API.Tests
{
    public class BugControllerTests : IAsyncLifetime
    {
        private readonly Mock<IBugService<int>> _mock = new();

        private HttpClient _httpClient;

        public async Task InitializeAsync()
        {
            var hostBuilder = Program.CreateHostBuilder(new string[0])
                .ConfigureWebHost(webHostBuilder =>
                {
                    webHostBuilder.UseTestServer();
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddSingleton(_mock.Object);
                });

            var host = await hostBuilder.StartAsync();
            _httpClient = host.GetTestClient();
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        private static Bug<int>[] GetTestData()
        {
            Bug<int>[] bugs =
            {
                new()
                {
                    Id = 1,
                    Name = "name1",
                    Description = "description1",
                    AssignToId = 1,
                    AuthorId = 1,
                    ProjectId = 1
                },
                new()
                {
                    Id = 2,
                    Name = "name2",
                    Description = "description2",
                    AssignToId = 2,
                    AuthorId = 2,
                    ProjectId = 2
                }
            };
            return bugs;
        }

        [Fact]
        public async Task GetBug_SuccessfulResult()
        {
            var bug = GetTestData()[0];
            _mock.Setup(bugService => bugService.GetBugById(bug.Id))
                .ReturnsAsync(bug);

            var response = await _httpClient.GetAsync($"Bug?BugId={bug.Id}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<BugResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(bug),
                JsonConvert.SerializeObject(returnedResponse.Bug));
        }

        [Fact]
        public async Task GetBug_BugNotFoundException_404()
        {
            var bugId = 1;
            _mock.Setup(bugService => bugService.GetBugById(bugId))
                .ThrowsAsync(new Exception("Bug not found"));

            var response = await _httpClient.GetAsync($"Bug?BugId={bugId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAllBugs_SuccessfulResult()
        {
            var bugs = GetTestData();

            _mock.Setup(bugService => bugService.SearchBugs(""))
                .ReturnsAsync(bugs);

            var response = await _httpClient.GetAsync("Bug/all");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<BugsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(bugs),
                JsonConvert.SerializeObject(returnedResponse.Bugs));
        }


        [Fact]
        public async Task GetAllBugs_EmptyResult()
        {
            var bugs = new Bug<int>[] { };
            _mock.Setup(bugService => bugService.SearchBugs(null))
                .ReturnsAsync(bugs);

            var response = await _httpClient.GetAsync("Bug/all");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<BugsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(bugs),
                JsonConvert.SerializeObject(returnedResponse.Bugs));
        }

        [Fact]
        public async Task GetAllBugs_Exception_404()
        {
            _mock.Setup(bugService => bugService.SearchBugs(""))
                .ThrowsAsync(new Exception());

            var response = await _httpClient.GetAsync("Bug/all");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task SearchBugs_SuccessfulResult()
        {
            var bugs = GetTestData();
            var searchStr = "name";
            _mock.Setup(bugService => bugService.SearchBugs(searchStr))
                .ReturnsAsync(bugs);

            var response =
                await _httpClient.GetAsync(
                    $"Bug/search?SearchString={searchStr}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<BugsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(bugs),
                JsonConvert.SerializeObject(returnedResponse.Bugs));
        }

        [Fact]
        public async Task SearchBugs_SuccessfulEmptyResult()
        {
            var bugs = new Bug<int>[] { };
            var searchStr = "name";
            _mock.Setup(bugService => bugService.SearchBugs(searchStr))
                .ReturnsAsync(bugs);

            var response =
                await _httpClient.GetAsync(
                    $"Bug/search?SearchString={searchStr}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<BugsResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(bugs),
                JsonConvert.SerializeObject(returnedResponse.Bugs));
        }
    }
}
