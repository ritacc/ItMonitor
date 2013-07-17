using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.AlertAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmLevelSetOR
    {
       
		private int _Id;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _Priority;
		/// <summary>
		/// 
		/// </summary>
		public int Priority
		{
			get { return _Priority; }
			set { _Priority = value; }
		}

		private string _Levelname;
		/// <summary>
		/// 
		/// </summary>
		public string Levelname
		{
			get { return _Levelname; }
			set { _Levelname = value; }
		}

		private int _Upinterval;
		/// <summary>
		/// 
		/// </summary>
		public int Upinterval
		{
			get { return _Upinterval; }
			set { _Upinterval = value; }
		}

		/// <summary>
		/// AlarmLevelSet构造函数
		/// </summary>
		public AlarmLevelSetOR()
		{
		}

		/// <summary>
		/// AlarmLevelSet构造函数
		/// </summary>
		public AlarmLevelSetOR(DataRow row)
		{
			// 
			_Id = Convert.ToInt32(row["ID"]);
			// 
			_Priority = Convert.ToInt32(row["Priority"]);
			// 
			_Levelname = row["LevelName"].ToString().Trim();
			// 
			_Upinterval = Convert.ToInt32(row["UpInterval"]);
		}
    }
}

