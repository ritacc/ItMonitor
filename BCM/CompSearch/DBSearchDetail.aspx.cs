using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.CompSearch;

namespace GDK.BCM.CompSearch
{
    public partial class DBSearchDetail : System.Web.UI.Page
    {
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

            lblType.Text = whereOR.ListChanncel[0].ChanncelName;
        }

        public void SearchData(ReportSeachWhereOR whereOR)
        {

        }
    }
}