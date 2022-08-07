using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BugTracker.API.Tests
{
    public class UserControllerTests : IAsyncLifetime
    {
        private readonly Mock<IUserService<int>> _mock = new();

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

        [Fact]
        public async Task GetUser_HappyPath()
        {
            var userId = 1;
            var user = new User<int>
            {
                Id = userId,
                Name = "name",
                Email = "email",
                Password = "password"
            };
            _mock.Setup(userService => userService.GetUserById(userId))
                .ReturnsAsync(user);

            var response = await _httpClient.GetAsync($"User?UserId={userId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedUser = JsonConvert.DeserializeObject<User<int>>(returnedJson);
            Assert.Equal(user, returnedUser);
        }

    }
}
