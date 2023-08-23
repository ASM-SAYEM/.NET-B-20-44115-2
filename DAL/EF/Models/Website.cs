using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class Website
    {
        [Key]
        public int WebFeedbackId { get; set; }
        [Required]
        public string Description { get; set; }


        [ForeignKey("Client")]
        public string FeedbackBy { get; set; }

        public DateTime Date { get; set; }

        public virtual Client Client { get; set; }
    }
}