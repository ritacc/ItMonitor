using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
   
    public partial class VHC_USER_PERMISSIONS
    {

        private string _USER_GUID;

        private string _PERMISSION_CODE;

        private string _MOD_URL;

        private string _MOD_NAME;

        private string _PARENT_URL;

        private int _SORT;

        private int _MOD_LEVEL;

        private string _MOD_DESC;

        private string _ENABLED;

        private string _IMAGE_PATH;

        private char _isFunction;

        public VHC_USER_PERMISSIONS(DataRow dr)
        {
            _USER_GUID = dr["USER_GUID"].ToString();

            _PERMISSION_CODE = dr["PERMISSION_CODE"].ToString();

            _MOD_URL = dr["MOD_URL"].ToString();

            _MOD_NAME = dr["MOD_NAME"].ToString();

            _PARENT_URL = dr["PARENT_URL"].ToString();
            _SORT = int.Parse(dr["SORT"].ToString());

            _MOD_LEVEL = int.Parse(dr["MOD_LEVEL"].ToString());

            _MOD_DESC = dr["MOD_DESC"].ToString();

            _ENABLED = dr["ENABLED"].ToString();
            _IMAGE_PATH = dr["IMAGE_PATH"].ToString();

            //_isFunction = (bool)dr["isFunction"];
        }

        public string USER_GUID
        {
            get
            {
                return this._USER_GUID;
            }
            set
            {
                if ((this._USER_GUID != value))
                {
                    this._USER_GUID = value;
                }
            }
        }

        public string PERMISSION_CODE
        {
            get
            {
                return this._PERMISSION_CODE;
            }
            set
            {
                if ((this._PERMISSION_CODE != value))
                {
                    this._PERMISSION_CODE = value;
                }
            }
        }

        public string MOD_URL
        {
            get
            {
                return this._MOD_URL;
            }
            set
            {
                if ((this._MOD_URL != value))
                {
                    this._MOD_URL = value;
                }
            }
        }

        public string MOD_NAME
        {
            get
            {
                return this._MOD_NAME;
            }
            set
            {
                if ((this._MOD_NAME != value))
                {
                    this._MOD_NAME = value;
                }
            }
        }

        public string PARENT_URL
        {
            get
            {
                return this._PARENT_URL;
            }
            set
            {
                if ((this._PARENT_URL != value))
                {
                    this._PARENT_URL = value;
                }
            }
        }

        public int SORT
        {
            get
            {
                return this._SORT;
            }
            set
            {
                if ((this._SORT != value))
                {
                    this._SORT = value;
                }
            }
        }

        public int MOD_LEVEL
        {
            get
            {
                return this._MOD_LEVEL;
            }
            set
            {
                if ((this._MOD_LEVEL != value))
                {
                    this._MOD_LEVEL = value;
                }
            }
        }

        public string MOD_DESC
        {
            get
            {
                return this._MOD_DESC;
            }
            set
            {
                if ((this._MOD_DESC != value))
                {
                    this._MOD_DESC = value;
                }
            }
        }

        public string ENABLED
        {
            get
            {
                return this._ENABLED;
            }
            set
            {
                if ((this._ENABLED != value))
                {
                    this._ENABLED = value;
                }
            }
        }

        public string IMAGE_PATH
        {
            get
            {
                return this._IMAGE_PATH;
            }
            set
            {
                if ((this._IMAGE_PATH != value))
                {
                    this._IMAGE_PATH = value;
                }
            }
        }

        public char isFunction
        {
            get
            {
                return this._isFunction;
            }
            set
            {
                if ((this._isFunction != value))
                {
                    this._isFunction = value;
                }
            }
        }
    }
}
