using Marten;
using Pharos.Billing.Domain.Feature;
using Pharos.Billing.Infra.Repositories.FeatureRepo;

namespace Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;

public class CreateFeatureHandler()
{
    public async Task Handle(CreateFeatureCommand command, IFeatureRepository repository)
    {
        var feature = new Feature(command.Name);
        await repository.StoreAsync(feature);
    }
}