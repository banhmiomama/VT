using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Comon;

namespace VTCinema.Controllers.Dashboard
{
    [Route("Admin/SaleMain")]
    public class SaleMainController : BaseController
    {
        public IActionResult Index()
        {
            ViewBag.AvatarUser = GlobalUser.sys_userAvatar;
            return View("~/Views/Admin/Dashboard/SaleMain.cshtml");
        }
        [Route("RevenuePayment")]
        [HttpPost]
        public string RevenuePayment(string dateFrom, string dateTo)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Report_Revenue]", CommandType.StoredProcedure,
                        "@datefrom", SqlDbType.DateTime, Convert.ToDateTime(dateFrom)
                        , "@dateto", SqlDbType.DateTime, Convert.ToDateTime(dateTo));

                }
                if (dt != null)
                {
                    return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    return "[]";
                }
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}