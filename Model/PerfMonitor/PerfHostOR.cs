using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class PerfHostOR
    {
        public PerfHostOR()
        {

        }

        /// <summary>
        /// 监视器名称
        /// </summary>
        //public string MonitorName { get; set; }

        /// <summary>
        /// 主机名称
        /// </summary>
        public string HostName { get; set; }
        
        /// <summary>
        /// 操作系统
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 告警状态
        /// </summary>
        public string WarningStatus { get; set; }

        /// <summary>
        /// 响应时间
        /// </summary>
        public string ResponseTime { get; set; }

               
        // CPU及内存使用率 - 近六小时内列表
    
        /// <summary>
        /// 交换内存利用率 %
        /// </summary>
        public string SwapMemoryUtilization { get; set; }

        /// <summary>
        /// 交换内存利用率 MB
        /// </summary>
        public string SwapMemoryUtilizationMB { get; set; }

        /// <summary>
        /// 物理内存利用率 %
        /// </summary>
        public string PhysicalpMemoryUtilization { get; set; }
        
        /// <summary>
        /// 物理内存利用率 MB
        /// </summary>
        public string PhysicalpMemoryUtilizationMB { get; set; }

        /// <summary>
        /// 空闲物理内存 MB
        /// </summary>
        public string FreePhysicalpMemory { get; set; }

        /// <summary>
        /// CPU使用率
        /// </summary>
        public string CPUMemoryUtilization { get; set; }


      

        public PerfHostOR(DataTable dt)
        {
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["ChannelNO"].ToString())
                {
                    //case "12101":
                    //    MonitorName = dr["MonitorValue"].ToString();
                    //    break;
                    case "12102":
                        HostName = dr["MonitorValue"].ToString();
                        break;
                    case "12103":
                        System = dr["MonitorValue"].ToString();
                        break;
                    case "12104":
                        IP = dr["MonitorValue"].ToString();
                        break;
                    case "12106":
                        WarningStatus = dr["MonitorValue"].ToString();
                        break;
                    case "12110":
                        ResponseTime = dr["MonitorValue"].ToString();
                        break;
                    case "14202":
                        SwapMemoryUtilization = dr["MonitorValue"].ToString();
                        break;
                    case "14205":
                        SwapMemoryUtilizationMB = dr["MonitorValue"].ToString();
                        break;
                    case "14203":
                        PhysicalpMemoryUtilization = dr["MonitorValue"].ToString();
                        break;
                    case "14206":
                        PhysicalpMemoryUtilizationMB = dr["MonitorValue"].ToString();
                        break;
                    case "14204":
                        FreePhysicalpMemory = dr["MonitorValue"].ToString();
                        break;
                    case "14102":
                        CPUMemoryUtilization = dr["MonitorValue"].ToString();
                        break;
                }
            }
        }

        

    }
}
