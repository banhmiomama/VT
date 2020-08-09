using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Comon;

namespace VTCinema.Controllers.Clients.Detail
{
    [Route("MovieDetail")]
    public class MovieDetailController : Controller
    {
        int DetailMovieID;
        [Route("{MovieDetailID}")]
        [HttpGet]
        public IActionResult Index(int MovieDetailID)
        {
            ViewBag.MovieDetailID = MovieDetailID;
            DetailMovieID = MovieDetailID;
            return View("~/Views/Clients/MovieDetail/MovieDetailView.cshtml");
        }

        [Route("GetMovieDetail/{MovieDetailID}")]
        [HttpGet]
        public string GetMovieDetail(int MovieDetailID)
        {
            try
            {
                DataSet ds = new DataSet();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataSet("[YYY_sp_Client_Movie_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, MovieDetailID);
                }
                if (ds != null)
                {
                    return JsonConvert.SerializeObject(ds);
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

        [Route("LoadDataScheduleMovie")]
        [HttpPost]
        public string LoadDataScheduleMovie()
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dtBranch = DataBranch();
                DataTable dtSchedule = DataScheduleMovie();

                ds.Tables.AddRange(new DataTable[] { dtBranch, dtSchedule });
                return JsonConvert.SerializeObject(ds);
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
        DataTable DataBranch()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_BranchAll_LoadCombo]", CommandType.StoredProcedure);

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
        DataTable DataScheduleMovie()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Schedule_LoadDetail]", CommandType.StoredProcedure, "@MovieID",SqlDbType.Int, ViewBag.MovieDetailID);

                }
                if (dt != null)
                {
                    dt.TableName = "Schedule";
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
        [Route("LoadDataComment")]
        [HttpPost]
        public string LoadDataComment(int MovieID)
        {
            try
            {
                DataTable ds = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataTable("[YYY_sp_Rating_LoadList]", CommandType.StoredProcedure
                        , "@MovieID", SqlDbType.Int, MovieID);

                }
                if (ds != null)
                {
                    return JsonConvert.SerializeObject(ds);
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
        [Route("ExecuteRating")]
        [HttpPost]
        public string ExecuteRating(string data)
        {
            try
            {
                DataTable ds = new DataTable();;
                DataRating dataDetail = JsonConvert.DeserializeObject<DataRating>(data);
                if(HttpContext.Session.GetInt32(Comon.GlobalClient.CustomerID) == null)
                {
                    return "0";
                }
                int CustomerID = (int)HttpContext.Session.GetInt32(Comon.GlobalClient.CustomerID);
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    ds = confunc.ExecuteDataTable("[YYY_sp_Rating_Insert]", CommandType.StoredProcedure
                        , "@MovieID", SqlDbType.Int, dataDetail.MovieID
                        , "@Note", SqlDbType.NVarChar, dataDetail.NoteRating
                        , "@Rating", SqlDbType.Decimal, dataDetail.RatingMoive
                        , "@CusID", SqlDbType.Int, CustomerID) ;
                }
                return ds.Rows[0][0].ToString();
            }
            catch (Exception ex)
            {
                return "[]";
            }
        }
        class DataRating
        {
            public string NoteRating;
            public decimal RatingMoive;
            public int MovieID;
            
        }
    }
}
