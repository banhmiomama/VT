using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Clients.Catalog
{
    [Route("Catalog")]
    public class CatalogController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Year = 2000;
            return View("~/Views/Clients/Catalog/CatalogView.cshtml");
        }
        
        [Route("LoadDataMovie")]
        [HttpGet]
        public string LoadDataMovie()
        {
            try
            {
                string Page = HttpContext.Request.Query["Page"].ToString();
                DataSet dt = new DataSet();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataSet("[YYY_sp_Client_Movie_LoadList_Catalog]",CommandType.StoredProcedure,
                        "@PageNumber", SqlDbType.Int, Page);
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