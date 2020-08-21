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
    public class UserDetailController : BaseController
    {
        [Route("{UserID}")]
        [HttpGet]
        public IActionResult Index(int UserID)
        {
            ViewBag.UserID = UserID;
            return View("~/Views/Admin/User/UserDetail.cshtml");
        }


        DataTable LoadDetail(int UserID)
        {
            try
            {
                if (UserID == 0)
                    return null;
                else
                {
                    DataTable dt = new DataTable();
                    using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                    {
                        dt = confunc.ExecuteDataTable("[YYY_sp_Employee_LoadDetail]", CommandType.StoredProcedure,
                         "@CurrentID", SqlDbType.Int, UserID);
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

            }
            catch (Exception ex)
            {
                return null;
            }
        }
        DataTable LoadComboUserGroup()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_UserGroup_LoadCombo]", CommandType.StoredProcedure);
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

        [Route("GetUserDetail/{UserID}")]
        [HttpGet]
        public string GetUserDetail(int UserID)
        {
            DataTable Combo = LoadComboUserGroup();
            DataTable Detail = LoadDetail(UserID);
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { Combo, Detail });
            return JsonConvert.SerializeObject(ds);
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
                        dt = connFunc.ExecuteDataTable("YYY_sp_Employee_Insert", CommandType.StoredProcedure,
                            "@Avatar", SqlDbType.NVarChar, dataDetail.Avatar,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@LastName", SqlDbType.NVarChar, dataDetail.LastName,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Phone", SqlDbType.NVarChar, dataDetail.Phone,
                            "@Email", SqlDbType.NVarChar, dataDetail.Email,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Weight", SqlDbType.Float, dataDetail.Weight,
                            "@GroupID", SqlDbType.Int, dataDetail.GroupID,
                            "@Address", SqlDbType.Int, dataDetail.Address,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Employee_Update", CommandType.StoredProcedure,
                            "@Avatar", SqlDbType.NVarChar, dataDetail.Avatar,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@LastName", SqlDbType.NVarChar, dataDetail.LastName,
                            "@Brithday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Phone", SqlDbType.NVarChar, dataDetail.Phone,
                            "@Email", SqlDbType.NVarChar, dataDetail.Email,
                            "@Height", SqlDbType.Float, dataDetail.Height,
                            "@Weight", SqlDbType.Float, dataDetail.Weight,
                            "@Address", SqlDbType.Int, dataDetail.Address,
                            "@GroupID", SqlDbType.Int, dataDetail.GroupID,
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
