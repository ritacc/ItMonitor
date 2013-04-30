using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace GDK.Entity.Sys
{
   public class TaskFunctionOR
    {
       private string _TASK_URL;
       /// <summary>
       /// 
       /// </summary>
       public string TASK_URL
       {
           get { return _TASK_URL; }
           set { _TASK_URL = value; }
       }

       private string _TASK_NAME;
       /// <summary>
       /// 
       /// </summary>
       public string TASK_NAME
       {
           get { return _TASK_NAME; }
           set { _TASK_NAME = value; }
       }

       private string _PARENT_URL;
       /// <summary>
       /// 
       /// </summary>
       public string PARENT_URL
       {
           get { return _PARENT_URL; }
           set { _PARENT_URL = value; }
       }

       private int _SORT;
       /// <summary>
       /// 
       /// </summary>
       public int SORT
       {
           get { return _SORT; }
           set { _SORT = value; }
       }

       private int _TASK_LEVEL;
       /// <summary>
       /// 
       /// </summary>
       public int TASK_LEVEL
       {
           get { return _TASK_LEVEL; }
           set { _TASK_LEVEL = value; }
       }

       private string _TASK_DESC;
       /// <summary>
       /// 
       /// </summary>
       public string TASK_DESC
       {
           get { return _TASK_DESC; }
           set { _TASK_DESC = value; }
       }

       public TaskFunctionOR() { }
       public TaskFunctionOR(DataRow dr)
       {
           _TASK_URL = dr["TASK_URL"].ToString();
           _TASK_NAME = dr["TASK_NAME"].ToString();
           _PARENT_URL = dr["PARENT_URL"].ToString();
           _SORT = Convert.ToInt32(dr["SORT"].ToString());
           _TASK_LEVEL = Convert.ToInt32(dr["TASK_LEVEL"].ToString());
           _TASK_DESC = dr["TASK_DESC"].ToString();
       }
    }
}
