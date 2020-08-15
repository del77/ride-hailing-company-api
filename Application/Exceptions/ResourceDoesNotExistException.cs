using System;

namespace Application.Exceptions
{
    public class ResourceDoesNotExistException : ApplicationException
    {
        public ResourceDoesNotExistException(Guid resourceId, Type type) : base(
            $"Resource of type \"{type.Name}\" with id {resourceId} does not exist.")
        {
        }

        public ResourceDoesNotExistException(Type type) : base(
            $"Resource of type \"{type.Name}\" does not exist.")
        {
        }

        public ResourceDoesNotExistException(string message, Exception e) : base(message, e)
        {
        }

        public override string Code { get; } = "resource_not_found";
    }
}