using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GDK.Entity.Sys;
using DBUtility;

namespace GDK.DAL.Sys
{
    public class KnowledgeBaseConfigDA:DALBase
    {
        #region 添加
        /// <summary>
        /// 知识库类别新增
        /// </summary>
        /// <param name="Knowledge_TypeName"></param>
        /// <returns></returns>
        public bool Insert(string Knowledge_TypeName)
        {
            string sql = "INSERT INTO T_SYS_KnowledageType(Knowledge_TypeName) VALUES(@Knowledge_TypeName)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Knowledge_TypeName",SqlDbType.NVarChar,35,ParameterDirection.Input,false,0,0,"Knowledge_TypeName",DataRowVersion.Default,Knowledge_TypeName)
            };
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        /// <summary>
        /// 知识库小类新增
        /// </summary>
        /// <param name="Child_TypeName"></param>
        /// <param name="Knowledage_TypeId"></param>
        /// <returns></returns>
        public bool Insert(string Child_TypeName, string Knowledage_TypeId)
        {
            string sql = "INSERT INTO T_SYS_KnowledageChildType(Child_TypeName,Knowledage_TypeId) VALUES(@Child_TypeName,@Knowledage_TypeId)";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Child_TypeName",SqlDbType.NVarChar,35,ParameterDirection.Input,false,0,0,"Child_TypeName",DataRowVersion.Default,Child_TypeName),
                new SqlParameter("@Knowledage_TypeId",SqlDbType.VarChar,36,ParameterDirection.Input,false,0,0,"Knowledage_TypeId",DataRowVersion.Default,Knowledage_TypeId)
            };
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 查询与类别关联的小类
        public DataTable selectAllKnowledgeTypeList(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = @"select BaseType.GUID as TypeID,BaseType.Knowledge_TypeName,ChildType.GUID as ChildTypeId,ChildType.Child_TypeName from T_SYS_KnowledageType BaseType
                            left join T_SYS_KnowledageChildType ChildType on 
                            ChildType.Knowledage_TypeId=BaseType.GUID";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            sql += " order by BaseType.Knowledge_TypeName asc,ChildType.Child_TypeName asc";
            DataTable dt = null;
            int returnC = 0; 
            try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }
        public DataTable selectAllKnowledgeTypeList()
        {
            string sql = @"select distinct * from dbo.T_SYS_KnowledageType order by Knowledge_TypeName asc";
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        /// <summary>
        /// 根据类型ID查找小类
        /// </summary>
        /// <returns></returns>
        public DataTable selectAllChildTypeListByWhere(string strwhere)
        {
            string sql = @"select guid as ID,Knowledage_TypeId,Child_TypeName from T_SYS_KnowledageChildType";
            DataTable dt = null;
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql = string.Format(" {0} where {1}", sql, strwhere);
            }
            sql += " order by Child_TypeName asc";
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
        public DataTable selectAllTypeListByWhere(string strwhere)
        {
            string sql = "select GUID as ID,Knowledge_TypeName from T_SYS_KnowledageType";
            DataTable dt = null;
            if (!string.IsNullOrEmpty(strwhere))
            {
                sql = string.Format(" {0} where {1}", sql, strwhere);
            }
            try
            {
                dt = db.ExecuteQuery(sql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }
       
        #endregion
        #region 编辑类
        public int Update(string id, string name,Boolean state=false)
        {
            SqlParameter[] parameters = null;
            string strSQL = "";
            if (!state)
            {
                strSQL = "UPDATE T_SYS_KnowledageChildType SET Child_TypeName=@Child_TypeName WHERE GUID=@GUID";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Child_TypeName",SqlDbType.NVarChar,35,ParameterDirection.Input,false,0,0,"Child_TypeName",DataRowVersion.Default,name),
                    new SqlParameter("@GUID",SqlDbType.VarChar,36,ParameterDirection.Input,false,0,0,"GUID",DataRowVersion.Default,id)
                };
            }
            else
            {
                strSQL = "UPDATE T_SYS_KnowledageType SET Knowledge_TypeName=@Knowledge_TypeName WHERE GUID=@GUID";
                parameters = new SqlParameter[]
                {
                    new SqlParameter("@Knowledge_TypeName",SqlDbType.NVarChar,35,ParameterDirection.Input,false,0,0,"Knowledge_TypeName",DataRowVersion.Default,name),
                    new SqlParameter("@GUID",SqlDbType.VarChar,36,ParameterDirection.Input,false,0,0,"GUID",DataRowVersion.Default,id)
                };
            }
            return db.ExecuteNoQuery(strSQL, parameters);
        }

        public int UpdateKnowledgeType(string oldType,string newType)
        {
            string sql = "update T_KnowledgeBase set KB_Type = '" + newType + "' where KB_Type = '" + oldType + "'";
            return db.ExecuteNoQuery(sql);
        }

        public int UpdateKnowledgeStype(string newStype, string oldType, string oldStype)
        {
            string sql = "update T_KnowledgeBase set KB_SType = '" + newStype + "' where KB_Type = '" + oldType + "' and KB_SType = '" + oldStype + "'";
            return db.ExecuteNoQuery(sql);
        }

        #endregion

        #region 删除小类
        public int Delete(string id)
        {
            string strSQL = "DELETE T_SYS_KnowledageChildType WHERE GUID=@GUID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GUID",SqlDbType.VarChar,36,ParameterDirection.Input,false,0,0,"GUID",DataRowVersion.Default,id)
            };
            return db.ExecuteNoQuery(strSQL, parameters);
        }
        #endregion

        public int DeleteKnowledgeBaseStype(string type,string stype)
        {
            string strSQL = "update T_KnowledgeBase set KB_STYPE = '' WHERE KB_TYPE = '" + type + "' AND KB_STYPE = '" + stype + "'";
            return db.ExecuteNoQuery(strSQL);
        }

        #region 删除大、小类
        /// <summary>
        /// 删除大类及相应的小类
        /// </summary>
        /// <param name="guid"></param>
        /// <returns></returns>
        public bool DeleteType(string guid)
        {
            List<CommandList> list = new List<CommandList>();
            string str1 = "DELETE from T_SYS_KnowledageType WHERE GUID=@GUID";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@GUID",SqlDbType.VarChar,36,ParameterDirection.Input,false,0,0,"GUID",DataRowVersion.Default,guid)
            };
            CommandList cmd1 = new CommandList();
            cmd1.strCommandText = str1;
            cmd1.Type = CommandType.Text;
            cmd1.Params = parameters;

            string str2 = "DELETE from T_SYS_KnowledageChildType WHERE Knowledage_TypeId=@Knowledage_TypeId";
            SqlParameter[] param = new SqlParameter[]
            {
                new SqlParameter("@Knowledage_TypeId",SqlDbType.VarChar,36,ParameterDirection.Input,false,0,0,"Knowledage_TypeId",DataRowVersion.Default,guid)
            };
            CommandList cmd2 = new CommandList();
            cmd2.strCommandText = str2;
            cmd2.Type = CommandType.Text;
            cmd2.Params = param;
            list.Add(cmd1);
            list.Add(cmd2);

            return db.ExecuteNoQueryTranPro(list);
        }

        public int DelKnowledgeBaseType(string type) {
            string sql = "update T_KnowledgeBase set KB_Type = '',KB_STYPE = '' where KB_Type = '" + type + "'";
            return db.ExecuteNoQuery(sql);
        }
        #endregion
    }
}
