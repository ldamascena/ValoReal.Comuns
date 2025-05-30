using Montanelli.Application.Services;
using Montanelli.Application.Services.Interfaces;
using ValoReal.Comuns.Application.Services;
using ValoReal.Comuns.Application.Services.Interfaces;
using ValoReal.Comuns.Domain.Interfaces.Repositories;
using ValoReal.Comuns.Domain.Repositories;
using ValoReal.Comuns.Domain.UoW;
using ValoReal.Comuns.Infrastructure.Repositories;
using ValoReal.Comuns.Infrastructure.UoW;
using ValoReal.Comuns.Interfaces.Repositorios;

namespace ValoReal.Comuns.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services)
    {   

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Repositórios
        services.AddScoped(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IPessoaRepository, PessoaRepository>();

        // // Serviços
        services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IPessoaService, PessoaService>();

        return services;
    }
}
