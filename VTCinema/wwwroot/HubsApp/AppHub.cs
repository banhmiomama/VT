using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;

namespace _2018_12_13.HubsApp
{
    [Microsoft.AspNet.SignalR.Hubs.HubName("AppHub")]
    public class AppHub : Hub
    {
        //public void Send(string name, string message)
        //{
        //    Clients.All.broadcastMessage(name, message);
        //}
        //public static void SendMessage(string name, string message)
        //{
        //    var hubContext = GlobalHost.ConnectionManager.GetHubContext<ChatHub>();
        //    hubContext.Clients.All.broadcastMessage(name, message);
        //}

        public  void Send(string name, string message)
        {
            Clients.All.BroadcastMessage(name, message);
        }

        public static void SendMessage(string msg)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<AppHub>();
            hubContext.Clients.All.Send(msg, msg);
        }

        private static IHubContext hubContext = GlobalHost.ConnectionManager.GetHubContext<AppHub>();

        public void Hello()
        {
            Clients.All.hello();
        }

        public static void SayHello(string prams)
        {
            hubContext.Clients.All.hello(prams);
        }
    }

}