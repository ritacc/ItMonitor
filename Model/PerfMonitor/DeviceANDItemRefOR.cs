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
		public DateTime LastPollingTime{get;set;}

		///<summary>
		///下次轮询时间
		///</summary>
		public DateTime NextPollingTime{get;set;}


		///<summary>
		///性能
		///</summary>
		public string Performance{get;set;}
		public string PerformanceVal
		{
			get
			{
				string val = "1";
				if (Performance == "故障")
					val = "0";
				else if (Performance == "报警")
					val = "2";
				else if (Performance == "未启动")
					val = "3";
				return val;

			}
		}

		public DeviceANDItemRefOR(DeviceOREx obj)
		{
			DeviceID = obj.DeviceID;
			Performance = obj.Performance;
			LastPollingTime = obj.LastPollingTime;
			NextPollingTime = obj.NextPollingTime;
		}

		public DeviceANDItemRefOR(DeviceItemOREx obj)
		{
			DeviceID = obj.DeviceID;
		}

		public DeviceANDItemRefOR() { }
	}
}
