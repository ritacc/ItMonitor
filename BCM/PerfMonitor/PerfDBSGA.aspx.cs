using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.PerfMonitor;
using GDK.DAL.PerfMonitor;
using System.Data;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfDBSGA : PageBase
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
            PerfDBOR _Obj = new PerfDBDA().SelectDeviceDetail(mDeviceID);
            lblBufferSize.Text = _Obj.BufferSize;
            lblShareSize.Text = _Obj.ShareSize.ToString();
            lblLogBufferSize.Text = _Obj.LogBufferSize;
            lblDatabaseSize.Text = _Obj.DatabaseSize;
            lblDictionarySize.Text = _Obj.DictionarySize;
            lblSqlSize.Text = _Obj.SqlSize;
            lblInherentSize.Text = _Obj.InherentSize;
            lblJavaSize.Text = _Obj.JavaSize;
            lblLargeSize.Text = _Obj.LargeSize;

            lblBufferHitRate.Text = _Obj.BufferHitRate;
            lblDictionaryHitRate.Text = _Obj.DictionaryHitRate;
            lblDatabaseHitRate.Text = _Obj.DatabaseHitRate;
            lblAvailableMemory.Text = _Obj.AvailableMemory;

            HistoryValueDA mDA = new HistoryValueDA();

            DateTime StartTime = DateTime.Now.AddHours(-2);// Convert.ToDateTime(string.Format("{0} 00:00:00", DateTime.Now.ToString("yyyy-MM-dd")));
            DateTime EndTime = DateTime.Now;// Convert.ToDateTime(string.Format("{0} 23:59:59", DateTime.Now.ToString("yyyy-MM-dd")));

            int DeviceID = Convert.ToInt32(mDeviceID);
            DataTable dte = mDA.GetDeviceChanncelValue(DeviceID, 41601, StartTime, EndTime);//缓冲区击中率
            if (dte != null)
            {
                chLine.Series["Series1"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }

            dte = mDA.GetDeviceChanncelValue(DeviceID, 41602, StartTime, EndTime);//数据字典击中率
            if (dte != null)
            {
                chLine.Series["Series2"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
            dte = mDA.GetDeviceChanncelValue(DeviceID, 41603, StartTime, EndTime);//库击中率
            if (dte != null)
            {
                chLine.Series["Series3"].Points.DataBindXY(dte.Rows, "Time", dte.Rows, "MonitorValue");
            }
        }
    }
}