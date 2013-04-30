using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GDK.DAL.common
{
    public class Utils
    {

        /// <summary>
        /// 产生新的编号
        /// </summary>
        /// <param name="code">得到的最大的字符串</param>
        /// <returns>返回构造之后最大的编号</returns>
        public static string retCodeToStringFormat(string code)
        {
            string str = string.Empty;
            string strNum = string.Empty;
            /*str.Substring(0, 2)获取前两个字母比如KC20100001中的BX*/
            /*str.Substring(2, str.Length - 2)获取除BX以外的其余字母*/
            //string s1 = code.Substring(DateTime.Now.Year.ToString().Length + 1, code.Length - 5);
            //string result = (Convert.ToInt32(code.Substring(DateTime.Now.Year.ToString().Length + 2, 4)) + 1).ToString();
            string ss = code.Substring(DateTime.Now.ToString("yyyyMMdd").Length, 5);
            string result = (Convert.ToInt32(ss) + 1).ToString();
            if (result.Length == 1)
            {
                strNum = string.Format("0000{0}", result);
            }
            else if (result.Length == 2)
            {
                strNum = string.Format("000{0}", result);
            }
            else if (result.Length == 3)
            {
                strNum = string.Format("00{0}", result);
            }
            else if (result.Length == 4)
            {
                strNum = string.Format("0{0}", result);
            }
            else
            {
                strNum = result;
            }
            str = string.Format("{0}{1}", System.DateTime.Now.ToString("yyyyMMdd"), strNum);
            return str;
        }
    }
}
