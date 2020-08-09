using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Admin.Clients.Main
{
    [Route("Main")]   
    public class MainController : Controller
    {
        [Route("/")]
        [Route("")]
        public IActionResult Index()
        {
            return View("~/Views/Clients/Main/MainView.cshtml");
        }
        [Route("LoadDataMain")]
        [HttpPost]
        public string LoadDataMain()
        {
            try
            {
                DataSet ds = new DataSet();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataSet("[YYY_sp_Client_Movie_LoadList_Main]", CommandType.StoredProcedure);

                }
                if (ds != null)
                {
                    return JsonConvert.SerializeObject(ds);
                }
                else
                {
                    return "[]";
                }
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }

        [Route("LoadDataInformation")]
        [HttpPost]
        public string LoadDataInformation()
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Infomation_LoadList]", CommandType.StoredProcedure);

                }
                return dt != null ? JsonConvert.SerializeObject(dt) : "[]";
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }

        [Route("LoadDataCustomer")]
        [HttpPost]
        public string LoadDataCustomer()
        {
            try
            {
                DataTable dt = new DataTable();
                int CustomerID = 0;
                if(HttpContext.Session.GetInt32(Comon.GlobalClient.CustomerID) == null)
                {
                    CustomerID = 0;
                }
                else
                {
                    CustomerID = (int)HttpContext.Session.GetInt32(Comon.GlobalClient.CustomerID);
                }
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_LoadDetail]", CommandType.StoredProcedure
                        , "@CusID", SqlDbType.Int, CustomerID);
                }
                return dt != null ? JsonConvert.SerializeObject(dt) : "[]";
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}
