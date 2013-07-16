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
    public partial class DisarmTimeEdit : PageBase
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
                           DisarmTimeOR m_Disa = new DisarmTimeDA().selectARowDate(Request.QueryString["id"]);
        txtDisarmname.Text = m_Disa.Disarmname;//撤防名称
        txtDisarmstarttime.Text = m_Disa.Disarmstarttime;//撤防开始时间
        txtDisarmendtime.Text = m_Disa.Disarmendtime;//撤防结束时间

            }
            catch (Exception e)
            {
                Alert(e);
            }
        }

        private DisarmTimeOR SetValue()
        {
            DisarmTimeOR m_Disa = new DisarmTimeOR();            
            if (Request.QueryString["id"] != null)
                m_Disa.Disarmid =int.Parse(Request.QueryString["id"]);
        m_Disa.Disarmname = txtDisarmname.Text;//撤防名称
        m_Disa.Disarmstarttime = txtDisarmstarttime.Text;//撤防开始时间
        m_Disa.Disarmendtime = txtDisarmendtime.Text;//撤防结束时间

return m_Disa;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            DisarmTimeOR sg = SetValue();            

            try
            {
                if (Request.QueryString["id"] == null)
                {
			new DisarmTimeDA().Insert(sg);
		}
		else
		{
			new DisarmTimeDA().Update(sg);
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
