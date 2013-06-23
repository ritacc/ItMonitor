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
        public int deviceID = 0;
        public string perf = "0";
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack) {
                InitData();
            }
        }

        private void InitData()
        {
            string mDeviceID= Request.QueryString["id"];
            PerfNetDetailOR _Obj = new PerfNetDA().SelectDeviceDetail(mDeviceID);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);            
            switch (_objDev.Performance)
            {
                case "正常":
                    perf = "0";
                    break;
                case "故障":
                    perf = "1";
                    break;
                case "报警":
                    perf = "2";
                    break;
                case "未启动":
                    perf = "3";
                    break;
            }
            lblClass.Text = _objDevEx.ClassName;
            lblType.Text = _objDevEx.TypeName;

            lblDeviceName.Text = _objDev.DeviceName;

            lblIP.Text = _objDev.IP;
            lblFirm.Text = _Obj.Firm;
            lblFlowCalculator.Text = _Obj.FlowCalculator;
            lblDependence.Text = _Obj.Dependence;
            lblPollingProtocol.Text = _Obj.PollingProtocol;
            lblMonitor.Text = _Obj.Monitor;
            lblSystemDescription.Text = _objDev.Describe;
            lblResponseTime.Text = _Obj.ResponseTime;
            lblPacketLossRate.Text = _Obj.LoseRate;

            #region 绑定 今天的使用率
            DataPoint dp = new DataPoint();
            dp.LegendText = string.Format("{0}({1}%)", "今天的使用率", _Obj.NetUtilityRate);
            double[] d = { Convert.ToDouble(_Obj.NetUtilityRate) };
            dp.Color = Color.Green;
            dp.YValues = d;
            chtPerf.Series["Series1"].Points.Add(dp);

            dp = new DataPoint();
            dp.LegendText = string.Format("{0}({1}%)", "今天的未使用率", 100 - _Obj.NetUtilityRate);
            double[] dno = { Convert.ToDouble(100 - _Obj.NetUtilityRate) };
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