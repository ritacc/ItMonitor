using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.PerfMonitor
{
    public class PrefApplicationDA : DALBase
    {
        #region 应用树列表
        public DataTable GetTopBuss()
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perfValue,--性能
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
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perfValue,--性能
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
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perfValue,--性能
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
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perfValue,--性能
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
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  performance
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
    }
}