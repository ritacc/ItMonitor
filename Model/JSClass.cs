using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class AjaxContext
    {
        /// <summary>
        /// // Ajax返回用户对象
        /// </summary>
        public object UserState;
        public bool IsSuccess;
        public string Html;
        public string Source;
        public string Message;
        public string TargetSite;
        public string StackTrace;
        public string InnerException;
        public string ErrorMsg;
        public List<SelectProgram> listPro;
        public List<SelectServer> listServer;
        public List<SelectSYXZC> listsyxzc;
    }
    public class HeadleServer
    {
        /// <summary>
        /// // Ajax返回用户对象
        /// </summary>       
        public bool IsSuccess;                
        public string Message;
        public string ErrorMsg;
        public string Domain;
        public string Server_IP;
        public string ServerAccount;
        public string ServerPwd;
    }

    public class SelectProgram
    {
        public string Guid;
        public string Name;

        public string Domain;
        public string Struct;
        public string OnlinTime;
        public string administrator;
        public string ErrorMsg;
    }

    public class SelectServer
    {
        public string Guid;
        public string ShowVal;
        public string Server_IP;
        public string AdminName;
        public string Server_Brand;
        public string Server_Model;
    }
    public class SelectSYXZC
    {
        public string Guid;
        public string Name;
        public string zcType;
        public string zcWZ;
        public string zcWHBM;

    }
}
