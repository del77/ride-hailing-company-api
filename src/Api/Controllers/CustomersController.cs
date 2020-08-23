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
        [HttpGet("payment-methods")]
        public async Task<IActionResult> GetPaymentMethods()
        {
            var paymentMethods = await Mediator.Send(new GetPaymentMethodsQuery());

            return Ok(paymentMethods);
        }

        [HttpPost("payment-methods/add")]
        public async Task<IActionResult> AddPaymentMethod(AddPaymentMethodCommand command)
        {
            var id = await Mediator.Send(command);

            return Ok(id);
        }

        [HttpPatch("payment-methods/{paymentMethodId}/set-as-default")]
        public async Task<IActionResult> SetPaymentMethodAsDefault([FromRoute]SetDefaultPaymentMethodCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }

        [HttpDelete("payment-methods/{paymentMethodId}/delete")]
        public async Task<IActionResult> DeletePaymentMethod(DeletePaymentMethodCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}