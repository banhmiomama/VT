using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Admin.User
{
    [Route("Admin/UserDetail")]
    public class UserDetailController : Controller
    {
        [Route("{UserID}")]
        [HttpGet]
        public IActionResult Index(int UserID)
        {
            ViewBag.UserID = UserID;
            return View("~/Views/Admin/User/UserDetail.cshtml");
        }

        [Route("GetUserDetail/{UserID}")]
        [HttpGet]
        public string GetUserDetail(int UserID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_User_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, UserID);
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
        public string Execute(string data, int UserID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataEmployeeChoose dataDetail = JsonConvert.DeserializeObject<DataEmployeeChoose>(data);

                if (UserID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_User_Insert", CommandType.StoredProcedure,
                            "@Avatar", SqlDbType.NVarChar, dataDetail.Avatar,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@LastName", SqlDbType.NVarChar, dataDetail.LastName,
                            "@Brithday", SqlDbType.DateTime, dataDetail.Brithday,
                            "@Phone", SqlDbType.NVarChar, dataDetail.Phone,
                            "@Email", SqlDbType.NVarChar, dataDetail.Email,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Weight", SqlDbType.Float, dataDetail.Weight,
                            "@Address", SqlDbType.Int, dataDetail.Address,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_User_Update", CommandType.StoredProcedure,
                            "@Avatar", SqlDbType.NVarChar, dataDetail.Avatar,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@LastName", SqlDbType.NVarChar, dataDetail.LastName,
                            "@Brithday", SqlDbType.DateTime, dataDetail.Brithday,
                            "@Phone", SqlDbType.NVarChar, dataDetail.Phone,
                            "@Email", SqlDbType.NVarChar, dataDetail.Email,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Weight", SqlDbType.Float, dataDetail.Weight,
                            "@Address", SqlDbType.Int, dataDetail.Address,
                            "@CurrentID", SqlDbType.Int, UserID,
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
