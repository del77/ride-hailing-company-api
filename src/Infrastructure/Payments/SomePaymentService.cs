using System.Threading.Tasks;
using Application.Services;
using Core.Interfaces;

namespace Infrastructure.Payments
{
    public class SomePaymentService : IPaymentService
    {
        public async Task<bool> FetchMoney(string cardId, decimal amount, string currency)
        {
            // use payment provider
            return await Task.FromResult(true);
        }
    }
}