using Pharos.Billing.Infra.Marten.ReadModels;

namespace Pharos.Billing.Infra.Marten.QueryServices.Feature;

public interface IFeatureQueryService
{
    Task<IReadOnlyList<FeatureReadModel>> GetAllAsync();
}