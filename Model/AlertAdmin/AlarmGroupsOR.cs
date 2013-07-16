using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.AlertAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmGroupsOR
    {
       
		private int _Alarmgroupsid;
		/// <summary>
		/// 
		/// </summary>
		public int Alarmgroupsid
		{
			get { return _Alarmgroupsid; }
			set { _Alarmgroupsid = value; }
		}

		private string _Groupname;
		/// <summary>
		/// 组名称
		/// </summary>
		public string Groupname
		{
			get { return _Groupname; }
			set { _Groupname = value; }
		}

		private int _Stationid;
		/// <summary>
		/// 站点ID
		/// </summary>
		public int Stationid
		{
			get { return _Stationid; }
			set { _Stationid = value; }
		}

		/// <summary>
		/// AlarmGroups构造函数
		/// </summary>
		public AlarmGroupsOR()
		{

		}

		/// <summary>
		/// AlarmGroups构造函数
		/// </summary>
		public AlarmGroupsOR(DataRow row)
		{
			// 
			_Alarmgroupsid = Convert.ToInt32(row["AlarmGroupsID"]);
			// 组名称
			_Groupname = row["GroupName"].ToString().Trim();
			// 站点ID
			_Stationid = Convert.ToInt32(row["StationID"]);
		}
    }
}

