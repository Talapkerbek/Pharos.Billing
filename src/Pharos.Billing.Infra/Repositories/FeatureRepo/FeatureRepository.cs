using Marten;
using Pharos.Billing.Domain.Feature;

namespace Pharos.Billing.Infra.Repositories.FeatureRepo;

public class FeatureRepository(IDocumentSession session) : RepositoryBase<Feature, FeatureId>(session), IFeatureRepository
{
    public async Task<Feature> LoadAsync(FeatureId id, CancellationToken ct)
    {
        return await base.LoadAsync<Feature>(id.Value, ct);
    }

}