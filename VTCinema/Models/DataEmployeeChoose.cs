using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataEmployeeChoose
    {
        public int? EmployeeID { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int? Height { get; set; }
        public int? Weight { get; set; }
        public int? GroupID { get; set; }
        public string Address { get; set; }
        public int? State { get; set; }
        public string Password { get; set; }

    }
}
