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

	   public void SecondMiddlewareInit(int DeviceID, DateTime begin, DateTime end)
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
		   //获取中间件
		   whereOR.ListDevices = GetBussMiddleware(DeviceID);
		   whereOR.StationID = devObj.StationID;
		   whereOR.ReportType = "month";
		   /*
			* web	活动会话数	21102
		    * 数据库连接池 活动连接	22603
		    * 当前 JVM堆大小(kb)	22505
		    * */
		   whereOR.ListChanncel = new List<SearchChanncelOR>() { 
            new SearchChanncelOR(){ ChanncelNo= 21102}//--活动会话数
			,new SearchChanncelOR(){ ChanncelNo= 22603}//--活动连接
			,new SearchChanncelOR(){ ChanncelNo= 22505}	//JVM堆大小
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

	   public List<int> GetBussMiddleware(int busDeviceID)
	   {
		   string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID
where bus.ParentId= {0} and dt.TypeID=10", busDeviceID);
		   DataTable dt = db.ExecuteQuery(sql);
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

       #region 二、数据库使用情况统计分析

       /// <summary>
       /// 1. 表空间汇总统计
       /// </summary>
       /// <returns></returns>
       public DataTable SlectDBNameSpanceUse()
       {
           string sql = @"select monitordate,round(AVG(monitorvalue),2) monitorvalue from ReportTemp where channelno=42105
group by monitordate order by monitordate";
           return db.ExecuteQuery(sql);
       }

       public DataTable SlectDBNameSpanceUseDetail(int Year,int Month,int BussID)
       {
           DateTime Start=new DateTime(Year,Month,1);

           string sql = string.Format(@"select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*
	,sy.monitorvalue as syValue ,ROUND( (gro.monitorvalue- sy.monitorvalue)/sy.monitorvalue,2)*100 tb
from (
	select deviceno,channelno,round(AVG(monitorvalue),2) monitorvalue from ReportTemp	
	where channelno=42105 and MonitorTime >='{0} 00:00:00' and MonitorTime <='{1} 23:59:59'
	group by deviceno,channelno	
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno 
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id  and bus.parentid={2}
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
left join 
(
		select deviceno,channelno,round(AVG(monitorvalue),2) monitorvalue from ReportTemp
		where channelno=42105 and MonitorTime >='{3} 00:00:00' and MonitorTime <='{4} 23:59:59'
		group by deviceno,channelno
) as sy on sy.deviceno= gro.deviceno and sy.channelno= gro.channelno
order by deviceno,channelno", Start.ToString("yyyy-MM-dd")
           , Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
           , BussID
           , Start.AddMonths(-1).ToString("yyyy-MM-dd")
           , Start.AddDays(-1).ToString("yyyy-MM-dd"));
           return db.ExecuteQuery(sql);
       }

       /// <summary>
       ///2. 根据通道号-查询命中率
       /// </summary>
       /// <param name="ChanncelNo"></param>
       /// <returns></returns>
       public DataTable SelectMZLImg(int ChanncelNo)
       {
           string sql =string.Format(@"select  monitordate,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
from ReportTemp	
where channelno={0} 
group by monitordate
order by monitordate",ChanncelNo);
           return db.ExecuteQuery(sql);
       }

       public DataTable SelectMZLDetail(int Year, int Month)
       {
           DateTime Start = new DateTime(Year, Month, 1);

           string sql = string.Format(@"select d.DeviceName, hcq.deviceno,hcq.maxval hcqmax,hcq.minval hcqmin,hcq.avgval hcqavg
,sjzd.maxval sjzdmax,sjzd.minval sjzdmin,sjzd.avgval sjzdavg
,k.maxval	kmax,	k.minval	kmin,k.avgval kavg
from (
	select  deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,
	round(AVG(monitorvalue),2) avgval from ReportTemp	 
	where channelno=41601 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno
) as hcq
left join (
	select  deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,
	round(AVG(monitorvalue),2) avgval from ReportTemp	 
	where channelno=41602 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno
) as sjzd   on hcq.deviceno= sjzd.deviceno
left join (
	select  deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,
	round(AVG(monitorvalue),2) avgval from ReportTemp	 
	where channelno=41603 and MonitorTime >='2013-06-01 00:00:00' and MonitorTime <='2013-06-30 23:59:59'
	group by deviceno
) as k on k.deviceno= hcq.deviceno
left join t_Device d on hcq.deviceno= d.DeviceID",  Start.ToString("yyyy-MM-dd")
           , Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd"));
           return db.ExecuteQuery(sql);
       }

       public DataTable SelectOnline()
       {
           string sql = @"select  
	monitordate,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
from ReportTemp	where channelno=41101 group by monitordate 
order by monitordate";
           return db.ExecuteQuery(sql);
       }

       public DataTable SelectOnlineDetail(int Year, int Month, int BussID)
       {
           DateTime Start = new DateTime(Year, Month, 1);
           string sql = string.Format(@"select d.DeviceName,db.DeviceName DBName,ditem.* from 
(
	select  
		deviceno,max(monitorvalue) maxval,MIN(monitorvalue) minval,round(AVG(monitorvalue),2) avgval
        ,count(case when monitorvalue> 60 then 1 end) num
	from ReportTemp	
	where channelno=41101 and MonitorTime >='{0} 00:00:00' and MonitorTime <='{1} 23:59:59'
	group by deviceno 
) as ditem
inner join t_Bussiness bus on ditem.deviceno=bus.Id and bus.parentid={2}
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId
order by DBName"
           , Start.ToString("yyyy-MM-dd")
           , Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
           , BussID);
           return db.ExecuteQuery(sql);
       }
        #endregion

       #region 三、中间件运行状况统计分析
		#region 1. 数据库连接池汇总统计
	   public DataTable DBTableSpaceLineNumberDetail(int Year,int Month,int BussID)
       {
           DateTime Start = new DateTime(Year, Month, 1);
           string sql = string.Format(@"select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*	,
	sy.maxval as symaxval,sy.minval as syminval,sy.avgval as syavgval
from (
	select deviceno,channelno,round(AVG(monitorvalue),2) avgval
	,max(monitorvalue) maxval
	,min(monitorvalue) minval
	from ReportTemp	
	where channelno=22603 and MonitorTime >='{0} 00:00:00' and MonitorTime <='{1} 23:59:59'
	group by deviceno,channelno
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno 
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id and bus.parentid={2}
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
left join (
select deviceno,channelno,round(AVG(monitorvalue),2) avgval
	,max(monitorvalue) maxval
	,min(monitorvalue) minval
	from ReportTemp	
	where channelno=22603 and MonitorTime >='{3} 00:00:00' and MonitorTime <='{4} 23:59:59'
	group by deviceno,channelno
) as sy on sy.deviceno= gro.deviceno and sy.channelno= gro.channelno
order by deviceno,channelno", Start.ToString("yyyy-MM-dd")
           , Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
           , BussID
           , Start.AddMonths(-1).ToString("yyyy-MM-dd")
           , Start.AddDays(-1).ToString("yyyy-MM-dd"));

           return db.ExecuteQuery(sql);
       }

       public DataTable DBTableSpaceLineNumberImg(int  BussID,int spacedeviceID)
       {
           string sql = string.Format(@"select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*	
from (
	select deviceno,channelno,monitordate,round(AVG(monitorvalue),2) avgval
	,max(monitorvalue) maxval
	,min(monitorvalue) minval
	from ReportTemp	
	where channelno=22603
	group by deviceno,channelno,monitordate
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno and DeviceID={0}
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id and bus.parentid={1}
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
order by deviceno,channelno,monitordate", spacedeviceID, BussID);
           return db.ExecuteQuery(sql);
       }

       /// <summary>
       /// 查询表空间
       /// </summary>
       /// <param name="sysid"></param>
       /// <returns></returns>
       public DataTable SelectDBTableSpace(int sysid)
       {
           string sql = string.Format(@"select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*	
from (
	select distinct deviceno,channelno
	from ReportTemp	
	where channelno=22603	
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno 
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id and bus.parentid={0}
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
order by deviceno,channelno", sysid);
           return db.ExecuteQuery(sql);
	   }
	   #endregion
	   
		#region 2、JVM堆使用汇总统计
		public DataTable MiddlewareJVMImg(int deviceno)
	   {
		   string sql =string.Format( @" select deviceno,monitordate,max(convert(float,d.monitorvalue)) maxval
	,min(convert(float,d.monitorvalue)) minval,
	round(avg(convert(float,d.monitorvalue)) ,2) avgval
	 from ReportTemp  d
	where d.ChannelNO=22505 and deviceno={0}
	group by deviceno,monitordate
	order by deviceno,monitordate",deviceno);
		   return db.ExecuteQuery(sql);
	   }
		public DataTable MiddlewareJVMDetail(int Year, int Month)
	   {
		   DateTime Start = new DateTime(Year, Month, 1);
		   string sql = string.Format(@"select d.DeviceName busName,mid.DeviceName midName,gro.*	
	,sy.maxval as symaxval,sy.minval as syminval,sy.avgval as syavgval
from (
	select deviceno,channelno,round(AVG(monitorvalue),2) avgval
	,max(monitorvalue) maxval
	,min(monitorvalue) minval
	from ReportTemp	
	where channelno=22505 and MonitorTime >='{0} 00:00:00' and MonitorTime <='{1} 23:59:59'
	group by deviceno,channelno
) as gro
inner join t_Bussiness bus on bus.Id=gro.deviceno  
inner join t_Device mid on mid.DeviceID= gro.deviceno
inner join t_Device  d on  d.DeviceID= bus.ParentId 

left join (
select deviceno,channelno,round(AVG(monitorvalue),2) avgval
	,max(monitorvalue) maxval
	,min(monitorvalue) minval
	from ReportTemp	
	where channelno=22505 and MonitorTime >='{2} 00:00:00' and MonitorTime <='{3} 23:59:59'
	group by deviceno,channelno
) as sy on sy.deviceno= gro.deviceno and sy.channelno= gro.channelno
order by deviceno,channelno ", Start.ToString("yyyy-MM-dd")
		   , Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
		   , Start.AddMonths(-1).ToString("yyyy-MM-dd")
		   , Start.AddDays(-1).ToString("yyyy-MM-dd"));

		   return db.ExecuteQuery(sql);
	   }

	   public DataTable GetBussMiddlewareName(int busDeviceID)
	   {
		   string sql = string.Format(@"select dt.typeid, dt.TypeName,d.DeviceID,d.DeviceName
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID
where bus.ParentId= {0} and dt.TypeID=10", busDeviceID);
		   return db.ExecuteQuery(sql);
	   }
		#endregion

	   #region 3、会话数汇总统计
	   public DataTable MiddlewareServerSessionImg(int deviceno)
	   {
		   string sql = string.Format(@" select deviceno,monitordate,max(convert(float,d.monitorvalue)) maxval
	,min(convert(float,d.monitorvalue)) minval,
	round(avg(convert(float,d.monitorvalue)) ,2) avgval
	 from ReportTemp  d
	where d.ChannelNO=22603 and deviceno={0}
	group by deviceno,monitordate
	order by deviceno,monitordate", deviceno);
		   return db.ExecuteQuery(sql);
	   }
	   public DataTable MiddlewareServerSessionDetail(int Year, int Month, int BussID)
	   {
		   DateTime Start = new DateTime(Year, Month, 1);
		   string sql = string.Format(@"select d.DeviceName,db.DeviceName DBName, ditem.DeviceName tableSpaceName,gro.*		
from (
	select deviceno,channelno,sum(monitorvalue) sumval
	,max(monitorvalue) maxval
	,min(monitorvalue) minval
	from ReportTemp	
	where channelno=22603 and MonitorTime >='{0} 00:00:00' and MonitorTime <='{1} 23:59:59'
	group by deviceno,channelno
) as gro
inner join t_DevItemList ditem on ditem.DeviceID= gro.deviceno 
inner join t_Bussiness bus on ditem.ParentDevID=bus.Id and bus.parentid={2}
inner join t_Device db on db.DeviceID= bus.Id
inner join t_Device  d on  d.DeviceID= bus.ParentId 
order by deviceno,channelno"
			   , Start.ToString("yyyy-MM-dd")
		   , Start.AddMonths(1).AddDays(-1).ToString("yyyy-MM-dd")
		  ,BussID);

		   return db.ExecuteQuery(sql);
	   }
	   #endregion

	   #endregion
	}
}
