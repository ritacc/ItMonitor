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
    public class UserRolesDA : DALBase
    {

      
        /// <summary>
        /// 查询用户角色
        /// </summary>
        /// <param name="UserGuid"></param>
        /// <returns></returns>
        public DataTable GetUserRoseBuyUserID(string UserGuid)
        {
            string sql = string.Format("select * from T_SYS_USER_ROLES where USER_GUID='{0}'", UserGuid);
           
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }           
            return dt;
        }

        public bool AddUserRoles(List<UserRolesOR> listRolse)
        {
            if(listRolse.Count==0)return false;
            string sql = string.Format("delete T_SYS_USER_ROLES where USER_GUID='{0}'", listRolse[0].UserGuid);
            List<string> listCommand=new List<string>();
            listCommand.Add(sql);
            foreach (UserRolesOR ur in listRolse)
            {
                sql = string.Format("insert into T_SYS_USER_ROLES (USER_GUID, ROLE_GUID) values ('{0}', '{1}')",ur.UserGuid,ur.RoleGuid);
                listCommand.Add(sql);
            }
            db.ExecuteNoQueryTran(listCommand);
            return true;
           
        }
        public DataTable GetUserRosetList(int pageCrrent, int pageSize, out int pageCount,string where)
        {
            string sql = "select * from View_USERRose_INFO";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
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

        

        public UserRolesOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_USER_ROLES where string strUserGuid='{0}'", m_id);
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
            UserRolesOR m_User = new UserRolesOR(dr);
            return m_User;

        }

      
    }
}

