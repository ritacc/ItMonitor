using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class PerfVirtualOR
    {
        public PerfVirtualOR()
        {

        }
        
        /// <summary>
        /// CPU使用率
        /// </summary>
        public Double CPUUtilizationRatio { get; set; }
        
        /// <summary>
        /// 内存使用率
        /// </summary>
        public Double MemoryUtilization { get; set; }


        
         /// <summary>
        /// 接口列表     3#^#1705#^#1706#^#1707
        /// </summary>
        public string Ports { get; set; }
                
        /// <summary>
        /// 网各设备的，接口列表
        /// </summary>
        public DataTable SubProts { get; set; }

        public PerfVirtualOR(DataTable dt)
        {
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["ChannelNO"].ToString())
                {
                    case "91103":
                        CPUUtilizationRatio = Convert.ToDouble(dr["MonitorValue"].ToString());
                        break;
                    case "91204":
                        MemoryUtilization = Convert.ToDouble(dr["MonitorValue"].ToString());
                        break;                    
                }
            }
        }
    }
}
