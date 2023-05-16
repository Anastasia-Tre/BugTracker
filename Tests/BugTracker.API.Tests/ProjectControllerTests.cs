using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoBogus;
using Bugify.Domain.AggregatesModel.ProjectAggregate;
using BugTracker.WebAPI.Controllers;
using BugTracker.WebAPI.Features.ProjectFeatures.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BugTracker.API.Tests;

public class ProjectControllerTests
{
    private readonly Mock<IMediator> _mediator;
    private readonly ProjectController _target;

    public ProjectControllerTests()
    {
        _mediator = new Mock<IMediator>();
        _target = new ProjectController(_mediator.Object);
    }

    [Fact]
    public async Task GetProjectById_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<Project<int>>();
        _mediator.Setup(x => x.Send(
                new GetProjectByIdQuery { ProjectId = expected.Id },
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
    public async Task GetAllProjects_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<IEnumerable<Project<int>>>();
        _mediator.Setup(x => x.Send(
                new GetAllProjectsQuery(),
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
    public async Task SearchProjects_ReturnsOk()
    {
        // arrange
        var expected = AutoFaker.Generate<IEnumerable<Project<int>>>();
        var searchString = AutoFaker.Generate<string>();
        _mediator.Setup(x => x.Send(
                new GetProjectsBySearchString
                    { SearchString = searchString },
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(expected);

        // act
        var actual = await _target.SearchProjects(searchString);
        var okResult = actual as ObjectResult;

        // assert
        okResult.Should().NotBeNull();
        okResult.Should().BeOfType<OkObjectResult>();
        okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
    }
}
