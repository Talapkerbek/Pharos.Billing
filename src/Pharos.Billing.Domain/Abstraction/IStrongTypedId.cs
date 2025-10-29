namespace Pharos.Billing.Domain.Abstraction;

public interface IStrongTypedId
{
    Guid Value { get; }
}