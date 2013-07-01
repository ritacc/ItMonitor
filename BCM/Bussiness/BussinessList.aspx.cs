using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.DAL.Sys;
using System.Data;

namespace GDK.BCM.Bussiness
{
    public partial class BussinessList : System.Web.UI.Page
    {
        BussinessDA busDA = new BussinessDA();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dt = busDA.GetTopBuss();
                if (null != dt)
                {
                    rpDepartment.DataSource = dt;
                    rpDepartment.DataBind();
                }
            }
        }
    }
}