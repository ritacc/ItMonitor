using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.Sys;
using GDK.Entity.Sys;


using DBUtility;

namespace GDK.BCM.Role
{
    public partial class RoseSet : PageBase
    {
        //GBXTClass.Dal.HCRole m_role = new GBXTClass.Dal.HCRole();
        DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BuildModelsAndPermissions();
                InitPage();
            }
        }

        /*根据Role.sitemap绑定权限列表*/
        private void InitPage()
        {
            if (null == Request.QueryString["guid"])
            {
                Alert("获取参数错误！");
                return;
            }
            string guid = Request.QueryString["guid"];
            dt = new FunctionDA().selectAllDate(guid);
            dt.DefaultView.RowFilter = "MOD_LEVEL=1";
            this.rptMenu0.DataSource = dt.DefaultView;
            this.rptMenu0.DataBind();

        
            RolesOR T_SY = new RolesDA().selectARowDate(guid);
            lblName.Text = T_SY.RoleName;//角色名称
            lblDesc.Text = T_SY.RoleDesc;//角色说明

        }


        protected DataView GetMenuList(object id)
        {
            dt.DefaultView.RowFilter = "PARENT_URL = '" + id.ToString() + "'";
            return dt.DefaultView;
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {
            string guid = Request.QueryString["guid"];
            List<RolePermissionsOR> list = new List<RolePermissionsOR>();
            foreach (RepeaterItem item0 in rptMenu0.Items)
            {
                CheckBox cb0 = item0.FindControl("cb0") as CheckBox;
                if (cb0.Checked)
                {
                    Label lb0 = item0.FindControl("lb0") as Label;
                    RolePermissionsOR permissions0 = new RolePermissionsOR();
                    permissions0.RoleGuid = guid;
                    permissions0.PermissionCode = lb0.Text;
                    list.Add(permissions0);

                    Repeater rptMenu1 = item0.FindControl("rptMenu1") as Repeater;
                    foreach (RepeaterItem item1 in rptMenu1.Items)
                    {
                        CheckBox cb1 = item1.FindControl("cb1") as CheckBox;
                        if (cb1.Checked)
                        {
                            Label lb1 = item1.FindControl("lb1") as Label;
                            RolePermissionsOR permissions1 = new RolePermissionsOR();
                            permissions1.RoleGuid = guid;
                            permissions1.PermissionCode = lb1.Text;
                            list.Add(permissions1);

                            Repeater rptMenu2 = item1.FindControl("rptMenu2") as Repeater;
                            foreach (RepeaterItem item2 in rptMenu2.Items)
                            {
                                CheckBox cb2 = item2.FindControl("cb2") as CheckBox;
                                if (cb2.Checked)
                                {
                                    Label lb2 = item2.FindControl("lb2") as Label;
                                    RolePermissionsOR permissions2 = new RolePermissionsOR();
                                    permissions2.RoleGuid = guid;
                                    permissions2.PermissionCode = lb2.Text;
                                    list.Add(permissions2);
                                }
                            }
                        }
                    }
                }

            }


            foreach (RepeaterItem itemt0 in rptMenut.Items)
            {
                CheckBox cb0 = itemt0.FindControl("cbt0") as CheckBox;
                if (cb0.Checked)
                {
                    Label lb0 = itemt0.FindControl("lbt0") as Label;
                    RolePermissionsOR permissions0 = new RolePermissionsOR();
                    permissions0.RoleGuid = guid;
                    permissions0.PermissionCode = lb0.Text;
                    list.Add(permissions0);

                    Repeater rptMenu1 = itemt0.FindControl("rptMenut1") as Repeater;
                    foreach (RepeaterItem item1 in rptMenu1.Items)
                    {
                        CheckBox cb1 = item1.FindControl("cbt1") as CheckBox;
                        if (cb1.Checked)
                        {
                            Label lb1 = item1.FindControl("lbt1") as Label;
                            RolePermissionsOR permissions1 = new RolePermissionsOR();
                            permissions1.RoleGuid = guid;
                            permissions1.PermissionCode = lb1.Text;
                            list.Add(permissions1);

                            Repeater rptMenu2 = item1.FindControl("rptMenut2") as Repeater;
                            foreach (RepeaterItem item2 in rptMenu2.Items)
                            {
                                CheckBox cb2 = item2.FindControl("cbt2") as CheckBox;
                                if (cb2.Checked)
                                {
                                    Label lb2 = item2.FindControl("lbt2") as Label;
                                    RolePermissionsOR permissions2 = new RolePermissionsOR();
                                    permissions2.RoleGuid = guid;
                                    permissions2.PermissionCode = lb2.Text;
                                    list.Add(permissions2);
                                }
                            }
                        }
                    }
                }

            }

            try
            {
                new RolePermissionsDA().InsertRolePermission(list);
                
            }
            catch (Exception ex)
            {
                base.Alert("设置权限失败.\n\n异常信息:" + ex.Message);
                return;
            }
            Response.Redirect("roleList.aspx");
        }
        
        private void BuildModelsAndPermissions()
        {
            

            // 删除模块表


            
           
            SqlHelper dal = new SqlHelper();
           
        }
    }

}