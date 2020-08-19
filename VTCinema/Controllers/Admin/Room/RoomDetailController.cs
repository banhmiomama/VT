using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Room
{
    [Route("Admin/RoomDetail")]
    public class RoomDetailController : Controller
    {
        [Route("{RoomID}")]
        [HttpGet]
        public IActionResult Index(int RoomID)
        {
            ViewBag.RoomID = RoomID;
            return View("~/Views/Admin/Room/RoomDetail.cshtml");
        }
        [Route("GetRoomDetail/{RoomID}")]
        [HttpGet]
        public string GetRoomDetail(int RoomID)
        {
            DataSet ds = new DataSet();
            DataTable dtBranch = DataBranch();
            DataTable dtDetail = DataRoomDetail(RoomID);
            ds.Tables.AddRange(new DataTable[] {dtBranch,dtDetail});
            return JsonConvert.SerializeObject(ds);
        }

        [Route("GetRoomChairDetail/{RoomID}")]
        [HttpGet]
        public string GetRoomChairDetail(int RoomID)
        {
            DataSet ds = new DataSet();
            ds = DataRoomChair(RoomID);
            return JsonConvert.SerializeObject(ds);
        }
        DataSet DataRoomChair(int RoomID)
        {
            try
            {
                DataSet dt = new DataSet();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataSet("[YYY_sp_Cinema_Chair_LoadDetail]", CommandType.StoredProcedure,
                      "@RoomID", SqlDbType.Int, RoomID);
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
        DataTable DataBranch()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Branch_LoadCombo]", CommandType.StoredProcedure);
                    
                }
                if (dt != null)
                {
                    dt.TableName = "Branch";
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
        DataTable DataRoomDetail(int RoomID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Room_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, RoomID);
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

        [Route("DataChairType")]
        [HttpPost]
        public string DataChairType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_ChairType_LoadCombo]", CommandType.StoredProcedure);
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
        public string Execute(string data, int RoomID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataRoomChoose dataDetail = JsonConvert.DeserializeObject<DataRoomChoose>(data);

                if (RoomID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Room_Insert", CommandType.StoredProcedure,
                            "@NameRoom", SqlDbType.NVarChar, dataDetail.NameRoom,
                            "@BranchID", SqlDbType.VarChar, dataDetail.BranchID,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Room_Update]", CommandType.StoredProcedure,
                             "@NameRoom", SqlDbType.NVarChar, dataDetail.NameRoom,
                            "@BranchID", SqlDbType.VarChar, dataDetail.BranchID,
                            "@CurrentID", SqlDbType.Int, RoomID,
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
        [Route("ExecuteChairType")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string ExecuteChairType(string data)
        {
            try
            {
                DataTable dt = new DataTable();
                ChairType dataDetail = JsonConvert.DeserializeObject<ChairType>(data);
                using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                {
                    dt = connFunc.ExecuteDataTable("[YYY_sp_Cinema_ChairType_Update]", CommandType.StoredProcedure,
                        "@Chair", SqlDbType.Int, dataDetail.IDChair,
                        "@Type", SqlDbType.Int, dataDetail.Type 
                    );
                }
                return JsonConvert.SerializeObject(dt);
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
        class ChairType
        {
            public int IDChair { get; set; }
            public int Type { get; set; }
        }
    }
}