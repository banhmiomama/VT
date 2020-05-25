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

namespace VTCinema.Controllers.Actor
{
    [Route("ActorDetail")]
    public class ActorDetailController : Controller
    {
        [Route("{ActorID}")]
        [HttpGet]
        public IActionResult Index(int ActorID)
        {
            ViewBag.ActorID = ActorID;
            return View("~/Views/Actor/ActorDetail.cshtml");
        }
        [Route("GetActorDetail/{ActorID}")]
        [HttpGet]
        public string GetActorDetail(int ActorID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Action_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, ActorID);
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
        public string Execute(string data, int ActorID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataActorChoose dataDetail = JsonConvert.DeserializeObject<DataActorChoose>(data);
                
                if (ActorID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Actor_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Description", SqlDbType.NVarChar, dataDetail.Description,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Nationality", SqlDbType.VarChar, dataDetail.Nationality,
                            "@CurrentID",SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Actor_Update]", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Description", SqlDbType.NVarChar, dataDetail.Description,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Nationality", SqlDbType.VarChar, dataDetail.Nationality,
                            "@CurrentID", SqlDbType.Int, ActorID ,
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