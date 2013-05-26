using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class PerfDBOR
    {

        public PerfDBOR()
        {

        }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string ServName { get; set; }
                
        /// <summary>
        /// 健康状况
        /// </summary>
        public string HealthStatus { get; set; }

        /// <summary>
        /// 数据库类型
        /// </summary>
        public string ServType { get; set; }

        /// <summary>
        /// 数据库版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 数据库启动时间
        /// </summary>
        public string StartUpTime { get; set; }

        /// <summary>
        /// 端口
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 主机名称
        /// </summary>
        public string HostName { get; set; }


        /// <summary>
        /// 操作系统
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// 最后轮询时间
        /// </summary>
        public string LastPollingTime { get; set; }

        /// <summary>
        /// 下次轮询时间
        /// </summary>
        public string NextPollingTime { get; set; }

        /// <summary>
        /// 当前可用状态
        /// </summary>
        public string CurrentlyState{ get; set; }

        /// <summary>
        /// 正常运行时间
        /// </summary>
        public string Uptime { get; set; }

        /// <summary>
        /// 应用停止时间
        /// </summary>
        public string StopTime { get; set; }

        /// <summary>
        /// 连接时间
        /// </summary>
        public string ConnectionTime { get; set; }

        /// <summary>
        /// 用户数
        /// </summary>
        public string UserNO { get; set; }
        
        /// <summary>
        /// 数据库创建时间
        /// </summary>
        public string ServCreateTime { get; set; }

        /// <summary>
        /// Open模式
        /// </summary>
        public string OpenStyle { get; set; }
        
        /// <summary>
        /// Log模式
        /// </summary>
        public string LogStyle { get; set; }

        /// <summary>
        /// 缓冲区大小
        /// </summary>
        public string BufferSize { get; set; }

        /// <summary>
        /// 共享池大小
        /// </summary>
        public string ShareSize { get; set; }

        /// <summary>
        /// 重做日志缓冲器大小
        /// </summary>
        public string LogBufferSize { get; set; }

        /// <summary>
        /// 库缓存大小
        /// </summary>
        public string DatabaseSize { get; set; }

        /// <summary>
        /// 数据字典缓存大小
        /// </summary>
        public string DictionarySize { get; set; }

        /// <summary>
        /// SQL区大小
        /// </summary>
        public string SqlSize { get; set; }

        /// <summary>
        /// 固有区大小
        /// </summary>
        public string InherentSize { get; set; }

        /// <summary>
        /// JAVA池大小
        /// </summary>
        public string JavaSize { get; set; }

        /// <summary>
        /// Large池大小
        /// </summary>
        public string LargeSize { get; set; }
        
        /// <summary>
        /// 缓冲区击中率
        /// </summary>
        public string BufferHitRate { get; set; }

        /// <summary>
        /// 数据字典击中率
        /// </summary>
        public string DictionaryHitRate { get; set; }

        /// <summary>
        /// 缓存库
        /// </summary>
        public string DatabaseHitRate { get; set; }

        /// <summary>
        /// 可用内存
        /// </summary>
        public string AvailableMemory { get; set; }

        /// <summary>
        /// 数据库尺寸
        /// </summary>
        public string ServerSize { get; set; }

        /// <summary>
        /// 平均执行时间
        /// </summary>
        public string AverageExecutionTime { get; set; }

        /// <summary>
        /// 读次数
        /// </summary>
        public string ReadingTimes { get; set; }

        /// <summary>
        /// 写次数
        /// </summary>
        public string WritingTimes { get; set; }
 
        /// <summary>
        /// 块大小
        /// </summary>
        public string BlockSize { get; set; }

        /// <summary>
        /// 接口列表     3#^#1705#^#1706#^#1707
        /// </summary>
        public string Ports { get; set; }
                
        /// <summary>
        /// 网各设备的，接口列表
        /// </summary>
        public DataTable SubProts { get; set; }

        public PerfDBOR(DataTable dt)
        {
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["ChannelNO"].ToString())
                {
                    case "41001":
                        ServName = dr["MonitorValue"].ToString();
                        break;
                    case "41002":
                        HealthStatus = dr["MonitorValue"].ToString();
                        break;

                    case "41003":
                        ServType = dr["MonitorValue"].ToString();
                        break;

                    case "41004":
                        Version = dr["MonitorValue"].ToString();
                        break;

                    case "41005":
                        StartUpTime = dr["MonitorValue"].ToString();
                        break;

                    case "41006":
                        Port = dr["MonitorValue"].ToString();
                        break;

                    case "41007":
                        HostName = dr["MonitorValue"].ToString();
                        break;

                    case "41008":
                        System = dr["MonitorValue"].ToString();
                        break;

                    case "41009":
                        LastPollingTime = dr["MonitorValue"].ToString();
                        break;

                    case "41010":
                        NextPollingTime = dr["MonitorValue"].ToString();
                        break;

                    case "41011":
                        CurrentlyState = dr["MonitorValue"].ToString();
                        break;

                    case "41012":
                        Uptime = dr["MonitorValue"].ToString();
                        break;

                    case "41013":
                        StopTime = dr["MonitorValue"].ToString();
                        break;

                    case "41201":
                        UserNO = dr["MonitorValue"].ToString();
                        break;

                    case "41401":
                        ServCreateTime = dr["MonitorValue"].ToString();
                        break;

                    case "41402":
                        OpenStyle = dr["MonitorValue"].ToString();
                        break;

                    case "41501":
                        ServerSize = dr["MonitorValue"].ToString();
                        break;

                    case "41502":
                        AverageExecutionTime = dr["MonitorValue"].ToString();
                        break;

                    case "41503":
                        ReadingTimes = dr["MonitorValue"].ToString();
                        break;

                    case "41504":
                        WritingTimes = dr["MonitorValue"].ToString();
                        break;

                    case "41505":
                        BlockSize = dr["MonitorValue"].ToString();
                        break;

                    case "42403":
                        LogStyle = dr["MonitorValue"].ToString();
                        break;

                    case "45201":
                        BufferSize = dr["MonitorValue"].ToString();
                        break;

                    case "45202":
                        ShareSize = dr["MonitorValue"].ToString();
                        break;

                    case "45203":
                        LogBufferSize = dr["MonitorValue"].ToString();
                        break;

                    case "45204":
                        DatabaseSize = dr["MonitorValue"].ToString();
                        break;

                    case "45205":
                        DictionarySize = dr["MonitorValue"].ToString();
                        break;

                    case "45206":
                        SqlSize = dr["MonitorValue"].ToString();
                        break;

                    case "45207":
                        InherentSize = dr["MonitorValue"].ToString();
                        break;

                    case "45208":
                        JavaSize = dr["MonitorValue"].ToString();
                        break;

                    case "45209":
                        LargeSize = dr["MonitorValue"].ToString();
                        break;

                    case "45301":
                        BufferHitRate = dr["MonitorValue"].ToString();
                        break;

                    case "45302":
                        DictionaryHitRate = dr["MonitorValue"].ToString();
                        break;

                    case "45303":
                        DatabaseHitRate = dr["MonitorValue"].ToString();
                        break;

                    case "45304":
                        AvailableMemory = dr["MonitorValue"].ToString();
                        break;


                }

            }
        }

    }
}
