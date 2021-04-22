using System.Threading.Tasks;

using Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies;
using Blip.Api.Template.Tests.Setup.Controller;

using Microsoft.AspNetCore.Http;

using NSubstitute;

using Serilog;

using Shouldly;

using Xunit;

namespace Blip.Api.Template.Tests.Strategies.ExceptionHandlingStrategies
{
    public class NotImplementedExceptionHandlingStrategyTests : BaseTests
    {
        private readonly ILogger _logger;

        public NotImplementedExceptionHandlingStrategyTests()
        {
            _logger = Substitute.For<ILogger>();
        }

        private NotImplementedExceptionHandlingStrategy CreateNotImplementedExceptionHandlingStrategy()
        {
            return new NotImplementedExceptionHandlingStrategy(_logger);
        }

        [Fact]
        public async Task HandleAsyncExpectedBehaviorAsync()
        {
            var notImplementedExceptionHandlingStrategy = CreateNotImplementedExceptionHandlingStrategy();

            var context = ControllerSetup.HttpContext;
            var exception = ControllerSetup.GetNotImplementedException(Faker);

            var result = await notImplementedExceptionHandlingStrategy.HandleAsync(
                context,
                exception);

            result.Response.StatusCode.ShouldBe(StatusCodes.Status501NotImplemented);
        }
    }
}
