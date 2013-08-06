using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Text;
using GDK.DAL.CompSearch;
using System.Data;
using System.Web.UI.DataVisualization.Charting;
using GDK.Entity.CompSearch;

namespace GDK.BCM.CompReport
{
    public class GeneratePDFBase
    {
        public const string Company = "广州吉飞科技技术有限公司";

        #region 属性
        /// <summary>
        /// 用于生成，曲线图
        /// </summary>
        public System.Web.UI.DataVisualization.Charting.Chart chLine { get; set; }

        /// <summary>
        /// 业务系统ID
        /// </summary>
        public int SystemID { get; set; }

        /// <summary>
        /// 系统名称
        /// </summary>
        public string SystemTitle { get; set; }
        /// <summary>
        /// 副标题
        /// </summary>
        public string SubTitle { get; set; }

        /// <summary>
        /// 报告描述
        /// </summary>
        public string ReportDesc { get; set; }

        /// <summary>
        /// 生成文件存储路径
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 用户部门
        /// </summary>
        public string UserPart { get; set; }

        /// <summary>
        /// 报表生成人部门
        /// </summary>
        public ReportConfigOR RepConfigOR { get; set; }
        #endregion

        #region 时间
        /// <summary>
        /// 报表统计年/月(2012年6月)
        /// </summary>
        public string ReportData { get; set; }

        /// <summary>
        /// 时间类型：M S,M选定时间,S:选定时间
        /// </summary>
        public string TimeType { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        #endregion

        
        public virtual string Generate()
        {
            return string.Empty;
        }

        public void LoadCOnfig()
        {
            RepConfigOR = new ReportConfigDA().selectARowDate(this.SystemID);
        }

        public void DeleteFile()
        {
            if (string.IsNullOrEmpty(SavePath))
                return;
            if (Directory.Exists(SavePath))
            {
               string[] strArr= Directory.GetFiles(SavePath);
               string mHour = DateTime.Now.ToString("HH");
               foreach (string str in strArr)
               {
                   try
                   {
                       string FileName = new FileInfo(str).Name;
                       if (FileName.Substring(0, 2) != mHour)
                       {
                           File.Delete(str);
                       }
                   }
                   catch
                   {
                       break;
                   }
               }
            }
        }

        #region Number Head
        public string GetDX(int mNumber)
        {
            string result = string.Empty;
            switch (mNumber)
            {
                case 1:
                    result = "一";
                    break;
                case 2:
                    result = "二";
                    break;
                case 3:
                    result = "三";
                    break;
                case 4:
                    result = "四";
                    break;
                case 5:
                    result = "五";
                    break;
            }
            return result;
        }
        #endregion

        #region 字体处理
        protected BaseFont bfSun = null;
        /// <summary>
        /// 初使化字体
        /// </summary>
        protected  void InitFont()
        {
            string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            if (!fontPath.EndsWith("\\"))
                fontPath += "\\";

            bfSun = BaseFont.CreateFont(fontPath + "SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        }


        protected  Font GetFont(FontEnum mtype)
        {
            Font mFont = null;
            switch (mtype)
            {
                case FontEnum.TitleCenter:
                    mFont = new Font(bfSun, 18);
                    mFont.SetStyle("normal");
                    break;
                case FontEnum.TitleLeft1:
                    mFont = new Font(bfSun, 16);
                    mFont.SetStyle("bold");
                    break;
                case FontEnum.TitleLeft2:
                    mFont = new Font(bfSun, 14);
                    mFont.SetStyle("normal");
                    break;
                case FontEnum.Title12Bold:
                    mFont = new Font(bfSun, 12);
                    mFont.SetStyle("bold");
                    break;
                case FontEnum.TableHeader:
                    mFont = new Font(bfSun, 12);
                    mFont.SetStyle("bold");
                    break;

                case FontEnum.TableIndex:
                    mFont = new Font(bfSun, 11);
                    mFont.SetStyle("bold");
                    break;

                case FontEnum.TableSM:
                    mFont = new Font(bfSun, 9);
                    mFont.SetStyle("normal");
                    break;
                default:
                    mFont = new Font(bfSun, 12);
                    mFont.SetStyle("normal");
                    break;

            }
            return mFont;
        }

        
        #endregion        
    }

    public enum FontEnum
    {
        TitleCenter,
        TitleLeft1,
        TitleLeft2,
        Title12Bold,
        Content,
        TableHeader,
        /// <summary>
        /// 表Index (表1,表2)
        /// </summary>
        TableIndex,
        /// <summary>
        /// 表说明
        /// </summary>
        TableSM
    }
}