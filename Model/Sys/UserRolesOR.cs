using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class UserRolesOR
    {
        
		private string _UserGuid;
		/// <summary>
		/// 用户GUID
		/// </summary>
		public string UserGuid
		{
			get { return _UserGuid; }
			set { _UserGuid = value; }
		}

		private string _RoleGuid;
		/// <summary>
		/// 角色GUID
		/// </summary>
		public string RoleGuid
		{
			get { return _RoleGuid; }
			set { _RoleGuid = value; }
		}

		/// <summary>
		/// UserRoles构造函数
		/// </summary>
		public UserRolesOR()
		{

		}

		/// <summary>
		/// UserRoles构造函数
		/// </summary>
		public UserRolesOR(DataRow row)
		{
			// 用户GUID
			_UserGuid = row["USER_GUID"].ToString().Trim();
			// 角色GUID
			_RoleGuid = row["ROLE_GUID"].ToString().Trim();
		}
    }
}

