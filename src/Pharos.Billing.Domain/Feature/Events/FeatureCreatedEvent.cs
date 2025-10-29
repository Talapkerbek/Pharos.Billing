using Pharos.Billing.Domain.Abstraction;

namespace Pharos.Billing.Domain.Feature.Events;

public record FeatureCreatedEvent(FeatureId Id, string Name) : IDomainEvent;