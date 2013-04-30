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
    public class FunctionDA : DALBase
    {

        #region 查询
        
        public DataTable selectAllDate(string RoseGUID)
        {
            string sql = string.Format("select t.*,dbo.F_RoseExisPerm('{0}',mod_url) as IsChecked from T_SYS_Function t    order by parent_url,sort ", RoseGUID);
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
        public DataTable selectAllDate()
        {
            string sql = "select * from T_SYS_Function";
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
        #endregion


    }
}

