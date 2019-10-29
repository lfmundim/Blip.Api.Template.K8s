using Blip.Api.Template.Facades.Interfaces;
using Blip.Api.Template.Models;
using Blip.Api.Template.Models.Ui;

using Microsoft.AspNetCore.Http;

namespace Blip.Api.Template.Facades
{
    public class AuthorizationFacade : IAuthorizationFacade
    {
        private readonly ApiSettings _settings;

        public AuthorizationFacade(ApiSettings settings)
        {
            _settings = settings;
        }

        public bool IsValidBotKey(HttpContext context) => 
                            _settings.BlipBotSettings
                            .Authorization
                            .Equals(context.Request.Headers[Constants.BLIP_BOT_KEY]);
    }
}
