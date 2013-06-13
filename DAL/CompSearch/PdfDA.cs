using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.CompSearch;
using GDK.DAL.SerMonitor;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.CompSearch
{
   public class PdfDA:DALBase
    {
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public void  InitData(int DeviceID, int ChanncelNO, DateTime begin, DateTime end)
       {
           ReportSeachWhereOR whereOR = new ReportSeachWhereOR();
           whereOR.StartTime= begin;
            whereOR.EndTime=end;

          DeviceOR devObj=  new DeviceDA().SelectDeviceORByID(DeviceID.ToString());
          if (devObj == null)
          {
              throw new Exception("设备不存！");
          }
          whereOR.DeviceID = devObj.DeviceID;
          whereOR.DeviceName = devObj.DeviceName;
          whereOR.DeviceType = devObj.DeviceTypeID;
          whereOR.StationID = devObj.StationID;
          whereOR.ReportType = "month";
          whereOR.ListChanncel = new List<SearchChanncelOR>() { 
            new SearchChanncelOR(){ ChanncelNo= ChanncelNO}
          };

          ReportSeachDA DataDA = new ReportSeachDA();
          DataDA.SearchReportDataToTemp(whereOR);
       }

       /// <summary>
       /// 获取使用率曲线数据
       /// </summary>
       public DataTable GetUseLine()
       {
           string sql = @"select deviceno,channelno,monitordate,round( avg(monitorvalue),2) val from ReportTemp
group by deviceno,channelno,monitordate";

           return db.ExecuteQuery(sql);
       }

       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
       public DataTable GetUseTableInfo()
       {
           string sql = @"
select sf.*,d.DeviceName, d.ip,
case when avgval< 20 and maxval< 100 then '极低'
	  when avgval< 60 and maxval<= 100 and maxnum< 200 then '正常'  
	  when avgval< 60 and maxval<= 100 and maxnum> 200 then '高压' 
	  when avgval> 60 and avgval<= 80  then '警戒' 
	  when  avgval> 80  then '报警' 
end Status
from (
	select deviceno,channelno--,monitordate
	,round( avg(monitorvalue),2) avgval
	,max(monitorvalue) maxval,sum(num) maxNum
	 from
	(
		select t.*,case when monitorvalue > 80 then 1 else 0 end as Num
		from ReportTemp t
	) as f
	group by deviceno,channelno--,monitordate
) as sf
left join t_Device d on sf.deviceno= d.deviceid
--order by monitordate desc";
           return db.ExecuteQuery(sql);
       }
    }
}
