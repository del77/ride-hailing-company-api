using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Money : ValueObject<Money>
    {
        public string Currency { get; private set; }
        public decimal Value { get; private set; }

        public Money(string currency, decimal value)
        {
            Currency = currency;
            Value = decimal.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        public Money DecreaseByPercent(decimal percent) => new Money(Currency, Value * (1 + percent / 100m));
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Currency;
            yield return Value;
        }
    }
}