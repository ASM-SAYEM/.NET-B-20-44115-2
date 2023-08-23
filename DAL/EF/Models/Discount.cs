using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class Discount
    {
        [Key]
        public int DiscountId { get; set; }

        // public string UserName { get; set; }

        // public virtual ICollection<Client> Clients { get; set; }
        [Required]
        [ForeignKey("Client")]
        public string ClientUserName { get; set; }

        [Required]
        public double DiscountPercentage { get; set; }

        public virtual Client Client { get; set; }
    }
}