using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GDK.DAL.PerfMonitor;
using GDK.Entity.CompSearch;
using GDK.DAL.CompSearch;

namespace GDK.BCM.CompReport
{
    public partial class ReportConfig : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                lblDepart.Text = base.CurrentUser.DepartmentName;
               
                //加载，应用系统
                DataTable dt = new PerfApplicationDA().GetTopBuss();
                dpdSystem.DataSource = dt;
                dpdSystem.DataTextField = "DeviceName";
                dpdSystem.DataValueField = "DeviceID";
                dpdSystem.DataBind();
                if (dt != null && dt.Rows.Count > 0)
                {
                    LoadData(Convert.ToInt32(dt.Rows[0]["DeviceID"].ToString()));
                }
            }
        }

		private void LoadData(int busID)
		{
			try
			{

				ReportConfigOR m_Repo = new ReportConfigDA().selectARowDate(busID);
				 
				cbHost_DiskUseRate.Checked=  m_Repo.HostDiskuserate;//
				cbHost_Memory.Checked = m_Repo.HostMemory;//
				cbHost_CPUUseRate.Checked = m_Repo.HostCpuuserate;//

				cbDB_TableNameSpace.Checked = m_Repo.DbTablenamespace;//
				cbDB_Hitrate.Checked = m_Repo.DbHitrate;//
				cbDB_OnlineTime.Checked = m_Repo.DbOnlinetime;//

				cbMid_Session.Checked = m_Repo.MidSession;//
				cbMid_JVMUse.Checked = m_Repo.MidJvmuse;//
				cbMid_ConnPool.Checked = m_Repo.MidConnpool;//

				cbSystem_Stop.Checked = m_Repo.SystemStop;//
				cbStopInfo.Checked = m_Repo.Stopinfo;//
				cbAvailableRate.Checked = m_Repo.Availablerate;//
			}
			catch (Exception e)
			{
				Alert(e);
			}
		}

		private ReportConfigOR SetValue()
		{
			ReportConfigOR m_Repo = new ReportConfigOR();
			m_Repo.Bussystemid = Convert.ToInt32(dpdSystem.SelectedItem.Value);

			m_Repo.HostDiskuserate = cbHost_DiskUseRate.Checked;//
			m_Repo.HostMemory = cbHost_Memory.Checked;//
			m_Repo.HostCpuuserate = cbHost_CPUUseRate.Checked;//

			m_Repo.DbTablenamespace = cbDB_TableNameSpace.Checked;//
			m_Repo.DbHitrate = cbDB_Hitrate.Checked;//
			m_Repo.DbOnlinetime = cbDB_OnlineTime.Checked;//

			m_Repo.MidSession = cbMid_Session.Checked;//
			m_Repo.MidJvmuse = cbMid_JVMUse.Checked;//
			m_Repo.MidConnpool = cbMid_ConnPool.Checked;//

			m_Repo.SystemStop = cbSystem_Stop.Checked;//
			m_Repo.Stopinfo = cbStopInfo.Checked;//
			m_Repo.Availablerate = cbAvailableRate.Checked;//

			return m_Repo;
		}

		protected void lbtSave_Click(object sender, EventArgs e)
		{
			ReportConfigOR sg = SetValue();
			try
			{
				if (Request.QueryString["id"] == null)
				{
					new ReportConfigDA().Insert(sg);
				}
				else
				{
					new ReportConfigDA().Update(sg);
				}
				AlertNormal("保存成功！");
			}
			catch (Exception ex)
			{
				base.Alert(ex.Message);
			}
		}


		protected void dpdSystem_SelectedIndexChanged(object sender, EventArgs e)
		{
			int busID = Convert.ToInt32(dpdSystem.SelectedItem.Value);
			LoadData(busID);
		}
    }
}