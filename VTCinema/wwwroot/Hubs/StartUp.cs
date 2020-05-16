using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
[assembly: OwinStartup(typeof(_2018_12_13.Hubs.StartUp))]
namespace _2018_12_13.Hubs
{
    public class StartUp
    {
        public void Configuration(IAppBuilder app)
        {
            //IoC container registration process
            //UnityConfig.RegisterComponents();

            //UnityConfig.Container.RegisterType<AHub, AHub>();

            //HubConfiguration config = new HubConfiguration();
            //config.EnableJavaScriptProxies = true;

           app.MapSignalR();
            //Here your SignalR dependency resolver
          

        }
    }
}