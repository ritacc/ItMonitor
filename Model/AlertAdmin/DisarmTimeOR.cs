using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.AlertAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public class DisarmTimeOR
    {
       
		private int _Disarmid;
		/// <summary>
		/// 
		/// </summary>
		public int Disarmid
		{
			get { return _Disarmid; }
			set { _Disarmid = value; }
		}

		private string _Disarmname;
		/// <summary>
		/// 撤防名称
		/// </summary>
		public string Disarmname
		{
			get { return _Disarmname; }
			set { _Disarmname = value; }
		}

		private string _Disarmstarttime;
		/// <summary>
		/// 撤防开始时间
		/// </summary>
		public string Disarmstarttime
		{
			get { return _Disarmstarttime; }
			set { _Disarmstarttime = value; }
		}

		private string _Disarmendtime;
		/// <summary>
		/// 撤防结束时间
		/// </summary>
		public string Disarmendtime
		{
			get { return _Disarmendtime; }
			set { _Disarmendtime = value; }
		}

		/// <summary>
		/// DisarmTime构造函数
		/// </summary>
		public DisarmTimeOR()
		{

		}

		/// <summary>
		/// DisarmTime构造函数
		/// </summary>
		public DisarmTimeOR(DataRow row)
		{
			// 
			_Disarmid = Convert.ToInt32(row["DisarmID"]);
			// 撤防名称
			_Disarmname = row["DisarmName"].ToString().Trim();
			// 撤防开始时间
			_Disarmstarttime = row["DisarmStartTime"].ToString().Trim();
			// 撤防结束时间
			_Disarmendtime = row["DisarmEndTime"].ToString().Trim();
		}
    }
}

