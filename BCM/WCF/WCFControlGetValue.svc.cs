using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GDK.DAL.PerfMonitor;

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
            float f = 0f;
            object val = new TmpValueDA().SelectValue(DviceID, ChanncelNo);
            if (val != null)
            {
                float.TryParse(val.ToString(), out f);
            }
            return f; 
        }

    }
}
