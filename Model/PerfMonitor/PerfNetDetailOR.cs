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
       /// 网络 今天的使用率 
       /// </summary>
       public double NetUtilityRate { get; set; }

       /// <summary>
       /// 接口 使用率 
       /// </summary>
       public string PortUtilityRate { get; set; }

       /// <summary>
       /// 7 响应时间 
       /// </summary>
       public string ResponseTime { get; set; }

       /// <summary>
       /// 今天的丢包率
       /// </summary>
       public string LoseRate { get; set; }

       /// <summary>
       /// 8 CPU使用率 
       /// </summary>
       public string CPU_Usage { get; set; }

       /// <summary>
       /// 9 内存使用率 
       /// </summary>
       public string MemoryUsage { get; set; }

       /// <summary>
       /// 背板使用率
       /// </summary>
       public string Butterfly { get; set; }
       
       /// <summary>
       /// 11 监控
       /// </summary>
       public string Monitor { get; set; }

       
      
       
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
                   case "31001":
                       Firm = dr["MonitorValue"].ToString();
                       break;

                   case "31002":
                       FlowCalculator = dr["MonitorValue"].ToString();
                       break;

                   case "31003":
                       Dependence = dr["MonitorValue"].ToString();
                       break;

                   case "31004":
                       PollingProtocol = dr["MonitorValue"].ToString();
                       break;

                   case "31005":
                       Monitor = dr["MonitorValue"].ToString();
                       break;

                   case "32001":
                       NetUtilityRate = Convert.ToDouble(dr["MonitorValue"]);
                       break;

                   case "32002":
                       ResponseTime = dr["MonitorValue"].ToString();
                       break;

                   case "32003":
                       LoseRate = dr["MonitorValue"].ToString();
                       break;
               }

           }
       }

    }
}
