﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GDK.BCM.WCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IWCFControlGetValue”。
    [ServiceContract]
    public interface IWCFControlGetValue
    {
        [OperationContract]
        void DoWork();


        [OperationContract]
        float? GetValue(string DviceID, string ChanncelNo);
    }
}
