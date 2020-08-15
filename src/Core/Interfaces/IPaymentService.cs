using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> FetchMoney(string cardId, decimal amount, string currency);
    }
}