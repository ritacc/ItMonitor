using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.StateMonitor
{
    public class StateListDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select dt.TypeName,dev.*,
case tvSta.MonitorValue when '正常' then '1' else  '0' end DeviceStatus--状态
 from t_Device  dev
left join t_DeviceType dt on dev.DeviceTypeID = dt.DeviceTypeID
left join  t_TmpValue tvSta on  dev.deviceid=tvSta.deviceid and  tvSta.ChannelNo=11103 ";
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

    }
}
