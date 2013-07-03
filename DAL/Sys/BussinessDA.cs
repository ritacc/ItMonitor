using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GDK.DAL.Sys
{
    public class BussinessDA : DALBase
    {
        public DataTable GetTopBuss()
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID
where bus.ParentId= -1 ";
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetTopBuss(int pageCrrent, int pageSize, out int pageCount)
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID
where bus.ParentId= -1 ";
            DataTable dt = null;
            int returnC = 0; 
            try
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

        public DataTable GetSysLay(int DeviceID, int typeid)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from  t_Device d  
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where  dt.typeid={0} 
and DeviceID not in (select Id  from t_Bussiness where ParentId={1})", typeid, DeviceID);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

        public DataTable GetSysLay(int DeviceID, string strWhere)
        {
            string sql = string.Format(@"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from  t_Device d  
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where  {0} 
and DeviceID not in (select Id  from t_Bussiness where ParentId={1}) ",strWhere, DeviceID);
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }


        #region DELETE
        /// <summary>
        /// 删除
        /// </summary>
        public virtual bool Delete(string strID)
        {
            string sql = "delete from t_Bussiness where  Id = @Id";
            SqlParameter parameter = new SqlParameter("@Id", strID);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion

    }
}
