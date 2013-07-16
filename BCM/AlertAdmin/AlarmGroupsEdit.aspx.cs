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


namespace GDK.BCM.AlertAdmin
{
    public partial class AlarmGroupsEdit : PageBase
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                dpdStationID.DataSource = new StationDA().selectAllStation();
                dpdStationID.DataTextField = "StationName";
                dpdStationID.DataValueField = "StationID";
                dpdStationID.DataBind();

                if (Request.QueryString["id"] != null)
                    LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                AlarmGroupsOR m_Alar = new AlarmGroupsDA().selectARowDate(Request.QueryString["id"]);
                txtGroupname.Text = m_Alar.Groupname;//组名称
                dpdStationID.SelectedValue = m_Alar.Stationid.ToString();//站点ID

            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        private AlarmGroupsOR SetValue()
        {
            AlarmGroupsOR m_Alar = new AlarmGroupsOR();
            if (Request.QueryString["id"] != null)
                m_Alar.Alarmgroupsid = int.Parse(Request.QueryString["id"]);
            m_Alar.Groupname = txtGroupname.Text;//组名称
            m_Alar.Stationid = int.Parse(dpdStationID.SelectedItem.Value);//站点ID

            return m_Alar;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            if (dpdStationID.SelectedItem == null)
            {
                Alert("请选择站点!");
                return;
            }
            AlarmGroupsOR sg = SetValue();            

            try
            {
                if (Request.QueryString["id"] == null)
                {
			new AlarmGroupsDA().Insert(sg);
		}
		else
		{
			new AlarmGroupsDA().Update(sg);
		}
		base.Close("tr");
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }
    }
}
