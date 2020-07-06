using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Clients.Checkout
{
    [Route("Checkout")]
    public class CheckoutController : Controller
    {
        [Route("{ScheduleID}")]
        [HttpGet]
        public IActionResult Index(int ScheduleID)
        {
            ViewBag.ScheduleDetailID = ScheduleID;
            if(ScheduleID == 0)
            {
                return Redirect("/");
            }
            return View("~/Views/Clients/Checkout/CheckoutView.cshtml");
        }
        [Route("ScheduleMovie/{ScheduleID}")]
        [HttpGet]
        public string ScheduleMovie(int ScheduleID)
        {
            DataTable Combo = LoadComboNational();
            DataSet Detail = LoadDetail(ScheduleID);
            DataSet ds = new DataSet();
            Detail.Tables.AddRange(new DataTable[] { Combo });
            return JsonConvert.SerializeObject(Detail);
        }
        DataTable LoadComboNational()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_National_LoadCombo]", CommandType.StoredProcedure);
                }
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        DataSet LoadDetail(int ScheduleID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataSet("[YYY_sp_Client_Schedule_LoadMovie]", CommandType.StoredProcedure,
                      "@ScheduleID", SqlDbType.Int, ScheduleID);
                }
                if (ds != null)
                {
                    return ds;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
