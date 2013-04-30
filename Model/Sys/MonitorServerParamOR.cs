using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class MonitorServerParamOR
    {
       
		private int _Paramid;
		/// <summary>
		/// 
		/// </summary>
		public int Paramid
		{
			get { return _Paramid; }
			set { _Paramid = value; }
		}

		private string _Paramname;
		/// <summary>
		/// 
		/// </summary>
		public string Paramname
		{
			get { return _Paramname; }
			set { _Paramname = value; }
		}

		private string _Paramaddr;
		/// <summary>
		/// 
		/// </summary>
		public string Paramaddr
		{
			get { return _Paramaddr; }
			set { _Paramaddr = value; }
		}

		private string _Param;
		/// <summary>
		/// 
		/// </summary>
		public string Param
		{
			get { return _Param; }
			set { _Param = value; }
		}

		private int _Stationid;
		/// <summary>
		/// 
		/// </summary>
		public int Stationid
		{
			get { return _Stationid; }
			set { _Stationid = value; }
		}

		private string _Stationname;
		/// <summary>
		/// 
		/// </summary>
		public string Stationname
		{
			get { return _Stationname; }
			set { _Stationname = value; }
		}

		private int _Ischeck;
		/// <summary>
		/// 
		/// </summary>
		public int Ischeck
		{
			get { return _Ischeck; }
			set { _Ischeck = value; }
		}

		private int _Issmscheck;
		/// <summary>
		/// 
		/// </summary>
		public int Issmscheck
		{
			get { return _Issmscheck; }
			set { _Issmscheck = value; }
		}

		/// <summary>
		/// MonitorServerParam构造函数
		/// </summary>
		public MonitorServerParamOR()
		{

		}

		/// <summary>
		/// MonitorServerParam构造函数
		/// </summary>
		public MonitorServerParamOR(DataRow row)
		{
			// 
			_Paramid = Convert.ToInt32(row["ParamID"]);
			// 
			_Paramname = row["ParamName"].ToString().Trim();
			// 
			_Paramaddr = row["ParamAddr"].ToString().Trim();
			// 
			_Param = row["Param"].ToString().Trim();
			// 
			_Stationid = Convert.ToInt32(row["StationID"]);
			// 
			_Stationname = row["StationName"].ToString().Trim();
			// 
			_Ischeck = Convert.ToInt32(row["IsCheck"]);
			// 
			_Issmscheck = Convert.ToInt32(row["IsSmsCheck"]);
		}
    }
}

