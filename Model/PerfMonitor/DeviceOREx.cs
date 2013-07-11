﻿using System;
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

       /// <summary>
       /// 状态
       /// </summary>
       public string State { get; set; }

       public string StatusVal
       {
           get
           {
               string val = "1";
               if (State == "正常")
                   val = "1";
               else
                   val = "0";
               return val;
           }
       }
    }
}
