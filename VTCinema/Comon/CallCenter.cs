using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Xml;


namespace VTTECH_2019_08_20.Comon
{
    public static class CallCenter
    {
        public static int ExecuteCall_External(string phone)
        {
            try
            {
                //GlobalUser user = (GlobalUser)HttpContext.Current.Session["CurrentUserInfo"];
                //if (phone.Length != 10) return 0;
                //string url = String.Format(@"http://{0}:{1}/pbx/v1.0/calls",Global.sys_CallHost, Global.sys_CallPort);
                //var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                //httpWebRequest.ContentType = "application/json";
                //httpWebRequest.Method = "POST";
                //httpWebRequest.Headers.Add("x-api-key", Global.sys_CallApi_Key);
                //using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                //{
                //    string json = "{\"type\":\"" + "external" + "\"" + ","
                //                  + "\"caller\":\"" + user.sys_CalLExtension  + "\"" + ","
                //                  + "\"callee\":\"" + phone + "\"" 
                //                  + "}";

                //    streamWriter.Write(json);
                //    streamWriter.Flush();
                //    streamWriter.Close();
                //}
                //var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                return 1;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        //public static string GetOutboundLog(string phone)
        //{
        //    try
        //    {
        //        if (phone.Length != 10) return "";
        //        string url = String.Format(@"http://{0}:{1}/pbx/v1.0/call-logs/outbound", Global.sys_CallHost, Global.sys_CallPort);
        //        long timespan = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        //        var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
        //        httpWebRequest.ContentType = "application/json";
        //        httpWebRequest.Method = "POST";
        //        httpWebRequest.Headers.Add("x-api-key", Global.sys_CallApi_Key);
        //        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        //        {
        //            string json = "{\"queryTime\":\"" + timespan + "\"" 
        //                          + "}";
        //            streamWriter.Write(json);
        //            streamWriter.Flush();
        //            streamWriter.Close();
        //        }
        //        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        //        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        //        {
        //            var result = streamReader.ReadToEnd();
        //            var obj = JObject.Parse(result);
        //            var resulf = obj["data"]["items"]; 
        //            return resulf.ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
    }
}