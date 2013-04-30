using System;
using GDK.Entity.Sys;
using GDK.DAL.Sys;
using System.Data;
using System.Text.RegularExpressions;


namespace GDK.BCM.Sysadmin
{
    public partial class UserEdit : PageBase
    {
        UserOrganizationsDal usrOrgDal = new UserOrganizationsDal();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    dpdRankCode.DataSource = usrOrgDal.GetRankDefine(2);
                    dpdRankCode.DataTextField = "name";
                    dpdRankCode.DataValueField = "code_name";
                    dpdRankCode.DataBind();

                    if (Request.QueryString["opType"].ToString() == "alert")
                    {
                        loadData();
                    }
                    else
                    {

                        txtEndTime.Text = DateTime.Now.AddYears(2).ToString("yyyy-MM-dd");
                    }
                    if (null != Request.QueryString["parentGUID"])
                    {
                        lblAllpath.Text = usrOrgDal.GetOgrAllPath(Request.QueryString["parentGUID"].ToString());
                    }
                    txtDisplayName.Focus();
                }
            }
            catch (Exception ex) {
                base.Close("ok");
            }
        }

        private void loadData()
        {
            try
            {
                string m_id = Request.QueryString["GUID"].ToString();
                UsersOR m_User = usrOrgDal.selectSingleUserByID(m_id);
                if (m_User == null)
                {
                    base.Alert("用户不在存！");
                    return;
                }

                txtDisplayName.Text = m_User.DisplayName;//用户的显示名称

                txtAllPathName.Text = m_User.AllPathName;//用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）

                txtRankName.Text = m_User.RankName;//用户在该部门中的职位
                txtDescription.Text = m_User.Description;//用户的附加描述信息
                txtStartTime.Text = Convert.ToDateTime(m_User.StartTime).ToString("yyyy-MM-dd");//关系启用时间
                txtEndTime.Text = Convert.ToDateTime(m_User.EndTime).ToString("yyyy-MM-dd");//关系结束时间
                txtLogonName.Text = m_User.LogonName;//用户的登录名称
                txtIcCard.Text = m_User.IcCard;//用户的IC卡号
                //txtPwdTypeGuid.Text = m_User.PWD_TYPE_GUID;//使用密码的加密算法
                txtUserPwd.Attributes["value"] = m_User.UserPwd; ;
                //txtUserPwd.Text = //用户所使用的密码（加密存储）
                dpdRankCode.Text = m_User.RankCode;//用户本身的级别信息数据
                txtEMail.Text = m_User.EMail;//用户默认使用的EMAIL
                //txtPostural.Text = m_User.Postural.ToString();//用户的在系统中的状态（1、禁用状态；2、要求下次登录修改密码；4、正常使用；）掩码方式实现
                // txtCreateTime.Text = Convert.ToDateTime(m_User.CreateTime).ToString("yyyy-MM-dd");//创建时间
                //txtModifyTime.Text = m_User.;//最近修改时间
                //txtAdCount.Text = m_User.AdCount.ToString();//是否在AD中建立对应的账号
                txtPersonId.Text = m_User.PersonId;//海关人员编码
            }
            catch (Exception e) {
                base.Close("ok");
            }
        }

        private UsersOR setValue()
        {
            UsersOR m_User = new UsersOR();
            if (Request.QueryString["GUID"] == null)
            {
                m_User.Guid = Guid.NewGuid().ToString();

            }
            else
            {
                string m_id = Request.QueryString["GUID"].ToString();
                m_User.Guid = m_id;
            }

            //if (Request.QueryString["opType"].ToString() == "alert")
            //    m_User.GUID = txtGuid.Text;//用户身份标志ID
            m_User.ParentGuid = Request.QueryString["parentGUID"].ToString();//所在部门的标志ID
            m_User.DisplayName = txtDisplayName.Text;//用户的显示名称
            //m_User.InnerSort = txtInnerSort.Text;//用户在部门中的排序
            //m_User.OriginalSort = txtOriginalSort.Text;//用户在系统中的全地址（不用于排序，仅仅标志所在部门的路径关系）
            m_User.AllPathName = txtAllPathName.Text;//用户在系统中的全程文字表述（例如：全国海关\海关总署\信息中心\应用开发二处\朱佳炜）
            m_User.Status = 1;// int.Parse(txtStatus.Text);//状态（1、正常使用；2、直接逻辑删除；4、机构级联逻辑删除；8、人员级联逻辑删除；）掩码方式实现
            m_User.RankName = txtRankName.Text;//用户在该部门中的职位
            m_User.Description = txtDescription.Text;//用户的附加描述信息
            m_User.StartTime = txtStartTime.Text;//关系启用时间
            m_User.EndTime = txtEndTime.Text;//关系结束时间
            m_User.LogonName = txtLogonName.Text;//用户的登录名称
            m_User.IcCard = txtIcCard.Text;//用户的IC卡号

            m_User.UserPwd = txtUserPwd.Text;//用户所使用的密码（加密存储）
            m_User.RankCode = dpdRankCode.Text;//行政级别信息数据
            m_User.EMail = txtEMail.Text;//用户默认使用的EMAIL
            //m_User.POSTURAL = int.Parse(txtPostural.Text);//用户的在系统中的状态（1、禁用状态；2、要求下次登录修改密码；4、正常使用；）掩码方式实现
            //m_User. = DateTime.Parse(txtCreateTime.Text);//创建时间
            //m_User.MODIFY_TIME = DateTime.Now;//.Parse(txtModifyTime.Text);//最近修改时间
            // m_User.AdCount = int.Parse(txtAdCount.Text);//是否在AD中建立对应的账号
            m_User.PersonId = txtPersonId.Text;//海关人员编码


            return m_User;
        }
        protected void lbtSave_Click(object sender, EventArgs e)
        {
            UsersOR affe = setValue();
            if (!IsIcCard(txtIcCard.Text))
            {
                Alert("IC卡号不能含中文！");
                return;
            }
            else if (txtEMail.Text.Trim().Length > 0 && !IsEmail(txtEMail.Text))
            {
                Alert("邮箱格式错误！");
                return;
            }
            if (Request.QueryString["opType"].ToString() == "add")
            {
                try
                {
                    if (Request["parentGUID"] != null)
                    {
                        DataTable dt = usrOrgDal.GetAllUsers();
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (txtLogonName.Text.Trim().ToLower() == dt.Rows[i]["LOGON_NAME"].ToString().Trim().ToLower())
                                {
                                    Alert("该登录名已存在！");
                                    return;
                                }
                            }
                        }
                    }
                    usrOrgDal.insertUser(affe);
                  
                }
                catch (Exception ex)
                {
                    base.Alert("添加用户出错！");
                    return;
                }
            }
            else if (Request.QueryString["opType"].ToString() == "alert")
            {
                try
                {
                    if (Request["parentGUID"] != null)
                    {
                        DataTable dt = usrOrgDal.GetUsersWithoutSelf(Request["GUID"].ToString());
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                if (txtLogonName.Text.Trim().ToLower() == dt.Rows[i]["LOGON_NAME"].ToString().Trim().ToLower())
                                {
                                    Alert("该登录名已存在！");
                                    return;
                                }
                            }
                        }
                    }
                    affe.Guid = Request.QueryString["GUID"].ToString();
                    usrOrgDal.updateUsers(affe, affe.Guid);
                   
                }
                catch (Exception ex)
                {
                    base.Alert("修改出错！");
                    return;
                }

            }
            base.Close("tr");
        }

        /// <summary>
        /// 判断IC卡是否含有中文
        /// </summary>
        /// <param name="icCard"></param>
        /// <returns></returns>
        private bool IsIcCard(string icCard)
        {
            bool chkResult = true;
            if (icCard.Trim().Length > 0)
            {
                int strLen = icCard.Trim().Length;
                int bytLeng = System.Text.Encoding.UTF8.GetBytes(icCard).Length;

                if(strLen < bytLeng)
                {
                    chkResult = false;
                }
            }
            return chkResult;
        }

        private bool IsEmail(string email)
        {
            Regex reg = new Regex(@"^[a-zA-Z0-9_]+([-+.][a-zA-Z0-9_]+)*@[a-zA-Z0-9_]+([-.][a-zA-Z0-9_]+)*\.[a-zA-Z0-9_]+([-.][a-zA-Z0-9_]+)*$");        
            if(!reg.IsMatch(email))
            {
                return false;
            }
            return true;
        }
    }
}