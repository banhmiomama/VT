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
    [Route("Admin/UserGroupDetail")]
    public class UserGroupDetailController : Controller
    {
        [Route("{UserGroupID}")]
        [HttpGet]
        public IActionResult Index(int UserGroupID)
        {
            ViewBag.UserGroupID = UserGroupID;
            return View("~/Views/Admin/User/UserGroupDetail.cshtml");
        }
        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int UserGroupID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataUserGroupChoose dataDetail = JsonConvert.DeserializeObject<DataUserGroupChoose>(data);

                if (UserGroupID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_UserGroup_Insert]", CommandType.StoredProcedure,
                            "@GroupName", SqlDbType.NVarChar, dataDetail.GroupName,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_UserGroup_Update]", CommandType.StoredProcedure,
                            "@GroupName", SqlDbType.NVarChar, dataDetail.GroupName,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
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
