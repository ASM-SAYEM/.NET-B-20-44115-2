using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class OTPresetDTO
    {
        public int Id { get; set; }
        
        public string OTP { get; set; }
       
        public DateTime CreateTime { get; set; }

        public DateTime DeleteTime { get; set; }

        
        public string UserName { get; set; }
    }
}