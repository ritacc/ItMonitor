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

        public const string Company = "广州吉飞科技技术有限公司";
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

            bfSun = BaseFont.CreateFont(fontPath + "SIMSUN.TTC,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
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
            PdfWriter.GetInstance(document, new FileStream(FilePath, FileMode.Create));

            document.Open();
            InitFirstPage();
            ContentFirstpart();//第一部分
            ContentSecondPart();//第二部分

            //ContentThreed();//第三部分
            document.Close();
            return FilePath;
        }

        BaseColor bgColor = new BaseColor(System.Drawing.Color.Beige);

		#region 第一部分-内容
		/// <summary>
        /// 内容第一部分
        /// </summary>
        /// <param name="document"></param>
        public void ContentFirstpart()
        {
            document.NewPage();
            string strContent = "第一部分、本月检查概述";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.Alignment = Element.ALIGN_CENTER;
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
		#endregion

		#region 第二部分-内容
		public void ContentSecondPart()
        {
            string strContent = "\n\n\n\n第二部分、系统运行状况整体分析\n";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);
            StringBuilder sb = new StringBuilder();
            sb.Append("\n    作为各业务系统运行的基础环境，主机、数据库以及中间件的平稳运行是对各业务系统正常提供服务的前提。因此，必须积极关注这些基础环境的运行情况。");
            sb.Append("    本部分将对主机、数据库以及中间件等三个基础环境的运行情况进行总体分析。");
            sb.Append("通过对各科室上报的主机系统日志、数据库系统检查日志及Statspack、中间件系统日志等信息进行整理、统计和分析，对系统运行状态进行整体分析评介，并力图给出合理的建议，以供各科室参考。");
            
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);
            


			//一
            chLine.Legends[0].Enabled = false;
            pg = new Paragraph("\n\n一、主机运行状况统计分析", GetFont(FontEnum.TitleLeft1));
            document.Add(pg);
            sb.Clear();
            sb.Append("    这部分主要针对主机CPU利用率、内存利用率、磁盘利用率进行统计分析。分别以业务系统来分析评估主机的总体运行情况。包括CPU利用率统计分析、内存利用率统计分析、磁盘利用率统计分析等三个部分。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);

            //主要CPU
            pg = new Paragraph("\n1. 主机CPU利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            chLine.Titles["titY"].Text = "均值(%)";
            chLine.Titles["titTop"].Text = "主机CPU利用率均值曲线序列图";
            DataTable dtList = UseReprot(25201);
            WriteTable(dtList, "当月CPU压力状态");//
            TableDesc("主机CPU");

            pg = new Paragraph("\n2. 主机内存利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            chLine.Titles["titTop"].Text = "主机内存利用率均值曲线序列图";            
            dtList = UseReprot(25202);
            WriteTable(dtList, "当月内存压力状态");//
            TableDesc("主机内存");

            pg = new Paragraph("\n3. 主机磁盘利用率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            chLine.Titles["titTop"].Text = "主机磁盘利用率均值曲线序列图";            
            dtList = UseReprot(25203);
            WriteTable(dtList, "当月磁盘压力状态");//
            TableDesc("主机磁盘");
            
			//二
            chLine.Legends[0].Enabled = true;
            pg = new Paragraph("\n\n二、数据库使用情况统计分析", GetFont(FontEnum.TitleLeft1));
            document.Add(pg);
            pg = new Paragraph("\n1. 表空间汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    本部分主要针对数据库磁盘空间使用情况进行统计分析，可了解各数据库中，表空间使用率>90%的情况，");
            sb.Append("并与上月作比较，以明确表空间的增减情况，以便及时作相关处理，以及提醒各科室及时处理存储空间问题，并为制定存储空间的扩充方案提供一定参考。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);
			PdfDA DA = new PdfDA();
			DA.SecondInit(this.SystemID,StartTime.AddMonths(-5),EndTime);
            DBTableSpaceUse();


            pg = new Paragraph("\n2. 命中率汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            pg = new Paragraph("    根据DB使用情况，制定不同的重点监控时段，对各时段的命中率进行横向比较，以清楚了解数据库的命中率情况。", GetFont(FontEnum.Content));
            document.Add(pg);
            MZL();


            pg = new Paragraph("\n3. 连接时间汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    通过本功能，列出平均连接时间最大的TOP10位数据库的情况，并以图形绘制出TOP10数据库的历史连接时间（注：以ms为单位）走势图。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
            document.Add(pg);
            Online();


            //三
            pg = new Paragraph("\n\n二、中间件运行状况统计分析", GetFont(FontEnum.TitleLeft1));
            document.Add(pg);
			DA.SecondMiddlewareInit(this.SystemID, StartTime.AddMonths(-5), EndTime);

            pg = new Paragraph("    本部分主要是针对运行各业务系统的中间件(WebLogic)的各项指标进行统计分析，分别从数据库连接池、Java虚拟机内存、应用会话等三个方面来分析评估综合征管系统中间件的总体运行情况。"
                , GetFont(FontEnum.Content));
            document.Add(pg);

            pg = new Paragraph("\n1. 数据库连接池汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            DBTableSpaceOnlinNumber();

            pg = new Paragraph("\n2、JVM堆使用汇总统计", GetFont(FontEnum.Content));
            document.Add(pg);
            sb.Clear();
            sb.Append("    Java虚拟机内存是Weblogic的核心参数之一，其直接关系到WebLogic的运行情况。当内存消耗均值接近配置的最大内存数时，表明虚拟机内存资源比较紧张；当内存消耗均值较小时，说明内存资源比较空闲。");
            pg = new Paragraph(sb.ToString(), GetFont(FontEnum.Content));
			MiddlewareJVM();

			pg = new Paragraph("\n3、会话数汇总统计", GetFont(FontEnum.Content));
			MiddlewareServerSession();
        }
        #region 一、主机运行状况统计分析
        /// <summary>
        /// 表格描述
        /// </summary>
        /// <param name="mTYpe"></param>
        public void TableDesc(string mTYpe)
        {
            TabeleIndex++;
            string minfo = string.Format("表{0}.{1}利用率汇总表", TabeleIndex, mTYpe);
            Paragraph pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);
            pg = new Paragraph("说明：", GetFont(FontEnum.TableSM));
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
            pg = new Paragraph(DescContent, GetFont(FontEnum.TableSM));
            document.Add(pg);
        }

        /// <summary>
        /// 使用率报表,并返回，table数据列表
        /// </summary>
        public DataTable UseReprot(int ChanncelID)
        {
            chLine.Series.Clear();

            PdfDA mda = new PdfDA();
            mda.InitData(SystemID, ChanncelID, StartTime, EndTime);
            DataTable dt = mda.GetUseLine();

            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            ser.MarkerStyle = MarkerStyle.Circle;
            ser.MarkerSize = 3;
            //ser.IsValueShownAsLabel = true;
            ser.LabelFormat = "{0}%";

            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "val");
            chLine.Series.Add(ser);

            AddImg();//生成，统计图

            return mda.GetUseTableInfo();
        }

        /// <summary>
        /// 写入表格数据
        /// </summary>
        /// <param name="dt"></param>
        public void WriteTable(DataTable dt, string mTypeStatusInfo)
        {
            PdfPTable pdfTB = new PdfPTable(11);
            pdfTB.WidthPercentage = 99;
            pdfTB.SetWidths(new float[] { 150f, 150f, 100f, 100f, 100f, 100f, 100f, 100f, 100f, 120f, 120f });
            //业务系统名称  IP	均值(%)		峰值(%) 峰值>80%出现次数(次) 当月CPU压力状态
            Font ft = GetFont(FontEnum.TableHeader);
            PdfPCell headr = GetPdfCell("业务系统名称");
            
            headr.Rowspan = 2;
            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("主机IP");
            
            headr.Rowspan = 2;
            
            pdfTB.AddCell(headr);


            headr = GetPdfCell("均值(%)");
            
            headr.Colspan = 4;
            
            pdfTB.AddCell(headr);


            headr = GetPdfCell("峰值(%)");
            
            
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("峰值>=80%出现次数（次）");
            

            headr.Colspan = 3;
            pdfTB.AddCell(headr);

            headr = GetPdfCell(mTypeStatusInfo);
            
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);


            headr = GetPdfCell("整月(%)");
            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("1-5");
            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("11-15");
            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("25-31");
            
            pdfTB.AddCell(headr);



            headr = GetPdfCell("1-5");
            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("11-15");
            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("25-31");
            
            pdfTB.AddCell(headr);

            //headr = GetPdfCell("峰值>80%出现次数(次)", ft));
            //
            //pdfTB.AddCell(headr);



            if (dt != null)
            {
                Font ftContent = GetFont(FontEnum.Content);
                foreach (DataRow dr in dt.Rows)
                {

                    pdfTB.AddCell(new Phrase(dr["DeviceName"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["ip"].ToString(), ftContent));

                    pdfTB.AddCell(new Phrase(dr["avgval"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["avgNum15"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["avgNum1115"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["avgNum2531"].ToString(), ftContent));

                    pdfTB.AddCell(new Phrase(dr["maxval"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["MaxNum15"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["MaxNum1115"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["MaxNum2531"].ToString(), ftContent));

                    // pdfTB.AddCell(new Phrase(dr["maxNum"].ToString(), ftContent));
                    pdfTB.AddCell(new Phrase(dr["Status"].ToString(), ftContent));
                }
            }
            string strContent = string.Format("统计期：{0}", ReportData);
            document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
            document.Add(pdfTB);
        }
        #endregion

        #region   二、数据库使用情况统计分析
        private PdfPCell GetPdfCell(string Name)
        {
            Font ft = GetFont(FontEnum.TableHeader);
            
            PdfPCell pcell = new PdfPCell(new Phrase(Name, ft));
            pcell.HorizontalAlignment = 1;
            pcell.BackgroundColor = bgColor;
            return pcell;

        }
        /// <summary>
        /// 1. 表空间汇总统计
        /// </summary>
        private void DBTableSpaceUse()
        {
            chLine.Series.Clear();

            chLine.Titles["titY"].Text = "使用率(%)";
            chLine.Titles["titTop"].Text = "表空间使用率曲线序列图";

            PdfDA mda = new PdfDA();
            DataTable dt = mda.SlectDBNameSpanceUse();
            Series ser = new Series();
            ser.ChartType = SeriesChartType.Line;
            ser.MarkerStyle = MarkerStyle.Circle;
            ser.LegendText = SystemTitle;
            ser.MarkerSize = 3;
            ser.LabelFormat = "{0}%";

            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "monitorvalue");
            
            chLine.Series.Add(ser);
            AddImg();//生成，统计图

            //添加表
            dt = mda.SlectDBNameSpanceUse();

            PdfPTable pdfTB = new PdfPTable(6);
            pdfTB.WidthPercentage = 99;

            Font ft = GetFont(FontEnum.TableHeader);
            PdfPCell headr = GetPdfCell("业务系统名称");
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("数据库名");
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("表空间名");
            headr.Rowspan = 2;            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("使用率");
            headr.Colspan = 3;            
            pdfTB.AddCell(headr);

            headr = GetPdfCell("本月");
            pdfTB.AddCell(headr);

            headr = GetPdfCell("上月");
            pdfTB.AddCell(headr);

            headr = GetPdfCell("同比%");
            pdfTB.AddCell(headr);

           dt= mda.SlectDBNameSpanceUseDetail(this.StartTime.Year, this.StartTime.Month,SystemID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Font dbftContent = GetFont(FontEnum.Content);
                    pdfTB.AddCell(new Phrase(dr["DeviceName"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["DBName"].ToString(), dbftContent));

                    pdfTB.AddCell(new Phrase(dr["tableSpaceName"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["monitorvalue"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["syValue"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["tb"].ToString(), dbftContent));
                }
            }
            string strContent = string.Format("统计期：{0}", ReportData);
            document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
            document.Add(pdfTB);

            //内容
            TabeleIndex++;
            string minfo = string.Format("表{0}：达警戒水平数据库表空间汇总表", TabeleIndex);
            Paragraph pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);
         

            string DescContent = @"说明：
 1)	表中数据的含义如下：
     a)	本月使用率：表空间使用率当天当前所采样点的值；
     b)	上月使用率：上月30日表空间使用率所采样点的值；
     c) 同比%：是本月使用率/上月使用率所获得的值；
 2)	表空间使用率评级标准：警戒状态90%，警报状态95%；
 3)	本表汇总统计各单位使用率超过警戒水平的表空间；
 4)	“--”表示无异常信息。";
            pg = new Paragraph(DescContent, GetFont(FontEnum.TableSM));
            document.Add(pg);
        }

        #region 2.命中率
        private void MZL()
        {
            chLine.Titles["titY"].Text = "使用率(%)";
         
            chLine.Titles["titTop"].Text = "命中率-缓冲区汇总柱状图";
            mzl(41601);

            chLine.Titles["titTop"].Text = "命中率-数据字典汇总柱状图";
            mzl(41602);

            chLine.Titles["titTop"].Text = "命中率-库汇总柱状图";
            mzl(41603);

            PdfPTable pdfTB = new PdfPTable(10);
            pdfTB.WidthPercentage = 99;

            Font ft = GetFont(FontEnum.TableHeader);
            PdfPCell headr = GetPdfCell("DB名");
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("命中率-缓冲区");            
            headr.Colspan = 3;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("命中率-数据字典");           
            headr.Colspan = 3;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("命中率-库");            
            headr.Colspan = 3;
            pdfTB.AddCell(headr);

            for (int i = 0; i < 3; i++)
            {
                headr = GetPdfCell("MAX");
                pdfTB.AddCell(headr);

                headr = GetPdfCell("MIN");
                pdfTB.AddCell(headr);

                headr = GetPdfCell("AVG");
                pdfTB.AddCell(headr);
            }
            PdfDA mda = new PdfDA();
            DataTable dt = mda.SelectMZLDetail(this.StartTime.Year, this.StartTime.Month);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Font dbftContent = GetFont(FontEnum.Content);
                    pdfTB.AddCell(new Phrase(dr["DeviceName"].ToString(), dbftContent));
                    
                    pdfTB.AddCell(new Phrase(dr["hcqmax"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["hcqmin"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["hcqavg"].ToString(), dbftContent));

                    pdfTB.AddCell(new Phrase(dr["sjzdmax"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["sjzdmin"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["sjzdavg"].ToString(), dbftContent));

                    pdfTB.AddCell(new Phrase(dr["kmax"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["kmin"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["kavg"].ToString(), dbftContent));
                }
            }
            string strContent = string.Format("统计期：{0}", ReportData);
            document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
            document.Add(pdfTB);

            //内容
            TabeleIndex++;
            string minfo = string.Format("表{0}：数据库命中率汇总表", TabeleIndex);
            Paragraph pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);
            //pg = new Paragraph("说明：", font);
            //document.Add(pg);

            string DescContent = @"说明：
     1)	本表汇总统计各数据库系统命中率超过警戒水平的表空间；
     2)	“--”表示无异常信息。";
            pg = new Paragraph(DescContent, GetFont(FontEnum.TableSM));
            document.Add(pg);

        }

        private void mzl(int ChanncelNo)
        {
            chLine.Series.Clear();

            PdfDA mda = new PdfDA();
            DataTable dt = mda.SelectMZLImg(ChanncelNo);

            Series ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LabelFormat = "{0}%";
            ser.LegendText = "最大值";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "maxval");
            chLine.Series.Add(ser);

            ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LegendText = "最小值";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "minval");
            chLine.Series.Add(ser);

            ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LegendText = "平均值";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "avgval");
            chLine.Series.Add(ser);
            AddImg();//生成，统计图
        }
        #endregion

        /// <summary>
        /// 3、连接时间汇总统计
        /// </summary>
        private void Online()
        {
            chLine.Titles["titY"].Text = "使用率(%)";
            chLine.Titles["titTop"].Text = "命中率-缓冲区汇总柱状图";

            chLine.Series.Clear();

            PdfDA mda = new PdfDA();
            DataTable dt = mda.SelectOnline();

            Series ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LabelFormat = "{0}%";
            ser.LegendText = "JVM最大响应时间";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "maxval");
            chLine.Series.Add(ser);

            ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LegendText = "JVM最小响应时间";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "minval");
            chLine.Series.Add(ser);

            ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LegendText = "JVM平均响应时间";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "avgval");
            chLine.Series.Add(ser);
            AddImg();//生成，统计图


            PdfPTable pdfTB = new PdfPTable(6);
            pdfTB.WidthPercentage = 99;

            Font ft = GetFont(FontEnum.TableHeader);
            PdfPCell headr = GetPdfCell("业务系统");
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("DB名");
            headr.Rowspan = 2;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("连接时间（单位：ms）");
            headr.Colspan = 4;
            pdfTB.AddCell(headr);

            headr = GetPdfCell("峰值");
            pdfTB.AddCell(headr);
            headr = GetPdfCell("最小值");
            
            
            pdfTB.AddCell(headr);
            headr = GetPdfCell("均值");
            pdfTB.AddCell(headr);

            headr = GetPdfCell(">阀值（60ms）的次数");
            pdfTB.AddCell(headr);

              dt = mda.SelectOnlineDetail(this.StartTime.Year, this.StartTime.Month,SystemID);
             if (dt != null)
             {
                 foreach (DataRow dr in dt.Rows)
                 {
                     Font dbftContent = GetFont(FontEnum.Content);
                     pdfTB.AddCell(new Phrase(dr["DeviceName"].ToString(), dbftContent));
                     pdfTB.AddCell(new Phrase(dr["DBName"].ToString(), dbftContent));
                     pdfTB.AddCell(new Phrase(dr["maxval"].ToString(), dbftContent));
                     pdfTB.AddCell(new Phrase(dr["minval"].ToString(), dbftContent));
                     pdfTB.AddCell(new Phrase(dr["avgval"].ToString(), dbftContent));
                     pdfTB.AddCell(new Phrase(dr["num"].ToString(), dbftContent));
                 }
             }

             string strContent = string.Format("统计期：{0}", ReportData);
             document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
             document.Add(pdfTB);

             //内容
             TabeleIndex++;
             string minfo = string.Format("表{0}：连接时间汇总统计", TabeleIndex);
             Paragraph pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
             pg.Alignment = Element.ALIGN_CENTER;
             document.Add(pg);
             pg = new Paragraph( @"注：列出本月中平均连接时间最大的TOP10位数据库的连接时间历史数据。", GetFont(FontEnum.TableSM));
             document.Add(pg);

        }
        #endregion 

        #region 三、中间件运行状况统计分析
        #region 1. 数据库连接池汇总统计
        private void DBTableSpaceOnlinNumber()
        {
             PdfDA mda = new PdfDA();

            //查询数据
             DataTable DBTableSpace = mda.SelectDBTableSpace(SystemID);
             Paragraph pg = new Paragraph("\r\n", GetFont(FontEnum.TableSM));
             if (DBTableSpace != null && DBTableSpace.Rows.Count > 0)
             {
                
                 foreach (DataRow dr in DBTableSpace.Rows)
                 {
                     LoadDBTableSpaceLineNumberImg(Convert.ToInt32(dr["deviceno"].ToString()), dr["tableSpaceName"].ToString());
                     document.Add(pg);
                 }
             }
             //数据详细，表格
             PdfPTable pdfTB = new PdfPTable(8);
             pdfTB.WidthPercentage = 99;

             Font ft = GetFont(FontEnum.TableHeader);
             PdfPCell headr = GetPdfCell("数据库");
             headr.Colspan = 2;
             pdfTB.AddCell(headr);

             headr = GetPdfCell("本月");
             headr.Colspan = 3;
             pdfTB.AddCell(headr);

             headr = GetPdfCell("上月");
             headr.Colspan = 3;
             pdfTB.AddCell(headr);

             headr = GetPdfCell("名称");
             pdfTB.AddCell(headr);

             headr = GetPdfCell("连接池名");
             pdfTB.AddCell(headr);
             for (int i = 0; i < 2; i++)
             {
                 headr = GetPdfCell("连接数峰值");
                 pdfTB.AddCell(headr);

                 headr = GetPdfCell("最小值");
                 pdfTB.AddCell(headr);

                 headr = GetPdfCell("均值");
                 pdfTB.AddCell(headr);
             }


            DataTable dt = mda.DBTableSpaceLineNumberDetail(StartTime.Year, StartTime.Month, SystemID);
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    Font dbftContent = GetFont(FontEnum.Content);
                    pdfTB.AddCell(new Phrase(dr["DBName"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["tableSpaceName"].ToString(), dbftContent));

                    pdfTB.AddCell(new Phrase(dr["maxval"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["minval"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["avgval"].ToString(), dbftContent));

                    pdfTB.AddCell(new Phrase(dr["symaxval"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["syminval"].ToString(), dbftContent));
                    pdfTB.AddCell(new Phrase(dr["syavgval"].ToString(), dbftContent));
                }
            }
            string strContent = string.Format("统计期：{0}", ReportData);
            document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
            document.Add(pdfTB);
            
            TabeleIndex++;
            string minfo = string.Format("表{0}：数据库命中率汇总表", TabeleIndex);
             pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);

            string DescContent = @"注：列出本月均值TOP10的连接池情况及与上月相应情况作对比。";
            pg = new Paragraph(DescContent, GetFont(FontEnum.TableSM));
            document.Add(pg);
        }

        /// <summary>
        /// 加载，表空间，连接数据，图形
        /// </summary>
        /// <param name="spacedeviceID"></param>
        /// <param name="SpaceName"></param>
        private void LoadDBTableSpaceLineNumberImg(int spacedeviceID,string SpaceName)
        {
            chLine.Series.Clear();
            chLine.Titles["titY"].Text = "连接数";
            chLine.Titles["titTop"].Text = string.Format("数据库连接池 {0} 汇总柱状图", SpaceName);

            PdfDA mda = new PdfDA();
            DataTable dt = mda.DBTableSpaceLineNumberImg(SystemID, spacedeviceID);

            Series ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LabelFormat = "{0}%";
            ser.LegendText = "最大值";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "maxval");
            chLine.Series.Add(ser);

            ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LegendText = "最小值";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "minval");
            chLine.Series.Add(ser);

            ser = new Series();
            ser.ChartType = SeriesChartType.Column;
            ser["DrawingStyle"] = "Cylinder";
            ser.MarkerSize = 3;
            ser.LegendText = "平均值";
            ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "avgval");
            chLine.Series.Add(ser);
            AddImg();//生成，统计图
        }
        #endregion
		#region 2、JVM堆使用汇总统计
		public void MiddlewareJVM()
		{
			PdfDA mda = new PdfDA();
			//查询数据
			DataTable DBTableSpace = mda.GetBussMiddlewareName(SystemID);
			Paragraph pg = new Paragraph("\r\n", GetFont(FontEnum.TableSM));
			if (DBTableSpace != null && DBTableSpace.Rows.Count > 0)
			{
				foreach (DataRow dr in DBTableSpace.Rows)
				{
					LoadMiddlewareJVMImg(Convert.ToInt32(dr["DeviceID"].ToString()), dr["DeviceName"].ToString());
					document.Add(pg);
				}
			}

			//数据详细，表格
			PdfPTable pdfTB = new PdfPTable(8);
			pdfTB.WidthPercentage = 99;

			Font ft = GetFont(FontEnum.TableHeader);
			PdfPCell headr = GetPdfCell("");
			headr.Colspan = 2;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("本月");
			headr.Colspan = 3;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("上月");
			headr.Colspan = 3;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("业务系统名称");
			pdfTB.AddCell(headr);

			headr = GetPdfCell("IP地址");
			pdfTB.AddCell(headr);
			for (int i = 0; i < 2; i++)
			{
				headr = GetPdfCell("JVM堆最大值");
				pdfTB.AddCell(headr);

				headr = GetPdfCell("最小值");
				pdfTB.AddCell(headr);

				headr = GetPdfCell("均值");
				pdfTB.AddCell(headr);
			}


			DataTable dt = mda.MiddlewareJVMDetail(StartTime.Year, StartTime.Month);
			if (dt != null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					Font dbftContent = GetFont(FontEnum.Content);
					pdfTB.AddCell(new Phrase(dr["busName"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["midName"].ToString(), dbftContent));

					pdfTB.AddCell(new Phrase(dr["maxval"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["minval"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["avgval"].ToString(), dbftContent));

					pdfTB.AddCell(new Phrase(dr["symaxval"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["syminval"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["syavgval"].ToString(), dbftContent));
				}
			}
			string strContent = string.Format("统计期：{0}", ReportData);
			document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
			document.Add(pdfTB);

			TabeleIndex++;
			string minfo = string.Format("表{0}：中间件JVM使用情况汇总", TabeleIndex);
			pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
			pg.Alignment = Element.ALIGN_CENTER;
			document.Add(pg);

			string DescContent = @"注：列出本月均值TOP10的JVM内存情况及与上月相应情况作对比。";
			pg = new Paragraph(DescContent, GetFont(FontEnum.TableSM));
			document.Add(pg);
		}

		private void LoadMiddlewareJVMImg(int deviceid, string devicename)
		{
			chLine.Series.Clear();
			chLine.Titles["titY"].Text = "连接数";
			chLine.Titles["titTop"].Text = string.Format("{0} 使用率汇总柱状图", devicename);

			PdfDA mda = new PdfDA();
			DataTable dt = mda.MiddlewareJVMImg(deviceid);

			Series ser = new Series();
			ser.ChartType = SeriesChartType.Column;
			ser["DrawingStyle"] = "Cylinder";
			ser.MarkerSize = 3;
			ser.LabelFormat = "{0}%";
			ser.LegendText = "最大值";
			ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "maxval");
			chLine.Series.Add(ser);

			ser = new Series();
			ser.ChartType = SeriesChartType.Column;
			ser["DrawingStyle"] = "Cylinder";
			ser.MarkerSize = 3;
			ser.LegendText = "最小值";
			ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "minval");
			chLine.Series.Add(ser);

			ser = new Series();
			ser.ChartType = SeriesChartType.Column;
			ser["DrawingStyle"] = "Cylinder";
			ser.MarkerSize = 3;
			ser.LegendText = "平均值";
			ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "avgval");
			chLine.Series.Add(ser);
			AddImg();//生成，统计图
		}
		#endregion
		#region 3、会话数汇总统计
		 
		public void MiddlewareServerSession()
		{
			PdfDA mda = new PdfDA();
			//查询数据
			DataTable DBTableSpace = mda.MiddlewareServerSessionImg(SystemID);
			Paragraph pg = new Paragraph("\r\n", GetFont(FontEnum.TableSM));
			if (DBTableSpace != null && DBTableSpace.Rows.Count > 0)
			{
				foreach (DataRow dr in DBTableSpace.Rows)
				{
					LoadMiddlewareServerSessionImg(Convert.ToInt32(dr["DeviceID"].ToString()), dr["DeviceName"].ToString());
					document.Add(pg);
				}
			}

			//数据详细，表格
			PdfPTable pdfTB = new PdfPTable(8);
			pdfTB.WidthPercentage = 99;

			Font ft = GetFont(FontEnum.TableHeader);
			PdfPCell headr = GetPdfCell("");
			headr = GetPdfCell("业务系统");
			headr.Rowspan = 2;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("WEBLOGIC名");
			headr.Rowspan = 2;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("WEB应用名");
			headr.Rowspan = 2;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("本月");
			headr.Colspan = 3;
			pdfTB.AddCell(headr);

			headr = GetPdfCell("活动会话数");
			pdfTB.AddCell(headr);

			headr = GetPdfCell("最大会话数");
			pdfTB.AddCell(headr);

			headr = GetPdfCell("总计会话数");
			pdfTB.AddCell(headr);



			DataTable dt = mda.MiddlewareServerSessionDetail(StartTime.Year, StartTime.Month, this.SystemID);
			if (dt != null)
			{
				foreach (DataRow dr in dt.Rows)
				{
					Font dbftContent = GetFont(FontEnum.Content);
					pdfTB.AddCell(new Phrase(dr["busName"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["midName"].ToString(), dbftContent));

					pdfTB.AddCell(new Phrase(dr["maxval"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["minval"].ToString(), dbftContent));
					pdfTB.AddCell(new Phrase(dr["sumval"].ToString(), dbftContent));
				}
			}
			string strContent = string.Format("统计期：{0}", ReportData);
			document.Add(new Phrase(strContent, GetFont(FontEnum.Title12Bold)));
			document.Add(pdfTB);

			TabeleIndex++;
			string minfo = string.Format("表{0}：中间件会话数汇总", TabeleIndex);
			pg = pg = new Paragraph(minfo, GetFont(FontEnum.TableIndex));
			pg.Alignment = Element.ALIGN_CENTER;
			document.Add(pg);

			string DescContent = @" 
说明：
  1) 缺省队列最大线程数：指WebLogic缺省队列配置的最大线程数；
  2) 采集最大值：指全月中执行队列占用的最高值；
  3) 采集均值：指全月中执行队列占用的平均值；
  4) --：表示未提交；
  5) N/A：表示不需要提交或没有该值。
";
			pg = new Paragraph(DescContent, GetFont(FontEnum.TableSM));
			document.Add(pg);
		}

		private void LoadMiddlewareServerSessionImg(int deviceid, string devicename)
		{
			chLine.Series.Clear();
			chLine.Titles["titY"].Text = "会话数";
			chLine.Titles["titTop"].Text = string.Format("{0} 会话数汇总柱状图", devicename);

			PdfDA mda = new PdfDA();
			DataTable dt = mda.MiddlewareJVMImg(deviceid);

			Series ser = new Series();
			ser.ChartType = SeriesChartType.Column;
			ser["DrawingStyle"] = "Cylinder";
			ser.MarkerSize = 3;
			ser.LabelFormat = "{0}%";
			ser.LegendText = "最大值";
			ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "maxval");
			chLine.Series.Add(ser);

			ser = new Series();
			ser.ChartType = SeriesChartType.Column;
			ser["DrawingStyle"] = "Cylinder";
			ser.MarkerSize = 3;
			ser.LegendText = "最小值";
			ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "minval");
			chLine.Series.Add(ser);

			ser = new Series();
			ser.ChartType = SeriesChartType.Column;
			ser["DrawingStyle"] = "Cylinder";
			ser.MarkerSize = 3;
			ser.LegendText = "总计会话数";
			ser.Points.DataBindXY(dt.Rows, "monitordate", dt.Rows, "sumval");
			chLine.Series.Add(ser);
			AddImg();//生成，统计图
		}
		#endregion
		#endregion

		#endregion

		#region 第三部分-内容
		public void ContentThreed()
        {
            document.NewPage();
            string strContent = "\n\n\n\n\n第三部分、业务运行状况整体分析";
            Paragraph pg = new Paragraph(strContent, GetFont(FontEnum.TitleCenter));
            pg.Alignment = Element.ALIGN_CENTER;
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

        enum FontEnum
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
        #endregion

        #region 图形生成处理
        public void AddImg()
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
            font.SetStyle("bold");
            Paragraph pg = new Paragraph(SystemTitle, font);
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);

            //subTitle            
            font = new Font(bfSun, 18);
            font.SetStyle("bold");
            pg = new Paragraph(SubTitle, font);
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);

            //版权、时间
            document.Add(new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n"));
            font = new Font(bfSun, 18);
            font.SetStyle("bold");
            pg = new Paragraph(Company, font);
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);

            font = new Font(bfSun, 14);
            font.SetStyle("bold");
            //string mTime = string.Format("{0}年{1}月", DateTime.Now.Year, DateTime.Now.Month);
            pg = new Paragraph(ReportData, font);
            pg.Alignment = Element.ALIGN_CENTER;
            document.Add(pg);
        }
    }
}