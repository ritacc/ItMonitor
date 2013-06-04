using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Text;

namespace GDK.BCM.CompReport
{
    public class GeneratePDF
    {
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

        public const string Company = "广东省国家税务局信息中心";

        /// <summary>
        /// 报表统计年/月(2012年6月)
        /// </summary>
        public string ReportData { get; set; }
        public string UserPart { get; set; }
        BaseFont bfSun = null;
        /// <summary>
        /// 初使化字体
        /// </summary>
        private void InitFont()
        {
            string fontPath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts);
            if (!fontPath.EndsWith("\\"))
                fontPath += "\\";

            bfSun = BaseFont.createFont(fontPath + "SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        }

        public string Generate()
        {
            InitFont();

            string currentPath = SavePath;
            if (!currentPath.EndsWith("\\"))
                currentPath += "\\";


            string FilePath = currentPath + Guid.NewGuid().ToString() + ".pdf";

            iTextSharp.text.Document document = new iTextSharp.text.Document();
            PdfWriter.getInstance(document, new FileStream(FilePath, FileMode.Create));

            document.Open();
            InitFirstPage(document);
            ContentFirstpart(document);//第一部分
            ContentSecondPart(document);//第二部分
            ContentThreed(document);//第三部分
            document.Close();

            return FilePath;
        }



        /// <summary>
        /// 内容第一部分
        /// </summary>
        /// <param name="document"></param>
        public void ContentFirstpart(iTextSharp.text.Document document)
        {
            string strContent = "第一部分、本月检查概述";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.setAlignment("Center");
            document.Add(pg);


            strContent = "\n\n一、概述";
            pg = new Paragraph(strContent, GetFont(FontEnum.TitleLeft1));
            document.Add(pg);

            StringBuilder sb = new StringBuilder();
            sb.Append("    ").Append(ReportData);
            sb.Append("健康检查结果数据是来自广东国税IT集中监控系统的监控数据，");
            sb.Append("本报告是由系统自动和人工编辑组合而成，");
            sb.Append("由系统自动生成的数据为").Append(ReportData).Append("1日，");
            sb.Append("基于系统生成的数据，");
            sb.Append(UserPart).Append(DateTime.Now.ToString("yyyy年MM月dd日")).Append("完成了数据的统计分析工作。");
            sb.Append("现将本次检查结果进行通报。\n");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);



            pg = new Paragraph("\n\n二、检查内容说明\n", GetFont(FontEnum.TitleLeft1));
            document.Add(pg);
            pg = new Paragraph("本月健康检查内容包括如下几个方面：", GetFont(FontEnum.Content));
            document.Add(pg);


            pg = new Paragraph("1. 主机系统检查", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    用于业务系统的主机压力情况，主要包括HP-UX、AIX、Windows、Linux主机运行状态检查，包括主机状态、CPU利用率、内存利用率、磁盘空间大小及利用率等信息。\n");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);


            pg = new Paragraph("\n2. 数据库系统检查", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    主要用于检查Oracle数据库的性能。检查数据库运行状态，包括数据库进程、数据库锁、数据库日志等信息：对数据库资源监视，包括数据");
            sb.Append("库CPU、数据库Cathe等信息：对数据库存储资源监视，包括数据库文件系统、数据库表空间、数据库表、数据库空间、文件空间等；对数据");
            sb.Append("库Session监控，包括运行的SQL语句、Buffer Cache命中率等信息。\n");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);


            pg = new Paragraph("\n3. 中间件检查", GetFont(FontEnum.Content));
            document.Add(pg);
            pg = new Paragraph("    实现对Weblogic应用服务器的运行状态监控，根据不同的中间件提供不同的监控指标。\n", GetFont(FontEnum.Content));
            document.Add(pg);


            pg = new Paragraph("\n4. 业务/应用系统检查", GetFont(FontEnum.Content));
            document.Add(pg);
            pg = new Paragraph("    实现对关键业务/应用系统的运行状态的监控，通过业务视图方式直观监视业务可用性、端到端响应时间、业务/应用所关联的资源对象的性能和故障等信息。\n"
                , GetFont(FontEnum.Content));
            document.Add(pg);

            pg = new Paragraph("\n5. 网络系统检查", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("实现网络设备、网络安全设备的在线状态的检查。");
            sb.Append("对网络线路运行状态监控，包括线路流量、线路带宽利用率、线路错包率、线路丢包率等信息。");
            sb.Append("对网络设备接口状态进行监管，包括接口面板、接口状态、接口流量性能等信息。\n");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);

            pg = new Paragraph("\n6. 健康检查报告", GetFont(FontEnum.Content));
            document.Add(pg);
            pg = new Paragraph("    由各科室进行编写，主要包括需上报的问题以及对前期发现问题的处理情况反馈等等。\n", GetFont(FontEnum.Content));
            document.Add(pg);

        }

        public void ContentSecondPart(iTextSharp.text.Document document)
        {
            string strContent = "\n\n\n\n第二部分、系统运行状况整体分析\n";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.setAlignment("Center");
            document.Add(pg);
            StringBuilder sb = new StringBuilder();
            sb.Append("\n    作为各业务系统运行的基础环境，主机、数据库以及中间件的平稳运行是对各业务系统正常提供服务的前提。");
            sb.Append("因此，必须积极关注这些基础环境的运行情况。");
            sb.Append("    本部分将对主机、数据库以及中间件等三个基础环境的运行情况进行总体分析。");
            sb.Append("通过对各科室上报的主机系统日志、数据库系统检查日志及Statspack、中间件系统日志等信息进行整理、统计和分析，");
            sb.Append("对系统运行状态进行整体分析评介，并力图给出合理的建议，以供各科室参考。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);
            



            pg = new Paragraph("\n\n一、主机运行状况统计分析", GetFont(FontEnum.TitleLeft1));
            document.Add(pg);
            sb.Clear();
            sb.Append("    这部分主要针对主机CPU利用率、内存利用率、磁盘利用率进行统计分析。");
            sb.Append("分别以业务系统来分析评估主机的总体运行情况。");
            sb.Append("包括CPU利用率统计分析、内存利用率统计分析、磁盘利用率统计分析等三个部分。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);

            pg = new Paragraph("\n1. 主机CPU利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            AddImg(document);//生成，统计图
            
            


            pg = new Paragraph("\n\n二、数据库使用情况统计分析", GetFont(FontEnum.TitleLeft1));
            document.Add(pg);
            pg = new Paragraph("\n1. 表空间汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    本部分主要针对数据库磁盘空间使用情况进行统计分析，可了解各数据库中，表空间使用率>90%的情况，");
            sb.Append("并与上月作比较，以明确表空间的增减情况，以便及时作相关处理，以及提醒各科室及时处理存储空间问题，并为制定存储空间的扩充方案提供一定参考。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);

            pg = new Paragraph("\n2. 命中率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            pg = new Paragraph("    根据DB使用情况，制定不同的重点监控时段，对各时段的命中率进行横向比较，以清楚了解数据库的命中率情况。", GetFont(FontEnum.Content));
            document.Add(pg);

            pg = new Paragraph("\n3. JVM堆使用汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    Java虚拟机内存是Weblogic的核心参数之一，其直接关系到WebLogic的运行情况。");
            sb.Append("当内存消耗均值接近配置的最大内存数时，表明虚拟机内存资源比较紧张：当内存消耗均值比较小时，说明内存资源比较空闲。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);
        }

        public void ContentThreed(iTextSharp.text.Document document)
        {
            string strContent = "\n\n\n\n\n第三部分、业务运行状况整体分析";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.setAlignment("Center");
            document.Add(pg);
        }
        #region 字体处理
        Font GetFont(FontEnum mtype)
        {
            Font mFont = null;
            switch (mtype)
            {
                case FontEnum.TitleCenter:
                    mFont = new Font(bfSun, 18);
                    mFont.setStyle("normal");
                    break;
                case FontEnum.TitleLeft1:
                    mFont = new Font(bfSun, 16);
                    mFont.setStyle("bold");
                    break;
                case FontEnum.TitleLeft2:
                    mFont = new Font(bfSun, 14);
                    mFont.setStyle("normal");
                    break;
                default:
                    mFont = new Font(bfSun, 12);
                    mFont.setStyle("normal");
                    break;

            }
            return mFont;
        }

        enum FontEnum
        {
            TitleCenter,
            TitleLeft1,
            TitleLeft2,
            Content
        }
        #endregion

        #region 图形生成处理
        public void AddImg(iTextSharp.text.Document document)
        {
            Stream imageStream = new MemoryStream();
            string mpath = SavePath + Guid.NewGuid().ToString() + ".jpg";
            chLine.SaveImage(imageStream, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Jpeg);
            System.Drawing.Image img = System.Drawing.Image.FromStream(imageStream);
            img.Save(mpath, System.Drawing.Imaging.ImageFormat.Jpeg);
            Jpeg jpg = new Jpeg(new Uri(mpath));
            document.Add(jpg);
        }

        #endregion

        /// <summary>
        /// 第一页信息
        /// </summary>
        /// <param name="document"></param>
        public void InitFirstPage(iTextSharp.text.Document document)
        {
            document.Add(new Paragraph("\n\n\n\n"));
            //Title
            Font font = new Font(bfSun, 24);
            font.setStyle("bold");
            Paragraph pg = new Paragraph(SystemTitle, font);
            pg.setAlignment("Center");
            document.Add(pg);

            //subTitle            
            font = new Font(bfSun, 18);
            font.setStyle("bold");
            pg = new Paragraph(SubTitle, font);
            pg.setAlignment("Center");
            document.Add(pg);

            //版权、时间
            document.Add(new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"));
            font = new Font(bfSun, 18);
            font.setStyle("bold");
            pg = new Paragraph(Company, font);
            pg.setAlignment("Center");
            document.Add(pg);

            font = new Font(bfSun, 14);
            font.setStyle("bold");
            string mTime = string.Format("{0}年{1}月", DateTime.Now.Year, DateTime.Now.Month);
            pg = new Paragraph(mTime, font);
            pg.setAlignment("Center");
            document.Add(pg);

            document.Add(new Paragraph("\n\n\n\n\n\n\n\n\n\n"));

        }

    }
}