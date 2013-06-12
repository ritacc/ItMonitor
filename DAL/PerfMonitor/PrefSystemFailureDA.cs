using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.PerfMonitor
{
    public class PrefSystemFailureDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,su.DISPLAY_NAME,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perfValue--性能
,alar.Content,alar.HappenTime
from t_AlarmLog alar
inner join t_Device d  on alar.DeviceID= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join T_SYS_USERS su on su.guid= alar.OperateUserID
";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format("{0} where {1}", sql, where);
            }
            sql += " order by HappenTime";
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