using Pharos.Billing.Domain.Abstraction;

namespace Pharos.Billing.Domain.Aggregates.Subscription.DomainEvents;

public record SubscriptionPaymentConfirmed(SubscriptionId SubscriptionId, DateTimeOffset CurrentPeriodEndDate) : IDomainEvent;