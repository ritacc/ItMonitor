using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class UsersOR
    {
        
		private string _Guid;
		/// <summary>
		/// 用户身份标志ID
		/// </summary>
		public string Guid
		{
			get { return _Guid; }
			set { _Guid = value; }
		}

		private string _ParentGuid;
		/// <summary>
		/// 所在部门的标志ID
		/// </summary>
		public string ParentGuid
		{
			get { return _ParentGuid; }
			set { _ParentGuid = value; }
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

		private string _RankName;
		/// <summary>
		/// 用户在该部门中的职位
		/// </summary>
		public string RankName
		{
			get { return _RankName; }
			set { _RankName = value; }
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

		private string _LogonName;
		/// <summary>
		/// 用户的登录名称
		/// </summary>
		public string LogonName
		{
			get { return _LogonName; }
			set { _LogonName = value; }
		}

		private string _IcCard;
		/// <summary>
		/// 用户的IC卡号
		/// </summary>
		public string IcCard
		{
			get { return _IcCard; }
			set { _IcCard = value; }
		}

		private string _PwdTypeGuid;
		/// <summary>
		/// 使用密码的加密算法
		/// </summary>
		public string PwdTypeGuid
		{
			get { return _PwdTypeGuid; }
			set { _PwdTypeGuid = value; }
		}

		private string _UserPwd;
		/// <summary>
		/// 用户所使用的密码（加密存储）
		/// </summary>
		public string UserPwd
		{
			get { return _UserPwd; }
			set { _UserPwd = value; }
		}

		private string _RankCode;
		/// <summary>
		/// 用户本身的级别信息数据
		/// </summary>
		public string RankCode
		{
			get { return _RankCode; }
			set { _RankCode = value; }
		}

		private string _EMail;
		/// <summary>
		/// 用户默认使用的EMAIL
		/// </summary>
		public string EMail
		{
			get { return _EMail; }
			set { _EMail = value; }
		}

		private int _Postural;
		/// <summary>
		/// 用户的在系统中的状态（1、禁用状态；2、要求下次登录修改密码；4、正常使用；）掩码方式实现
		/// </summary>
		public int Postural
		{
			get { return _Postural; }
			set { _Postural = value; }
		}

		private string _CreateTime;
		/// <summary>
		/// 创建时间
		/// </summary>
		public string CreateTime
		{
			get { return _CreateTime; }
			set { _CreateTime = value; }
		}

		private string _ModifyTime;
		/// <summary>
		/// 最近修改时间
		/// </summary>
		public string ModifyTime
		{
			get { return _ModifyTime; }
			set { _ModifyTime = value; }
		}

		private int _AdCount;
		/// <summary>
		/// 是否在AD中建立对应的账号
		/// </summary>
		public int AdCount
		{
			get { return _AdCount; }
			set { _AdCount = value; }
		}

		private string _PersonId;
		/// <summary>
		/// 海关人员编码
		/// </summary>
		public string PersonId
		{
			get { return _PersonId; }
			set { _PersonId = value; }
		}

		private string _Sysdistinct1;
		/// <summary>
		/// 备用字段1(16位,不允许重复)
		/// </summary>
		public string Sysdistinct1
		{
			get { return _Sysdistinct1; }
			set { _Sysdistinct1 = value; }
		}

		private string _Sysdistinct2;
		/// <summary>
		/// 备用字段2(32位,不允许重复)
		/// </summary>
		public string Sysdistinct2
		{
			get { return _Sysdistinct2; }
			set { _Sysdistinct2 = value; }
		}

		private string _Syscontent1;
		/// <summary>
		/// 备用字段3(32位,允许重复)
		/// </summary>
		public string Syscontent1
		{
			get { return _Syscontent1; }
			set { _Syscontent1 = value; }
		}

		private string _Syscontent2;
		/// <summary>
		/// 备用字段4(64位,允许重复)
		/// </summary>
		public string Syscontent2
		{
			get { return _Syscontent2; }
			set { _Syscontent2 = value; }
		}

		private string _Syscontent3;
		/// <summary>
		/// 备用字段5(128位,允许重复)
		/// </summary>
		public string Syscontent3
		{
			get { return _Syscontent3; }
			set { _Syscontent3 = value; }
		}

		/// <summary>
		/// Users构造函数
		/// </summary>
		public UsersOR()
		{

		}

		/// <summary>
		/// Users构造函数
		/// </summary>
		public UsersOR(DataRow row)
		{
			// 用户身份标志ID
			_Guid = row["GUID"].ToString().Trim();
			// 所在部门的标志ID
			_ParentGuid = row["PARENT_GUID"].ToString().Trim();
			// 用户的显示名称
			_DisplayName = row["DISPLAY_NAME"].ToString().Trim();
			// 用户在部门中的排序
			_InnerSort = row["INNER_SORT"].ToString().Trim();
			// 用户在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
			_OriginalSort = row["ORIGINAL_SORT"].ToString().Trim();
			// 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）
			_AllPathName = row["ALL_PATH_NAME"].ToString().Trim();
			// 状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
			_Status = Convert.ToInt32(row["STATUS"]);
			// 用户在该部门中的职位
			_RankName = row["RANK_NAME"].ToString().Trim();
			// 用户的附加描述信息
			_Description = row["DESCRIPTION"].ToString().Trim();
			// 关系启用时间
			_StartTime = row["START_TIME"].ToString().Trim();
			// 关系结束时间
			_EndTime = row["END_TIME"].ToString().Trim();
			// 用户的登录名称
			_LogonName = row["LOGON_NAME"].ToString().Trim();
			// 用户的IC卡号
			_IcCard = row["IC_CARD"].ToString().Trim();
			// 使用密码的加密算法
			_PwdTypeGuid = row["PWD_TYPE_GUID"].ToString().Trim();
			// 用户所使用的密码（加密存储）
			_UserPwd = row["USER_PWD"].ToString().Trim();
			// 用户本身的级别信息数据
			_RankCode = row["RANK_CODE"].ToString().Trim();
			// 用户默认使用的EMAIL
			_EMail = row["E_MAIL"].ToString().Trim();
			// 用户的在系统中的状态（1、禁用状态；2、要求下次登录修改密码；4、正常使用；）掩码方式实现
			_Postural = Convert.ToInt32(row["POSTURAL"]);
			// 创建时间
			_CreateTime = row["CREATE_TIME"].ToString().Trim();
			// 最近修改时间
			_ModifyTime = row["MODIFY_TIME"].ToString().Trim();
			// 是否在AD中建立对应的账号
			_AdCount = Convert.ToInt32(row["AD_COUNT"]);
			// 海关人员编码
			_PersonId = row["PERSON_ID"].ToString().Trim();
			// 备用字段1(16位,不允许重复)
			_Sysdistinct1 = row["SYSDISTINCT1"].ToString().Trim();
			// 备用字段2(32位,不允许重复)
			_Sysdistinct2 = row["SYSDISTINCT2"].ToString().Trim();
			// 备用字段3(32位,允许重复)
			_Syscontent1 = row["SYSCONTENT1"].ToString().Trim();
			// 备用字段4(64位,允许重复)
			_Syscontent2 = row["SYSCONTENT2"].ToString().Trim();
			// 备用字段5(128位,允许重复)
			_Syscontent3 = row["SYSCONTENT3"].ToString().Trim();
		}
    }
}

