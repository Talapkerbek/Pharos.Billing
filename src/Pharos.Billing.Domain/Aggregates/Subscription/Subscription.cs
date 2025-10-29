using Pharos.Billing.Domain.Abstraction;
using Pharos.Billing.Domain.Aggregates.Feature;
using Pharos.Billing.Domain.Aggregates.Subscription.DomainEvents;

namespace Pharos.Billing.Domain.Aggregates.Subscription;

public class Subscription : AggregateBase<SubscriptionId>
{
    public string StripeSubscriptionId { get; private set; } = String.Empty;
    public Guid SubscriberId { get; private set; }
    public List<FeatureId> FeatureIds { get; private set; } = new List<FeatureId>();
    public SubscriptionStatus Status { get; private set; }
    public DateTimeOffset? CurrentPeriodEnd { get; private set; }
    
    private readonly List<Guid> _subscribedFeaturesIds = new();
    public IReadOnlyList<Guid> SubscribedFeaturesIds => _subscribedFeaturesIds.AsReadOnly();
    
    public Subscription () {}

    #region SubscriptionCreatedEvent

    public void Subscribe(string stripeSubscriptionId, List<FeatureId> featureIds, Guid subscriberId)
    {
        var @event = new SubscriptionCreatedEvent(SubscriptionId.New(), featureIds, stripeSubscriptionId, subscriberId);
        
        AddUncommittedEvent(@event);
        Apply(@event);
    }

    private void Apply(SubscriptionCreatedEvent @event)
    {
        Id = @event.SubscriptionId;
        StripeSubscriptionId = @event.StripeSubscriptionId;
        FeatureIds = @event.FeatureIds;
        SubscriberId = @event.SubscriberId;
        Status = SubscriptionStatus.Pending;
    }

    #endregion

    #region SubscriptionPaymentConfirmedEvent

    public void ConfirmPayment(DateTimeOffset currentPeriodEndDate)
    {
        var @event = new SubscriptionPaymentConfirmed(Id, currentPeriodEndDate);
        
        AddUncommittedEvent(@event);
        Apply(@event);
    }

    private void Apply(SubscriptionPaymentConfirmed @event)
    {
        Status = SubscriptionStatus.Active;
        CurrentPeriodEnd = @event.CurrentPeriodEndDate;
    }
    
    #endregion
    
    
}