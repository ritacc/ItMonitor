using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.AlertAdmin
{
    /// <summary>
    /// 
    /// </summary>
    public class HealthConfigOR
    {
        string _ID;
        /// <summary>
        /// ID
        /// </summary>
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

		private int _Deviceid;
		/// <summary>
		/// 
		/// </summary>
		public int Deviceid
		{
			get { return _Deviceid; }
			set { _Deviceid = value; }
		}

		private int _Sdid;
		/// <summary>
		/// 
		/// </summary>
		public int Sdid
		{
			get { return _Sdid; }
			set { _Sdid = value; }
		}

		private int _Pdid;
		/// <summary>
		/// 
		/// </summary>
		public int Pdid
		{
			get { return _Pdid; }
			set { _Pdid = value; }
		}

		private int? _Channelno;
		/// <summary>
		/// 
		/// </summary>
		public int? Channelno
		{
			get { return _Channelno; }
			set { _Channelno = value; }
		}

		private int _Effectlevel;
		/// <summary>
		/// 
		/// </summary>
		public int Effectlevel
		{
			get { return _Effectlevel; }
			set { _Effectlevel = value; }
		}

		/// <summary>
		/// HealthConfig构造函数
		/// </summary>
		public HealthConfigOR()
		{
            _ID = Guid.NewGuid().ToString();
		}

		/// <summary>
		/// HealthConfig构造函数
		/// </summary>
		public HealthConfigOR(DataRow row)
		{
            _ID = row["id"].ToString();
			// 
			_Deviceid = Convert.ToInt32(row["DeviceID"]);
			//
            if (row["SDID"] != DBNull.Value)
                _Sdid = Convert.ToInt32(row["SDID"]);
			// 
            if (row["PDID"] != DBNull.Value)
			_Pdid = Convert.ToInt32(row["PDID"]);
			// 
            if (row["ChannelNO"] != DBNull.Value)
                _Channelno = Convert.ToInt32(row["ChannelNO"]);
			// 
			_Effectlevel = Convert.ToInt32(row["EffectLevel"]);
		}
    }
}

