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


namespace GDK.BCM.AlertAdmin
{
    public partial class AlarmLevelSetEdit : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                    LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                AlarmLevelSetOR m_Alar = new AlarmLevelSetDA().selectARowDate(Request.QueryString["id"]);
                dpdPriority.Text = m_Alar.Priority.ToString();//级别
                txtLevelname.Text = m_Alar.Levelname;//待级名称
                txtUpinterval.Text = m_Alar.Upinterval.ToString();//自动升级间隔时间

            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        private AlarmLevelSetOR SetValue()
        {
            AlarmLevelSetOR m_Alar = new AlarmLevelSetOR();
            if (Request.QueryString["id"] != null)
                m_Alar.Id = int.Parse(Request.QueryString["id"]);
            m_Alar.Priority = int.Parse(dpdPriority.Text);//级别
            m_Alar.Levelname = txtLevelname.Text;//待级名称
            m_Alar.Upinterval = int.Parse(txtUpinterval.Text);//自动升级间隔时间

            return m_Alar;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            AlarmLevelSetOR sg = SetValue();

            try
            {
                if (Request.QueryString["id"] == null)
                {
                    new AlarmLevelSetDA().Insert(sg);
                }
                else
                {
                    new AlarmLevelSetDA().Update(sg);
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
