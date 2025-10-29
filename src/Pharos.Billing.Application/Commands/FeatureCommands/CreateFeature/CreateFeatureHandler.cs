using Pharos.Billing.Domain.DomainServices.Abstraction;
using Pharos.Billing.Infra.Stripe;

namespace Pharos.Billing.Application.Commands.FeatureCommands.CreateFeature;

public class CreateFeatureHandler()
{
    public async Task Handle(CreateFeatureCommand command, IFeatureService service, IStripeService stripeService)
    {
        var stripeRes = await stripeService.CreateProductAndPriceAsync(command.Name, command.BasePrice);
        
       await service.CreateFeatureAsync(command.Name, command.BasePrice, stripeRes.PriceId, stripeRes.ProductId, command.FeatureType);
    }
}