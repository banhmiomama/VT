using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Admin.Clients.SignUp
{
    [Route("SignUp")]
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Clients/SignUp/SignUpView.cshtml");
        }
    }
}