using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class DeviceOR
    {
        /// <summary>
        /// 设备id
        /// </summary>
        private int _DeviceID;

        public int DeviceID
        {
            get { return _DeviceID; }
            set { _DeviceID = value; }
        }

        /// <summary>
        /// 设备名称
        /// </summary>
        private string _DeviceName;

        public string DeviceName
        {
            get { return _DeviceName; }
            set { _DeviceName = value; }
        }

        /// <summary>
        ///通信参数
        /// </summary>
        private int _CommunicateType;

        public int CommunicateType
        {
            get { return _CommunicateType; }
            set { _CommunicateType = value; }
        }
 
        /// <summary>
        /// 通信Id
        /// </summary>
        private int _CommunicateID;

        public int CommunicateID
        {
            get { return _CommunicateID; }
            set { _CommunicateID = value; }
        }

        ///<summary>
        ///设备地址
        ///</summary>
        private string _SubAddr;

        public string SubAddr
        {
            get { return _SubAddr; }
            set { _SubAddr = value; }
        }

        ///<summary>
        ///设备的父类型
        ///</summary>
        private int _DeviceTypeID;

        public int DeviceTypeID
        {
            get { return _DeviceTypeID; }
            set { _DeviceTypeID = value; }
        }


        ///<summary>
        ///机房ID
        ///</summary>
        private int _StationID;

        public int StationID
        {
            get { return _StationID; }
            set { _StationID = value; }
        }


        ///<summary>
        ///机房名称
        ///</summary>
        private string _StationName;

        public string  StationName
        {
            get { return _StationName; }
            set { _StationName = value; }
        }


        ///<summary>
        ///ip
        ///</summary>
        private string _IP;

        public string IP
        {
            get { return _IP; }
            set { _IP = value; }
        }



        ///<summary>
        ///子网掩码
        ///</summary>
        private string _NetMask;

        public string NetMask
        {
            get { return _NetMask; }
            set { _NetMask = value; }
        }


        ///<summary>
        ///轮询间隔秒
        ///</summary>
        private string _Interval;

        public string Interval
        {
            get { return _Interval; }
            set { _Interval = value; }
        }



        ///<summary>
        ///用户名
        ///</summary>
        private string _UserId;

        public string UserId
        {
            get { return _UserId; }
            set { _UserId = value; }
        }


        ///<summary>
        ///端口号
        ///</summary>
        private string _Port;

        public string Port
        {
            get { return _Port; }
            set { _Port = value; }
        }



        ///<summary>
        ///服务名/实例名
        ///</summary>
        private string _ServName;

        public string ServName
        {
            get { return _ServName; }
            set { _ServName = value; }
        }




        ///<summary>
        ///据库服务器时有效，为认证类型(
        ///</summary>
        private string _AuthType;

        public string AuthType
        {
            get { return _AuthType; }
            set { _AuthType = value; }
        }


        ///<summary>
        ///版本号,
        ///</summary>
        private string _Version;

        public string Version
        {
            get { return _Version; }
            set { _Version = value; }
        }



        ///<summary>
        ///默认值为0.只有Tomcat或Apache等会用到
        ///</summary>
        private string _SSL;

        public string SSL
        {
            get { return _SSL; }
            set { _SSL = value; }
        }
        
        ///<summary>
        ///默认值为0.只有Apache等会用到
        ///</summary>
        private int _NeedAuth;

        public int NeedAuth
        {
            get { return _NeedAuth; }
            set { _NeedAuth = value; }
        }
        
        ///<summary>
        ///父节点
        ///</summary>
        private int _ParentDevID;

        public int ParentDevID
        {
            get { return _ParentDevID; }
            set { _ParentDevID = value; }
        }

        ///<summary>
        ///最后轮询时间
        ///</summary>
        private DateTime _LastPollingTime;

        public DateTime LastPollingTime
        {
            get { return _LastPollingTime; }
            set { _LastPollingTime = value; }
        }

        ///<summary>
        ///下次轮询时间
        ///</summary>
        private DateTime _NextPollingTime;

        public DateTime NextPollingTime
        {
            get { return _NextPollingTime; }
            set { _NextPollingTime = value; }
        }

        ///<summary>
        ///性能
        ///</summary>
        private string _Performance;

        public string Performance
        {
            get { return _Performance; }
            set { _Performance = value; }
        }

        ///<summary>
        ///描述
        ///</summary>
        private string _Describe;

        public string Describe
        {
            get { return _Describe; }
            set { _Describe = value; }
        }

        ///<summary>
        ///是否启用设备
        ///</summary>
        private int _Enable;

        public int Enable
        {
            get { return _Enable; }
            set { _Enable = value; }
        }



        ///<summary>
        ///是否启用采集校验
        ///</summary>
        private int _EnableCheck;

        public int EnableCheck
        {
            get { return _EnableCheck; }
            set { _EnableCheck = value; }
        }


        ///<summary>
        ///是否启用采集校验
        ///</summary>
        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        /// <summary>
        /// 可用性
        /// </summary>
        public Double AvailableRate { get; set; }

        /// <summary>
		/// Roles构造函数
		/// </summary>
		public DeviceOR()
		{

		}

		/// <summary>
		/// Roles构造函数
		/// </summary>
        public DeviceOR(DataRow row)
        {
            // 设备id
            _DeviceID = Convert.ToInt32(row["DeviceID"]);
            // 设备名称
            _DeviceName = row["DeviceName"].ToString().Trim();
            // 通信参数

            if (row["CommunicateType"] != DBNull.Value)
                _CommunicateType = Convert.ToInt32(row["CommunicateType"]);

            if (row["CommunicateID"] != DBNull.Value)
                _CommunicateID = Convert.ToInt32(row["CommunicateID"]);

            _SubAddr = row["SubAddr"].ToString().Trim();

            if (row["DeviceTypeID"] != DBNull.Value)
                _DeviceTypeID = Convert.ToInt32(row["DeviceTypeID"]);

            if (row["StationID"] != DBNull.Value)
                _StationID = Convert.ToInt32(row["StationID"]);
            _StationName = row["StationName"].ToString().Trim();
            _IP = row["IP"].ToString().Trim();
            _UserId = row["UserId"].ToString().Trim();
            _Password = row["Password"].ToString().Trim();
            if (row["Enable"] != DBNull.Value)
                _Enable = Convert.ToInt32(row["Enable"]);

            if (row["EnableCheck"] != DBNull.Value)
                _EnableCheck = Convert.ToInt32(row["EnableCheck"]);

            _NetMask = row["NetMask"].ToString().Trim();
            _Interval = row["Interval"].ToString().Trim();
            _Port = row["Port"].ToString().Trim();
            _ServName = row["ServName"].ToString().Trim();
            _AuthType = row["AuthType"].ToString().Trim();
            _Version = row["Version"].ToString().Trim();
            _SSL = row["SSL"].ToString().Trim();

            if (row["NeedAuth"] != DBNull.Value)
                _NeedAuth = Convert.ToInt32(row["NeedAuth"]);

            //可用性
            if (row["AvailableRate"].ToString() != "")
            {
                AvailableRate = Convert.ToDouble(row["AvailableRate"].ToString());
            }
            else
            {
                AvailableRate = 0f;
            }
            if (row["ParentDevID"] != DBNull.Value)
                _ParentDevID = Convert.ToInt32(row["ParentDevID"]);
            if (row["LastPollingTime"] != DBNull.Value)
                _LastPollingTime = Convert.ToDateTime(row["LastPollingTime"]);
            if (row["NextPollingTime"] != DBNull.Value)
                _NextPollingTime = Convert.ToDateTime(row["NextPollingTime"]);
            if (row["Performance"] != DBNull.Value)
                _Performance = row["Performance"].ToString().Trim();
            if (row["Describe"] != DBNull.Value)
                _Describe = row["Describe"].ToString().Trim();
        }
    }


}
