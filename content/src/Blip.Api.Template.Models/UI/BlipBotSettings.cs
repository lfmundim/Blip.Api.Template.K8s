namespace Blip.Api.Template.Models.UI
{
    /// <summary>
    /// Collection of a Bot's info
    /// </summary>
    public class BlipBotSettings
    {
        /// <summary>
        /// Bot's BLiP Identifier
        /// </summary>
        public string Identifier { get; set; }

        /// <summary>
        /// Bot's BLiP AccessKey
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Bot's BLiP Authorization Key Header
        /// </summary>
        public string Authorization { get; set; }

        /// <summary>
        /// Ammount of channels to be used
        /// </summary>
        public int ChannelCount { get; set; }
    }
}
