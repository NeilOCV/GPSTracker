using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace GPSTracker.Pages
{
    public partial class DeviceStats : System.Web.UI.Page
    {
        private class DisplayGrid
        {
            public string setting { get; set; }
            public string value { get; set; }
        }
        private string CalculateTimeAgo(DateTime logDateTime)
        {
            string result = string.Empty;

            TimeSpan tsDays = DateTime.Now - logDateTime;
            int intDaysSpan = tsDays.Days;
            byte bytHours = (byte)tsDays.Hours;
            byte bytMinutes = (byte)tsDays.Minutes;
            byte bytSeconds = (byte)tsDays.Seconds;
            result = string.Format("{0:### ### ### ### ### ##0}", intDaysSpan).Trim() + " day(s), ";
            result += string.Format("{0:00}", bytHours).Trim() + " hour(s), ";
            result += string.Format("{0:00}", bytMinutes).Trim() + " minute(s) and ";
            result += string.Format("{0:00}", bytSeconds).Trim() + " seconds ago";

            return result;
        }
        private void LoadDevice(Int32 intDeviceID)
        {
            List<DisplayGrid> lst = new List<DisplayGrid>();

            DisplayGrid obj = new DisplayGrid();
            devices device = new devices();
            device = device.Read(intDeviceID);
            obj.setting = "Device ID";
            obj.value = device.id.ToString();
            lst.Add(obj);

            obj = new DisplayGrid();
            obj.setting = "Device URL name";
            obj.value = device.device_url_name.ToString();
            lst.Add(obj);

            obj = new DisplayGrid();
            obj.setting = "Device friendly name";
            obj.value = device.device_name.ToString();
            lst.Add(obj);

            obj = new DisplayGrid();
            obj.setting = "Device is retired";
            obj.value = device.device_retired.ToString();
            lst.Add(obj);

            transactions transactions = new DAL.transactions();
            transactions.transactions_stats stats = transactions.GetDisplayStats(intDeviceID);

            if (stats.SerialNumber != null)
            {
                obj = new DisplayGrid();
                obj.setting = "Serial number";
                obj.value = stats.SerialNumber;
                lst.Add(obj);
            }
            if (stats.AndroidID != null)
            {
                obj = new DisplayGrid();
                obj.setting = "Android ID";
                obj.value = stats.AndroidID;
                lst.Add(obj);
            }
            if (stats.FirstLog != null)
            {
                obj = new DisplayGrid();
                obj.setting = "First log date (time)";
                obj.value = string.Format("{0:dddd, d MMMM yyyy (H:mm:ss)}", stats.FirstLog);
                obj.value += " (" + CalculateTimeAgo(stats.FirstLog) + ")";
                lst.Add(obj);
            }
            if (stats.LastLog != null)
            {
                obj = new DisplayGrid();
                obj.setting = "Last log date (time)";
                obj.value = string.Format("{0:dddd, d MMMM yyyy (H:mm:ss)}", stats.LastLog);
                obj.value += " (" + CalculateTimeAgo(stats.LastLog) + ")";
                lst.Add(obj);
            }
            if (stats.TotalNumberOfLogs > 0)
            {
                obj = new DisplayGrid();
                obj.setting = "Total number of logs (all devices)";
                obj.value = (string.Format("{0:### ### ### ### ### ### ##0}", stats.TotalNumberOfLogs)).Trim();
                lst.Add(obj);
            }
            if (stats.NumberOfLogs > 0)
            {
                obj = new DisplayGrid();
                obj.setting = "Device logs (this device only)";
                obj.value = (string.Format("{0:### ### ### ### ### ### ##0}", stats.NumberOfLogs)).Trim();
                lst.Add(obj);
            }
            if (stats.LastLongitude > -1000)
            {
                obj = new DisplayGrid();
                obj.setting = "Longitude";
                obj.value = string.Format("{0:##0.0###########}", stats.LastLongitude).Trim();
                lst.Add(obj);
            }
            if (stats.LastLatitude > -1000)
            {
                obj = new DisplayGrid();
                obj.setting = "LastLatitude";
                obj.value = string.Format("{0:##0.0###########}", stats.LastLatitude).Trim();
                lst.Add(obj);
            }
            if (stats.Altitude > 0)
            {
                obj = new DisplayGrid();
                obj.setting = "Altitude";
                obj.value = string.Format("{0:### ##0}", stats.Altitude).Trim();
                lst.Add(obj);
            }
            if (stats.Speed > 0)
            {
                obj = new DisplayGrid();
                obj.setting = "Speed";
                obj.value = string.Format("{0:### ##0}", stats.Speed).Trim();
                lst.Add(obj);
            }
            if (stats.Accuracy > 0)
            {
                obj = new DisplayGrid();
                obj.setting = "Accuracy";
                obj.value = string.Format("{0:### ##0}", stats.Accuracy).Trim();
                lst.Add(obj);
            }
            if (stats.Direction > -1)
            {
                obj = new DisplayGrid();
                obj.setting = "Direction";
                obj.value = string.Format("{0:##0}", stats.Direction);
                lst.Add(obj);
            }
            if (stats.Provider != "")
            {
                obj = new DisplayGrid();
                obj.setting = "Location provider";
                obj.value = stats.Provider;
                lst.Add(obj);
            }
            if (stats.Time_UTC > DateTime.MinValue)
            {
                obj = new DisplayGrid();
                obj.setting = "Device local date(time)";
                obj.value = string.Format("{0:dddd, d MMMM yyyy (H:mm:ss)}", stats.Time_UTC);
                lst.Add(obj);
            }
            if (stats.Battery > -1)
            {
                obj = new DisplayGrid();
                obj.setting = "Battery";
                obj.value = string.Format("{0:##0}", stats.Battery) + "%";
                lst.Add(obj);
            }

            grdDetail.DataSource = lst;
            grdDetail.DataBind();
        }
        private void PageLoad()
        {
            if (Request.QueryString["id"] != null)
                if (Request.QueryString["id"].ToString() != "")
                    LoadDevice(Convert.ToInt32(Request.QueryString["id"].ToString()));
                else
                    Response.Redirect("/Default.aspx");
            else
                Response.Redirect("/Default.aspx");
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PageLoad();
        }
        //protected void Page_Load(object sender, EventArgs e)
        //{

        //}
    }
}