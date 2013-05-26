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
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        public string perf = "0";
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
            PerNetPortDetailOR _Obj = new PerfNetDA().SelectNetPortDetail(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);  
            lblType.Text = _objDevEx.TypeName;
            lblDescription.Text = _objDevEx.Desc;
            perf = _objDevEx.Perf;

            lblPort.Text = _Obj.Port;
            lblIpAddresses.Text = _Obj.IP;
            lblCircuitID.Text = _Obj.CircuitID;
            lblSuperiorName.Text = _Obj.SuperiorName;
            lblIndex.Text = _Obj.Index;
            lblPhysicalAddress.Text = _Obj.PhysicalAddress;
            lblManagementState.Text = _Obj.ManagementState;

            lblReceiveBroadband.Text = _Obj.ReceiveBroadband;
            lblSendBroadband.Text = _Obj.SendBroadband;
            lblCurrentlyReceivingTraffic.Text = _Obj.CurrentDownloadSpeed;
            lblCurrentSendTraffic.Text = _Obj.CurrentUploadSpeed;



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
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 32, StartTime, EndTime);//接收
            if (dt != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");//接收
            }

            dt = mDA.GetDeviceChanncelValue(iDeviceID, 31, StartTime, EndTime);//发送
            if (dt != null)
            {
                chLine.Series["Series2"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }


            // 错误数和丢包数-今天
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 21, StartTime, EndTime);//流入错误数
            if (dte != null)
            {
                chtErrorSum.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            dte = mDA.GetDeviceChanncelValue(iDeviceID, 22, StartTime, EndTime);//流出错误数
            if (dte != null)
            {
                chtErrorSum.Series["Series2"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(iDeviceID, 23, StartTime, EndTime);//流入丢包数
            if (dte != null)
            {
                chtErrorSum.Series["Series3"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            dte = mDA.GetDeviceChanncelValue(iDeviceID, 24, StartTime, EndTime);//流出丢包数
            if (dte != null)
            {
                chtErrorSum.Series["Series4"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 发送字数总量-今天
            DataTable dts = mDA.GetDeviceChanncelValue(iDeviceID, 11, StartTime, EndTime);//流入错误数
            if (dts != null)
            {
                chtSendSum.Series["Series1"].Points.DataBindXY(dts.Rows, "Time", dts.Rows, "MonitorValue");
            }

            dts = mDA.GetDeviceChanncelValue(iDeviceID, 12, StartTime, EndTime);//流出错误数
            if (dts != null)
            {
                chtSendSum.Series["Series2"].Points.DataBindXY(dts.Rows, "Time", dts.Rows, "MonitorValue");
            }

            #endregion

        }

    }
}