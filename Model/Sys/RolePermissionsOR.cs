using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class RolePermissionsOR
    {
        
		private string _RoleGuid;
		/// <summary>
		/// 角色GUID
		/// </summary>
		public string RoleGuid
		{
			get { return _RoleGuid; }
			set { _RoleGuid = value; }
		}

		private string _PermissionCode;
		/// <summary>
		/// 权限代码
		/// </summary>
		public string PermissionCode
		{
			get { return _PermissionCode; }
			set { _PermissionCode = value; }
		}

		/// <summary>
		/// RolePermissions构造函数
		/// </summary>
		public RolePermissionsOR()
		{

		}

		/// <summary>
		/// RolePermissions构造函数
		/// </summary>
		public RolePermissionsOR(DataRow row)
		{
			// 角色GUID
			_RoleGuid = row["ROLE_GUID"].ToString().Trim();
			// 权限代码
			_PermissionCode = row["PERMISSION_CODE"].ToString().Trim();
		}
    }
}

