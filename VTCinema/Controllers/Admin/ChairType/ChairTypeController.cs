using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.ChairType
{
    [Route("Admin/ChairType")]
    public class ChairTypeController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/ChairType/ChairTypeView.cshtml");
        }
        [Route("LoadChairType")]
        [HttpPost]
        public string LoadChairType()
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ChairType_LoadList]", CommandType.StoredProcedure);

                }
                if (dt != null)
                {
                    return JsonConvert.SerializeObject(dt);
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

        [Route("DeleteChairType/{ID}")]
        [HttpGet]
        public string DeleteChairType(int ID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ChairType_Delete]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, ID,
                      "@Modified_By", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID));
                }
                return "1";
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}