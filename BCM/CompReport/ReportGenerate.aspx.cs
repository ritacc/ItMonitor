using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using System.Data;
using GDK.Entity.CompSearch;

namespace GDK.BCM.CompReport
{
    public partial class ReportGenerate : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblName.Text = base.UserName;
                lblDepart.Text = base.CurrentUser.DepartmentName;
                int NowYear=DateTime.Now.Year;
                for (int i = 0; i <  10; i++)
                {
                    dpdYear.Items.Add(new ListItem((NowYear - i).ToString()));
                }
                for (int i = 1; i <= 12; i++)
                {
                    dpdMonth.Items.Add(new ListItem(i.ToString().PadLeft(2,'0')));
                }
                //加载，应用系统
               DataTable dt= new PrefApplicationDA().SelectApplicationSystem();
               dpdSystem.DataSource = dt;
               dpdSystem.DataTextField = "DeviceName";
               dpdSystem.DataValueField = "DeviceID";
               dpdSystem.DataBind();
            }
        }

        protected void btnGeneratePDF_Click(object sender, EventArgs e)
        {
            GeneratePDF PDF = new GeneratePDF();
            if (dpdSystem.SelectedItem == null)
            {
                AlertNormal("请选择报告标题。");
                return;
            }
            PDF.SystemID = Convert.ToInt32(dpdSystem.SelectedItem.Value);
            PDF.SystemTitle =dpdSystem.SelectedItem.Text;
            PDF.SubTitle = txtSubTitle.Text;


            if (rdiM.Checked)
            {
                PDF.ReportData = string.Format("{0}年{1}月", dpdYear.Text, dpdMonth.Text);
                PDF.StartTime = Convert.ToDateTime(string.Format("{0}-{1}-01 00:00:00"
                    , dpdYear.SelectedItem.Value, dpdMonth.SelectedItem.Value)).AddMonths(-1);

                string strEnd = string.Format("{0}-{1}-01 00:00:00"
                    , dpdYear.SelectedItem.Value, dpdMonth.SelectedItem.Value);
                PDF.EndTime = Convert.ToDateTime(strEnd).AddMonths(1).AddSeconds(-1);
            }
            else
            {
                if (txtStartTime.Text == "" || txtEndTime.Text == "")
                {
                    AlertNormal("请选择时间！");
                    return;
                }
                PDF.StartTime = Convert.ToDateTime(txtStartTime.Text);
                PDF.EndTime = Convert.ToDateTime(txtEndTime.Text);
                if (PDF.StartTime > PDF.EndTime)
                {
                    AlertNormal("开始时间必须大于结束时间！");
                    return;
                }
            }
            PDF.UserPart = base.CurrentUser.DepartmentName;
            PDF.ReportDesc = reportDesc.Text;

            Session["GeneratePDF"] = PDF;
            Response.Redirect("Generate.aspx");
        }
    }
}