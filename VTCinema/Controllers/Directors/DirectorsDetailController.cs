using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Directors
{
    [Route("Directors")]
    public class DirectorsDetailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}