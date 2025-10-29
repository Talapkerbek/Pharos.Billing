using Marten;
using Pharos.Billing.Infra.Marten.ReadModels;

namespace Pharos.Billing.Infra.Marten.QueryServices.Feature;

public class FeatureQueryService(IDocumentSession session) : QueryServiceBase<FeatureReadModel>(session), IFeatureQueryService
{
}