using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class TokenDTO
    {
        public int Id { get; set; }
        public string TokenKey { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiredAt { get; set; }
    }
}