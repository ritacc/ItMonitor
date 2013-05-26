using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDK.Entity.CompSearch
{
    public class ReportSeachWhereOR
    {
        /// <summary>
        /// 站点
        /// </summary>
        public int StationID { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int DeviceType { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public int DeviceID { get; set; }

        /// <summary>
        /// 设备名称
        /// </summary>
        public string DeviceName { get; set; }


        public List<SearchChanncelOR> ListChanncel { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        /// <summary>
        /// 报表详细度
        /// </summary>
        public string ReportType { get; set; }
        public string ReportTypeName { get; set; }

        public string ReportName { get; set; }


        public string GetDataConver()
        {
            //当天(精确到小时)
            string str = "SUBSTRING(CONVERT(varchar(16) , MonitorTime, 120 ),6,8)";//05-25 11 当天日期
            switch (ReportType.ToLower())
            {
                case "hour"://历史(一小时)
                    str = "CONVERT(varchar(13) , MonitorTime, 120 )";//2013-05-25 11
                    break;
                case "day"://历史(一天)
                    str = "CONVERT(varchar(10) , MonitorTime, 120 )"; //2013-05-25
                    break;
                case "month"://历史(一月)
                    str = "CONVERT(varchar(7) , MonitorTime, 120 )"; //2013-05
                    break;
                case "year"://历史(一年)
                    str = "CONVERT(varchar(4) , MonitorTime, 120 )"; //2013
                    break;
            }
            return str;
        }

        public string GetChanncelWhere(string filds)
        {
            if (ListChanncel == null)
                return string.Empty;
            string mWhere=string.Empty;
            bool isFirst = true;
            foreach (SearchChanncelOR obj in ListChanncel)
            {
                if (isFirst)
                {
                    mWhere = string.Format(" {0}={1}", filds, obj.ChanncelNo);
                    isFirst = false;
                }
                else
                {
                    mWhere+=string.Format(" or {0}={1}",filds, obj.ChanncelNo);
                }
            }

            return mWhere;
        }
    }

    public class SearchChanncelOR
    {
        public int ChanncelNo { get; set; }

        public string ChanncelName { get; set; }
    }
}
