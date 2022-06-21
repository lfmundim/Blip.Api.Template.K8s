using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies;
using Blip.Api.Template.Models;

using Lime.Protocol;

using Microsoft.AspNetCore.Http;

using Newtonsoft.Json;

using Serilog;

namespace Blip.Api.Template.Middleware
{
    /// <summary>
    /// Wraps all controller actions with a try-catch latch to avoid code repetition
    /// </summary>
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;
        private readonly Dictionary<Type, ExceptionHandlingStrategy> _exceptionHandling;

        #pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        public ErrorHandlingMiddleware(RequestDelegate next, 
                                       ILogger logger,
                                       Dictionary<Type, ExceptionHandlingStrategy> exceptionHandling)
        #pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            _next = next;
            _logger = logger;
            _exceptionHandling = exceptionHandling;
        }

        /// <summary>
        /// Invoke Method, to validate requisition errors
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.EnableBuffering();
            
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            if (_exceptionHandling.TryGetValue(exception.GetType(), out var handler))
            {
                context = await handler.HandleAsync(context, exception);
            }
            else
            {
                _logger.Error(exception, "[{@user}] Error: {@exception}", context.Request.Headers[Constants.BLIP_USER_HEADER], exception.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }

            var requestBody = await GetRequestBodyAsync(context.Request);

            _logger.Error(exception, "[traceId:{@traceId}]{@user} Error. Headers: {@headers}. Query: {@query}. Path: {@path}. Body: {@requestBody}",
                          context.TraceIdentifier, context.Request.Headers[Constants.BLIP_USER_HEADER],
                          context.Request.Headers, context.Request.Query, context.Request.Path, requestBody);

            context.Response.ContentType = MediaType.ApplicationJson;
            await context.Response.WriteAsync(JsonConvert.SerializeObject($"{exception.Message}| traceId: {context.TraceIdentifier}"));
        }

        private async Task<string> GetRequestBodyAsync(HttpRequest request)
        {
            using (var reader = new StreamReader(request.Body, leaveOpen: true))
            {
                request.Body.Position = default;
                return await reader.ReadToEndAsync();
            }
        }
    }
}
