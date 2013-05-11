using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.SerMonitor;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.SerMonitor
{
    public class DeviceDA : DALBase
    {
        public DeviceDA()
        {
            db = MoniBase;
        }
        /// <summary>
        /// 选择站点下的设备
        /// </summary>
        /// <returns></returns>
        public DataTable SelectDeviceByStationID(string strID)
        {
            string sql = string.Format("select * from t_Device where stationid={0} order by deviceName", strID);
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

        /// <summary>
        /// 选择设备下的通道
        /// </summary>
        /// <param name="strID"></param>
        /// <returns></returns>
        public DataTable SelectChannelByDeviceID(string strID)
        {
            if (string.IsNullOrEmpty(strID))
                return null;
            string sql = string.Format("select * from t_Channel where DeviceID={0} order by ChannelName", strID);
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
        /// <summary>
        /// 选择站点下的设备
        /// </summary>
        /// <param name="strDeviceID">设备ID</param>
        /// <param name="StationID">站点ID</param>
        /// <param name="DeviceTypeID">设备类型ID</param>
        /// <returns></returns>
        public DataTable SelectChannelByDeviceID(string strDeviceID, string StationID, string DeviceTypeID)
        {
            string sql = string.Format(@"select 
*,dbo.F_ISExisAlarmPolicy({0},{1},{2},Channelno) as ISHavePolice from t_Channel where DeviceID={2} order by ChannelName",
StationID, DeviceTypeID, strDeviceID);
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

        /// <summary>
        /// 选择站点下的设备
        /// </summary>
        /// <param name="strDeviceID">设备ID</param>
        /// <param name="StationID">站点ID</param>
        /// <param name="DeviceTypeID">设备类型ID</param>
        /// <returns></returns>
        public DataTable SelectAllGenerdChannelByDeviceID(string strDeviceID, string StationID, string DeviceTypeID)
        {
            string sql = string.Format(@"select 
*,dbo.F_ISExisAlarmPolicy({0},{1},{2},Channelno) as ISHavePolice from t_Channel where DeviceID={2} order by ChannelName",
StationID, DeviceTypeID, strDeviceID);
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


        public DataTable GetAllDeviceType()
        {
            string sql = "select * from t_DeviceType";
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
        /// <summary>
        /// 根据站点、设备类型查询设备
        /// </summary>
        /// <param name="nStationID"></param>
        /// <param name="mDeviceTypeID"></param>
        /// <returns></returns>
        public DataTable GetAllGenerdDevice(string nStationID, string mDeviceTypeID)
        {
            string sql = string.Format(@"select d.*,dt.DeviceTypeID from t_Device d
inner join  t_DeviceType dt on d.DeviceTypeID=dt.DeviceTypeID and d.stationid={0} and dt.DeviceTypeID={1} "
                , nStationID, mDeviceTypeID);
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
        public DataTable GetAllGenerdDevice(string nStationID)
        {
            string sql = string.Format(@"select d.*,dt.DeviceTypeID from t_Device d
inner join  t_DeviceType dt on d.DeviceTypeID=dt.DeviceTypeID and d.stationid={0}", nStationID);
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

        public DataTable GetDevLightAlarmByID(int LightID)
        {
            string sql = string.Format("select * from t_LightAlarm where LightID={0}", LightID);
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

        /// <summary>
        /// 查询所有声光报警
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllLightAlarm()
        {
            string sql = string.Format("select * from t_LightAlarm");
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

        public List<DeviceObj> GetAllDevice(int StationID)
        {
            string strSql = string.Format("select * from v_Device where StationID={0} and StationID is not null", StationID);
            DataTable dt = db.ExecuteQuery(strSql);

            List<DeviceObj> m_list = new List<DeviceObj>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DeviceObj m_obj = new DeviceObj();
                m_obj.strDeviceName = dt.Rows[i]["DeviceName"].ToString();
                m_obj.nCommunicateType = int.Parse(dt.Rows[i]["CommunicateType"].ToString());
                m_obj.nCommunicateID = int.Parse(dt.Rows[i]["CommunicateID"].ToString());
                m_obj.strSubAddr = dt.Rows[i]["SubAddr"].ToString();
                m_obj.nDeviceTypeID = int.Parse(dt.Rows[i]["DeviceTypeID"].ToString());
                m_obj.nDeviceID = int.Parse(dt.Rows[i]["DeviceID"].ToString());
                m_obj.strParseDLL = dt.Rows[i]["ParseDll"].ToString();
                m_obj.strTypeName = dt.Rows[i]["TypeName"].ToString();

                m_list.Add(m_obj);

            }

            return m_list;
        }

        /// <summary>
        /// 获取通道值类型
        /// </summary>
        /// <param name="DevID"></param>
        /// <param name="ChannelNo"></param>
        /// <returns></returns>
        public int GetChannelValueType(string DevID, string ChannelNo)
        {
            int ValueType = 0;
            string sql = string.Format("select * from dbo.t_ChannelType where DeviceTypeID=(select DeviceTypeID from dbo.t_Device where DeviceID={0} ) and ChannelNo={1}", DevID, ChannelNo);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
            }
            else
            {
                sql = string.Format("select * from dbo.t_GenChannelType where DeviceTypeID=(select DeviceTypeID from dbo.t_Device where DeviceID={0} ) and ChannelNo={1}", DevID, ChannelNo);
                dt = db.ExecuteQuery(sql);
            }
            if (dt != null && dt.Rows.Count > 0)
                if (dt.Rows[0]["ValueType"].ToString() != string.Empty)
                    ValueType = int.Parse(dt.Rows[0]["ValueType"].ToString());
                else
                    ValueType = 0;
            return ValueType;
        }

        /// <summary>
        /// 根据设备ID查询，设备类型
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public int GetDeviceTypeID(string DeviceID)
        {
            string sql = string.Format("select TOP 1 DeviceTypeID from t_Device  where Deviceid ='{0}'", DeviceID);
            DataTable dt = db.ExecuteQuery(sql);
            int DeviceTypeID = int.Parse(dt.Rows[0]["DeviceTypeID"].ToString());
            return DeviceTypeID;
        }


        #region 获取名称

        public string GetDeviceTypeName(string strTypeID)
        {
            string sql = string.Format("select TypeName from t_DeviceType   where DeviceTypeID='{0}'", strTypeID);
            return db.ExecuteScalar(sql).ToString();
        }

        public string GetDeviceName(string strDeviceID)
        {
            string sql = string.Format("select DeviceName from t_Device   where DeviceID='{0}'", strDeviceID);
            return db.ExecuteScalar(sql).ToString();
        }
        public string GetChannelName(string strChannelID)
        {
            string sql = string.Format("select ChannelName from t_Channel   where ChannelNo='{0}'", strChannelID);
            return db.ExecuteScalar(sql).ToString();
        }
        #endregion

        /// <summary>
        /// 所有事件名
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllEventsName()
        {
            string sql = string.Format("select distinct EventsName from t_AlarmLog");
            return db.ExecuteQuery(sql);
        }

        /// <summary>
        /// 获取所有事件确认者
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllSureName()
        {
            string sql = string.Format("select distinct OperateUserID,display_Name from t_AlarmLog a,T_SYS_USERS u  where a.OperateUserID=u.guid");
            return db.ExecuteQuery(sql);
        }

        public DeviceOR SelectDeviceORByID(string m_id)
        {
            string sql = string.Format("select * from t_Device where  Deviceid='{0}'", m_id);
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
            DeviceOR m_obj = new DeviceOR(dr);
            return m_obj;
        }
    }
}
