using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTCinema.Comon;

namespace VTCinema.Controllers.Admin.Login
{
    [Route("Admin/Logout")]
    public class LogoutController : BaseController
    {
        public IActionResult Index()
        {
            HttpContext.Session.Clear();           
            return View("~/Views/Admin/Login/login.cshtml");
        }
    }
}
