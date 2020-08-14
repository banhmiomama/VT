using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Admin.Schedule
{
    [Route("Admin/ScheduleDetail")]
    public class ScheduleDetailController : Controller
    {
        [Route("{ScheduleID}")]
        [HttpGet]
        public IActionResult Index(int ScheduleID)
        {
            ViewBag.ScheduleID = ScheduleID;
            return View("~/Views/Admin/Schedule/ScheduleDetail.cshtml");
        }
        [Route("GetScheduleDetail/{ScheduleID}")]
        [HttpGet]
        public string GetScheduleDetail(int ScheduleID)
        {
            DataTable ComboMovie = LoadComboMovie();
            DataTable ComboTicketType = LoadComboMovieTicketType();
            DataTable ComboBranch = LoadComboBranch();
            DataTable ComboRoom = LoadComboRoom();
            DataTable Detail = LoadDetail(ScheduleID);
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { ComboMovie,ComboTicketType,ComboBranch, ComboRoom, Detail });
            return JsonConvert.SerializeObject(ds);
        }
        DataTable LoadComboMovie()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Movie_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboBranch()
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
        DataTable LoadComboMovieTicketType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieTicketType_LoadCombo]", CommandType.StoredProcedure, 
                        "@MovieID", SqlDbType.Int, 0);
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
        DataTable LoadComboRoom()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Room_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadDetail(int ScheduleID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Schedule_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, ScheduleID);
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

        [Route("LoadComboMovieTicketType/{MovieID}")]
        [HttpGet]
        public string LoadComboMovieTicketType(int MovieID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieTicketType_LoadCombo]", CommandType.StoredProcedure
                        , "@MovieID", SqlDbType.Int, MovieID);
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
        public string Execute(string data, int ScheduleID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataScheduleChoose dataDetail = JsonConvert.DeserializeObject<DataScheduleChoose>(data);

                if (ScheduleID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Schedule_Insert", CommandType.StoredProcedure,
                            "@MovieID",SqlDbType.Int,dataDetail.MovieID,
                            "@BranchID", SqlDbType.Int,dataDetail.BranchID,
                            "@RoomID", SqlDbType.Int,dataDetail.RoomID,
                            "@TicketTypeID", SqlDbType.Int,dataDetail.TicketTypeID,
                            "@ShowTime", SqlDbType.DateTime,dataDetail.ShowTime,
                            "@CloseTime", SqlDbType.DateTime,dataDetail.CloseTime,
                            "@Note", SqlDbType.NVarChar,dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Schedule_Update]", CommandType.StoredProcedure,
                           "@MovieID", SqlDbType.Int, dataDetail.MovieID,
                            "@BranchID", SqlDbType.Int, dataDetail.BranchID,
                            "@RoomID", SqlDbType.Int, dataDetail.RoomID,
                            "@TicketTypeID", SqlDbType.Int, dataDetail.TicketTypeID,
                            "@ShowTime", SqlDbType.DateTime, dataDetail.ShowTime,
                            "@CloseTime", SqlDbType.DateTime, dataDetail.CloseTime,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, ScheduleID,
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