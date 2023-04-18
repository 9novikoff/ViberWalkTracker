using Microsoft.AspNetCore.Mvc;
using ViberWalkTracker.BLL;
using ViberWalkTracker.DAL;

namespace ViberWalkTracker.Controllers
{
    [Route("")]
    [ApiController]
    public class WalkTrakerController : ControllerBase
    {
        private WalkService _walkService;
        public WalkTrakerController(WalkService walkService)
        {
            _walkService = walkService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string imei = "359339077003915";
            return Ok(await _walkService.GetAllWalksByIMEI(imei));
        }

    }
}
