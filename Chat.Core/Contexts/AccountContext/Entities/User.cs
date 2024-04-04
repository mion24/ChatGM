using Chat.Domain.Contexts.AccountContext.ValueObjects;
using Chat.Domain.Contexts.SharedContext.Entities;

namespace Chat.Domain.Contexts.AccountContext.Entities
{
    public class User : Entity
    {
        protected User()
        { }

        public User(string emailAddress, string name, Password password, string? profilePhoto = null)
        {
            EmailAddress = emailAddress;
            Name = name;
            ProfilePhoto = profilePhoto;
            Password = password;
        }

        public string EmailAddress { get; private set; } = string.Empty;
        public string Name { get; private set; } = string.Empty;
        public Password Password { get; private set; } = null!;
        public string? ProfilePhoto { get; set; } = string.Empty;
    }
}
