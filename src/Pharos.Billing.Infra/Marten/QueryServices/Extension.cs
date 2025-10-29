using Microsoft.Extensions.DependencyInjection;
using Pharos.Billing.Infra.Marten.QueryServices.Feature;
using Pharos.Billing.Infra.Repositories.FeatureRepo;

namespace Pharos.Billing.Infra.Marten.QueryServices;

public static class Extension
{
    public static IServiceCollection AddQueryServices(this IServiceCollection services)
    {
        services.AddScoped<IFeatureQueryService, FeatureQueryService>();
        
        return services;
    }
}