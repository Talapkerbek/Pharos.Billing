namespace Pharos.Billing.Domain.Aggregates.Subscription;

public enum SubscriptionStatus
{
    Active,
    PastDue,
    Pending,
    Canceled
}
