using Pharos.Billing.Domain.Abstraction;
using Pharos.Billing.Domain.Feature.Events;

namespace Pharos.Billing.Domain.Feature;

public class Feature : AggregateBase<FeatureId>
{
    public string Name { get; private set; } = String.Empty;
    
    public Feature()
    {
    }
    
    public Feature(string name)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new DomainException("Feature name cannot be null or whitespace.");
        
        var @event = new FeatureCreatedEvent(FeatureId.New(), name);
        AddUncommittedEvent(@event);
        Apply(@event);
    }

    public void ChangeName(string name)
    {
        if (string.IsNullOrWhiteSpace(name)) 
            throw new DomainException("Feature name cannot be null or whitespace.");
    
        if (Name == name) 
            throw new DomainException("Feature name is already set to the specified value.");
    
        var @event = new FeatureNameChangedEvent(FeatureId.New(), name);
        AddUncommittedEvent(@event);
        Apply(@event);
    }

    public void Apply(FeatureCreatedEvent @event)
    {
        Id = @event.Id;
        Name = @event.Name;
        Version++;
    }
    
    public void Apply(FeatureNameChangedEvent @event)
    {
        Name = @event.Name;
        Version++;
    }
}