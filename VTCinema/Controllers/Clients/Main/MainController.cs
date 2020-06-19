using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Admin.Clients.Main
{
    [Route("Main")]
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Clients/Main/MainView.cshtml");
        }
    }
}
