using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;
using GDK.DAL.SerMonitor;

namespace GDK.BCM.AlertAdmin
{
    public partial class HealthConfigList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dpdStationID.DataSource = new StationDA().selectAllStation();
                dpdStationID.DataTextField = "StationName";
                dpdStationID.DataValueField = "StationID";
                dpdStationID.DataBind();

                LoadData();
            }

        }
        private void ShowChannel()
        {
            DeviceDA m_DeviceTypedao = new DeviceDA();
            try
            {
                //string stationName = 

                rpDepartment.DataSource = m_DeviceTypedao.GetAllGenerdDevice(dpdStationID.SelectedItem.Value);
                rpDepartment.DataBind();
            }
            catch (Exception ex)
            {

                //comboBox1.Text = string.Empty;
                // MessageBox.Show(ex.ToString());
            }

        }

        private void LoadData()
        {
            ShowChannel();
        }

        protected void dpdStationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowChannel();
        }
    }
}