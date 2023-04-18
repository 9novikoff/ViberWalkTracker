using Microsoft.AspNetCore.Mvc;

namespace ViberWalkTracker.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WebhookController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}
