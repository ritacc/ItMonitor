using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class PerfNetAlarmOR
    {
        /// <summary>
        /// 消息
        /// </summary>
        private string _Content;

        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        /// <summary>
        /// 发生时间
        /// </summary>
        private DateTime _HappenTime;

        public DateTime HappenTime
        {
            get { return _HappenTime; }
            set { _HappenTime = value; }
        }

        public PerfNetAlarmOR()
		{

		}

		/// <summary>
		/// Roles构造函数
		/// </summary>
        public PerfNetAlarmOR(DataRow row)
        {
            // 消息
            if (row["Content"] != DBNull.Value)
                _Content = row["Content"].ToString().Trim();

            // 发生时间
            if (row["HappenTime"] != DBNull.Value)
                _HappenTime = Convert.ToDateTime(row["HappenTime"]);
        }
    }
}
