using Microsoft.AspNetCore.Mvc;
using Pokemon.ApiModels;
using System.Net;
using System.Threading.Tasks;

namespace Pokemon.Controllers
{
    [ApiController]
    [Route("healthcheck")]
    public class HealthCheckController : ControllerBase
    {
        /// <summary>
        /// The purpose of this is for either a deploy ready check, scale down check or something has gone wrong internally
        /// </summary>
        /// <returns>HealthCheckResponse</returns>
        [HttpGet]
        public async Task<ActionResult<HealthCheckResponse>> Get()
        {
            int responseStatusCode = (int)HttpStatusCode.OK; // I could use constants, but that felt weird

            // if something is wrong: (int)HttpStatusCode.ServiceUnavailable

            var healthResponse = new HealthCheckResponse
            {
                IsHealthy = true
            };

            return await Task.FromResult(StatusCode(responseStatusCode, healthResponse));
        }
    }
}
