using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Newtonsoft.Json;
using VTCinema.Comon;


namespace VTCinema.Controllers.Clients.Checkout
{
    [Route("Checkout")]
    public class CheckoutController : Controller
    {
        [Route("{ScheduleID}")]
        [HttpGet]
        public IActionResult Index(int ScheduleID)
        {
            if(HttpContext.Session.GetInt32(GlobalClient.CustomerID) == null)
            {
                return Redirect("/SignIn");
            }
            ViewBag.ScheduleDetailID = ScheduleID;
            if(ScheduleID == 0 )
            {
                return Redirect("/");
            }
            ViewBag.Email = GlobalUser.sys_Email;
            return View("~/Views/Clients/Checkout/CheckoutView.cshtml");
        }
        [Route("ScheduleMovie/{ScheduleID}")]
        [HttpGet]
        public string ScheduleMovie(int ScheduleID)
        {
            DataSet Combo = LoadDataProduct();
            DataTable ProductType = Combo.Tables["Table"].Copy();
            ProductType.TableName = "ProductType";
            DataTable Product = Combo.Tables["Table1"].Copy();
            Product.TableName = "Product";
            DataTable dtChairType = LoadDataChairType();
            DataTable checkAges = CheckAge(ScheduleID);
            checkAges.TableName = "CheckAge";
            DataSet Detail = LoadDetail(ScheduleID);
            Detail.Tables.AddRange(new DataTable[] { ProductType, Product, dtChairType, checkAges });
            return JsonConvert.SerializeObject(Detail);
        }
        DataSet LoadDataProduct()
        {
            try
            {
                DataSet ds = new DataSet();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataSet("[YYY_sp_Client_Product_LoadList]", CommandType.StoredProcedure);
                }
                if (ds != null)
                {
                    return ds;
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
        DataTable LoadDataChairType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_ChairType_LoadList]", CommandType.StoredProcedure);
                }
                if (dt != null)
                {
                    dt.TableName = "ChairType";
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
        DataSet LoadDetail(int ScheduleID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataSet("[YYY_sp_Client_Schedule_LoadMovie]", CommandType.StoredProcedure,
                      "@ScheduleID", SqlDbType.Int, ScheduleID);
                }
                if (ds != null)
                {
                    return ds;
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
        DataTable CheckAge(int ScheduleID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_CheckAges]", CommandType.StoredProcedure,
                      "@ScheduleID", SqlDbType.Int, ScheduleID
                      , "@CurentID",SqlDbType.Int,HttpContext.Session.GetInt32(Comon.GlobalClient.CustomerID));
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

        [Route("ExecuteBill")]
        [HttpPost]
        public string ExecuteBill(string data,string Email)
        {
            try
            {
                DataTable dt = new DataTable();

                DataBill dataDetail = JsonConvert.DeserializeObject<DataBill>(data);
                int CustomerID = (int)HttpContext.Session.GetInt32(Comon.GlobalClient.CustomerID);
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Bill_Insert]", CommandType.StoredProcedure
                        , "@CustomerID", SqlDbType.Int, CustomerID
                        , "@ScheduleID", SqlDbType.Int, dataDetail.ScheduleID
                        , "@Quan", SqlDbType.Int, dataDetail.Quan
                        , "@Price", SqlDbType.Float, dataDetail.Price);
                }

                //MimeMessage message = new MimeMessage();
                //message.Subject = "VTCinema";

                //BodyBuilder bodyBuilder = new BodyBuilder();
                //bodyBuilder.HtmlBody = "<h1>Hello World!</h1>";
                //bodyBuilder.TextBody = "hello every !";
                //message.Body = bodyBuilder.ToMessageBody();

                //message.From.Add(new MailboxAddress("VTCinema"));
                //message.To.Add(new MailboxAddress(Email));
                //using (var client = new SmtpClient())
                //{
                //    client.Connect("smtp.gmail.com"
                //    , 587
                //    , MailKit.Security.SecureSocketOptions.StartTls);
                //    client.Authenticate("riva.friend.2605@gmail.com", "CuBaKhoTinh1804");
                //    client.Send(message);
                //    client.Disconnect(true);
                //}

                return dt.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        [Route("ExecuteBillTicket")]
        [HttpPost]
        public int ExecuteBillTicket(string data)
        {
            try
            {
                DataTable dt = new DataTable();
                DataBillTicket dataDetail = JsonConvert.DeserializeObject<DataBillTicket>(data);

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Bill_Ticket_Insert]", CommandType.StoredProcedure
                        , "@Bill_ID", SqlDbType.Int, dataDetail.Bill_ID
                        , "@Chair", SqlDbType.Int, dataDetail.Chair
                        , "@Price", SqlDbType.Float, dataDetail.Price
                        , "@Schedule_ID",SqlDbType.Int,dataDetail.Schedule_ID);
                }
                return Convert.ToInt32(dt.Rows[0][0].ToString());
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        [Route("ExecuteBillProduct")]
        [HttpPost]
        public int ExecuteBillProduct(string data)
        {
            try
            {
                DataTable dt = new DataTable();
                DataBillProduct dataDetail = JsonConvert.DeserializeObject<DataBillProduct>(data);

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Bill_Product_Insert]", CommandType.StoredProcedure
                        , "@Bill_ID", SqlDbType.Int, dataDetail.Bill_ID
                        , "@Product_ID", SqlDbType.Int, dataDetail.ProductID
                        , "@Quan", SqlDbType.Int, dataDetail.Quan
                        , "@Price", SqlDbType.Float, dataDetail.Price);
                }
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        class DataBill
        {
            public int ScheduleID;
            public int Quan;
            public float Price;
        }
        class DataBillTicket
        {
            public int Bill_ID;
            public int Chair;
            public float Price;
            public int Schedule_ID;
        }
        class DataBillProduct
        {
            public int Bill_ID;
            public int ProductID;
            public int Quan;
            public float Price;
        }
    }
}
