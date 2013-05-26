using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDK.Entity.CompSearch
{
    public class ReportSeachWhereOR
    {
        /// <summary>
        /// 站点
        /// </summary>
        public int StationID { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int DeviceType { get; set; }

        /// <summary>
        /// 设备ID
        /// </summary>
        public int DeviceID { get; set; }


        public List<SearchChanncelOR> ListChanncel { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string ReportType { get; set; }
        public string ReportTypeName { get; set; }

        public string ReportName { get; set; }

    }

    public class SearchChanncelOR
    {
        public int ChanncelNo { get; set; }

        public string ChanncelName { get; set; }
    }
}
