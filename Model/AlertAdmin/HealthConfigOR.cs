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

		private int _Channelno;
		/// <summary>
		/// 
		/// </summary>
		public int Channelno
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

		}

		/// <summary>
		/// HealthConfig构造函数
		/// </summary>
		public HealthConfigOR(DataRow row)
		{
			// 
			_Deviceid = Convert.ToInt32(row["DeviceID"]);
			// 
			_Sdid = Convert.ToInt32(row["SDID"]);
			// 
			_Pdid = Convert.ToInt32(row["PDID"]);
			// 
			_Channelno = Convert.ToInt32(row["ChannelNO"]);
			// 
			_Effectlevel = Convert.ToInt32(row["EffectLevel"]);
		}
    }
}

