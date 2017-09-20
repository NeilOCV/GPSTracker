using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GPSTracker.Pages
{
    public partial class History : System.Web.UI.Page
    {
        private void PageLoad()
        {
            if (ceHistoryDate.SelectedDate == null)
                ceHistoryDate.SelectedDate = Convert.ToDateTime("18 April 1971");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PageLoad();
        }

        protected void txtHistoryDate_TextChanged(object sender, EventArgs e)
        {
            string s = "S";
        }

        
    }
}