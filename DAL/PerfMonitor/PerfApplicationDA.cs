using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class PerfApplicationDA : DALBase
    {
        #region 应用树列表
        public DataTable GetTopBuss()
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf,--性能
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态
where bus.ParentId= -1 ";
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf,--性能
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态 
where bus.ParentId={0} ", DeviceID);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID, int typeid)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf,--性能
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态 
where bus.ParentId={0} and dt.typeid={1} ", DeviceID, typeid);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID, string strWhere)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf,--性能
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvSta on  d.deviceid=tvSta.deviceid and  tvSta.ChannelNo=11103 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态 
where bus.ParentId={0} and {1} ", DeviceID, strWhere);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        #endregion

        /// <summary>
        /// 查询应用系统
        /// </summary>
        /// <returns></returns>
        public DataTable SelectApplicationSystem()
        {

            string sql = @"select d.Describe descInfo, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where dt.typeid=2 ";

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

        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select d.Describe descInfo, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where dt.typeid=2 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} and  {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0;
            try
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
        public PerfApplicationOR SelectPerfApplication(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfApplicationOR obj = new PerfApplicationOR(dt);
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
            string sql = string.Format(@"select d.LastPollingTime,OneJob.MonitorValue OneJob,FiveJob.MonitorValue FiveJob,
FifteenJob.MonitorValue FifteenJob,OneJobPeak.MonitorValue OneJobPeak,FiveJobPeak.MonitorValue FiveJobPeak,
FifteenJobPeak.MonitorValue FifteenJobPeak
 from t_Device d 
left join t_TmpValue OneJob on OneJob.DeviceID= d.DeviceID and OneJob.ChannelNO=25601
left join t_TmpValue FiveJob on FiveJob.DeviceID= d.DeviceID and FiveJob.ChannelNO=25602
left join t_TmpValue FifteenJob on FifteenJob.DeviceID= d.DeviceID and FifteenJob.ChannelNO=25603
left join t_TmpValue OneJobPeak on OneJobPeak.DeviceID= d.DeviceID and OneJobPeak.ChannelNO=25601
left join t_TmpValue FiveJobPeak on FiveJobPeak.DeviceID= d.DeviceID and FiveJobPeak.ChannelNO=25602
left join t_TmpValue FifteenJobPeak on FifteenJobPeak.DeviceID= d.DeviceID and FifteenJobPeak.ChannelNO=25603
where d.DeviceTypeID= 256 and ParentDevID ={0} order by d.LastPollingTime desc", ParentDevID);
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
            string sql = string.Format(@"select Process.MonitorValue Process,HealthStatus.MonitorValue HealthStatus,
CurrentlyState.MonitorValue CurrentlyState,ExampleNO.MonitorValue ExampleNO,Memory.MonitorValue Memory,
CPU.MonitorValue CPU
 from t_Device d 
left join t_TmpValue Process on Process.DeviceID= d.DeviceID and Process.ChannelNO=25701
left join t_TmpValue HealthStatus on HealthStatus.DeviceID= d.DeviceID and HealthStatus.ChannelNO=25702
left join t_TmpValue CurrentlyState on CurrentlyState.DeviceID= d.DeviceID and CurrentlyState.ChannelNO=25703
left join t_TmpValue ExampleNO on ExampleNO.DeviceID= d.DeviceID and ExampleNO.ChannelNO=25704
left join t_TmpValue Memory on Memory.DeviceID= d.DeviceID and Memory.ChannelNO=25705
left join t_TmpValue CPU on CPU.DeviceID= d.DeviceID and CPU.ChannelNO=25706
where d.DeviceTypeID= 257 and ParentDevID ={0} order by Process", ParentDevID);
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
            string sql = string.Format(@"select DiskName.MonitorValue DiskName,DiskUsage.MonitorValue DiskUsage,
Used.MonitorValue Used,UsedMB.MonitorValue UsedMB,Free.MonitorValue Free,
FreeMB.MonitorValue FreeMB
 from t_Device d 
left join t_TmpValue DiskName on DiskName.DeviceID= d.DeviceID and DiskName.ChannelNO=25801
left join t_TmpValue DiskUsage on DiskUsage.DeviceID= d.DeviceID and DiskUsage.ChannelNO=25802
left join t_TmpValue Used on Used.DeviceID= d.DeviceID and Used.ChannelNO=25803
left join t_TmpValue UsedMB on UsedMB.DeviceID= d.DeviceID and UsedMB.ChannelNO=25804
left join t_TmpValue Free on Free.DeviceID= d.DeviceID and Free.ChannelNO=25805
left join t_TmpValue FreeMB on FreeMB.DeviceID= d.DeviceID and FreeMB.ChannelNO=25806
where d.DeviceTypeID= 258 and ParentDevID ={0} order by DiskName", ParentDevID);
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
            string sql = string.Format(@"select PageSpace.MonitorValue PageSpace,PageSpaceSize.MonitorValue PageSpaceSize,
Used.MonitorValue Used,UsedMB.MonitorValue UsedMB,Free.MonitorValue Free,
FreeMB.MonitorValue FreeMB
 from t_Device d 
left join t_TmpValue PageSpace on PageSpace.DeviceID= d.DeviceID and PageSpace.ChannelNO=26001
left join t_TmpValue PageSpaceSize on PageSpaceSize.DeviceID= d.DeviceID and PageSpaceSize.ChannelNO=26002
left join t_TmpValue Used on Used.DeviceID= d.DeviceID and Used.ChannelNO=26003
left join t_TmpValue UsedMB on UsedMB.DeviceID= d.DeviceID and UsedMB.ChannelNO=26004
left join t_TmpValue Free on Free.DeviceID= d.DeviceID and Free.ChannelNO=26005
left join t_TmpValue FreeMB on FreeMB.DeviceID= d.DeviceID and FreeMB.ChannelNO=26006
where d.DeviceTypeID= 260 and ParentDevID ={0} order by PageSpace", ParentDevID);
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
            string sql = string.Format(@"select Equipment.MonitorValue Equipment,ReadS.MonitorValue ReadS,
WriteS.MonitorValue WriteS,TransportS.MonitorValue TransportS
 from t_Device d 
left join t_TmpValue Equipment on Equipment.DeviceID= d.DeviceID and Equipment.ChannelNO=25901
left join t_TmpValue ReadS on ReadS.DeviceID= d.DeviceID and ReadS.ChannelNO=25902
left join t_TmpValue WriteS on WriteS.DeviceID= d.DeviceID and WriteS.ChannelNO=25903
left join t_TmpValue TransportS on TransportS.DeviceID= d.DeviceID and TransportS.ChannelNO=25904
where d.DeviceTypeID= 259 and ParentDevID ={0} order by Equipment", ParentDevID);
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
