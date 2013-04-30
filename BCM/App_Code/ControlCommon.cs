using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data;
using GDK.DAL.Sys;
using GDK.Entity;

using System.Text;
using System.Web.UI;

namespace GDK.BCM
{
    
    public class ControlCommon : PageBase
    {
        

        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="htmltable">htmltable控件</param>
        /// <returns></returns>
        public List<ControlOR> SetObjValue(HtmlTable htmltable)
        {
            List<ControlOR> listObj = (List<ControlOR>)ViewState["List<ControlOR>"];
            if (listObj != null)
            {
                foreach (ControlOR obj in listObj)
                {
                    if (obj.ControlType == "textbox")
                    {
                        obj.ObjValue = ((TextBox)htmltable.FindControl(obj.CName)).Text;
                    }
                    else if (obj.ControlType == "checkbox")
                    {
                        if (((CheckBox)htmltable.FindControl(obj.CName)).Checked)
                        {
                            obj.ObjValue = 1;
                        }
                        else
                        {
                            obj.ObjValue = 0;
                        }
                    }
                    else if (obj.ControlType == "dropdownlist")
                    {
                        obj.ObjValue = ((DropDownList)htmltable.FindControl(obj.CName)).SelectedValue;
                    }
                }
            }
            return listObj;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="htmltable">htmltable控件</param>
        /// <param name="listObj">控件实体集合</param>
        /// <param name="dr">数据行</param>
        //public void UpdateColumn(HtmlTable htmltable, List<ControlOR> listObj, DataRow dr)
        //{
        //    foreach (ControlOR obj in listObj)
        //    {
        //        HtmlTableRow tr = new HtmlTableRow();
        //        HtmlTableCell tcName = new HtmlTableCell();
        //        HtmlTableCell tcValue = new HtmlTableCell();
        //        tcName.InnerHtml = obj.CDescribe + "：";
        //        if (obj.ControlType == "textbox")
        //        {
        //            TextBox tx = new TextBox();
        //            tx.ID = obj.CName;
        //            tx.Text = dr[obj.CName].ToString();
        //            tx.CssClass = "textbox_skin";
        //            tcValue.Controls.Add(tx);
        //        }
        //        else if (obj.ControlType == "checkbox")
        //        {
        //            CheckBox cb = new CheckBox();
        //            cb.ID = obj.CName;
        //            if (!string.IsNullOrEmpty(dr[obj.CName].ToString()) && (bool)dr[obj.CName])
        //            {
        //                cb.Checked = true;
        //            }
        //            else
        //            {
        //                cb.Checked = false;
        //            }
        //            tcValue.Controls.Add(cb);
        //        }
        //        else if (obj.ControlType == "dropdownlist")
        //        {
        //            DropDownList ddl = new DropDownList();
        //            ddl.ID = obj.CName;
        //            DataTable dt = new DataDictDA().SelectDictTypeByKeyWord(obj.Keyword);
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                string str = dt.Rows[i]["NAME"].ToString();
        //                ListItem item = new ListItem(str, str);
        //                ddl.Items.Add(item);
        //            }
        //            ddl.SelectedValue = obj.KeywordName;
        //            tcValue.Controls.Add(ddl);
        //        }
        //        tcName.Attributes.Add("align", "right");
        //        tr.Cells.Add(tcName);
        //        tr.Cells.Add(tcValue);
        //        htmltable.Rows.Add(tr);
        //    }

        //    ViewState["List<ControlOR>"] = listObj;
        //}

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="htmltable">htmltable控件</param>
        /// <param name="listObj">控件实体集合</param>
        //public void InsertColumn(HtmlTable htmltable, List<ControlOR> listObj)
        //{
        //    foreach (ControlOR obj in listObj)
        //    {
        //        HtmlTableRow tr = new HtmlTableRow();
        //        HtmlTableCell tcName = new HtmlTableCell();
        //        HtmlTableCell tcValue = new HtmlTableCell();
        //        tcName.InnerHtml = obj.CDescribe + "：";
        //        if (obj.ControlType == "textbox")
        //        {
        //            TextBox tx = new TextBox();
        //            tx.ID = obj.CName;
        //            tx.CssClass = "textbox_skin";
        //            tcValue.Controls.Add(tx);
        //        }
        //        else if (obj.ControlType == "checkbox")
        //        {
        //            CheckBox cb = new CheckBox();
        //            cb.ID = obj.CName;
        //            tcValue.Controls.Add(cb);
        //        }
        //        else if (obj.ControlType == "dropdownlist")
        //        {
        //            DropDownList ddl = new DropDownList();
        //            ddl.ID = obj.CName;
        //            DataTable dt = new DataDictDA().SelectDictTypeByKeyWord(obj.Keyword);
        //            for (int i = 0; i < dt.Rows.Count; i++)
        //            {
        //                string str = dt.Rows[i]["NAME"].ToString();
        //                ListItem item = new ListItem(str, str);
        //                ddl.Items.Add(item);
        //            }
        //            tcValue.Controls.Add(ddl);
        //        } 
        //        tcName.Attributes.Add("align", "right");
        //        tr.Cells.Add(tcName);
        //        tr.Cells.Add(tcValue);
        //        htmltable.Rows.Add(tr);
        //    }

        //    ViewState["List<ControlOR>"] = listObj;
        //}


        public void Close(string msg)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script language='javascript'>window.close(); </script>");
        }

    }
}