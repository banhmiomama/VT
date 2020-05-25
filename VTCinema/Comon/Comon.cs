using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace VTCinema.Comon
{
    public static class Comon
    {
        public static string DMY_To_YMD(string date)
        {
            try
            {
                if (date == "") return "";
                date = date.Trim();
                string[] A = date.Split(' ');
                string[] B = A[0].Split('-');
                return B[2] + "-" + B[1] + "-" + B[0];
            }
            catch (Exception ex)
            {
                return "";
            }


        }
        //public static List<string> GetAllDirectoryInFolder(string directory)
        //{
        //    try
        //    {
        //        FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(Global.sys_ServerImageFolder + directory);
        //        ftpRequest.Credentials = new NetworkCredential(Global.sys_ServerImageUserName, Global.sys_ServerImagePassword);
        //        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
        //        FtpWebResponse response = (FtpWebResponse)ftpRequest.GetResponse();
        //        StreamReader streamReader = new StreamReader(response.GetResponseStream());
        //        List<string> directories = new List<string>();
        //        string line = streamReader.ReadLine();
        //        while (!string.IsNullOrEmpty(line))
        //        {
        //            directories.Add(line);
        //            line = streamReader.ReadLine();
        //        }

        //        streamReader.Close();
        //        return directories;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        //public static bool CheckDirectoryFTP(string customer, string directory)
        //{
        //    List<string> currrentdirectories = GetAllDirectoryInFolder(customer);
        //    // Chua co folder customer
        //    if (currrentdirectories == null)
        //    {
        //        CreateDirectoryFTP(customer);
        //        currrentdirectories = GetAllDirectoryInFolder(customer);
        //    }
        //    // Co roi nhung chua co 1 folder hinh anh nao
        //    if (currrentdirectories.Count == 0)
        //    {
        //        CreateDirectoryFTP(customer + "/" + directory);
        //        return true;
        //    }
        //    else
        //    {
        //        bool resulf = false;
        //        foreach (var dr in currrentdirectories)
        //        {
        //            if (dr == directory)
        //                resulf = true;
        //        }
        //        if (resulf) return false; // Trung folder
        //        else
        //        {
        //            CreateDirectoryFTP(customer + "/" + directory);
        //            return true;
        //        }
        //    }
        //}
        //public static bool CreateDirectoryFTP(string directory)
        //{
        //    WebRequest request = WebRequest.Create(Global.sys_ServerImageFolder + directory);
        //    request.Method = WebRequestMethods.Ftp.MakeDirectory;
        //    request.Credentials = new NetworkCredential(Global.sys_ServerImageUserName, Global.sys_ServerImagePassword);
        //    try
        //    {
        //        request.GetResponse();
        //        return true;
        //    }
        //    catch (Exception e)
        //    {
        //        return false;
        //    }
        //}

        //private static bool MoveDetailFolder(string CurrentFolder, string dicfrom, string dicto)
        //{
        //    // Tao folder truoc, Kiem tra dicto da co folder hinh anh chua
        //    try
        //    {
        //        string newFolder = CurrentFolder + "(M)";
        //        CheckDirectoryFTP(dicto, newFolder);
        //        List<string> allimage = GetAllDirectoryInFolder(dicfrom + "/" + CurrentFolder);
        //        if (allimage != null && allimage.Count > 0)
        //        {
        //            foreach (var im in allimage)
        //            {
        //                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(Global.sys_ServerImageFolder + dicfrom + '/' + CurrentFolder + '/' + im.ToString());
        //                request.Credentials = new NetworkCredential(Global.sys_ServerImageUserName, Global.sys_ServerImagePassword);
        //                request.Method = WebRequestMethods.Ftp.DownloadFile;

        //                using (Stream ftpStream = request.GetResponse().GetResponseStream())
        //                {
        //                    if (UploadStream(ftpStream, Global.sys_ServerImageFolder + dicto + '/' + newFolder + '/' + im.ToString()))
        //                    {
        //                        DeleteFile(Global.sys_ServerImageFolder + dicfrom + '/' + CurrentFolder + '/' + im.ToString());
        //                    }
        //                }
        //            }
        //        }
        //        return true;
        //    }

        //    catch (Exception ex)
        //    {
        //        return false;
        //    }



        //}
        //public static decimal MathRoundMoney(double number)
        //{
        //    if (number >= 0 && number <= 100)
        //    {
        //        number = Math.Round(number);
        //    }
        //    else if (number > 100 && number <= 10000)
        //    {
        //        number = Math.Round(number / 100) * 100;
        //    }
        //    else if (number > 10000)
        //    {
        //        number = Math.Round(number / 1000) * 1000;
        //    }
        //    return (decimal)number;
        //}
        //private static bool DeleteFolder(string des)
        //{
        //    try
        //    {
        //        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(des);
        //        request.Method = WebRequestMethods.Ftp.RemoveDirectory;
        //        request.Credentials = new NetworkCredential(Global.sys_ServerImageUserName, Global.sys_ServerImagePassword);
        //        request.GetResponse().Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public static bool DeleteFile(string des)
        //{
        //    try
        //    {
        //        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(des);
        //        request.Credentials = new NetworkCredential(Global.sys_ServerImageUserName, Global.sys_ServerImagePassword);

        //        request.Method = WebRequestMethods.Ftp.DeleteFile;
        //        FtpWebResponse response = (FtpWebResponse)request.GetResponse();
        //        Console.WriteLine("Delete status: {0}", response.StatusDescription);
        //        response.Close();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        private static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        //private static bool UploadStream(Stream stream, string des)
        //{
        //    try
        //    {
        //        FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(des);
        //        request.Method = WebRequestMethods.Ftp.UploadFile;
        //        request.Credentials = new NetworkCredential(Global.sys_ServerImageUserName, Global.sys_ServerImagePassword);
        //        request.UsePassive = true;
        //        request.UseBinary = true;
        //        request.KeepAlive = false;
        //        byte[] fileContents = ReadFully(stream);


        //        request.ContentLength = fileContents.Length;

        //        using (Stream requestStream = request.GetRequestStream())
        //        {
        //            requestStream.Write(fileContents, 0, fileContents.Length);
        //        }

        //        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        //        {
        //            Console.WriteLine($"Upload File Complete, status {response.StatusDescription}");
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }

        //}
        //public static bool MoveFolder(string dicFrom, string dicTo)
        //{
        //    try
        //    {
        //        List<string> currrentdirectories = GetAllDirectoryInFolder(dicFrom);
        //        // Csutomer From khong co hinh anh
        //        if (currrentdirectories == null)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            // Co roi nhung chua co 1 folder hinh anh nao
        //            if (currrentdirectories.Count == 0)
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                foreach (var dr in currrentdirectories)
        //                {
        //                    if (MoveDetailFolder(dr.ToString(), dicFrom, dicTo))
        //                    {
        //                        DeleteFolder(Global.sys_ServerImageFolder + dicFrom + '/' + dr.ToString());
        //                    }
        //                }

        //            }
        //        }
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}
        //// customer + foldername
        //public static List<string> GetImageFromDirectory(string directory)
        //{
        //    List<string> stringName = new List<string>();
        //    stringName = GetAllDirectoryInFolder(directory);
        //    if (stringName == null)
        //    {
        //        return null;
        //    }
        //    for (int i = 0; i < stringName.Count; i++)
        //    {
        //        stringName[i] = String.Format(@"{0}{1}/{2}", Global.sys_HTTPImageRoot, directory, stringName[i]);
        //    }
        //    return stringName;
        //}
        //public static DateTime GetDateTimeNow()
        //{
        //    return DateTime.Now;
        //}
        public static string UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            try
            {
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                dtDateTime = dtDateTime.AddMilliseconds(unixTimeStamp).ToLocalTime();
                return dtDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            }
            catch (Exception ex)
            {
                return "";
            }

        }
        public static string ConvertToUnsign(string str)
        {
            str = str.Replace("'", "");
            string[] signs = new string[]
                {
                    "aAeEoOuUiIdDyY",
                    "áàạảãâấầậẩẫăắằặẳẵ",
                    "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
                    "éèẹẻẽêếềệểễ",
                    "ÉÈẸẺẼÊẾỀỆỂỄ",
                    "óòọỏõôốồộổỗơớờợởỡ",
                    "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
                    "úùụủũưứừựửữ",
                    "ÚÙỤỦŨƯỨỪỰỬỮ",
                    "íìịỉĩ",
                    "ÍÌỊỈĨ",
                    "đ",
                    "Đ",
                    "ýỳỵỷỹ",
                    "ÝỲỴỶỸ"
                };
            for (int i = 1; i < signs.Length; i++)
            {
                for (int j = 0; j < signs[i].Length; j++)
                {
                    str = str.Replace(signs[i][j], signs[0][i - 1]);
                }
            }
            return str;
        }

        // COnvert Image Format
        public static Stream ConvertImage(Stream originalStream, ImageFormat format)
        {
            var image = Image.FromStream(originalStream);
            var stream = new MemoryStream();
            image.Save(stream, format);
            stream.Position = 0;
            return stream;
        }
        // Resize Image
        public static string ResizeImage(byte[] byteArrayIn, int width, int height)
        {
            using (var ms = new MemoryStream(byteArrayIn))
            {
                Image image = Image.FromStream(ms);
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
                Bitmap bImage = destImage;
                System.IO.MemoryStream ms1 = new MemoryStream();
                bImage.Save(ms1, ImageFormat.Jpeg);
                byte[] byteImage = ms1.ToArray();
                var SigBase64 = Convert.ToBase64String(byteImage);
                return SigBase64;
            }
        }
        #region // Convert Num to String ( Money)
        private static string ConvertChu(string gNumber)
        {
            string result = "";
            switch (gNumber)
            {
                case "0":
                    result = "Không";
                    break;
                case "1":
                    result = "Một";
                    break;
                case "2":
                    result = "Hai";
                    break;
                case "3":
                    result = "Ba";
                    break;
                case "4":
                    result = "Bốn";
                    break;
                case "5":
                    result = "Năm";
                    break;
                case "6":
                    result = "Sáu";
                    break;
                case "7":
                    result = "Bảy";
                    break;
                case "8":
                    result = "Tám";
                    break;
                case "9":
                    result = "Chín";
                    break;
            }
            return result;
        }

        private static string ConvertDonvi(string so)
        {
            string Kdonvi = "";

            if (so.Equals("1"))
                Kdonvi = "";
            if (so.Equals("2"))
                Kdonvi = "nghìn";
            if (so.Equals("3"))
                Kdonvi = "triệu";
            if (so.Equals("4"))
                Kdonvi = "tỷ";
            if (so.Equals("5"))
                Kdonvi = "nghìn tỷ";
            if (so.Equals("6"))
                Kdonvi = "triệu tỷ";
            if (so.Equals("7"))
                Kdonvi = "tỷ tỷ";

            return Kdonvi;
        }

        private static string ConvertTach(string tach3)
        {
            string Ktach = "";
            if (tach3.Equals("000"))
                return "";
            if (tach3.Length == 3)
            {
                string tr = tach3.Trim().Substring(0, 1).ToString().Trim();
                string ch = tach3.Trim().Substring(1, 1).ToString().Trim();
                string dv = tach3.Trim().Substring(2, 1).ToString().Trim();
                if (tr.Equals("0") && ch.Equals("0"))
                    Ktach = " không trăm lẻ " + ConvertChu(dv.ToString().Trim()) + " ";
                if (!tr.Equals("0") && ch.Equals("0") && dv.Equals("0"))
                    Ktach = ConvertChu(tr.ToString().Trim()).Trim() + " trăm ";
                if (!tr.Equals("0") && ch.Equals("0") && !dv.Equals("0"))
                    Ktach = ConvertChu(tr.ToString().Trim()).Trim() + " trăm lẻ " + ConvertChu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm " + ConvertChu(ch.Trim()).Trim() + " mươi " + ConvertChu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = " không trăm " + ConvertChu(ch.Trim()).Trim() + " mươi ";
                if (tr.Equals("0") && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = " không trăm " + ConvertChu(ch.Trim()).Trim() + " mươi lăm ";
                if (tr.Equals("0") && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = " không trăm mười " + ConvertChu(dv.Trim()).Trim() + " ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("0"))
                    Ktach = " không trăm mười ";
                if (tr.Equals("0") && ch.Equals("1") && dv.Equals("5"))
                    Ktach = " không trăm mười lăm ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = ConvertChu(tr.Trim()).Trim() + " trăm " + ConvertChu(ch.Trim()).Trim() + " mươi " + ConvertChu(dv.Trim()).Trim() + " ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("0"))
                    Ktach = ConvertChu(tr.Trim()).Trim() + " trăm " + ConvertChu(ch.Trim()).Trim() + " mươi ";
                if (Convert.ToInt32(tr) > 0 && Convert.ToInt32(ch) > 1 && dv.Equals("5"))
                    Ktach = ConvertChu(tr.Trim()).Trim() + " trăm " + ConvertChu(ch.Trim()).Trim() + " mươi lăm ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && Convert.ToInt32(dv) > 0 && !dv.Equals("5"))
                    Ktach = ConvertChu(tr.Trim()).Trim() + " trăm mười " + ConvertChu(dv.Trim()).Trim() + " ";

                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("0"))
                    Ktach = ConvertChu(tr.Trim()).Trim() + " trăm mười ";
                if (Convert.ToInt32(tr) > 0 && ch.Equals("1") && dv.Equals("5"))
                    Ktach = ConvertChu(tr.Trim()).Trim() + " trăm mười lăm ";

            }

            return Ktach;

        }

        public static string ConvertNumToString(double gNum)
        {
            if (gNum == 0)
                return "Không đồng";

            string lso_chu = "";
            string tach_mod = "";
            string tach_conlai = "";
            double Num = Math.Round(gNum, 0);
            string gN = Convert.ToString(Num);
            int m = Convert.ToInt32(gN.Length / 3);
            int mod = gN.Length - m * 3;
            string dau = "[+]";

            // Dau [+ , - ]
            if (gNum < 0)
                dau = "[-]";
            dau = "";

            // Tach hang lon nhat
            if (mod.Equals(1))
                tach_mod = "00" + Convert.ToString(Num.ToString().Trim().Substring(0, 1)).Trim();
            if (mod.Equals(2))
                tach_mod = "0" + Convert.ToString(Num.ToString().Trim().Substring(0, 2)).Trim();
            if (mod.Equals(0))
                tach_mod = "000";
            // Tach hang con lai sau mod :
            if (Num.ToString().Length > 2)
                tach_conlai = Convert.ToString(Num.ToString().Trim().Substring(mod, Num.ToString().Length - mod)).Trim();

            ///don vi hang mod
            int im = m + 1;
            if (mod > 0)
                lso_chu = ConvertTach(tach_mod).ToString().Trim() + " " + ConvertDonvi(im.ToString().Trim());
            /// Tach 3 trong tach_conlai

            int i = m;
            int _m = m;
            int j = 1;
            string tach3 = "";
            string tach3_ = "";

            while (i > 0)
            {
                tach3 = tach_conlai.Trim().Substring(0, 3).Trim();
                tach3_ = tach3;
                lso_chu = lso_chu.Trim() + " " + ConvertTach(tach3.Trim()).Trim();
                m = _m + 1 - j;
                if (!tach3_.Equals("000"))
                    lso_chu = lso_chu.Trim() + " " + ConvertDonvi(m.ToString().Trim()).Trim();
                tach_conlai = tach_conlai.Trim().Substring(3, tach_conlai.Trim().Length - 3);

                i = i - 1;
                j = j + 1;
            }
            if (lso_chu.Trim().Substring(0, 1).Equals("k"))
                lso_chu = lso_chu.Trim().Substring(10, lso_chu.Trim().Length - 10).Trim();
            if (lso_chu.Trim().Substring(0, 1).Equals("l"))
                lso_chu = lso_chu.Trim().Substring(2, lso_chu.Trim().Length - 2).Trim();
            if (lso_chu.Trim().Length > 0)
                lso_chu = dau.Trim() + " " + lso_chu.Trim().Substring(0, 1).Trim().ToUpper() + lso_chu.Trim().Substring(1, lso_chu.Trim().Length - 1).Trim() + " đồng.";

            return lso_chu.ToString().Trim().Replace("mươi Một", "mươi mốt");

        }
        #endregion

        public static System.Data.DataTable GetControlPermissionByGroup(System.Data.DataTable dt, string groupID)
        {
            try
            {
                System.Data.DataRow[] dr = dt.Select("PermissionGroupID=" + groupID);
                return null; // dr.CopyToDataTable();
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool CheckPreventCusByBranch(int cusBranchID)
        {

            //GlobalUser user = (GlobalUser)HttpContext.Session.Get["CurrentUserInfo"];
            //if (user.sys_AllBranchID == 1) return true;
            //if (Global.sys_PreventCusByBranch == 0) return true;
            //else
            //{
            //    if (user.sys_branchID == cusBranchID) return true;
            //    return false;
            //}
            return true;
        }
        public static bool CheckLimitUpLoad()
        {
            try
            {
                //GlobalUser user = (GlobalUser)HttpContext.Current.Session["CurrentUserInfo"];
                //if (user.sys_isLimit == 0) return true;
                //DataTable dt = new DataTable();
                //using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                //{
                //    dt = confunc.ExecuteDataTable("[YYY_sp_CheckLimitBranch_UpLoad]", CommandType.StoredProcedure,
                //      "@BranchID", SqlDbType.Int, user.sys_branchID);
                //}
                //if (dt != null && dt.Rows.Count != 0)
                //{
                //    if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //else
                //{
                //    return true;
                //}
                return true;
            }
            catch (Exception ex)
            {
                return true;
            }


        }
        public static bool CheckLimitSMS()
        {
            try
            {
                //GlobalUser user = (GlobalUser)HttpContext.Current.Session["CurrentUserInfo"];
                //if (user.sys_isLimit == 0) return true;
                //DataTable dt = new DataTable();
                //using (Models.ExecuteDataBase confunc = new Models.ExecuteDataBase())
                //{
                //    dt = confunc.ExecuteDataTable("[YYY_sp_CheckLimitBranch_SMS]", CommandType.StoredProcedure,
                //      "@BranchID", SqlDbType.Int, user.sys_branchID);
                //}
                //if (dt != null && dt.Rows.Count != 0)
                //{
                //    if (Convert.ToInt32(dt.Rows[0][0].ToString()) > 0)
                //    {
                //        return true;
                //    }
                //    else
                //    {
                //        return false;
                //    }
                //}
                //else
                //{
                //    return true;
                //}

                return true;
            }
            catch (Exception ex)
            {
                return true;
            }


        }
        public static string Readfile(string link)
        {
            try
            {
                string content = "";
                WebClient client = new WebClient();
                using (Stream stream = client.OpenRead(link))
                {
                    StreamReader reader = new StreamReader(stream);
                    content = reader.ReadToEnd();

                }
                return content;

            }
            catch (Exception ex)
            {
                return "";
            }
        }        
    }
}