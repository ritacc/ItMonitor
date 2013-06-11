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
            string sql = @"select dt.TypeName,dev.*,
case tvSta.MonitorValue when '正常' then '1' else  '0' end DeviceStatus--状态
 from t_Device  dev
left join t_DeviceType dt on dev.DeviceTypeID = dt.DeviceTypeID
left join  t_TmpValue tvSta on  dev.deviceid=tvSta.deviceid and  tvSta.ChannelNo=11103 
where dt.typeid=2";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            sql += " order by DeviceName desc";
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