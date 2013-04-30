using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OracleClient;

namespace DBUtility
{
    /// <summary>
    /// Oracle 数据库处理类，包括分页方法
    /// </summary>
    public class OracleHelper : DbHelper
    {
        /// <summary>
        /// OracleHelper 构造方法
        /// </summary>
        public OracleHelper()
            : base()
        {

        }

        /// <summary>
        /// OracleHelper 构造方法
        /// </summary>
        /// <param name="name"></param>
        public OracleHelper(string name)
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
            OracleParameter[] parameters = new OracleParameter[]
            {
                new OracleParameter("v_sql", sql)
                ,new OracleParameter("v_pageindex", pageIndex)
                ,new OracleParameter("v_pagesize", pageSize)
                ,new OracleParameter("v_recordcount", OracleType.Number)
                ,new OracleParameter("v_table_cursor", OracleType.Cursor)
            };
            parameters[3].Direction = ParameterDirection.Output;
            parameters[4].Direction = ParameterDirection.Output;
            DataTable dt = base.ExecuteQueryProc(procedureName, parameters);
            recordCurrent = Convert.ToInt32(parameters[3].Value);
            return dt;
        }
    }
}
