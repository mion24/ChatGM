using Chat.Application.Contexts.AccountContext.UseCases;
using Chat.Infra.Contexts.AccountContext.UseCases;
using Chat.Application.Contexts.AccountContext.UseCases.Create;
using MediatR;
using Chat.Application.Contexts.AccountContext.UseCases.Authenticate;

namespace Chat.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region Repositorio
            builder.Services.AddTransient<IRepository, Repository>();
            #endregion
        }

        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Register
            app.MapPost("v1/users", async (CreateAccountRequest request, IRequestHandler<CreateAccountRequest, CreateAccountResponse> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Created($"/v1/users/{result.Data?.Id}", result)
                    : Results.Json(result, statusCode: result.Status);
            });
            #endregion

            #region Auth
            app.MapPost("v1/authenticate", async (AuthenticateAccountRequest request, IRequestHandler<AuthenticateAccountRequest, AuthenticateAccountResponse> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());

                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                return Results.Ok(result);

            });
            #endregion
        }
    }
}
