using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class PerfDBDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select d.Describe descInfo, dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  performance
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join  t_TmpValue xl on xl.DeviceID= d.DeviceID and xl.ChannelNO=11101 
left join  t_TmpValue ms on ms.DeviceID= d.DeviceID and ms.ChannelNO=11102
where dt.typeid=4 ";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} and  {1}", sql, where);
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

        /// <summary>
        /// 根据网络设备ID，查询详细信息
        /// </summary>
        /// <param name="mDeviceID"></param>
        /// <returns></returns>
        public PerfDBOR SelectDeviceDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfDBOR obj = new PerfDBOR(dt);
            //加载网络接口
            obj.SubProts = GetNetPorts(obj.Ports);
            return obj;
        }


        private DataTable GetNetPorts(string strPortinfo)
        {
            if (string.IsNullOrEmpty(strPortinfo))
                return null;
            string mWhere = "";
            //3#^#1705#^#1706#^#1707
            if (strPortinfo.IndexOf("#^#") > 0)
            {
                string[] strArr = strPortinfo.Replace("#^#", "$").Split('$');
                if (strArr.Length < 2)
                    return null;
                mWhere = " d.DeviceID=" + strArr[1];
                for (int i = 2; i < strArr.Length; i++)
                {
                    mWhere += " or d.DeviceID=" + strArr[i];
                }
            }

            string sql = @"select * from dbo.t_TmpValue 
where " + mWhere;

            sql = string.Format(" {0} and  {1}", sql, mWhere);

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

        public DataTable selectMinBytesList(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql =string.Format( @"select d.deviceid,d.DeviceName,kyzj.MonitorValue kyzj,ky.MonitorValue ky from t_Device d
left join t_TmpValue kyzj on kyzj.DeviceID= d.DeviceID and kyzj.ChannelNO=41302
left join t_TmpValue ky on ky.DeviceID= d.DeviceID and ky.ChannelNO=41303
where d.DeviceTypeID= 413 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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

        public DataTable selectTableSpaceDetailList(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,syqk.MonitorValue syqk,yfpzj.MonitorValue yfpzj, bkjqk.MonitorValue bkjqk,
ky.MonitorValue ky, yfpkkj.MonitorValue yfpkkj, kyks.MonitorValue kyks,datafile.MonitorValue datafile 
from t_Device d
left join t_TmpValue syqk on syqk.DeviceID= d.DeviceID and syqk.ChannelNO=42102
left join t_TmpValue yfpzj on yfpzj.DeviceID= d.DeviceID and yfpzj.ChannelNO=42103
left join t_TmpValue bkjqk on bkjqk.DeviceID= d.DeviceID and bkjqk.ChannelNO=42104
left join t_TmpValue ky on ky.DeviceID= d.DeviceID and ky.ChannelNO=42105
left join t_TmpValue yfpkkj on yfpkkj.DeviceID= d.DeviceID and yfpkkj.ChannelNO=42106
left join t_TmpValue kyks on kyks.DeviceID= d.DeviceID and kyks.ChannelNO=42107
left join t_TmpValue datafile on datafile.DeviceID= d.DeviceID and datafile.ChannelNO=42108
where d.DeviceTypeID= 421 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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

        public DataTable selectTableSpaceState(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,state.MonitorValue state,readed.MonitorValue readed, Write.MonitorValue Write,
readedTime.MonitorValue readedTime, WriteTime.MonitorValue WriteTime 
from t_Device d
left join t_TmpValue state on state.DeviceID= d.DeviceID and state.ChannelNO=42202
left join t_TmpValue readed on readed.DeviceID= d.DeviceID and readed.ChannelNO=42203
left join t_TmpValue Write on Write.DeviceID= d.DeviceID and Write.ChannelNO=42204
left join t_TmpValue readedTime on readedTime.DeviceID= d.DeviceID and readedTime.ChannelNO=42205
left join t_TmpValue WriteTime on WriteTime.DeviceID= d.DeviceID and WriteTime.ChannelNO=42206
where d.DeviceTypeID= 422 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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

        public DataTable selectTableSpaceData(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,TableSpaceName.MonitorValue TableSpaceName,State.MonitorValue State, DataFileSize.MonitorValue DataFileSize,
ReadTimes.MonitorValue ReadTimes, WriteTimes.MonitorValue WriteTimes, AverageReadingTime.MonitorValue AverageReadingTime, AverageWriteTime.MonitorValue AverageWriteTime 
from t_Device d
left join t_TmpValue TableSpaceName on TableSpaceName.DeviceID= d.DeviceID and TableSpaceName.ChannelNO=42302
left join t_TmpValue State on State.DeviceID= d.DeviceID and State.ChannelNO=42303
left join t_TmpValue DataFileSize on DataFileSize.DeviceID= d.DeviceID and DataFileSize.ChannelNO=42304
left join t_TmpValue ReadTimes on ReadTimes.DeviceID= d.DeviceID and ReadTimes.ChannelNO=42305
left join t_TmpValue WriteTimes on WriteTimes.DeviceID= d.DeviceID and WriteTimes.ChannelNO=42306
left join t_TmpValue AverageReadingTime on AverageReadingTime.DeviceID= d.DeviceID and AverageReadingTime.ChannelNO=42307
left join t_TmpValue AverageWriteTime on AverageWriteTime.DeviceID= d.DeviceID and AverageWriteTime.ChannelNO=42308
where d.DeviceTypeID= 423 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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
    }
}