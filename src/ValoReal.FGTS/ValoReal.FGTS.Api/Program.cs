using ValoReal.FGTS.Api.Configurations;
using Montanelli.API.Middlewares;
using Serilog;
using Scalar.AspNetCore;
using ValoReal.FGTS.Application.Services.Interfaces.ExternalServices;
using ValoReal.Comuns.Infrastructure.ExternalService.ComunsApi;

var builder = WebApplication.CreateBuilder(args);

// Configuração do Serilog
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Host.UseSerilog();

try
{
    // Configuração da API
    builder.Services.AddApiConfiguration(builder.Configuration);

    // Configuração de injeção de dependência
    builder.Services.AddDependencyInjectionConfiguration(builder.Configuration);

    var app = builder.Build();

    app.MapGet("/", () => Results.Redirect("/scalar/v1"));
        app.UseSwagger(options =>
        {
            options.RouteTemplate = "/openapi/{documentName}.json";
        });
        app.MapScalarApiReference(opt => opt
        .WithDarkMode(true)
        .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient));

    // Configuração dos middlewares e pipeline
    app.UseApiConfiguration(app.Environment);

    // Middleware para tratamento de exceções
    app.UseMiddleware<ExceptionMiddleware>();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "A aplicação falhou ao iniciar");
}
finally
{
    Log.CloseAndFlush();
}
