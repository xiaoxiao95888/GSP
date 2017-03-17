using System;

namespace Gsp.Api.Infrastructure.Exceptions
{
    public class ServiceException : Exception
    {
        public int ErrorCode { get; set; }
        public ServiceException(int errorCode, string message, Exception exception)
            : base(message, exception)
        {
            ErrorCode = errorCode;
        }
    }
}