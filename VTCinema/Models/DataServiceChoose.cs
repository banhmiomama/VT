using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataServiceChoose
    {
        public int ? Number { get; set; }
        public decimal ?  Amount { get; set; }
        public int? ServiceID { get; set; }
        public decimal? DiscountPrice { get; set; }
        public decimal? FinalAmount { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public int? Consultant { get; set; }
        public int Gender { get; set; }
        public string Brithday  { get; set; } 
    }
}
