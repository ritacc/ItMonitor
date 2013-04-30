using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class FunctionOR
    {
        
		private string _ModUrl;
		/// <summary>
		/// 
		/// </summary>
		public string ModUrl
		{
			get { return _ModUrl; }
			set { _ModUrl = value; }
		}

		private string _ModName;
		/// <summary>
		/// 
		/// </summary>
		public string ModName
		{
			get { return _ModName; }
			set { _ModName = value; }
		}

		private string _ParentUrl;
		/// <summary>
		/// 
		/// </summary>
		public string ParentUrl
		{
			get { return _ParentUrl; }
			set { _ParentUrl = value; }
		}

		private int _Sort;
		/// <summary>
		/// 
		/// </summary>
		public int Sort
		{
			get { return _Sort; }
			set { _Sort = value; }
		}

		private int _ModLevel;
		/// <summary>
		/// 
		/// </summary>
		public int ModLevel
		{
			get { return _ModLevel; }
			set { _ModLevel = value; }
		}

		private string _ModDesc;
		/// <summary>
		/// 
		/// </summary>
		public string ModDesc
		{
			get { return _ModDesc; }
			set { _ModDesc = value; }
		}

		private string _Enabled;
		/// <summary>
		/// 
		/// </summary>
		public string Enabled
		{
			get { return _Enabled; }
			set { _Enabled = value; }
		}

		private string _ImagePath;
		/// <summary>
		/// 
		/// </summary>
		public string ImagePath
		{
			get { return _ImagePath; }
			set { _ImagePath = value; }
		}

		private string _Isfunction;
		/// <summary>
		/// 
		/// </summary>
		public string Isfunction
		{
			get { return _Isfunction; }
			set { _Isfunction = value; }
		}

		/// <summary>
		/// Function构造函数
		/// </summary>
		public FunctionOR()
		{

		}

		/// <summary>
		/// Function构造函数
		/// </summary>
		public FunctionOR(DataRow row)
		{
			// 
			_ModUrl = row["MOD_URL"].ToString().Trim();
			// 
			_ModName = row["MOD_NAME"].ToString().Trim();
			// 
			_ParentUrl = row["PARENT_URL"].ToString().Trim();
			// 
			_Sort = Convert.ToInt32(row["SORT"]);
			// 
			_ModLevel = Convert.ToInt32(row["MOD_LEVEL"]);
			// 
			_ModDesc = row["MOD_DESC"].ToString().Trim();
			// 
			_Enabled = row["ENABLED"].ToString().Trim();
			// 
			_ImagePath = row["IMAGE_PATH"].ToString().Trim();
			// 
			_Isfunction = row["IsFunction"].ToString().Trim();
		}
    }
}

