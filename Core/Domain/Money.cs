namespace Core.Domain
{
    public class Money : ValueObject
    {
        public string Currency { get; private set; }
        public decimal Value { get; private set; }

        public Money(string currency, decimal value)
        {
            Currency = currency;
            Value = value;
        }

        public Money DecreaseByPercent(decimal percent) => new Money(Currency, Value * (1 + percent / 100m));
    }
}