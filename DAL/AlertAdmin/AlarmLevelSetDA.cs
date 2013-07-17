using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DBUtility;
using GDK.Entity.AlertAdmin;


namespace GDK.DAL.AlertAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public class AlarmLevelSetDA : DALBase
    {
        public AlarmLevelSetDA()
        {
            //db = MoniBase;
        }
        public DataTable selectAllData()
        {
            string sql = string.Format("select * from t_AlarmLevelSet");
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
        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from t_AlarmLevelSet";
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

        public AlarmLevelSetOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_AlarmLevelSet where  Id='{0}'", m_id);
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
            AlarmLevelSetOR m_Alar = new AlarmLevelSetOR(dr);
            return m_Alar;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入t_AlarmLevelSet
        /// </summary>
        public virtual bool Insert(AlarmLevelSetOR alarmLevelSet)
        {
            string sql = "insert into t_AlarmLevelSet ( Priority, LevelName, UpInterval) values ( @Priority, @LevelName, @UpInterval)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				
				new SqlParameter("@Priority", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Priority", DataRowVersion.Default, alarmLevelSet.Priority),
				new SqlParameter("@LevelName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LevelName", DataRowVersion.Default, alarmLevelSet.Levelname),
				new SqlParameter("@UpInterval", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "UpInterval", DataRowVersion.Default, alarmLevelSet.Upinterval)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新t_AlarmLevelSet
        /// </summary>
        public virtual bool Update(AlarmLevelSetOR alarmLevelSet)
        {
            string sql = "update t_AlarmLevelSet set  Priority = @Priority,  LevelName = @LevelName,  UpInterval = @UpInterval where  ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@ID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, alarmLevelSet.Id),
				new SqlParameter("@Priority", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Priority", DataRowVersion.Default, alarmLevelSet.Priority),
				new SqlParameter("@LevelName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "LevelName", DataRowVersion.Default, alarmLevelSet.Levelname),
				new SqlParameter("@UpInterval", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "UpInterval", DataRowVersion.Default, alarmLevelSet.Upinterval)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_AlarmLevelSet
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = "delete from t_AlarmLevelSet where  ID = @ID";
            SqlParameter parameter = new SqlParameter("@ID", strId);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

