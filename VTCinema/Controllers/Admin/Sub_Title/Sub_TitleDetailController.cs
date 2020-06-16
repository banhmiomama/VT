using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Sub_Title
{
    [Route("Admin/Sub_TitleDetail")]
    public class Sub_TitleDetailController : Controller
    {
        [Route("{Sub_TitleID}")]
        [HttpGet]
        public IActionResult Index(int Sub_TitleID)
        {
            ViewBag.Sub_TitleID = Sub_TitleID;
            return View("~/Views/Admin/Sub_Title/Sub_TitleDetail.cshtml");
        }
        [Route("GetSub_TitleDetail/{Sub_TitleID}")]
        [HttpGet]
        public string GetSub_TitleDetail(int Sub_TitleID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Sub_Title_Detail]", CommandType.StoredProcedure,
                        "@CurrentID",SqlDbType.Int,Sub_TitleID);

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

       [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int Sub_TitleID)
        {
            
            try
            {
                DataTable dt = new DataTable();
                DataSub_TitleChoose dataDetail = JsonConvert.DeserializeObject<DataSub_TitleChoose>(data);

                if (Sub_TitleID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Sub_Title_Insert", CommandType.StoredProcedure,
                            "@Sub_Title", SqlDbType.NVarChar, dataDetail.Sub_Title,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Sub_Title_Update", CommandType.StoredProcedure,
                           "@CurrentID", SqlDbType.Int, Sub_TitleID,
                           "@Sub_Title", SqlDbType.NVarChar, dataDetail.Sub_Title,
                          "@Note", SqlDbType.NVarChar, dataDetail.Note,
                           "@Modified_By", SqlDbType.Int , HttpContext.Session.GetInt32(Comon.Global.UserID)
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
