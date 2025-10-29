using Pharos.Billing.Domain.Aggregates.Feature;

namespace Pharos.Billing.Domain.Abstraction.Repositories;

public interface IFeatureRepository
{
    Task<Feature> LoadAsync(FeatureId id, CancellationToken ct);
    Task StoreAsync(Feature feature, CancellationToken ct = default);
    Task<bool> ExistByTypeAsync(FeatureType type, CancellationToken ct = default);
}