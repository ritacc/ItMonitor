using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Text;
using GDK.Entity.AlertAdmin;
using GDK.DAL.AlertAdmin;


namespace GDK.BCM.AlertAdmin
{
    public partial class EventTypeEdit : PageBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindDrop();

                if (Request.QueryString["id"] != null)
                    LoadData();
            }
        }

        private void BindDrop()
        {
          dpdAlarmlevel.DataSource=  new AlarmLevelSetDA().selectAllData();
          dpdAlarmlevel.DataTextField = "LevelName";
          dpdAlarmlevel.DataValueField = "Priority";
          dpdAlarmlevel.DataBind();

          DataTable dt = new AlarmGroupsDA().SelectAllDate();
          foreach (DataRow dr in dt.Rows)
          {
              ListItem li = new ListItem();
              li.Value = dr["AlarmGroupsID"].ToString();
              li.Text = dr["GroupName"].ToString();
              cbAlertGroup.Items.Add(li);
          }

           dt = new DisarmTimeDA().selectAllDate();
          foreach (DataRow dr in dt.Rows)
          {
              ListItem li = new ListItem();
              li.Value = dr["DisarmID"].ToString();
              li.Text = dr["DisarmName"].ToString();
              cbDisarmid.Items.Add(li);
          }
        }
        private void LoadData()
        {
            try
            {
                EventTypeOR m_Even = new EventTypeDA().selectARowDate(Request.QueryString["id"]);
                txtEventname.Text = m_Even.Eventname;//事件名称
                dpdAlarmlevel.SelectedValue = m_Even.Alarmlevel.ToString();//事件级别

                string[] AlarmWay = m_Even.Alarmway.Split('-');//报警方式
                if (AlarmWay[0] == "1")
                    check_Sms.Checked = true;
                else
                    check_Sms.Checked = false;
                if (AlarmWay[1] == "1")
                    check_Phone.Checked = true;
                else
                    check_Phone.Checked = false;
                if (AlarmWay[2] == "1")
                    check_Media.Checked = true;
                else
                    check_Media.Checked = false;
                if (AlarmWay[3] == "1")
                    check_Emali.Checked = true;
                else
                    check_Emali.Checked = false;

                string[] strAlarmTarget = m_Even.Alarmtarget.Split('-');
                foreach (string str in strAlarmTarget)
                {
                    foreach (ListItem li in cbAlertGroup.Items)
                    {
                        if (str == li.Value)
                            li.Selected = true;
                    }
                }

                txtIsenablefrequency.Checked = m_Even.Isenablefrequency.ToString() == "1" ? true : false;//是否班次报警
                txtAlarmaudiofile.Text = m_Even.Alarmaudiofile;//电话语音文件
                txtDisalarmaudiofile.Text = m_Even.Disalarmaudiofile;//电话语音文件
                txtSmsmsg.Text = m_Even.Smsmsg;//短信、Email、语音报警内容格式
                //txtDisarmid.Text = m_Even.Disarmid;//撤防时间
                ShowSettedDisarmInfo ( m_Even.Disarmid);//撤防时间
            }
            catch (Exception e)
            {
                Alert(e);
            }
        }
        //private void ShowSettedDisarmInfo(int DisarmID)
        //{
        //    int _DisarmID = -1;
        //    foreach (TreeNode node in Disarm_treeView.Nodes)
        //    {
        //        _DisarmID = (int)node.Tag;
        //        if (_DisarmID == DisarmID)
        //        {
        //            node.Checked = true;
        //        }
        //        else
        //        {
        //            node.Checked = false;
        //        }
        //    }
        //}
        private EventTypeOR SetValue()
        {
            EventTypeOR m_Even = new EventTypeOR();
            if (Request.QueryString["id"] != null)
                m_Even.Eventid = int.Parse(Request.QueryString["id"]);
            m_Even.Eventname = txtEventname.Text;//事件名称
            m_Even.Alarmlevel = int.Parse(dpdAlarmlevel.SelectedItem.Value);//事件级别
            


            string[] ArryAlarmWay = { "0", "0", "0", "0" };
            if (check_Sms.Checked)
                ArryAlarmWay[0] = "1";
            if (check_Phone.Checked)
                ArryAlarmWay[1] = "1";
            if (check_Media.Checked)
                ArryAlarmWay[2] = "1";
            if (check_Emali.Checked)
                ArryAlarmWay[3] = "1";
            //if (check_Frequency.Checked)
            //ArryAlarmWay [4]="1";
            string AlarmWay = "";
            for (int i = 0; i < ArryAlarmWay.Length; i++)
            {
                if (i != 3)
                    AlarmWay += ArryAlarmWay[i] + "-";
                else
                    AlarmWay += ArryAlarmWay[i];

            }

            m_Even.Alarmway = AlarmWay;//报警方式
            m_Even.Isenablefrequency = txtIsenablefrequency.Checked ? 1 : 0;//是否班次报警
            m_Even.Alarmaudiofile = txtAlarmaudiofile.Text;//电话语音文件
            m_Even.Disalarmaudiofile = txtDisalarmaudiofile.Text;//电话语音文件
            m_Even.Smsmsg = txtSmsmsg.Text;//短信、Email、语音报警内容格式

            string AlarmTarget = "";
            //m_Even.Alarmtarget = txtAlarmtarget.Text;//报警组
            foreach (ListItem li in cbAlertGroup.Items)
            {
              if(!li.Selected)
                    continue;
                AlarmTarget = AlarmTarget + li.Value + "-";
            }
            m_Even.Alarmtarget = AlarmTarget;
            //撤防时间
            m_Even.Disarmid = "";
            foreach (ListItem li in cbDisarmid.Items)
            {
                if (li.Selected)
                {
                    if (!string.IsNullOrEmpty(m_Even.Disarmid))
                    {
                        Alert("你不能选择连2个或2个以上撤防时间段");
                        return null;
                    }
                    m_Even.Disarmid = li.Value;
                }
            }

            

            return m_Even;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            EventTypeOR sg = SetValue();
            if (sg == null)
                return;

            try
            {
                if (Request.QueryString["id"] == null)
                {
                    new EventTypeDA().Insert(sg);
                }
                else
                {
                    new EventTypeDA().Update(sg);
                }
                base.Close("tr");
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }

       


        private void ShowSettedDisarmInfo(string DisarmID)
        {
            foreach (ListItem li in cbDisarmid.Items)
            {
                if (li.Value == DisarmID)
                {
                    li.Selected = true;
                }
            }
        }
    }
}
