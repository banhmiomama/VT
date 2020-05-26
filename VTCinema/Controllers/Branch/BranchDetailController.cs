using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Branch
{
    [Route("BranchDetail")]
    public class BranchDetailController : Controller
    {
        [Route("{BranchID}")]
        [HttpGet]
        public IActionResult Index(int BranchID)
        {
            ViewBag.BranchID = BranchID;
            return View("~/Views/Branch/BranchDetail.cshtml");
        }
        [Route("LoadBranchDetail/{BranchID}")]
        [HttpPost]
        public string LoadBranchDetail(int BranchID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Branch_LoadDetail]", CommandType.StoredProcedure,
                        "@CurrentID",SqlDbType.Int,BranchID);

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