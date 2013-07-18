using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GDK.Entity.PerfMonitor;

namespace GDK.DAL.PerfMonitor
{
    public class PerfMiddlewareDA : DALBase
    {
        public DataTable selectDeviceList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select d.DeviceID,d.DeviceName,dt.TypeName, d.IP,d.servname,
case(d.Performance) when '故障' then 0 when  '报警' then 2 when '未启动' then 3 else 1 end  performanceVal
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
where dt.typeid=10 ";
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
        public PerfMiddlewareOR SelectDeviceDetail(string mDeviceID)
        {
            DataTable dt = new TmpValueDA().SelectValues(mDeviceID);
            if (dt == null)
                return null;
            PerfMiddlewareOR obj = new PerfMiddlewareOR(dt);
            //加载网络接口
            //obj.SubProts = GetNetPorts(obj.Ports);
            return obj;
        }


//        private DataTable GetNetPorts(string strPortinfo)
//        {
//            if (string.IsNullOrEmpty(strPortinfo))
//                return null;
//            string mWhere = "";
//            //3#^#1705#^#1706#^#1707
//            if (strPortinfo.IndexOf("#^#") > 0)
//            {
//                string[] strArr = strPortinfo.Replace("#^#", "$").Split('$');
//                if (strArr.Length < 2)
//                    return null;
//                mWhere = " d.DeviceID=" + strArr[1];
//                for (int i = 2; i < strArr.Length; i++)
//                {
//                    mWhere += " or d.DeviceID=" + strArr[i];
//                }
//            }

//            string sql = @"select * from dbo.t_TmpValue 
//where " + mWhere;

//            sql = string.Format(" {0} and  {1}", sql, mWhere);

//            DataTable dt = null;
//            try
//            {
//                dt = db.ExecuteQuery(sql);
//            }
//            catch (Exception ex)
//            {
//                throw ex;
//            }
//            return dt;

//        }

        /// <summary>
        /// Web应用的会话明细
        /// </summary>
        public DataTable selectConversationDetail(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select distinct  d.deviceid,d.DeviceName,ActivityNO.MonitorValue ActivityNO,
MaxNO.MonitorValue MaxNO,TotalNO.MonitorValue TotalNO,ServletNO.MonitorValue ServletNO
 from t_DevItemList d 
left join t_TmpValue ActivityNO on d.DeviceID= d.DeviceID and ActivityNO.ChannelNO=21102
left join t_TmpValue MaxNO on MaxNO.DeviceID= d.DeviceID and MaxNO.ChannelNO=21103
left join t_TmpValue TotalNO on TotalNO.DeviceID= d.DeviceID and TotalNO.ChannelNO=21104
left join t_TmpValue ServletNO on ServletNO.DeviceID= d.DeviceID and ServletNO.ChannelNO=21105
where d.DeviceTypeID= 211 and ParentDevID ={0} order by DeviceName", ParentDevID);
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
        /// 进程明细
        /// </summary>
        public DataTable selectThreadDetail(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,ThreadName.MonitorValue ThreadName,ThreadNO.MonitorValue ThreadNO,
FreeThreadNO.MonitorValue FreeThreadNO,Throughput.MonitorValue Throughput,UndecidedNO.MonitorValue UndecidedNO
 from t_DevItemList d 
left join t_TmpValue ThreadName on ThreadName.DeviceID= d.DeviceID and ThreadName.ChannelNO=22201
left join t_TmpValue ThreadNO on ThreadNO.DeviceID= d.DeviceID and ThreadNO.ChannelNO=22202
left join t_TmpValue FreeThreadNO on FreeThreadNO.DeviceID= d.DeviceID and FreeThreadNO.ChannelNO=22203
left join t_TmpValue Throughput on Throughput.DeviceID= d.DeviceID and Throughput.ChannelNO=22204
left join t_TmpValue UndecidedNO on UndecidedNO.DeviceID= d.DeviceID and UndecidedNO.ChannelNO=22205
where d.DeviceTypeID= 222 and ParentDevID ={0} order by DeviceName", ParentDevID);
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
        /// 数据库连接池明细
        /// </summary>
        public DataTable selectPoolingDetails(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,ConnectionPoolingName.MonitorValue ConnectionPoolingName,ConnectionPoolingSize.MonitorValue ConnectionPoolingSize,
ActiveConnection.MonitorValue ActiveConnection,ActiveConnectionNO.MonitorValue ActiveConnectionNO,
MissedConnection.MonitorValue MissedConnection,ThreadWait.MonitorValue ThreadWait
 from t_DevItemList d 
left join t_TmpValue ConnectionPoolingName on ConnectionPoolingName.DeviceID= d.DeviceID and ConnectionPoolingName.ChannelNO=22601
left join t_TmpValue ConnectionPoolingSize on ConnectionPoolingSize.DeviceID= d.DeviceID and ConnectionPoolingSize.ChannelNO=22602
left join t_TmpValue ActiveConnection on ActiveConnection.DeviceID= d.DeviceID and ActiveConnection.ChannelNO=22603
left join t_TmpValue ActiveConnectionNO on ActiveConnectionNO.DeviceID= d.DeviceID and ActiveConnectionNO.ChannelNO=22604
left join t_TmpValue MissedConnection on MissedConnection.DeviceID= d.DeviceID and MissedConnection.ChannelNO=22605
left join t_TmpValue ThreadWait on ThreadWait.DeviceID= d.DeviceID and ThreadWait.ChannelNO=22606
where d.DeviceTypeID= 226 and ParentDevID ={0} order by DeviceName", ParentDevID);
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
        /// 最近1小时的服务器应答时间
        /// </summary>
        public DataTable selectServerResponseTime(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.*,MinMs.MonitorValue MinMs,MaxMs.MonitorValue MaxMs,
AverageMs.MonitorValue AverageMs,ResponseTime.MonitorValue ResponseTime
 from t_DevItemList d 
left join t_TmpValue MinMs on MinMs.DeviceID= d.DeviceID and MinMs.ChannelNO=22301
left join t_TmpValue MaxMs on MaxMs.DeviceID= d.DeviceID and MaxMs.ChannelNO=22302
left join t_TmpValue AverageMs on AverageMs.DeviceID= d.DeviceID and AverageMs.ChannelNO=22303
left join t_TmpValue ResponseTime on ResponseTime.DeviceID= d.DeviceID and ResponseTime.ChannelNO=22304
where d.DeviceTypeID= 223 and ParentDevID ={0} order by DeviceName", ParentDevID);
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
        /// 线程等待
        /// </summary>
        public DataTable selectThreadWait(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid, d.DeviceName,ATTRIBUTENAME.MonitorValue ATTRIBUTENAME,ATTRIBUTEVALUE.MonitorValue ATTRIBUTEVALUE,
CONLLECTIONTIME.MonitorValue CONLLECTIONTIME
 from t_DevItemList d 
left join t_TmpValue ATTRIBUTENAME on ATTRIBUTENAME.DeviceID= d.DeviceID and ATTRIBUTENAME.ChannelNO=22401
left join t_TmpValue ATTRIBUTEVALUE on ATTRIBUTEVALUE.DeviceID= d.DeviceID and ATTRIBUTEVALUE.ChannelNO=22402
left join t_TmpValue CONLLECTIONTIME on CONLLECTIONTIME.DeviceID= d.DeviceID and CONLLECTIONTIME.ChannelNO=22403
where d.DeviceTypeID= 224 and ParentDevID ={0}", ParentDevID);
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
        /// 最近1小时的JVM堆使用情况
        /// </summary>
        public DataTable selectJVMHeap( int ParentDevID)
        {
            DateTime EndTime = DateTime.Now;
            DateTime StartTime= DateTime.Now.AddHours(-1);
            string strTableName = new HistoryValueDA().GetTableName(ParentDevID);
            if (strTableName == "")
                return null;

            string sql = string.Format(@"select f.*,TotalHeap.MonitorValue TotalHeap,CurrentHeap.MonitorValue CurrentHeap 
from(
	select max(convert(float,d.monitorvalue)) MaxHeap
	,min(convert(float,d.monitorvalue)) MinHeap,
	round(avg(convert(float,d.monitorvalue)) ,2) AverageHeap
	 from {0}  d
	where d.ChannelNO=22505 and  MonitorTime>'{1}' and MonitorTime<'{2}'
) as f
left join t_TmpValue TotalHeap on TotalHeap.DeviceID= {3} and TotalHeap.ChannelNO=22504
left join t_TmpValue CurrentHeap on CurrentHeap.DeviceID= {3} and CurrentHeap.ChannelNO=22505"
                , strTableName
                , StartTime.ToString("yyyy-MM-dd HH:mm:ss")
                , EndTime.ToString("yyyy-MM-dd HH:mm:ss")
                , ParentDevID);
            DataTable dt = null;
            //int returnC = 0;
            try
            {
                dt = db.ExecuteQuery(sql);//, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //pageCount = returnC;
            return dt;
        }

        /// <summary>
        /// Web应用 -最近1小时最高用户会话（前5位）
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public DataTable SelectWebSessionImg(int DeviceID, DateTime StartTime, DateTime EndTime)
        {
            string strTableName = new HistoryValueDA().GetTableName(DeviceID);
            if (strTableName == "")
                return null;
            string sql = string.Format(@"
            select top 5 gro.*,ditem.DeviceName from (
                select  DeviceID,avg(monitorvalue) maxval from (	
                select  DeviceID,convert(bigint, monitorvalue) monitorvalue
                    from {0}
                    where channelno=21102  and  MonitorTime>'{1}' and MonitorTime<'{2}'
                ) as d  
                group by DeviceID
            ) as gro
            inner join t_DevItemList ditem on ditem.DeviceID= gro.DeviceID
            order by maxval", strTableName
                            ,StartTime.ToString("yyyy-MM-dd HH:mm:ss")
                            , EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return db.ExecuteQuery(sql);
        }

        /// <summary>
        /// 线程使用-最后1小时
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <param name="StartTime"></param>
        /// <param name="EndTime"></param>
        /// <returns></returns>
        public DataTable SelectProcesNumber(int DeviceID, DateTime StartTime, DateTime EndTime)
        {
            string strTableName = new HistoryValueDA().GetTableName(DeviceID);
            if (strTableName == "")
                return null;
            string sql = string.Format(@"
            select top 5 gro.*,ditem.DeviceName from (
                select  DeviceID,avg(monitorvalue) maxval from (	
                select  DeviceID,convert(bigint, monitorvalue) monitorvalue
                    from {0}
                    where channelno=22202 and  MonitorTime>'{1}' and MonitorTime<'{2}'
                ) as d  
                group by DeviceID
            ) as gro
            inner join t_DevItemList ditem on ditem.DeviceID= gro.DeviceID
            order by maxval", strTableName
                            , StartTime.ToString("yyyy-MM-dd HH:mm:ss")
                            , EndTime.ToString("yyyy-MM-dd HH:mm:ss"));
            return db.ExecuteQuery(sql);
        }

    }
}