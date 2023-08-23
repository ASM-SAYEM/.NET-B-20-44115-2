using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class WebsiteDTO
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string FeedbackBy { get; set; }

        public DateTime Date { get; set; }
    }
}