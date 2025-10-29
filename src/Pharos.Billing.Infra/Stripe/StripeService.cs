using Pharos.Billing.Domain.Common;
using Stripe;

namespace Pharos.Billing.Infra.Stripe;

public class StripeService : IStripeService
{
    public StripeService()
    {
    }

    public async Task<string> CreateCustomerAsync(string email, string name, CancellationToken ct = default)
    {
        var options = new CustomerCreateOptions
        {
            Email = email,
            Name = name
        };
        var service = new CustomerService();
        var customer = await service.CreateAsync(options, cancellationToken: ct);
        return customer.Id;
    }

    public async Task<(string PriceId, string ProductId)> CreateProductAndPriceAsync(string productName, Money money, CancellationToken ct = default)
    {
        var productOptions = new ProductCreateOptions
        {
            Name = productName
        };
        
        var productService = new ProductService();
        var product = await productService.CreateAsync(productOptions, cancellationToken: ct);

        var priceOptions = new PriceCreateOptions
        {
            UnitAmount = money.AmountInCents,
            Currency = "usd",
            Product = product.Id,
            Recurring = new PriceRecurringOptions
            {
                Interval = "month" 
            }
        };
        
        var priceService = new PriceService();
        var price = await priceService.CreateAsync(priceOptions, cancellationToken: ct);
        
        return (price.Id, product.Id);
    }

    public async Task<string> CreateSubscriptionAsync(string customerId, IEnumerable<string> priceIds, CancellationToken ct = default)
    {
        var subscriptionOptions = new SubscriptionCreateOptions
        {
            Customer = customerId,
            Items = priceIds.Select(p => new SubscriptionItemOptions { Price = p }).ToList()
        };

        var subscriptionService = new SubscriptionService();
        var subscription = await subscriptionService.CreateAsync(subscriptionOptions, cancellationToken: ct);
        return subscription.Id;
    }

    public async Task UpdateSubscriptionAsync(string subscriptionId, IEnumerable<string> priceIds, CancellationToken ct = default)
    {
        var subscriptionService = new SubscriptionService();

        var subscription = await subscriptionService.GetAsync(subscriptionId, cancellationToken: ct);
        var items = priceIds.Select((p, i) => new SubscriptionItemOptions
        {
            Id = i < subscription.Items.Data.Count ? subscription.Items.Data[i].Id : null,
            Price = p
        }).ToList();

        var updateOptions = new SubscriptionUpdateOptions
        {
            Items = items
        };

        await subscriptionService.UpdateAsync(subscriptionId, updateOptions, cancellationToken: ct);
    }

    public async Task CancelSubscriptionAsync(string subscriptionId, CancellationToken ct = default)
    {
        var subscriptionService = new SubscriptionService();
        await subscriptionService.CancelAsync(subscriptionId, cancellationToken: ct);
    }
}