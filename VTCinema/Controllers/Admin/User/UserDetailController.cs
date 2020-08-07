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
            DataTable Detail = LoadDetail(UserID);
            DataTable ComboEmployee = LoadComboEmployee();
            DataTable ComboBranch = LoadComboBranch();
            DataTable ComboUserGroup = LoadComboUserGroup();
            Detail.TableName = "LoadDetail";
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { Detail,ComboEmployee,ComboBranch,ComboUserGroup});
            return JsonConvert.SerializeObject(ds);
        }
        DataTable LoadDetail(int UserID)
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
        DataTable LoadComboEmployee()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Employee_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboBranch()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Branch_LoadCombo]", CommandType.StoredProcedure);
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


        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int UserID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataUserChoose dataDetail = JsonConvert.DeserializeObject<DataUserChoose>(data);

                if (UserID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_User_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@EmployeeID", SqlDbType.Int, dataDetail.EmployeeID,
                            "@BranchID", SqlDbType.Int, dataDetail.BranchID,
                            "@GroupID", SqlDbType.Int, dataDetail.GroupID,
                            "@Username", SqlDbType.NVarChar, dataDetail.UserName,
                            //"@Password", SqlDbType.NVarChar, dataDetail.Password,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@AreaBranch", SqlDbType.NVarChar, dataDetail.AreaBranch,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_User_Update", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@EmployeeID", SqlDbType.Int, dataDetail.EmployeeID,
                            "@BranchID", SqlDbType.Int, dataDetail.BranchID,
                            "@GroupID", SqlDbType.Int, dataDetail.GroupID,
                            "@Username", SqlDbType.NVarChar, dataDetail.UserName,
                            //"@Password", SqlDbType.NVarChar, dataDetail.Password,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@AreaBranch", SqlDbType.NVarChar, dataDetail.AreaBranch,
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
