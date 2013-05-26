using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.PerfMonitor
{
    public class TmpValueDA : DALBase
    {

        public DataTable SelectValues(string mDeviceID)
        {
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


    }
}
