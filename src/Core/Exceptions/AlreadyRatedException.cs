namespace Core.Exceptions
{
    public class AlreadyRatedException : DomainException
    {
        public override string Code { get; } = "driver_already_rated";

        public AlreadyRatedException(string driverId, string userId) : base($"Driver {driverId} is already rated by user {userId}.")
        {
        }
    }
}