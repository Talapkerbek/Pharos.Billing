using Pharos.Billing.Domain.Abstraction;
using Pharos.Billing.Domain.Common;

namespace Pharos.Billing.Domain.Aggregates.Feature.Events;

public record FeatureCreatedEvent(FeatureId Id, string Name, Money BasePrice, string StripePriceId, FeatureType FeatureType, string StripeProductId) : IDomainEvent;