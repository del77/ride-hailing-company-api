namespace Core.Exceptions
{
    public class DriverUnavailableException : DomainException
    {
        public DriverUnavailableException(string driverId) : base($"Driver with id {driverId} is unavailable.")
        {
        }

        public override string Code { get; } = "driver_unavailable";
    }
}