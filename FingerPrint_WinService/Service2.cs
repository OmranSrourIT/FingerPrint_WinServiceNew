using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace FingerPrint_WinService
{
    public partial class Service2 : ServiceBase
    {
        public Service2()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var config = new HttpSelfHostConfiguration("http://localhost:12300");
            config.EnableCors();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));

            config.MaxReceivedMessageSize = 2147483647; // use config for this value
             

            config.Routes.MapHttpRoute(
                name: "API",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { controller = "AFISHome", id = RouteParameter.Optional }
                );

            HttpSelfHostServer server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
             
            //WriteToFile("api http://localhost:1234 in done to calling" + DateTime.Now);

        }

        protected override void OnStop()
        {
        }
    }
}
