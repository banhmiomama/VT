using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using VTCinema.Models;

namespace VTCinema.Controllers.MovieTicketType
{
    [Route("MovieTicketTypeDetail")]
    public class MovieTicketTypeDetailController : Controller
    {
        [Route("{MovieTicketTypeID}")]
        [HttpGet]
        public IActionResult Index(int MovieTicketTypeID)
        {
            ViewBag.MovieTicketTypeID = MovieTicketTypeID;
            return View("~/Views/MovieTicketType/MovieTicketTypeDetail.cshtml");
        }
        [Route("GetMovieTicketTypeDetail/{MovieTicketTypeID}")]
        [HttpGet]
        public string GetMovieTicketTypeDetail(int MovieTicketTypeID)
        {
            try
            {
                DataTable dt = new DataTable();

                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieTicketType_LoadDetail]", CommandType.StoredProcedure,
                        "@CurrentID", SqlDbType.Int, MovieTicketTypeID);

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
        public string Execute(string data, int MovieTicketTypeID)
        {
            try
            {
                DataTable dt = new DataTable();
                DataMovieTicketTypeChoose dataDetail = JsonConvert.DeserializeObject<DataMovieTicketTypeChoose>(data);

                if (MovieTicketTypeID == 0)
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_MovieTicketType_Insert", CommandType.StoredProcedure,
                            "@Name", SqlDbType.NVarChar, dataDetail.Name,
                            "@Price", SqlDbType.Int, dataDetail.Price,
                            "@Note", SqlDbType.NVarChar, dataDetail.Note,
                            "@CurrentID", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID)
                        );
                    }
                }
                else
                {
                    using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                    {
                        dt = connFunc.ExecuteDataTable("YYY_sp_MovieTicketType_Update", CommandType.StoredProcedure,
                           "@CurrentID", SqlDbType.Int, MovieTicketTypeID,
                           "@Name", SqlDbType.NVarChar, dataDetail.Name,
                           "@Price", SqlDbType.Int, dataDetail.Price,
                           "@Note", SqlDbType.NVarChar, dataDetail.Note,
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