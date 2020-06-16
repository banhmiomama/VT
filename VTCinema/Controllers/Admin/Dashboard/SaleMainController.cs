using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Dashboard
{
    [Route("Admin/SaleMain")]
    public class SaleMainController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Dashboard/SaleMain.cshtml");
        }
    }
}