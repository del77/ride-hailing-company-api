namespace Core.Domain.Customers
{
    public class PaymentMethod : ValueObject
    {
        public string CardNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CVV { get; private set; }
        public string MonthValidity { get; private set; }
        public string YearValidity { get; private set; }
    }
}