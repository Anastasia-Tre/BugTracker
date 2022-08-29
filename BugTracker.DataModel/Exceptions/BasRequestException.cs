using System;

namespace BugTracker.DataModel.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
        {
        }

        public BadRequestException(string message) : base(message)
        {
        }

        public BadRequestException(string message, Exception exp) : base(
            message, exp)
        {
        }
    }
}
