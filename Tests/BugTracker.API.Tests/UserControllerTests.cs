using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AutoBogus;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using BugTracker.WebAPI;
using BugTracker.WebAPI.Controllers;
using BugTracker.WebAPI.Features.ProjectFeatures.Queries;
using BugTracker.WebAPI.Features.UserFeatures.Queries;
using BugTracker.WebAPI.Model.Response.User;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace BugTracker.API.Tests
{
    public class UserControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly UserController _target;

        public UserControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _target = new UserController(_mediator.Object);
        }

        [Fact]
        public async Task GetUserById_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<User<int>>();
            _mediator.Setup(x => x.Send(
                    new GetUserByIdQuery() { UserId = expected.Id },
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // act
            var actual = await _target.GetById(expected.Id);
            var okResult = actual as ObjectResult;

            // assert
            okResult.Should().NotBeNull();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetAllUsers_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<IEnumerable<User<int>>>();
            _mediator.Setup(x => x.Send(
                    new GetAllUsersQuery(),
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // act
            var actual = await _target.GetAll();
            var okResult = actual as ObjectResult;

            // assert
            okResult.Should().NotBeNull();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
