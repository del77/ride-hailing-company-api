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
        [HttpGet]
        public async Task<IActionResult> GetCurrentRide(GetCurrentRideQuery query)
        {
            var ride = await Mediator.Send(query);

            return Ok(ride);
        }

        [HttpGet]
        public async Task<IActionResult> GetRidesHistory(GetRidesHistoryQuery query)
        {
            var rides = await Mediator.Send(query);

            return Ok(rides);
        }

        [HttpPost]
        public async Task<IActionResult> OrderRide(OrderRideCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetCurrentRide), null);
        }

        [HttpPatch("rides/{rideId}/cancel")]
        public async Task<IActionResult> CancelRequestedRide(CancelRequestedRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}