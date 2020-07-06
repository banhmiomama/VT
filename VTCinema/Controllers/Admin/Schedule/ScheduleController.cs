using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace VTCinema.Controllers.Admin.Schedule
{
    [Route("Admin/Schedule")]
    public class ScheduleController : BaseController
    {
        public IActionResult Index()
        {
            return View("~/Views/Admin/Schedule/ScheduleView.cshtml");
        }

        [Route("LoadSchedule")]
        [HttpPost]
        public string LoadSchedule()
        {
            DataSet ds = new DataSet();
            DataTable Schedule = DataSchedule();
            Schedule.TableName = "Schedule";
            DataTable Branch = DataBranch();
            Branch.TableName = "Branch";
            ds.Tables.AddRange(new DataTable[] { Schedule, Branch });
            return JsonConvert.SerializeObject(ds);
        }
        DataTable DataSchedule()
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Schedule_LoadList]", CommandType.StoredProcedure);

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

        [Route("DeleteSchedule/{ID}")]
        [HttpGet]
        public string DeleteSchedule(int ID)
        {
            try
            {
                DataTable dt = new DataTable();
                using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                {
                    dt = confunc.ExecuteDataTable("[YYY_sp_Schedule_Delete]", CommandType.StoredProcedure,
                      "@CurrentID", SqlDbType.Int, ID,
                      "@Modified_By", SqlDbType.Int, HttpContext.Session.GetInt32(Comon.Global.UserID));
                }
                return "1";
            }
            catch (Exception ex)
            {
                return "0";
            }
        }
    }
}