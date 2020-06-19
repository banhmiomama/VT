using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Admin.Clients.Main
{
    [Route("Main")]
    public class MainController : Controller
    {
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
    }
}
