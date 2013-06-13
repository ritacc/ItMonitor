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
                    dpdMonth.Items.Add(new ListItem(i.ToString()));
                }
                //加载，应用系统
               DataTable dt= new PerfApplicationDA().SelectApplicationSystem();
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
            PDF.ReportData = string.Format("{0}年{1}月",dpdYear.Text,dpdMonth.Text);
            PDF.UserPart = base.CurrentUser.DepartmentName;
            PDF.ReportDesc = reportDesc.Text;

            Session["GeneratePDF"] = PDF;
            Response.Redirect("Generate.aspx");
        }
    }
}