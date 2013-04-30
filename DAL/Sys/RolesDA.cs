using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GDK.Entity.Sys;
using GDK.Entity;


namespace GDK.DAL.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class RolesDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from T_SYS_ROLES";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            sql += " order by ROLE_NAME desc";
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        public RolesOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_ROLES where GUID='{0}'", m_id);
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
            RolesOR m_Role = new RolesOR(dr);
            return m_Role;

        }

        public DataTable SelectAllRoles()
        {
            string sql = string.Format("select * from T_SYS_ROLES");
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
            return dt;
        }

        public DataTable SelectRolesWithoutSelf(string rolename)
        {
            string sql = string.Format("select * from T_SYS_ROLES where role_name != '" + rolename + "'");
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }


        #endregion

        #region 插入
        /// <summary>
        /// 插入T_SYS_ROLES
        /// </summary>
        public virtual bool Insert(RolesOR roles)
        {
            string sql = "insert into T_SYS_ROLES (GUID, ROLE_NAME, ROLE_DESC) values (@GUID, @ROLE_NAME, @ROLE_DESC)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@GUID", Guid.NewGuid().ToString()),
				new SqlParameter("@ROLE_NAME",  roles.RoleName),
				new SqlParameter("@ROLE_DESC", roles.RoleDesc)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }

      
        #endregion

        #region 修改
        /// <summary>
        /// 更新T_SYS_ROLES
        /// </summary>
        public virtual bool Update(RolesOR roles)
        {
            string sql = "update T_SYS_ROLES set  ROLE_NAME = @ROLE_NAME,  ROLE_DESC = @ROLE_DESC where  GUID = @GUID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@GUID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "GUID", DataRowVersion.Default, roles.Guid),
				new SqlParameter("@ROLE_NAME", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "ROLE_NAME", DataRowVersion.Default, roles.RoleName),
				new SqlParameter("@ROLE_DESC", SqlDbType.NVarChar, 512, ParameterDirection.Input, false, 0, 0, "ROLE_DESC", DataRowVersion.Default, roles.RoleDesc)
			};
            
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }

       
        #endregion

        #region DELETE
        /// <summary>
        /// 删除T_SYS_ROLES
        /// </summary>
        public virtual bool Delete(string strGuid)
        {
            string sql =string.Format( "delete from T_SYS_ROLES where  GUID = '{0}'",strGuid);            
            return db.ExecuteNoQuery(sql) > -1;
        }
        #endregion

        #region 获取角色
        /// <summary>
        /// 获取角色
        /// </summary>
        /// <param name="guid">角色guid</param>
        /// <returns>DataTable</returns>
        public DataTable GetValueByGuid(string guid)
        {
            DataSet ds = db.ExecuteQueryDataSet("select * from T_SYS_ROLES where GUID = '" + guid + "'");
            DataTable dt = ds.Tables[0].DefaultView.Table;
            return dt;
        }
        #endregion

        #region 获取数据字典
        /// <summary>
        /// 获取数据字典
        /// </summary>
        /// <param name="keywordName">关键字名称</param>
        /// <returns>DataSet</returns>
        public DataSet GetDropdownList(string keyword)
        {
            return db.ExecuteQueryDataSet("select * from T_SYS_DataDict where KEY_WORD = '" + keyword + "' and PARENT_CODE != 0");
        }
        #endregion
    }
}

