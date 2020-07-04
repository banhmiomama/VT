using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTCinema.Comon;

namespace VTCinema.Controllers.Clients.SignIn
{
    [Route("SignIn")]
    public class SignInController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Clients/SignIn/SignInView.cshtml");
        }

        [Route("Login")]
        [HttpGet]
        public IActionResult Login(string username, string pass)
        {
            if (username != null && pass != null)
            {
                //   Comon.Global.DetectSettingAbosulute();
                GlobalUser user = new GlobalUser();
                int resulf = user.DetectAuthorisedClient(username.Replace("'", "").Trim(), pass.Replace("'", "").Trim());
                if (resulf != 0)
                {
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(GlobalClient.CustomerID)))
                    {
                        HttpContext.Session.SetInt32(GlobalClient.CustomerID, resulf);
                    }
                    //return RedirectToAction("Index", "ServiceDetail", new { Type = 27 });
                    return RedirectToAction("Index", "Main");
                }
                else
                {
                    //string Status = "Wrong username password";
                    //ViewBag.Status = Status;
                    return View("~/Views/Admin/Login/Login.cshtml");
                }
            }
            return View();
        }
    }
}
