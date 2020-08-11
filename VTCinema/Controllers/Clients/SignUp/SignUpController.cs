using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Admin.Clients.SignUp
{
    [Route("SignUp")]
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Clients/SignUp/SignUpView.cshtml");
        }

        [Route("ExecuteCustomer")]
        [HttpPost]
        public string ExecuteCustomer(string data)
        {
            try
            {
                DataTable dt = new DataTable();
                DataCustomerChoose dataDetail = JsonConvert.DeserializeObject<DataCustomerChoose>(data);
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_LoadList]", CommandType.StoredProcedure
                        , "@UserName", SqlDbType.NVarChar, dataDetail.Username
                        , "@Email", SqlDbType.NVarChar , dataDetail.Email);
                    if (dt.Rows.Count ==0)
                    {
                        dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_Insert]", CommandType.StoredProcedure
                              , "@UserName", SqlDbType.NVarChar, dataDetail.Username
                              , "@Name", SqlDbType.NVarChar, dataDetail.Name
                              , "@LastName", SqlDbType.NVarChar, dataDetail.LastName
                              , "@Email", SqlDbType.NVarChar, dataDetail.Email
                              , "@Password", SqlDbType.NVarChar, dataDetail.Password
                              );
                        return "Đăng kí thành công";
                    }
                    else
                    {
                        return "Tên Tài Khoản , Email đã được sử dụng";
                    }
                }
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}
