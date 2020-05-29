using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

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
        [Route("GetBranchDetail/{BranchID}")]
        [HttpGet]
        public string GetBranchDetail(int BranchID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Branch_Detail]", CommandType.StoredProcedure,
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

        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int BranchID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataBranchChoose dataDetail = JsonConvert.DeserializeObject<DataBranchChoose>(data);

                if (BranchID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Branch_Insert", CommandType.StoredProcedure,
                            "@BranchCode", SqlDbType.NVarChar, dataDetail.BranchCode,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@ShortName", SqlDbType.NVarChar ,dataDetail.ShortName,
                            "@Address", SqlDbType.NVarChar ,dataDetail.Address,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@Latitude",SqlDbType.Float ,dataDetail.Latitude,
                            "@Longtitude", SqlDbType.Float, dataDetail.Longtitude,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Branch_Update", CommandType.StoredProcedure,
                           "@CurrentID", SqlDbType.Int, BranchID,
                           "@BranchCode", SqlDbType.NVarChar, dataDetail.BranchCode,
                           "@Name", SqlDbType.NVarChar, dataDetail.Name,
                           "@ShortName", SqlDbType.NVarChar, dataDetail.ShortName,
                           "@Address", SqlDbType.NVarChar, dataDetail.Address,
                           "@Latitude", SqlDbType.Float, dataDetail.Latitude,
                           "@Longtitude", SqlDbType.Float, dataDetail.Longtitude,
                           "@Modified_By", SqlDbType.Int , HttpContext.Session.GetInt32(Comon.Global.UserID)
                      );
                    }
                }
                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }


    }

}
