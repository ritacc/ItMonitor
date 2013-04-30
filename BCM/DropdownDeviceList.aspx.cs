using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using GDK.Entity.SYS;
using GDK.DAL.SYS;
using Entity;

namespace GDK.BCM
{
    public partial class DropdownDeviceList : PageBase
    {
        IEnumerable<DEVICETYPEOR> _List;
        private int _Depth;
        private JavaScriptSerializer _jss;
        private JavaScriptSerializer Jss
        {
            get
            {
                if (null == _jss)
                {
                    _jss = new JavaScriptSerializer();
                }
                return _jss;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.IsAjaxPage = true;
            base.IsAuthenticate = false;
            base.OnLoad(e);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (AjaxLoadData())
            {
                return;
            }
        }

        private bool AjaxLoadData()
        {
            if (null != Request.QueryString["type"])
            {
                //JavaScriptSerializer jss = new JavaScriptSerializer();
                AjaxContext context = new AjaxContext();
                context.Html = string.Empty;
                try
                {
                    context.IsSuccess = true;
                    string type = Request.QueryString["type"];
                    if (type == "single"
                        && null != Request.QueryString["guid"])
                    {
                        string guid = Request.QueryString["guid"];
                        Device _type = new DEVICETYPEDA().SingleByID(guid);
                        if (null != _type)
                        {
                            context.Html = Jss.Serialize(_type);
                        }
                    }
                    else if (type == "list")
                    {
                        int level;
                        if (null != Request.QueryString["guid"]   // 父节点Guid
                            && null != Request.QueryString["identity"]  // 身份
                            && null != Request.QueryString["depth"]
                            && int.TryParse(Request.QueryString["depth"], out _Depth) // 默认需要加载的级别
                            && null != Request.QueryString["level"]
                            && int.TryParse(Request.QueryString["level"], out level))  // 加载的级别
                        {
                            string guid = Request.QueryString["guid"];
                            string key = "key_" + guid + "_depth_" + Request.QueryString["depth"];
                            context.UserState = true;// base.HasPermissionFullWord(Request.QueryString["Identity"]); // 是否为管理员
                           
                            switch (level)
                            {
                                case 1:
                                    _List = new DEVICETYPEDA().SelectExtend(guid);
                                    rpLevel1.DataSource = _List;
                                    rpLevel1.DataBind();
                                    context.Html = base.RenderControl(rpLevel1);
                                    break;
                                case 2:
                                    _List = new DEVICETYPEDA().SelectExtend(guid, _Depth);
                                    rpLevel2.DataSource = _List.Where(d => d.Parentguid == guid);
                                    rpLevel2.DataBind();
                                    context.Html = base.RenderControl(rpLevel2);
                                    break;
                                default:
                                    throw new KeyNotFoundException("Ajax->list列表获取操作参数配置错误！");
                            }
                        }
                        else
                        {
                            throw new KeyNotFoundException("Ajax->list列表获取操作参数配置错误！");
                        }
                    }
                    else if (type == "add"
                        && null != Request.QueryString["obj"]
                        && null != Request.QueryString["depth"])
                    {
                        DEVICETYPEOR _type = Jss.Deserialize<DEVICETYPEOR>(Request.QueryString["obj"]);
                        context.UserState = _type.Guid = Guid.NewGuid().ToString();
                        new DEVICETYPEDA().Insert(_type);
                        context.Html = Jss.Serialize(_type).Replace("\"", "&quot;");
                        string key = "key_" + _type.Rootguid + "_depth_" + Request.QueryString["depth"];
                        Cache.Remove(key);
                    }
                    else if (type == "edit"
                        && null != Request.QueryString["obj"]
                        && null != Request.QueryString["depth"])
                    {
                        DEVICETYPEOR _type = Jss.Deserialize<DEVICETYPEOR>(Request.QueryString["obj"]);
                        new DEVICETYPEDA().UpdateType(_type);
                        context.Html = Jss.Serialize(_type).Replace("\"", "&quot;");
                        string key = "key_" + _type.Rootguid + "_depth_" + Request.QueryString["depth"];
                        Cache.Remove(key);
                    }
                    else if (type == "delete"
                        && null != Request.QueryString["guid"]
                        && null != Request.QueryString["root"]
                        && null != Request.QueryString["flag"])// 0 或 1 在此区分为删除耗材(0)或设备(1)
                    {
                        int flag;
                        if (int.TryParse(Request.QueryString["flag"].Trim(), out flag))
                        {
                            string guid = Request.QueryString["guid"];
                            context.UserState = new DEVICETYPEDA().Delete(guid);
                            string key = "key_" + Request.QueryString["root"] + "_depth_" + Request.QueryString["depth"];
                            Cache.Remove(key);
                        }
                        else
                        {
                            throw new KeyNotFoundException("Ajax->delete操作参数配置错误！");
                        }
                    }
                }
                catch (Exception ex)
                {
                    context.IsSuccess = false;
                    context.Source = ex.Source;
                    context.Message = ex.Message;
                    context.TargetSite = ex.TargetSite.ToString();
                    context.StackTrace = ex.StackTrace;
                    if (null != ex.InnerException)
                    {
                        context.InnerException = ex.InnerException.ToString();
                    }

                }
                string error = Jss.Serialize(context);
                Response.Write(error);

                Response.Flush();
                Response.End();
                return true;
            }
            return false;
        }

        protected string GetItem(object item)
        {
            return Jss.Serialize(item).Replace("\"", "&quot;");
        }

        protected IEnumerable<DEVICETYPEOR> GetChild(object parentGuid)
        {
            return _List.Where(d => d.Parentguid == parentGuid.ToString());
        }
    }

   
}