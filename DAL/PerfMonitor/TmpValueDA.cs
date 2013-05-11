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

    }
}
