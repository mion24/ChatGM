﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Contexts.SharedContext.Entities
{
    public abstract class Entity : IEquatable<Guid>
    {
        protected Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        public bool Equals(Guid id)
            => Id == id;
    }
}
