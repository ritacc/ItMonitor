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
           ClassName = dr["ClassNmae"].ToString();
       }
       /// <summary>
       /// 类型名称
       /// </summary>
       public string TypeName { get; set; }

       /// <summary>
       /// 分类
       /// </summary>
       public string ClassName { get; set; }
    }
}
