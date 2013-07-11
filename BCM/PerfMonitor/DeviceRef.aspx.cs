using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.PerfMonitor;
using GDK.Entity.PerfMonitor;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GDK.BCM.PerfMonitor
{
	public partial class DeviceRef : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			string mdeivceid = Request.QueryString["id"];
			DeviceANDItemRefOR obj=	new TmpValueDA().SelectRefData(mdeivceid);
			string result=string.Empty;
			if (obj != null)
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());
				using (MemoryStream ms = new MemoryStream())
				{
					serializer.WriteObject(ms, obj);
					result= System.Text.Encoding.UTF8.GetString(ms.ToArray());
				}
			}
			Response.Clear();
			Response.Write(result);
			Response.Flush();
			Response.End();
		}
	}
}