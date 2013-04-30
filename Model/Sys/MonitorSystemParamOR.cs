using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class MonitorSystemParamOR
    {
       
		private int _Monitorrefreshtime;
		/// <summary>
		/// 监控刷新时间隔
		/// </summary>
		public int Monitorrefreshtime
		{
			get { return _Monitorrefreshtime; }
			set { _Monitorrefreshtime = value; }
		}

		private int _Startscreenid;
		/// <summary>
		/// 启动页
		/// </summary>
		public int Startscreenid
		{
			get { return _Startscreenid; }
			set { _Startscreenid = value; }
		}

		private int _Alarmlogtime;
		/// <summary>
		/// 报警框刷新时间
		/// </summary>
		public int Alarmlogtime
		{
			get { return _Alarmlogtime; }
			set { _Alarmlogtime = value; }
		}

		private string _Serverip;
		/// <summary>
		/// IP地址
		/// </summary>
		public string Serverip
		{
			get { return _Serverip; }
			set { _Serverip = value; }
		}

		private int _Serverport;
		/// <summary>
		/// 端口
		/// </summary>
		public int Serverport
		{
			get { return _Serverport; }
			set { _Serverport = value; }
		}

		private string _DoorSysid;
		/// <summary>
		/// 
		/// </summary>
		public string DoorSysid
		{
			get { return _DoorSysid; }
			set { _DoorSysid = value; }
		}

		private int _DoorCom;
		/// <summary>
		/// 
		/// </summary>
		public int DoorCom
		{
			get { return _DoorCom; }
			set { _DoorCom = value; }
		}

		private int _Havedoor;
		/// <summary>
		/// 
		/// </summary>
		public int Havedoor
		{
			get { return _Havedoor; }
			set { _Havedoor = value; }
		}

		private int _Id;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		/// <summary>
		/// MonitorSystemParam构造函数
		/// </summary>
		public MonitorSystemParamOR()
		{


		}

		/// <summary>
		/// MonitorSystemParam构造函数
		/// </summary>
		public MonitorSystemParamOR(DataRow row)
		{
			// 监控刷新时间隔
			_Monitorrefreshtime = Convert.ToInt32(row["MonitorRefreshTime"]);
			// 启动页
			_Startscreenid = Convert.ToInt32(row["StartScreenID"]);
			// 报警框刷新时间
			_Alarmlogtime = Convert.ToInt32(row["AlarmLogTime"]);
			// IP地址
			_Serverip = row["ServerIP"].ToString().Trim();
			// 端口
			_Serverport = Convert.ToInt32(row["ServerPort"]);
			// 
			_DoorSysid = row["Door_Sysid"].ToString().Trim();
			// 
			_DoorCom = Convert.ToInt32(row["Door_Com"]);
			// 
			_Havedoor = Convert.ToInt32(row["HaveDoor"]);
			// 
			_Id = Convert.ToInt32(row["ID"]);
		}
    }
}

