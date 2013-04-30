using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DAL.Sys;
using System.Collections.Generic;
using Entity.Sys;
namespace ZCGL
{
    public partial class Role_UserAuthRose : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                initPage();
            }
        }

        private void initPage()
        {
            initRose();//初使化角色列表

            initUserRose();
            InitUserInfo();
        }

        private void initRose()
        {
            RolesDA rs = new RolesDA();
            int Count = 0;
            DataTable listRose = rs.selectAllDateByWhere(1, 50, out Count, "");
            cblRoseList.DataSource = listRose;
            cblRoseList.DataTextField = "ROLE_NAME";
            cblRoseList.DataValueField = "GUID";
            cblRoseList.DataBind();
        }

        private void InitUserInfo()
        {

            if (Request.QueryString["userid"] != null)
            {
                UsersOR obj = new UsersDA().selectARowDateByGuid(Request.QueryString["userid"].ToString());
                if (obj != null)
                {
                    this.txt_UserName.Text = obj.LogonName;
                    //this.txt_phone.Text = obj.PHONE;
                    this.txt_name.Text = obj.DisplayName;
                }
            }
        }

        private void initUserRose()
        {
            if (null != Request.QueryString["userid"])
            {
                string userid = Request.QueryString["userid"].ToString();

                UserRolesDA rs = new UserRolesDA();
                DataTable listUserRose = rs.GetUserRoseBuyUserID(userid);
                foreach (DataRow dr in listUserRose.Rows)
                {
                    checkCBList(dr["ROLE_GUID"].ToString());
                }
            }
            else
            {
                base.Alert("获取用户ID失败！");
            }
        }

        private void checkCBList(string guid)
        {
            foreach (ListItem li in cblRoseList.Items)
            {
                if (li.Value == guid)
                {
                    li.Selected = true;
                }
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (null != Request.QueryString["userid"])
            {
                string userid = Request.QueryString["userid"].ToString();

                List<UserRolesOR> listUR = new List<UserRolesOR>();
                foreach (ListItem li in cblRoseList.Items)
                {
                    if (li.Selected)
                    {
                        UserRolesOR tur = new UserRolesOR();
                        tur.UserGuid = userid;
                        tur.RoleGuid = li.Value;
                        listUR.Add(tur);
                    }
                }
                if (listUR.Count == 0)
                {
                    base.Alert("请选择角色。");
                }
                UserRolesDA rs = new UserRolesDA();
                if (rs.AddUserRoles(listUR))
                {
                    base.Close(true);
                }
                else
                {
                    base.Alert("授权失败！");
                }
            }
            else
            {
                base.Alert("获取用户ID失败！");
            }
        }
    }

}
