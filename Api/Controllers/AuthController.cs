using System.Threading.Tasks;
using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterAccount(RegisterAccountCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(LoginCommand command)
        {
            return await Mediator.Send(command);
        }
    }
}