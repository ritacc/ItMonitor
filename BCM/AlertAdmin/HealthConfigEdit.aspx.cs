using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using GDK.Entity.AlertAdmin;
using GDK.DAL.AlertAdmin;
using GDK.DAL.Sys;
using GDK.DAL.SerMonitor;
using GDK.Entity.PerfMonitor;


namespace GDK.BCM.AlertAdmin
{
    public partial class HealthConfigEdit : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BoindStation();
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    LoadData();
            }
        }
        #region Dpd加载值
        private void BoindStation()
        {
            dpdStationID.DataSource = dpdStationID.DataSource = new StationDA().selectAllStation();
            dpdStationID.DataTextField = "StationName";
            dpdStationID.DataValueField = "StationID";
            dpdStationID.DataBind();

            dpdStationID_SelectedIndexChanged(null, null);
        }
        protected void dpdStationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpdStationID.SelectedItem == null)
                return;
            BindDeviceid(dpdStationID.SelectedItem.Value);
            dpdDeviceid_SelectedIndexChanged(null, null);
        }
        protected void dpdDeviceid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpdDeviceid.SelectedItem == null)
                return;
            BindChannel(dpdDeviceid.SelectedItem.Value);
        }
        private void BindDeviceid(string strID)
        {
            dpdDeviceid.DataSource = new DeviceDA().SelectDeviceByStationID(strID);
            dpdDeviceid.DataTextField = "deviceName";
            dpdDeviceid.DataValueField = "DeviceID";
            dpdDeviceid.DataBind();

            dpdDeviceid.Items.Insert(0,new ListItem("",""));
        }

        private void BindChannel(string strID)
        {
            dpdchannelno.DataSource = new DeviceDA().SelectChannelByDeviceID(strID);
            dpdchannelno.DataTextField = "ChannelName";
            dpdchannelno.DataValueField = "ChannelNo";
            dpdchannelno.DataBind();
            dpdchannelno.Items.Insert(0, new ListItem("", ""));
        }

        #endregion
        private void LoadData()
        {
            try
            {
                string m_id = Request.QueryString["id"];
                HealthConfigOR m_Heal = new HealthConfigDA().selectARowDate(m_id);
                DeviceOR m_DeviceOR = new DeviceDA().SelectDeviceORByID(m_Heal.Sdid.ToString());

                dpdStationID.SelectedValue = m_DeviceOR.StationID.ToString();//站点
                BindDeviceid(m_DeviceOR.StationID.ToString());

                dpdDeviceid.SelectedValue = m_Heal.Sdid.ToString();//
                BindChannel(m_Heal.Sdid.ToString());

                if (m_Heal.Channelno.HasValue)
                    dpdchannelno.SelectedValue = m_Heal.Channelno.Value.ToString();//

                txtEffectlevel.Text = m_Heal.Effectlevel.ToString();//
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }



        private HealthConfigOR SetValue()
        {
            HealthConfigOR m_Heal = new HealthConfigOR();
            if (Request.QueryString["opType"] == "alert")
            {
                m_Heal.ID = Request.QueryString["id"].ToString();
            }
            else
            {
                m_Heal.Deviceid = Convert.ToInt32(Request.QueryString["DeviceID"]);
            }

            m_Heal.Sdid =Convert.ToInt32( dpdDeviceid.SelectedValue);//

            if (!string.IsNullOrEmpty(dpdchannelno.SelectedValue))
            {
                m_Heal.Channelno = int.Parse(dpdchannelno.SelectedValue);//
            }

            m_Heal.Effectlevel = int.Parse(txtEffectlevel.Text);//

            return m_Heal;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            HealthConfigOR sg = SetValue();

            try
            {
                if (Request.QueryString["id"] == null)
                {
                    new HealthConfigDA().Insert(sg);
                }
                else
                {
                    new HealthConfigDA().Update(sg);
                }
                base.Close(true);
            }
            catch (Exception ex)
            {
                if (ex.Message.IndexOf("IX_t_HealthConfigIX") > 0)
                {
                    if (sg.Channelno.HasValue)
                    {
                        base.Alert("此设备、通道已配置！");
                    }
                    else
                    {
                        base.Alert("此设备已配置！");
                    }
                    return;
                }
                base.Alert(ex.Message);
            }
        }


    }
}
