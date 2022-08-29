using EnergyCompany.Application.Handlers;
using EnergyCompany.Application.Main;
using EnergyCompany.Infra;
using Microsoft.Extensions.DependencyInjection;

namespace EnergyCompany.Application;

public static class DependencyInjectionApplication
{
    public static IServiceCollection ApplicationDependencyInjection(this IServiceCollection services)
    {
        services.AddTransient<CreateEndPointHandler>();
        services.AddTransient<UpdateEndPointHandler>();
        services.AddTransient<GetBySerialNumberHandler>();
        services.AddTransient<GetAllEndPointsHandler>();
        services.AddTransient<DeleteEndPointHandler>();
        services.AddTransient<Mediator>();
        services.InfraDependencyInjection();
        return services;
    }
}