namespace Pharos.Billing.Domain.Abstraction;

public interface IEntity<T> where T : IStrongTypedId
{
    public T Id { get; }
}