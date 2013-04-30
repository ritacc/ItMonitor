using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GDK.BCM.UI
{
    public partial class SelectFile : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public Unit Width
        {
            set { txtFileName.Width = value; }
        }

        public string Text
        {
            set { txtFileName.Text = value; }
            get { return txtFileName.Text; }
        }
        public string Floder
        {
            set { txtFloder.Text = value; }
            get { return txtFloder.Text; }
        }
        public bool Enable
        {
            set
            {
                selectFIle.Visible = value;
                txtFileName.Enabled = value;
            }
        }
    }
}