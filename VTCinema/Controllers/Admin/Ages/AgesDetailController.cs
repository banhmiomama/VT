using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Comon;
using VTCinema.Models;

namespace VTCinema.Controllers.Ages
{
    [Route("Admin/AgesDetail")]
    public class AgesDetailController : Controller
    {
        [Route("{AgesID}")]
        [HttpGet]
        public IActionResult Index(int AgesID)
        {
            ViewBag.AgesID = AgesID;
            return View("~/Views/Admin/Ages/AgesDetail.cshtml");
        }
        [Route("GetAgesDetail/{AgesID}")]
        [HttpGet]
        public string GetAgesDetail(int AgesID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Ages_Type_Detail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, AgesID);
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
        public string Execute(string data, int AgesID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataAgesChoose dataDetail = JsonConvert.DeserializeObject<DataAgesChoose>(data);
                
                if (AgesID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Ages_Type_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Ages", SqlDbType.Int, dataDetail.Ages,
                            "@CurrentID",SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Ages_Type_Update]", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Ages", SqlDbType.Int, dataDetail.Ages,
                            "@CurrentID", SqlDbType.Int, AgesID ,
                            "@Modified_By", SqlDbType.Int,HttpContext.Session.GetInt32(Comon.Global.UserID)
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