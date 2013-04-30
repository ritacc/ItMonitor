using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace GDK.DAL
{
    public class ModelConvertHelper<T> where T : new()
    {

        public static List<T> ConvertToModel(DataTable dt)
        {
            // 定义集合
            List<T> l = new List<T>();
            // 获得此模型的类型
            Type type = typeof(T);
            string tempNmae = "";
            foreach (DataRow dr in dt.Rows)
            {
                T t = new T();
                // 获得此模型的公共属性
                PropertyInfo[] propertys = t.GetType().GetProperties();
                foreach (PropertyInfo pi in propertys)
                {
                    tempNmae = pi.Name;
                    // 检查DataTable是否包含此列
                    if (dt.Columns.Contains(tempNmae))
                    {
                        // 判断此属性是否有Setter

                        if (!pi.CanWrite) continue;
                        object value = dr[tempNmae];
                        if (value != DBNull.Value)
                        {
                            pi.SetValue(t, value, null);
                        }
                    }

                }
                l.Add(t);
            }
            return l;
        }
    }
}
