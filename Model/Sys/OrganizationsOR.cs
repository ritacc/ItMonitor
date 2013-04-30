using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class OrganizationsOR
    {
        
		private string _Guid;
		/// <summary>
		/// 部门的标志ID
		/// </summary>
		public string Guid
		{
			get { return _Guid; }
			set { _Guid = value; }
		}

		private string _DisplayName;
		/// <summary>
		/// 显示名称
		/// </summary>
		public string DisplayName
		{
			get { return _DisplayName; }
			set { _DisplayName = value; }
		}

		private string _ObjName;
		/// <summary>
		/// 对象名称（部门内唯一）
		/// </summary>
		public string ObjName
		{
			get { return _ObjName; }
			set { _ObjName = value; }
		}

		private string _ParentGuid;
		/// <summary>
		/// 父部门的标志ID（注：树结构中第一个节点没有值）
		/// </summary>
		public string ParentGuid
		{
			get { return _ParentGuid; }
			set { _ParentGuid = value; }
		}

		private string _RankCode;
		/// <summary>
		/// 机构的行政级别信息数据
		/// </summary>
		public string RankCode
		{
			get { return _RankCode; }
			set { _RankCode = value; }
		}

		private string _InnerSort;
		/// <summary>
		/// 部门内部排序号
		/// </summary>
		public string InnerSort
		{
			get { return _InnerSort; }
			set { _InnerSort = value; }
		}

		private string _OriginalSort;
		/// <summary>
		/// 在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
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
		/// 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处）
		/// </summary>
		public string AllPathName
		{
			get { return _AllPathName; }
			set { _AllPathName = value; }
		}

		private int _OrgClass;
		/// <summary>
		/// 部门的一些特殊属性（1总署、2分署、4特派办、8直属、16院校、32隶属海关、64派驻机构）采用掩码实现
		/// </summary>
		public int OrgClass
		{
			get { return _OrgClass; }
			set { _OrgClass = value; }
		}

		private int _OrgType;
		/// <summary>
		/// 部门的一些特殊属性（1虚拟机构、2一般部门、4办公室（厅）、8综合处）采用掩码实现
		/// </summary>
		public int OrgType
		{
			get { return _OrgType; }
			set { _OrgType = value; }
		}

		private int _ChildrenCounter;
		/// <summary>
		/// 记录部门内部使用的最大号值（记录值为下一个可使用值，从0开始）
		/// </summary>
		public int ChildrenCounter
		{
			get { return _ChildrenCounter; }
			set { _ChildrenCounter = value; }
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

		private string _CustomsCode;
		/// <summary>
		/// 关区代码
		/// </summary>
		public string CustomsCode
		{
			get { return _CustomsCode; }
			set { _CustomsCode = value; }
		}

		private string _Description;
		/// <summary>
		/// 附加说明信息
		/// </summary>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
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
		/// Organizations构造函数
		/// </summary>
		public OrganizationsOR()
		{

		}

		/// <summary>
		/// Organizations构造函数
		/// </summary>
		public OrganizationsOR(DataRow row)
		{
			// 部门的标志ID
			_Guid = row["GUID"].ToString().Trim();
			// 显示名称
			_DisplayName = row["DISPLAY_NAME"].ToString().Trim();
			// 对象名称（部门内唯一）
			_ObjName = row["OBJ_NAME"].ToString().Trim();
			// 父部门的标志ID（注：树结构中第一个节点没有值）
			_ParentGuid = row["PARENT_GUID"].ToString().Trim();
			// 机构的行政级别信息数据
			_RankCode = row["RANK_CODE"].ToString().Trim();
			// 部门内部排序号
			_InnerSort = row["INNER_SORT"].ToString().Trim();
			// 在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
			_OriginalSort = row["ORIGINAL_SORT"].ToString().Trim();
			// 用户在部门中的全地址（用于全国大排序）
			_GlobalSort = row["GLOBAL_SORT"].ToString().Trim();
			// 用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处）
			_AllPathName = row["ALL_PATH_NAME"].ToString().Trim();
			// 部门的一些特殊属性（1总署、2分署、4特派办、8直属、16院校、32隶属海关、64派驻机构）采用掩码实现
			_OrgClass = Convert.ToInt32(row["ORG_CLASS"]);
			// 部门的一些特殊属性（1虚拟机构、2一般部门、4办公室（厅）、8综合处）采用掩码实现
			_OrgType = Convert.ToInt32(row["ORG_TYPE"]);
			// 记录部门内部使用的最大号值（记录值为下一个可使用值，从0开始）
			_ChildrenCounter = Convert.ToInt32(row["CHILDREN_COUNTER"]);
			// 状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
			_Status = Convert.ToInt32(row["STATUS"]);
			// 关区代码
			_CustomsCode = row["CUSTOMS_CODE"].ToString().Trim();
			// 附加说明信息
			_Description = row["DESCRIPTION"].ToString().Trim();
			// 创建时间
			_CreateTime = row["CREATE_TIME"].ToString().Trim();
			// 最近修改时间
			_ModifyTime = row["MODIFY_TIME"].ToString().Trim();
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

