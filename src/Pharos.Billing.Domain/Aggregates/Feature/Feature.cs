using Pharos.Billing.Domain.Abstraction;
using Pharos.Billing.Domain.Aggregates.Feature.Events;
using Pharos.Billing.Domain.Common;

namespace Pharos.Billing.Domain.Aggregates.Feature;

public class Feature : AggregateBase<FeatureId>
{
    public string Name { get; private set; } = String.Empty;
    public Money BasePrice { get; private set; } = null!;
    public string StripePriceId {get; private set; } = null!;
    public string StripeProductId {get; private set; } = null!;
    public FeatureType FeatureType { get; private set; }
    
    public Feature() {}

    #region FeatureCreatedEvent

    public Feature(string name, Money basePrice, string stripePriceId, string stripeProductId, FeatureType featureType)
    {
        if (String.IsNullOrWhiteSpace(name)) throw new DomainException("Feature name cannot be null or whitespace.");
        if (String.IsNullOrWhiteSpace(stripePriceId)) throw new DomainException("Feature stripePriceId cannot be null or whitespace.");
        if (String.IsNullOrWhiteSpace(stripeProductId)) throw new DomainException("Feature stripeProductId cannot be null or whitespace.");
        
        var @event = new FeatureCreatedEvent(FeatureId.New(), name,  basePrice, stripePriceId, featureType, stripeProductId);
        AddUncommittedEvent(@event);
        Apply(@event);
    }
    
    public void Apply(FeatureCreatedEvent @event)
    {
        Id = @event.Id;
        Name = @event.Name;
        BasePrice = @event.BasePrice;
        StripePriceId = @event.StripePriceId;
        FeatureType = @event.FeatureType;
        Version++;
    }

    #endregion

    #region FeatureNameChangedEvent

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
    
    public void Apply(FeatureNameChangedEvent @event)
    {
        Name = @event.Name;
        Version++;
    }

    #endregion
}