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
            string sql = @"select dt.TypeName,d.*,
case(d.Performance) when '故障' then 1 when  '报警' then 2 when '未启动' then 3 else 0 end  perf
from t_Device d 
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID 
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

        public DataTable selectConversationDetailList(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,State.MonitorValue State,Machine.MonitorValue Machine,
UserName.MonitorValue UserName,Processed.MonitorValue Processed,CpuUsage.MonitorValue CpuUsage,MemorySequence.MonitorValue MemorySequence,
TableScan.MonitorValue TableScan,PhysicalRead.MonitorValue PhysicalRead,LogicalRead.MonitorValue LogicalRead,
Submit.MonitorValue Submit,sqlCursor.MonitorValue sqlCursor,BufferHitRate.MonitorValue BufferHitRate
 from t_Device d
left join t_TmpValue State on State.DeviceID= d.DeviceID and State.ChannelNO=43102
left join t_TmpValue Machine on Machine.DeviceID= d.DeviceID and Machine.ChannelNO=43103
left join t_TmpValue UserName on UserName.DeviceID= d.DeviceID and UserName.ChannelNO=43104
left join t_TmpValue Processed on Processed.DeviceID= d.DeviceID and Processed.ChannelNO=43105
left join t_TmpValue CpuUsage on CpuUsage.DeviceID= d.DeviceID and CpuUsage.ChannelNO=43106
left join t_TmpValue MemorySequence on MemorySequence.DeviceID= d.DeviceID and MemorySequence.ChannelNO=43107
left join t_TmpValue TableScan on TableScan.DeviceID= d.DeviceID and TableScan.ChannelNO=43108
left join t_TmpValue PhysicalRead on PhysicalRead.DeviceID= d.DeviceID and PhysicalRead.ChannelNO=43109
left join t_TmpValue LogicalRead on LogicalRead.DeviceID= d.DeviceID and LogicalRead.ChannelNO=43110
left join t_TmpValue Submit on Submit.DeviceID= d.DeviceID and Submit.ChannelNO=43111
left join t_TmpValue sqlCursor on sqlCursor.DeviceID= d.DeviceID and sqlCursor.ChannelNO=43112
left join t_TmpValue BufferHitRate on State.DeviceID= d.DeviceID and State.ChannelNO=43113
where d.DeviceTypeID= 431 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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

        public DataTable selectConversationCollect(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,State.MonitorValue State,Program.MonitorValue Program,
Times.MonitorValue Times
 from t_Device d
left join t_TmpValue State on State.DeviceID= d.DeviceID and State.ChannelNO=43202
left join t_TmpValue Program on Program.DeviceID= d.DeviceID and Program.ChannelNO=43203
left join t_TmpValue Times on Times.DeviceID= d.DeviceID and Times.ChannelNO=43204
where d.DeviceTypeID= 432 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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

        public DataTable selectConversationNO(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,UserName.MonitorValue UserName,sqlEvent.MonitorValue sqlEvent,
State.MonitorValue State,WaitTime.MonitorValue WaitTime,Waits.MonitorValue Waits
 from t_Device d
left join t_TmpValue UserName on UserName.DeviceID= d.DeviceID and UserName.ChannelNO=43302
left join t_TmpValue sqlEvent on sqlEvent.DeviceID= d.DeviceID and sqlEvent.ChannelNO=43303
left join t_TmpValue State on State.DeviceID= d.DeviceID and State.ChannelNO=43304
left join t_TmpValue WaitTime on WaitTime.DeviceID= d.DeviceID and WaitTime.ChannelNO=43305
left join t_TmpValue Waits on Waits.DeviceID= d.DeviceID and Waits.ChannelNO=43306
where d.DeviceTypeID= 433 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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

        public DataTable selectDBBack(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,TableSpaceName.MonitorValue TableSpaceName,
State.MonitorValue State,CurrentSize.MonitorValue CurrentSize,InitialLength.MonitorValue InitialLength,
NextLength.MonitorValue NextLength,
MinLength.MonitorValue MinLength,MaxLength.MonitorValue MaxLength,HitRate.MonitorValue HitRate,
HWMSize.MonitorValue HWMSize,Search.MonitorValue Search,Wraps.MonitorValue Wraps,Expand.MonitorValue Expand 
 from t_Device d
left join t_TmpValue TableSpaceName on TableSpaceName.DeviceID= d.DeviceID and TableSpaceName.ChannelNO=44102
left join t_TmpValue State on State.DeviceID= d.DeviceID and State.ChannelNO=44103
left join t_TmpValue CurrentSize on CurrentSize.DeviceID= d.DeviceID and CurrentSize.ChannelNO=44104
left join t_TmpValue InitialLength on InitialLength.DeviceID= d.DeviceID and InitialLength.ChannelNO=44105
left join t_TmpValue NextLength on NextLength.DeviceID= d.DeviceID and NextLength.ChannelNO=44106
left join t_TmpValue MinLength on MinLength.DeviceID= d.DeviceID and MinLength.ChannelNO=44107
left join t_TmpValue MaxLength on MaxLength.DeviceID= d.DeviceID and MaxLength.ChannelNO=44108
left join t_TmpValue HitRate on HitRate.DeviceID= d.DeviceID and HitRate.ChannelNO=44109
left join t_TmpValue HWMSize on HWMSize.DeviceID= d.DeviceID and HWMSize.ChannelNO=44110
left join t_TmpValue Search on Search.DeviceID= d.DeviceID and Search.ChannelNO=44111
left join t_TmpValue Wraps on Wraps.DeviceID= d.DeviceID and Wraps.ChannelNO=44112
left join t_TmpValue Expand on Expand.DeviceID= d.DeviceID and Expand.ChannelNO=44113
where d.DeviceTypeID= 44 and ParentDevID ={0} order  by DeviceName", ParentDevID);
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


        //数据库-- 查询 --磁盘读数-前10查询
        public DataTable selectDiskReading(string ParentDevID)
        {
            string sql = string.Format(@"select top 10 d.deviceid,d.DeviceName,DiskReading.MonitorValue DiskReading,PerformSeveral.MonitorValue PerformSeveral,
EachReading.MonitorValue EachReading,DBSelect.MonitorValue DBSelect
 from t_Device d
left join t_TmpValue DiskReading on DiskReading.DeviceID= d.DeviceID and DiskReading.ChannelNO=46101
left join t_TmpValue PerformSeveral on PerformSeveral.DeviceID= d.DeviceID and PerformSeveral.ChannelNO=46102
left join t_TmpValue EachReading on EachReading.DeviceID= d.DeviceID and EachReading.ChannelNO=46103
left join t_TmpValue DBSelect on DBSelect.DeviceID= d.DeviceID and DBSelect.ChannelNO=46104
where d.DeviceTypeID= 461 and ParentDevID ={0} order by d.LastPollingTime desc", ParentDevID);
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

        //数据库-- 查询 --缓冲区读数-前10查询
        public DataTable selectBufferReading(string ParentDevID)
        {
            string sql = string.Format(@"select top 10 d.deviceid,d.DeviceName,BufferReading.MonitorValue BufferReading,PerformSeveral.MonitorValue PerformSeveral,
EachReading.MonitorValue EachReading,DBSelect.MonitorValue DBSelect
 from t_Device d
left join t_TmpValue BufferReading on BufferReading.DeviceID= d.DeviceID and BufferReading.ChannelNO=46201
left join t_TmpValue PerformSeveral on PerformSeveral.DeviceID= d.DeviceID and PerformSeveral.ChannelNO=46202
left join t_TmpValue EachReading on EachReading.DeviceID= d.DeviceID and EachReading.ChannelNO=46203
left join t_TmpValue DBSelect on DBSelect.DeviceID= d.DeviceID and DBSelect.ChannelNO=46204
where d.DeviceTypeID= 462 and ParentDevID ={0} order by d.LastPollingTime desc", ParentDevID);
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


        //数据库-- 查询 --拥有锁的会话数
        public DataTable selectLockedNO(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,ID.MonitorValue ID,Array.MonitorValue Array,Machine.MonitorValue Machine,
Program.MonitorValue Program,LockWaiting.MonitorValue LockWaiting
 from t_Device d 
left join t_TmpValue ID on ID.DeviceID= d.DeviceID and ID.ChannelNO=47101
left join t_TmpValue Array on Array.DeviceID= d.DeviceID and Array.ChannelNO=47102
left join t_TmpValue Machine on Machine.DeviceID= d.DeviceID and Machine.ChannelNO=47103
left join t_TmpValue Program on Program.DeviceID= d.DeviceID and Program.ChannelNO=47104
left join t_TmpValue LockWaiting on LockWaiting.DeviceID= d.DeviceID and LockWaiting.ChannelNO=47105
where d.DeviceTypeID= 471 and ParentDevID ={0} order  by ID", ParentDevID);
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

        //数据库-- 查询 --锁的会话等待数
        public DataTable selectLockedWaitingNO(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,WaitingID.MonitorValue WaitingID,PendingID.MonitorValue PendingID,LockType.MonitorValue LockType,
HoldMode.MonitorValue HoldMode,AskMode.MonitorValue AskMode,LockID1.MonitorValue LockID1,LockID2.MonitorValue LockID2
 from t_Device d 
left join t_TmpValue WaitingID on WaitingID.DeviceID= d.DeviceID and WaitingID.ChannelNO=47201
left join t_TmpValue PendingID on PendingID.DeviceID= d.DeviceID and PendingID.ChannelNO=47202
left join t_TmpValue LockType on LockType.DeviceID= d.DeviceID and LockType.ChannelNO=47203
left join t_TmpValue HoldMode on HoldMode.DeviceID= d.DeviceID and HoldMode.ChannelNO=47204
left join t_TmpValue AskMode on AskMode.DeviceID= d.DeviceID and AskMode.ChannelNO=47205
left join t_TmpValue LockID1 on LockID1.DeviceID= d.DeviceID and LockID1.ChannelNO=47206
left join t_TmpValue LockID2 on LockID2.DeviceID= d.DeviceID and LockID2.ChannelNO=47207
where d.DeviceTypeID= 472 and ParentDevID ={0} order  by WaitingID", ParentDevID);
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

        //数据库-- 查询 --锁明细
        public DataTable selectLockDetail(int pageCrrent, int pageSize, out int pageCount, string ParentDevID)
        {
            string sql = string.Format(@"select d.deviceid,d.DeviceName,DialogueName.MonitorValue DialogueName,ConversationID.MonitorValue ConversationID,
Program.MonitorValue Program,LockMode.MonitorValue LockMode,State.MonitorValue State,
OsProcessID.MonitorValue OsProcessID,LoginTime.MonitorValue LoginTime,LastCallTime.MonitorValue LastCallTime
 from t_Device d 
left join t_TmpValue DialogueName on DialogueName.DeviceID= d.DeviceID and DialogueName.ChannelNO=47301
left join t_TmpValue ConversationID on ConversationID.DeviceID= d.DeviceID and ConversationID.ChannelNO=47302
left join t_TmpValue Program on Program.DeviceID= d.DeviceID and Program.ChannelNO=47303
left join t_TmpValue LockMode on LockMode.DeviceID= d.DeviceID and LockMode.ChannelNO=47304
left join t_TmpValue State on State.DeviceID= d.DeviceID and State.ChannelNO=47305
left join t_TmpValue OsProcessID on OsProcessID.DeviceID= d.DeviceID and OsProcessID.ChannelNO=47306
left join t_TmpValue LoginTime on LoginTime.DeviceID= d.DeviceID and LoginTime.ChannelNO=47307
left join t_TmpValue LastCallTime on LastCallTime.DeviceID= d.DeviceID and LastCallTime.ChannelNO=47308
where d.DeviceTypeID= 473 and ParentDevID ={0} order  by DialogueName", ParentDevID);
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