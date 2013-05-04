using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class DeviceTypeOR
    {
        #region 字段定义

        #region 字段 DeviceTypeID
        private int? _DeviceTypeID = null;
        /// <summary>
        /// （不能为空）   大小：10
        /// </summary>
        public int? DeviceTypeID
        {
            set { _DeviceTypeID = value; }
            get { return _DeviceTypeID; }
        }
        #endregion

        #region 字段 TypeName
        private string _TypeName = null;
        /// <summary>
        ///    大小：64
        /// </summary>
        public string TypeName
        {
            set { _TypeName = value; }
            get { return _TypeName; }
        }
        #endregion

        #region 字段 ParseDll
        private string _ParseDll = null;
        /// <summary>
        ///    大小：200
        /// </summary>
        public string ParseDll
        {
            set { _ParseDll = value; }
            get { return _ParseDll; }
        }
        #endregion

        #region 字段 SaveTimeInteval
        private int? _SaveTimeInteval = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? SaveTimeInteval
        {
            set { _SaveTimeInteval = value; }
            get { return _SaveTimeInteval; }
        }
        #endregion

        #region 字段 Param
        private string _Param = null;
        /// <summary>
        ///    大小：50
        /// </summary>
        public string Param
        {
            set { _Param = value; }
            get { return _Param; }
        }
        #endregion

        #region 字段 IP
        private string _IP = null;
        /// <summary>
        ///    大小：200
        /// </summary>
        public string IP
        {
            set { _IP = value; }
            get { return _IP; }
        }
        #endregion

        #region 字段 StationID
        private int? _StationID = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? StationID
        {
            set { _StationID = value; }
            get { return _StationID; }
        }
        #endregion

        #region 字段 VDeviceTypeID
        private int? _VDeviceTypeID = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? VDeviceTypeID
        {
            set { _VDeviceTypeID = value; }
            get { return _VDeviceTypeID; }
        }
        #endregion

        #region 字段 ObjectExId
        private int? _ObjectExId = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? ObjectExId
        {
            set { _ObjectExId = value; }
            get { return _ObjectExId; }
        }
        #endregion

        #region 字段 NameSpace
        private string _NameSpace = null;
        /// <summary>
        ///    大小：200
        /// </summary>
        public string NameSpace
        {
            set { _NameSpace = value; }
            get { return _NameSpace; }
        }
        #endregion

        #region 字段 TypeID
        private int? _TypeID = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? TypeID
        {
            set { _TypeID = value; }
            get { return _TypeID; }
        }
        #endregion

        #region 字段 ServerID
        private int? _ServerID = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? ServerID
        {
            set { _ServerID = value; }
            get { return _ServerID; }
        }
        #endregion

        #endregion

        public DeviceTypeOR() { }
        public DeviceTypeOR(DataRow row) {
            _DeviceTypeID = Convert.ToInt32(row["DeviceTypeID"]);
            _TypeName = row["TypeName"].ToString().Trim();
            _ParseDll = row["ParseDll"].ToString().Trim();
            _SaveTimeInteval = Convert.ToInt32(row["SaveTimeInteval"]);
            _Param = row["Param"].ToString().Trim();
            _IP = row["IP"].ToString().Trim();
            _StationID = Convert.ToInt32(row["StationID"]);
            _VDeviceTypeID = Convert.ToInt32(row["VDeviceTypeID"]);
            _ObjectExId = Convert.ToInt32(row["ObjectExId"]);
            _NameSpace = row["NameSpace"].ToString().Trim();
            _TypeID = Convert.ToInt32(row["TypeID"]);
            _ServerID = Convert.ToInt32(row["ServerID"]);
        }
    }
}
