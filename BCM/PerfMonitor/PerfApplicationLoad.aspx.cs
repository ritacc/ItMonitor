using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.BCM.StateMonitor;
using System.Data;
using GDK.DAL.PerfMonitor;
using System.Text;

namespace GDK.BCM.PerfMonitor
{
    public partial class PerfApplicationLoad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string mType = Request.QueryString["type"];
            List<ApplListOR> list = new List<ApplListOR>();
            switch (mType)
            {
                case "top":
                    HeadTop(list);
                    break;
                case "soft":
                    HeadSoft(list);
                    break;
                case "HD":
                    HeadHD(list);
                    break;
                default:
                    HeadOther(list, mType);
                    break;
            }
            int dep = Convert.ToInt32(Request.QueryString["dep"]);
            dep++;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"divContent\">");
            if (list.Count > 0)
            {
                if (mType == "top" || mType == "soft" || mType == "HD")
                {
                    foreach (ApplListOR obj in list)
                    {
                        sb.Append(string.Format("<div class=\"divTitleMu\" guid='{0}' type='{1}' dep='{2}'>"
                            , obj.DeviceID
                            , obj.TypeEN, dep));
                        sb.Append("<table class=\"tableContent\">");
                        sb.Append("<tr>");
                        sb.Append(string.Format("<td class=\"w75\"> <span class=\"divTitle Title{0}\">&nbsp;</span></td>", dep));
                        sb.Append("<td>");
                        sb.Append("    <span class=\"spanLadDate\">");
                        sb.Append(obj.DeviceName);
                        sb.Append("    </span>");
                        sb.Append(" </td>");
                        sb.Append("<td class=\"w120\">");
                        sb.Append(obj.TypeName);
                        sb.Append("  </td>");
                        sb.Append("<td class=\"w120\">");
                        sb.Append(string.Format(@" <img  src='../images/Common/stata{0}.gif' alt='状态'/>{1}", obj.Status, obj.StatusShow));
                        sb.Append("  </td>");
                        sb.Append("<td class=\"w120\">");
                        sb.Append(string.Format(@" <img  src='../images/Common/stata{0}.gif' alt='状态'/>{1}", obj.Warning, obj.WarningShow));
                        sb.Append("  </td>");
                        sb.Append(" </tr>");
                        sb.Append(" </table>");
                        sb.Append("  </div>");
                    }
                }
                else
                {
                    foreach (ApplListOR obj in list)
                    {
                        sb.Append(string.Format("<div class=\"divTitleMu\" guid='{0}' type='{1}' dep='{2}'>"
                            , obj.DeviceID
                            , obj.TypeEN, dep));
                        sb.Append("<table class=\"tableContent\">");
                        sb.Append("<tr>");
                        sb.Append(string.Format("<td class=\"w75\"> <span class=\"divItem Title{0}\">&nbsp;</span></td>", dep));
                        sb.Append("<td>");
                        sb.Append("    <span class=\"spanLadDate\">");
                        if (obj.typeID == 4)
                        {
                            sb.Append(string.Format("<a href='{0}?id={1}'\"\" target=\"_parent\">{2}</a>", this.GetTargetURL(obj.typeID),
                            obj.DeviceID, obj.DeviceName));
                        }
                        else
                        {
                            sb.Append(string.Format("<a href='{0}?id={1}'\"\">{2}</a>", this.GetTargetURL(obj.typeID),
                         obj.DeviceID, obj.DeviceName));
                        }
                        sb.Append("    </span>");
                        sb.Append(" </td>");
                        sb.Append("<td class=\"w120\">");
                        sb.Append(obj.TypeName);
                        sb.Append("  </td>");
                        sb.Append("<td class=\"w120\">");
                        sb.Append(string.Format(@" <img  src='../images/Common/stata{0}.gif' alt='状态'/>{1}", obj.Status, obj.StatusShow));
                        sb.Append("  </td>");
                        sb.Append("<td class=\"w120\">");
                        sb.Append(string.Format(@" <img  src='../images/Common/stata{0}.gif' alt='状态'/>{1}", obj.Warning, obj.WarningShow));
                        sb.Append("  </td>");
                        sb.Append(" </tr>");
                        sb.Append(" </table>");
                        sb.Append("  </div>");
                    }
                }
            }
            else
            {
                sb.Append("<table class=\"tableContent\"><tr><td style='text-align:center;'>没有子系统。</td></tr></table>");
            }

            sb.Append("            </div>");


            Response.Clear();
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
        }

        public void HeadTop(List<ApplListOR> list)
        {
            string id = Request.QueryString["GUID"];
            DataTable objDev = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id));
            if (objDev != null)
            {
                objDev.DefaultView.RowFilter = string.Format(" typeid=2 or typeid=3 or typeid=10 ");
                DataTable dt = objDev.DefaultView.ToTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ApplListOR obj = HeadStatusAndWaring(dt);
                    obj.DeviceID = id;
                    obj.DeviceName = "软件层";
                    obj.TypeName = "业务系统";
                    obj.TypeEN = "soft";
                    list.Add(obj);
                }

                objDev.DefaultView.RowFilter = string.Format(" typeid=4");
                dt = objDev.DefaultView.ToTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ApplListOR obj = HeadStatusAndWaring(dt);
                    obj.DeviceID = id;
                    obj.DeviceName = "数据库层";
                    obj.TypeName = "业务系统";
                    obj.TypeEN = "DB";
                    list.Add(obj);
                }

                objDev.DefaultView.RowFilter = string.Format(" typeid=1");
                dt = objDev.DefaultView.ToTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    ApplListOR obj = HeadStatusAndWaring(dt);
                    obj.DeviceID = id;
                    obj.DeviceName = "硬件层";
                    obj.TypeName = "业务系统";
                    obj.TypeEN = "HD";
                    list.Add(obj);
                }
            }
        }

        public void HeadSoft(List<ApplListOR> list)
        {
            string id = Request.QueryString["GUID"];
            DataTable objDev = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), " (dt.typeid=2 or dt.typeid=3 )");
            if (objDev != null && objDev.Rows.Count > 0)
            {
                ApplListOR obj = HeadStatusAndWaring(objDev);
                obj.DeviceID = id;
                obj.DeviceName = "Web层";
                obj.TypeName = "业务系统";
                obj.TypeEN = "web";
                list.Add(obj);
            }

            objDev = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), 10);
            if (objDev != null && objDev.Rows.Count > 0)
            {
                ApplListOR obj = HeadStatusAndWaring(objDev);
                obj.DeviceID = id;
                obj.DeviceName = "应用层";
                obj.TypeName = "业务系统";
                obj.TypeEN = "use";
                list.Add(obj);
            }
        }
        public void HeadHD(List<ApplListOR> list)
        {
            string id = Request.QueryString["GUID"];
            DataTable objDev = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), 1);
            if (objDev != null)
            {
                ApplListOR obj = HeadStatusAndWaring(objDev);
                obj.DeviceID = id;
                obj.DeviceName = "服务器";
                obj.TypeName = "业务系统";
                obj.TypeEN = "server";
                list.Add(obj);
            }
        }

        public void HeadOther(List<ApplListOR> list, string mtype)
        {
            string id = Request.QueryString["GUID"];
            DataTable dt = null;
            switch (mtype)
            {
                case "server":
                    dt = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), 1);
                    break;
                case "use":
                    dt = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), 10);
                    break;
                case "web":
                    dt = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), " (dt.typeid=2 or dt.typeid=3 )");
                    break;
                case "DB":
                    dt = new PrefApplicationDA().GetSysLay(Convert.ToInt32(id), 4);
                    break;
            }
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ApplListOR obj = new ApplListOR();
                    obj.DeviceID = dr["DeviceID"].ToString();
                    obj.DeviceName = dr["DeviceName"].ToString();
                    obj.TypeName = dr["TypeName"].ToString();
                    obj.typeID = Convert.ToInt32(dr["typeid"].ToString());

                    obj.Status = Convert.ToInt32(dr["perfValue"].ToString());
                    obj.StatusShow = dr["Performance"].ToString();
                    obj.Warning = Convert.ToInt32(dr["WarningStatus"].ToString());
                    obj.WarningShow = dr["WarningStatusName"].ToString();
                    list.Add(obj);
                }
            }
        }


        private ApplListOR HeadStatusAndWaring(DataTable objDev)
        {
            ApplListOR obj = new ApplListOR();
            obj.Status = 1;
            obj.StatusShow = "正常";
            obj.Warning = 1;
            obj.WarningShow = "正常";

            foreach (DataRow dr in objDev.Rows)
            {
                if (dr["perfValue"].ToString() != "1")
                {
                    obj.Status = Convert.ToInt32(dr["perfValue"].ToString());
                    obj.StatusShow = dr["Performance"].ToString();
                }
                if (dr["WarningStatus"].ToString() != "1")
                {
                    obj.Warning = Convert.ToInt32(dr["WarningStatus"].ToString());
                    obj.WarningShow = dr["WarningStatusName"].ToString();
                }
            }
            return obj;
        }

        public string GetTargetURL(int typeID)
        {
            string url = "";
            switch (typeID)
            {
                case 1:
                    url = "../PerfMonitor/PerfHostDetail.aspx";
                    break;
                case 2:
                    url = "";
                    break;
                case 3:
                    url = "";
                    break;
                case 4:
                    url = "../PerfMonitor/PerfDBIndex.aspx";
                    break;
                case 10:
                    url = "../PerfMonitor/PerfMiddlewareDetail.aspx";
                    break;
            }
            return url;
        }
    }
}