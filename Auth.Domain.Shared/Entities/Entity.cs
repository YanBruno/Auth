using Flunt.Notifications;
using System;

namespace Auth.Domain.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

    }
}
