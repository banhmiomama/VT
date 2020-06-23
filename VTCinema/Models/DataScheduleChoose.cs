using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataScheduleChoose
    {
        public int? MovieID { get; set; }
        public int? BranchID { get; set; }
        public int? RoomID { get; set; }
        public int? TicketTypeID { get; set; }      
        public DateTime ShowTime { get; set; }
        public DateTime CloseTime { get; set; }
        public string Note { get; set; }
    }
}
