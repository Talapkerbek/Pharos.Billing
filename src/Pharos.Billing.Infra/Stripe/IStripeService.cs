using Pharos.Billing.Domain.Common;

namespace Pharos.Billing.Infra.Stripe;

public interface IStripeService
{
    Task<string> CreateCustomerAsync(string email, string name, CancellationToken ct = default);

    Task<(string PriceId, string ProductId)> CreateProductAndPriceAsync(string productName, Money amountInCents, CancellationToken ct = default);

    Task<string> CreateSubscriptionAsync(string customerId, IEnumerable<string> priceIds, CancellationToken ct = default);

    Task UpdateSubscriptionAsync(string subscriptionId, IEnumerable<string> priceIds, CancellationToken ct = default);

    Task CancelSubscriptionAsync(string subscriptionId, CancellationToken ct = default);
}