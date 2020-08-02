using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VTCinema.Models
{
    public class DataUserChoose
    {
        public int? UserID { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public int? EmployeeID { get; set; }
        public int? BranchID { get; set; }
        public int? GroupID { get; set; }
        public string Password { get; set; }
        public int? isAllBranch { get; set; }
        public string AreaBranch { get; set; }
        public string Note { get; set; }
    }
}
