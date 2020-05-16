using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
 
namespace _2018_12_13.Hubs
{
    public class ChatHub : Hub
    {
        public  void Send(string name, string message)
        {
            Clients.All.BroadcastMessage(name, message);
        }

        public static void SendMessage(string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
            hubContext.Clients.All.Send(msg, msg);
        }

        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();

        public void Hello()
        {
            Clients.All.hello();
        }

        public static void Facebook_PostingFromMessage(string data)
        {
            hubContext.Clients.All.Facebook_PostingFromMessage(data);
        }
        public static void Facebook_PostingFromComment(string data,string commentid)
        {
            hubContext.Clients.All.Facebook_PostingFromComment(data, commentid);
        }

        
    }

}