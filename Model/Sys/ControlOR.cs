using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity
{
    [Serializable]
    public class ControlOR
    {
        public ControlOR()
        {
            /*......*/
        }

        public ControlOR(DataRow dr)
        {
            id = int.Parse(dr["Id"].ToString());
            cName = dr["CName"].ToString();
            cDescribe = dr["CDescribe"].ToString();
            cType = dr["CType"].ToString();
            tableName = dr["TableName"].ToString();
            cLength = int.Parse(dr["CLength"].ToString());
            isVisible = int.Parse(dr["IsVisible"].ToString());
            controlType = dr["ControlType"].ToString();
            keyword = dr["Keyword"].ToString();
            keywordName = dr["KeywordName"].ToString();
            parentCode = int.Parse(dr["ParentCode"].ToString());
        }

        private int id;
        private string cName;
        private string cType;
        private int cLength;
        private string tableName;
        private int isVisible;
        private string cDescribe;
        private string controlType;
        private string keyword;
        private string keywordName;
        private int parentCode;
        private object objValue;
        private string guid;

        public string Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        public int ParentCode
        {
            get { return parentCode; }
            set { parentCode = value; }
        }
        public string Keyword
        {
            get { return keyword; }
            set { keyword = value; }
        }
        public string KeywordName
        {
            get { return keywordName; }
            set { keywordName = value; }
        }
        public string ControlType
        {
            get { return controlType; }
            set { controlType = value; }
        }

        public object ObjValue
        {
            get { return objValue; }
            set { objValue = value; }
        }

        public string CDescribe
        {
            get { return cDescribe; }
            set { cDescribe = value; }
        }

        public string CName
        {
            get { return cName; }
            set { cName = value; }
        }

        public string CType
        {
            get { return cType; }
            set { cType = value; }
        }
        public int CLength
        {
            get { return cLength; }
            set { cLength = value; }
        }

        public string TableName
        {
            get { return tableName; }
            set { tableName = value; }
        }

        public int IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }



        
    }
}
