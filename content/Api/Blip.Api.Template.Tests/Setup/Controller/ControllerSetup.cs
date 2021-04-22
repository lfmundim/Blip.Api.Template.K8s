
using System;
using System.Net.Http;

using Blip.Api.Template.Models;

using Bogus;

using Microsoft.AspNetCore.Http;

using RestEase;

namespace Blip.Api.Template.Tests.Setup.Controller
{
    public static class ControllerSetup
    {
        #region Private Fields

        private const string HEADER_VALUE = "Header";

        #endregion Private Fields

        #region Public Properties

        public static HttpContext HttpContext
        {
            get
            {
                var context = new DefaultHttpContext();
                context.Request.Headers[Constants.BLIP_USER_HEADER] = HEADER_VALUE;
                return context;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public static ApiException GetApiException(Faker faker)
        {
            var response = new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                RequestMessage = new HttpRequestMessage(HttpMethod.Post,
                    faker.Internet.Url())
            };

            var exception = new ApiException(new HttpRequestMessage(HttpMethod.Post,
                faker.Internet.Url()), response, string.Empty);

            return exception;
        }

        public static NotImplementedException GetNotImplementedException(Faker faker)
        {
            var exception = new NotImplementedException(faker.Lorem.Text());

            return exception;
        }

        #endregion Public Methods
    }
}
