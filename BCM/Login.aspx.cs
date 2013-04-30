using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.Sys;
using GDK.DAL.Sys;
using HB.Framework.Security.OU;

namespace GDK.BCM
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    Request.Cookies.Clear();
            //    Session.Clear();
            //    IHBDsUser user = HBIdentity.CurrentUser;
            //    Response.Redirect("~/Main/Master/Default.aspx");
            //}
        }

        protected void ibtnLogin_Click(object sender, ImageClickEventArgs e)
        {
            UsersOR user;
            try
            {
                user = new UsersDA().sp_UserLogin(txtUersName.Text, txtPassword.Text);
            }
            catch (Exception ex)
            {
                Alert(ex.Message.Replace("'", "").Replace("\r\n", ""));
                return;
            }
            Session["CurrentUser"] = user;
            HttpCookie cookieGuid = new HttpCookie("CurrentUser");
            cookieGuid.Expires = DateTime.Now.AddHours(9);

            cookieGuid.Values.Add("UserID", user.Guid);
            cookieGuid.Values.Add("LoginName", user.LogonName);
            cookieGuid.Values.Add("UserName", user.DisplayName);
            cookieGuid.Values.Add("Password", user.UserPwd);
            cookieGuid.Path = "/";
            Response.AppendCookie(cookieGuid);

            List<VHC_USER_PERMISSIONS> _Permissions = new UserPermissionsDA().GetListByUserID(user.Guid);
            if (_Permissions.Count == 0)
            {
                Alert("未授权，无法访问该系统。");
                return;
            }
            Session["UserPermissions"] = _Permissions;
            Response.Redirect("~/Main/Default.aspx");
            
        }

        protected void Alert(string msg)
        {
            msg = msg.Replace("\"", "&quot;").Replace("'", "&acute;").Replace("\r", "").Replace("\n", ""); ;
            ClientScript.RegisterStartupScript(this.GetType(), "LoginAlert", "<script language='javascript'>$(document).ready(function(){alert('" + msg + "');});</script>");
        
        }
    }
}