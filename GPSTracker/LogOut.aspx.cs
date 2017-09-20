using System;

namespace GPSTracker
{
    public partial class LogOur : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            Response.Redirect(@"~/Default.aspx");
        }
    }
}