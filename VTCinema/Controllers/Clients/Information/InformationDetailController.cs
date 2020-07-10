using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Clients.MovieDetail
{
    [Route("InformationDetail")]
    public class InformationDetailController : Controller
    {
        [Route("{InformationDetailID}")]
        [HttpGet]
        public IActionResult Index( int InformationDetailID)
        {
            ViewBag.InformationDetailID = InformationDetailID;
            return View("~/Views/Clients/Information/InformationDetail.cshtml");
        }
        [Route("GetInformationDetail/{InformationDetailID}")]
        [HttpGet]
        public string GetInformationDetail(int InformationDetailID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Client_Infomation_LoadDetail]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, InformationDetailID);
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

        [Route("LoadTicket")]
        [HttpPost]
        public string LoadTicket()
        {
            DataSet ds = new DataSet();
            DataTable Movie = DataMovie();
            Movie.TableName = "Movie";
            DataTable Branch = DataBranch();
            Branch.TableName = "Branch";
            ds.Tables.AddRange(new DataTable[] { Movie, Branch });
            return JsonConvert.SerializeObject(ds);
        }
        DataTable DataMovie()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_MovieAll_LoadCombo]", CommandType.StoredProcedure);

                }
                if (dt != null)
                {
                    dt.TableName = "Movie";
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



    }
}
