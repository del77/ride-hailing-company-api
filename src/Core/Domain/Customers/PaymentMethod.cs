namespace Core.Domain.Customers
{
    public class PaymentMethod : BaseEntity
    {
        private PaymentMethod() { }
        
        public PaymentMethod(string cardId, string last4, string customerId)
        {
            CardId = cardId;
            Last4 = last4;
            CustomerId = customerId;
        }

        public string CardId { get; } = null!; // payments provider id
        public string Last4 { get; } = null!;

        public string CustomerId { get; set; } = null!;
        public bool IsDefault { get; set; }
    }
}