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
    public class MonitorSystemParamDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere()
        {
            string sql = "select * from t_MonitorSystemParam";
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
        public DataTable selectAllScreen()
        {
            string sql = "select * from t_Screen";
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

        public DataTable SelectAllParm()
        {
            string sql = "select * from t_SysPara";
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

        public MonitorSystemParamOR selectARowDate()
        {
            string sql = string.Format("select * from t_MonitorSystemParam");
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
            MonitorSystemParamOR m_Moni = new MonitorSystemParamOR(dr);
            return m_Moni;

        }

        #endregion


        #region 修改
       /// <summary>
       /// 
       /// </summary>
       /// <param name="monitorSystemParam"></param>
       /// <param name="AutoStartVideo">是否自动启动录像</param>
       /// <param name="VideoScreenID">自动录像ScreenID</param>
       /// <param name="AlarmMaxLevel">最大告警层次</param>
       /// <returns></returns>
        public virtual bool Update(MonitorSystemParamOR monitorSystemParam, bool AutoStartVideo,
            string VideoScreenID,string AlarmMaxLevel)
        {
            string sql = "update t_MonitorSystemParam set  MonitorRefreshTime = @MonitorRefreshTime,  StartScreenID = @StartScreenID,  AlarmLogTime = @AlarmLogTime,  ServerIP = @ServerIP,  ServerPort = @ServerPort";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@MonitorRefreshTime", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "MonitorRefreshTime", DataRowVersion.Default, monitorSystemParam.Monitorrefreshtime),
				new SqlParameter("@StartScreenID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StartScreenID", DataRowVersion.Default, monitorSystemParam.Startscreenid),
				new SqlParameter("@AlarmLogTime", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "AlarmLogTime", DataRowVersion.Default, monitorSystemParam.Alarmlogtime),
				new SqlParameter("@ServerIP", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "ServerIP", DataRowVersion.Default, monitorSystemParam.Serverip),
				new SqlParameter("@ServerPort", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ServerPort", DataRowVersion.Default, monitorSystemParam.Serverport)
			};
            db.ExecuteNoQuery(sql, parameters);

          string  strSql = string.Format("select count(*) from t_SysPara where KeyStr='AutoStartVideo'");
            string s =db.ExecuteScalar(strSql).ToString();
            bool b = false;
            if (s != "")
            {
                int count = int.Parse(s);
                if (count > 0)
                    b = true;
            }
            if (b)
            {
                strSql = string.Format("update t_SysPara set ValStr='{0}' where KeyStr='AutoStartVideo'", AutoStartVideo ? "1" : "0");
                db.ExecuteNoQuery(strSql);
            }
            else
            {
                strSql = string.Format("insert into t_SysPara (KeyStr,ValStr) values('AutoStartVideo','{0}')", AutoStartVideo ? "1" : "0");
                db.ExecuteNoQuery(strSql);
            }

            strSql = string.Format("select count(*) from t_SysPara where KeyStr='VideoScreenID'");
            s = db.ExecuteScalar(strSql).ToString();
            b = false;
            if (s != "")
            {
                int count = int.Parse(s);
                if (count > 0)
                    b = true;
            }
            if (b)
            {
                strSql = string.Format("update t_SysPara set ValStr='{0}' where KeyStr='VideoScreenID'", VideoScreenID);
                db.ExecuteNoQuery(strSql);
            }
            else
            {
                strSql = string.Format("insert into t_SysPara (KeyStr,ValStr) values('VideoScreenID','{0}')", VideoScreenID);
                db.ExecuteNoQuery(strSql);
            }

            strSql = string.Format("select count(*) from t_SysPara where KeyStr='AlarmMaxLevel'");
            s = db.ExecuteScalar(strSql).ToString();
            b = false;
            if (s != "")
            {
                int count = int.Parse(s);
                if (count > 0)
                    b = true;
            }
            if (b)
            {
                strSql = string.Format("update t_SysPara set ValStr='{0}' where KeyStr='AlarmMaxLevel'", AlarmMaxLevel);
                db.ExecuteNoQuery(strSql);
            }
            else
            {
                strSql = string.Format("insert into t_SysPara (KeyStr,ValStr) values('AlarmMaxLevel','{0}')", AlarmMaxLevel);
                db.ExecuteNoQuery(strSql);
            }
            return true;

        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_MonitorSystemParam
        /// </summary>
        public virtual bool Delete(string strId)
        {
            string sql = "delete from t_MonitorSystemParam where  ID = @ID";
            SqlParameter parameter = new SqlParameter("@ID", strId);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

