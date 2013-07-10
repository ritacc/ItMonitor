using System;
using GDK.Entity.PerfMonitor;
using GDK.DAL.AlertAdmin;

namespace GDK.BCM.AlertAdmin
{
    public partial class PerfSystemFailureDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mDeviceID = Request.QueryString["id"];
            //DeviceItemOREx _objDev = new DeviceDA().SelectDeviceItemORExByID(mDeviceID);
            PerfNetAlarmOR _obj = new AlertDA().SelectErrorNews(mDeviceID);
            //switch (_objDev.Performance)
            //{
            //    case "正常":
            //        perf = "1";
            //        break;
            //    case "故障":
            //        perf = "0";
            //        break;
            //    case "报警":
            //        perf = "2";
            //        break;
            //    case "未启动":
            //        perf = "3";
            //        break;
            //}

            //lblName.Text = _objDev.DeviceName;
            //lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            //lblPerformance.Text = _objDev.Performance;
            if (_obj != null)
            {
                lblContent.Text = _obj.Content;
                lblHappenTime.Text = _obj.HappenTime.ToString();
            }
            else
            {
                return;
            }
        }
    }
}