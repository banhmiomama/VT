using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataActorChoose
    {
        public int? ActorID { get; set; }
        public string Name { get; set; }
        public DateTime? Birthday { get; set; }
        public float Height { get; set; }
        public string Nationality { get; set; }
        public string Description { get; set; }
    }
}
