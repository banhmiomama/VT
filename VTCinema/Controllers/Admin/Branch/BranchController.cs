using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Branch
{
    [Route("Admin/Branch")]
    public class BranchController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Branch/BranchView.cshtml");
        }

        [Route("LoadBranch")]
        [HttpPost]
        public string LoadBranch()
        {
            try
            {
                DataTable dt = new DataTable();
               
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Branch_LoadList]", CommandType.StoredProcedure);

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

        [Route("DeleteBranch/{ID}")]
        [HttpGet]
        public string DeleteBranch(int ID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Branch_Delete]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, ID,
                      "@Modified_By", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID));
                }
                return "1";
            }
            catch (Exception ex)
            {
                return "0";
            }
            LoadBranch();
        }
    }
}