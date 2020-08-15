using System.Threading.Tasks;
using Application.Customers.Commands;
using Application.Customers.Queries;
using Core.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Authorize(Roles = UserRoles.Customer, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CustomersController : ApiController
    {
        [HttpGet("rides/current")]
        public async Task<IActionResult> GetCurrentRide()
        {
            var ride = await Mediator.Send(new GetCurrentRideQuery());

            return Ok(ride);
        }

        [HttpGet("rides/history")]
        public async Task<IActionResult> GetRidesHistory()
        {
            var rides = await Mediator.Send(new GetRidesHistoryQuery());

            return Ok(rides);
        }

        [HttpGet("rides/unpaid")]
        public async Task<IActionResult> GetUnpaidRides()
        {
            var unpaidRides = await Mediator.Send(new GetUnpaidRidesQuery());

            return Ok(unpaidRides);
        }

        [HttpGet("payment-methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var paymentMethods = await Mediator.Send(new GetPaymentMethodsQuery());

            return Ok(paymentMethods);
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

        [HttpPatch("rides/{rideId}/pay")]
        public async Task<IActionResult> PayForRide(PayForRideCommand command)
        {
            var paymentResult = await Mediator.Send(command);

            return Ok(new {paymentResult});
        }
    }
}