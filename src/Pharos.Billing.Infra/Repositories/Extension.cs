using Microsoft.Extensions.DependencyInjection;
using Pharos.Billing.Domain.Abstraction.Repositories;
using Pharos.Billing.Infra.Repositories.FeatureRepo;

namespace Pharos.Billing.Infra.Repositories;

public static class Extension
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        
        return services;
    }
}