﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace VTCinema.Controllers.Error
{
    [Route("Error")]
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View("~/Views/Error/Error.cshtml");
        }

    }
}