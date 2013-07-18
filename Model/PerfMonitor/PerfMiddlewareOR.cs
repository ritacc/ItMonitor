using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class PerfMiddlewareOR
    {
        public PerfMiddlewareOR()
        {

        }
        
        /// <summary>
        /// 主机名称
        /// </summary>
        public string HostName { get; set; }


         /// <summary>
        /// 接口列表     3#^#1705#^#1706#^#1707
        /// </summary>
        public string Ports { get; set; }
                
        /// <summary>
        /// 网各设备的，接口列表
        /// </summary>
       // public DataTable SubProts { get; set; }

        public PerfMiddlewareOR(DataTable dt)
        {
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["ChannelNO"].ToString())
                {
                    case "12101":
                        HostName = dr["MonitorValue"].ToString();
                        break;
                }
            }
        }
    }
}
