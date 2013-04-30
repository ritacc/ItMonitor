using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.BCM;
using System.Data;



namespace GDK.BCM.Main
{
   
    public partial class Default : PageBase
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
                InitPage();
            }
        }

       
        private void InitPage()
        {

            //DataTable dt = new DAL.Server.InfoDA().StatServerByBuytime("", "m");
            //if (dt.Rows.Count == 0)
            //{
            //    chtServerBuytime.AlternateText = "没有数据。";
            //    chtServerBuytime.DataSource = null;
            //    return;
            //}
            //chtServerBuytime.Series["Series1"].Points.DataBindXY(dt.Rows, "gyear", dt.Rows, "num");
            //chtServerBuytime.Series["Series1"]["DrawingStyle"] = "Cylinder";
            //int sourceCount = 0;

            //dt = new DAL.Server.InfoDA().selectAllDateByWhere(1, 5, out sourceCount, " state !='1'");
            //gvErrorServer.DataSource = dt;
            //gvErrorServer.DataBind();

            //dt = new AlertLogReportDA().GetErrorMainPage();
            //gvErrorApp.DataSource = dt;
            //gvErrorApp.DataBind();
        }
    }
}