namespace Core.Domain.Customers
{
    public class PaymentMethod : BaseEntity
    {
        public PaymentMethod(string cardId, string last4, string customerId)
        {
            CardId = cardId;
            Last4 = last4;
            CustomerId = customerId;
        }

        public string CardId { get; } // payments provider id
        public string Last4 { get; }

        public string CustomerId { get; set; }
        public bool IsDefault { get; set; }
    }
}