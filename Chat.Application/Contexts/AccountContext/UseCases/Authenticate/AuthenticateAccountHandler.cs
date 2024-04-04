using Chat.Application.Contexts.SharedContext.UseCases;
using Chat.Domain.Contexts.AccountContext.Entities;
using MediatR;
using SecureIdentity.Password;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Application.Contexts.AccountContext.UseCases.Authenticate
{
    public class AuthenticateAccountHandler(IRepository repository) : IRequestHandler<AuthenticateAccountRequest, AuthenticateAccountResponse>
    {
        private readonly IRepository _repository = repository;

        public async Task<AuthenticateAccountResponse> Handle(AuthenticateAccountRequest request, CancellationToken cancellationToken)
        {
            #region Validar notificações
            try
            {
                var res = AuthenticateAccountSpecification.Ensure(request);

                if (!res.IsValid)
                {
                    return new AuthenticateAccountResponse("Requisição inválida", 400, res.Notifications);
                }
            }
            catch 
            {
                return new AuthenticateAccountResponse("Requisição não processada", 500);
            }
            #endregion

            #region Procurar usuario

            User user;

            try
            {
                user = await _repository.GetUserByEmailAsync(request.EmailAddress, cancellationToken);

                if (user is null)
                    return new AuthenticateAccountResponse("Perfil não encontrado", 404);
            }
            catch
            {
                return new AuthenticateAccountResponse("Falha ao conectar com servidor", 500);
            }
            #endregion

            #region Validar senha

            try
            {
                if (!PasswordHasher.Verify(user.Password.Hash, request.PlainTextPassword))
                {
                    return new AuthenticateAccountResponse("Usuario ou senha inválidos", 400);
                }
            }
            catch
            {
                return new AuthenticateAccountResponse("Requisição não processada", 500);
            }

            #endregion

            #region Montar ResponseData
            try
            {
                ResponseData response = new ResponseData { Email = user.EmailAddress, Id = user.Id, Name = user.Name };

                return new AuthenticateAccountResponse(string.Empty, response);
            }
            catch (Exception)
            {

                throw;
            }
            #endregion
        }
    }
}
