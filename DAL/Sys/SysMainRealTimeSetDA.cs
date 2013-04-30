using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using GDK.Entity.Sys;


namespace GDK.DAL.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class SysMainRealTimeSetDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from t_Sys_MainRealTimeSet";
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

        public SysMainRealTimeSetOR selectARowDate()
        {
            string sql = string.Format("select * from t_Sys_MainRealTimeSet");
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
            SysMainRealTimeSetOR m_SysM = new SysMainRealTimeSetOR(dr);
            return m_SysM;

        }

        #endregion

      

        #region 修改
        /// <summary>
        /// 更新t_Sys_MainRealTimeSet
        /// </summary>
        public virtual bool Update(SysMainRealTimeSetOR sysMainRealTimeSet)
        {
            string sql = "update t_Sys_MainRealTimeSet set  StationID = @StationID,  DeviceID = @DeviceID,  ChannelNO = @ChannelNO,   YmaxValue = @YmaxValue,  YminValue = @YminValue,  Yupper = @Yupper,  Ylower = @Ylower,  GridHeight = @GridHeight";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StationID", DataRowVersion.Default, sysMainRealTimeSet.Stationid),
				new SqlParameter("@DeviceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "DeviceID", DataRowVersion.Default, sysMainRealTimeSet.Deviceid),
				new SqlParameter("@ChannelNO", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ChannelNO", DataRowVersion.Default, sysMainRealTimeSet.Channelno),
				new SqlParameter("@YmaxValue", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "YmaxValue", DataRowVersion.Default, sysMainRealTimeSet.Ymaxvalue),
				new SqlParameter("@YminValue", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "YminValue", DataRowVersion.Default, sysMainRealTimeSet.Yminvalue),
				new SqlParameter("@Yupper", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "Yupper", DataRowVersion.Default, sysMainRealTimeSet.Yupper),
				new SqlParameter("@Ylower", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "Ylower", DataRowVersion.Default, sysMainRealTimeSet.Ylower),
				new SqlParameter("@GridHeight", SqlDbType.Float, 8, ParameterDirection.Input, false, 0, 0, "GridHeight", DataRowVersion.Default, sysMainRealTimeSet.Gridheight)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_Sys_MainRealTimeSet
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = "delete from t_Sys_MainRealTimeSet where  ID = @ID";
            SqlParameter parameter = new SqlParameter("@ID", strId);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

