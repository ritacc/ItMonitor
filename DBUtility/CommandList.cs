using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DBUtility
{
    /// <summary>
    /// SQL 脚本列表
    /// </summary>
    public class CommandList
    {
        private string _strCommandText;
        /// <summary>
        /// SQL 脚本
        /// </summary>
        public string strCommandText
        {
            get { return _strCommandText; }
            set { _strCommandText = value; }
        }

        private CommandType _Type;
        /// <summary>
        /// 命令类型
        /// </summary>
        public CommandType Type
        {
            get
            {
                return _Type;
            }
            set { _Type = value; }
        }


        private SqlParameter[] _Params;
        /// <summary>
        /// 参数数组
        /// </summary>
        public SqlParameter[] Params
        {
            get { return _Params; }
            set { _Params = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="m_type"></param>
        /// <param name="strParams"></param>
        public CommandList(string strSql, CommandType m_type, SqlParameter[] strParams)
        {
            _strCommandText = strSql;
            _Type = m_type;
            _Params = strParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="strParams"></param>
        public CommandList(string strSql, SqlParameter[] strParams)
        {
            _strCommandText = strSql;
            _Type = CommandType.Text;
            _Params = strParams;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strSql"></param>
        public CommandList(string strSql)
        {
            _strCommandText = strSql;
            _Type = CommandType.Text;
        }

        /// <summary>
        /// 
        /// </summary>
        public CommandList()
        {
        }
    }
}
