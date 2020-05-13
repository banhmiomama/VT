using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Index
{
    [Route("Index")]
    public class IndexController : Controller
    {
        [Route("/")]
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            return View("~/Views/Index/Index.cshtml");
        }
        [Route("Authorize")]
        //[ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Authorize(string KEYCODE)
        {
            return Json(new { data = "/Login" });
        }

    }
}