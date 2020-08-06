using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog;
using RestEase;
using Blip.Api.Template.Models;

namespace Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategy : ExceptionHandlingStrategy
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategy(ILogger logger)
        {
            _logger = logger;
        }

        public override async Task<HttpContext> HandleAsync(HttpContext context, Exception exception)
        {
            var apiException = exception as NotImplementedException;
            _logger.Error(apiException, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], apiException.Message);
            context.Response.StatusCode = StatusCodes.Status501NotImplemented;

            return await Task.FromResult(context);
        }
    }
}
