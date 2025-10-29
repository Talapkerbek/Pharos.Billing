using Microsoft.Extensions.Configuration;
using Pharos.Billing.Domain.DomainServices.Abstraction;

namespace Pharos.Billing.Domain.DomainServices;
using Microsoft.Extensions.DependencyInjection;

public static class Extensions
{
    public static IServiceCollection AddDomainServices
    (
        this IServiceCollection services
    )
    {
        services.AddScoped<IFeatureService, FeatureService>();
        
        return services;
    }
}