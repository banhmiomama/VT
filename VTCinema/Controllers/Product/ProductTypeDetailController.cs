using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Product
{
    [Route("ProductTypeDetail")]
    public class ProductTypeDetailController : Controller
    {
        [Route("{ProductTypeID}")]
        [HttpGet]
        public IActionResult Index(int ProductTypeID)
        {
            ViewBag.ProductTypeID = ProductTypeID;
            return View("~/Views/Product/ProductTypeDetail.cshtml");
        }
        [Route("GetProductTypeDetail/{ProductTypeID}")]
        [HttpGet]
        public string GetProductTypeDetail(int ProductTypeID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ProductType_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, ProductTypeID);
                }
                if (dt != null)
                {
                    return JsonConvert.SerializeObject(dt);
                }
                else
                {
                    return "";
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
        public string Execute(string data, int ProductTypeID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataProductTypeChoose dataDetail = JsonConvert.DeserializeObject<DataProductTypeChoose>(data);

                if (ProductTypeID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_ProductType_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.NameType,
                            "@Image", SqlDbType.VarChar, dataDetail.Image,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_ProductType_Update]", CommandType.StoredProcedure,
                            "@NameType", SqlDbType.NVarChar, dataDetail.NameType,
                            "@Image", SqlDbType.VarChar, dataDetail.Image,
                            "@CurrentID", SqlDbType.Int, ProductTypeID,
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