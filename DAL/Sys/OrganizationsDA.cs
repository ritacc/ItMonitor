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
    public class OrganizationsDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from T_SYS_Organizations";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize,  out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }

        public OrganizationsOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from T_SYS_Organizations where Guid='{0}'", m_id);
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
            OrganizationsOR m_Orga = new OrganizationsOR(dr);
            return m_Orga;

        }


        public DataTable SelectOrgCS()
        {
            string sql = @"select * from T_SYS_Organizations where  RANK_CODE='POS_ORGAN_D' 
or RANK_CODE='SUB_ORGAN_D'";
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

       
    }
}

