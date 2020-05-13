using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VTTECH_2019_08_20.Comon;

namespace VTCinema.Controllers.Login
{
    [Route("Login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Status = "";
            return View("~/Views/Login/Login.cshtml");
        }
        [Route("Authorize")]
        [HttpGet]
        public IActionResult Authorize(string username, string pass)
        {
            if (username != null && pass != null)
            {
                //   Comon.Global.DetectSettingAbosulute();
                GlobalUser user = new GlobalUser();
                int resulf = user.DetectAuthorised(username.Replace("'", "").Trim(), pass.Replace("'", "").Trim());
                if (resulf != 0)
                {
                    if (string.IsNullOrEmpty(HttpContext.Session.GetString(Global.UserID)))
                    {
                        HttpContext.Session.SetInt32(Global.UserID, resulf);
                    }
                    //return RedirectToAction("Index", "ServiceDetail", new { Type = 27 });
                    return RedirectToAction("Index", "SaleMain");
                }
                else
                {
                    string Status = "Wrong username password";
                    ViewBag.Status = Status;
                    return View("~/Views/Login/Login.cshtml");
                }
            }
            else
            {
                return View();
            }
        }
    }
}