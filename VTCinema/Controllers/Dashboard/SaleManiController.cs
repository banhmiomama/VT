using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTTECH_2019_08_20.Models;

namespace VTCinema.Controllers.Dashboard
{
    [Route("SaleMain")]
    public class SaleManiController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Dashboard/SaleMain.cshtml");
        }
    }
}