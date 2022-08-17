using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace BugTracker.WebAPI.Filters
{
    public class ExceptionFilterAttribute: Attribute, IExceptionFilter
    {
        private readonly IHostEnvironment _hostEnvironment;

        public ExceptionFilterAttribute(IHostEnvironment hostEnvironment) =>
            _hostEnvironment = hostEnvironment;

        public void OnException(ExceptionContext context)
        {
            if (!_hostEnvironment.IsDevelopment())
            {
                return;
            }

            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
