using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.ChairTypeDetail
{
    [Route("Admin/ChairTypeDetail")]
    public class ChairTypeDetailDetailController : Controller
    {
        [Route("{ChairTypeID}")]
        [HttpGet]
        public IActionResult Index(int ChairTypeID)
        {
            ViewBag.ChairTypeID = ChairTypeID;
            return View("~/Views/Admin/ChairType/ChairTypeDetail.cshtml");
        }
        [Route("GetChairTypeDetail/{ChairTypeID}")]
        [HttpGet]
        public string GetChairTypeDetail(int ChairTypeID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ChairType_LoadDetail]", CommandType.StoredProcedure,
                        "@CurrentID", SqlDbType.Int, ChairTypeID);

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
        public string Execute(string data, int ChairTypeID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataChairTypeChoose dataDetail = JsonConvert.DeserializeObject<DataChairTypeChoose>(data);

                if (ChairTypeID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_ChairType_Insert", CommandType.StoredProcedure,
                           "@NameChair", SqlDbType.NVarChar, dataDetail.NameChair,
                            "@Price", SqlDbType.Int, dataDetail.Price,
                            "@Total", SqlDbType.Int, dataDetail.Total,
                            "@ColorCode", SqlDbType.NVarChar, dataDetail.ColorCode,
                            "@Visibility", SqlDbType.NVarChar, dataDetail.VisibilityChair,
                            "@Disabled", SqlDbType.NVarChar, dataDetail.DisabledChair,                           
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_ChairType_Update", CommandType.StoredProcedure,
                           "@CurrentID", SqlDbType.Int, ChairTypeID,
                           "@NameChair", SqlDbType.NVarChar, dataDetail.NameChair,
                            "@Price", SqlDbType.Int, dataDetail.Price,
                            "@Total", SqlDbType.Int, dataDetail.Total,
                            "@ColorCode", SqlDbType.NVarChar, dataDetail.ColorCode,
                             "@Visibility", SqlDbType.NVarChar, dataDetail.VisibilityChair,
                            "@Disabled", SqlDbType.NVarChar, dataDetail.DisabledChair,
                           "@Modified_By", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
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