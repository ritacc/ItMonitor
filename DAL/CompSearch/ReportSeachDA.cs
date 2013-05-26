﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.CompSearch
{
    public class ReportSeachDA:DALBase
    {

        public DataTable GetDataMonthReport(int stationID, string devName, int nDeviceID, DateTime begin, DateTime end)
        {
            // 以1970年为限，（年份－1970）×12+月份为数值，一直循环到结束时间
            int t1 = (begin.Year - 1970) * 12 + begin.Month - 1;
            int t2 = (end.Year - 1970) * 12 + end.Month - 1;
            int t = 0;
            bool bFirst = true;
            DataTable result = null;
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

                string strSql = string.Format("select t1.dataid,t1.deviceid as deviceno, t1.channelno as channelno,t1.monitorvalue as monitorvalue,CONVERT(char(10), t1.MonitorTime, 111) as monitordate into temp from {0} t1 where t1.MonitorTime between '{1}' and '{2}';select deviceno,channelno,max(monitorvalue) as 最大值, min(monitorvalue) as 最小值,avg(monitorvalue) as 平均值,monitordate as 日期 into temp2 from temp group by monitordate,channelno,deviceno;select temp2.deviceno as 设备ID,t2.devicename as 设备名,temp2.channelno as 测点ID,t3.channelname as 测点名,最大值,最小值,平均值,日期 from temp2, t_device t2,t_channel t3 where temp2.Deviceno=t2.DeviceID and t3.deviceid=temp2.deviceno and t3.channelno = temp2.channelno order by temp2.deviceno,temp2.channelno,日期;drop table temp2;drop table temp;", tableName2, time1, time2);


                DataTable dt = db.ExecuteQuery(strSql);

                if (bFirst)
                    result = dt;
                else
                    result.Merge(dt);

                bFirst = false;
            }
            return result;
        }


    }
}
