using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.CompSearch;

namespace GDK.DAL.CompSearch
{
    public class ReportSeachDA:DALBase
    {
        public void SearchReportDataToTemp(ReportSeachWhereOR whereOR)
        {
            DateTime begin = whereOR.StartTime;
            DateTime end = whereOR.EndTime;
            int stationID = whereOR.StationID;
            string devName = whereOR.DeviceName;
            int nDeviceID = whereOR.DeviceID; 

            string Datastr = whereOR.GetDataConver();
            string ChanncelWhere = whereOR.GetChanncelWhere("t1.channelno");

            string sqlTruncate = " truncate table ReportTemp;";
            db.ExecuteNoQuery(sqlTruncate);

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
                string strdev = Convert.ToString(nDeviceID);

                string strSql = string.Format(@"insert into ReportTemp ([deviceno],[channelno],[monitorvalue],[monitordate],MonitorTime)
select  t1.deviceid as deviceno, t1.channelno as channelno,
convert(float,t1.monitorvalue) as monitorvalue,{0} as monitordate,MonitorTime from {1} t1 
where t1.MonitorTime between '{2}' and '{3}' and ({4})", Datastr, tableName2, time1, time2, ChanncelWhere);

                //ChanncelWhere
                db.ExecuteNoQuery(strSql);
            }
        }

        public void GetDataReport(ReportSeachWhereOR whereOR
           , out DataTable reReport, out DataTable reList)
        {
            string SqlReport = @"select val.*,tc.ChannelName from (
select deviceno,ChannelNo,monitordate,
round( avg(MonitorValue),2) avgValue,
max(MonitorValue) maxValue,min(MonitorValue) minValue from ReportTemp 
group by deviceno,ChannelNo,monitordate
) as val
left join t_Channel tc on tc.DeviceID= val.deviceno and tc.ChannelNo= val.ChannelNo order by monitordate;";
            DataTable dtReport = db.ExecuteQuery(SqlReport);
            reReport = dtReport;

            string sqlList = @"select val.*,tc.ChannelName from (
select deviceno,ChannelNo,
round( avg(MonitorValue),2) avgValue,
max(MonitorValue) maxValue,min(MonitorValue) minValue from ReportTemp 
group by deviceno,ChannelNo
) as val
left join t_Channel tc on tc.DeviceID= val.deviceno and tc.ChannelNo= val.ChannelNo;
";

            DataTable dtList = db.ExecuteQuery(sqlList);
            reList = dtList;
        }


    



}
}
