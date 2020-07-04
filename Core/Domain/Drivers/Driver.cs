using System;
using System.Collections.Generic;

namespace Core.Domain.Drivers
{
    public class Driver : BaseEntity, IAggregateRoot
    {
        public Guid IdentityId { get; private set; }
        public IEnumerable<Opinion> Opinions { get; private set; }

        public Driver(Guid identityId)
        {
            IdentityId = identityId;
            Opinions = new List<Opinion>();
        }
    }
}