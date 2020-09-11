using System;

using Microsoft.AspNetCore.Http;

using Serilog;

namespace Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        #region Public Constructors

        public NotImplementedExceptionHandlingStrategy(ILogger logger) : base(logger) { }

        #endregion Public Constructors

        #region Internal Methods

        internal override int GetStatusCode(Exception exception) => StatusCodes.Status501NotImplemented;

        #endregion Internal Methods
    }
}
