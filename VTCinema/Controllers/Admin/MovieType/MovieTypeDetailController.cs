using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.MovieType
{
    [Route("Admin/MovieTypeDetail")]
    public class MovieTypeDetailController : Controller
    {
       [Route("{MovieTypeID}")]
        [HttpGet]
        public IActionResult Index(int MovieTypeID)
        {
            ViewBag.MovieTypeID = MovieTypeID;
            return View("~/Views/Admin/MovieType/MovieTypeDetail.cshtml");
        }
        [Route("GetMovieTypeDetail/{MovieTypeID}")]
        [HttpGet]
        public string GetMovieTypeDetail(int MovieTypeID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieType_Detail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, MovieTypeID);
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
        public string Execute(string data, int MovieTypeID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataMovieTypeChoose dataDetail = JsonConvert.DeserializeObject<DataMovieTypeChoose>(data);
                
                if (MovieTypeID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_MovieType_Insert", CommandType.StoredProcedure,
                            "@Name_Type", SqlDbType.NVarChar, dataDetail.Name,
                            "@Note", SqlDbType.Int, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("[YYY_sp_MovieType_Update]", CommandType.StoredProcedure,
                            "@Name_Type", SqlDbType.NVarChar, dataDetail.Name,
                            "@Note", SqlDbType.Int, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, MovieTypeID ,
                            "@Modified_By", SqlDbType.Int,HttpContext.Session.GetInt32(Comon.Global.UserID)
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
