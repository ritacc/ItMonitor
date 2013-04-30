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
    public class MonitorServerParamDA : DALBase
    {
        
		#region 查询
public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
{
string sql = "select * from t_MonitorServerParam";
if (!string.IsNullOrEmpty(where)){
sql = string.Format(" {0} where {1}", sql, where);
}
 DataTable dt = null;
int returnC = 0;try
 {
     dt = db.ExecuteQuery(sql,pageCrrent, pageSize,  out returnC);
  }
  catch (Exception ex)
  {
    throw ex;
  }
 pageCount = returnC;
  return dt;
}

public MonitorServerParamOR selectARowDate(string m_id)
{string sql = string.Format("select * from t_MonitorServerParam where  Paramid='{0}'",m_id);
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
MonitorServerParamOR m_Moni=new MonitorServerParamOR(dr); 
 return m_Moni;

}

		#endregion

		#region 插入
		/// <summary>
		/// 插入t_MonitorServerParam
		/// </summary>
		public virtual bool Insert(MonitorServerParamOR monitorServerParam)
		{
			string sql = "insert into t_MonitorServerParam (ParamID, ParamName, ParamAddr, Param, StationID, StationName, IsCheck, IsSmsCheck) values (@ParamID, @ParamName, @ParamAddr, @Param, @StationID, @StationName, @IsCheck, @IsSmsCheck)";
			SqlParameter [] parameters = new SqlParameter[]
			{
				new SqlParameter("@ParamID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ParamID", DataRowVersion.Default, monitorServerParam.Paramid),
				new SqlParameter("@ParamName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ParamName", DataRowVersion.Default, monitorServerParam.Paramname),
				new SqlParameter("@ParamAddr", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ParamAddr", DataRowVersion.Default, monitorServerParam.Paramaddr),
				new SqlParameter("@Param", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Param", DataRowVersion.Default, monitorServerParam.Param),
				new SqlParameter("@StationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StationID", DataRowVersion.Default, monitorServerParam.Stationid),
				new SqlParameter("@StationName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "StationName", DataRowVersion.Default, monitorServerParam.Stationname),
				new SqlParameter("@IsCheck", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "IsCheck", DataRowVersion.Default, monitorServerParam.Ischeck),
				new SqlParameter("@IsSmsCheck", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "IsSmsCheck", DataRowVersion.Default, monitorServerParam.Issmscheck)
			};
			return db.ExecuteNoQuery(sql, parameters) > -1;
		}
		#endregion

		#region 修改
		/// <summary>
		/// 更新t_MonitorServerParam
		/// </summary>
		public virtual bool Update(MonitorServerParamOR monitorServerParam)
		{
			string sql = "update t_MonitorServerParam set  ParamName = @ParamName,  ParamAddr = @ParamAddr,  Param = @Param,  StationID = @StationID,  StationName = @StationName,  IsCheck = @IsCheck,  IsSmsCheck = @IsSmsCheck where  ParamID = @ParamID";
			SqlParameter [] parameters = new SqlParameter[]
			{
				new SqlParameter("@ParamID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ParamID", DataRowVersion.Default, monitorServerParam.Paramid),
				new SqlParameter("@ParamName", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ParamName", DataRowVersion.Default, monitorServerParam.Paramname),
				new SqlParameter("@ParamAddr", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "ParamAddr", DataRowVersion.Default, monitorServerParam.Paramaddr),
				new SqlParameter("@Param", SqlDbType.VarChar, 50, ParameterDirection.Input, false, 0, 0, "Param", DataRowVersion.Default, monitorServerParam.Param),
				new SqlParameter("@StationID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "StationID", DataRowVersion.Default, monitorServerParam.Stationid),
				new SqlParameter("@StationName", SqlDbType.NVarChar, 100, ParameterDirection.Input, false, 0, 0, "StationName", DataRowVersion.Default, monitorServerParam.Stationname),
				new SqlParameter("@IsCheck", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "IsCheck", DataRowVersion.Default, monitorServerParam.Ischeck),
				new SqlParameter("@IsSmsCheck", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "IsSmsCheck", DataRowVersion.Default, monitorServerParam.Issmscheck)
			};
			return db.ExecuteNoQuery(sql, parameters) > -1;
		}
		#endregion

		#region DELETE
		/// <summary>
		/// 删除t_MonitorServerParam
		/// </summary>
		public virtual bool Delete(string strParamid)
		{
			string sql = "delete from t_MonitorServerParam where  ParamID = @ParamID";
			SqlParameter parameter = new SqlParameter("@ParamID", strParamid);
			return db.ExecuteNoQuery(sql, parameter) > -1;
		}
		#endregion
    }
}

