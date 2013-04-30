using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GDK.Entity.Sys;
using GDK.DAL.Sys;
using System.Data;
using GDK.Entity;
using System.Web.UI.HtmlControls;
using System.Text;


namespace GDK.BCM.Role
{
    public partial class RoleEdit : PageBase
    {
        
        ControlCommon com = new ControlCommon();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    loadData();
                    txtName.Focus();
                }
                catch (Exception ex)
                {
                    base.Alert(ex.Message);
                }
            }
        }

        private void loadData()
        {
            try
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    RolesOR T_SY = new RolesDA().selectARowDate(id);
                    txtName.Text = T_SY.RoleName;//角色名称
                    txtROLE_DESC.Text = T_SY.RoleDesc;//角色说明
                }
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }


        private RolesOR setValue()
        {
            RolesOR T_SY = new RolesOR();
            if (Request.QueryString["id"] != null)
                T_SY.Guid = Request.QueryString["id"].ToString();
            T_SY.RoleName = txtName.Text;//角色名称
            T_SY.RoleDesc = txtROLE_DESC.Text;//角色说明
            return T_SY;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            RolesOR cg = setValue();
            RolesDA carClassAdin = new RolesDA();
            
            
            try
            {
                if (Request.QueryString["opType"] == null)
                {
                    DataTable dt = carClassAdin.SelectAllRoles();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Role_Name"].ToString().Trim().ToLower() == txtName.Text.Trim().ToLower())
                        {
                            Alert("该角色已存在！");
                            return;
                        }
                    }
                        carClassAdin.Insert(cg);
                       
                }
                else if (Request.QueryString["opType"].ToString() == "alert")
                {
                    RolesOR or = new RolesDA().selectARowDate(Request["id"].ToString());
                    DataTable dt = carClassAdin.SelectRolesWithoutSelf(or.RoleName);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["Role_Name"].ToString().Trim().ToLower() == txtName.Text.Trim().ToLower())
                        {
                            Alert("该角色已存在！");
                            return;
                        }
                    }
                        carClassAdin.Update(cg);
                        
                }
                base.Close(true);
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }


    }
}