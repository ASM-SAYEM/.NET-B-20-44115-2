using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BAL.DTOs
{
    public class OfferDTO
    {
        public int offerId { get; set; }

        public string offerName { get; set; }

        public string offerType { get; set; }

        public string offerDescription { get; set; }

        public string Assignby { get; set; }

        public DateTime offerStarts { get; set; }

        public DateTime offerEnd { get; set; }
    }
}