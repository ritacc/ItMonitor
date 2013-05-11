﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.StateMonitor;

namespace GDK.BCM.StateMonitor
{
    public partial class StateVirtualMachine : PageBase
    {

        protected override void OnPreLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnPreLoad(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            if (!IsPostBack)
                BindGraid();
        }
        protected void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }

        private void BindGraid()
        {
            string mWhere = string.Empty;
            if (!string.IsNullOrEmpty(txtValue.Text))
            {
                string filds = "dev.IP";
                if (rdbName.Checked)
                {
                    filds = "dev.DeviceName";
                }
                mWhere = string.Format(" {0} like '%{1}%'", filds, txtValue.Text);
            }
            try
            {
                int PageCount = 0;
                this.gvDataList.DataSource = new StateVirtualMachineDA()
                    .selectDeviceList(pg.PageIndex, pg.PageSize, out PageCount, mWhere);

                this.gvDataList.DataBind();
                this.pg.RecordCount = PageCount;
            }
            catch (Exception ex)
            {
                AlertNormal(ex.Message);
            }
        }
        
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindGraid();
        }
    }
}