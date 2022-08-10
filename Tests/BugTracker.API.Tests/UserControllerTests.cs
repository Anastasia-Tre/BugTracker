using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI;
using BugTracker.WebAPI.Model.Response.User;
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
        public async Task GetUser_SuccessfulResult()
        {
            var userId = 1;
            var user = new User<int>
            {
                Id = userId,
                Name = "name",
                Email = "email@gmail.com",
                Password = "password"
            };
            _mock.Setup(userService => userService.GetUserById(userId))
                .ReturnsAsync(user);

            var response = await _httpClient.GetAsync($"User?UserId={userId}");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<UserResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(user),
                JsonConvert.SerializeObject(returnedResponse.User));
        }

        [Fact]
        public async Task GetUser_UserNotFoundException_404()
        {
            var userId = 1;
            _mock.Setup(userService => userService.GetUserById(userId))
                .ThrowsAsync(new Exception("User not found"));

            var response = await _httpClient.GetAsync($"User?UserId={userId}");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task GetAllUsers_SuccessfulResult()
        {
            User<int>[] users =
            {
                new()
                {
                    Id = 1,
                    Name = "name1",
                    Email = "email1@gmail.com",
                    Password = "password1"
                },
                new()
                {
                    Id = 2,
                    Name = "name2",
                    Email = "email2@gmail.com",
                    Password = "password2"
                }
            };


            _mock.Setup(userService => userService.GetAllUsers())
                .ReturnsAsync(users);

            var response = await _httpClient.GetAsync("User/all");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<UsersResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(users),
                JsonConvert.SerializeObject(returnedResponse.Users));
        }

        [Fact]
        public async Task GetAllUsers_EmptyResult()
        {
            var users = new User<int>[] { };
            _mock.Setup(userService => userService.GetAllUsers())
                .ReturnsAsync(users);

            var response = await _httpClient.GetAsync("User/all");
            response.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            var returnedJson = await response.Content.ReadAsStringAsync();
            var returnedResponse =
                JsonConvert.DeserializeObject<UsersResponse>(returnedJson);
            Assert.Equal(
                JsonConvert.SerializeObject(users),
                JsonConvert.SerializeObject(returnedResponse.Users));
        }

        [Fact]
        public async Task GetAllUsers_Exception_404()
        {
            _mock.Setup(userService => userService.GetAllUsers())
                .ThrowsAsync(new Exception());

            var response = await _httpClient.GetAsync("User/all");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
