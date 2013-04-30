﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class StationOR
    {
       
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
		/// 装点名称
		/// </summary>
		public string Stationname
		{
			get { return _Stationname; }
			set { _Stationname = value; }
		}

		private string _Ip;
		/// <summary>
		/// IP
		/// </summary>
		public string Ip
		{
			get { return _Ip; }
			set { _Ip = value; }
		}

		private int _Port;
		/// <summary>
		/// 端口
		/// </summary>
		public int Port
		{
			get { return _Port; }
			set { _Port = value; }
		}

		private int _Historyport;
		/// <summary>
		/// 历史端口
		/// </summary>
		public int Historyport
		{
			get { return _Historyport; }
			set { _Historyport = value; }
		}

		/// <summary>
		/// Station构造函数
		/// </summary>
		public StationOR()
		{

		}

		/// <summary>
		/// Station构造函数
		/// </summary>
		public StationOR(DataRow row)
		{
			// 
			_Stationid = Convert.ToInt32(row["StationID"]);
			// 装点名称
			_Stationname = row["StationName"].ToString().Trim();
			// IP
			_Ip = row["IP"].ToString().Trim();
			// 端口
			_Port = Convert.ToInt32(row["Port"]);
			// 历史端口
			_Historyport = Convert.ToInt32(row["HistoryPort"]);
		}
    }
}

