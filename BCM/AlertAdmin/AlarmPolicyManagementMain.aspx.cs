using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.SerMonitor;
using GDK.DAL.AlertAdmin;

namespace GDK.BCM.AlertAdmin
{
    public partial class AlarmPolicyManagementMain : PageBase
    {

        protected override void OnLoad(EventArgs e)
        {
            IsAuthenticate = false;
            base.OnLoad(e);
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }

        private void LoadData()
        {
            gvAlarmGroups.DataSource = new DeviceDA().SelectChannelByDeviceID(Request.QueryString["DeviceID"],
                    Request.QueryString["StationID"],
                    Request.QueryString["DeviceTypeID"]);
            gvAlarmGroups.DataBind();
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
            string strChanncelID = e.CommandArgument.ToString();
            if (e.CommandName == "deleteTS")
            {
                try
                {
                    new AlarmPolicyManagementDA().Delete(Request.QueryString["StationID"],
                        Request.QueryString["DeviceTypeID"],
                        Request.QueryString["DeviceID"],
                        strChanncelID);
                        LoadData();
                }
                catch(Exception ex)
                {
                    base.Alert(ex);
                }
                //if (!m_Rose.Delete(id))
                //{
                //    base.Alert("删除失败!");
                //}

                //BindGraid();
            }
        }
    }
}