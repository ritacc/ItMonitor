using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.DAL.Sys
{
    public class BussinessDA : DALBase
    {
        public DataTable GetTopBuss()
        {
            string sql = @"select d.Describe descInfo,dt.typeid, dt.TypeName,d.*
from t_Bussiness bus
inner join t_Device d  on bus.id= d.DeviceID
inner join t_DeviceType dt on d.DeviceTypeID= dt.DeviceTypeID
where bus.ParentId= -1 ";
            DataTable dt = db.ExecuteQuery(sql);
            return dt;
        }

    }
}
