using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Clients.Information
{
    [Route("Information")]
    public class ClientInformationController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Clients/Information/InformationView.cshtml");
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
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Infomation_LoadList]", CommandType.StoredProcedure);

                }
                return dt != null ? JsonConvert.SerializeObject(dt) : "[]";
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}
