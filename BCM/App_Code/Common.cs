using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GDK.BCM
{
    public class CommonHead
    {
        public static bool HeadString()
        {
            return false; 
        }

        public static string GetStr(string sObj, int intLen)
        {
            if (sObj.Length > intLen)
            {
                return sObj.Substring(0, intLen) + "…";
            }
            return sObj; 
        }

        public static bool isImg(string FileName)
        {
            string[] extendFileName = { ".psd", ".jpg", ".gif", ".bmp", ".BMP", ".PSD", ".JPG", ".GIF" };

            string[] arr = FileName.Split('.');
            if (arr.Length == 0)
                return false;
            string cjm = "." + arr[arr.Length - 1];
            bool isimg = false;
            if (arr.Length == 2)
                for (int j = 0; j < extendFileName.Length && !isimg; j++)
                {
                    if (cjm == extendFileName[j])
                        isimg = true;
                }
            return isimg;
        }

        /// <summary>
        /// 获取文件长，最大单位MB
        /// </summary>
        /// <param name="fileSize"></param>
        /// <returns></returns>
        public static string GetFileLengStr(int f_size)
        {
            if (f_size == 0)
            {
                return "0KB";
            }
            float fileSize = float.Parse(f_size.ToString());
            if (fileSize <= 1024)
                return "1KB";
            float f = fileSize / 1024;
            if (f <= 1)
                return "1KB";

            if (f <= 100)
            {
                int f_len = 4;
                if (f.ToString().Length < 4)
                {
                    f_len = f.ToString().Length;
                }
                return f.ToString().Substring(0, f_len) + "KB";
            }
            f = f / 1024;
            string temp = f.ToString();
            int dindex = temp.IndexOf('.');
            if (dindex != -1)
            {
                int dAfertLeng = temp.Substring(0, dindex).Length;
                int i_xiaosLeng = temp.Length - dindex;
                if (i_xiaosLeng < 2)
                {
                    i_xiaosLeng = 1;
                }
                else
                {
                    i_xiaosLeng = 2;
                }
                string xiaosStr = temp.Substring(dindex + 1, i_xiaosLeng);
                return temp.Substring(0, dAfertLeng) + "." + xiaosStr + "MB";
            }
            return temp + "MB";
        }
    }
}