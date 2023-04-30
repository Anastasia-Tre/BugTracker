using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoBogus;
using BugTracker.WebAPI.Controllers;
using BugTracker.WebAPI.Features.TaskFeatures.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BugTracker.API.Tests;

public class TaskControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly TaskController _target;

    public TaskControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _target = new TaskController(_mediator.Object);
    }

    [Fact]
    public async Task GetTaskById_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<DataModel.Task<int>>();
        _mediator.Setup(x => x.Send(
                new GetTaskByIdQuery { TaskId = expected.Id },
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
    public async Task GetAllTasks_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<IEnumerable<DataModel.Task<int>>>();
        _mediator.Setup(x => x.Send(
                new GetAllTasksQuery(),
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

    [Fact]
    public async Task SearchTasks_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<IEnumerable<DataModel.Task<int>>>();
        var searchString = AutoFaker.Generate<string>();
        _mediator.Setup(x => x.Send(
                new GetTasksBySearchStringQuery
                    { SearchString = searchString },
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var actual = await _target.SearchTasks(searchString);
        var okResult = actual as ObjectResult;

        // assert
        okResult.Should().NotBeNull();
        okResult.Should().BeOfType<OkObjectResult>();
        okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetTasksForUser_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<IEnumerable<DataModel.Task<int>>>();
        var userId = AutoFaker.Generate<int>();
        _mediator.Setup(x => x.Send(
                new GetTasksByUserQuery { UserId = userId },
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var actual = await _target.GetTasksForUser(userId);
        var okResult = actual as ObjectResult;

        // assert
        okResult.Should().NotBeNull();
        okResult.Should().BeOfType<OkObjectResult>();
        okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
    }

    [Fact]
    public async Task GetTasksForProject_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<IEnumerable<DataModel.Task<int>>>();
        var projectId = AutoFaker.Generate<int>();
        _mediator.Setup(x => x.Send(
                new GetTasksByProjectQuery { ProjectId = projectId },
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var actual = await _target.GetTasksForProject(projectId);
        var okResult = actual as ObjectResult;

        // assert
        okResult.Should().NotBeNull();
        okResult.Should().BeOfType<OkObjectResult>();
        okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}
