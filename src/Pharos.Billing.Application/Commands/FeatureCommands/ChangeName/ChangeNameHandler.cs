using Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;
using Pharos.Billing.Domain.Abstraction.Repositories;
using Pharos.Billing.Domain.Aggregates.Feature;
using Pharos.Billing.Infra.Repositories.FeatureRepo;

namespace Pharos.Billing.Application.Commands.FeatureCommands.ChangeName;

public class ChangeFeatureNameHandler()
{
    public async Task Handle(ChangeFeatureNameCommand command, IFeatureRepository repository, CancellationToken ct)
    {
        var feature = await repository.LoadAsync(new FeatureId(command.Id), ct);
        feature.ChangeName(command.Name);

        await repository.StoreAsync(feature, ct);
    }
}