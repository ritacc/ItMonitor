using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class DeviceItemOREx : DeviceOR
    {

        /// <summary>
        /// 类型名称
        /// </summary>
        public string TypeName { get; set; }

        /// <summary>
        /// 分类
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 告警状态
        /// </summary>
        public string WarningStatus { get; set; }

        /// <summary>
        /// 健康状况
        /// </summary>
        public string HealthStatus { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

         /// <summary>
		/// Roles构造函数
		/// </summary>
        public DeviceItemOREx(DataRow row)
        {
            // 设备id
            DeviceID = Convert.ToInt32(row["DeviceID"]);
            // 设备名称
            DeviceName = row["DeviceName"].ToString().Trim();
            
            if (row["DeviceTypeID"] != DBNull.Value)
                DeviceTypeID = Convert.ToInt32(row["DeviceTypeID"]);

            if (row["StationID"] != DBNull.Value)
                StationID = Convert.ToInt32(row["StationID"]);
            StationName = row["StationName"].ToString().Trim();
           
            //可用性
            if (row["AvailableRate"].ToString() != "")
            {
                AvailableRate = Convert.ToDouble(row["AvailableRate"].ToString());
            }
            else
            {
                AvailableRate = 0f;
            }
            if (row["ParentDevID"] != DBNull.Value)
                ParentDevID = Convert.ToInt32(row["ParentDevID"]);

            if (row["Performance"] != DBNull.Value)
                Performance = row["Performance"].ToString().Trim();
            if (row["Describe"] != DBNull.Value)
                Describe = row["Describe"].ToString().Trim();


            TypeName = row["TypeName"].ToString();
            ClassName = row["ClassName"].ToString();
            WarningStatus = row["WarningStatus"].ToString();
            HealthStatus = row["HealthStatus"].ToString();
            State = row["State"].ToString();
        }
    }
}
