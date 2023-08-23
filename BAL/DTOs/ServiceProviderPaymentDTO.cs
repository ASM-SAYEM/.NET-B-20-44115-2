using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class ServiceProviderPaymentDTO
    {
        public int PaymentId { get; set; }


        public int ServiceProviderId { get; set; }


        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}