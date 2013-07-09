using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
    }
}
