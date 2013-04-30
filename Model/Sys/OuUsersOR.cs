using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class OuUsersOR
    {
        
		private string _ParentGuid;
		/// <summary>
		/// 所在部门的标志ID
		/// </summary>
		public string ParentGuid
		{
			get { return _ParentGuid; }
			set { _ParentGuid = value; }
		}

		private string _UserGuid;
		/// <summary>
		/// 用户的标志ID
		/// </summary>
		public string UserGuid
		{
			get { return _UserGuid; }
			set { _UserGuid = value; }
		}

		private string _DisplayName;
		/// <summary>
		/// 用户的显示名称
		/// </summary>
		public string DisplayName
		{
			get { return _DisplayName; }
			set { _DisplayName = value; }
		}

		private string _ObjName;
		/// <summary>
		/// 用户的对象名称（解决兼职情况下不允许重名情况）
		/// </summary>
		public string ObjName
		{
			get { return _ObjName; }
			set { _ObjName = value; }
		}

		private string _InnerSort;
		/// <summary>
		/// 用户在部门中的排序
		/// </summary>
		public string InnerSort
		{
			get { return _InnerSort; }
			set { _InnerSort = value; }
		}

		private string _OriginalSort;
		/// <summary>
		/// 用户在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
		/// </summary>
		public string OriginalSort
		{
			get { return _OriginalSort; }
			set { _OriginalSort = value; }
		}

		private string _GlobalSort;
		/// <summary>
		/// 用户在部门中的全地址（用于全国大排序）
		/// </summary>
		public string GlobalSort
		{
			get { return _GlobalSort; }
			set { _GlobalSort = value; }
		}

		private string _AllPathName;
		/// <summary>
		/// 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）
		/// </summary>
		public string AllPathName
		{
			get { return _AllPathName; }
			set { _AllPathName = value; }
		}

		private int _Status;
		/// <summary>
		/// 状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
		/// </summary>
		public int Status
		{
			get { return _Status; }
			set { _Status = value; }
		}

		private int _Sideline;
		/// <summary>
		/// 改职位是否为兼职（0、主职；1、兼职）
		/// </summary>
		public int Sideline
		{
			get { return _Sideline; }
			set { _Sideline = value; }
		}

		private string _RankName;
		/// <summary>
		/// 用户在该部门中的职位
		/// </summary>
		public string RankName
		{
			get { return _RankName; }
			set { _RankName = value; }
		}

		private int _Attributes;
		/// <summary>
		/// 用户的属性标志（普通成员0，党组成员1、署管干部2、交流干部4、借调干部8）掩码实现
		/// </summary>
		public int Attributes
		{
			get { return _Attributes; }
			set { _Attributes = value; }
		}

		private string _Description;
		/// <summary>
		/// 用户的附加描述信息
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		private string _StartTime;
		/// <summary>
		/// 关系启用时间
		/// </summary>
		public string StartTime
		{
			get { return _StartTime; }
			set { _StartTime = value; }
		}

		private string _EndTime;
		/// <summary>
		/// 关系结束时间
		/// </summary>
		public string EndTime
		{
			get { return _EndTime; }
			set { _EndTime = value; }
		}

		private string _ModifyTime;
		/// <summary>
		/// 关系最近修改时间
		/// </summary>
		public string ModifyTime
		{
			get { return _ModifyTime; }
			set { _ModifyTime = value; }
		}

		private string _CreateTime;
		/// <summary>
		/// 关系建立的时间
		/// </summary>
		public string CreateTime
		{
			get { return _CreateTime; }
			set { _CreateTime = value; }
		}

		private string _Ousysdistinct1;
		/// <summary>
		/// 备用字段1(16位,不允许重复)
		/// </summary>
		public string Ousysdistinct1
		{
			get { return _Ousysdistinct1; }
			set { _Ousysdistinct1 = value; }
		}

		private string _Ousysdistinct2;
		/// <summary>
		/// 备用字段2(32位,不允许重复)
		/// </summary>
		public string Ousysdistinct2
		{
			get { return _Ousysdistinct2; }
			set { _Ousysdistinct2 = value; }
		}

		private string _Ousyscontent1;
		/// <summary>
		/// 备用字段3(32位,允许重复)
		/// </summary>
		public string Ousyscontent1
		{
			get { return _Ousyscontent1; }
			set { _Ousyscontent1 = value; }
		}

		private string _Ousyscontent2;
		/// <summary>
		/// 备用字段4(64位,允许重复)
		/// </summary>
		public string Ousyscontent2
		{
			get { return _Ousyscontent2; }
			set { _Ousyscontent2 = value; }
		}

		private string _Ousyscontent3;
		/// <summary>
		/// 备用字段5(128位,允许重复)
		/// </summary>
		public string Ousyscontent3
		{
			get { return _Ousyscontent3; }
			set { _Ousyscontent3 = value; }
		}

		/// <summary>
		/// OuUsers构造函数
		/// </summary>
		public OuUsersOR()
		{

		}

		/// <summary>
		/// OuUsers构造函数
		/// </summary>
		public OuUsersOR(DataRow row)
		{
			// 所在部门的标志ID
			_ParentGuid = row["PARENT_GUID"].ToString().Trim();
			// 用户的标志ID
			_UserGuid = row["USER_GUID"].ToString().Trim();
			// 用户的显示名称
			_DisplayName = row["DISPLAY_NAME"].ToString().Trim();
			// 用户的对象名称（解决兼职情况下不允许重名情况）
			_ObjName = row["OBJ_NAME"].ToString().Trim();
			// 用户在部门中的排序
			_InnerSort = row["INNER_SORT"].ToString().Trim();
			// 用户在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
			_OriginalSort = row["ORIGINAL_SORT"].ToString().Trim();
			// 用户在部门中的全地址（用于全国大排序）
			_GlobalSort = row["GLOBAL_SORT"].ToString().Trim();
			// 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）
			_AllPathName = row["ALL_PATH_NAME"].ToString().Trim();
			// 状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
			_Status = Convert.ToInt32(row["STATUS"]);
			// 改职位是否为兼职（0、主职；1、兼职）
			_Sideline = Convert.ToInt32(row["SIDELINE"]);
			// 用户在该部门中的职位
			_RankName = row["RANK_NAME"].ToString().Trim();
			// 用户的属性标志（普通成员0，党组成员1、署管干部2、交流干部4、借调干部8）掩码实现
			_Attributes = Convert.ToInt32(row["ATTRIBUTES"]);
			// 用户的附加描述信息
			_Description = row["DESCRIPTION"].ToString().Trim();
			// 关系启用时间
			_StartTime = row["START_TIME"].ToString().Trim();
			// 关系结束时间
			_EndTime = row["END_TIME"].ToString().Trim();
			// 关系最近修改时间
			_ModifyTime = row["MODIFY_TIME"].ToString().Trim();
			// 关系建立的时间
			_CreateTime = row["CREATE_TIME"].ToString().Trim();
			// 备用字段1(16位,不允许重复)
			_Ousysdistinct1 = row["OUSYSDISTINCT1"].ToString().Trim();
			// 备用字段2(32位,不允许重复)
			_Ousysdistinct2 = row["OUSYSDISTINCT2"].ToString().Trim();
			// 备用字段3(32位,允许重复)
			_Ousyscontent1 = row["OUSYSCONTENT1"].ToString().Trim();
			// 备用字段4(64位,允许重复)
			_Ousyscontent2 = row["OUSYSCONTENT2"].ToString().Trim();
			// 备用字段5(128位,允许重复)
			_Ousyscontent3 = row["OUSYSCONTENT3"].ToString().Trim();
		}
    }
}

