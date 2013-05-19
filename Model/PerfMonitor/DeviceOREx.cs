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
           ClassName = dr["ClassNmae"].ToString();
           Desc = dr["descInfo"].ToString();
           Perf = dr["performance"].ToString();
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
       /// 描述
       /// </summary>
       public string Desc { get; set; }

       /// <summary>
       /// 性能
       /// </summary>
       public string Perf { get; set; }
    }
}
