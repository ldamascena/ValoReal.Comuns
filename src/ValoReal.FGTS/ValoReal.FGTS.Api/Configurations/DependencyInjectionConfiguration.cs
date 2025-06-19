using ValoReal.FGTS.Domain.UoW;
using ValoReal.FGTS.Application.Services;
using ValoReal.FGTS.Application.Services.Interfaces;
using ValoReal.FGTS.Domain.Interfaces.Repositories;
using ValoReal.FGTS.Infrastructure.Repositories;
using ValoReal.FGTS.Infrastructure.UoW;
using ValoReal.FGTS.Application.Services.Interfaces.ExternalServices;
using ValoReal.Comuns.Infrastructure.ExternalService.ComunsApi;

namespace ValoReal.FGTS.Api.Configurations;

public static class DependencyInjectionConfiguration
{
    public static IServiceCollection AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
    {   

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Repositórios
        services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

        // Serviços Externos
        services.AddScoped<IComunsApiService, ComunsApiService>();
        services.AddHttpClient("ComunsApi", client =>{
            client.BaseAddress = new Uri(configuration["ExternalApis:ComunsApi"]);
        });

        // // Serviços
        services.AddScoped<IEmprestimoService, EmprestimoService>();
        

        return services;
    }
}
