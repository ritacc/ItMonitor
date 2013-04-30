using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.SYS
{
    /// <summary>
    /// 
    /// </summary>
    public class DEVICETYPEOR
    {
        
		private string _Guid;
		/// <summary>
		/// 
		/// </summary>
		public string Guid
		{
			get { return _Guid; }
			set { _Guid = value; }
		}

		private string _Displayname;
		/// <summary>
		/// 型号
		/// </summary>
		public string Displayname
		{
			get { return _Displayname; }
			set { _Displayname = value; }
		}

		private string _Subname;
		/// <summary>
		/// 规格
		/// </summary>
        public string SubName
		{
			get { return _Subname; }
			set { _Subname = value; }
		}

		private string _Parentguid;
		/// <summary>
		/// 
		/// </summary>
		public string Parentguid
		{
			get { return _Parentguid; }
			set { _Parentguid = value; }
		}

		private string _Rootguid;
		/// <summary>
		/// 
		/// </summary>
		public string Rootguid
		{
			get { return _Rootguid; }
			set { _Rootguid = value; }
		}

		private int _Flag;
		/// <summary>
		/// 
		/// </summary>
		public int Flag
		{
			get { return _Flag; }
			set { _Flag = value; }
		}

		private int _Level;
		/// <summary>
		/// 
		/// </summary>
		public int Level
		{
			get { return _Level; }
			set { _Level = value; }
		}

		private string _Remark;
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			get { return _Remark; }
			set { _Remark = value; }
		}

		/// <summary>
		/// DEVICETYPE构造函数
		/// </summary>
		public DEVICETYPEOR()
		{
            _Subname = "";
            _Remark = "";
            _Guid = System.Guid.NewGuid().ToString();

		}

		/// <summary>
		/// DEVICETYPE构造函数
		/// </summary>
		public DEVICETYPEOR(DataRow row)
		{
			// 
			_Guid = row["Guid"].ToString().Trim();
			// 型号
			_Displayname = row["DisplayName"].ToString().Trim();
			// 规格
			_Subname = row["SubName"].ToString().Trim();
			// 
			_Parentguid = row["ParentGuid"].ToString().Trim();
			// 
			_Rootguid = row["RootGuid"].ToString().Trim();
			// 
			_Flag = Convert.ToInt32(row["Flag"]);
			// 
			_Level = Convert.ToInt32(row["Level"]);
			// 
			_Remark = row["Remark"].ToString().Trim();
		}
    }
}

