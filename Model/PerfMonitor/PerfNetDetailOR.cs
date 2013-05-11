﻿using System;
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
       /// 接口列表     3#^#1705#^#1706#^#1707
       /// </summary>
       public string Ports { get; set; }

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
                   case "10":
                       Ports = dr["MonitorValue"].ToString();
                       break;

               }

           }
       }

    }
}
