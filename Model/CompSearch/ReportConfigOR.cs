using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.CompSearch
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportConfigOR
    {
       
		private int  _Bussystemid;
		/// <summary>
		/// 
		/// </summary>
		public int  Bussystemid
		{
			get { return _Bussystemid; }
			set { _Bussystemid = value; }
		}

		private bool  _HostDiskuserate;
		/// <summary>
		/// 
		/// </summary>
		public bool  HostDiskuserate
		{
			get { return _HostDiskuserate; }
			set { _HostDiskuserate = value; }
		}

		private bool  _HostMemory;
		/// <summary>
		/// 
		/// </summary>
		public  bool HostMemory
		{
			get { return _HostMemory; }
			set { _HostMemory = value; }
		}

		private bool  _HostCpuuserate;
		/// <summary>
		/// 
		/// </summary>
		public bool  HostCpuuserate
		{
			get { return _HostCpuuserate; }
			set { _HostCpuuserate = value; }
		}

		private bool  _DbTablenamespace;
		/// <summary>
		/// 
		/// </summary>
		public  bool DbTablenamespace
		{
			get { return _DbTablenamespace; }
			set { _DbTablenamespace = value; }
		}

		private bool  _DbHitrate;
		/// <summary>
		/// 
		/// </summary>
		public bool  DbHitrate
		{
			get { return _DbHitrate; }
			set { _DbHitrate = value; }
		}

		private bool  _DbOnlinetime;
		/// <summary>
		/// 
		/// </summary>
		public bool  DbOnlinetime
		{
			get { return _DbOnlinetime; }
			set { _DbOnlinetime = value; }
		}

		private bool  _MidSession;
		/// <summary>
		/// 
		/// </summary>
		public  bool MidSession
		{
			get { return _MidSession; }
			set { _MidSession = value; }
		}

		private bool  _MidJvmuse;
		/// <summary>
		/// 
		/// </summary>
		public bool  MidJvmuse
		{
			get { return _MidJvmuse; }
			set { _MidJvmuse = value; }
		}

		private  bool _MidConnpool;
		/// <summary>
		/// 
		/// </summary>
		public bool  MidConnpool
		{
			get { return _MidConnpool; }
			set { _MidConnpool = value; }
		}

		private bool  _SystemStop;
		/// <summary>
		/// 
		/// </summary>
		public bool  SystemStop
		{
			get { return _SystemStop; }
			set { _SystemStop = value; }
		}

		private  bool _Stopinfo;
		/// <summary>
		/// 
		/// </summary>
		public  bool Stopinfo
		{
			get { return _Stopinfo; }
			set { _Stopinfo = value; }
		}

		private bool  _Availablerate;
		/// <summary>
		/// 
		/// </summary>
		public bool Availablerate
		{
			get { return _Availablerate; }
			set { _Availablerate = value; }
		}

		/// <summary>
		/// ReportConfig构造函数
		/// </summary>
		public ReportConfigOR()
		{
			_Bussystemid = -1;
			_HostDiskuserate = true;
			_HostMemory = true;
			_HostCpuuserate = true;
			_DbTablenamespace = true;
			_DbHitrate = true;
			_DbOnlinetime = true;
			_MidSession = true;
			_MidJvmuse = true;
			_MidConnpool = true;
			_SystemStop = true;
			_Stopinfo = true;
			_Availablerate = true;
		}

		/// <summary>
		/// ReportConfig构造函数
		/// </summary>
		public ReportConfigOR(DataRow row)
		{
			// 
			_Bussystemid = Convert.ToInt32(row["BusSystemID"].ToString().Trim());
			// 
			_HostDiskuserate = Convert.ToBoolean(row["Host_DiskUseRate"].ToString().Trim());
			// 
			_HostMemory = Convert.ToBoolean(row["Host_Memory"].ToString().Trim());
			// 
			_HostCpuuserate = Convert.ToBoolean(row["Host_CPUUseRate"].ToString().Trim());
			// 
			_DbTablenamespace = Convert.ToBoolean(row["DB_TableNameSpace"].ToString().Trim());
			// 
			_DbHitrate = Convert.ToBoolean(row["DB_Hitrate"].ToString().Trim());
			// 
			_DbOnlinetime = Convert.ToBoolean(row["DB_OnlineTime"].ToString().Trim());
			// 
			_MidSession = Convert.ToBoolean(row["Mid_Session"].ToString().Trim());
			// 
			_MidJvmuse = Convert.ToBoolean(row["Mid_JVMUse"].ToString().Trim());
			// 
			_MidConnpool = Convert.ToBoolean(row["Mid_ConnPool"].ToString().Trim());
			// 
			_SystemStop = Convert.ToBoolean(row["System_Stop"].ToString().Trim());
			// 
			_Stopinfo = Convert.ToBoolean(row["StopInfo"].ToString().Trim());
			// 
			_Availablerate = Convert.ToBoolean(row["AvailableRate"].ToString().Trim());
		}
    }
}

