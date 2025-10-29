using Marten;
using Pharos.Billing.Domain.Abstraction.Repositories;
using Pharos.Billing.Domain.Aggregates.Feature;
using Pharos.Billing.Domain.Aggregates.Feature.Events;

namespace Pharos.Billing.Infra.Repositories.FeatureRepo;

public class FeatureRepository(IDocumentSession session) : RepositoryBase<Feature, FeatureId>(session), IFeatureRepository
{
    public async Task<Feature> LoadAsync(FeatureId id, CancellationToken ct)
    {
        return await base.LoadAsync<Feature>(id.Value, ct);
    }

    public async Task<bool> ExistByTypeAsync(FeatureType type, CancellationToken ct = default)
    {
        return await session.Events.QueryRawEventDataOnly<FeatureCreatedEvent>()
            .FirstOrDefaultAsync(e => e.FeatureType == type, token: ct) is not null;
    }
}