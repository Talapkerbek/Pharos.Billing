using Pharos.Billing.Domain.Abstraction;
using Pharos.Billing.Domain.Abstraction.Repositories;
using Pharos.Billing.Domain.Aggregates.Feature;
using Pharos.Billing.Domain.Common;
using Pharos.Billing.Domain.DomainServices.Abstraction;

namespace Pharos.Billing.Domain.DomainServices;

public class FeatureService(IFeatureRepository repository) : IFeatureService
{
    public async Task<Feature> CreateFeatureAsync
    (
        string name,
        Money basePrice,
        string stripePriceId,
        string stripeProductId,
        FeatureType featureType,
        CancellationToken ct = default
    )
    {
        if (await repository.ExistByTypeAsync(featureType, ct))
        {
            throw new DomainException($"Feature:{featureType} already exists"); 
        }

        var feature = new Feature(name, basePrice, stripePriceId, stripeProductId, featureType);
        await repository.StoreAsync(feature, ct);
        
        return feature;
    }
}