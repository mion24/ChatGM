using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Create
{
    public static class CreateAccountSpecification
    {
        public static Contract<Notification> Ensure(CreateAccountRequest request)
            => new Contract<Notification>()
        .Requires()
        .IsNotNull(request.EmailAddress, "EmailAddress")
        .IsNotNull(request.PlainTextPassword, "Password")
        .IsLowerThan(request.EmailAddress.Length, 160, "Name", "O Email deve conter menos que 160 caracteres")
        .IsGreaterThan(request.EmailAddress.Length, 3, "Name", "O Email deve conter mais que 3 caracteres")
        .IsLowerThan(request.PlainTextPassword.Length, 40, "Password", "A senha deve conter menos que 40 caracteres")
        .IsGreaterThan(request.PlainTextPassword.Length, 8, "Password", "A senha deve conter mais que 8 caracteres")
        .IsEmail(request.EmailAddress, "Email", "E-mail inválido");
    }
}
