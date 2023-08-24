using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TerraceGardenManagement.Models
{
    public class SetPassModel
    {
        [Required]
        public string Otp { get; set; }
        [Required]
        public string Password { get; set; }
    }
}