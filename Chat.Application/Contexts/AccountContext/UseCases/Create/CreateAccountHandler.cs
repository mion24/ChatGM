using Chat.Application.Contexts.SharedContext.UseCases;
using Chat.Domain.Contexts.AccountContext.Entities;
using Chat.Domain.Contexts.AccountContext.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Create
{
    public class CreateAccountHandler(IRepository repository) : IRequestHandler<CreateAccountRequest, CreateAccountResponse>
    {
        private readonly IRepository _repository = repository;

        public async Task<CreateAccountResponse> Handle(CreateAccountRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var res = CreateAccountSpecification.Ensure(request);

                if (!res.IsValid)
                {
                    return new CreateAccountResponse("Requisição inválida", 400, res.Notifications);
                }
            }
            catch
            {
                return new CreateAccountResponse("Requisição não processada", 500);
            }

            User user;
            Name name;

            try
            {
                name = new(request.FirstName, request.LastName);
                user = new(request.EmailAddress, name, request.PlainTextPassword);
            }
            catch
            {
                return new CreateAccountResponse("Requisição não processada", 400);
            }

            try
            {
                var exists = await _repository.AnyAsync(request.EmailAddress, cancellationToken);

                if (exists)
                    return new CreateAccountResponse("Este E-mail já está em uso", 400);
            }
            catch
            {
                return new CreateAccountResponse("Falha ao verificar email cadastrado", 500);
            }

            try
            {
                await _repository.SaveAsync(user, cancellationToken);
            }
            catch
            {
                return new CreateAccountResponse("Falha ao persistir dados", 500);
            }

            return new CreateAccountResponse("Conta criada com sucesso", new ResponseData(user.Id));
        }
    }
}
