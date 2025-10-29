using Pharos.Billing.Domain.Aggregates.Feature;
using Pharos.Billing.Domain.Common;

namespace Pharos.Billing.Domain.DomainServices.Abstraction;

public interface IFeatureService
{
    Task<Feature> CreateFeatureAsync(string name, Money basePrice, string stripePriceId, string stripeProductId,
        FeatureType featureType, CancellationToken ct = default);
}