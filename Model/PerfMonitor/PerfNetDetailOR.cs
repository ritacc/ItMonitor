using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
   public class PerfNetDetailOR
    {

       public PerfNetDetailOR()
       {

       }

       /// <summary>
       /// IP地址 1
       /// </summary>
       public string IP { get; set; }

       /// <summary>
       /// 2 厂商 
       /// </summary>
       public string Firm { get; set; }

       /// <summary>
       /// 3 流量计算器 
       /// </summary>
       public string FlowCalculator { get; set; }

       /// <summary>
       /// 4 依赖性 
       /// </summary>
       public string Dependence { get; set; }

       /// <summary>
       /// 5 轮询协议 
       /// </summary>
       public string PollingProtocol { get; set; }

       /// <summary>
       /// 6 使用率 
       /// </summary>
       public string UtilityRate { get; set; }

       /// <summary>
       /// 7 响应时间 
       /// </summary>
       public string ResponseTime { get; set; }

       /// <summary>
       /// 8 CPU使用率 
       /// </summary>
       public string CPU_Usage { get; set; }

       /// <summary>
       /// 9 内存使用率 
       /// </summary>
       public string MemoryUsage { get; set; }

       /// <summary>
       /// 10 接口列表     3#^#1705#^#1706#^#1707
       /// </summary>
       public string Ports { get; set; }


       /// <summary>
       /// 系统描述 
       /// </summary>
       public string SystemDescription { get; set; }

       /// <summary>
       /// 网各设备的，接口列表
       /// </summary>
       public DataTable SubProts { get; set; }

       public PerfNetDetailOR(DataTable dt)
       {
           if (dt == null)
               return;
           foreach (DataRow dr in dt.Rows)
           {
               switch (dr["ChannelNO"].ToString())
               {
                   case "1":
                       IP = dr["MonitorValue"].ToString();
                       break;
                   case "2":
                       Firm = dr["MonitorValue"].ToString();
                       break;

                   case "3":
                       FlowCalculator = dr["MonitorValue"].ToString();
                       break;

                   case "4":
                       Dependence = dr["MonitorValue"].ToString();
                       break;

                   case "5":
                       PollingProtocol = dr["MonitorValue"].ToString();
                       break;

                   case "6":
                       UtilityRate = dr["MonitorValue"].ToString();
                       break;

                   case "7":
                       ResponseTime = dr["MonitorValue"].ToString();
                       break;

                   case "8":
                       CPU_Usage = dr["MonitorValue"].ToString();
                       break;

                   case "9":
                       MemoryUsage = dr["MonitorValue"].ToString();
                       break;

                   case "10":
                       Ports = dr["MonitorValue"].ToString();
                       break;

                   case "11102":
                       SystemDescription = dr["MonitorValue"].ToString();
                       break;
               }

           }
       }

    }
}
