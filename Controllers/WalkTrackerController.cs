using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using ViberWalkTracker.BLL;
using ViberWalkTracker.ViberModels.DeliveryModels;
using ViberWalkTracker.ViberModels.ReceivedModels;

namespace ViberWalkTracker.Controllers
{
    [Route("")]
    [ApiController]
    public class WalkTrakerController : ControllerBase
    {
        private WalkService _walkService;
        private ViberApiService _viberApiService;
        public WalkTrakerController(WalkService walkService, ViberApiService viberApiService)
        {
            _walkService = walkService;
            _viberApiService = viberApiService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] object response)
        {
            await _viberApiService.ProcessReceivedObject(response);
            return Ok();
        }


    }
}
