using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.CompSearch;
using GDK.DAL.CompSearch;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

namespace GDK.BCM.CompSearch
{
    public partial class DBSearchDetail : PageBase
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
                ReportSeachWhereOR whereOR = Session["SearchWhere"] as ReportSeachWhereOR;
                SearchData(whereOR);
                Init(whereOR);
            }
        }

        public void Init(ReportSeachWhereOR whereOR)
        {
            lblName.Text = whereOR.ReportName;

            lblTime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            lblType.Text = whereOR.ReportTypeName.Replace("历史(", "").Replace(")", "");

            lblProp.Text = whereOR.ListChanncel[0].ChanncelName;

            chtReport.Titles[0].Text = string.Format("{0}:{1}",
                whereOR.ReportName, whereOR.ListChanncel[0].ChanncelName);
        }

        public void SearchData(ReportSeachWhereOR whereOR)
        {
            //ReportSeachDA
            DataTable dtReport=new DataTable();
            DataTable dtList=new DataTable();
            new ReportSeachDA().GetDataReport(whereOR, out dtReport, out dtList);
            gvList.DataSource = dtList;
            gvList.DataBind();
            //编写数据
            BindSeries(dtReport, whereOR);
        }

        public void BindSeries(DataTable dtReport, ReportSeachWhereOR whereOR)
        {
            if (dtReport == null)
                return;
            if (dtReport.Rows.Count == 0)
                return;

            foreach (SearchChanncelOR obj in whereOR.ListChanncel)
            {

                 dtReport.DefaultView.RowFilter = string.Format(" ChannelNo={0}", obj.ChanncelNo);
                 DataTable dt = dtReport.DefaultView.ToTable();
                
                 Series ser = new Series();
                 ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "avgValue");
                 ser.ChartType = SeriesChartType.Line;
                 //ser.IsValueShownAsLabel = true;
                 ser.MarkerStyle = MarkerStyle.Circle;
                 ser.MarkerSize = 3;
                 ser.LegendText = obj.ChanncelName;
                 chtReport.Series.Add(ser);
            }
        }
    }
}