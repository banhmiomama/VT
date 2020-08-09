using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Admin.Room
{
    [Route("Admin/RoomChairDetail")]
    public class RoomChairDetailController : Controller
    {
        [Route("{RoomID}")]
        [HttpGet]
        public IActionResult Index(int RoomID)
        {
            ViewBag.RoomID = RoomID;
            return View("~/Views/Admin/Room/RoomChairDetail.cshtml");
        }
    }
}
