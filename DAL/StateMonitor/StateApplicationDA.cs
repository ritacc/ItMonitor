using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.StateMonitor
{
    public class StateApplicationDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where dt.typeid=12 ";
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

        public DataTable GetTopBuss()
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case tvSta.MonitorValue when '正常' then '1' else  '0' end DeviceStatus, tvSta.MonitorValue DeviceStatusName,--状态
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvSta on  d.deviceid=tvSta.deviceid and  tvSta.ChannelNo=11103 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态
where bus.ParentId= -1 ";
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case tvSta.MonitorValue when '正常' then '1' else  '0' end DeviceStatus, tvSta.MonitorValue DeviceStatusName,--状态
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvSta on  d.deviceid=tvSta.deviceid and  tvSta.ChannelNo=11103 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态 
where bus.ParentId={0} ", DeviceID);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID,int typeid)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case tvSta.MonitorValue when '正常' then '1' else  '0' end DeviceStatus, tvSta.MonitorValue DeviceStatusName,--状态
case tvalter.MonitorValue when '正常' then '1' else  '0' end WarningStatus,tvalter.MonitorValue WarningStatusName--告警状态
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue tvSta on  d.deviceid=tvSta.deviceid and  tvSta.ChannelNo=11103 
left join  t_TmpValue tvalter on  d.deviceid=tvalter.deviceid and  tvalter.ChannelNo=11107--告警状态 
where bus.ParentId={0} and dt.typeid={1} ", DeviceID, typeid);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID, string strWhere)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case tvSta.MonitorValue when '正常' then '1' else  '0' end DeviceStatus, tvSta.MonitorValue DeviceStatusName,--状态
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

    }
}