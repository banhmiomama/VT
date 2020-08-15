using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Clients.MovieDetail
{
    [Route("InformationDetail")]
    public class InformationDetailController : Controller
    {
        [Route("{InformationDetailID}")]
        [HttpGet]
        public IActionResult Index( int InformationDetailID)
        {
            ViewBag.InformationDetailID = InformationDetailID;
            return View("~/Views/Clients/Information/InformationDetail.cshtml");
        }
        [Route("GetInformationDetail/{InformationDetailID}")]
        [HttpGet]
        public string GetInformationDetail(int InformationDetailID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Infomation_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, InformationDetailID);
                }
                if (dt != null)
                {
                    return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }

        [Route("LoadDataInformation")]
        [HttpPost]
        public string LoadDataInformation()
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Infomation_LoadList]", CommandType.StoredProcedure);

                }
                return dt != null ? JsonConvert.SerializeObject(dt) : "[]";
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}
