using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using GDK.Entity.SYS;
using GDK.DAL.SYS;
using Entity;
using GDK.DAL.PerfMonitor;
using System.Data;

namespace GDK.BCM
{
    public partial class DropdownDeviceList : System.Web.UI.Page
    {


		protected void Page_Load(object sender, EventArgs e)
		{
			HistoryValueDA mda = new HistoryValueDA();//	GetDeviceChanncelValuesList(
			DataTable dt = mda.GetDeviceChanncelValuesList(60001, 211, 21103, DateTime.Now.AddHours(-1), DateTime.Now);

			chLine.Series["Series1"].Points.DataBindXY(dt.Rows, "DeviceName", dt.Rows, "maxVal");//接收
		}

		
    }

   
}