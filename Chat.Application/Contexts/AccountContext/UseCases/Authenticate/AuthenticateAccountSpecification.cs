using Chat.Application.Contexts.AccountContext.UseCases.Create;
using Flunt.Notifications;
using Flunt.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Authenticate
{
    public class AuthenticateAccountSpecification
    {
        public static Contract<Notification> Ensure(AuthenticateAccountRequest request)
           => new Contract<Notification>()
       .Requires()
       .IsNotNull(request.EmailAddress, "EmailAddress")
       .IsNotNull(request.PlainTextPassword, "Password")
       .IsLowerThan(request.EmailAddress.Length, 160, "Email", "Email inválido")
       .IsGreaterThan(request.EmailAddress.Length, 3, "Email", "Email inválido")
       .IsLowerThan(request.PlainTextPassword.Length, 40, "Password", "Senha inválida")
       .IsGreaterThan(request.PlainTextPassword.Length, 8, "Password", "Senha inválida")
       .IsEmail(request.EmailAddress, "Email", "E-mail inválido");
    }
}
