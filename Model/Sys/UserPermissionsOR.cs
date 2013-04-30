using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class UserPermissionsOR
    {
        
		private string _UserGuid;
		/// <summary>
		/// 用户ID
		/// </summary>
		public string UserGuid
		{
			get { return _UserGuid; }
			set { _UserGuid = value; }
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
		/// UserPermissions构造函数
		/// </summary>
		public UserPermissionsOR()
		{

		}

		/// <summary>
		/// UserPermissions构造函数
		/// </summary>
		public UserPermissionsOR(DataRow row)
		{
			// 用户ID
			_UserGuid = row["USER_GUID"].ToString().Trim();
			// 权限代码
			_PermissionCode = row["PERMISSION_CODE"].ToString().Trim();
		}
    }
}

