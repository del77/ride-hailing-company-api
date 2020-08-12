using System.Threading.Tasks;
using Application.Rides.Command;
using Application.Rides.Queries;
using Core.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = UserRoles.Customer, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : ApiController
    {
        [HttpGet("{rideId}")]
        public async Task<IActionResult> GetById(GetRideQuery query)
        {
            var ride = Mediator.Send(query);
            
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> OrderRide(OrderRideCommand command)
        {
            var id = await Mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), id);
        }
        
        [HttpPatch("rides/{rideId}/cancel")]
        public async Task<IActionResult> CancelRequestedRide(CancelRequestedRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}