using System;

namespace GPSTracker.UserControls
{
    public partial class BatteryGauge : System.Web.UI.UserControl
    {
        private Int32 _BatteryCharge = 0;
        public Int32 BatteryCharge 
        {
            get
            {
                return _BatteryCharge;
            }
            set
            {
                _BatteryCharge = value;
                pnlValuePanel.Width = value;
                if ((value > 0) && (value < 25))
                    pnlValuePanel.CssClass = "ValuePanel Above0";
                if ((value > 24) && (value < 50))
                    pnlValuePanel.CssClass = "ValuePanel Above25";
                if ((value > 49) && (value < 75))
                    pnlValuePanel.CssClass = "ValuePanel Above50";
                if (value > 74)
                    pnlValuePanel.CssClass = "ValuePanel Above75";

                lblCharge.Text = value.ToString() + "%";
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}