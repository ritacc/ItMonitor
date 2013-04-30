using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.Sys;

namespace GDK.BCM.Main
{
    public partial class SiteMain : System.Web.UI.MasterPage
    {
        PageBase _PageBase;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitPage();
                lblUserName.Text = _PageBase.UserName + "!";
            }
        }
        private void InitPage()
        {
            _PageBase = new PageBase();
            var query = _PageBase.Permissions.Where(p => p.MOD_LEVEL == 1 ).OrderBy(p => p.MOD_LEVEL);
            this.rptMenu0.DataSource = query;
            this.rptMenu0.DataBind();
        }

        protected IEnumerable<VHC_USER_PERMISSIONS> GetMenuLevel(object url)
        {
            var query = _PageBase.Permissions.Where(p => p.PARENT_URL == url.ToString()).OrderBy(p =>p.MOD_LEVEL);
            if (query.Any(p => p.IMAGE_PATH == "-"))
            {
                bool hasPrev = false;
                var list = query.ToList();
                foreach (VHC_USER_PERMISSIONS permissions in query)
                {
                    if (permissions.IMAGE_PATH == "-"
                        && !hasPrev)
                    {
                        list.Remove(permissions);
                    }
                    else if (permissions.IMAGE_PATH == "-")
                    {
                        hasPrev = false;
                    }
                    else
                    {
                        hasPrev = true;
                    }
                }

                int count = list.Count;
                if (count > 0)
                {
                    if (list[count - 1].IMAGE_PATH == "-")
                    {
                        list.RemoveAt(count - 1);
                    }
                }


                return list;
            }
            return query;
        }

        protected void ibtnLogout_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("~/Login.aspx");
        }
    }
}