using System.Threading.Tasks;

using Blip.Api.Template.Facades.Strategies.ExceptionHandlingStrategies;
using Blip.Api.Template.Tests.Setup.Controller;

using FluentAssertions;

using NSubstitute;

using Serilog;

using Xunit;

namespace Blip.Api.Template.Tests.Strategies.ExceptionHandlingStrategies
{
    public class ApiExceptionHandlingStrategyTests : BaseTests
    {
        private readonly ILogger _logger;

        public ApiExceptionHandlingStrategyTests()
        {
            _logger = Substitute.For<ILogger>();
        }

        private ApiExceptionHandlingStrategy CreateApiExceptionHandlingStrategy()
        {
            return new ApiExceptionHandlingStrategy(_logger);
        }

        [Fact]
        public async Task HandleAsyncExpectedBehaviorAsync()
        {
            var apiExceptionHandlingStrategy = CreateApiExceptionHandlingStrategy();

            var context = ControllerSetup.HttpContext;
            var exception = ControllerSetup.GetApiException(Faker);

            var result = await apiExceptionHandlingStrategy.HandleAsync(
                context,
                exception);

            result.Response.StatusCode.Should().Be((int)exception.StatusCode);
        }
    }
}
