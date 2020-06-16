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
    [Route("ProductDetail")]
    public class ProductDetailController : Controller
    {
        [Route("{ProductID}")]
        [HttpGet]
        public IActionResult Index(int ProductID)
        {
            ViewBag.ProductID = ProductID;
            return View("~/Views/Product/ProductDetail.cshtml");
        }

        DataTable LoadComboProductType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ProductType_LoadCombo]", CommandType.StoredProcedure);
                }
                if (dt != null)
                {
                    return dt;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        DataTable LoadDetail(int ProductID)
        {
            try
            {
                if (ProductID == 0) 
                    return null;
                else
                {
                    DataTable dt = new DataTable();
                    using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                    {
                        dt = confunc.ExecuteDataTable("[YYY_sp_Product_LoadDetail]", CommandType.StoredProcedure,
                         "@CurrentID", SqlDbType.Int, ProductID);
                    }
                    if (dt != null)
                    {
                        return dt;
                    }
                    else
                    {
                        return null;
                    }
                }
                    
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [Route("GetProductDetail/{ProductID}")]
        [HttpGet]
        public string GetProductDetail(int ProductID)
        {
            DataTable Combo = LoadComboProductType();
            DataTable Detail = LoadDetail(ProductID);
            DataSet ds = new DataSet();
            ds.Tables.AddRange( new DataTable[] { Combo, Detail });
            return JsonConvert.SerializeObject(ds);
        }

        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int ProductID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataProductChoose dataDetail = JsonConvert.DeserializeObject<DataProductChoose>(data);

                if (ProductID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Product_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.NameProduct,
                            "@Image", SqlDbType.VarChar, dataDetail.Image,
                            "@Type", SqlDbType.Int, dataDetail.TypeID,
                            "@Price", SqlDbType.Int, dataDetail.Price,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Product_Update]", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.NameProduct,
                            "@Image", SqlDbType.VarChar, dataDetail.Image,
                            "@Type", SqlDbType.Int, dataDetail.TypeID,
                            "@Price", SqlDbType.Int, dataDetail.Price,
                            "@CurrentID", SqlDbType.Int, ProductID,
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