using System;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace _2018_12_13.HubProgress
{
    [Microsoft.AspNet.SignalR.Hubs.HubName("Hub")]
    public class Hub : Microsoft.AspNet.SignalR.Hub
    {
        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<Hub>();
        /// <summary>
        /// Gửi cho 1 user cụ thể, title và message
        /// </summary>
        /// <param name="jsonString"></param>
        public static void Send_Message_To_User(string jsonString)
        {
            hubContext.Clients.All.SendMessageClient_ToUser(jsonString);
        }
        /// <summary>
        /// App khách hàng gọi controller, controller gọi hub này. Truyền 1 chuỗi json
        /// </summary>
        /// <param name="jsonString"></param>
        public static void Send_Message_From_App(string jsonString)
        {
            hubContext.Clients.All.SendMessageClient_From_App(jsonString);
        }

        /// <summary>
        /// Nhận khi inbox từ facebook fanpage
        /// </summary>
        /// <param name="data"></param>
        public static void Facebook_ReceiptMessageFromFace(string data)
        {
            hubContext.Clients.All.ReceiptMessageFromFace(data);
        }
        /// <summary>
        /// Nhận khi comment từ facebook fanpage
        /// </summary>
        /// <param name="data"></param>
        /// <param name="commentid"></param>
        public static void Facebook_ReceiptCommentFromFace(string data, string commentid)
        {
            hubContext.Clients.All.ReceiptCommentFromFace(data, commentid);
        }
        /// <summary>
        /// Gửi cho Noti báo cho user
        /// </summary>
        /// <param name="jsonString"></param>
        public static void Send_Notier(string jsonString)
        {
            hubContext.Clients.All.Send_Notier_Client(jsonString);
        }
    }
}