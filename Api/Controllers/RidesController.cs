using System;
using System.Threading.Tasks;
using Application.Rides.Command;
using Core.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class RidesController : ApiController
    {
        [HttpPost]
        [Authorize(Roles = UserRoles.Customer, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> OrderRide(OrderRideCommand command)
        {
            var id = await Mediator.Send(command);
            
            return CreatedAtAction(nameof(GetById), id);
        }
        
        [HttpPatch("{rideId}/cancel")]
        [Authorize(Roles = UserRoles.Customer, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> CancelRequestedRide(CancelRequestedRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPatch("{rideId}/pick-up-ride")]
        [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> PickUpRide(PickUpRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPatch("{rideId}/start-ride")]
        [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> StartRide(StartRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPatch("{rideId}/finish")]
        [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> FinishRide(FinishRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok();
        }

        [HttpGet("requested")]
        [Authorize(Roles = UserRoles.Driver, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetRequestedRides()
        {
            //todo
            return Ok();
        }
    }
}