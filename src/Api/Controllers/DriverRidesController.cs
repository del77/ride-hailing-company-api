using System.Threading.Tasks;
using Application.DriverRides.Commands;
using Application.DriverRides.Queries;
using Core.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class DriverRidesController : ApiController
    {
        [HttpGet("requested")]
        public async Task<IActionResult> GetRequestedRides()
        {
            var rides = await Mediator.Send(new GetRequestedRidesQuery());

            return Ok(rides);
        }

        [HttpPatch("{rideId}/pick-up-ride")]
        public async Task<IActionResult> PickUpRide(PickUpRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPatch("{rideId}/start-ride")]
        public async Task<IActionResult> StartRide(StartRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPatch("{rideId}/finish")]
        public async Task<IActionResult> FinishRide(FinishRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}