using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using MonitorSystem.Web.Moldes;
using System.IO;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.ServiceModel;

namespace MonitorSystem.Web.Servers
{
    public partial class MonitorServers
    {

        public IQueryable<t_ElementProperty> GetScreenElementProperty(int ScreenID)
        {
            return ObjectContext.P_GetElementPropertiesByScreenID(ScreenID).AsQueryable();
        }

        public void CopyScreenElement(int newScreenID, int oldScreen)
        {
            ObjectContext.P_CopyScreen(newScreenID, oldScreen);
        }

        /// <summary>
        /// 根据Screenid查询当前场景下元素的值
        /// </summary>
        /// <param name="mScreenID"></param>
        /// <returns></returns>
        public List<v_DeviceStatus> GetScreenMonitorValue(int mScreenID)
        {
            var v = from f in ObjectContext.v_DeviceStatus where f.ScreenID == mScreenID select f;
            List<v_DeviceStatus> eValue = v.ToList();
            return eValue;
        }


        /// <summary>
        /// 根据场景ID获取 元素列表
        /// </summary>
        /// <param name="screenID"></param>
        /// <returns></returns>
        public List<t_Element> GetT_ElementsByScreenID(int screenID)
        {
            var v = from f in ObjectContext.t_Element where f.ScreenID == screenID select f;
            List<t_Element> list = v.ToList();
            return list;
        }



        /// <summary>
        /// 根据 control type 查询控件 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public IQueryable<t_Control> GetT_ControlByType(int type)
        {
            return this.ObjectContext.t_Control.Where(t => t.ControlType == type);
        }

    }


}