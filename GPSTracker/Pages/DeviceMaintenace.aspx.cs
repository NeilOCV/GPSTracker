using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace GPSTracker.Pages
{
    public partial class DeviceMaintenace : System.Web.UI.Page
    {
        private void PopulateDDL()
        {
            devices devices = new devices();
            List<devices> List = devices.List();
            ddlDevices.DataTextField = "device_name";
            ddlDevices.DataValueField = "id";
            ddlDevices.DataSource = List;
            ddlDevices.DataBind();


            devices startupDevices=new devices();

            if (ddlDevices.Items.Count > 0)
                startupDevices = SelectDevice(Convert.ToInt32(ddlDevices.Items[0].Value));
        }
        private void PageLoad()
        {
            PopulateDDL();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                PageLoad();
        }
        private devices SelectDevice(int id)
        {
            devices devices = new devices();
            devices.Read(id);
            return devices;
        }
        protected void ddlDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            devices devices = SelectDevice(Convert.ToInt32(ddlDevices.SelectedItem.Value));

        }
    }
}