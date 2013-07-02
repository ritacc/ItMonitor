using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;
using System.Data;

namespace GDK.BCM.Bussiness
{
    public partial class BussinessEdit : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

        BussinessDA BusDA = new BussinessDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            txtDeviceID.Text = Request.QueryString["GUID"];
            txtType.Text = Request.QueryString["type"];

            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
            {
                if (null != Session["ListPageIndexRoleList"])
                {
                    pg.PageIndex = Convert.ToInt32(Session["ListPageIndexRoleList"]);
                }

                
                BindGraid();
            }

        }
        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }

       

        private void BindGraid()
        {
            int pageCount = 0;
            DataTable dt = null;
            if (Request.QueryString["type"] == "top")
            {
              dt=  BusDA.GetTopBuss(pg.PageIndex,pg.PageSize, out pageCount);
            }
            this.gvDataList.DataSource = dt;
            gvDataList.DataBind();
        }

        protected void GView_LinkButton_Click(object sender, CommandEventArgs e)
        {
            // string loginUserId = base.CurrentUser.LogonName;
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "delete")
            {
                if (!BusDA.Delete(id))
                {
                    base.Alert("删除失败!");
                }
                BindGraid();
            }
        }

    }
}