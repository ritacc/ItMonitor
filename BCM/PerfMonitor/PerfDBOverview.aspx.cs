﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Drawing;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;
using GDK.DAL.PerfMonitor;
using System.Data;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfDBOverview : PageBase
    {
        public int deviceID = 0;
        public string State = "0";
        public string Health = "0";
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.pg.OnPageChanged += new EventHandler(PageChanged);
            deviceID = Convert.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                InitData();
            }
        }

        #region  绑定列表 - 最少可用表空间
        private void PageChanged(object sender, EventArgs e)
        {
            BindGraid();
        }
        private void BindGraid()
        {
            int PageCount = 0;
            DataTable dt = new PerfDBDA().selectMinBytesList(pg.PageIndex, pg.PageSize, out PageCount, Request.QueryString["id"]);
            gvMinBytes.DataSource = dt;
            gvMinBytes.DataBind();
            this.pg.RecordCount = PageCount;
        }
        #endregion

        private void InitData()
        {
            BindGraid();
            string mDeviceID = Request.QueryString["id"];
            int iDeviceID = Convert.ToInt32(Request.QueryString["id"]);
            DeviceOR _objDev = new DeviceDA().SelectDeviceORByID(mDeviceID);
            PerfDBOR _Obj = new PerfDBDA().SelectDeviceDetail(mDeviceID);
            DeviceOREx _objDevEx = new DeviceDA().SelectDeviceORExByID(mDeviceID);

            State = _objDevEx.StatusVal;
         
            Health = _objDevEx.HealthStatusVal;
           

            lblState.Text = _objDevEx.State;

            lblServName.Text =  _objDev.DeviceName;
            lblAuthType.Text = _objDev.AuthType;
            lblVersion.Text = _objDev.Version;
            lblStartUpTime.Text = _Obj.StartUpTime;
            lblPort.Text = _objDev.Port;
            lblHostName.Text = _objDev.OperSystem;
            lblSystem.Text = _objDev.HostName;
            lblLastPollingTime.Text = _objDev.LastPollingTime.ToString();
            lblNextPollingTime.Text = _objDev.NextPollingTime.ToString();

            lblValue.Text = _Obj.ConnectionTime;
            lblUserNO.Text = _Obj.UserNO;

            lblServerSize.Text = _Obj.ServerSize;
            lblAverageExecutionTime.Text = _Obj.AverageExecutionTime;
            lblReadingTimes.Text = _Obj.ReadingTimes;
            lblWritingTimes.Text = _Obj.WritingTimes;
            lblBlockSize.Text = _Obj.BlockSize;




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


            #region 绑定 共享的SGA
            DataPoint dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}M)", "库存储器大小", _Obj.LibraryMemorySize);
            double[] dSGA = { _Obj.LibraryMemorySize };
            dpSGA.Color = Color.Green;
            dpSGA.YValues = dSGA;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}M)", "数据字典存储器", _Obj.DataDictionaryMemory);
            double[] dSGA2 = { _Obj.DataDictionaryMemory };
            dpSGA.Color = Color.Red;
            dpSGA.YValues = dSGA2;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}M)", "SG区域大小", _Obj.SGSize);
            double[] dSGA3 = { _Obj.SGSize };
            dpSGA.Color = Color.Blue;
            dpSGA.YValues = dSGA3;
            chtSGA.Series["Series1"].Points.Add(dpSGA);
            
            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}M)", "固定的区域大小", _Obj.FixedRegionSize);
            double[] dSGA4 = { _Obj.FixedRegionSize };
            dpSGA.Color = Color.Yellow;
            dpSGA.YValues = dSGA4;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}M)", "缓冲存储器大小", _Obj.BufferMemorySize);
            double[] dSGA5 = { _Obj.BufferMemorySize };
            dpSGA.Color = Color.Orange;
            dpSGA.YValues = dSGA5;
            chtSGA.Series["Series1"].Points.Add(dpSGA);

            dpSGA = new DataPoint();
            dpSGA.LegendText = string.Format("{0}({1}M)", "共享池大小", _Obj.ShareSize);
            double[] dSGA6 = { _Obj.ShareSize };
            dpSGA.Color = Color.OldLace;
            dpSGA.YValues = dSGA6;
            chtSGA.Series["Series1"].Points.Add(dpSGA);
            #endregion


            #region 绑定，曲线
            HistoryValueDA mDA = new HistoryValueDA();
            
            DateTime StartTime = DateTime.Now.AddHours(-1);
            DateTime EndTime = DateTime.Now;


            // 连接时间-最后一小时
            DataTable dte = mDA.GetDeviceChanncelValue(iDeviceID, 41101, StartTime, EndTime);//流入错误数
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            // 用户活动性-最后一小时
            DataTable dt = mDA.GetDeviceChanncelValue(iDeviceID, 41201, StartTime, EndTime);//流入错误数
            if (dt != null)
            {
                chUserActivity.Series["Series1"].Points.DataBindXY(dt.Rows, "Time", dt.Rows, "MonitorValue");
            }
            


            #endregion
        }
    }
}