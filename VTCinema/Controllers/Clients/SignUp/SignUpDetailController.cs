﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Clients.SignUp
{
    [Route("SignUpDetail")]
    public class SignUpDetailController : Controller
    {
        [Route("{CustomerID}")]
        [HttpGet]
        public IActionResult Index(int CustomerID)
        {

            ViewBag.CustomerID = CustomerID;
            return View("~/Views/Clients/SignUp/SignUpDetail.cshtml");
        }
        [Route("GetCusDetail/{CustomerID}")]
        [HttpGet]
        public string GetCusDetail(int CustomerID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_LoadDetail]", CommandType.StoredProcedure,
                      "@CusID", SqlDbType.NVarChar, CustomerID);
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

        [Route("ExecuteCustomer")]
        [HttpPost]
        public string ExecuteCustomer(string data, int CustomerID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataCustomerChoose dataDetail = JsonConvert.DeserializeObject<DataCustomerChoose>(data);
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_Update]", CommandType.StoredProcedure
                          , "@Name", SqlDbType.NVarChar, dataDetail.Name
                          , "@LastName", SqlDbType.NVarChar, dataDetail.LastName
                          , "@Birthday", SqlDbType.NVarChar, dataDetail.Birthday
                          , "@Phone", SqlDbType.NVarChar, dataDetail.Phone
                          , "@Avatar", SqlDbType.VarChar, dataDetail.Avatar
                          , "@CurrentID", SqlDbType.Int, CustomerID
                          );
                    return "Chỉnh Sửa Tài Khoản thành công";
                }
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
        [Route("ExecutePassword")]
        [HttpPost]
        public string ExecutePassword(string data, int CustomerID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataCustomerChoose dataDetail = JsonConvert.DeserializeObject<DataCustomerChoose>(data);
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Customer_ChangePassword]", CommandType.StoredProcedure
                          , "@Password", SqlDbType.NVarChar, dataDetail.Password
                          , "@CurrentID", SqlDbType.Int, CustomerID
                          );
                    return "Đổi mật khẩu thành công";
                }
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
    }
}
