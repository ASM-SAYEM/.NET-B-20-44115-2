using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class ServiceProviderPayment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ServiceProvider")]
        public int ServiceProviderId { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }

        public int Amount { get; set; }

        public DateTime PaymentDate { get; set; }
    }
}