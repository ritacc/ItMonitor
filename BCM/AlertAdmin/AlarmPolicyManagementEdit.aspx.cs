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
using GDK.DAL.SerMonitor;
using GDK.DAL.Sys;
using GDK.Entity.SerMonitor;


namespace GDK.BCM.AlertAdmin
{
    public partial class AlarmPolicyManagementEdit : PageBase
    {
        DeviceDA m_devi = new DeviceDA();
        protected override void OnLoad(EventArgs e)
        {
            BindEvent();

            IsAuthenticate = false;
            base.OnLoad(e);
        }

        private void BindEvent()
        {
            DataTable dt = new EventTypeDA().selectAllDate();
            DataRow dr = dt.NewRow();
            dr["EventName"] = "";
            dr["EventID"] = "-1";
            dt.Rows.InsertAt(dr, 0);

            cmbEvent.DataSource = cmbEventLo.DataSource = cmbEventHi.DataSource = dt;
            cmbEvent.DataTextField = cmbEventLo.DataTextField = cmbEventHi.DataTextField = "EventName";
            cmbEvent.DataValueField = cmbEventLo.DataValueField = cmbEventHi.DataValueField = "EventID";
            cmbEvent.DataBind();
            cmbEventLo.DataBind();
            cmbEventHi.DataBind();


            DataTable dtAlarm = m_devi.GetAllLightAlarm();
            DataRow drAlarm = dtAlarm.NewRow();
           drAlarm["LightID"] = -1;
           drAlarm["LightName"] = "未启用声光报警";
           drAlarm["DeviceID"] = -1;
           drAlarm["ChannelNO"] = -1;
           dtAlarm.Rows.InsertAt(drAlarm, 0);

           ReleaseLightID.DataSource=LightID.DataSource = dtAlarm;
           ReleaseLightID.DataTextField = LightID.DataTextField = "LightName";
           ReleaseLightID.DataValueField = LightID.DataValueField = "LightID";

           LightID.DataBind();
           ReleaseLightID.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txt_defaultSmsMsg.Text = new SysParaDA().selectARowDate("defaultSmsMsg").Valstr;

                string DeviceID = Request.QueryString["DeviceID"];
                string ChannelNo = Request.QueryString["ChanncelID"];

                txtStationid.Text = new StationDA().selectARowDate(Request.QueryString["StationID"]).Stationname;
                txtDevicetypeid.Text = m_devi.GetDeviceTypeName(Request.QueryString["DeviceTypeID"]);
                txtDeviceid.Text = m_devi.GetDeviceName(DeviceID);
                txtDevicechannelid.Text = m_devi.GetChannelName(ChannelNo);
               

                int ValueType = m_devi.GetChannelValueType(DeviceID, ChannelNo);

                if (ValueType == 1)
                {
                    txt_ChannelValueType.Text = "开关量";
                    txt_MaxValue.Enabled = false;
                    txt_MinValue.Enabled = false;
                    cmbEventHi.Enabled = false;
                    cmbEventLo.Enabled = false;
                    cmbEvent.Enabled = true;
                    check_EqualMax.Enabled = false;
                    check_EqualMinValue.Enabled = false;
                    cmb_AlarmValue.Enabled = true;

                }
                else if (ValueType == 0)
                {
                    txt_ChannelValueType.Text = "模拟量";
                    cmb_AlarmValue.Enabled = false;
                    txt_MaxValue.Enabled = true;
                    txt_MinValue.Enabled = true;
                    cmbEventHi.Enabled = true;
                    cmbEventLo.Enabled = true;
                    cmbEvent.Enabled = false;
                    check_EqualMax.Enabled = true;
                    check_EqualMinValue.Enabled = true;
                }
                this.LightID.SelectedValue = "-1";
                this.ReleaseLightID.SelectedValue = "-1";

                AlarmPolicyManagementOR m_Alar = new AlarmPolicyManagementDA()
                    .selectARowDate(Request.QueryString["StationID"]
                   , Request.QueryString["DeviceTypeID"]
                   , Request.QueryString["DeviceID"]
                   , Request.QueryString["ChanncelID"]);

                if (m_Alar != null)
                    showAlarmPolicyInfo(m_Alar);
            }
        }
        public void showAlarmPolicyInfo(AlarmPolicyManagementOR m_Alar)
        {
            string EventID = m_Alar.Eventid;
            string[] evds = EventID.Split('-');
            if (evds.Length > 1)
            {
                string hi = "-1";
                string lo = "-1";
                if (evds[0] != "")
                {
                    hi = evds[0];
                    this.cmbEventHi.SelectedValue = hi;
                }

                if (evds[1] != "")
                {
                    lo = evds[1];
                    this.cmbEventLo.SelectedValue = lo;
                }
            }
            else if (evds.Length == 1)
            {
                if (evds[0] != "")
                {
                    this.cmbEvent.SelectedValue = evds[0];
                }
            }

            txt_MaxValue.Text = m_Alar.Maxvalue.ToString();
            txt_MinValue.Text = m_Alar.Minvalue.ToString();
            string s = m_Alar.Switchvalue.ToString();
            if (s.Trim() != "" && s.Trim() != null && s.Trim() != "NULL" && s.Trim() != "null")
            {
                //string s = dt.Rows[0]["SwitchValue"].ToString();
                int ValueType = int.Parse(s);
                if (ValueType == 1)
                {
                    cmb_AlarmValue.Text = "高电平";
                }
                else
                    cmb_AlarmValue.Text = "低电平";
            }
            else
                cmb_AlarmValue.Text = "未配置";


            if (m_Alar.Maxtiggertype == 0)
                check_EqualMax.Checked = false;
            else
                check_EqualMax.Checked = true;

            if (m_Alar.Mintiggertype == 0)
                check_EqualMinValue.Checked = false;
            else
                check_EqualMinValue.Checked = true;

            txtAlarmtimes.Text = m_Alar.Alarmtimes.ToString();//AlarmTimes  AlarmfilterTimes
            txtAlarmfiltertimes.Text = m_Alar.Alarmfiltertimes.ToString();

            //2011-10-26  增加语音文件
            txtAlarmaudiofile.Text = m_Alar.Alarmaudiofile;
            txtDisalarmaudiofile.Text = m_Alar.Disalarmaudiofile;


            cbIsenable.Checked = (m_Alar.Isenable == 1);
                      
            txtSmsmsg.Text = m_Alar.Smsmsg;


            this.LightID.SelectedValue = m_Alar.Lightid.ToString();


            this.ReleaseLightID.SelectedValue = m_Alar.Releaselightid.ToString();

        }

        private AlarmPolicyManagementOR SetValue()
        {
            AlarmPolicyManagementOR m_Alar = new AlarmPolicyManagementOR();

            m_Alar.Stationid = int.Parse(Request.QueryString["StationID"]);//机房名称
            m_Alar.Devicetypeid = int.Parse(Request.QueryString["DeviceTypeID"]);//设备类型
            m_Alar.Deviceid = int.Parse(Request.QueryString["DeviceID"]);//设备名称
            m_Alar.Devicechannelid = int.Parse(Request.QueryString["ChanncelID"]);//通道



            m_Alar.Isenable = cbIsenable.Checked ? 1 : 0;


            string EvHi, EvLo, EvSg;
            string EventID = "";
            int ValueType = m_devi.GetChannelValueType(Request.QueryString["DeviceID"],
                Request.QueryString["ChanncelID"]);
            m_Alar.Valuetype = ValueType;
            if (ValueType == 0)
            {
                if (this.cmbEventHi.SelectedValue != null)
                    EvHi = this.cmbEventHi.SelectedValue.ToString();
                else
                    EvHi = "";

                if (this.cmbEventLo.SelectedValue != null)
                    EvLo = this.cmbEventLo.SelectedValue.ToString();
                else
                    EvLo = "";

                EventID = EvHi + "-" + EvLo;

                if (txt_MaxValue.Text != string.Empty && txt_MaxValue.Text != "")
                    m_Alar.Maxvalue =txt_MaxValue.Text.Trim();
                if (txt_MinValue.Text != string.Empty && txt_MinValue.Text != "")
                    m_Alar.Minvalue =txt_MinValue.Text.Trim();
            }
            else
            {
                if (this.cmbEvent.SelectedValue != null)
                    EvSg = this.cmbEvent.SelectedValue.ToString();
                else
                    EvSg = "";

                EventID = EvSg;

                m_Alar.Maxvalue = "NULL";
                m_Alar.Minvalue = "NULL";
                //if (cmb_AlarmValue.Text.Trim() == "")
                //    objPolicyModel.SwitchValue;
                if (cmb_AlarmValue.Text.Trim() == "高电平")
                    m_Alar.Switchvalue = 1;

                else if (cmb_AlarmValue.Text.Trim() == "低电平")
                    m_Alar.Switchvalue = 0;
            }

            if (check_EqualMax.Checked)
                m_Alar.Maxtiggertype = 1;//高于高限触发
            else
                m_Alar.Maxtiggertype = 0;//等于或高于高限触发
            if (check_EqualMinValue.Checked)
                m_Alar.Mintiggertype = 1;
            else
                m_Alar.Mintiggertype = 0;


            if (txtAlarmtimes.Text.Trim() != string.Empty)
                m_Alar.Alarmtimes = int.Parse(txtAlarmtimes.Text);
            if (txtAlarmfiltertimes.Text.Trim() != string.Empty)
                m_Alar.Alarmfiltertimes = int.Parse(txtAlarmfiltertimes.Text);

            //报警语音文件以及解除报警语音文件名
            if (txtAlarmaudiofile.Text.Trim() != string.Empty)
            {
                m_Alar.Alarmaudiofile = txtAlarmaudiofile.Text.Trim();
            }
            else
            {
                m_Alar.Alarmaudiofile = null;
            }
            if (txtDisalarmaudiofile.Text.Trim() != string.Empty)
            {
                m_Alar.Disalarmaudiofile = txtDisalarmaudiofile.Text.Trim();
            }
            else
            {
                m_Alar.Disalarmaudiofile = null;
            }

            //短信、Email、语音报警内容格式
            if (txtSmsmsg.Text.Trim() != string.Empty && cbDefultAlert.Checked == false)
            {
                m_Alar.Smsmsg = txtSmsmsg.Text.Trim();
            }
            //保存默认的报警内容
            else if (this.txt_defaultSmsMsg.Text != string.Empty && this.txt_defaultSmsMsg.Enabled == true && cbDefultAlert.Checked)
                m_Alar.Smsmsg = txt_defaultSmsMsg.Text.Trim();


            m_Alar.Lightid = int.Parse(LightID.SelectedItem.Value);
            m_Alar.Releaselightid = int.Parse(ReleaseLightID.SelectedItem.Value);
            m_Alar.Eventid = EventID;
            return m_Alar;
        }

        protected void lbtSave_Click(object sender, EventArgs e)
        {
            AlarmPolicyManagementOR sg = SetValue();

            try
            {
                if (Request.QueryString["id"] == null)
                {
                    new AlarmPolicyManagementDA().Insert(sg);
                }
                else
                {
                    new AlarmPolicyManagementDA().Update(sg);
                }
                base.Close("tr");
            }
            catch (Exception ex)
            {
                base.Alert(ex.Message);
            }
        }

        protected void cbDefultAlert_CheckedChanged(object sender, EventArgs e)
        {
            txt_defaultSmsMsg.Enabled = cbDefultAlert.Checked;
        }

        protected void btnAlertDefult_Click(object sender, EventArgs e)
        {
            SysParaOR  obj=new SysParaOR();
            obj.Keystr = "defaultSmsMsg";
            obj.Valstr=txt_defaultSmsMsg.Text;
            try
            {
                new SysParaDA().Update(obj);
            }
            catch(Exception ex)
            {
                Alert(ex);
            }
        }
    }
}
