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
    public class AlarmGroupsDA : DALBase
    {
        public AlarmGroupsDA()
        {
           // db = MoniBase;
        }
        #region 查询
        public DataTable SelectAllDate()
        {
            string sql = string.Format(@"select ag.*,s.StationName,s.StationName+'-'+ GroupName showName  from t_AlarmGroups ag
inner join t_Station s on s.StationID=ag.StationID order by showName");
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
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select ag.*,s.StationName from t_AlarmGroups ag
inner join t_Station s on s.StationID=ag.StationID";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            sql += " order by ag.StationID,GroupName";
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

        public AlarmGroupsOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_AlarmGroups where  Alarmgroupsid='{0}'", m_id);
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
            AlarmGroupsOR m_Alar = new AlarmGroupsOR(dr);
            return m_Alar;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入t_AlarmGroups
        /// </summary>
        public virtual bool Insert(AlarmGroupsOR alarmGroups)
        {
            string sql = "insert into t_AlarmGroups ( GroupName, StationID) values ( @GroupName, @StationID)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@GroupName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "GroupName", DataRowVersion.Default, alarmGroups.Groupname),
				new SqlParameter("@StationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StationID", DataRowVersion.Default, alarmGroups.Stationid)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新t_AlarmGroups
        /// </summary>
        public virtual bool Update(AlarmGroupsOR alarmGroups)
        {
            string sql = "update t_AlarmGroups set  GroupName = @GroupName,  StationID = @StationID where  AlarmGroupsID = @AlarmGroupsID";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@AlarmGroupsID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "AlarmGroupsID", DataRowVersion.Default, alarmGroups.Alarmgroupsid),
				new SqlParameter("@GroupName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "GroupName", DataRowVersion.Default, alarmGroups.Groupname),
				new SqlParameter("@StationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StationID", DataRowVersion.Default, alarmGroups.Stationid)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_AlarmGroups
        /// </summary>
        public virtual bool Delete(string strAlarmgroupsid)
        {
            string sql = "delete from t_AlarmGroups where  AlarmGroupsID = @AlarmGroupsID";
            SqlParameter parameter = new SqlParameter("@AlarmGroupsID", strAlarmgroupsid);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

