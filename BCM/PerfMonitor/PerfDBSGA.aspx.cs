using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.PerfMonitor;
using GDK.DAL.PerfMonitor;

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
            lblShareSize.Text = _Obj.ShareSize;
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
        }
    }
}