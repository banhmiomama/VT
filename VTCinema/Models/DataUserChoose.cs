using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataUserChoose
    {
        public string Name { get; set; }
        public int? Employee_ID { get; set; }
        public int? Branch_ID { get; set; }
        public  int? Group_ID { get; set; }
        public string Username { get; set; }
        public int? isAllBranch { get; set; }
        public  string Password { get; set; }
        public string Note { get; set; }
        public string AreaBranch { get; set; }

    }
}
