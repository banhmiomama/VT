using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataProductChoose
    {
        public int? ProductID { get; set; }
        public string NameProduct { get; set; }
        public string Image { get; set; }
        public int? TypeID { get; set; }
        public int? Price { get; set; }
    }
}
