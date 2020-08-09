using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.Movie
{
    [Route("Admin/MovieDetail")]
    public class MovieDetailController : BaseController
    {        

        [Route("{MovieID}")]
        [HttpGet]
        public IActionResult Index(int MovieID)
        {
            ViewBag.MovieID = MovieID;
            return View("~/Views/Admin/Movie/MovieDetail.cshtml");
        }
        [Route("GetMovieDetail/{MovieID}")]
        [HttpGet]
        public string GetMovieDetail(int MovieID)
        {
            DataTable Detail = LoadDetail(MovieID);
            Detail.TableName = "LoadDetail";
            DataTable ComboNational = LoadComboNational();
            ComboNational.TableName = "National";
            DataTable ComboAgeType = LoadComboAgeType();
            ComboAgeType.TableName = "AgeType";
            DataTable ComboSubTitle = LoadComboSubTitle();
            ComboSubTitle.TableName = "SubTitle";
            DataTable ComboMovieType = LoadComboMovieType();
            ComboMovieType.TableName = "MovieType";
            DataTable ComboMovieTicketType = LoadComboMovieTicketType();
            ComboMovieTicketType.TableName = "MovieTicketType";
            DataTable ComboDirector = LoadComboDirector();
            ComboDirector.TableName = "Director";
            DataTable ComboActor = LoadComboActor();
            ComboActor.TableName = "Actor";
            DataSet ds = new DataSet();
            ds.Tables.AddRange(new DataTable[] { Detail, ComboNational, ComboAgeType,ComboSubTitle,ComboMovieType,ComboMovieTicketType,ComboDirector,ComboActor });
            return JsonConvert.SerializeObject(ds);
        }
        
        DataTable LoadDetail(int MovieID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Movie_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, MovieID);
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
        DataTable LoadComboNational()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_National_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboAgeType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_AgeType_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboSubTitle()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_SubTitle_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboMovieType()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieType_LoadCombo]", CommandType.StoredProcedure);
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
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieTicketType_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboDirector()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Director_LoadCombo]", CommandType.StoredProcedure);
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
        DataTable LoadComboActor()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Actor_LoadCombo]", CommandType.StoredProcedure);
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


       
        [Route("Execute")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public string Execute(string data, int MovieID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataMovieChoose dataDetail = JsonConvert.DeserializeObject<DataMovieChoose>(data);

                if (MovieID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_Movie_Insert", CommandType.StoredProcedure,
                            "@Name_VN", SqlDbType.NVarChar, dataDetail.NameVN,
                            "@Name_EN", SqlDbType.NVarChar, dataDetail.NameEN,
                            "@Image", SqlDbType.VarChar, dataDetail.Image,
                            "@VideoTrailer", SqlDbType.VarChar, dataDetail.VideoTrailer,
                            "@Nationality", SqlDbType.Int, dataDetail.NationalityID,
                            "@Year_Movie", SqlDbType.Int, dataDetail.YearMovie,
                            "@Ages_ID", SqlDbType.Int, dataDetail.AgeID,
                            "@Opening_Time", SqlDbType.Int, dataDetail.OpeningTime,
                            "@SubTitle_ID",SqlDbType.Int,dataDetail.SubTitleID,
                            "@MovieType_ID", SqlDbType.VarChar,dataDetail.MovieTypeID,
                            "@MovieTicketType_ID", SqlDbType.Int,dataDetail.MovieTicketTypeID,
                            "@Director_ID", SqlDbType.Int,dataDetail.DirectorID,
                            "@Actor_ID", SqlDbType.VarChar,dataDetail.ActorID,
                            "@Note", SqlDbType.VarChar,dataDetail.Note,
                            "@Movie_Time_Duration", SqlDbType.Int,dataDetail.MovieTimeDuration,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_Movie_Update]", CommandType.StoredProcedure,
                            "@Name_VN", SqlDbType.NVarChar, dataDetail.NameVN,
                            "@Name_EN", SqlDbType.NVarChar, dataDetail.NameEN,
                            "@Image", SqlDbType.VarChar, dataDetail.Image,
                            "@VideoTrailer", SqlDbType.VarChar, dataDetail.VideoTrailer,
                            "@Nationality", SqlDbType.Int, dataDetail.NationalityID,
                            "@Year_Movie", SqlDbType.Int, dataDetail.YearMovie,
                            "@Ages_ID", SqlDbType.Int, dataDetail.AgeID,
                            "@Opening_Time", SqlDbType.Int, dataDetail.OpeningTime,
                            "@SubTitle_ID", SqlDbType.Int, dataDetail.SubTitleID,
                            "@MovieType_ID", SqlDbType.VarChar, dataDetail.MovieTypeID,
                            "@MovieTicketType_ID", SqlDbType.Int, dataDetail.MovieTicketTypeID,
                            "@Director_ID", SqlDbType.Int, dataDetail.DirectorID,
                            "@Actor_ID", SqlDbType.VarChar, dataDetail.ActorID,
                            "@Note", SqlDbType.VarChar, dataDetail.Note,
                            "@Movie_Time_Duration", SqlDbType.Int, dataDetail.MovieTimeDuration,
                            "@CurrentID", SqlDbType.Int, MovieID,
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