using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class RidesController : ApiController
    {
        // GET
        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            return Ok();
        }
    }
}