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
    public class UsersDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from T_SYS_USERS";
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
        public UsersOR selectARowDateByGuid(string m_id)
        {
            string sql = string.Format("select * from T_SYS_USERS where GUID='{0}'", m_id);
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
            UsersOR m_User = new UsersOR(dr);
            return m_User;

        }
        public UsersOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_USERS where LOGON_NAME='{0}'", m_id);
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
            UsersOR m_User = new UsersOR(dr);
            return m_User;

        }

        #endregion

      

      

        public UsersOR sp_UserLogin(string userID, string UsrPwd)
        {
            string sql = string.Format("select * from T_SYS_USERS where  LOGON_NAME='{0}' and USER_PWD='{1}'", userID, UsrPwd);
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
            {
                UsersOR user = this.selectARowDate(userID);
                if (user != null)
                    throw new Exception("密码错误！");
                else
                    throw new Exception("用户名或密码错误！");
            }
            DataRow dr = dt.Rows[0];
            UsersOR m_User = new UsersOR(dr);
            OrganizationsOR org = new OrganizationsDA().selectARowDate(m_User.ParentGuid);
            if (org != null)
            {
                m_User.DepartmentName = org.DisplayName;
            }
            return m_User;
        }
    }
}

