using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GDK.BCM.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“WCFControlGetValue”。
    public class WCFControlGetValue : IWCFControlGetValue
    {
        public void DoWork()
        {
        }

        public float? GetValue(string DviceID, string ChanncelNo)
        {
            int deviceid = Convert.ToInt32(DviceID);
            if (deviceid > 1000)
                return deviceid / 100;
            if (deviceid > 100)
                return deviceid / 100;
            return deviceid;
            //return new Random().Next(0, 100);
        }

    }
}
