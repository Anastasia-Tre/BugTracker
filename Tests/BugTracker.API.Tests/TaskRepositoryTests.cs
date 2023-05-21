using System;
using System.Linq;
using System.Threading.Tasks;
using Bugify.Domain.AggregatesModel.ProjectAggregate;
using Bugify.Domain.AggregatesModel.TaskAggregate;
using Bugify.Infrastructure;
using Bugify.Infrastructure.Repositories.EFImplementation;
using Microsoft.EntityFrameworkCore;
using Xunit;
using TaskStatus = Bugify.Domain.AggregatesModel.TaskAggregate.TaskStatus;

namespace Bugify.API.Tests;

public class TaskRepositoryTests
{
    private readonly DbContextOptions<BugTrackerDbContext> _options;

    public TaskRepositoryTests()
    {
        _options = new DbContextOptionsBuilder<BugTrackerDbContext>()
            .UseInMemoryDatabase(databaseName: "BugTrackerTest")
            .Options;
    }

    [Fact]
    public async Task Search_ReturnsMatchingTasks()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var searchString = "test";
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.Search(searchString);

        // Assert
        Assert.NotNull(result);
        //Assert.All(result, task =>
        //    task.Name.ToLower().Contains(searchString.ToLower()) ||
        //    task.Description.ToLower().Contains(searchString.ToLower()));
    }

    [Fact]
    public async Task GetTasksForProject_ReturnsTasksForProject()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.GetTasksForProject(projectId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, task => Assert.Equal(projectId, task.ProjectId));
    }

    [Fact]
    public async Task GetTasksForUser_ReturnsTasksForUser()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.GetTasksForUser(userId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, task => Assert.Equal(userId, task.AssignedId));
    }

    [Fact]
    public async Task GetTaskInFocusForUser_ReturnsTaskInFocusForUser()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.New,
                Deadline = DateTime.Now.AddDays(1)
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.InProgress,
                Deadline = DateTime.Now.AddDays(2)
            },
            new TaskEntity<int>
            {
                Id = 3,
                Name = "Task 3",
                Description = "Important task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.New,
                Deadline = DateTime.Now.AddDays(3)
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.GetTaskInFocusForUser(userId);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(userId, result.AssignedId);
        Assert.True(result.Status == TaskStatus.New || result.Status == TaskStatus.InProgress);
        Assert.Equal(projectId, result.ProjectId);
        Assert.Equal(3, result.Id);
    }

    [Fact]
    public async Task GetTasksNowOrLaterForUser_ReturnsTasksNowOrLaterForUser()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.New,
                Difficulty = 1,
                Priority = TaskPriority.High,
                Deadline = DateTime.Now.AddDays(1)
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.InProgress,
                Difficulty = 2,
                Priority = TaskPriority.Low,
                Deadline = DateTime.Now.AddDays(2)
            },
            new TaskEntity<int>
            {
                Id = 3,
                Name = "Task 3",
                Description = "Important task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.New,
                Difficulty = 1,
                Priority = TaskPriority.Normal,
                Deadline = DateTime.Now.AddDays(3)
            },
            new TaskEntity<int>
            {
                Id = 4,
                Name = "Task 4",
                Description = "Later task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.New,
                Difficulty = 2,
                Priority = TaskPriority.High,
                Deadline = DateTime.Now.AddDays(4)
            },
            new TaskEntity<int>
            {
                Id = 5,
                Name = "Task 5",
                Description = "Another later task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.InProgress,
                Difficulty = 1,
                Priority = TaskPriority.Low,
                Deadline = DateTime.Now.AddDays(5)
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.GetTasksNowOrLaterForUser(userId);

        // Assert
        Assert.NotNull(result);
        Assert.All(result, task => {
            Assert.Equal(userId, task.AssignedId);
            Assert.True(task.Status == TaskStatus.New || task.Status == TaskStatus.InProgress);
            Assert.Equal(projectId, task.ProjectId);
        });
        Assert.Equal(4, result.Count());
    }

    [Fact]
    public async Task GetTotalTasksForUser_ReturnsTotalTasksForUser()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId
            },
            new TaskEntity<int>
            {
                Id = 3,
                Name = "Task 3",
                Description = "Yet another task",
                ProjectId = projectId,
                AssignedId = userId
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.GetTotalTasksForUser(userId);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public async Task GetCompleteTasksForUser_ReturnsCompleteTasksForUser()
    {
        // Arrange
        using var dbContext = new BugTrackerDbContext(_options);
        dbContext.Database.EnsureCreated();
        var repository = new EFTaskRepository(dbContext);
        var projectId = 1;
        var userId = 1;

        dbContext.Projects.Add(new ProjectEntity<int>
        {
            Id = projectId,
            Status = ProjectStatus.Open
        });

        dbContext.Tasks.AddRange(
            new TaskEntity<int>
            {
                Id = 1,
                Name = "Task 1",
                Description = "Test task 1",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.InTesting
            },
            new TaskEntity<int>
            {
                Id = 2,
                Name = "Task 2",
                Description = "Another test task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.Closed
            },
            new TaskEntity<int>
            {
                Id = 3,
                Name = "Task 3",
                Description = "Yet another task",
                ProjectId = projectId,
                AssignedId = userId,
                Status = TaskStatus.Closed
            });

        dbContext.SaveChanges();

        // Act
        var result = await repository.GetCompleteTasksForUser(userId);

        // Assert
        Assert.NotNull(result);
        //Assert.All<TaskEntity<int>>(result, task => Assert.Equal(userId, task.AssignedId));
        Assert.Equal(2, result);
    }
}