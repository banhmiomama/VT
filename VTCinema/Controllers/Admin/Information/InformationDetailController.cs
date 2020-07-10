using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Admin.Information
{
    [Route("Admin/InformationDetail")]
    public class InformationDetailController : Controller
    {
        [Route("{InformationID}")]
        [HttpGet]
        public IActionResult Index(int InformationID)
        {
            ViewBag.InformationID = InformationID;
            return View("~/Views/Admin/Information/InformationDetail.cshtml");
        }
        [Route("GetInformationDetail/{InformationID}")]
        [HttpGet]
        public string GetInformationDetail(int InformationID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Information_Detail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, InformationID);
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

        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int InformationID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataInfomationChoose dataDetail = JsonConvert.DeserializeObject<DataInfomationChoose>(data);

                if (InformationID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Information_Insert", CommandType.StoredProcedure,
                            "@Title", SqlDbType.NVarChar, dataDetail.Title,
                            "@Image", SqlDbType.NVarChar, dataDetail.Image,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Information_Update]", CommandType.StoredProcedure,
                            "@Title", SqlDbType.NVarChar, dataDetail.Title,
                            "@Note", SqlDbType.Int, dataDetail.Note,
                            "@Image", SqlDbType.NVarChar, dataDetail.Image,
                            "@CurrentID", SqlDbType.Int, InformationID,
                            "@Modified_By", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                       );
                    }
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
