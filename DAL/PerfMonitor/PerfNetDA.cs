using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class PerfNetDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select dt.TypeName,sty.name ClassName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join t_ServersType sty on sty.typeid= dt.typeid and sty.ServerID= dt.ServerID 
where dt.typeid=8 ";
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
        public PerfNetDetailOR SelectDeviceDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfNetDetailOR obj = new PerfNetDetailOR(dt);
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
            if(strPortinfo.IndexOf("#^#")>0)
            {
                string[] strArr = strPortinfo.Replace("#^#", "$").Split('$');
                if (strArr.Length < 2)
                    return null;
                mWhere = " d.DeviceID="+ strArr[1];
                for (int i = 2; i < strArr.Length; i++)
                {
                    mWhere += " or d.DeviceID="+ strArr[i];
                }
            }

            string sql = @"select d.DeviceID,d.DeviceName,d.Describe,ReceiveFlow.MonitorValue ReceiveFlow,
SendFlow.MonitorValue SendFlow,ErrorNO.MonitorValue ErrorNO,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf 
from t_Device d 
left join  t_TmpValue ReceiveFlow on ReceiveFlow.DeviceID= d.DeviceID and ReceiveFlow.ChannelNO=33001
left join  t_TmpValue SendFlow on SendFlow.DeviceID= d.DeviceID and SendFlow.ChannelNO=33002
left join  t_TmpValue ErrorNO on ErrorNO.DeviceID= d.DeviceID and ErrorNO.ChannelNO=33003
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

        /// <summary>
        /// 根据网络设备ID，查询详细信息
        /// </summary>
        /// <param name="mDeviceID"></param>
        /// <returns></returns>
        public PerNetPortDetailOR SelectNetPortDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerNetPortDetailOR obj = new PerNetPortDetailOR(dt);
           
            return obj;
        }
        
        public PerfNetAlarmOR SelectErrorNews(string m_id)
        {
            string sql = string.Format("select * from t_AlarmLog where DeviceID='{0}'", m_id);
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
            PerfNetAlarmOR m_obj = new PerfNetAlarmOR(dr);
            return m_obj;
        }

        public DataTable SelectErrorList(int pageCrrent, int pageSize, out int pageCount)
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,su.DISPLAY_NAME,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perfValue--性能
,alar.Content,alar.HappenTime 
from t_AlarmLog alar 
inner join t_Device d  on alar.DeviceID= d.DeviceID 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
left join T_SYS_USERS su on su.guid= alar.OperateUserID 
order by HappenTime desc
";            
            DataTable dt = null;
            int returnC = 0;
            try
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
