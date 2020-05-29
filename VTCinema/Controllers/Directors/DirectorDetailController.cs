using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Directors
{
    [Route("DirectorDetail")]
    public class DirectorDetailController : Controller
    {
        [Route("{DirectorID}")]
        [HttpGet]
        public IActionResult Index(int DirectorID)
        {
            ViewBag.DirectorID = DirectorID;
            return View("~/Views/Directors/DirectorDetail.cshtml");
        }
        [Route("GetDirectorDetail/{DirectorID}")]
        [HttpGet]
        public string GetDirectorDetail(int DirectorID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Directors_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, DirectorID);
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
        public string Execute(string data, int DirectorID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataDirectorChoose dataDetail = JsonConvert.DeserializeObject<DataDirectorChoose>(data);

                if (DirectorID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Directors_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Avatar", SqlDbType.VarChar, dataDetail.Avatar,
                            "@Description", SqlDbType.NVarChar, dataDetail.Description,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Nationality", SqlDbType.VarChar, dataDetail.Nationality,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Directors_Update]", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Avatar", SqlDbType.VarChar, dataDetail.Avatar,
                            "@Description", SqlDbType.NVarChar, dataDetail.Description,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Nationality", SqlDbType.VarChar, dataDetail.Nationality,
                            "@CurrentID", SqlDbType.Int, DirectorID,
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