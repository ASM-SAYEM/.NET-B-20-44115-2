using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.EF.Models
{
    public class Admin
    {
        [Key]
        public string UserName { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Type { get; set; }

        //
        //public virtual ICollection<Notification> SentNotifications { get; set; }

        //public Admin()
        //{
        //    SentNotifications = new List<Notification>();
        //}

        [Required]
        public string Phone { get; set; }
        [Required]
        public string Gmail { get; set; }
    }
}