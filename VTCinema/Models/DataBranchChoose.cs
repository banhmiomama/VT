using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataBranchChoose
    {
        public int? BranchID { get; set; }
        public string BranchCode { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public float? Latitude { get; set; }
        public float? Longtitude { get; set; }
        public string Note { get; set; }

    }
}
