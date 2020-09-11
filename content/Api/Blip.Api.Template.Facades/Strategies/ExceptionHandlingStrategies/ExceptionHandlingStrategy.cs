using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using Serilog;

using Blip.Api.Template.Models;

namespace Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies
{
    public abstract class ExceptionHandlingStrategy
    {
        #region Private Fields

        private readonly ILogger _logger;

        #endregion Private Fields

        #region Public Constructors

        protected ExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            _logger.Error(exception, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], exception.Message);
            context.Response.StatusCode = GetStatusCode(exception);

            return await Task.FromResult(context);
        }

        #endregion Public Methods

        #region Internal Methods

        internal abstract int GetStatusCode(Exception exception);

        #endregion Internal Methods
    }
}
