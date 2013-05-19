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

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfNetPortDetail : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);

        }

        public string perf = "0";
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

            //绑定，曲线
            HistoryValueDA mDA=new HistoryValueDA();
            #region 今天接收、发送
            DateTime StartTime= Convert.ToDateTime( string.Format("{0} 00:00:00",DateTime.Now.ToString("yyyy-MM-dd")));
            DateTime EndTime= Convert.ToDateTime(string.Format("{0} 23:59:59",DateTime.Now.ToString("yyyy-MM-dd")));
                        
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
            #endregion

        }

    }
}