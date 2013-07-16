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
    public partial class AlarmLevelSetList : PageBase
    {
        private AlarmLevelSetDA m_Rose = new AlarmLevelSetDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                InitPage();
                BindGraid();
            }
        }

        private void InitPage()
        {
            //btnAdd.Visible = base.HasPermission("Admin");
            aBtnAdd.Visible = gvAlarmLevelSet.Columns[1].Visible = base.HasPermission("Edit");
            gvAlarmLevelSet.Columns[2].Visible = base.HasPermission("Delete");
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            int PageCount = 0;
            this.gvAlarmLevelSet.DataSource = new AlarmLevelSetDA().selectAllDateByWhere(this.pg.PageIndex, this.pg.PageSize, out PageCount, string.Empty); ;

            this.gvAlarmLevelSet.DataBind();
            this.pg.RecordCount = PageCount;
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
