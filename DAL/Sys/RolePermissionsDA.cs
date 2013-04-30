using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GDK.Entity.Sys;


namespace GDK.DAL.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class RolePermissionsDA : DALBase
    {

        public bool InsertRolePermission(List<RolePermissionsOR> list)
        {
            if (list.Count == 0) return false;
            string sql = string.Format("delete from T_SYS_ROLE_PERMISSIONS where  ROLE_GUID='{0}'", list[0].RoleGuid);
            List<string> listCommand = new List<string>();
            listCommand.Add(sql);
            foreach (RolePermissionsOR ur in list)
            {
                sql = string.Format("insert into T_SYS_ROLE_PERMISSIONS (ROLE_GUID, PERMISSION_CODE) values ('{0}', '{1}')", ur.RoleGuid, ur.PermissionCode);
                listCommand.Add(sql);
            }
            db.ExecuteNoQueryTran(listCommand);
            return true;

        }

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from T_SYS_ROLE_PERMISSIONS";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql,pageCrrent, pageSize,  out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        public RolePermissionsOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_ROLE_PERMISSIONS where RoleGuid='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            RolePermissionsOR m_Role = new RolePermissionsOR(dr);
            return m_Role;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入T_SYS_ROLE_PERMISSIONS
        /// </summary>
        public virtual bool Insert(RolePermissionsOR rolePermissions)
        {
            string sql = "insert into T_SYS_ROLE_PERMISSIONS (ROLE_GUID, PERMISSION_CODE) values (:ROLE_GUID, :PERMISSION_CODE)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter(":ROLE_GUID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ROLE_GUID", DataRowVersion.Default, rolePermissions.RoleGuid),
				new SqlParameter(":PERMISSION_CODE", SqlDbType.VarChar, 512, ParameterDirection.Input, false, 0, 0, "PERMISSION_CODE", DataRowVersion.Default, rolePermissions.PermissionCode)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新T_SYS_ROLE_PERMISSIONS
        /// </summary>
        public virtual bool Update(RolePermissionsOR rolePermissions)
        {
            string sql = "update T_SYS_ROLE_PERMISSIONS set  PERMISSION_CODE = :PERMISSION_CODE where  ROLE_GUID = :ROLE_GUID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter(":ROLE_GUID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ROLE_GUID", DataRowVersion.Default, rolePermissions.RoleGuid),
				new SqlParameter(":PERMISSION_CODE", SqlDbType.VarChar, 512, ParameterDirection.Input, false, 0, 0, "PERMISSION_CODE", DataRowVersion.Default, rolePermissions.PermissionCode)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除T_SYS_ROLE_PERMISSIONS
        /// </summary>
        public virtual bool Delete(string strRoleGuid)
        {
            string sql = "delete from T_SYS_ROLE_PERMISSIONS where  ROLE_GUID = :ROLE_GUID";
            SqlParameter parameter = new SqlParameter(":ROLE_GUID", strRoleGuid);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

