using System;

using RestEase;

using Serilog;

namespace Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies
{
    public class ApiExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        #region Public Constructors

        public ApiExceptionHandlingStrategy(ILogger logger) : base(logger) { }

        #endregion Public Constructors

        #region Internal Methods

        internal override int GetStatusCode(Exception exception)
        {
            var apiException = exception as ApiException;
            return (int)apiException.StatusCode;
        }

        #endregion Internal Methods
    }
}
