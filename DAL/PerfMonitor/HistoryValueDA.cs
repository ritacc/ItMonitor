using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;

namespace GDK.DAL.PerfMonitor
{
  public  class HistoryValueDA:DALBase
    {
      public string GetTableName(int DeviceID)
      {
          DeviceOR _objOR = new DeviceDA().SelectDeviceORByID(DeviceID.ToString());
          string TableName = string.Empty;
          if (TalbleIsExist(_objOR.StationID, _objOR.DeviceName, out TableName))
          {
              return TableName;
          }
          return null;
      }

      public bool TalbleIsExist(int stationID, string devName,out string tableName)
      {
          int month = DateTime.Now.Month;
          int year = DateTime.Now.Year;

          // 生成表名
          string strmonth = string.Format("{0:00}", month);
          string targetTable = "t_" + stationID.ToString().Trim() + "_" + devName + "_" + Convert.ToString(year) + "_" + strmonth;
          
          string tableNametemp = "\"" + targetTable + "\"";
          string tableName2 = "";
          foreach (char c in tableNametemp)
          {
              if (c == '(' || c == ')')
              {
                  tableName2 += new string('/', 1);
              }
              tableName2 += new string(c, 1);
          }
		  tableName = tableName2;

          string strSQL = "SELECT count(*) FROM dbo.sysobjects WHERE id = OBJECT_ID(N'" + tableName2 + "') AND OBJECTPROPERTY(id, N'IsUserTable') = 1";
          string s = db.ExecuteScalar(strSQL).ToString();
          if (s == "" || Convert.ToInt32(s) <= 0)
              return false;

          return true;
      }

	  /// <summary>
	  /// 查询一个通道 的历史值
	  /// </summary>
	  /// <param name="DeviceID"></param>
	  /// <param name="ChannelNo"></param>
	  /// <param name="StartTime"></param>
	  /// <param name="EndTime"></param>
	  /// <returns></returns>
      public DataTable GetDeviceChanncelValue(int DeviceID, int ChannelNo,DateTime StartTime,DateTime EndTime)
      {
          string tableName = GetTableName(DeviceID);
          if (string.IsNullOrEmpty(tableName))
              return null;
          string sql = string.Format(@"select CONVERT(varchar(5) , MonitorTime, 108 ) Time,MonitorValue from {0} where ChannelNo={1} and DeviceID={2}
and MonitorTime> '{3}' and MonitorTime< '{4}' ", tableName, ChannelNo, DeviceID, StartTime.ToString("yyyy-MM-dd HH:mm:ss"), EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
         DataTable dt= db.ExecuteQuery(sql);
         return dt;
      }

	
	  /// <summary>
	  /// 查询设备列表
	  /// </summary>
	  /// <param name="DeviceID"></param>
	  /// <param name="DeviceTypeID"></param>
	  /// <param name="ChannelNo"></param>
	  /// <param name="StartTime"></param>
	  /// <param name="EndTime"></param>
	  /// <returns></returns>
	  public DataTable GetDeviceChanncelValuesList(int DeviceID, int DeviceTypeID, int ChannelNo, DateTime StartTime, DateTime EndTime)
	  {
		  string tableName = GetTableName(DeviceID);
		  if (string.IsNullOrEmpty(tableName))
			  return null;

		  string sql = string.Format(@"
select e.*,d1.DeviceName from(
	select f.DeviceID,max(MonitorValue) maxVal from (
		select d.DeviceID,convert(int,td.MonitorValue) MonitorValue
		from {0} td
		left join t_Device d on d.DeviceID= td.DeviceID and  d.DeviceTypeID={1}
		where d.ParentDevID= {2}  and ChannelNo={3} and td.MonitorTime  between   '{4}' and  '{5}'
	) as f group by DeviceID
) as e
inner join t_Device d1 on d1.DeviceID= e.DeviceID", tableName, DeviceTypeID, DeviceID, ChannelNo, StartTime.ToString("yyyy-MM-dd HH:mm:ss"), EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
	  
	   DataTable dt= db.ExecuteQuery(sql);
         return dt;
	  }

    }
}
