
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace VTTECH_2019_08_20.Comon
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
        public DataTable sys_PermissionMenu;
        public DataTable sys_PermissionControl;
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
    //public class Global
    //{
    //    public static readonly string keyfileVietGreat = "@1B2c3D4e5F6g7H8@TECHVT";
    //    public static readonly string fileVietGreat = AppDomain.CurrentDomain.BaseDirectory+"/fileVietGreat.txt";
    //    // SMS Keyword
    //    public static DataTable sys_SMS_NotInBrandName;

    //    // Link SIGN IN
    //    public static string sys_SignInLINK;
    //    public static string sys_DBVersion;
    //    public static string sys_NameClient;
    //    public static string sys_DBTOCATCHSQL;
    //    public static string sys_DB_IP;
    //    public static string sys_DB_Name;
    //    public static string sys_DB_User;
    //    public static string sys_DB_Pass;

    //    public static string sys_ServerImageFolder;
    //    public static string sys_ServerImageUserName;
    //    public static string sys_ServerImagePassword;
    //    public static string sys_HTTPImageRoot;
    //    public static string sys_DefaultAvatar;

    //    public static string sys_CodePayment;
    //    public static string sys_CodePaymentReturn;
    //    public static string sys_PassworDefault;
    //    public static string sys_SMSRemind { get; set; }
    //    public static int sys_MaxImportTicket { get; set; }

    //    // SETTING Searching , access cus,access tic
    //    public static int sys_SearchingInBranch;
    //    public static int sys_PreventCusByBranch;

    //    // SMS User PopUP
    //    public static DataTable sys_UserPopup;
    //    public static DataTable sys_AuthosizeSettingFunction;
    //    // SMS SETTING

    //    public static string sys_ALLHTTPDocument;
    //    public static string sys_ALLFTP_USER;
    //    public static string sys_ALLFTP_FTPDocument;
    //    public static string sys_ALLFTP_PASSWORD;
    //    public static string sys_SMSAfterPaymentContent;

    //    // SMS After Payment
    //    public static int sys_isSMSAfterPayment;

    //    // SMS SETTING
    //    public static string sys_SMSThirdParty = "";
    //    public static string sys_SMSUserName = "";
    //    public static string sys_SMSPassword = "";
    //    public static string sys_SMSBrandName = "";
    //    public static string sys_SMSShareKey = "";
    //    public static string sys_SMSLogin = "";
    //    public static string sys_SMSSendSMS = "";
    //    public static string sys_SMSBrandNameShow = "";

    //    // Treatment Setting
    //    public static int sys_PercentTreatment;
    //    public static int sys_DentistCosmetic;

    //    // Show GUide For End User
    //    public static int sys_isShowUserGuide;

    //    // Permission Absoulte
    //    public static DataTable sys_PermissionTableMenu_Table;
    //    public static DataTable sys_PermissionMenuMustHide_Table;
    //    public static DataTable sys_PermissionFirstPage_Table;
    //    public static DataTable sys_PermissionControl_Table;
    //    public static DataTable sys_PermissionControlMustHide_Table;
    //    public static DataTable sys_TabCustomer;
    //    public static DataTable sys_GuideForEndUser;
    //    public static DataTable sys_Report;

    //    // Document
    //    public static DataTable sys_Document;

    //    // Call Center Argument
    //    public static string sys_CallNumber = "";
    //    public static string sys_CallHost = "";
    //    public static string sys_CallPort = "";
    //    public static string sys_CallApi_Key = "";
    //    public static string sys_CallDomain = "";
    //    public static string sys_CallPBXIP = "";
    //    public static string sys_CallPBXPort = "";
    //    public static string sys_CallOutBound = "";
    //    public static string sys_CallOutBoundPort = "";

    //    public static void DetectSettingAbosulute()
    //    {
    //        int autho = DetectDataBase(sys_DBTOCATCHSQL);
    //        if (autho == 1)
    //        {
    //            DetectInitiliazePermission(sys_DBTOCATCHSQL);
    //            DetectInitiliazeFirstPage();
    //            DetectSMSAPI(sys_DBTOCATCHSQL);
    //            DetectOption(sys_DBTOCATCHSQL);
    //            DetectCallCenter(sys_DBTOCATCHSQL);
    //            DetectDocument(sys_DBTOCATCHSQL);
    //            DetectUserPopup(sys_DBTOCATCHSQL);
    //            DetectSMSNotInBrandName();
    //        }

    //    }
    //    private static void DetectSMSNotInBrandName()
    //    {
    //        try
    //        {
    //            DataTable dt = new DataTable();
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_SMS_GetKeyWord]", CommandType.StoredProcedure);
    //                if (dt != null)
    //                {
    //                    sys_SMS_NotInBrandName = dt;
    //                }
    //                else
    //                {
    //                    sys_SMS_NotInBrandName = null;
    //                }
    //            }
    //        }
    //        catch
    //        {

    //        }
    //    }

    //    public static void DetectDBByCode(string keycode)
    //    {
    //        try
    //        {
    //            DataTable dt = new DataTable();
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {


    //                dt = connFunc.ExecuteDataTable("YYY_sp_DB_AuthorizeDBName", CommandType.StoredProcedure, "@KeyCode", SqlDbType.NVarChar, keycode);
    //                if (dt != null && dt.Rows.Count == 1)
    //                {
    //                    sys_SignInLINK = dt.Rows[0]["LinkSignIn"].ToString();
    //                    sys_DBTOCATCHSQL = dt.Rows[0]["DBName"].ToString();
    //                    sys_DBVersion = dt.Rows[0]["Version"].ToString();
    //                    sys_NameClient = dt.Rows[0]["ClientName"].ToString();
    //                }
    //                else
    //                {
    //                    sys_SignInLINK = "";
    //                    sys_DBTOCATCHSQL = "";
    //                    sys_DBVersion = "";
    //                    sys_NameClient = "";
    //                }
    //            }
    //        }
    //        catch
    //        {
    //            sys_SignInLINK = "";
    //            sys_DBTOCATCHSQL = "";
    //            sys_DBVersion = "";
    //            sys_NameClient = "";
    //        }

    //    }

    //    private static void DetectInitiliazeFirstPage()
    //    {
    //        try
    //        {
    //            DataTable dt = new DataTable();
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Per_FirstPageLogin]", CommandType.StoredProcedure);
    //                if (dt != null)
    //                {
    //                    sys_PermissionFirstPage_Table = dt;
    //                }
    //                else
    //                {

    //                }
    //            }
    //        }
    //        catch
    //        {

    //        }
    //    }
    //    private static void DetectUserPopup(string db)
    //    {
    //        try
    //        {
    //            DataTable dt = new DataTable();
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Popup_GetPopup]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_UserPopup = dt;
    //                }
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_AuthorizeFunction]", CommandType.StoredProcedure);
    //                if (dt != null)
    //                {
    //                    sys_AuthosizeSettingFunction = dt;
    //                }

    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //        }




    //    }
    //    private static void DetectDocument(string db)
    //    {
    //        try
    //        {
    //            DataTable dt = new DataTable();
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Document_GetAll]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    for (int i = 0; i < dt.Rows.Count; i++)
    //                    {
    //                        dt.Rows[i]["DocUrlHTTP"] = sys_ALLHTTPDocument + dt.Rows[i]["DocUrl"].ToString();
    //                    }
    //                    sys_Document = dt;
    //                }
    //                else
    //                {

    //                }
    //            }
    //        }
    //        catch
    //        {

    //        }
    //    }
    //    private static void DetectInitiliazePermission(string db)
    //    {
    //        try
    //        {
    //            DataTable dt = new DataTable();
    //            DataSet ds = new DataSet();
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Per_GetMenu]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_PermissionTableMenu_Table = dt;
    //                }

    //                ds = connFunc.ExecuteDataSet("[YYY_sp_Per_GetControll]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (ds != null)
    //                {
    //                    sys_PermissionControl_Table = ds.Tables[0];
    //                    sys_PermissionControlMustHide_Table = ds.Tables[1];
    //                }
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Per_GetTab]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_TabCustomer = dt;
    //                }
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Per_GetUserGuide]", CommandType.StoredProcedure);
    //                if (dt != null)
    //                {
    //                    sys_GuideForEndUser = dt;

    //                }
    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Per_GetReport]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_Report = dt;
    //                }

    //                dt = connFunc.ExecuteDataTable("[YYY_sp_Per_GetmenuHideFromServer]", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_PermissionMenuMustHide_Table = dt;
    //                }

    //            }
    //        }
    //        catch
    //        {

    //        }

    //    }
    //    private static void DetectOption(string db)
    //    {
    //        try
    //        {
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                DataTable dt = new DataTable();
    //                dt = connFunc.ExecuteDataTable("YYY_sp_DB_DetectOption", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_DentistCosmetic = Convert.ToInt32(dt.Rows[0]["Type"].ToString());
    //                    sys_isShowUserGuide = Convert.ToInt32(dt.Rows[0]["isShowUserGuide"].ToString());
    //                    sys_ServerImageFolder = dt.Rows[0]["ImageFolder"].ToString();
    //                    sys_ServerImageUserName = dt.Rows[0]["ImageUserName"].ToString();
    //                    sys_ServerImagePassword = dt.Rows[0]["ImagePassword"].ToString();
    //                    sys_SearchingInBranch = Convert.ToInt32(dt.Rows[0]["SearchCusInBranch"].ToString());
    //                    sys_PreventCusByBranch = Convert.ToInt32(dt.Rows[0]["PreventCusByBranch"].ToString());
    //                    sys_isSMSAfterPayment = Convert.ToInt32(dt.Rows[0]["isSMSAfterPayment"].ToString());
    //                    sys_HTTPImageRoot = dt.Rows[0]["ImageURL"].ToString();
    //                }

    //                dt = connFunc.ExecuteDataTable("YYY_sp_DetectOption", CommandType.StoredProcedure);
    //                if (dt != null)
    //                {
    //                    for (int i = 0; i < dt.Rows.Count; i++)
    //                    {
    //                        switch (dt.Rows[i]["Name"].ToString())
    //                        {
    //                            case "HTTPDocument":
    //                                sys_ALLHTTPDocument = dt.Rows[i]["Value"].ToString();
    //                                break;

    //                            case "FTPUser":
    //                                sys_ALLFTP_USER = dt.Rows[i]["Value"].ToString();
    //                                break;
    //                            case "FTPDocument":
    //                                sys_ALLFTP_FTPDocument = dt.Rows[i]["Value"].ToString();
    //                                break;
    //                            case "FTPPass":
    //                                sys_ALLFTP_PASSWORD = dt.Rows[i]["Value"].ToString();
    //                                break;
    //                            case "SMSAfterPaymentContent":
    //                                sys_SMSAfterPaymentContent = dt.Rows[i]["Value"].ToString();
    //                                break;

    //                            default: break;
    //                        }
    //                    }
    //                }
    //            }
    //        }
    //        catch (Exception ex)
    //        {

    //        }
    //    }
    //    private static int DetectDataBase(string db)
    //    {
    //        try
    //        {
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                DataTable dt = new DataTable();
    //                dt = connFunc.ExecuteDataTable("YYY_sp_DB_DetectNameString", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_DB_IP = dt.Rows[0]["IP"].ToString();
    //                    sys_DB_Name = dt.Rows[0]["DBName"].ToString();
    //                    sys_DB_User = dt.Rows[0]["DBUser"].ToString();
    //                    sys_DB_Pass = dt.Rows[0]["DBPass"].ToString();
    //                    return 1;
    //                }
    //                else
    //                {
    //                    return 0;
    //                }
    //            }

    //        }
    //        catch
    //        {
    //            return 0;
    //        }
    //    }
    //    private static void DetectSMSAPI(string db)
    //    {
    //        try
    //        {
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                DataTable dt = new DataTable();
    //                dt = connFunc.ExecuteDataTable("YYY_sp_DB_DetectSMS", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_SMSThirdParty = dt.Rows[0]["ThirdParty"].ToString();
    //                    sys_SMSUserName = dt.Rows[0]["UserName"].ToString();
    //                    sys_SMSPassword = dt.Rows[0]["Password"].ToString();
    //                    sys_SMSBrandName = dt.Rows[0]["BrandName"].ToString();
    //                    sys_SMSShareKey = dt.Rows[0]["ShareKey"].ToString();
    //                    sys_SMSLogin = dt.Rows[0]["UrlLogin"].ToString();
    //                    sys_SMSSendSMS = dt.Rows[0]["UrlSend"].ToString();
    //                    sys_SMSBrandNameShow = dt.Rows[0]["BrandNameShow"].ToString();

    //                }
    //            }
    //        }
    //        catch
    //        {

    //        }
    //    }
    //    private static void DetectCallCenter(string db)
    //    {
    //        try
    //        {
    //            using (Models.ExecuteDataBaseRoot connFunc = new Models.ExecuteDataBaseRoot())
    //            {
    //                DataTable dt = new DataTable();
    //                dt = connFunc.ExecuteDataTable("YYY_sp_DB_DetectCallCenter", CommandType.StoredProcedure, "@db", SqlDbType.NVarChar, db);
    //                if (dt != null)
    //                {
    //                    sys_CallNumber = dt.Rows[0]["Number"].ToString();
    //                    sys_CallHost = dt.Rows[0]["Host"].ToString();
    //                    sys_CallPort = dt.Rows[0]["Port"].ToString();
    //                    sys_CallApi_Key = dt.Rows[0]["Api_Key"].ToString();
    //                    sys_CallDomain = dt.Rows[0]["Domain"].ToString();
    //                    sys_CallPBXIP = dt.Rows[0]["PBXIP"].ToString();
    //                    sys_CallPBXPort = dt.Rows[0]["PBXPort"].ToString();
    //                    sys_CallOutBound = dt.Rows[0]["Outbound"].ToString();
    //                    sys_CallOutBoundPort = dt.Rows[0]["OutBound_Port"].ToString();
    //                }
    //            }
    //        }
    //        catch
    //        {

    //        }
    //    }

    //    public static void Initalize()
    //    {
    //        sys_SMSRemind = "";


    //        DataTable dtContent = new DataTable();
    //        using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
    //        {
    //            dtContent = confunc.ExecuteDataTable("[YYY_sp_Option_Get]", CommandType.StoredProcedure);
    //        }

    //        if (dtContent != null && dtContent.Rows.Count != 0)
    //        {
    //            foreach (DataRow dRow in dtContent.Rows)
    //            {
    //                switch (dRow["Type"].ToString())
    //                {

    //                    case "sys_DefaultAvatar":
    //                        sys_DefaultAvatar = dRow["Value"].ToString().Trim();
    //                        break;

    //                    case "sys_MaxImportTicket":
    //                        sys_MaxImportTicket = Convert.ToInt32(dRow["Value"].ToString().Trim());
    //                        break;
    //                    case "sys_CodePayment":
    //                        sys_CodePayment = dRow["Value"].ToString().Trim();
    //                        break;
    //                    case "sys_CodePaymentReturn":
    //                        sys_CodePaymentReturn = dRow["Value"].ToString().Trim();
    //                        break;
    //                    case "PasswordDefault":
    //                        sys_PassworDefault = dRow["Value"].ToString().Trim();
    //                        break;
    //                    case "sys_PercentTreatment":
    //                        sys_PercentTreatment = Convert.ToInt32(dRow["Value"].ToString().Trim());
    //                        break;


    //                }
    //            }
    //        }
    //    }
    //}
    public class Global
    {
        public static string UserID = "UserID";
    }
}