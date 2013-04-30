using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace GDK.BCM
{
    public class Logger
    {

        private static Logger logger = null;
        private string filePath = ""; //用来记录当前日志文件
        private StreamWriter sw = null;
        private bool recordLog = false;
        private string datetime = null;

        private Logger() //禁止直接创建实例
        {
        }

        public void close() //关闭日志，释放资源
        {
            try
            {//如果前面的日志还没关闭，则关闭
                this.sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        private const int DEBUG = 0;
        private const int WARNING = 1;
        private const int ERROR = 2;
        private const int INFO = 3;
        /**
         * 记录日志级别
         * 0　DEBUG
         * 1　WARNING
         * 2　ERROR
         * 3　INFO
         * 如果需要更改记录日志的级别，只需要修改本字段的取值即可
         **/
        private int level = 0;
        /**
         * 获取日志类实例
         **/
        public static Logger getLogger()
        {
            if (logger == null)
            {
                logger = new Logger();
                //				string recordlogvalue =ConfigurationSettings.AppSettings["RecordLog"];
                //				if (recordlogvalue.ToUpper().Equals("YES")) 
                //				{
                //					logger.recordLog = true;
                //				}
                //				else 
                //				{
                //					logger.recordLog = false;
                //				}

                logger.recordLog = true;
                logger.datetime = DateTime.Now.ToString("u").Substring(0, 10);
                //string sDir = 
                logger.config("..\\LOG\\" + logger.datetime + ".log");
            }
            return logger;
        }

        /**
         * 配置日志路径及级别
         * 由本方法关闭前面的日志并打开新日志
         **/
        public void config(string filePath)
        {
            try
            {//如果前面的日志还没关闭，则关闭
                this.sw.Close();
            }
            catch (Exception e)
            {
            }

            this.level = level;
            this.filePath = filePath;

            try
            {
                this.sw = new StreamWriter(this.filePath, true, System.Text.Encoding.Default);
                this.sw.WriteLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                //日志文件打开失败，放弃日志
            }
        }

        /**
         * 写日志的基础方法
         * 如果要改为写数据库或者其它流，只需更改本方法
         **/
        private void log(string strLog)
        {
           

            if (this.sw != null)
            {
                string now = DateTime.Now.ToString("u").Substring(0, 10);
                if (!now.Equals(datetime))
                {
                    ///日期发生变化，重新打开新文件，记录日志
                    ///
                    datetime = now;                    
                    logger.config("LOG\\" + datetime + ".log");
                }
                this.sw.WriteLine(DateTime.Now.ToString() + " - " + strLog);
                this.sw.Flush();
            }
        }

        /**
         * 写日志
         **/
        public void debug(string strLog)
        {

            if (this.level <= Logger.DEBUG && this.recordLog)
            {
                this.log("debug: " + strLog);
            }
        }
        public void error(string strLog)
        {
            if (this.level <= Logger.ERROR && this.recordLog)
            {
                this.log("error: " + strLog);
            }
        }
        public void info(string strLog)
        {
            if (this.level <= Logger.INFO && this.recordLog)
            {
                this.log("infor: " + strLog);
            }
        }
        public void warning(string strLog)
        {
            if (this.level <= Logger.WARNING && this.recordLog)
            {
                this.log("warning: " + strLog);
            }
        }

        public void debugUploadError(string strLog)
        {
            // System.Windows.Forms.MessageBox.Show(strLog);
            if (this.level <= Logger.DEBUG && this.recordLog)
            {
                this.log("debug: " + strLog);
            }
        }
    }
}