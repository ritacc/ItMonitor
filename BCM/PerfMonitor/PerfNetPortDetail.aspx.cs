using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.PerfMonitor;
using GDK.DAL.PerfMonitor;
using GDK.DAL.SerMonitor;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;


namespace GDK.BCM.PerfMonitor
{
    public partial class PerfNetPortDetail : PageBase
    {
        public int deviceID = 0;
        public string health = "0";
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        public string Performance = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                InitData();
            }
        }
        private void InitData()
        {
            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            PerNetPortDetailOR _Obj = new PerfNetDA().SelectNetPortDetail(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);
            Performance = _objDev.Performance;
            switch (_objDevEx.HealthStatus)
            {
                case "正常":
                    health = "1";
                    break;
                case "故障":
                    health = "0";
                    break;
                case "报警":
                    health = "2";
                    break;
            }
            lblPort.Text = _objDev.Port;
            lblIpAddresses.Text = _objDev.IP;
            lblDescription.Text = _objDev.Describe;
            lblName.Text = _objDev.DeviceName;
            lblCircuitID.Text = _Obj.CircuitID;
            lblSuperiorName.Text = _Obj.SuperiorName;
            lblIndex.Text = _Obj.Index;
            lblPhysicalAddress.Text = _objDev.StationName;
            lblType.Text = _objDevEx.TypeName;
            lblManagementState.Text = _Obj.ManagementState;
            lblOperatingStatus.Text = _Obj.OperatingStatus;

            lblReceiveBroadband.Text = _Obj.ReceiveBroadband;
            lblSendBroadband.Text = _Obj.SendBroadband;
            lblCurrentlyReceivingTraffic.Text = _Obj.CurrentlyReceivingTraffic;
            lblCurrentSendTraffic.Text = _Obj.CurrentSendTraffic;
            lblReceiveUtilization.Text = _Obj.UtilizationReceive;
            lblSendUtilization.Text = _Obj.UtilizationSend;
            lblReceivePacketsNumber.Text = _Obj.ReceiveNoS;
            lblSendPacketsNumber.Text = _Obj.SendNos;
            lblReceiveAverageSize.Text = _Obj.AverageSizeReceive;
            lblSendAverageSize.Text = _Obj.AverageSizeSend;


            #region 绑定 可用性
            DataPoint dp = new DataPoint();
            dp.LegendText = string.Format("{0}({1}%)", "可用", _objDevEx.AvailableRate);
            double[] d = { Convert.ToDouble(_objDevEx.AvailableRate) };
            dp.Color = Color.Green;
            dp.YValues = d;
            chtPerf.Series["Series1"].Points.Add(dp);

            dp = new DataPoint();
            dp.LegendText = string.Format("{0}({1}%)", "不可用", 100 - _objDevEx.AvailableRate);
            double[] dno = { Convert.ToDouble(100 - _objDevEx.AvailableRate) };
            dp.Color = Color.Red;
            dp.YValues = dno;
            chtPerf.Series["Series1"].Points.Add(dp);
            #endregion

            //绑定，曲线
            HistoryValueDA mDA=new HistoryValueDA();
            #region 今天接收、发送
            DateTime StartTime= Convert.ToDateTime( string.Format("{0} 00:00:00",DateTime.Now.ToString("yyyy-MM-dd")));
            DateTime EndTime= Convert.ToDateTime(string.Format("{0} 23:59:59",DateTime.Now.ToString("yyyy-MM-dd")));
             
           
            // 流量-今天
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 33001, StartTime, EndTime);//接收
            if (dt != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");//接收
            }

            dt = mDA.GetDeviceChanncelValue(iDeviceID, 33002, StartTime, EndTime);//发送
            if (dt != null)
            {
                chLine.Series["Series2"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }


            // 错误数和丢包数-今天
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 37001, StartTime, EndTime);//流入错误数
            if (dte != null)
            {
                chtErrorSum.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            dte = mDA.GetDeviceChanncelValue(iDeviceID, 37002, StartTime, EndTime);//流出错误数
            if (dte != null)
            {
                chtErrorSum.Series["Series2"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 37003, StartTime, EndTime);//流入丢包数
            if (dte != null)
            {
                chtErrorSum.Series["Series3"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            dte = mDA.GetDeviceChanncelValue(iDeviceID, 37004, StartTime, EndTime);//流出丢包数
            if (dte != null)
            {
                chtErrorSum.Series["Series4"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 发送字数总量-今天
            DataTable dts = mDA.GetDeviceChanncelValue(iDeviceID, 38001, StartTime, EndTime);//InBytes
            if (dts != null)
            {
                chtSendSum.Series["Series1"].Points.DataBindXY(dts.Rows, "Time", dts.Rows, "MonitorValue");
            }

            dts = mDA.GetDeviceChanncelValue(iDeviceID, 38002, StartTime, EndTime);//OutBytes
            if (dts != null)
            {
                chtSendSum.Series["Series2"].Points.DataBindXY(dts.Rows, "Time", dts.Rows, "MonitorValue");
            }

            #endregion

        }

    }
}