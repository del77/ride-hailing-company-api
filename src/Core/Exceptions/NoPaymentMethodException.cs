namespace Core.Exceptions
{
    public class NoPaymentMethodException : DomainException
    {
        public NoPaymentMethodException(string customerId) : base(
            $"Customer with id {customerId} does not have payment method.")
        {
        }

        public override string Code { get; } = "no_payment_method";
    }
}