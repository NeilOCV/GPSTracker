using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace GPSTracker
{
    public partial class Default : System.Web.UI.Page
    {
        
        
        
        
        private void PopulateGrid()
        {
            List<DisplayItems> lst = new List<DisplayItems>();
            EDM edm = new EDM();
            var prog = from tb in edm.GetLastOfEach()
                       select new DisplayItems
                       {
                           device_id = (int)tb.device_id,
                           log_date_time = tb.date_time.ToString(),
                           location_provider = tb.provider,
                           battery = (int)tb.battery,
                           device = tb.device_name,
                           latitude = (decimal)tb.latitude,
                           longitude = (decimal)tb.longitude
                       };
            lst = prog.ToList();
            grdLastLogs.DataSource = lst;
            grdLastLogs.DataBind();

            MapBuilder map = new MapBuilder();
            string strMap = string.Empty;
            strMap = map.BuildMap(MapType.AllMarkersOnly);
            litMapScript.Text = strMap;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGrid();
            }
        }
        private string CalculateTimeAgo(DateTime logDateTime)
        {
            string result = string.Empty;
            result += string.Format("{0:dddd, d MMMM yyyy (H:mm:ss)}", logDateTime);
            result += "  -  (";
            TimeSpan tsDays = DateTime.Now - logDateTime;
            int intDaysSpan = tsDays.Days;
            byte bytHours = (byte)tsDays.Hours;
            byte bytMinutes = (byte)tsDays.Minutes;
            byte bytSeconds = (byte)tsDays.Seconds;
            result += string.Format("{0:### ### ### ### ### ##0}", intDaysSpan).Trim() + ":";
            result += string.Format("{0:00}", bytHours).Trim() + ":";
            result += string.Format("{0:00}", bytMinutes).Trim() + ":";
            result += string.Format("{0:00}", bytSeconds).Trim() + " ago)";

            return result;
        }
        
        protected void grdLastLogs_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblID = (Label)e.Row.FindControl("lblID");
                Int32 intID = Convert.ToInt32(lblID.Text);
                HyperLink hlHistory = new HyperLink();
                hlHistory = (HyperLink)e.Row.FindControl("hlHistory");
                hlHistory.NavigateUrl = @"~/Pages/History.aspx?id=" + lblID.Text;

                HyperLink hlDevice = (HyperLink)e.Row.FindControl("hlDevice");
                hlDevice.NavigateUrl = @"~/Pages/DeviceStats.aspx?id=" + lblID.Text;

                Label lblLogDateTime = (Label)e.Row.FindControl("lblLogDateTime");
                DateTime dtLastLog = Convert.ToDateTime(lblLogDateTime.Text);
                lblLogDateTime.Text = CalculateTimeAgo(dtLastLog);

            }
        }
      
    }
}