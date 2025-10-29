using JasperFx;
using JasperFx.Events.Projections;
using Marten;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pharos.Billing.Infra.Marten.Projections;
using Pharos.Billing.Infra.Marten.ReadModels;
using Stripe;
using Wolverine.Marten;

namespace Pharos.Billing.Infra.Stripe;

public static class Extensions
{
    public static IServiceCollection AddStripe
    (
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
        
        services.AddScoped<IStripeService, StripeService>();

        return services;
    }
}