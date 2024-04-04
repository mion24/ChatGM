using Chat.Domain.Contexts.SharedContext.ValueObjects;
using SecureIdentity.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Domain.Contexts.AccountContext.ValueObjects
{
    public class Password : ValueObject
    {
        protected Password()
        { }

        public Password(string plainPassword)
        {
            Hash = PasswordHasher.Hash(plainPassword);
        }

        public string Hash { get; private set; } = string.Empty;

        public static implicit operator Password(string plainPassword)
            => new Password(plainPassword);
    }
}
