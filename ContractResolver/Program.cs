using ContractResolver.Domain.Handler;
using ContractResolver.Infra;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IAccountHandler, AccountHandler>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();

var app = builder.Build();

app.MapGet("/v1/accounts/{id}", (IAccountHandler accountHandler, int id, string? fields) =>
{
    var result = accountHandler.GetAccount(id, fields);
    
    switch (result.StatusCode)
    {
        case 200:
            return Results.Ok(result.Data);
        case 400:
            return Results.BadRequest(result.ErrorMessage);
        case 404:
            return Results.NotFound();
        default:
            return Results.Problem("Erro desconhecido");
    }
});

app.Run();