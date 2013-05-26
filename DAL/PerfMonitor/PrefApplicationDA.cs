using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.PerfMonitor
{
    public class PrefApplicationDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select d.Describe descInfo, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  performance
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue xl on xl.DeviceID= d.DeviceID and xl.ChannelNO=11101 
left join  t_TmpValue ms on ms.DeviceID= d.DeviceID and ms.ChannelNO=11102
where dt.typeid=2 ";
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
    }
}