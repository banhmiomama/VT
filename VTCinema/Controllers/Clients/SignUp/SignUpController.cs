using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        
        [Route("LoadDataCustomer")]
        [HttpPost]
        public string LoadDataCustomer()
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_LoadList]", CommandType.StoredProcedure);

                }
                return dt != null ? JsonConvert.SerializeObject(dt) : "[]";
            }
            catch (Exception ex)
            {
                return "[]";
            }
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

                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_Insert]", CommandType.StoredProcedure
                          , "@UserName", SqlDbType.NVarChar, dataDetail.Username
                          , "@Email", SqlDbType.NVarChar, dataDetail.Email
                          , "@Password", SqlDbType.NVarChar, dataDetail.Password
                          );
                }
                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}