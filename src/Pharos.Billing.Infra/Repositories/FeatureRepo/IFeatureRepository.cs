using Pharos.Billing.Domain.Feature;

namespace Pharos.Billing.Infra.Repositories.FeatureRepo;

public interface IFeatureRepository
{
    Task<Feature> LoadAsync(FeatureId id, CancellationToken ct);
    Task StoreAsync(Feature feature, CancellationToken ct = default);
}