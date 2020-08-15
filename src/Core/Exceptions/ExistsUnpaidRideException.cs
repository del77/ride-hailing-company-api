namespace Core.Exceptions
{
    public class ExistsUnpaidRideException : DomainException
    {
        public override string Code { get; } = "exists_unpaid_ride";

        public ExistsUnpaidRideException(string customerId) : base(
            $"Ride cannot be requested for customer with id {customerId} because there is other unpaid ride")
        {
        }
    }
}