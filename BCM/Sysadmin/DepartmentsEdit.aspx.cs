using System;
using GDK.Entity.Sys;
using GDK.DAL.Sys;
using System.Data;


namespace GDK.BCM.Sysadmin
{
    public partial class DepartmentsEdit : PageBase
    {
        UserOrganizationsDal usrOrgDal = new UserOrganizationsDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    dpdRankCode.DataSource = usrOrgDal.GetRankDefine(1);
                    dpdRankCode.DataTextField = "name";
                    dpdRankCode.DataValueField = "code_name";
                    dpdRankCode.DataBind();

                    if (Request.QueryString["opType"].ToString() == "alert")
                    {
                        loadData();
                    }

                    if (null != Request.QueryString["parentGUID"])
                    {
                        lblAllpath.Text = usrOrgDal.GetOgrAllPath(Request.QueryString["parentGUID"].ToString());
                    }
                    txtDisplayName.Focus();
                }
            }
            catch (Exception ex) {
                Alert(ex);
            }
        }
        private void loadData()
        {
            try
            {
                string m_id = Request.QueryString["GUID"].ToString();
                OrganizationsOR m_Orga = usrOrgDal.selectSingleOrganization(m_id);
                txtDisplayName.Text = m_Orga.DisplayName;//显示名称
                //txtObjName.Text = m_Orga.ObjName;//对象名称（部门内唯一）
                txtCustomsCode.Text = m_Orga.CustomsCode;//关区代码

                //txtParentGuid.Text = m_Orga.ParentGuid;//父部门的标志ID（注：树结构中第一个节点没有值）

                dpdRankCode.Text = m_Orga.RankCode;//机构的行政级别信息数据
                //txtInnerSort.Text = m_Orga.InnerSort;//部门内部排序号
                //txtOriginalSort.Text = m_Orga.OriginalSort;//在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
                // txtGlobalSort.Text = m_Orga.GlobalSort;//用户在部门中的全地址（用于全国大排序）
                txtAllPathName.Text = m_Orga.AllPathName;//用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处）
                dplOrgClass.Text = m_Orga.OrgClass.ToString();//部门的一些特殊属性（1总署、2分署、4特派办、8直属、16院校、32隶属海关、64派驻机构）采用掩码实现
                dplOrgType.Text = m_Orga.OrgType.ToString();//部门的一些特殊属性（1虚拟机构、2一般部门、4办公室（厅）、8综合处）采用掩码实现
                //txtChildrenCounter.Text = m_Orga.ChildrenCounter.ToString();//记录部门内部使用的最大号值（记录值为下一个可使用值，从0开始）
                //txtStatus.Text = m_Orga.Status.ToString();//状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现

                txtDescription.Text = m_Orga.Description;//附加说明信息
                //txtCreateTime.Text = Convert.ToDateTime(m_Orga.CreateTime).ToString("yyyy-MM-dd");//创建时间
            }
            catch (Exception e) {
                Alert(e);
            }

        }

        private OrganizationsOR setValue()
        {

            OrganizationsOR m_Orga = new OrganizationsOR();
            if (Request.QueryString["opType"].ToString() == "alert")
                m_Orga.Guid = Request.QueryString["GUID"].ToString();
            else
                m_Orga.Guid = Guid.NewGuid().ToString();
            m_Orga.ObjName=m_Orga.DisplayName = txtDisplayName.Text;//显示名称
            //m_Orga.ObjName = txtObjName.Text;//对象名称（部门内唯一）
            m_Orga.CustomsCode = txtCustomsCode.Text;//关区代码
            m_Orga.ParentGuid = Request.QueryString["parentGUID"].ToString();//父部门的标志ID（注：树结构中第一个节点没有值）

            m_Orga.RankCode = dpdRankCode.Text;//机构的行政级别信息数据

            m_Orga.AllPathName = txtAllPathName.Text;//用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处）
            m_Orga.OrgClass = int.Parse(dplOrgClass.SelectedValue);//部门的一些特殊属性（1总署、2分署、4特派办、8直属、16院校、32隶属海关、64派驻机构）采用掩码实现
            m_Orga.OrgType = int.Parse(dplOrgType.SelectedValue);//部门的一些特殊属性（1虚拟机构、2一般部门、4办公室（厅）、8综合处）采用掩码实现
            m_Orga.Status = 1;// int.Parse(txtStatus.Text);//状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现

            m_Orga.Description = txtDescription.Text;//附加说明信息
            //m_Orga.CreateTime = DateTime.Now;//创建时间
            //m_Orga.ModifyTime = DateTime.Now;//最近修改时间
            return m_Orga;
        }
        protected void lbtSave_Click(object sender, EventArgs e)
        {
            
            OrganizationsOR affe = setValue();
            if (Request.QueryString["opType"].ToString() == "add")
            {
                try
                {
                    if (Request["parentGUID"] != null)
                    {
                        DataTable dt = usrOrgDal.GetOrgByParentID(Request["parentGUID"]);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (txtDisplayName.Text.Trim().ToLower() == dt.Rows[i]["OBJ_NAME"].ToString().ToLower())
                                {
                                    Alert("该机构已存在！");
                                    return;
                                }
                            }
                        }
                    }
                    usrOrgDal.InsertOrganizations(affe);
                    
                }
                catch (Exception ex)
                {
                    base.Alert(ex.Message);
                    return;
                }
            }
            else if (Request.QueryString["opType"].ToString() == "alert")
            {
                try
                {
                    if (Request["parentGUID"] != null)
                    {
                        string orgName = usrOrgDal.selectSingleOrganization(Request["GUID"]).ObjName;
                        DataTable dt = usrOrgDal.GetOrgWithoutSelf(Request["parentGUID"], orgName);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (txtDisplayName.Text.Trim().ToLower() == dt.Rows[i]["OBJ_NAME"].ToString().ToLower())
                                {
                                    Alert("该机构已存在！");
                                    return;
                                }
                            }
                        }
                    }
                    usrOrgDal.updateOrg(affe, Request.QueryString["GUID"].ToString());
                    
                }
                catch (Exception ex)
                {
                    base.Alert(ex.Message);
                    return;
                }
            }

            base.Close("tr");
        }
    }
}