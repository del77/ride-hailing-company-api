﻿using System;
using System.Collections.Generic;

namespace Core.Domain.Customers
{
    public class PaymentMethod : BaseEntity
    {
        public string CardId { get; private set; } // payments provider id
        public string Last4 { get; private set; }

        public string CustomerId { get; set; }

        public PaymentMethod(string cardId, string last4, string customerId)
        {
            CardId = cardId;
            Last4 = last4;
            CustomerId = customerId;
        }
    }
}