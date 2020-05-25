using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Actor
{
    [Route("ActorDetail")]
    public class ActorDetailController : Controller
    {
        [Route("{ActorID}")]
        [HttpGet]
        public IActionResult Index(int ActorID)
        {
            ViewBag.ActorID = ActorID;
            return View("~/Views/Actor/ActorDetail.cshtml");
        }
    }
}