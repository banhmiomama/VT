using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Admin.Schedule
{
    [Route("Admin/Calendar")]
    public class CalendarController : BaseController
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Schedule/CalendarView.cshtml");
        }
        [Route("LoadCalendar")]
        [HttpPost]
        public string LoadCalendar()
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Schedule_Calendar_LoadList]", CommandType.StoredProcedure);

                }
                return dt != null ? JsonConvert.SerializeObject(dt) : "[]";
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}