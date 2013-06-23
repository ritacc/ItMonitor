using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class PerNetPortDetailOR
    {

        public PerNetPortDetailOR()
       {

       }

        /// <summary>
        /// 3 上级名
        /// </summary>
        public string SuperiorName { get; set; }

        /// <summary>
        /// 4 索引
        /// </summary>
        public string Index { get; set; }

        /// <summary>
        /// 5物理地址
        /// </summary>
        public string PhysicalAddress { get; set; }

        /// <summary>
        /// 6接收宽带
        /// </summary>
        public string ReceiveBroadband { get; set; }

        /// <summary>
        /// 7发送宽带
        /// </summary>
        public string SendBroadband { get; set; }

        /// <summary>
        /// 8当前流量接收
        /// </summary>
        public string CurrentlyReceivingTraffic { get; set; }

        /// <summary>
        /// 9当前流量发送
        /// </summary>
        public string CurrentSendTraffic { get; set; }

        /// <summary>
        /// 使用率 接收
        /// </summary>
        public string UtilizationReceive { get; set; }

        /// <summary>
        /// 使用率 发送
        /// </summary>
        public string UtilizationSend { get; set; }

        /// <summary>
        /// 每秒包数量 接收
        /// </summary>
        public string ReceiveNoS { get; set; }

        /// <summary>
        /// 每秒包数量 发送
        /// </summary>
        public string SendNos { get; set; }

        /// <summary>
        /// 数据包平均尺寸 接收
        /// </summary>
        public string AverageSizeReceive { get; set; }

        /// <summary>
        /// 数据包平均尺寸 发送
        /// </summary>
        public string AverageSizeSend { get; set; }
        
        /// <summary>
        /// 消息
        /// </summary>
        public string From { get; set; }

        /// <summary>
        /// 电路ID
        /// </summary>
        public string CircuitID { get; set; }

        /// <summary>
        /// 操作状态
        /// </summary>
        public string OperatingStatus { get; set; }

        /// <summary>
        /// 管理状态
        /// </summary>
        public string ManagementState { get; set; }        
                 
        public PerNetPortDetailOR(DataTable dt)
        {
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["ChannelNO"].ToString())
                {
                    case "34001":
                        CircuitID = dr["MonitorValue"].ToString();
                        break;
                    case "34002":
                        SuperiorName = dr["MonitorValue"].ToString();
                        break;
                    case "34003":
                        Index = dr["MonitorValue"].ToString();
                        break;
                    case "34004":
                        ManagementState = dr["MonitorValue"].ToString();
                        break;
                    case "34005":
                        OperatingStatus = dr["MonitorValue"].ToString();
                        break;
                    case "35001":
                        ReceiveBroadband = dr["MonitorValue"].ToString();
                        break;
                    case "35002":
                        SendBroadband = dr["MonitorValue"].ToString();
                        break;
                    case "33001":
                        CurrentlyReceivingTraffic = dr["MonitorValue"].ToString();
                        break;
                    case "33002":
                        CurrentSendTraffic = dr["MonitorValue"].ToString();
                        break;
                    case "35003":
                        UtilizationReceive = dr["MonitorValue"].ToString();
                        break;
                    case "35004":
                        UtilizationSend = dr["MonitorValue"].ToString();
                        break;
                    case "35005":
                        ReceiveNoS = dr["MonitorValue"].ToString();
                        break;
                    case "35006":
                        SendNos = dr["MonitorValue"].ToString();
                        break;
                    case "35007":
                        AverageSizeReceive = dr["MonitorValue"].ToString();
                        break;
                    case "35008":
                        AverageSizeSend = dr["MonitorValue"].ToString();
                        break;
                }
            }
        }
    }
}
