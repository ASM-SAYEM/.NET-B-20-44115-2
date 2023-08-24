using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class OTPreset
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string OTP { get; set; }
        [Required]
        public DateTime CreateTime { get; set; }

        public DateTime DeleteTime { get; set; }

        [Required]
        [ForeignKey("Admin")]
        public string UserName { get; set; }
        public virtual Admin Admin { get; set; }

    }
}