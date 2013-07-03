using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GDK.Entity.CompSearch;
using GDK.DAL.SerMonitor;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.CompSearch
{
	public class PDFReportSearch : DALBase
	{

		public void SearchReportDataToTemp(ReportSeachWhereOR whereOR)
		{

			DateTime begin = whereOR.StartTime;
			DateTime end = whereOR.EndTime;
			int stationID = whereOR.StationID;
			// whereOR.DeviceName;


			string Datastr = whereOR.GetDataConver();
			string ChanncelWhere = whereOR.GetChanncelWhere("t1.channelno");

			string sqlTruncate = " truncate table ReportTemp;";
			db.ExecuteNoQuery(sqlTruncate);

			foreach (int mdevid in whereOR.ListDevices)
			{
				int nDeviceID = mdevid;
				string devName = GetDeviceName(nDeviceID);

				// 以1970年为限，（年份－1970）×12+月份为数值，一直循环到结束时间
				int t1 = (begin.Year - 1970) * 12 + begin.Month - 1;
				int t2 = (end.Year - 1970) * 12 + end.Month - 1;
				int t = 0;

				for (t = t1; t <= t2; t++)
				{
					int year = t / 12 + 1970;
					int month = t % 12 + 1;

					// 生成表名
					string strmonth = string.Format("{0:00}", month);// 00001234
					string targetTable = "t_" + stationID.ToString().Trim() + "_" + devName + "_" + Convert.ToString(year) + "_" + strmonth;

					//string tableName2 = targetTable;
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

					string strSQL = "SELECT count(*) FROM dbo.sysobjects WHERE id = OBJECT_ID(N'" + tableName2 + "') AND OBJECTPROPERTY(id, N'IsUserTable') = 1";
					string s = db.ExecuteScalar(strSQL).ToString();
					if (s == "" || Convert.ToInt32(s) <= 0)
						continue;

					// 根据表名和时间返回数据
					string time1 = begin.ToString("yyyy-MM-dd HH:mm:ss");
					string time2 = end.ToString("yyyy-MM-dd HH:mm:ss");
					string strdev = nDeviceID.ToString();

					string strSql = string.Format(@"insert into ReportTemp ([deviceno],[channelno],[monitorvalue],[monitordate],MonitorTime)
select  t1.deviceid as deviceno, t1.channelno as channelno,
convert(float,t1.monitorvalue) as monitorvalue,{0} as monitordate,MonitorTime from {1} t1 
where t1.MonitorTime between '{2}' and '{3}' and ({4})", Datastr, tableName2, time1, time2, ChanncelWhere);

					//ChanncelWhere
					db.ExecuteNoQuery(strSql);
				}// end for

			}
		}

		public string GetDeviceName(int deviceID)
		{
			DeviceOR  obj= new DeviceDA().SelectDeviceORByID(deviceID.ToString());
			if (obj != null)
				return obj.DeviceName;
			return "";
		}

	}
}
