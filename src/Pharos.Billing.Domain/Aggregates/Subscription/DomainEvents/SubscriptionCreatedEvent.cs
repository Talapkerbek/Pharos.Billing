using Pharos.Billing.Domain.Abstraction;
using Pharos.Billing.Domain.Aggregates.Feature;

namespace Pharos.Billing.Domain.Aggregates.Subscription.DomainEvents;

public record SubscriptionCreatedEvent(SubscriptionId SubscriptionId, List<FeatureId> FeatureIds, string StripeSubscriptionId, Guid SubscriberId) : IDomainEvent;