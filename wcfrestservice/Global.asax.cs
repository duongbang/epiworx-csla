using System;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;

namespace Epiworx.WcfRestService
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            // Edit the base address of DataService by replacing the "DataService" string below
            RouteTable.Routes.Add(new ServiceRoute("DataService", new WebServiceHostFactory(), typeof(DataService)));
        }
    }
}
