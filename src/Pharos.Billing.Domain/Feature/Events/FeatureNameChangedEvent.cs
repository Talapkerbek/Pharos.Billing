using Pharos.Billing.Domain.Abstraction;

namespace Pharos.Billing.Domain.Feature.Events;

public record FeatureNameChangedEvent(FeatureId Id, string Name) : IDomainEvent;