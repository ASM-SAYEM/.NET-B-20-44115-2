using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FeedbackDescription { get; set; }
        [Required]
        public int Star { get; set; }

        public DateTime Date { get; set; }
        [ForeignKey("Client")]
        public string FeedbackBy { get; set; }
        [ForeignKey("ServiceProvider")]
        public int ServiceProviderId { get; set; }

        public virtual Client Client { get; set; }

        public virtual ServiceProvider ServiceProvider { get; set; }
    }
}