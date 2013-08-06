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
        /// CPU使用情况
        /// </summary>
        public int CPUUsage { get; set; }
        
        /// <summary>
        /// 内存使用率
        /// </summary>
        public Double MemoryUtilization { get; set; }

        /// <summary>
        /// 磁盘使用率
        /// </summary>
        public Double DiskUsage { get; set; }

        /// <summary>
        /// 网络使用率
        /// </summary>
        public Double NetUsage { get; set; }
        

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
                    case "91104":
                        CPUUsage = Convert.ToInt32(dr["MonitorValue"].ToString());
                        break;
                    case "91204":
                        MemoryUtilization = Convert.ToDouble(dr["MonitorValue"].ToString());
                        break;
                    case "91303":
                        DiskUsage = Convert.ToDouble(dr["MonitorValue"].ToString());
                        break;
                    case "91403":
                        NetUsage = Convert.ToDouble(dr["MonitorValue"].ToString());
                        break;                      
                }
            }
        }
    }
}
