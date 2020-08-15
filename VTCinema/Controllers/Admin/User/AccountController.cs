using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Admin.User
{
    [Route("Admin/AccountDetail")]
    public class AccountController : Controller
    {
        [Route("{AccountID}")]
        [HttpGet]
        public IActionResult Index(int AccountID)
        {
            ViewBag.AccountID = AccountID;
            return View("~/Views/Admin/User/AccountDetail.cshtml");
        }

        [Route("LoadAccount/{AccountID}")]
        [HttpGet]
        public string LoadAccount(int AccountID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Account_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, AccountID);
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
        [HttpPost]
        public string Execute(string data, int AccountID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataUserChoose dataDetail = JsonConvert.DeserializeObject<DataUserChoose>(data);

                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Account_Update]", CommandType.StoredProcedure,
                            "@UserName", SqlDbType.NVarChar, dataDetail.UserName,
                            "@Password", SqlDbType.Int, dataDetail.Password,
                            "@CurrentID", SqlDbType.Int, AccountID,
                            "@Modified_By", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                       );
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
