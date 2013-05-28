using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.SerMonitor;
using GDK.DAL.Sys;
using GDK.Entity.CompSearch;

namespace GDK.BCM.CompSeartch
{
    public partial class DBSearch : PageBase
    {
        protected override void OnLoad(EventArgs e)
        {
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BoindStation();
            }
        }

        #region Dpd加载值
        private void BoindStation()
        {
            dpdStationID.DataSource = dpdStationID.DataSource = new StationDA().selectAllStation();
            dpdStationID.DataTextField = "StationName";
            dpdStationID.DataValueField = "StationID";
            dpdStationID.DataBind();

            dpdDeviceType.DataSource = dpdStationID.DataSource = 
                new DeviceDA().GetAllDeviceType(Request.QueryString["type"]);
            dpdDeviceType.DataValueField = "DeviceTypeID";
            dpdDeviceType.DataTextField = "TypeName";
            dpdDeviceType.DataBind();

            dpdStationID_SelectedIndexChanged(null, null);
        }

        protected void dpdStationID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpdStationID.SelectedItem == null || dpdDeviceType.SelectedItem == null)
                return;
            if (dpdStationID.SelectedValue == "" || dpdDeviceType.SelectedValue == "")
                return;

            BindDeviceid(dpdStationID.SelectedItem.Value, dpdDeviceType.SelectedItem.Value);
            dpdDeviceid_SelectedIndexChanged(null, null);
        }
        protected void dpdDeviceid_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dpdDeviceid.SelectedItem == null)
                return;
            BindChannel(dpdDeviceid.SelectedItem.Value);
        }
        private void BindDeviceid(string strID, string strTypeid)
        {
            dpdDeviceid.DataSource = new DeviceDA().GetAllGenerdDevice(strID, strTypeid);
            dpdDeviceid.DataTextField = "deviceName";
            dpdDeviceid.DataValueField = "DeviceID";
            dpdDeviceid.DataBind();

            dpdDeviceid.Items.Insert(0, new ListItem("==请选择设备==", ""));
        }

        private void BindChannel(string strID)
        {
            lbChannelnoList.DataSource = new DeviceDA().SelectChannelByDeviceID(strID);
            lbChannelnoList.DataTextField = "ChannelName";
            lbChannelnoList.DataValueField = "ChannelNo";
            lbChannelnoList.DataBind();
        }

        #endregion

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (dpdDeviceid.SelectedItem == null)
            {
                base.AlertNormal("请选择设备！");
                return;
            }
            ReportSeachWhereOR whereOR = new ReportSeachWhereOR();
            whereOR.StationID = Convert.ToInt32(dpdStationID.SelectedValue);
            whereOR.DeviceType = Convert.ToInt32(dpdDeviceType.SelectedValue);

            whereOR.DeviceID = Convert.ToInt32(dpdDeviceid.SelectedValue);
            whereOR.DeviceName = dpdDeviceid.SelectedItem.Text;

            whereOR.StartTime = Convert.ToDateTime(txtStartTime.Text);
            whereOR.EndTime = Convert.ToDateTime(txtEndTime.Text);

            whereOR.ReportType = dpdDtaill.SelectedValue;
            whereOR.ReportTypeName = dpdDtaill.SelectedItem.Text;

            whereOR.ReportName = GetReportType(Request.QueryString["type"]);

            List<SearchChanncelOR> listChanncels = new List<SearchChanncelOR>();
            foreach (ListItem li in listSelectChannelNo.Items)
            {
                listChanncels.Add(new SearchChanncelOR()
                {
                    ChanncelNo = Convert.ToInt32(li.Value),
                    ChanncelName = li.Text
                });
            }

            if (listChanncels.Count == 0)
            {
                base.AlertNormal("请选择通道！");
                return;
            }
            whereOR.ListChanncel = listChanncels;

            Session["SearchWhere"] = whereOR;
            Response.Redirect("DBSearchDetail.aspx");
        }

        #region 获取报表类型
        private string GetReportType(string type)
        {
            string strType = string.Empty;
            switch (type)
            {
                case "1":
                    strType = "主机性能报表";
                    break;
                case "4":
                    strType = "数据库报表";
                    break;
                case "10":
                    strType = "中间件报表";
                    break;
                case "2":
                    strType = "应用系统报表";
                    break;
                //case "":
                //    strType = "机房报表";
                //    break;
            }
            return strType;
        }
        #endregion

        #region 对象处理
        protected void btnAddAItem_Click(object sender, EventArgs e)
        {
            if (lbChannelnoList.SelectedItem == null)
                return;

            listSelectChannelNo.Items.Add(lbChannelnoList.SelectedItem);
            lbChannelnoList.Items.Remove(lbChannelnoList.SelectedItem);
            listSelectChannelNo.SelectedIndex = -1;
            lbChannelnoList.SelectedIndex = -1;
        }

        protected void btnAddAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in lbChannelnoList.Items)
            {
                listSelectChannelNo.Items.Add(li);
            }
            lbChannelnoList.Items.Clear();
            listSelectChannelNo.SelectedIndex = -1;
            lbChannelnoList.SelectedIndex = -1;
        }

        protected void btnMoveAItem_Click(object sender, EventArgs e)
        {
            if (listSelectChannelNo.SelectedItem == null)
                return;
            lbChannelnoList.Items.Add(listSelectChannelNo.SelectedItem);
            listSelectChannelNo.Items.Remove(listSelectChannelNo.SelectedItem);
            listSelectChannelNo.SelectedIndex = -1;
            lbChannelnoList.SelectedIndex = -1;
        }

        protected void btnMoveAll_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in listSelectChannelNo.Items)
            {
                lbChannelnoList.Items.Add(li);
            }
            listSelectChannelNo.Items.Clear();
            listSelectChannelNo.SelectedIndex = -1;
            lbChannelnoList.SelectedIndex = -1;
        }
        #endregion

    }
}