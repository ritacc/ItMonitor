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
    public partial class HealthConfigEdit : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["id"]))
                    LoadData();
            }
        }

        private void LoadData()
        {
            try
            {
                string m_id = Request.QueryString["id"];
                HealthConfigOR m_Heal = new HealthConfigDA().selectARowDate(m_id);
                txtSdid.Text = m_Heal.Sdid.ToString();//
                txtPdid.Text = m_Heal.Pdid.ToString();//
                txtChannelno.Text = m_Heal.Channelno.ToString();//
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
                m_Heal.Sdid = Convert.ToInt32(Request.QueryString["id"]);
            m_Heal.Sdid = int.Parse(txtSdid.Text);//
            m_Heal.Pdid = int.Parse(txtPdid.Text);//
            m_Heal.Channelno = int.Parse(txtChannelno.Text);//
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
                base.Alert(ex.Message);
            }
        }


    }
}
