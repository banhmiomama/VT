using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Admin.ChangePass
{
    [Route("Admin/ChangePass")]
    public class ChangePassController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/ChangePass/ChangePass.cshtml");
        }
        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string Password)
        {
            try
            {
                DataTable dt = new DataTable();
               

                using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                {
                    dt = connFunc.ExecuteDataTable("[YYY_sp_ChangePass_User]", CommandType.StoredProcedure,
                        "@Password",SqlDbType.VarChar, Password,
                        "@UserID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                   );
                }

                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}
