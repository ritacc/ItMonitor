using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using System.Data;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;

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
           DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);

           lblIP.Text = _Obj.IP;
           lblFirm.Text = _Obj.Firm;

           #region 绑定 可用性
           DataPoint dp = new DataPoint();
           dp.LegendText = string.Format("{0}({1}%)", "可用", _objDev.AvailableRate);
           double[] d = { Convert.ToDouble(_objDev.AvailableRate) };
           dp.Color = Color.Green;
           dp.YValues = d;
           chtPerf.Series["Series1"].Points.Add(dp);

           dp = new DataPoint();
           dp.LegendText = string.Format("{0}({1}%)", "不可用", 100 - _objDev.AvailableRate);
           double[] dno = { Convert.ToDouble(100 - _objDev.AvailableRate) };
           dp.Color = Color.Red;
           dp.YValues = dno;
           chtPerf.Series["Series1"].Points.Add(dp);
           #endregion

           //接口列表
           gvPortList.DataSource = _Obj.SubProts;
           gvPortList.DataBind();
        }
       
    }
}