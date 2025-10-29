using Pharos.Billing.Domain.Abstraction;

namespace Pharos.Billing.Domain.Aggregates.Feature.Events;

public record FeatureNameChangedEvent(Aggregates.Feature.FeatureId Id, string Name) : IDomainEvent;