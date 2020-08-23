using System.Threading.Tasks;
using Application.CustomerRides.Commands;
using Application.CustomerRides.Queries;
using Application.Customers.Commands;
using Application.Customers.Queries;
using Core.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = UserRoles.Customer, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomerRidesController : ApiController
    {
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentRide()
        {
            var ride = await Mediator.Send(new GetCurrentRideQuery());

            return Ok(ride);
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetRidesHistory()
        {
            var rides = await Mediator.Send(new GetRidesHistoryQuery());

            return Ok(rides);
        }

        [HttpGet("unpaid")]
        public async Task<IActionResult> GetUnpaidRides()
        {
            var unpaidRides = await Mediator.Send(new GetUnpaidRidesQuery());

            return Ok(unpaidRides);
        }
        
        [HttpPost("order")]
        public async Task<IActionResult> OrderRide(OrderRideCommand command)
        {
            var id = await Mediator.Send(command);

            return CreatedAtAction(nameof(GetCurrentRide), null);
        }

        [HttpPatch("{rideId}/cancel")]
        public async Task<IActionResult> CancelRequestedRide([FromRoute]CancelRequestedRideCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpPatch("{rideId}/pay")]
        public async Task<IActionResult> PayForRide([FromRoute]PayForRideCommand command)
        {
            var paymentResult = await Mediator.Send(command);

            return Ok(new {paymentResult});
        }
    }
}