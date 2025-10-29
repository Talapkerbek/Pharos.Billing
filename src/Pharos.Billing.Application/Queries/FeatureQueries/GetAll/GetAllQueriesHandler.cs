using Pharos.Billing.Infra.Marten.QueryServices.Feature;
using Pharos.Billing.Infra.Marten.ReadModels;

namespace Pharos.Billing.Application.Queries.FeatureQueries.GetAll;

public class GetAllQueriesHandler
{
    public async Task<IReadOnlyList<FeatureReadModel>> Handle(GetAllFeaturesQuery query, IFeatureQueryService  queryService)
    {
       return await queryService.GetAllAsync();
    }
}