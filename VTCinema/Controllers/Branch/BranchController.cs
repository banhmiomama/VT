using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Branch
{
    [Route("Branch")]
    public class BranchController : Controller
    {
        public IActionResult Index()
        {
            return View("~/Views/Branch/BranchView.cshtml");
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
    }
}