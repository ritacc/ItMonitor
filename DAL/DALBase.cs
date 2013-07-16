using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;


namespace GDK.DAL
{
    public class DALBase
    {
        protected SqlHelper db = new SqlHelper();
        //protected SqlHelper MoniBase = new SqlHelper("MonitorBase");
       // protected DbHelper db1 = new DbHelper("vssdb");

        //protected SqlHelper db1 = new SqlHelper("MonitorDemo2");
        //protected SqlHelper db1 = new SqlHelper("onepoint");
        //protected SqlHelper db2 = new SqlHelper("bcm");
        //protected void resetDB()
        //{
        //    try
        //    {                
        //        db.Dispose();
        //        db = new SqlHelper();
        //    }
        //    catch (Exception ex)
        //    {
                
        //        throw ex;
        //    }

        //}

        protected SqlParameter[] InsertPara(SqlParameter[] ParaArr, SqlParameter mobj)
        {
            int len = ParaArr.Length + 1;
            SqlParameter[] pNew = new SqlParameter[len];
            int index = 0;
            foreach (SqlParameter mp in ParaArr)
            {
                pNew[index] = mp;
                index++;
            }
            pNew[index] = mobj;
            return pNew;
        }
    }
}
