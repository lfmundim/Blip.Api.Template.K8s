using Microsoft.AspNetCore.Http;

namespace Blip.Api.Template.Facades.Interfaces
{
    public interface IAuthorizationFacade
    {
        /// <summary>
        /// Checks if the given bot is allowed to use the API
        /// </summary>
        /// <param name="context"></param>
        bool IsValidBotKey(HttpContext context);
    }
}
