using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Text;

namespace GDK.BCM
{
    public class Global : System.Web.HttpApplication
    {

        //string s = @"../Problem/count.txt";
        void Application_Start(object sender, EventArgs e)
        {
            // 在应用程序启动时运行的代码

            //int count = 0;
            //using (FileStream fs = new FileStream(Server.MapPath(s) , FileMode.Open, FileAccess.Read))
            //{
            //    using (StreamReader reader = new StreamReader(fs, Encoding.Default))
            //    {
            //        string result = reader.ReadToEnd().Replace("\r", "").Replace("\n", "").Trim();
            //        count = Convert.ToInt32(result);
            //    }
            //}
            //Application["count_web"] = count;
            //Application["num"] = 1;
        }

        void Application_End(object sender, EventArgs e)
        {
            // 在应用程序关闭时运行的代码
            //using (StreamWriter writer = new StreamWriter(Server.MapPath(s) , false))
            //{
            //    writer.Write(Application["count_web"].ToString());
            //    writer.Flush();
            //    writer.Close();
            //}
        }

        void Application_Error(object sender, EventArgs e)
        {
            // 在出现未处理的错误时运行的代码
        }

        void Session_Start(object sender, EventArgs e)
        {
            // 在新会话启动时运行的代码
            //Application.Lock();
            //Application["count_web"] = Convert.ToInt32(Application["count_web"]) + 1;
            //Application["num"] = Convert.ToInt32(Application["num"]) + 1;
            //Application.UnLock();
        }

        void Session_End(object sender, EventArgs e)
        {
            // 在会话结束时运行的代码。
            // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为
            // InProc 时，才会引发 Session_End 事件。如果会话模式设置为 StateServer
            // 或 SQLServer，则不会引发该事件。
            //Application.Lock();
            //Application["num"] = Convert.ToInt32(Application["num"]) - 1;
            //Application.UnLock();
        }

        

        

    }
}
