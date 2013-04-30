using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
    public class KnowledgeBaseConfigOR
    {
        /// <summary>
        /// 知识库配置主键id
        /// </summary>
        private string _GUID;

        public string GUID
        {
            get { return _GUID; }
            set { _GUID = value; }
        }
        private string _LBID;

        /// <summary>
        /// 类别ID
        /// </summary>
        public string LBID
        {
            get { return _LBID; }
            set { _LBID = value; }
        }
        private string _XLID;

        /// <summary>
        /// 小类ID
        /// </summary>
        public string XLID
        {
            get { return _XLID; }
            set { _XLID = value; }
        }

        /// <summary>
        /// KnowledgeBaseConfigOR无参构造函数
        /// </summary>
        public KnowledgeBaseConfigOR()
        {

        }
        /// <summary>
        /// KnowledgeBaseConfigOR带参数构造函数
        /// </summary>
        /// <param name="dr"></param>
        public KnowledgeBaseConfigOR(DataRow dr)
        {
            _GUID = dr["GUID"].ToString().Trim();
            _LBID = dr["LBID"].ToString().Trim();
            _XLID = dr["XLID"].ToString().Trim();
        }
    }
}
