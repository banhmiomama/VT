
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
        public string sys_Role { get; set; }
        public string sys_RoleID { get; set; }
        public string sys_RoleName { get; set; }
        public string sys_BranchShortName { get; set; }

        public string sys_RoleServerID { get; set; }
        public string sys_BranchName { get; set; }
        public int sys_branchID { get; set; }
        public int sys_AllBranchID { get; set; }
        public int sys_employeeid { get; set; }
        public string sys_branchCode;
        public string sys_CompanyName;
        public string sys_CompanyAddress;
        public string sys_hotline;

        public string sys_userAvatar;

        // Permission Invidual User       
        // Extension
        public string sys_CalLExtension;
        public string sys_CalLExtensionPassword;
        public int sys_UsingCallCenter;
        // Limit By Branch
        public int sys_LimitPic { get; set; }
        public int sys_LimitSMS { get; set; }
        public int sys_isLimit { get; set; }


        public int DetectLimitDate(int userID)
        {
            using (Models.ExecuteDataBase connFunc = new Models.ExecuteDataBase())
            {
                DataTable dt = connFunc.ExecuteDataTable("[YYY_sp_Permission_User_LimitDate]",
                    CommandType.StoredProcedure, "@userID", SqlDbType.Int, userID

                 );

                if (dt != null && dt.Rows.Count > 0)
                {
                    return Convert.ToInt32(dt.Rows[0][0].ToString());
                }
                else
                {
                    return 0;
                }
            }
        }
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
        public void DetectUserInfo(int id)
        {
            DataTable dtUser = new DataTable();
            using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
            {
                dtUser = confunc.ExecuteDataTable("[YYY_sp_GetGlobal_User]", CommandType.StoredProcedure, "@UserID", SqlDbType.Int, sys_userid);
            }
            DataTable dtUserCall = new DataTable();
            using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
            {
                dtUserCall = confunc.ExecuteDataTable("[YYY_sp_GetGlobal_CallExtension]", CommandType.StoredProcedure, "@UserID", SqlDbType.Int, sys_userid);
            }
            DataTable dt = new DataTable();
            using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
            {
                dt = confunc.ExecuteDataTable("[YYY_sp_Permission_LoadMenuGroup]", CommandType.StoredProcedure,
                    "@GroupID", SqlDbType.Int, Convert.ToInt32(sys_RoleID));
            }
            DataTable dtLimit = new DataTable();
            using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
            {
                dtLimit = confunc.ExecuteDataTable("YYY_sp_GetLimit_Branch", CommandType.StoredProcedure,
                    "@BranchID", SqlDbType.Int, Convert.ToInt32(dtUser.Rows[0]["Branch_ID"].ToString()));
            }
            if (dtUser != null && dtUser.Rows.Count != 0 && dt != null)
            {


                //this.user = new GlobalUser()
                //{
                //    sys_userid = id,
                //    sys_CalLExtension = (dtUserCall != null && dtUserCall.Rows.Count == 1) ? dtUserCall.Rows[0]["Extension"].ToString() : "",
                //    sys_CalLExtensionPassword = (dtUserCall != null && dtUserCall.Rows.Count == 1) ? dtUserCall.Rows[0]["Password"].ToString() : "",
                //    sys_UsingCallCenter = (dtUserCall != null && dtUserCall.Rows.Count == 1) ? 1 : 0,
                //    sys_branchID = Convert.ToInt32(dtUser.Rows[0]["Branch_ID"].ToString()),
                //    sys_AllBranchID = Convert.ToInt32(dtUser.Rows[0]["AllBranchID"].ToString()),
                //    sys_branchCode = dtUser.Rows[0]["ShortName"].ToString(),
                //    sys_CompanyName = dtUser.Rows[0]["sys_CompanyName"].ToString(),
                //    sys_CompanyAddress = dtUser.Rows[0]["sys_CompanyAddress"].ToString(),
                //    sys_hotline = dtUser.Rows[0]["Tel"].ToString(),
                //    sys_employeeid = Convert.ToInt32(dtUser.Rows[0]["Employee_ID"].ToString()),
                //    sys_username = dtUser.Rows[0]["Username"].ToString(),
                //    sys_BranchShortName = dtUser.Rows[0]["ShortName"].ToString(),
                //    sys_RoleName = dtUser.Rows[0]["Role"].ToString(),
                //    sys_BranchName = dtUser.Rows[0]["BranchName"].ToString(),
                //    sys_Role = dtUser.Rows[0]["Role"].ToString(),
                //    sys_RoleID = dtUser.Rows[0]["Group_ID"].ToString(),
                //    sys_RoleServerID = dtUser.Rows[0]["InheritanceServer"].ToString(),
                //    sys_userAvatar = dtUser.Rows[0]["userAvatar"].ToString(),
                //   // sys_PermissionMenu = GetPermissionByGroup(Global.sys_PermissionTableMenu_Table, dtUser.Rows[0]["InheritanceServer"].ToString()),
                //  //  sys_PermissionControl = GetPermissionByGroup(Global.sys_PermissionControl_Table, dtUser.Rows[0]["InheritanceServer"].ToString()),
                //    sys_isLimit = (dtLimit != null && dtLimit.Rows.Count != 0 && dtLimit.Rows[0][0].ToString() != "0") ? 1 : 0
                //};

            }

        }

        private DataTable GetPermissionByGroup(DataTable dt, string roleID)
        {
            try
            {
                DataRow[] dr = dt.Select("PermissionGroupID=" + roleID);
                return null;// dr.CopyToDataTable();
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
    
    public class Global
    {
        public static string UserID = "UserID";
    }
}