namespace Core.Exceptions
{
    public class InvalidOpinionValueException : DomainException
    {
        public override string Code { get; } = "invalid_opinion_value";

        public InvalidOpinionValueException(int opinionValue) : base($"Opinion value {opinionValue} is invalid.")
        {
        }
    }
}