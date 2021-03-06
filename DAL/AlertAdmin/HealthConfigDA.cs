﻿using System;
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
    public class HealthConfigDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from t_HealthConfig";
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
        public DataTable selectDataByDeviceID(string strID)
        {
            string sql = @"select hea.*,d.DeviceName,c.ChannelName from t_HealthConfig hea
left join t_Device d on hea.SDID=d.DeviceID
left join t_Channel c on hea.ChannelNo=c.ChannelNo and c.DeviceID=d.DeviceID
where hea.DeviceID=" + strID;
           
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);//, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
            return dt;
        }

        public HealthConfigOR selectARowDate(string m_id)
        {
            string sql = string.Format("select * from t_HealthConfig where  id='{0}'", m_id);
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
            HealthConfigOR m_Heal = new HealthConfigOR(dr);
            return m_Heal;

        }

        #endregion

        #region 插入
        /// <summary>
        /// 插入t_HealthConfig
        /// </summary>
        public virtual bool Insert(HealthConfigOR healthConfig)
        {
            string sql = @"insert into t_HealthConfig (ID,DeviceID, SDID,EffectLevel) 
values (@ID,@DeviceID, @SDID, @EffectLevel)";
           
            SqlParameter[] parameters = new SqlParameter[]
			{
                new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, healthConfig.ID),
				new SqlParameter("@DeviceID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "DeviceID", DataRowVersion.Default, healthConfig.Deviceid),
				new SqlParameter("@SDID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "SDID", DataRowVersion.Default, healthConfig.Sdid),
				//new SqlParameter("@PDID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "PDID", DataRowVersion.Default, healthConfig.Pdid),
				
				new SqlParameter("@EffectLevel", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "EffectLevel", DataRowVersion.Default, healthConfig.Effectlevel)
			};
            SqlParameter pChannel = new SqlParameter("@ChannelNO", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ChannelNO", DataRowVersion.Default, healthConfig.Channelno);
            SqlParameter[] paraNew;
            if (healthConfig.Channelno.HasValue)
            {
                sql = @"insert into t_HealthConfig (ID,DeviceID, SDID,ChannelNO, EffectLevel) 
values (@ID,@DeviceID, @SDID,@ChannelNO, @EffectLevel)";
                paraNew = InsertPara(parameters, pChannel);
            }
            else
            {
                paraNew = parameters;
            }
            return db.ExecuteNoQuery(sql, paraNew) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新t_HealthConfig
        /// </summary>
        public virtual bool Update(HealthConfigOR healthConfig)
        {
            string sql = @"update t_HealthConfig set  SDID = @SDID,  ChannelNO = NULL,  EffectLevel = @EffectLevel where  ID = @ID";
            SqlParameter[] parameters = new SqlParameter[]
			{
                 new SqlParameter("@ID", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ID", DataRowVersion.Default, healthConfig.ID),
				new SqlParameter("@SDID", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "SDID", DataRowVersion.Default, healthConfig.Sdid),
				//new SqlParameter("@ChannelNO", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ChannelNO", DataRowVersion.Default, healthConfig.Channelno),
				new SqlParameter("@EffectLevel", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "EffectLevel", DataRowVersion.Default, healthConfig.Effectlevel)
			};

            
            SqlParameter pChannel = new SqlParameter("@ChannelNO", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "ChannelNO", DataRowVersion.Default, healthConfig.Channelno);
            SqlParameter[] paraNew;
            if (healthConfig.Channelno.HasValue)
            {
                sql = @"update t_HealthConfig set  SDID = @SDID,  ChannelNO = @ChannelNO,  EffectLevel = @EffectLevel where  ID = @ID";
                paraNew = InsertPara(parameters, pChannel);
            }
            else
            {
                paraNew = parameters;
            }
            return db.ExecuteNoQuery(sql, paraNew) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除t_HealthConfig
        /// </summary>
        public virtual bool Delete(string strID)
        {
            string sql = "delete from t_HealthConfig where  ID = @DeviceID";
            SqlParameter parameter = new SqlParameter("@DeviceID", strID);
            return db.ExecuteNoQuery(sql, parameter) > -1;
        }
        #endregion
    }
}

