using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class Notification
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string ServiceProviderName { get; set; }

        [Required]
        [StringLength(255)]
        public string Message { get; set; }

        [Required]
        public DateTime DateSent { get; set; }

        [ForeignKey("Admin")]
        public string SentByAdminUserName { get; set; }

        public virtual Admin Admin { get; set; }
    }

}
