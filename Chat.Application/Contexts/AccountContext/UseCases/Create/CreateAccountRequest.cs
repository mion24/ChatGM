using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Create
{
    public record CreateAccountRequest(string EmailAddress, string FirstName, string LastName, string PlainTextPassword) : IRequest<CreateAccountResponse>;
}
