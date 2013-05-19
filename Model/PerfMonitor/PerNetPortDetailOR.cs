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
        /// 1 接口名
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 2 IP地址
        /// </summary>
        public string IP { get; set; }

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
        /// 8当前上传速度
        /// </summary>
        public string CurrentUploadSpeed { get; set; }

        /// <summary>
        /// 9当前下载速度
        /// </summary>
        public string CurrentDownloadSpeed { get; set; }

        /// <summary>
        /// 9999通讯状态
        /// </summary>
        public string CommunicationStatus { get; set; }

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
                    case "1":
                        Port = dr["MonitorValue"].ToString();
                        break;
                    case "2":
                        IP = dr["MonitorValue"].ToString();
                        break;
                    case "3":
                        SuperiorName = dr["MonitorValue"].ToString();
                        break;
                    case "4":
                        Index = dr["MonitorValue"].ToString();
                        break;
                    case "5":
                        PhysicalAddress = dr["MonitorValue"].ToString();
                        break;
                    case "6":
                        ReceiveBroadband = dr["MonitorValue"].ToString();
                        break;
                    case "7":
                        SendBroadband = dr["MonitorValue"].ToString();
                        break;
                    case "8":
                        CurrentUploadSpeed = dr["MonitorValue"].ToString();
                        break;
                    case "9":
                        CurrentDownloadSpeed = dr["MonitorValue"].ToString();
                        break;
                    case "9999":
                        CommunicationStatus = dr["MonitorValue"].ToString();
                        break;
                    case "11103":
                        ManagementState = dr["MonitorValue"].ToString();
                        break;
                }
            }
        }
    }
}
