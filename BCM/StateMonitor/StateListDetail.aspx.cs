using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.SerMonitor;
using GDK.Entity.PerfMonitor;

namespace GDK.BCM.StateMonitor
{
    public partial class StateListDetail : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitData();
            }
        }

        private void InitData()
        {
            string mDeviceID = Request.QueryString["id"];
            string mTypeid = Request.QueryString["typeid"];

            string url = string.Empty;
            switch (Convert.ToInt32(mTypeid))
            {
                case 1:
                    url = "../PerfMonitor/PerfHostDetail.aspx";
                    break;
                case 2://应用
                    url = "../PerfMonitor/PerfApplicationUrl.aspx";
                    break;
                case 3:
                    url = "../PerfMonitor/PerfApplicationUrl.aspx";
                    break;
                case 4://数据库
                    url = "../PerfMonitor/PerfDBIndex.aspx";
                    break;
                case 8://网络
                    url = "../PerfMonitor/PerfNetDetail.aspx";
                    break;
                case 9://虚拟机
                    url = "../PerfMonitor/PerfVirtualMachineDetail.aspx";
                    break;
                case 10://中间件
                    url = "../PerfMonitor/PerfMiddlewareDetail.aspx";
                    break;
                case 12://机房环境
                    url = "../StateMonitor/StateCompRoomEnviDetail.aspx";
                    break;
            }

            if (string.IsNullOrEmpty(url))
            {
                return;
            }
            
            Response.Redirect(string.Format("{0}?id={1}",url,mDeviceID));

          
        }

    }
}