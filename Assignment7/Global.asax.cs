using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Assignment7
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //initialize counter variable
            Application["counter"] = 0;

            //initialize welcome message
            HttpContext.Current.Application["startupMessage"] = "Welcome! Today's date is " + DateTime.Today.ToString("MM/dd/yyyy");
        }
        void Application_End(object sender, EventArgs e)
        {

        }
        void Session_Start(object sender, EventArgs e)
        {
            //for each session incrememnt the counter
            Application["counter"] = (int)Application["counter"] + 1;
        }
    }
}