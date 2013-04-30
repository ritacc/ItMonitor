using System;
using System.Web.UI.WebControls;

namespace GDK.BCM.UI
{
    public partial class pagenavigate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 分页事件
        /// </summary>
        public EventHandler OnPageChanged;

        /// <summary>
        /// 当前页索引
        /// </summary>
        public Int32 PageIndex
        {
            get
            {
                int p = Convert.ToInt32(this.lab_PageIndex.Text);
                if (p == 0)
                {
                    this.lab_PageIndex.Text = "1";
                    return 1;
                }
                return p;
                //return Convert.ToInt32(this.lab_PageIndex.Text);
            }
            set
            {
                this.lab_PageIndex.Text = value.ToString();
            }
        }

        /// <summary>
        /// 页面总数
        /// </summary>
        public Int32 PageCount
        {
            get
            {
                return Convert.ToInt32(this.lab_PageCount.Text);
            }
            set
            {
                this.lab_PageCount.Text = value.ToString();
            }
        }

        /// <summary>
        /// 每页记录数
        /// </summary>
        public Int32 PageSize
        {
            get
            {
                return Convert.ToInt32(this.ddlPageSize.SelectedValue);
            }
            set
            {
                ListItem li = this.ddlPageSize.Items.FindByValue(value.ToString());
                ddlPageSize.ClearSelection();
                if (null != li)
                {
                    li.Selected = true;
                }
                else
                {
                    this.ddlPageSize.Items.Insert(0, new ListItem(value.ToString()));
                    this.ddlPageSize.SelectedIndex = 0;
                }
            }
        }

        /// <summary>
        /// 所有记录总数
        /// </summary>
        public Int32 RecordCount
        {
            get
            {
                return Convert.ToInt32(this.lab_RecordCount.Text);
            }
            set
            {
                //this.PageCount = (value % this.PageSize == 0 ? value / this.PageSize : (value / this.PageSize) + 1);
                //this.lab_RecordCount.Text = value.ToString();
                this.lab_RecordCount.Text = value.ToString();
                if (value == 0)
                {
                    this.PageCount = 0;
                    this.PageIndex = 0;
                }
                else
                {
                    int m_pageCOunt = 0;
                    m_pageCOunt = value / PageSize + 1;
                    if (m_pageCOunt > 1 && (value % PageSize) == 0)//整数页，页数出错
                    {
                        m_pageCOunt--;
                    }
                    this.PageCount = m_pageCOunt;
                }
            }
        }

        

        #region Web 窗体设计器生成的代码
        override protected void OnInit(EventArgs e)
        {
            //
            // CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
            //
            InitializeComponent();
            base.OnInit(e);
        }

        /// <summary>
        ///		设计器支持所需的方法 - 不要使用代码编辑器
        ///		修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.img_first.Click += new System.Web.UI.ImageClickEventHandler(this.img_first_Click);
            this.img_prev.Click += new System.Web.UI.ImageClickEventHandler(this.img_prev_Click);
            this.img_next.Click += new System.Web.UI.ImageClickEventHandler(this.img_next_Click);
            this.img_last.Click += new System.Web.UI.ImageClickEventHandler(this.img_last_Click);
            this.img_gopage.Click += new System.Web.UI.ImageClickEventHandler(this.img_gopage_Click);
            this.ddlPageSize.SelectedIndexChanged += new EventHandler(ddlPageSize_SelectedIndexChanged);
            this.ddlPageSize.AutoPostBack = true;
        }
        #endregion

        /// <summary>
        /// 每页显示大小
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageIndex = 1;
            this.txt_gopage.Text = PageIndex.ToString();
            OnPageChanged(sender, e);
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_first_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            PageIndex = 1;
            this.txt_gopage.Text = PageIndex.ToString();
            OnPageChanged(sender, e);
        }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_prev_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            PageIndex = PageIndex - 1;
            this.txt_gopage.Text = PageIndex.ToString();
            OnPageChanged(sender, e);
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_next_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            PageIndex = PageIndex + 1;
            this.txt_gopage.Text = PageIndex.ToString();
            OnPageChanged(sender, e);
        }

        /// <summary>
        /// 末页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_last_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            PageIndex = PageCount;
            this.txt_gopage.Text = PageIndex.ToString();
            OnPageChanged(sender, e);
        }

        /// <summary>
        /// 转到
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void img_gopage_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            string goPage = this.txt_gopage.Text.Trim();
            System.Text.RegularExpressions.Regex rex =
            new System.Text.RegularExpressions.Regex(@"^\d+$");

            if (goPage == "" || !rex.IsMatch(goPage))
            {
                return;
            }

            int nGoPage = Convert.ToInt32(goPage);

            if (nGoPage <= PageCount && nGoPage >= 0)
            {
                PageIndex = nGoPage;
                OnPageChanged(sender, e);
            }
        }

        /// <summary>
        /// 改变分页按钮状态
        /// </summary>
        /// <param name="first"></param>
        /// <param name="prev"></param>
        /// <param name="next"></param>
        /// <param name="last"></param>
        private void changeBtn(Boolean first, Boolean prev, Boolean next, Boolean last)
        {
            this.img_first.Visible = first;
            this.img_prev.Visible = prev;
            this.img_next.Visible = next;
            this.img_last.Visible = last;
        }
    }
}