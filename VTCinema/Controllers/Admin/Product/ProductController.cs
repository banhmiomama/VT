﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Product
{
    [Route("Admin/Product")]
    public class ProductController : BaseController
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Product/ProductView.cshtml");
        }

        [Route("LoadProduct")]
        [HttpPost]
        public string LoadProduct()
        {
            try
            {
                DataSet dt = new DataSet();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataSet("[YYY_sp_Product_LoadList]", CommandType.StoredProcedure);

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
        [Route("DeleteProduct/{ID}")]
        [HttpGet]
        public string DeleteProduct(int ID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Product_Delete]", CommandType.StoredProcedure,
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
        [Route("DeleteProductType/{ID}")]
        [HttpGet]
        public string DeleteProductType(int ID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ProductType_Delete]", CommandType.StoredProcedure,
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