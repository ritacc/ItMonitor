using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.StateMonitor;
using GDK.DAL.PerfMonitor;

namespace GDK.DAL.StateMonitor
{
    public class StateCompRoomEnviDA : DALBase
    {

        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select distinct dt.TypeName,d.*,al.Content,
case(d.Performance) when '故障' then 0 when  '报警' then 2 when '未启动' then 3 else 1 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join t_AlarmLog al on al.Deviceid= d.deviceid
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
        /// <summary>
        /// 根据网络设备ID，查询详细信息
        /// </summary>
        /// <param name="mDeviceID"></param>
        /// <returns></returns>
        public StateCompRoomEnviOR SelectDeviceDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            StateCompRoomEnviOR obj = new StateCompRoomEnviOR(dt);

            return obj;
        }




    }
}