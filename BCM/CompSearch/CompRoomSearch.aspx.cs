using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.SerMonitor;
using GDK.DAL.Sys;

namespace GDK.BCM.CompSearch
{
	public partial class CompRoomShearch : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				BoindStation();
			}
		}

		#region Dpd加载值
		private void BoindStation()
		{
			dpdStationID.DataSource = dpdStationID.DataSource = new StationDA().selectAllStation();
			dpdStationID.DataTextField = "StationName";
			dpdStationID.DataValueField = "StationID";
			dpdStationID.DataBind();

            dpdDeviceType.DataSource = dpdStationID.DataSource = new DeviceDA().GetAllDeviceType("");
            dpdDeviceType.DataValueField = "DeviceTypeID";
            dpdDeviceType.DataTextField = "TypeName";
            dpdDeviceType.DataBind();

			dpdStationID_SelectedIndexChanged(null, null);
		}

		protected void dpdStationID_SelectedIndexChanged(object sender, EventArgs e)
		{
            if (dpdStationID.SelectedItem == null || dpdDeviceType.SelectedItem == null)
				return;
            if (dpdStationID.SelectedValue == "" || dpdDeviceType.SelectedValue == "")
				return;

			BindDeviceid(dpdStationID.SelectedItem.Value,dpdDeviceType.SelectedItem.Value);
			dpdDeviceid_SelectedIndexChanged(null, null);
		}
		protected void dpdDeviceid_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (dpdDeviceid.SelectedItem == null)
				return;
			BindChannel(dpdDeviceid.SelectedItem.Value);
		}
		private void BindDeviceid(string strID,string strTypeid)
		{
            dpdDeviceid.DataSource = new DeviceDA().GetAllGenerdDevice(strID, strTypeid);
			dpdDeviceid.DataTextField = "deviceName";
			dpdDeviceid.DataValueField = "DeviceID";
			dpdDeviceid.DataBind();

            dpdDeviceid.Items.Insert(0, new ListItem("===="));
		}

		private void BindChannel(string strID)
		{
			dpdchannelno.DataSource = new DeviceDA().SelectChannelByDeviceID(strID);
			dpdchannelno.DataTextField = "ChannelName";
			dpdchannelno.DataValueField = "ChannelNo";
			dpdchannelno.DataBind();
            dpdchannelno.Items.Insert(0, new ListItem("===="));
		}

		#endregion
		

	}
}