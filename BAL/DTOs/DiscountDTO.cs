using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class DiscountDTO
    {
        public int DiscountId { get; set; }

        public string ClientUserName { get; set; }

        public double DiscountPercentage { get; set; }
    }
}