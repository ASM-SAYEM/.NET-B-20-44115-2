using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class ServiceProvider
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(100)]
        public string shortDescriprtion { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("Admin")]
        public string AssignedBy { get; set; }

        public virtual Admin Admin { get; set; }


        [ForeignKey("Client")]
        public string FeedbackBy { get; set; }

        public virtual Client Client { get; set; }

        public virtual ICollection<Feedback> ServiceProviders { get; set; }

        public ServiceProvider()
        {
            ServiceProviders = new List<Feedback>();
        }
    }
}