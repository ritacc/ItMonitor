using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.PerfMonitor
{
    public class ServersTypeOR
    {
        #region 字段定义

        #region 字段 ID
        private int? _ID = null;
        /// <summary>
        /// （不能为空）   大小：10
        /// </summary>
        public int? ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        #endregion

        #region 字段 TypeID
        private int? _TypeID = null;
        /// <summary>
        /// （不能为空）   大小：10
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
        /// （不能为空）   大小：10
        /// </summary>
        public int? ServerID
        {
            set { _ServerID = value; }
            get { return _ServerID; }
        }
        #endregion

        #region 字段 Name
        private string _Name = null;
        /// <summary>
        ///    大小：200
        /// </summary>
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        #endregion

        #region 字段 Description
        private string _Description = null;
        /// <summary>
        ///    大小：200
        /// </summary>
        public string Description
        {
            set { _Description = value; }
            get { return _Description; }
        }
        #endregion

        #region 字段 Enabled
        private int? _Enabled = null;
        /// <summary>
        ///    大小：10
        /// </summary>
        public int? Enabled
        {
            set { _Enabled = value; }
            get { return _Enabled; }
        }
        #endregion

        #endregion
        public ServersTypeOR() { }
        public ServersTypeOR(DataRow row) {
            _ID = Convert.ToInt32(row["ID"]);
            _TypeID = Convert.ToInt32(row["TypeID"]);
            _ServerID = Convert.ToInt32(row["ServerID"]);
            _Name = row["Name"].ToString().Trim();
            _Description = row["Description"].ToString().Trim();
            _Enabled = Convert.ToInt32(row["Enabled"]);
        }
    }
}
