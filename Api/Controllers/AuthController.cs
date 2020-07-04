using System;
using System.Threading.Tasks;
using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost("register")]
        public async Task<ActionResult<string>> RegisterAccount(RegisterAccount command)
        {
            return await Mediator.Send(command);
        }
        
    }
}