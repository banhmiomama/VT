using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Clients.Detail
{
    [Route("MovieDetail")]
    public class MovieDetailController : Controller
    {
        [Route("{MovieDetailID}")]
        [HttpGet]
        public IActionResult Index(int MovieDetailID)
        {
            ViewBag.MovieDetailID = MovieDetailID;
            return View("~/Views/Clients/MovieDetail/MovieDetailView.cshtml");
        }
        [Route("GetMovieDetail/{MovieDetailID}")]
        [HttpGet]
        public string GetMovieDetail(int MovieDetailID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Movie_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, MovieDetailID);
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

    }
}
