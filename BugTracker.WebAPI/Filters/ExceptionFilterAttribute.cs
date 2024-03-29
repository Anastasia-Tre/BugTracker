﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace BugTracker.WebAPI.Filters;

public class ExceptionFilter : IExceptionFilter
{
    private readonly IHostEnvironment _hostEnvironment;

    public ExceptionFilter(IHostEnvironment hostEnvironment)
    {
        _hostEnvironment = hostEnvironment;
    }

    public void OnException(ExceptionContext context)
    {
        if (!_hostEnvironment.IsDevelopment()) return;

        context.Result = new ContentResult
        {
            Content = context.Exception.ToString()
        };
    }
}
