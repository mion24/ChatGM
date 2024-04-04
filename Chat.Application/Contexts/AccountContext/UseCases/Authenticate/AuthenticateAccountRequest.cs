using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Authenticate
{
    public record AuthenticateAccountRequest(string EmailAddress, string PlainTextPassword) : IRequest<AuthenticateAccountResponse>;
}
