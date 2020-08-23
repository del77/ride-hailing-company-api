using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Money : ValueObject<Money>
    {
        private Money() { }
        
        public static Money Zero => new Money(Currencies.Usd, 0m);
        
        public Money(string currency, decimal value)
        {
            Currency = currency;
            Value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public string Currency { get; } = null!;
        public decimal Value { get; }

        public Money DecreaseByPercent(decimal percent)
        {
            return new Money(Currency, Value * (1 + percent / 100m));
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Value;
        }
    }
}