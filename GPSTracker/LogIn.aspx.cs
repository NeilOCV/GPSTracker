using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace GPSTracker
{
    public partial class LogIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mpeLogIn.Show();
        }

        private bool ValidateUser(string strUserName, string strPassword)
        {
            if (strPassword == strUserName)
                return true;
            return false;
        }
        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            if(ValidateUser(txtUserName.Text,txtPassword.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(txtUserName.Text, chkRememberMe.Checked);
            }
            else
            {
                lblMessage.Visible = true;
            }
        }
    }
}