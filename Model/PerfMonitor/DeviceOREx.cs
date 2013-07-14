using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
   public class DeviceOREx:DeviceOR
    {
       public DeviceOREx(DataRow dr)
           : base(dr)
       {
           TypeName = dr["TypeName"].ToString();
           ClassName = dr["ClassName"].ToString();
           WarningStatus = dr["WarningStatus"].ToString();
           HealthStatus = dr["HealthStatus"].ToString();
           State = dr["State"].ToString();
       }
       /// <summary>
       /// 类型名称
       /// </summary>
       public string TypeName { get; set; }

       /// <summary>
       /// 分类
       /// </summary>
       public string ClassName { get; set; }
       
       /// <summary>
       /// 告警状态
       /// </summary>
       public string WarningStatus { get; set; }

       /// <summary>
       /// 健康状况
       /// </summary>
       public string HealthStatus { get; set; }
       public string HealthStatusVal {
           get
           {
               string val = string.Empty;
               if( HealthStatus=="故障")
               {
                   val = "0";
               }
               else if (HealthStatus == "报警")
               {
                   val = "2";
               }
               else
               {
                   val = "1";
               }
               return val;
           }
       }

       /// <summary>
       /// 状态
       /// </summary>
       public string State { get; set; }

       public string StatusVal
       {
           get
           {
               string val = "1";
               if (State == "异常")
                   val = "0";
               else
                   val = "1";
               return val;
           }
       }
    }
}
