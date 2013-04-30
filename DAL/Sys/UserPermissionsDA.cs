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
    public class UserPermissionsDA : DALBase
    {

        public List<VHC_USER_PERMISSIONS> GetListByUserID(string userLoginID)
        {
            string sql = string.Format("select * from VHC_USER_PERMISSIONS where USER_GUID='{0}' order by Sort", userLoginID);
            DataTable dt = null;
           
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            List<VHC_USER_PERMISSIONS> list = new List<VHC_USER_PERMISSIONS>();
            foreach (DataRow dr in dt.Rows)
            {
                VHC_USER_PERMISSIONS obj = new VHC_USER_PERMISSIONS(dr);
                list.Add(obj);
            }
            return list;
        }

        public DataTable GetListByUserIDToTB(string userLoginID)
        {
            string sql = string.Format("select * from VHC_USER_PERMISSIONS where USER_GUID='{0}'", userLoginID);
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

        public DataTable GetListByUserIDPrarentID(string userLoginID,string patrentID)
        {
            string sql = string.Format("select * from VHC_USER_PERMISSIONS where USER_GUID='{0}' and PARENT_URL='{1}'",
                userLoginID,patrentID);
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


    }
}

