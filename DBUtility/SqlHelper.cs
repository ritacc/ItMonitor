using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DBUtility
{
    /// <summary>
    /// SQL Server 数据库处理类，包括分页方法
    /// </summary>
    public class SqlHelper : DbHelper
    {
        /// <summary>
        /// SqlHelper 构造方法
        /// </summary>
        public SqlHelper()
            : base()
        {

        }

        /// <summary>
        /// SqlHelper 构造方法
        /// </summary>
        /// <param name="name">数据库名</param>
        public SqlHelper(string name)
            : base(name)
        {

        }

        /// <summary>
        /// 分页方法
        /// </summary>
        /// <param name="sql">SQL 脚本</param>
        /// <param name="pageIndex">页索引(从1开始)</param>
        /// <param name="pageSize">分页大小</param>
        /// <param name="recordCurrent">总的纪录行数</param>
        /// <returns>返回查询结果 DataTable</returns>
        public override DataTable ExecuteQuery(string sql, int pageIndex, int pageSize, out int recordCurrent)
        {
            string procedureName = "Spy_Page";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@sql", sql)
                ,new SqlParameter("@PageCurrent", pageIndex)
                ,new SqlParameter("@PageSize", pageSize)
                ,new SqlParameter("@RecordCount", SqlDbType.Int)
            };
            parameters[3].Direction = ParameterDirection.Output;
            DataTable dt = base.ExecuteQueryDataSetProc(procedureName, parameters).Tables[1];
            recordCurrent = Convert.ToInt32(parameters[3].Value);
            return dt;
        }
    }
}
