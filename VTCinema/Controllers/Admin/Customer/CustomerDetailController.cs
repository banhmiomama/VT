using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Customer
{
    [Route("Admin/CustomerDetail")]
    public class CustomerDetailController : Controller
    {
        [Route("{CustomerID}")]
        [HttpGet]
        public IActionResult Index(int CustomerID)
        {
            ViewBag.CustomerID = CustomerID;
            return View("~/Views/Admin/Customer/CustomerDetail.cshtml");
        }
        [Route("GetCustomerDetail/{CustomerID}")]
        [HttpGet]
        public string GetCustomerDetail(int CustomerID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Customer_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, CustomerID);
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
        public string Execute(string data, int CustomerID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataCustomerChoose dataDetail = JsonConvert.DeserializeObject<DataCustomerChoose>(data);

                if (CustomerID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Customer_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@LastName", SqlDbType.NVarChar, dataDetail.LastName,
                            "@Avatar", SqlDbType.VarChar, dataDetail.Avatar,
                            "@Password", SqlDbType.VarChar, dataDetail.Password,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Phone", SqlDbType.VarChar, dataDetail.Phone,
                            "@Email", SqlDbType.VarChar, dataDetail.Email,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Customer_Update]", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@LastName", SqlDbType.NVarChar, dataDetail.LastName,
                            "@Avatar", SqlDbType.VarChar, dataDetail.Avatar,
                            "@Birthday", SqlDbType.DateTime, dataDetail.Birthday,
                            "@Phone", SqlDbType.VarChar, dataDetail.Phone,
                            "@Email", SqlDbType.VarChar, dataDetail.Email,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, CustomerID,
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