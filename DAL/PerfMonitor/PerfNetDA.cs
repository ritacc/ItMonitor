using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class PerfNetDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select dt.TypeName,d.*,
case(d.Performance) when '故障' then 0 when  '报警' then 2 when '未启动' then 3 else 1 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where dt.typeid=8 and ParentDevID is NULL";
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
        public PerfNetDetailOR SelectDeviceDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfNetDetailOR obj = new PerfNetDetailOR(dt);
            //加载网络接口
            obj.SubProts = GetNetPorts(mDeviceID);
            return obj;
        }

        private DataTable GetNetPorts(string mDeviceID)
        {
            string sql = string.Format(@"select d.Describe descInfo,js.MonitorValue resave, fs.MonitorValue fsm, cws.MonitorValue cwsm,
 dt.TypeName,d.*,
case(d.Performance) when '故障' then 0 when  '报警' then 2 when '未启动' then 3 else 1 end  performanceVal
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue js on js.DeviceID= d.DeviceID and js.ChannelNO=63
left join  t_TmpValue fs on fs.DeviceID= d.DeviceID and fs.ChannelNO=64
left join  t_TmpValue cws on cws.DeviceID= d.DeviceID and cws.ChannelNO=11
where ParentDevID={0} order by DeviceName", mDeviceID);
           
           
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

        /// <summary>
        /// 根据网络设备ID，查询详细信息
        /// </summary>
        /// <param name="mDeviceID"></param>
        /// <returns></returns>
        public PerNetPortDetailOR SelectNetPortDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerNetPortDetailOR obj = new PerNetPortDetailOR(dt);
           
            return obj;
        }

    }
}
