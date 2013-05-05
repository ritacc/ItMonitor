using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.AlertAdmin;
using GDK.DAL.AlertAdmin;


namespace GDK.BCM.AlertAdmin
{
    public partial class HealthConfigMain : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

        private HealthConfigDA m_Rose = new HealthConfigDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                InitPage();
                BindGraid();
            }
        }

        private void InitPage()
        {
            //btnAdd.Visible = base.HasPermission("Admin");
            //aBtnAdd.Visible = gvHealthConfig.Columns[1].Visible = base.HasPermission("Edit");
            //gvHealthConfig.Columns[2].Visible = base.HasPermission("Delete");
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            string strID = Request.QueryString["DeviceID"].ToString();
            this.gvHealthConfig.DataSource = new HealthConfigDA().selectDataByDeviceID(strID);

            this.gvHealthConfig.DataBind();
            
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete")
            {
                if (!m_Rose.Delete(id))
                {
                    base.Alert("删除失败!");
                }
               
                BindGraid();
            }
        }
    }

}
