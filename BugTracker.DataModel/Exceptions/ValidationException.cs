using System;
using System.Collections.Generic;

namespace BugTracker.DataModel.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
