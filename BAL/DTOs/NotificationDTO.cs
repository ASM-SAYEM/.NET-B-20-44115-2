using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class NotificationDTO
    {
        public int Id { get; set; }
        public string ServiceProviderName { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public string SentByAdminUserName { get; set; }
    }
}