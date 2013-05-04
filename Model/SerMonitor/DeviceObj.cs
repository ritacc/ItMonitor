using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDK.Entity.SerMonitor
{
    public class DeviceObj
    {
        public int nDeviceID;

        public int DeviceID
        {
            get { return nDeviceID; }
            set { nDeviceID = value; }
        }
        public string strDeviceName;

        public string DeviceName
        {
            get { return strDeviceName; }
            set { strDeviceName = value; }
        }
        public int nStationID;
        public int nCommunicateType;
        public int nCommunicateID;
        public string strSubAddr;
        public int nDeviceTypeID;
        public string strParseDLL;
        public string strTypeName;

        public string UserId;
    }


    public class AlarmLogObj
    {
        public int StationID;
        public string EventsName;
        public int AlarmLogID;
        public string DeviceName;
        public string Content;
        public DateTime HappenTime;
        public string RelieveTime;
        public string UserName;
        public int AlarmLevel;
        public int DeviceID;
        public float MonitorValue;
        public int OperateUserID;
        public string LastTime;
        // 2011-10-11
        public string AlarmType;
    }

    public class DeviceTypeObj
    {

        public int nDeviceTypeID;
        public int SaveTimeInteval;//设备采集的时间间隔  
        public int DeviceTypeID
        {
            get { return nDeviceTypeID; }
            set { nDeviceTypeID = value; }
        }
        public string strTypeName;

        public string TypeName
        {
            get { return strTypeName; }
            set { strTypeName = value; }
        }
        //2011-1-4曾巍  添加ip,param
        public string ip;

        public string IP
        {
            get { return ip; }
            set { ip = value; }
        }
        public string param;

        public string Param
        {
            get { return param; }
            set { param = value; }
        }
        //2011-2-21曾巍  添加stationid
        public int stationid;

        public int StationID
        {
            get { return stationid; }
            set { stationid = value; }
        }

        public string strParseDLL;
        public IList<int> PolicyDevicTypeeMap = new List<int>();
        //public IList<PolicyAction> PolicyActionMap = new List<PolicyAction>();
    }
}
