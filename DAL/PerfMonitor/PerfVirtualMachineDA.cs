using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class PerfVirtualMachineDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select dt.TypeName,d.*,
case(tm.MonitorValue) when '故障' then 0 when '未启动' then 3 else 1 end  stateNO
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join t_TmpValue tm on tm.DeviceID = d.deviceid and tm.ChannelNO = 11103 
where dt.typeid=9 ";
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
        public PerfVirtualOR SelectVirtualDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfVirtualOR obj = new PerfVirtualOR(dt);
            return obj;
        }

        /// <summary>
        /// 虚拟机操作系统
        /// </summary>
        public DataTable selectVirtualSystem(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,d.Performance,CPUUtilization.MonitorValue CPUUtilization,MemoryUtilization.MonitorValue MemoryUtilization,
DiskUtilization.MonitorValue DiskUtilization,NetworkUtilization.MonitorValue NetworkUtilization,
WarningStatus.MonitorValue WarningStatus,
case d.Performance when '故障' then 0 when  '报警' then 2 when '未启动' then 3 else 1 end  perf,
case WarningStatus.MonitorValue when '异常' then 0 when '未启动' then 3 else 1 end Warning
 from t_DevItemList d 
left join t_TmpValue CPUUtilization on CPUUtilization.DeviceID= d.DeviceID and CPUUtilization.ChannelNO=91103
left join t_TmpValue MemoryUtilization on MemoryUtilization.DeviceID= d.DeviceID and MemoryUtilization.ChannelNO=91204
left join t_TmpValue DiskUtilization on DiskUtilization.DeviceID= d.DeviceID and DiskUtilization.ChannelNO=14301
left join t_TmpValue NetworkUtilization on NetworkUtilization.DeviceID= d.DeviceID and NetworkUtilization.ChannelNO=91403
left join t_TmpValue WarningStatus on WarningStatus.DeviceID= d.DeviceID and WarningStatus.ChannelNO=11101
where d.DeviceTypeID= 915 and ParentDevID ={0} order by DeviceName", ParentDevID);
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