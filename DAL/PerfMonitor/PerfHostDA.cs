using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;
using System.Data.SqlClient;

namespace GDK.DAL.PerfMonitor
{
    public class PerfHostDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select dt.TypeName,d.*,
case(d.Performance) when '故障' then 0 when  '报警' then 2 when '未启动' then 3 else 1 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where dt.typeid=1 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} and  {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        /// <summary>
        /// 根据网络设备ID，查询详细信息
        /// </summary>
        /// <param name="mDeviceID"></param>
        /// <returns></returns>
        public PerfHostOR SelectHostDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfHostOR obj = new PerfHostOR(dt);
            //加载网络接口
            obj.SubProts = GetNetPorts(obj.Ports);
            return obj;
        }


        private DataTable GetNetPorts(string strPortinfo)
        {
            if (string.IsNullOrEmpty(strPortinfo))
                return null;
            string mWhere = "";
            //3#^#1705#^#1706#^#1707
            if (strPortinfo.IndexOf("#^#") > 0)
            {
                string[] strArr = strPortinfo.Replace("#^#", "$").Split('$');
                if (strArr.Length < 2)
                    return null;
                mWhere = " d.DeviceID=" + strArr[1];
                for (int i = 2; i < strArr.Length; i++)
                {
                    mWhere += " or d.DeviceID=" + strArr[i];
                }
            }

            string sql = @"select * from dbo.t_TmpValue where " + mWhere;

            sql = string.Format(" {0} and  {1}", sql, mWhere);

            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;

        }


        // 系统负荷 - 最近一小时
        public DataTable selecSystemLoad(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select OneJob.MonitorValue OneJob,FiveJob.MonitorValue FiveJob,
FifteenJob.MonitorValue FifteenJob,OneJobPeak.MonitorValue OneJobPeak,FiveJobPeak.MonitorValue FiveJobPeak,
FifteenJobPeak.MonitorValue FifteenJobPeak
 from t_DevItemList d 
left join t_TmpValue OneJob on OneJob.DeviceID= d.DeviceID and OneJob.ChannelNO=13101
left join t_TmpValue FiveJob on FiveJob.DeviceID= d.DeviceID and FiveJob.ChannelNO=13102
left join t_TmpValue FifteenJob on FifteenJob.DeviceID= d.DeviceID and FifteenJob.ChannelNO=13103
left join t_TmpValue OneJobPeak on OneJobPeak.DeviceID= d.DeviceID and OneJobPeak.ChannelNO=13201
left join t_TmpValue FiveJobPeak on FiveJobPeak.DeviceID= d.DeviceID and FiveJobPeak.ChannelNO=13202
left join t_TmpValue FifteenJobPeak on FifteenJobPeak.DeviceID= d.DeviceID and FifteenJobPeak.ChannelNO=13203
where d.DeviceTypeID= 132 and ParentDevID ={0}", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        // 进程明细
        public DataTable selecProcessDetail(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName,Process.MonitorValue Process,HealthStatus.MonitorValue HealthStatus,
CurrentlyState.MonitorValue CurrentlyState,ExampleNO.MonitorValue ExampleNO,Memory.MonitorValue Memory,
CPU.MonitorValue CPU
 from t_DevItemList d 
left join t_TmpValue Process on Process.DeviceID= d.DeviceID and Process.ChannelNO=13301
left join t_TmpValue HealthStatus on HealthStatus.DeviceID= d.DeviceID and HealthStatus.ChannelNO=13302
left join t_TmpValue CurrentlyState on CurrentlyState.DeviceID= d.DeviceID and CurrentlyState.ChannelNO=13303
left join t_TmpValue ExampleNO on ExampleNO.DeviceID= d.DeviceID and ExampleNO.ChannelNO=13304
left join t_TmpValue Memory on Memory.DeviceID= d.DeviceID and Memory.ChannelNO=13305
left join t_TmpValue CPU on CPU.DeviceID= d.DeviceID and CPU.ChannelNO=13306
where d.DeviceTypeID= 133 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        // 磁盘使用率
        public DataTable selecDiskUtilization(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName,DiskName.MonitorValue DiskName,DiskUsage.MonitorValue DiskUsage,
Used.MonitorValue Used,UsedMB.MonitorValue UsedMB,Free.MonitorValue Free,
FreeMB.MonitorValue FreeMB
 from t_DevItemList d 
left join t_TmpValue DiskName on DiskName.DeviceID= d.DeviceID and DiskName.ChannelNO=14301
left join t_TmpValue DiskUsage on DiskUsage.DeviceID= d.DeviceID and DiskUsage.ChannelNO=14302
left join t_TmpValue Used on Used.DeviceID= d.DeviceID and Used.ChannelNO=14303
left join t_TmpValue UsedMB on UsedMB.DeviceID= d.DeviceID and UsedMB.ChannelNO=14304
left join t_TmpValue Free on Free.DeviceID= d.DeviceID and Free.ChannelNO=14305
left join t_TmpValue FreeMB on FreeMB.DeviceID= d.DeviceID and FreeMB.ChannelNO=14306
where d.DeviceTypeID= 143 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        // 页面空间
        public DataTable selecPageSpace(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName,PageSpace.MonitorValue PageSpace,PageSpaceSize.MonitorValue PageSpaceSize,
Used.MonitorValue Used,UsedMB.MonitorValue UsedMB,Free.MonitorValue Free,
FreeMB.MonitorValue FreeMB
 from t_DevItemList d 
left join t_TmpValue PageSpace on PageSpace.DeviceID= d.DeviceID and PageSpace.ChannelNO=13401
left join t_TmpValue PageSpaceSize on PageSpaceSize.DeviceID= d.DeviceID and PageSpaceSize.ChannelNO=13402
left join t_TmpValue Used on Used.DeviceID= d.DeviceID and Used.ChannelNO=13403
left join t_TmpValue UsedMB on UsedMB.DeviceID= d.DeviceID and UsedMB.ChannelNO=13404
left join t_TmpValue Free on Free.DeviceID= d.DeviceID and Free.ChannelNO=13405
left join t_TmpValue FreeMB on FreeMB.DeviceID= d.DeviceID and FreeMB.ChannelNO=13406
where d.DeviceTypeID= 134 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }


        // 磁盘IO统计列表
        public DataTable selecDiskStatistics(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName, Equipment.MonitorValue Equipment,ReadS.MonitorValue ReadS,
WriteS.MonitorValue WriteS,TransportS.MonitorValue TransportS
 from t_DevItemList d 
left join t_TmpValue Equipment on Equipment.DeviceID= d.DeviceID and Equipment.ChannelNO=13501
left join t_TmpValue ReadS on ReadS.DeviceID= d.DeviceID and ReadS.ChannelNO=13502
left join t_TmpValue WriteS on WriteS.DeviceID= d.DeviceID and WriteS.ChannelNO=13503
left join t_TmpValue TransportS on TransportS.DeviceID= d.DeviceID and TransportS.ChannelNO=13504
where d.DeviceTypeID= 135 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        // 网络接口
        public DataTable selecNetworksPort(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName, PortName.MonitorValue PortName,HealthStatus.MonitorValue HealthStatus,
Rate.MonitorValue Rate,InputFlow.MonitorValue InputFlow,
OutputFlow.MonitorValue OutputFlow,Error.MonitorValue Error
 from t_DevItemList d 
left join t_TmpValue PortName on PortName.DeviceID= d.DeviceID and PortName.ChannelNO=14501
left join t_TmpValue HealthStatus on HealthStatus.DeviceID= d.DeviceID and HealthStatus.ChannelNO=14502
left join t_TmpValue Rate on Rate.DeviceID= d.DeviceID and Rate.ChannelNO=14503
left join t_TmpValue InputFlow on InputFlow.DeviceID= d.DeviceID and InputFlow.ChannelNO=14504
left join t_TmpValue OutputFlow on OutputFlow.DeviceID= d.DeviceID and OutputFlow.ChannelNO=14505
left join t_TmpValue Error on Error.DeviceID= d.DeviceID and Error.ChannelNO=14506
where d.DeviceTypeID= 145 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        // 服务明细
        public DataTable selecServiceDetail(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName, DisplayName.MonitorValue DisplayName,ServiceName.MonitorValue ServiceName,
Availability.MonitorValue Availability
 from t_DevItemList d 
left join t_TmpValue DisplayName on DisplayName.DeviceID= d.DeviceID and DisplayName.ChannelNO=13701
left join t_TmpValue ServiceName on ServiceName.DeviceID= d.DeviceID and ServiceName.ChannelNO=13702
left join t_TmpValue Availability on Availability.DeviceID= d.DeviceID and Availability.ChannelNO=13703
where d.DeviceTypeID= 137 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        // 最近从事件日志来的事件
        public DataTable selecEvent(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.DeviceName, RuleName.MonitorValue RuleName,LogFileType.MonitorValue LogFileType,
Source.MonitorValue Source,EventID.MonitorValue EventID,EventType.MonitorValue EventType,
UserName.MonitorValue UserName,Describe.MonitorValue Describe,LogGenerationTime.MonitorValue LogGenerationTime
 from t_DevItemList d 
left join t_TmpValue RuleName on RuleName.DeviceID= d.DeviceID and RuleName.ChannelNO=13601
left join t_TmpValue LogFileType on LogFileType.DeviceID= d.DeviceID and LogFileType.ChannelNO=13602
left join t_TmpValue Source on Source.DeviceID= d.DeviceID and Source.ChannelNO=13603
left join t_TmpValue EventID on EventID.DeviceID= d.DeviceID and EventID.ChannelNO=13604
left join t_TmpValue EventType on EventType.DeviceID= d.DeviceID and EventType.ChannelNO=13605
left join t_TmpValue UserName on UserName.DeviceID= d.DeviceID and UserName.ChannelNO=13606
left join t_TmpValue Describe on Describe.DeviceID= d.DeviceID and Describe.ChannelNO=13607
left join t_TmpValue LogGenerationTime on LogGenerationTime.DeviceID= d.DeviceID and LogGenerationTime.ChannelNO=13608
where d.DeviceTypeID= 136 and ParentDevID ={0} order by d.DeviceName", ParentDevID);
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }
    }
}