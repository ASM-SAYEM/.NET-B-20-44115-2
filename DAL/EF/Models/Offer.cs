using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class Offer
    {
        [Key]
        public int offerId { get; set; }
        [Required]
        [StringLength(100)]
        public string offerName { get; set; }
        [Required]
        [StringLength(100)]
        public string offerType { get; set; }
        [Required]
        [StringLength(100)]
        public string offerDescription { get; set; }
        [Required]
        public DateTime offerStarts { get; set; }
        [Required]
        public DateTime offerEnd { get; set; }

        [ForeignKey("Admin")]
        public string Assignby { get; set; }

        public virtual Admin Admin { get; set; }
    }
}