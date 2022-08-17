using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoBogus;
using BugTracker.DataModel;
using BugTracker.WebAPI.Controllers;
using BugTracker.WebAPI.Features.BugFeatures.Queries;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace BugTracker.API.Tests
{
    public class BugControllerTests
    {
        private readonly Mock<IMediator> _mediator;
        private readonly BugController _target;

        public BugControllerTests()
        {
            _mediator = new Mock<IMediator>();
            _target = new BugController(_mediator.Object);
        }

        [Fact]
        public async Task GetBugById_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<Bug<int>>();
            _mediator.Setup(x => x.Send(
                    new GetBugByIdQuery() { BugId = expected.Id },
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
        public async Task GetAllBugs_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<IEnumerable<Bug<int>>>();
            _mediator.Setup(x => x.Send(
                    new GetAllBugsQuery(),
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
        public async Task SearchBugs_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<IEnumerable<Bug<int>>>();
            var searchString = AutoFaker.Generate<string>();
            _mediator.Setup(x => x.Send(
                    new GetBugsBySearchStringQuery() { SearchString = searchString },
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // act
            var actual = await _target.SearchBugs(searchString);
            var okResult = actual as ObjectResult;

            // assert
            okResult.Should().NotBeNull();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetBugsForUser_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<IEnumerable<Bug<int>>>();
            var userId = AutoFaker.Generate<int>();
            _mediator.Setup(x => x.Send(
                    new GetBugsByUserQuery() { UserId = userId },
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // act
            var actual = await _target.GetBugsForUser(userId);
            var okResult = actual as ObjectResult;

            // assert
            okResult.Should().NotBeNull();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task GetBugsForProject_ReturnsOk()
        {
            // arrange
            var expected = AutoFaker.Generate<IEnumerable<Bug<int>>>();
            var projectId = AutoFaker.Generate<int>();
            _mediator.Setup(x => x.Send(
                    new GetBugsByProjectQuery() { ProjectId = projectId },
                    It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            // act
            var actual = await _target.GetBugsForProject(projectId);
            var okResult = actual as ObjectResult;

            // assert
            okResult.Should().NotBeNull();
            okResult.Should().BeOfType<OkObjectResult>();
            okResult!.StatusCode.Should().Be(StatusCodes.Status200OK);
        }
    }
}
