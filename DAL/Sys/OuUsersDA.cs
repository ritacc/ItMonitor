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
    public class OuUsersDA : DALBase
    {

        #region 查询
       

        public OuUsersOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_OU_USERS where Parent_Guid='{0}'", m_id);
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
            OuUsersOR m_OuUs = new OuUsersOR(dr);
            return m_OuUs;

        }

        #endregion

       
    }
}

