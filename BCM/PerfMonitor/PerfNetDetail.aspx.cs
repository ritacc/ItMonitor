using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.BCM.PerfMonitor
{
    public partial class NetDetail : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                InitData();
            }
        }

        private void InitData()
        {
           string mDeviceID= Request.QueryString["id"];
           PerfNetDetailOR _Obj = new PerfNetDA().SelectDeviceDetail(mDeviceID);
           lblIP.Text = _Obj.IP;
           lblFirm.Text = _Obj.Firm;

           gvPortList.DataSource = _Obj.SubProts;
           gvPortList.DataBind();
        }
       
    }
}