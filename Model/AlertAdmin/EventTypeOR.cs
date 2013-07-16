using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.AlertAdmin
{
    public class EventTypeOR
    {

        private int _Eventid;
        /// <summary>
        /// 事件编号
        /// </summary>
        public int Eventid
        {
            get { return _Eventid; }
            set { _Eventid = value; }
        }

        private string _Eventname;
        /// <summary>
        /// 事件名称
        /// </summary>
        public string Eventname
        {
            get { return _Eventname; }
            set { _Eventname = value; }
        }

        private int _Alarmlevel;
        /// <summary>
        /// 事件级别
        /// </summary>
        public int Alarmlevel
        {
            get { return _Alarmlevel; }
            set { _Alarmlevel = value; }
        }

        private string _Alarmtarget;
        /// <summary>
        /// 报警组
        /// </summary>
        public string Alarmtarget
        {
            get { return _Alarmtarget; }
            set { _Alarmtarget = value; }
        }

        private string _Alarmway;
        /// <summary>
        /// 报警方式
        /// </summary>
        public string Alarmway
        {
            get { return _Alarmway; }
            set { _Alarmway = value; }
        }

        private int _Isenablefrequency;
        /// <summary>
        /// 是否班次报警
        /// </summary>
        public int Isenablefrequency
        {
            get { return _Isenablefrequency; }
            set { _Isenablefrequency = value; }
        }

        private string _Alarmaudiofile;
        /// <summary>
        /// 电话语音文件
        /// </summary>
        public string Alarmaudiofile
        {
            get { return _Alarmaudiofile; }
            set { _Alarmaudiofile = value; }
        }

        private string _Disalarmaudiofile;
        /// <summary>
        /// 电话语音文件
        /// </summary>
        public string Disalarmaudiofile
        {
            get { return _Disalarmaudiofile; }
            set { _Disalarmaudiofile = value; }
        }

        private string _Smsmsg;
        /// <summary>
        /// 短信、Email、语音报警内容格式
        /// </summary>
        public string Smsmsg
        {
            get { return _Smsmsg; }
            set { _Smsmsg = value; }
        }

        private string _Disarmid;
        /// <summary>
        /// 撤防时间
        /// </summary>
        public string Disarmid
        {
            get { return _Disarmid; }
            set { _Disarmid = value; }
        }

        /// <summary>
        /// EventType构造函数
        /// </summary>
        public EventTypeOR()
        {

        }

        /// <summary>
        /// EventType构造函数
        /// </summary>
        public EventTypeOR(DataRow row)
        {
            // 事件编号
            _Eventid = Convert.ToInt32(row["EventID"]);
            // 事件名称
            _Eventname = row["EventName"].ToString().Trim();
            // 事件级别
            _Alarmlevel = Convert.ToInt32(row["AlarmLevel"]);
            // 报警组
            _Alarmtarget = row["AlarmTarget"].ToString().Trim();
            // 报警方式
            _Alarmway = row["AlarmWay"].ToString().Trim();
            // 是否班次报警
            _Isenablefrequency = Convert.ToInt32(row["IsEnableFrequency"]);
            // 电话语音文件
            _Alarmaudiofile = row["AlarmAudioFile"].ToString().Trim();
            // 电话语音文件
            _Disalarmaudiofile = row["DisAlarmAudioFile"].ToString().Trim();
            // 短信、Email、语音报警内容格式
            _Smsmsg = row["SmsMsg"].ToString().Trim();
            // 撤防时间
            _Disarmid = row["DisarmID"].ToString().Trim();
        }
    }
}
