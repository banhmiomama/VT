using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using VTCinema.Comon;

namespace VTCinema.Controllers
{
    public  class BaseController : Controller
    {
        protected virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {
            int sessionUser = Convert.ToInt32(HttpContext.Session.GetInt32("UserID"));
            if (sessionUser == null)
            {
                filterContext.Result = RedirectToAction("Index", "Login");
            }
            base.OnActionExecuting(filterContext);
        }

    }
}