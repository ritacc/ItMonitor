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
    public class StationDA : DALBase
    {

        #region 查询
        public DataTable selectAllStation()
        {
            string sql = "select * from t_Station";

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

        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from t_Station";
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

        public StationOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_Station where  Stationid='{0}'", m_id);
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
            StationOR m_Stat = new StationOR(dr);
            return m_Stat;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入t_Station
        /// </summary>
        public virtual bool Insert(StationOR station)
        {
            string sql = "insert into t_Station ( StationName, IP, Port, HistoryPort) values ( @StationName, @IP, @Port, @HistoryPort)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				
				new SqlParameter("@StationName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "StationName", DataRowVersion.Default, station.Stationname),
				new SqlParameter("@IP", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "IP", DataRowVersion.Default, station.Ip),
				new SqlParameter("@Port", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Port", DataRowVersion.Default, station.Port),
				new SqlParameter("@HistoryPort", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "HistoryPort", DataRowVersion.Default, station.Historyport)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新t_Station
        /// </summary>
        public virtual bool Update(StationOR station)
        {
            string sql = "update t_Station set  StationName = @StationName,  IP = @IP,  Port = @Port,  HistoryPort = @HistoryPort where  StationID = @StationID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@StationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StationID", DataRowVersion.Default, station.Stationid),
				new SqlParameter("@StationName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "StationName", DataRowVersion.Default, station.Stationname),
				new SqlParameter("@IP", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "IP", DataRowVersion.Default, station.Ip),
				new SqlParameter("@Port", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Port", DataRowVersion.Default, station.Port),
				new SqlParameter("@HistoryPort", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "HistoryPort", DataRowVersion.Default, station.Historyport)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_Station
        /// </summary>
        public virtual bool Delete(string strStationid)
        {
            string sql = "delete from t_Station where  StationID = @StationID";
            SqlParameter parameter = new SqlParameter("@StationID", strStationid);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

