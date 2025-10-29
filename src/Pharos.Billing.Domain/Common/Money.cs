namespace Pharos.Billing.Domain.Common;

public record Money(long AmountInCents)
{
    public static Money operator +(Money a, Money b) => new(a.AmountInCents + b.AmountInCents);
    public static Money operator -(Money a, Money b) => new(a.AmountInCents - b.AmountInCents);
    public bool IsPositive() => AmountInCents > 0;
}