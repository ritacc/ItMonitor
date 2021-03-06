﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;
using System.Data;

namespace GDK.BCM.Bussiness
{
	public partial class BussinessSelect : PageBase
    {
        public string AppName = string.Empty;
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

		protected void Page_Load(object sender, EventArgs e)
		{
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
            
            
		}

        public void BindGrid()
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            string type = Request.QueryString["type"];
            DataTable dt = null;
			switch (type)
            {
				case "top":
					dt = new BussinessDA().GetSelectTopBuss();
					break;
                case "host":
					dt = new BussinessDA().GetSelectSysLay(id, "(dt.typeid=1 or dt.typeid=9 )");
                    break;
                case "use":
					dt = new BussinessDA().GetSelectSysLay(id, 10);
                    break;
                case "web":
					dt = new BussinessDA().GetSelectSysLay(id, " (dt.typeid=2 or dt.typeid=3 )");
                    break;
                case "db":
					dt = new BussinessDA().GetSelectSysLay(id, 4);
                    break;
            }

            this.gvDataList.DataSource = dt;
            gvDataList.DataBind();
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
			try
			{
                if (txtValue.Text == "")
                {
                    Alert("请选择数据.");
                    return;
                }
				int id = Convert.ToInt32(txtValue.Text);
				int parentID = Convert.ToInt32(Request.QueryString["id"]);
				new BussinessDA().SaveBus(id, parentID);
				base.Close("tr");
			}
			catch (Exception ex)
			{
				base.Alert(ex);
			}
        }
	}
}