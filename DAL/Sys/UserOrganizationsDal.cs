using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using GDK.Entity.Sys;
using System.Data.SqlClient;

namespace GDK.DAL.Sys
{
    public class UserOrganizationsDal : DALBase
    {
        #region public
        private string getOrgSort(int counter)
        {
            string returnValue = "00000";
            switch (counter.ToString().Length)
            {
                case 1:
                    returnValue = "00000" + counter.ToString();
                    break;
                case 2:
                    returnValue = "0000" + counter.ToString();
                    break;
                case 3:
                    returnValue = "000" + counter.ToString();
                    break;
                case 4:
                    returnValue = "00" + counter.ToString();
                    break;
                case 5:
                    returnValue = "0" + counter.ToString();
                    break;
                case 6:
                    returnValue = counter.ToString();
                    break;
            }
            return returnValue;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="RANK_CLASS">1��ʾ����,2��ʾ��Ա����</param>
        /// <returns></returns>
        public DataTable GetRankDefine(int RANK_CLASS)
        {
            string sql = string.Format("select * from RANK_DEFINE where RANK_CLASS={0}  order by sort_id", RANK_CLASS);
            return db.ExecuteQuery(sql);
        }

        #endregion
        #region Organization
        public DataTable GetOrgTop()
       {
           string sql = "select * from T_SYS_Organizations where PARENT_GUID is null or PARENT_GUID=''";
            return db.ExecuteQuery(sql);
                
       }

       public OrganizationsOR selectSingleOrganization(string m_ID)
       {

           string sql = string.Format("select * from T_SYS_Organizations where Guid='{0}'", m_ID);
           DataTable dt = null;
           try
           {
               dt = db.ExecuteQueryDataSet(sql).Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;
           }
           if (dt == null)
               return null;
           if (dt.Rows.Count == 0)
               return null;
           DataRow dr = dt.Rows[0];
           OrganizationsOR m_Orga = new OrganizationsOR(dr);
           return m_Orga;
       }



       public DataTable GetOrgByParentID(string parentGuid)
       {
           string sql = string.Format("select * from T_SYS_Organizations where PARENT_GUID='{0}' order by INNER_SORT", parentGuid);
           return db.ExecuteQuery(sql);
       }

       public DataTable GetAllUsers()
       {
           string sql = string.Format("select * from T_SYS_Users");
           return db.ExecuteQuery(sql);
       }

       public DataTable GetOrgWithoutSelf(string parentGuid,string orgName)
       {
           string sql = string.Format("select * from T_SYS_Organizations where PARENT_GUID='{0}' and OBJ_NAME != '{1}' order by INNER_SORT", parentGuid, orgName.Trim().ToLower());
           return db.ExecuteQuery(sql);
       }

        /// <summary>
        /// ��ѯֱ�����ػ�ְ�ܴ���
        /// </summary>
        /// <returns></returns>
        public DataTable GetHeadOrganization()
        {
           DataTable dt= GetOrgTop();

           if (dt == null || dt.Rows.Count == 0)
               throw new Exception("��ѯ�������ʧ�ܣ� ");

            dt= GetOrgByParentID(dt.Rows[0]["Guid"].ToString());
            return GetOrgByParentID(dt.Rows[0]["Guid"].ToString());
        }




        public void InsertOrganizations(OrganizationsOR obj)
        {
            OrganizationsOR orgparent = selectSingleOrganization(obj.ParentGuid);
            DataTable dtOrg = GetOrgByParentID(obj.ParentGuid);

            int counter = (dtOrg == null ? 0 : dtOrg.Rows.Count);

            bool sortIsExis = true;
            while (sortIsExis)
            {

                obj.InnerSort = getOrgSort(++counter);//�����ڲ������
                sortIsExis = OrgSortIsExis(obj.InnerSort, obj.ParentGuid);
            }
            obj.OriginalSort = orgparent.OriginalSort + obj.InnerSort;//��ϵͳ�е�ȫ��ַ�����������򣬽�����־���ڲ��ŵ�·����ϵ��
            obj.GlobalSort = obj.OriginalSort;//�û��ڲ����е�ȫ��ַ������ȫ��������
            obj.ChildrenCounter = counter++;//��¼�����ڲ�ʹ�õ�����ֵ����¼ֵΪ��һ����ʹ��ֵ����0��ʼ��
 
            insertOrg(obj);
            
        }

        #region ����
        /// <summary>
        /// ����T_SYS_Organizations
        /// </summary>
        public bool insertOrg(OrganizationsOR T_SY)
        {
            string sql = string.Format(@" insert into T_SYS_Organizations (GUID,DISPLAY_NAME,OBJ_NAME,PARENT_GUID,RANK_CODE,INNER_SORT,ORIGINAL_SORT,GLOBAL_SORT,ALL_PATH_NAME,ORG_CLASS,ORG_TYPE,CHILDREN_COUNTER,STATUS,CUSTOMS_CODE,DESCRIPTION,CREATE_TIME,MODIFY_TIME)
 values(newid(),'{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}',((0)),((1)),'{10}','{11}',(getdate()),(getdate()))"
            ,  T_SY.DisplayName, T_SY.ObjName, T_SY.ParentGuid, T_SY.RankCode,T_SY.InnerSort,T_SY.OriginalSort, T_SY.GlobalSort,T_SY.AllPathName,T_SY.OrgClass,T_SY.OrgType, T_SY.CustomsCode, T_SY.Description);
            try
            {
                db.ExecuteNoQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

        #endregion


        public bool OrgSortIsExis(string strSort, string parentGuid)
       {
            string sql=string.Format("select * from T_SYS_Organizations where  INNER_SORT='{0}' and PARENT_GUID='{1}'",strSort,parentGuid);
            DataTable dt = db.ExecuteQuery(sql);
           return dt.Rows.Count > 0;
       }

        public void UpdateOrganizations(OrganizationsOR obj, string m_ID)
       {
            /*
           var v = from f in db.T_SYS_Organizations where f.GUID == m_ID select f;
           if (v.Count() == 0)
               throw new Exception("���󲻴��ڣ�");
           T_SYS_Organizations objNew = v.Single();

           objNew.DISPLAY_NAME = obj.DISPLAY_NAME;		//��ʾ����
           objNew.OBJ_NAME = obj.OBJ_NAME;		//�������ƣ�������Ψһ��
           objNew.RANK_CODE = obj.RANK_CODE;		//����������������Ϣ����
           objNew.ALL_PATH_NAME = obj.ALL_PATH_NAME;		//�û���ϵͳ�е�ȫ�����ֱ��������磺ȫ������\��������\��Ϣ����\Ӧ�ÿ���������
           objNew.ORG_CLASS = obj.ORG_CLASS;		//���ŵ�һЩ�������ԣ�1����2����4���ɰ졢8ֱ����16ԺУ��32�������ء�64��פ��������������ʵ��
           objNew.ORG_TYPE = obj.ORG_TYPE;		//���ŵ�һЩ�������ԣ�1���������2һ�㲿�š�4�칫�ң�������8�ۺϴ�����������ʵ��
           objNew.CUSTOMS_CODE = obj.CUSTOMS_CODE;		//��������
           objNew.DESCRIPTION = obj.DESCRIPTION;		//����˵����Ϣ
           objNew.MODIFY_TIME = DateTime.Now;		//����޸�ʱ��
           db.SubmitChanges();
             * */
       }
        public bool updateOrg(OrganizationsOR T_SY, string m_id)
        {
            string sql = string.Format(@" update T_SYS_Organizations set DISPLAY_NAME='{0}',OBJ_NAME='{1}',RANK_CODE='{2}',ALL_PATH_NAME='{3}',ORG_CLASS={4},ORG_TYPE={5},CHILDREN_COUNTER={6},STATUS={7},CUSTOMS_CODE='{8}',DESCRIPTION='{9}',MODIFY_TIME=getDate() where GUID='{10}'"
            , T_SY.DisplayName, T_SY.ObjName,T_SY.RankCode, T_SY.AllPathName, T_SY.OrgClass, T_SY.OrgType, T_SY.ChildrenCounter, T_SY.Status, T_SY.CustomsCode, T_SY.Description,m_id);
            try
            {
                db.ExecuteNoQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }

        public void DeleteOrganizations(string m_ID)
       {
           string sql = string.Format("delete T_SYS_Organizations where guid='{0}'", m_ID);
           db.ExecuteNoQuery(sql);
       }

       
        public DataTable GetOrgUserListByParentID(string strGuid)
        {
            string sql = string.Format(@"select * from (
select guid,display_name,r.[name] as Rank_Code,'org' as dataType,description,'' EnableTime from T_SYS_Organizations  org
inner join RANK_DEFINE r on r.code_name=org.rank_Code 
where parent_GUID='{0}' 
union
select GUID,DisPlay_name,ru.[name] as rank_Code,'user' as dataType,description,
convert(varchar(10),START_TIME,120)+'��'+convert(varchar(10),END_TIME,120) as EnableTime from T_SYS_USERS u
inner join RANK_DEFINE ru on ru.code_name=u.rank_Code 
where u.parent_GUID='{0}' 
) as ug
order by dataType,display_name", strGuid);
            return db.ExecuteQuery(sql);
        }
      


        public string GetOgrAllPath(string Guid)
       {
           string sql = string.Format("select ALL_PATH_NAME from T_SYS_Organizations where guid='{0}'", Guid);
            try
            {
                object obj = db.ExecuteScalar(sql);
               return obj.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
       }
        #endregion


        #region User

        public UsersOR selectSingleUser(string m_ID)
       {
           string sql = string.Format("select * from T_SYS_USERS where LOGON_NAME='{0}'", m_ID);
           DataTable dt = null;
           try
           {
               dt = db.ExecuteQuery(sql);
           }
           catch (Exception ex)
           {
               throw ex;
           }
           if (dt == null)
               return null;
           if (dt.Rows.Count == 0)
               return null;
           DataRow dr = dt.Rows[0];
           UsersOR m_User = new UsersOR(dr);
           return m_User;
       }

        public UsersOR selectSingleUserByID(string m_ID)
        {
            string sql = string.Format("select * from T_SYS_USERS where GUID='{0}'", m_ID);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            UsersOR m_User = new UsersOR(dr);
            return m_User;
        }

        public DataTable GetUsersByParentID(string m_ID)
       {
            string sql=string.Format("select * from T_SYS_USERS where PARENT_GUID='{0}'",m_ID);
            return db.ExecuteQuery(sql);
       }

        public DataTable GetUsersWithoutSelf(string m_ID)
        {
            string sql = string.Format("select * from T_SYS_USERS where GUID !='{0}' ", m_ID);
            return db.ExecuteQuery(sql);
        }

        /// <summary>
        /// 2012-3-1ct�޸�
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public DataTable GetUserInfoByGuid(string guid)
        {
            string sql = string.Format("select * from T_SYS_USERS where GUID='{0}'",guid);
            return db.ExecuteQuery(sql);
        }

        public bool UserSortIsExis(string strSort, string parentGuid)
        {
            string sql = string.Format("select * from T_SYS_USERS INNER_SORT='{0}' and PARENT_GUID='{1}'", strSort, parentGuid);
            DataTable dt = db.ExecuteQuery(sql);
            if (dt == null)
            {
                throw new Exception("��ѯ����ʧ�ܣ�");
            }
            return dt.Rows.Count>0;
        }

        public void insertUser(UsersOR obj)
        {
            OrganizationsOR orgparent = selectSingleOrganization(obj.ParentGuid);
            DataTable dtUser = GetUsersByParentID(obj.ParentGuid);

            int counter = (dtUser == null ? 0 : dtUser.Rows.Count);

            bool sortIsExis = true;
            while (sortIsExis)
            {

                obj.InnerSort = getOrgSort(++counter);//�����ڲ������
                sortIsExis = OrgSortIsExis(obj.InnerSort, obj.ParentGuid);
            }
            obj.OriginalSort = orgparent.OriginalSort + obj.InnerSort;//��ϵͳ�е�ȫ��ַ�����������򣬽�����־���ڲ��ŵ�·����ϵ��
            insertU(obj);
            

        }
      /// ����T_SYS_USERS
		/// </summary>
        public bool insertU(UsersOR T_SY)
        {

            string sql = string.Format(@" insert into T_SYS_USERS (GUID,PARENT_GUID,DISPLAY_NAME,INNER_SORT,ORIGINAL_SORT,ALL_PATH_NAME,STATUS,RANK_NAME,DESCRIPTION,START_TIME,END_TIME,LOGON_NAME,IC_CARD,PWD_TYPE_GUID,USER_PWD,RANK_CODE,E_MAIL,POSTURAL,CREATE_TIME,MODIFY_TIME,AD_COUNT,PERSON_ID)
 values(newid(),'{0}','{1}','{2}','{3}','{4}',1,'{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}',getdate(),getdate(),'{16}','{17}')"
  , T_SY.ParentGuid, T_SY.DisplayName, T_SY.InnerSort, T_SY.OriginalSort, T_SY.AllPathName, T_SY.RankName, T_SY.Description, T_SY.StartTime.ToString(), T_SY.EndTime.ToString(), T_SY.LogonName, T_SY.IcCard, T_SY.PwdTypeGuid, T_SY.UserPwd, T_SY.RankCode, T_SY.EMail, T_SY.Postural, T_SY.AdCount, T_SY.PersonId);
            try
            {
                db.ExecuteNoQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;

        }

		#endregion
        public void updateUsers(UsersOR obj, string m_id)
        {
           
            updateUser(obj, m_id);
        }
		#region �޸�
		/// <summary>
		/// ����T_SYS_USERS
		/// </summary>
        public bool updateUser(UsersOR T_SY, string m_id)
        {
            string sql = string.Format(@" update T_SYS_USERS set DISPLAY_NAME='{0}',ALL_PATH_NAME='{1}',RANK_NAME='{2}',DESCRIPTION='{3}',START_TIME='{4}',END_TIME='{5}',LOGON_NAME='{6}',IC_CARD='{7}',PWD_TYPE_GUID='{8}',USER_PWD='{9}',RANK_CODE='{10}',E_MAIL='{11}',POSTURAL={12},MODIFY_TIME=getdate(),AD_COUNT={13},PERSON_ID='{14}' where GUID='{15}'"
 , T_SY.DisplayName, T_SY.AllPathName, T_SY.RankName, T_SY.Description, T_SY.StartTime.ToString(), T_SY.EndTime.ToString(), T_SY.LogonName, T_SY.IcCard, T_SY.PwdTypeGuid, T_SY.UserPwd, T_SY.RankCode, T_SY.EMail, T_SY.Postural, T_SY.AdCount, T_SY.PersonId, m_id);
            try
            {
                db.ExecuteNoQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return true;
        }



        public void DeleteUser(string m_GUID)
       {
            string sql=string.Format("delete T_SYS_USERS where guid='{0}'",m_GUID);
            db.ExecuteNoQuery(sql);
       }
       
        #endregion

    }
}
