
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace VTCinema.Comon
{
    public class GlobalUser
    {
        public GlobalUser user;
        public int sys_userid { get; set; }
      
        public string sys_username { get; set; }
        public string sys_RoleID { get; set; }
        public static string sys_userAvatar { get; set; }      
        public int sys_customerid { get; set; }
        public static string sys_Email { get; set; }

        public int DetectAuthorised(string user, string pass)
        {
            try
            {
                using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                {
                    DataTable dt = connFunc.ExecuteDataTable("[YYY_sp_Permission_User_LogIn]",
                        CommandType.StoredProcedure,
                         "@username", SqlDbType.NVarChar, user.Replace("'", "").Trim(),
                         "@password", SqlDbType.NVarChar, pass.Replace("'", "").Trim()
                     );

                    if (dt.Rows.Count > 0)
                    {
                        sys_userid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        sys_username = dt.Rows[0]["username"].ToString();
                        sys_RoleID = dt.Rows[0]["Group_ID"].ToString();
                        sys_userAvatar = dt.Rows[0]["Avatar"].ToString();
                        //sys_RoleServerID = dt.Rows[0]["InheritanceServer"].ToString();
                        //DetectUserInfo(sys_userid);
                        return sys_userid;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int DetectAuthorisedClient(string user, string pass)
        {
            try
            {
                using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
                {
                    DataTable dt = connFunc.ExecuteDataTable("[YYY_sp_Permission_UserClient_LogIn]",
                        CommandType.StoredProcedure,
                         "@username", SqlDbType.NVarChar, user.Replace("'", "").Trim(),
                         "@password", SqlDbType.NVarChar, pass.Replace("'", "").Trim()
                     );

                    if (dt.Rows.Count > 0)
                    {
                        sys_customerid = Convert.ToInt32(dt.Rows[0]["ID"].ToString());
                        sys_Email = dt.Rows[0]["Email"].ToString();                     
                        //sys_RoleServerID = dt.Rows[0]["InheritanceServer"].ToString();
                        //DetectUserInfo(sys_userid);
                        return sys_customerid;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
    
    public class Global
    {
        public static string UserID = "UserID";
    }
    public class GlobalClient
    {
        public static string CustomerID = "CustomerID";
    }
}