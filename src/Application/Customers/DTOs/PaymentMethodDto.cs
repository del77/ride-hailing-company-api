using System;

namespace Application.Customers.DTOs
{
    public class PaymentMethodDto
    {
        public Guid Id { get; set; }
        public string Last4 { get; set; }
    }
}