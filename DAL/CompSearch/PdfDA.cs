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
		  List<int> ListDevs = new List<int>();
		  ListDevs.Add(devObj.DeviceID);

		  whereOR.ListDevices = ListDevs;

          //whereOR.DeviceName = devObj.DeviceName;
          //whereOR.DeviceType = devObj.DeviceTypeID;
          whereOR.StationID = devObj.StationID;
          whereOR.ReportType = "month";
          whereOR.ListChanncel = new List<SearchChanncelOR>() { 
            new SearchChanncelOR(){ ChanncelNo= ChanncelNO}
          };

		  PDFReportSearch DataDA = new PDFReportSearch();
          DataDA.SearchReportDataToTemp(whereOR);
       }
	   #region 数据库处理
	   /// <summary>
	   /// 
	   /// </summary>
	   /// <returns></returns>
	   public void SecondInit(int DeviceID,DateTime begin, DateTime end)
	   {
		   ReportSeachWhereOR whereOR = new ReportSeachWhereOR();
		   whereOR.StartTime = begin;
		   whereOR.EndTime = end;

		   DeviceOR devObj = new DeviceDA().SelectDeviceORByID(DeviceID.ToString());
		   if (devObj == null)
		   {
			   throw new Exception("设备不存！");
		   }
		   List<int> ListDevs = new List<int>();
		   ListDevs.Add(devObj.DeviceID);
		   //获取数据库设备
		   whereOR.ListDevices = GetBussDataBase(DeviceID);

		  // whereOR.DeviceName = devObj.DeviceName;

		  // whereOR.DeviceType = devObj.DeviceTypeID;
		   whereOR.StationID = devObj.StationID;
		   whereOR.ReportType = "month";
		   /*
		    --表空间	421
--连接数	42109
--%可用		42105

--直接数据库
--击中率
--41601		--缓冲器
--41602		--数据字典
--41603		--库
--41101		连接时间
		    * 
		    * */
		   whereOR.ListChanncel = new List<SearchChanncelOR>() { 
            new SearchChanncelOR(){ ChanncelNo= 42109}//--连接数
			,new SearchChanncelOR(){ ChanncelNo= 42105}//--%可用
			,new SearchChanncelOR(){ ChanncelNo= 41601}	//缓冲器
			,new SearchChanncelOR(){ ChanncelNo= 41602}	//数据字典
			,new SearchChanncelOR(){ ChanncelNo= 41603}	//库
			,new SearchChanncelOR(){ ChanncelNo= 41101}	//连接时间
          };

		   PDFReportSearch DataDA = new PDFReportSearch();
		   DataDA.SearchReportDataToTemp(whereOR);
	   }

	   #endregion
	   /// <summary>
       /// 获取使用率曲线数据
       /// </summary>
       public DataTable GetUseLine()
       {
           string sql = @"select deviceno,channelno,monitordate,round( avg(monitorvalue),2) val from ReportTemp
group by deviceno,channelno,monitordate";

           return db.ExecuteQuery(sql);
       }

	   public List<int> GetBussDataBase(int busDeviceID)
	   {
		   string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID
where bus.ParentId= {0} and dt.TypeID=4", busDeviceID);
		   DataTable dt= db.ExecuteQuery(sql);
		   List<int> deviceids = new List<int>();
		   if (dt != null && dt.Rows.Count > 0)
		   {
			   foreach (DataRow dr in dt.Rows)
			   {
				   deviceids.Add(Convert.ToInt32(dr["DeviceID"].ToString()));
			   }
		   }
		   return deviceids;
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
	,max(monitorvalue) maxval
	,sum(num) maxNum
	,round(avg(case when dateDay>=1 and dateDay<=5 then monitorvalue  end),2) avgNum15
	,round(avg(case when dateDay>=11 and dateDay<=15 then monitorvalue  end),2) avgNum1115
	,round(avg(case when dateDay>=25 and dateDay<=31 then monitorvalue  end),2) avgNum2531
	,sum(case when dateDay>=1 and dateDay<=5 and Num=1 then 1 else 0 end) MaxNum15
	,sum(case when dateDay>=11 and dateDay<=15 and Num=1 then 1 else 0 end) MaxNum1115
	,sum(case when dateDay>=25 and dateDay<=31 and Num=1 then 1 else 0 end) MaxNum2531
	 from
	(
		select t.*
			,datepart(dd,MonitorTime) dateDay
			,case when monitorvalue > 80 then 1 else 0 end as Num
		from ReportTemp t
	) as f
	group by deviceno,channelno--,monitordate
) as sf
left join t_Device d on sf.deviceno= d.deviceid
";
           return db.ExecuteQuery(sql);
       }
    }
}
