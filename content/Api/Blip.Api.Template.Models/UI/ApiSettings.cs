using Blip.Api.Template.Models.UI;

namespace Blip.Api.Template.Models.Ui
{
    /// <summary>
    /// Class to use data from appsettings.json "Settings" field
    /// </summary>
    public class ApiSettings
    {
        /// <summary>
        /// Current API Version
        /// </summary>
        public string ApiVersion { get; set; }

        /// <summary>
        /// BLiP's Bots Authorization Keys
        /// </summary>
        public BlipBotSettings BlipBotSettings { get; set; }

        /// <summary>
        /// Sets wether or not the API should check for Bot's permission
        /// </summary>
        public bool CheckAuthorizationKey { get; set; }
    }
}
