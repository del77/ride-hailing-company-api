using System.Collections.Generic;

namespace Core.Domain.Customers
{
    public class PaymentMethod : ValueObject<PaymentMethod>
    {
        public string CardNumber { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string CVV { get; private set; }
        public string MonthValidity { get; private set; }
        public string YearValidity { get; private set; }

        public PaymentMethod(string cardNumber, string firstName, string lastName, string cvv, string monthValidity, string yearValidity)
        {
            CardNumber = cardNumber;
            FirstName = firstName;
            LastName = lastName;
            CVV = cvv;
            MonthValidity = monthValidity;
            YearValidity = yearValidity;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return CardNumber;
            yield return FirstName;
            yield return LastName;
            yield return CVV;
            yield return MonthValidity;
            yield return YearValidity;
        }
    }
}