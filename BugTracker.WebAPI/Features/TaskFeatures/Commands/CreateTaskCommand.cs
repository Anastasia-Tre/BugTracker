﻿using System.Threading;
using BugTracker.DataModel;
using BugTracker.Services.Abstraction;
using MediatR;

namespace BugTracker.WebAPI.Features.TaskFeatures.Commands;

public class CreateTaskCommand : IRequest<Task<int>>
{
    public Task<int> Task { get; set; }

    public class
        CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand,
            Task<int>>
    {
        private readonly ITaskService<int> _service;

        public CreateTaskCommandHandler(ITaskService<int> service)
        {
            _service = service;
        }

        public async System.Threading.Tasks.Task<Task<int>> Handle(
            CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var result = await _service.CreateTask(request.Task);
            return result;
        }
    }
}
