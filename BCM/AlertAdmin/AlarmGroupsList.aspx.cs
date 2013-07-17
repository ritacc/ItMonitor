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
    public partial class AlarmGroupsList : PageBase
    {
        private AlarmGroupsDA m_Rose = new AlarmGroupsDA();
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
            aBtnAdd.Visible = gvAlarmGroups.Columns[1].Visible = base.HasPermission("Edit");
            gvAlarmGroups.Columns[2].Visible = base.HasPermission("Delete");
        }

        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();/*加查询条件string.Empty*/
        }

        private void BindGraid()
        {
            int PageCount = 0;
            this.gvAlarmGroups.DataSource = new AlarmGroupsDA().selectAllDateByWhere(this.pg.PageIndex, this.pg.PageSize, out PageCount, string.Empty); ;

            this.gvAlarmGroups.DataBind();
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
