using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.PerfMonitor
{
    public class DeviceDA:DALBase
    {
        #region  查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select xl.MonitorValue performance,ms.MonitorValue descInfo, dt.TypeName,d.* from t_Device d inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID left join  t_TmpValue xl on xl.DeviceID= d.DeviceID and xl.ChannelNO=11101 left join  t_TmpValue ms on ms.DeviceID= d.DeviceID and ms.ChannelNO=11102";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
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


        public DataTable selectDetailDateByWhere(string id)
        {
            string sql = "select t.*,tv.MonitorValue from  t_Channel t left join  t_TmpValue tv on  t.deviceid=tv.deviceid and t.channelno= tv.channelno where DeviceID="+id;
           
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        #endregion
    }
}
