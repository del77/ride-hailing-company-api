using System;
using System.Collections;
using System.Collections.Generic;
using Core.Domain.Users;

namespace Core.Domain.Drivers
{
    public class Driver : BaseEntity
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;
        public IEnumerable<Opinion> Opinions { get; private set; }

        public Driver(Guid userId)
        {
            UserId = userId;
            Opinions = new List<Opinion>();
        }
    }
}