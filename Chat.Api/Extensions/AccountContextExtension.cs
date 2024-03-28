using Chat.Application.Contexts.AccountContext.UseCases;
using Chat.Infra.Contexts.AccountContext.UseCases;
using Chat.Application.Contexts.AccountContext.UseCases.Create;
using MediatR;

namespace Chat.Api.Extensions
{
    public static class AccountContextExtension
    {
        public static void AddAccountContext(this WebApplicationBuilder builder)
        {
            #region create
            builder.Services.AddTransient<IRepository, Repository>();
            #endregion
        }

        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region create
            app.MapPost("v1/users", async (CreateAccountRequest request, IRequestHandler<CreateAccountRequest,CreateAccountResponse> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Created($"/v1/users/{result.Data?.Id}", result)
                    : Results.Json(result, statusCode: result.Status);
            });
            #endregion
        }
    }
}
