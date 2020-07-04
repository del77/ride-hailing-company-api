using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class RidesController : ControllerBase
    {
        // GET
        public IActionResult Index()
        {
            return Ok();
        }
    }
}