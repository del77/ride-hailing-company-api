using System;
using System.Collections.Generic;
using System.Linq;
using Core.Domain.Rides;

namespace Core.Domain.Customers
{
    public class Customer : IAggregateRoot
    {
        private readonly HashSet<PaymentMethod> _paymentMethods;

        private Customer()
        {
            Rides = new List<Ride>();
            _paymentMethods = new HashSet<PaymentMethod>();
        }

        public Customer(string id)
        {
            Id = id;
        }

        public string Id { get; } = null!;
        public IEnumerable<Ride> Rides { get; } = null!;

        public IEnumerable<PaymentMethod> PaymentMethods => _paymentMethods;

        public void AddPaymentMethod(PaymentMethod paymentMethod)
        {
            if (!PaymentMethods.Any(pm => pm.IsDefault))
                paymentMethod.IsDefault = true;
            
            _paymentMethods.Add(paymentMethod);
        }

        public void SetDefaultPaymentMethod(Guid paymentMethodId)
        {
            var currentlyDefaultPaymentMethod = _paymentMethods.FirstOrDefault(pm => pm.IsDefault);
            if (currentlyDefaultPaymentMethod != null)
                currentlyDefaultPaymentMethod.IsDefault = false;

            var newDefaultPaymentMethod = _paymentMethods.FirstOrDefault(pm => pm.Id == paymentMethodId);
            if (newDefaultPaymentMethod != null)
                newDefaultPaymentMethod.IsDefault = true;
        }

        public void DeletePaymentMethod(Guid paymentMethodId)
        {
            var paymentMethodToDelete = _paymentMethods.FirstOrDefault(pm => pm.Id == paymentMethodId);
            
            if(paymentMethodToDelete is null)
                return;

            _paymentMethods.Remove(paymentMethodToDelete);

            if (paymentMethodToDelete.IsDefault && _paymentMethods.Any())
                _paymentMethods.First().IsDefault = true;
        }
    }
}