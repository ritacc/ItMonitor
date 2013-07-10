using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.AlertAdmin
{
    public class AlertDA : DALBase
    {
        public DataTable SlectAlertMonitor()
        {
            string sql = @"select mt.*,case when alterInfo.num is null then 0 else alterInfo.num end num
 from t_MonitorType  mt
left join (
select typeid,count(*) num
from t_AlarmLog alar
inner join t_Device d  on alar.DeviceID= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
group by typeid
 ) as alterInfo on alterInfo.typeid= mt.typeid";
            return db.ExecuteQuery(sql);
        }

        public DataTable SelectErrorList(int pageCrrent, int pageSize, out int pageCount,string mType)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,su.DISPLAY_NAME,d.DeviceName
,alar.Content,alar.HappenTime,alar.AlarmLogID
from t_AlarmLog alar 
inner join t_Device d  on alar.DeviceID= d.DeviceID 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join T_SYS_USERS su on su.guid= alar.OperateUserID
where typeid={0}
order by HappenTime desc
", mType);
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

        public PerfNetAlarmOR SelectErrorNews(string m_id)
        {
            string sql = string.Format("select * from t_AlarmLog where AlarmLogID='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            PerfNetAlarmOR m_obj = new PerfNetAlarmOR(dr);
            return m_obj;
        }
    }
}
