using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.CompSearch;
using System.Data.SqlClient;


namespace GDK.DAL.CompSearch
{
	/// <summary>
	/// 
	/// </summary>
	public class ReportConfigDA : DALBase
	{

		#region 查询
		public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
		{
			string sql = "select * from t_ReportConfig";
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

		public ReportConfigOR selectARowDate(int m_id)
		{
			string sql = string.Format("select * from t_ReportConfig where  Bussystemid='{0}'", m_id);
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
				return  new ReportConfigOR();
			if (dt.Rows.Count == 0)
				return new ReportConfigOR();
			DataRow dr = dt.Rows[0];
			ReportConfigOR m_Repo = new ReportConfigOR(dr);
			return m_Repo;
		}

		#endregion

		#region 插入
		/// <summary>
		/// 插入t_ReportConfig
		/// </summary>
		public virtual bool Insert(ReportConfigOR reportConfig)
		{
			ReportConfigOR temp = selectARowDate(reportConfig.Bussystemid);
			if (temp.Bussystemid > 0)
			{
				return Update(reportConfig);
			}

			string sql = "insert into t_ReportConfig (BusSystemID, Host_DiskUseRate, Host_Memory, Host_CPUUseRate, DB_TableNameSpace, DB_Hitrate, DB_OnlineTime, Mid_Session, Mid_JVMUse, Mid_ConnPool, System_Stop, StopInfo, AvailableRate) values (@BusSystemID, @Host_DiskUseRate, @Host_Memory, @Host_CPUUseRate, @DB_TableNameSpace, @DB_Hitrate, @DB_OnlineTime, @Mid_Session, @Mid_JVMUse, @Mid_ConnPool, @System_Stop, @StopInfo, @AvailableRate)";
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BusSystemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "BusSystemID", DataRowVersion.Default, reportConfig.Bussystemid),
				new SqlParameter("@Host_DiskUseRate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Host_DiskUseRate", DataRowVersion.Default, reportConfig.HostDiskuserate),
				new SqlParameter("@Host_Memory", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Host_Memory", DataRowVersion.Default, reportConfig.HostMemory),
				new SqlParameter("@Host_CPUUseRate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Host_CPUUseRate", DataRowVersion.Default, reportConfig.HostCpuuserate),
				new SqlParameter("@DB_TableNameSpace", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "DB_TableNameSpace", DataRowVersion.Default, reportConfig.DbTablenamespace),
				new SqlParameter("@DB_Hitrate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "DB_Hitrate", DataRowVersion.Default, reportConfig.DbHitrate),
				new SqlParameter("@DB_OnlineTime", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "DB_OnlineTime", DataRowVersion.Default, reportConfig.DbOnlinetime),
				new SqlParameter("@Mid_Session", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Mid_Session", DataRowVersion.Default, reportConfig.MidSession),
				new SqlParameter("@Mid_JVMUse", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Mid_JVMUse", DataRowVersion.Default, reportConfig.MidJvmuse),
				new SqlParameter("@Mid_ConnPool", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Mid_ConnPool", DataRowVersion.Default, reportConfig.MidConnpool),
				new SqlParameter("@System_Stop", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "System_Stop", DataRowVersion.Default, reportConfig.SystemStop),
				new SqlParameter("@StopInfo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "StopInfo", DataRowVersion.Default, reportConfig.Stopinfo),
				new SqlParameter("@AvailableRate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "AvailableRate", DataRowVersion.Default, reportConfig.Availablerate)
			};
			return db.ExecuteNoQuery(sql, parameters) > -1;
		}
		#endregion

		#region 修改
		/// <summary>
		/// 更新t_ReportConfig
		/// </summary>
		public virtual bool Update(ReportConfigOR reportConfig)
		{
			string sql = "update t_ReportConfig set  Host_DiskUseRate = @Host_DiskUseRate,  Host_Memory = @Host_Memory,  Host_CPUUseRate = @Host_CPUUseRate,  DB_TableNameSpace = @DB_TableNameSpace,  DB_Hitrate = @DB_Hitrate,  DB_OnlineTime = @DB_OnlineTime,  Mid_Session = @Mid_Session,  Mid_JVMUse = @Mid_JVMUse,  Mid_ConnPool = @Mid_ConnPool,  System_Stop = @System_Stop,  StopInfo = @StopInfo,  AvailableRate = @AvailableRate where  BusSystemID = @BusSystemID";
			SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@BusSystemID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "BusSystemID", DataRowVersion.Default, reportConfig.Bussystemid),
				new SqlParameter("@Host_DiskUseRate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Host_DiskUseRate", DataRowVersion.Default, reportConfig.HostDiskuserate),
				new SqlParameter("@Host_Memory", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Host_Memory", DataRowVersion.Default, reportConfig.HostMemory),
				new SqlParameter("@Host_CPUUseRate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Host_CPUUseRate", DataRowVersion.Default, reportConfig.HostCpuuserate),
				new SqlParameter("@DB_TableNameSpace", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "DB_TableNameSpace", DataRowVersion.Default, reportConfig.DbTablenamespace),
				new SqlParameter("@DB_Hitrate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "DB_Hitrate", DataRowVersion.Default, reportConfig.DbHitrate),
				new SqlParameter("@DB_OnlineTime", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "DB_OnlineTime", DataRowVersion.Default, reportConfig.DbOnlinetime),
				new SqlParameter("@Mid_Session", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Mid_Session", DataRowVersion.Default, reportConfig.MidSession),
				new SqlParameter("@Mid_JVMUse", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Mid_JVMUse", DataRowVersion.Default, reportConfig.MidJvmuse),
				new SqlParameter("@Mid_ConnPool", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "Mid_ConnPool", DataRowVersion.Default, reportConfig.MidConnpool),
				new SqlParameter("@System_Stop", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "System_Stop", DataRowVersion.Default, reportConfig.SystemStop),
				new SqlParameter("@StopInfo", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "StopInfo", DataRowVersion.Default, reportConfig.Stopinfo),
				new SqlParameter("@AvailableRate", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "AvailableRate", DataRowVersion.Default, reportConfig.Availablerate)
			};
			return db.ExecuteNoQuery(sql, parameters) > -1;
		}
		#endregion

		#region DELETE
		/// <summary>
		/// 删除t_ReportConfig
		/// </summary>
		public virtual bool Delete(string strBussystemid)
		{
			string sql = "delete from t_ReportConfig where  BusSystemID = @BusSystemID";
			SqlParameter parameter = new SqlParameter("@BusSystemID", strBussystemid);
			return db.ExecuteNoQuery(sql, parameter) > -1;
		}
		#endregion
	}
}

