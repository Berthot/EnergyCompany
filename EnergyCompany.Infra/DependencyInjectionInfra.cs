using EnergyCompany.Infra.Context;
using EnergyCompany.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyCompany.Infra;

public static class DependencyInjectionInfra
{
    public static void InfraDependencyInjection(this IServiceCollection services)
    {
        services.AddSingleton<IContext, Context.Context>();
        services.AddTransient<IEndPointRepository, EndPointRepository>();
    }
}