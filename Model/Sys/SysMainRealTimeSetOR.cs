using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    /// <summary>
    /// 
    /// </summary>
    public class SysMainRealTimeSetOR
    {
       
		private int _Id;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}

		private int _Stationid;
		/// <summary>
		/// 站点名称
		/// </summary>
		public int Stationid
		{
			get { return _Stationid; }
			set { _Stationid = value; }
		}

		private int _Deviceid;
		/// <summary>
		/// 设备名称
		/// </summary>
		public int Deviceid
		{
			get { return _Deviceid; }
			set { _Deviceid = value; }
		}

		private int _Channelno;
		/// <summary>
		/// 测点
		/// </summary>
		public int Channelno
		{
			get { return _Channelno; }
			set { _Channelno = value; }
		}

		private float _Chanenlsubno;
		/// <summary>
		/// 
		/// </summary>
		public float Chanenlsubno
		{
			get { return _Chanenlsubno; }
			set { _Chanenlsubno = value; }
		}

		private float _Ymaxvalue;
		/// <summary>
		/// 最大值
		/// </summary>
		public float Ymaxvalue
		{
			get { return _Ymaxvalue; }
			set { _Ymaxvalue = value; }
		}

		private float _Yminvalue;
		/// <summary>
		/// 最小值
		/// </summary>
		public float Yminvalue
		{
			get { return _Yminvalue; }
			set { _Yminvalue = value; }
		}

		private float _Yupper;
		/// <summary>
		/// 上限
		/// </summary>
		public float Yupper
		{
			get { return _Yupper; }
			set { _Yupper = value; }
		}

		private float _Ylower;
		/// <summary>
		/// 下限
		/// </summary>
		public float Ylower
		{
			get { return _Ylower; }
			set { _Ylower = value; }
		}

		private float _Gridheight;
		/// <summary>
		/// 网格高度
		/// </summary>
		public float Gridheight
		{
			get { return _Gridheight; }
			set { _Gridheight = value; }
		}

		/// <summary>
		/// SysMainRealTimeSet构造函数
		/// </summary>
		public SysMainRealTimeSetOR()
		{


		}

		/// <summary>
		/// SysMainRealTimeSet构造函数
		/// </summary>
		public SysMainRealTimeSetOR(DataRow row)
		{
			// 
			_Id = Convert.ToInt32(row["ID"]);
			// 站点名称
			_Stationid = Convert.ToInt32(row["StationID"]);
			// 设备名称
			_Deviceid = Convert.ToInt32(row["DeviceID"]);
			// 测点
			_Channelno = Convert.ToInt32(row["ChannelNO"]);
			// 
			_Chanenlsubno = float.Parse(row["ChanenlSubNo"].ToString());
			// 最大值
			_Ymaxvalue = float.Parse(row["YmaxValue"].ToString());
			// 最小值
			_Yminvalue = float.Parse(row["YminValue"].ToString());
			// 上限
			_Yupper = float.Parse(row["Yupper"].ToString());
			// 下限
			_Ylower = float.Parse(row["Ylower"].ToString());
			// 网格高度
			_Gridheight = float.Parse(row["GridHeight"].ToString());
		}
    }
}

