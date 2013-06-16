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

namespace GDK.BCM.CompReport
{
    public class GeneratePDF
    {
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

        public const string Company = "广东省国家税务局信息中心";
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

        /// <summary>
        /// 本文档表序号
        /// </summary>
        private int TabeleIndex = 0;

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

        private iTextSharp.text.Document document=null;
        public string Generate()
        {
            InitFont();

            string currentPath = SavePath;
            if (!currentPath.EndsWith("\\"))
                currentPath += "\\";


            string FilePath = currentPath + Guid.NewGuid().ToString() + ".pdf";

            document = new iTextSharp.text.Document();
            PdfWriter.getInstance(document, new FileStream(FilePath, FileMode.Create));

            document.Open();
            InitFirstPage();
            ContentFirstpart();//第一部分
            ContentSecondPart();//第二部分
            ContentThreed();//第三部分
            document.Close();
            
            return FilePath;
        }



        /// <summary>
        /// 内容第一部分
        /// </summary>
        /// <param name="document"></param>
        public void ContentFirstpart()
        {
            document.newPage();
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

        public void ContentSecondPart()
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

            //主要CPU
            pg = new Paragraph("\n1. 主机CPU利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            chLine.Titles[0].Text = "主机CPU利用率均值曲线序列图";
            DataTable dtList = UseReprot(document, 25201);
            WriteTable(dtList, "当月CPU压力状态");//
            TableDesc("主机CPU");

            pg = new Paragraph("\n2. 主机内存利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            chLine.Titles[0].Text = "主机内存利用率均值曲线序列图";
            dtList = UseReprot(document, 25202);
            WriteTable(dtList, "当月内存压力状态");//
            TableDesc("主机内存");

            pg = new Paragraph("\n3. 主机磁盘利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            chLine.Titles[0].Text = "主机磁盘利用率均值曲线序列图";
            dtList = UseReprot(document, 25203);
            WriteTable(dtList, "当月磁盘压力状态");//
            TableDesc("主机磁盘");
            

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

        public void ContentThreed()
        {
            string strContent = "\n\n\n\n\n第三部分、业务运行状况整体分析";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.setAlignment("Center");
            document.Add(pg);
        }
        #region 第一部分 表格描述
        /// <summary>
        /// 
        /// </summary>
        /// <param name="mTYpe"></param>
        public void TableDesc(string mTYpe)
        {
            Font font = new Font(bfSun, 11);
            font.setStyle("bold");
            TabeleIndex++;
            string minfo = string.Format("表{0}.{1}利用率汇总表", TabeleIndex, mTYpe);
            Paragraph pg = pg = new Paragraph(minfo, font);
            pg.setAlignment("Center");
            document.Add(pg);
            pg = new Paragraph("说明：", font);
            document.Add(pg);

            string DescContent = string.Format(@"1) 本表是按照{0}利用率均值降序排列
2) 表中的数据含意如下：
    均值：本月工作日中，{0}利用率的所有采点的均值。
    峰值：本月工作日中，{0}利用率的所有采点的最高值。
    峰值>80%的次数，按照每5分钟一次的采样率，本月{0}峰值达80%及以上的出现次数。
    {0}压力状态，按照规定评级标准，对{0}压力情况的评估，详细评级标准如下：
        极低：均值<20%,且峰值<100%
        正常：均值<60%，且峰值≤100%,且峰值大于等于80%的次数≤200
        高压：均值<60%，且峰值=100%,且峰值大于等于80%的次数>200
        警戒：60%≤均值<80%.
        报警：均值≥80%
3) “-”表示，未提交有效数据。", mTYpe);
            font = new Font(bfSun, 9);
            font.setStyle("normal");
            pg = new Paragraph(DescContent, font);
            document.Add(pg);          
        }


        #endregion

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
                case FontEnum.Title12Bold:
                    mFont = new Font(bfSun, 12);
                    mFont.setStyle("bold");
                    break;
                case FontEnum.TableHeader:
                    mFont = new Font(bfSun, 14);
                    mFont.setStyle("bold");
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
            Title12Bold,
            Content,
            TableHeader
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
        public void InitFirstPage()
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
            //string mTime = string.Format("{0}年{1}月", DateTime.Now.Year, DateTime.Now.Month);
            pg = new Paragraph(ReportData, font);
            pg.setAlignment("Center");
            document.Add(pg);
            
        }


        #region 数据库处理

        /// <summary>
        /// 使用率报表,并返回，table数据列表
        /// </summary>
        public DataTable UseReprot(iTextSharp.text.Document document, int ChanncelID)
        {
            PdfDA mda = new PdfDA();
            mda.InitData(SystemID, ChanncelID, StartTime, EndTime);
            DataTable dt = mda.GetUseLine();

            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            ser.MarkerStyle = MarkerStyle.Circle;
            ser.MarkerSize = 3;
            //ser.IsValueShownAsLabel = true;
            ser.LabelFormat="{0}%";

            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "val");
            chLine.Series.Add(ser);
            
            AddImg(document);//生成，统计图

            return mda.GetUseTableInfo();
        }

        /// <summary>
        /// 写入表格数据
        /// </summary>
        /// <param name="dt"></param>
        public void WriteTable(DataTable dt,string mTypeStatusInfo)
        {
            
            PdfPTable pdfTB = new PdfPTable(6);
            pdfTB.WidthPercentage = 99;
            pdfTB.setWidths(new float[] { 200f, 200f, 100f, 100f, 120f, 120f });
            //业务系统名称  IP	均值(%)		峰值(%) 峰值>80%出现次数(次) 当月CPU压力状态
            Color bgColor = new Color(System.Drawing.Color.Beige); ;

            Font ft = GetFont(FontEnum.TableHeader);
            PdfPCell headr = new PdfPCell(new Phrase("业务系统名称", ft));
            headr.BackgroundColor = bgColor;
            pdfTB.addCell(headr);

            headr = new PdfPCell(new Phrase("IP", ft));
            headr.BackgroundColor = bgColor;
            pdfTB.addCell(headr);

            headr = new PdfPCell(new Phrase("均值(%)", ft));
            headr.BackgroundColor = bgColor;
            pdfTB.addCell(headr);

            headr = new PdfPCell(new Phrase("峰值(%)", ft));
            headr.BackgroundColor = bgColor;
            pdfTB.addCell(headr);

            headr = new PdfPCell(new Phrase("峰值>80%出现次数(次)", ft));
            headr.BackgroundColor = bgColor;
            pdfTB.addCell(headr);

            headr = new PdfPCell(new Phrase(mTypeStatusInfo, ft));
            headr.BackgroundColor = bgColor;
            pdfTB.addCell(headr);

            if (dt != null)
            {

                Font ftContent = GetFont(FontEnum.Content);
                foreach (DataRow dr in dt.Rows)
                {

                    pdfTB.addCell(new Phrase(dr["DeviceName"].ToString(), ftContent));
                    pdfTB.addCell(new Phrase(dr["ip"].ToString(), ftContent));
                    pdfTB.addCell(new Phrase(dr["avgval"].ToString(), ftContent));
                    pdfTB.addCell(new Phrase(dr["maxval"].ToString(), ftContent));
                    pdfTB.addCell(new Phrase(dr["maxNum"].ToString(), ftContent));
                    pdfTB.addCell(new Phrase(dr["Status"].ToString(), ftContent));
                }
            }
            string strContent = string.Format("统计期：{0}", ReportData);
            document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
            document.Add(pdfTB);
        }
        #endregion
    }
}