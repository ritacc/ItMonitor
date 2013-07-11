using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;
using GDK.DAL.SerMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class TmpValueDA : DALBase
    {

        public DataTable SelectValues(string mDeviceID)
        {
			if (string.IsNullOrEmpty(mDeviceID))
				return null;
            string sql = string.Format("select * from t_TmpValue where DeviceID={0}", mDeviceID);
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
        public object SelectValue(string mDeviceID, string ChanncelNo)
        {
            string sql = string.Format("select MonitorValue from t_TmpValue where DeviceID={0} and ChannelNo={1}", mDeviceID, ChanncelNo);
            object val = new object();
            try
            {
                val = db.ExecuteScalar(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return val;
        }

		/// <summary>
		/// 查询刷新数据
		/// </summary>
		/// <returns></returns>
		public DeviceANDItemRefOR SelectRefData(string mDeviceID)
		{
			DeviceOREx obj = new DeviceDA().SelectDeviceORExByID(mDeviceID);
			if (obj == null)
			{
				DeviceItemOREx objItem = new DeviceDA().SelectDeviceItemORExByID(mDeviceID);
				if (objItem == null)
					return null;
				return new DeviceANDItemRefOR(objItem);
			}
			return new DeviceANDItemRefOR(obj);
		}


    }
}
