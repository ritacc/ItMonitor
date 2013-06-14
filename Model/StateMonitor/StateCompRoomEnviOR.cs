using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.StateMonitor
{
    public class StateCompRoomEnviOR
    {
        public StateCompRoomEnviOR()
        {

        }

        /// <summary>
        /// 泄漏
        /// </summary>
        public string Leak { get; set; }

        /// <summary>
        /// DUANXIAN
        /// </summary>
        public string DUANXIAN { get; set; }

        /// <summary>
        /// WEIZHI
        /// </summary>
        public string WEIZHI { get; set; }
        
        /// <summary>
        /// 接口列表     3#^#1705#^#1706#^#1707
        /// </summary>
        public string Ports { get; set; }
                
        /// <summary>
        /// 网各设备的，接口列表
        /// </summary>
        public DataTable SubProts { get; set; }

        public StateCompRoomEnviOR(DataTable dt)
        {
            if (dt == null)
                return;
            foreach (DataRow dr in dt.Rows)
            {
                switch (dr["ChannelNO"].ToString())
                {
                    case "52001":
                        Leak = dr["MonitorValue"].ToString();
                        break;
                    case "52002":
                        DUANXIAN = dr["MonitorValue"].ToString();
                        break;
                    case "52003":
                        WEIZHI = dr["MonitorValue"].ToString();
                        break;
                }
            }
        }

    }
}
