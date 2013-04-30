using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace DBUtility
{
    /// <summary>
    /// 数据库处理类
    /// </summary>
    public abstract class DbHelper : IDisposable
    {
        #region 构造函数

        /// <summary>
        /// 数据库名称
        /// </summary>
        private string _name = string.Empty;

        /// <summary>
        /// 构造函数
        /// </summary>
        public DbHelper()
        {

        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="name">数据库名称</param>
        public DbHelper(string name)
        {
            _name = name;
        }

        #endregion

        #region 数据库操作

        /**/
        /// <summary>
        /// 连接超时时间.
        /// </summary>
        private readonly static int TimeOut = 1000;

        /// <summary>
        /// 属性DbDataAdapter
        /// </summary>
        private DbCommand _cmd;

        /// <summary>
        /// 属性DbDataAdapter
        /// </summary>
        private DbDataAdapter _da;

        /// <summary>
        /// 属性IDbTransaction
        /// </summary>
        private DbTransaction _tran;

        private Database GetDataBase()
        {
            if (string.IsNullOrEmpty(_name))
            {
                return DatabaseFactory.CreateDatabase();
            }
            return DatabaseFactory.CreateDatabase(_name);
        }

        /// <summary>
        /// 断开连接
        /// </summary>
        private void Disconnect()
        {
            if (null != _cmd)
            {
                if (_cmd.Connection.State == ConnectionState.Open)
                {
                    _cmd.Connection.Close();
                }
                _cmd.Dispose();
                _cmd = null;
            }

            if (null != _da)
            {
                _da.Dispose();
                _da = null;
            }

            if (null != _tran)
            {
                _tran.Dispose();
                _tran = null;
            }
        }

        /// <summary>
        /// 执行查询 SQL 脚本返回DataTable
        /// </summary>
        /// <param name="strCmdText">查询SQL 脚本</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQuery(string strCmdText)
        {
            return ExecuteQuery(strCmdText, CommandType.Text);
        }

        /// <summary>
        /// 执行查询 存储过程 脚本返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryProc(string strCmdText)
        {
            return ExecuteQuery(strCmdText, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行查询操作 返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string strCmdText, CommandType commandType)
        {
            DataTable dt = new DataTable();
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return dt;
        }


        /// <summary>
        /// 执行查询 SQL 脚本返回DataSet
        /// </summary>
        /// <param name="strCmdText">查询SQL 脚本</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteQueryDataSet(string strCmdText)
        {
            return ExecuteQueryDataSet(strCmdText, CommandType.Text);
        }

        /// <summary>
        /// 执行查询 存储过程 脚本返回DataSet
        /// </summary>
        /// <param name="strCmdText">查询SQL 脚本</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteQueryDataSetProc(string strCmdText)
        {
            return ExecuteQueryDataSet(strCmdText, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行查询操作 返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet(string strCmdText, CommandType commandType)
        {
            DataSet ds = new DataSet();
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return ds;
        }

        /// <summary>
        /// 执行查询 SQL 脚本返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText">查询SQL 脚本</param>
        /// <returns>DataTable</returns>
        public object ExecuteScalar(string strCmdText)
        {
            return ExecuteScalar(strCmdText, CommandType.Text);
        }

        /// <summary>
        /// 执行查询 存储过程 返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText">查询SQL 脚本</param>
        /// <returns>DataTable</returns>
        public object ExecuteScalarProc(string strCmdText)
        {
            return ExecuteScalar(strCmdText, CommandType.StoredProcedure);
        }


        /// <summary>
        /// 执行查询操作 返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strCmdText, CommandType commandType)
        {
            object oResult;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                oResult = db.ExecuteScalar(_cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return oResult;
        }

        /// <summary>
        /// 执行查询 SQL 语句 返回DataTable
        /// </summary>
        /// <param name="strCmdText">存储过程名称</param>
        /// <param name="arg0">参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQuery(string strCmdText, DbParameter arg0)
        {
            return ExecuteQuery(strCmdText, arg0, CommandType.Text);
        }

        /// <summary>
        /// 执行查询 存储过程 返回DataTable
        /// </summary>
        /// <param name="strCmdText">存储过程名称</param>
        /// <param name="arg0">参数</param>
        /// <returns>DataTable</returns>
        public DataTable ExecuteQueryProc(string strCmdText, DbParameter arg0)
        {
            return ExecuteQuery(strCmdText, arg0, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行查询 返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="arg0"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string strCmdText, DbParameter arg0, CommandType commandType)
        {
            DataTable dt = new DataTable();
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.Add(arg0);
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return dt;
        }

        /// <summary>
        /// 执行sql脚本，返回指定的行数
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="recordCurrent"></param>
        /// <returns></returns>
        public virtual DataTable ExecuteQuery(string sql, int pageIndex, int pageSize, out int recordCurrent)
        {
            throw new Exception("请在相应的数据库子类中重写此方法，此处不提供分页存储过程！");
        }

        /// <summary>
        /// 执行查询 SQL 脚本 过程返回DataSet
        /// </summary>
        /// <param name="strCmdText">存储过程名称</param>
        /// <param name="arg0">参数</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteQueryDataSet(string strCmdText, DbParameter arg0)
        {
            return ExecuteQueryDataSet(strCmdText, arg0, CommandType.Text);
        }

        /// <summary>
        /// 执行查询存储过程返回DataSet
        /// </summary>
        /// <param name="strCmdText">存储过程名称</param>
        /// <param name="arg0">参数</param>
        /// <returns>DataSet</returns>
        public DataSet ExecuteQueryDataSetProc(string strCmdText, DbParameter arg0)
        {
            return ExecuteQueryDataSet(strCmdText, arg0, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行查询 返回DataSet
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="arg0"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet(string strCmdText, DbParameter arg0, CommandType commandType)
        {
            DataSet ds = new DataSet();
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.Add(arg0);
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return ds;
        }

        /// <summary>
        /// 执行查询 SQL 脚本返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText">存储过程名称</param>
        /// <param name="arg0">参数</param>
        /// <returns>DataTable</returns>
        public object ExecuteScalar(string strCmdText, DbParameter arg0)
        {
            return ExecuteScalar(strCmdText, arg0, CommandType.Text);
        }

        /// <summary>
        ///  执行存储过程 返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="arg0"></param>
        /// <returns></returns>
        public object ExecuteScalarPro(string strCmdText, DbParameter arg0)
        {
            return ExecuteScalar(strCmdText, arg0, CommandType.StoredProcedure);
        } 

        
        /// <summary>
        /// 执行查询 脚本返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="arg0"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strCmdText, DbParameter arg0, CommandType commandType)
        {
            object oResult;
            DbCommand _cmd = null;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.Add(arg0);
                oResult = db.ExecuteScalar(_cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return oResult;
        }


        /// <summary>
        /// 执行查询 SQL 脚本 返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string strCmdText, DbParameter[] args)
        {
            return ExecuteQuery(strCmdText, args, CommandType.Text);
        }

       
        /// <summary>
        /// 执行查询存储过程返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataTable ExecuteQueryProc(string strCmdText, DbParameter[] args)
        {
            return ExecuteQuery(strCmdText, args, CommandType.StoredProcedure);
        }

        
        /// <summary>
        /// 执行查询 返回DataTable
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string strCmdText, DbParameter[] args, CommandType commandType)
        {
            DataTable dt = new DataTable();
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                
                _cmd.Parameters.AddRange(args);
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return dt;
        }
        
        
        /// <summary>
        /// 执行查询 SQL 语句 返回DataSet
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet(string strCmdText, DbParameter[] args)
        {
            return ExecuteQueryDataSet(strCmdText, args, CommandType.Text);
        }

       
        /// <summary>
        /// 执行查询存储过程返回DataSet
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSetProc(string strCmdText, DbParameter[] args)
        {
            return ExecuteQueryDataSet(strCmdText, args, CommandType.StoredProcedure);
        }


       
        /// <summary>
        /// 执行查询 返回DataSet
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public DataSet ExecuteQueryDataSet(string strCmdText, DbParameter[] args, CommandType commandType)
        {
            DataSet ds = new DataSet();
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.AddRange(args);
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return ds;
        }

       
       
        /// <summary>
        /// 执行查询 SQL 脚本 返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strCmdText, DbParameter[] args)
        {
            return ExecuteScalar(strCmdText, args, CommandType.Text);
        }

        
        /// <summary>
        /// 执行查询 存储过程返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public object ExecuteScalarProc(string strCmdText, DbParameter[] args)
        {
            return ExecuteScalar(strCmdText, args, CommandType.StoredProcedure);
        }

        

        /// <summary>
        /// 执行查询  返回第一条记录的第一个字段
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="args"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public object ExecuteScalar(string strCmdText, DbParameter[] args, CommandType commandType)
        {
            object oResult;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.AddRange(args);
                oResult = db.ExecuteScalar(_cmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return oResult;
        }

        /// <summary>
        /// 执行SQL 脚本返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">SQL 脚本</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string strCmdText)
        {
            return ExecuteNoQuery(strCmdText , CommandType.Text);
        }

        /// <summary>
        /// 执行 存储过程 返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">存储过程</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQueryProc(string strCmdText)
        {
            return ExecuteNoQuery(strCmdText, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行数据库操作 返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText"></param>
        /// <param name="commandType"></param>
        /// <returns></returns>
        public int ExecuteNoQuery(string strCmdText, CommandType commandType)
        {
            int iResult = -1;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                iResult = db.ExecuteNonQuery(_cmd);
                if (iResult == -1)
                {
                    iResult = 1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return iResult;
        }

        /// <summary>
        /// 执行SQL 脚本返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">SQL 脚本</param>
        /// <param name="arg0">参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string strCmdText, DbParameter arg0)
        {
            return ExecuteNoQuery(strCmdText, arg0, CommandType.Text);
        }

        /// <summary>
        /// 执行 存储过程 返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">存储过程</param>
        /// <param name="arg0">参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQueryProc(string strCmdText, DbParameter arg0)
        {
            return ExecuteNoQuery(strCmdText, arg0, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行数据库操作返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">SQL</param>
        /// <param name="arg0">参数</param>
        /// <param name="commandType">命令模式</param>
        /// <returns></returns>
        public int ExecuteNoQuery(string strCmdText, DbParameter arg0, CommandType commandType)
        {
            int iResult = -1;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.Add(arg0);
                iResult = db.ExecuteNonQuery(_cmd);
                if (iResult == -1)
                {
                    iResult = 1;
                }
            }
            catch (Exception ex)
            {
                iResult = -1;
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return iResult;
        }

        /// <summary>
        /// 执行SQL 脚本返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">SQL 脚本</param>
        /// <param name="args">参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string strCmdText, DbParameter[] args)
        {
            return ExecuteNoQuery(strCmdText, args, CommandType.Text);
        }

        /// <summary>
        /// 执行 存储过程 返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">存储过程</param>
        /// <param name="args">参数</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQueryProc(string strCmdText, DbParameter[] args)
        {
            return ExecuteNoQuery(strCmdText, args, CommandType.StoredProcedure);
        }

        /// <summary>
        /// 执行数据库操作 返回受影响的行数，错误返回-1。
        /// </summary>
        /// <param name="strCmdText">SQL</param>
        /// <param name="args">参数</param>
        /// <param name="commandType">命令模式</param>
        /// <returns>受影响的行数</returns>
        public int ExecuteNoQuery(string strCmdText, DbParameter[] args, CommandType commandType)
        {
            int iResult = -1;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = commandType;
                _cmd.Parameters.AddRange(args);
                iResult = db.ExecuteNonQuery(_cmd);
                if (iResult == -1)
                {
                    iResult = 1;
                }
            }
            catch (Exception ex)
            {
                iResult = -1;
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return iResult;
        }

        /// <summary>
        /// 执行多条SQL脚本
        /// </summary>
        /// <param name="strCmdTexts"></param>
        /// <returns></returns>
        public bool ExecuteNoQueryTran(List<string> strCmdTexts)
        {
            bool bResult = false;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.Connection.Open();
                _tran = _cmd.Connection.BeginTransaction();
                _cmd.CommandTimeout = TimeOut;
                _cmd.CommandType = CommandType.Text;

                foreach (string strCommandText in strCmdTexts)
                {
                    _cmd.CommandText = strCommandText;
                    db.ExecuteNonQuery(_cmd, _tran);
                }

                _tran.Commit();
                bResult = true;
            }
            catch (Exception ex)
            {
                if (null != _tran)
                {
                    _tran.Rollback();
                }
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return bResult;
        }

        /// <summary>
        /// 执行多个存储过程
        /// </summary>
        /// <param name="args">存储过程列表</param>
        /// <returns></returns>
        public bool ExecuteNoQueryTranPro(List<CommandList> args)
        {
            bool bResult = false;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.Connection.Open();
                _tran = _cmd.Connection.BeginTransaction();
                _cmd.Transaction = _tran;
                _cmd.CommandTimeout = TimeOut;

                foreach (CommandList command in args)
                {
                    _cmd.CommandType = command.Type;
                    _cmd.CommandText = command.strCommandText;
                    _cmd.Parameters.Clear();
                    if (null != command.Params)
                    {
                        _cmd.Parameters.AddRange(command.Params);
                    }
                    db.ExecuteNonQuery(_cmd, _tran);
                }

                _tran.Commit();
                bResult = true;
            }
            catch (Exception ex)
            {
                if(null != _tran)
                {
                    _tran.Rollback();
                }
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return bResult;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="strCmdText"></param>
        /// <returns></returns>
        public bool Update(DataTable dt, string strCmdText)
        {
            bool bResult = false;
            try
            {
                Database db = GetDataBase();
                _cmd = db.DbProviderFactory.CreateCommand();
                _cmd.Connection = db.CreateConnection();
                _cmd.CommandText = strCmdText;
                _cmd.CommandTimeout = TimeOut;
                _da = db.DbProviderFactory.CreateDataAdapter();
                _da.SelectCommand = _cmd;
                _da.Update(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Dispose();
            }
            return bResult;
        }

        #endregion

        #region IDisposable 成员

        /**/
        /// <summary>
        /// 是否已经被释放过,默认是false
        /// </summary>
        public bool _disposed;
        //private IntPtr handle;

        /// <summary>
        /// 实现IDisposable接口
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            //.NET Framework 类库
            // GC..::.SuppressFinalize 方法
            //请求系统不要调用指定对象的终结器。
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 虚方法，可供子类重写
        /// </summary>
        /// <param name="disposing"></param>
        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    Disconnect();
                }
                _disposed = true;
            }
        }

        /// <summary>
        /// 析构函数
        /// 当客户端没有显示调用Dispose()时由GC完成资源回收功能
        /// </summary>
        ~DbHelper()
        {
            Dispose(true);
        }

        #endregion
    }
}
