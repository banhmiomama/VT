using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Admin.Clients
{
    [Route("404")]
    public class ErroController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Clients/Main/404/ErroView.cshtml");
        }
    }
}
