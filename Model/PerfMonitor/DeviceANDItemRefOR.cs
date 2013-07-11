using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDK.Entity.PerfMonitor
{
	/// <summary>
	/// 用于界面刷新数据
	/// </summary>
	public class DeviceANDItemRefOR
	{
		/// <summary>
		/// 设备id
		/// </summary>
		public int DeviceID{get;set;}

		///<summary>
		///最后轮询时间
		///</summary>
        public string LastPollingTime { get; set; }

		///<summary>
		///下次轮询时间
		///</summary>
		public string NextPollingTime{get;set;}

        public string Status { get; set; }

        public string StatusVal { get; set; }

		///<summary>
		///性能
		///</summary>
		public string Performance{get;set;}
        public string PerformanceVal { get; set; }

		public DeviceANDItemRefOR(DeviceOREx obj)
		{
			DeviceID = obj.DeviceID;
			Performance = obj.Performance;
            PerformanceVal = obj.PerformanceVal;
			LastPollingTime = obj.LastPollingTime.ToString("yyyy-MM-dd HH:mm:ss");
            NextPollingTime = obj.NextPollingTime.ToString("yyyy-MM-dd HH:mm:ss");
            Status = obj.State;
            StatusVal = obj.StatusVal;
		}

		public DeviceANDItemRefOR(DeviceItemOREx obj)
		{
			DeviceID = obj.DeviceID;
		}

		public DeviceANDItemRefOR() { }
	}
}
