using System;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blip.Api.Template.Controllers
{
    /// <summary>
    /// Controller responsible only for check API uptime for alarms
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// Returns 200 if the API is Online
        /// </summary>
        /// <returns>Basic DateTime info for the server</returns>
        [HttpGet]
        public IActionResult HealthCheck()
        {
            var now = DateTime.Now;
            return Ok($"It's alive! Server Date Time: {now.ToLongDateString()} {now.ToLongTimeString()} - Daylight Saving: {now.IsDaylightSavingTime()}");
        }

        /// <summary>
        /// Returns 200 if you're authorized, 401 if not
        /// </summary>
        [HttpGet("Authorization"), Authorize]
        public IActionResult AuthorizationCheck()
        {
            return Ok("You're authorized!");
        }
    }
}
