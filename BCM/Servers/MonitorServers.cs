
namespace MonitorSystem.Web.Servers
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using MonitorSystem.Web.Moldes;


    // 使用 MS 上下文实现应用程序逻辑。
    // TODO: 将应用程序逻辑添加到这些方法中或其他方法中。
    // TODO: 连接身份验证(Windows/ASP.NET Forms)并取消注释以下内容，以禁用匿名访问
    //还可考虑添加角色，以根据需要限制访问。
    // [RequiresAuthentication]
    [EnableClientAccess()]
    public partial class MonitorServers : LinqToEntitiesDomainService<MS>
    {

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Control”查询添加顺序。
        public IQueryable<t_Control> GetT_Control()
        {
            return this.ObjectContext.t_Control;
        }

        public void InsertT_Control(t_Control t_Control)
        {
            if ((t_Control.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Control, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Control.AddObject(t_Control);
            }
        }

        public void UpdateT_Control(t_Control currentt_Control)
        {
            this.ObjectContext.t_Control.AttachAsModified(currentt_Control, this.ChangeSet.GetOriginal(currentt_Control));
        }

        public void DeleteT_Control(t_Control t_Control)
        {
            if ((t_Control.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Control, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Control.Attach(t_Control);
                this.ObjectContext.t_Control.DeleteObject(t_Control);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_ControlProperty”查询添加顺序。
        public IQueryable<t_ControlProperty> GetT_ControlProperty()
        {
            return this.ObjectContext.t_ControlProperty;
        }

        public void InsertT_ControlProperty(t_ControlProperty t_ControlProperty)
        {
            if ((t_ControlProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ControlProperty, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ControlProperty.AddObject(t_ControlProperty);
            }
        }

        public void UpdateT_ControlProperty(t_ControlProperty currentt_ControlProperty)
        {
            this.ObjectContext.t_ControlProperty.AttachAsModified(currentt_ControlProperty, this.ChangeSet.GetOriginal(currentt_ControlProperty));
        }

        public void DeleteT_ControlProperty(t_ControlProperty t_ControlProperty)
        {
            if ((t_ControlProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ControlProperty, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_ControlProperty.Attach(t_ControlProperty);
                this.ObjectContext.t_ControlProperty.DeleteObject(t_ControlProperty);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Element”查询添加顺序。
        public IQueryable<t_Element> GetT_Element()
        {
            return this.ObjectContext.t_Element;
        }

        public void InsertT_Element(t_Element t_Element)
        {
            if ((t_Element.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Element.AddObject(t_Element);
            }
        }

        public void UpdateT_Element(t_Element currentt_Element)
        {
            this.ObjectContext.t_Element.AttachAsModified(currentt_Element, this.ChangeSet.GetOriginal(currentt_Element));
        }

        public void DeleteT_Element(t_Element t_Element)
        {
            if ((t_Element.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Element, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Element.Attach(t_Element);
                this.ObjectContext.t_Element.DeleteObject(t_Element);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_ElementProperty”查询添加顺序。
        public IQueryable<t_ElementProperty> GetT_ElementProperty()
        {
            return this.ObjectContext.t_ElementProperty;
        }

        public void InsertT_ElementProperty(t_ElementProperty t_ElementProperty)
        {
            if ((t_ElementProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ElementProperty, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_ElementProperty.AddObject(t_ElementProperty);
            }
        }

        public void UpdateT_ElementProperty(t_ElementProperty currentt_ElementProperty)
        {
            this.ObjectContext.t_ElementProperty.AttachAsModified(currentt_ElementProperty, this.ChangeSet.GetOriginal(currentt_ElementProperty));
        }

        public void DeleteT_ElementProperty(t_ElementProperty t_ElementProperty)
        {
            if ((t_ElementProperty.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_ElementProperty, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_ElementProperty.Attach(t_ElementProperty);
                this.ObjectContext.t_ElementProperty.DeleteObject(t_ElementProperty);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_MonitorSystemParam”查询添加顺序。
        public IQueryable<t_MonitorSystemParam> GetT_MonitorSystemParam()
        {
            return this.ObjectContext.t_MonitorSystemParam;
        }

        public void InsertT_MonitorSystemParam(t_MonitorSystemParam t_MonitorSystemParam)
        {
            if ((t_MonitorSystemParam.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_MonitorSystemParam, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_MonitorSystemParam.AddObject(t_MonitorSystemParam);
            }
        }

        public void UpdateT_MonitorSystemParam(t_MonitorSystemParam currentt_MonitorSystemParam)
        {
            this.ObjectContext.t_MonitorSystemParam.AttachAsModified(currentt_MonitorSystemParam, this.ChangeSet.GetOriginal(currentt_MonitorSystemParam));
        }

        public void DeleteT_MonitorSystemParam(t_MonitorSystemParam t_MonitorSystemParam)
        {
            if ((t_MonitorSystemParam.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_MonitorSystemParam, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_MonitorSystemParam.Attach(t_MonitorSystemParam);
                this.ObjectContext.t_MonitorSystemParam.DeleteObject(t_MonitorSystemParam);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Screen”查询添加顺序。
        public IQueryable<t_Screen> GetT_Screen()
        {
            return this.ObjectContext.t_Screen;
        }

        public void InsertT_Screen(t_Screen t_Screen)
        {
            if ((t_Screen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Screen, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Screen.AddObject(t_Screen);
            }
        }

        public void UpdateT_Screen(t_Screen currentt_Screen)
        {
            this.ObjectContext.t_Screen.AttachAsModified(currentt_Screen, this.ChangeSet.GetOriginal(currentt_Screen));
        }

        public void DeleteT_Screen(t_Screen t_Screen)
        {
            if ((t_Screen.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Screen, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Screen.Attach(t_Screen);
                this.ObjectContext.t_Screen.DeleteObject(t_Screen);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“t_Station”查询添加顺序。
        public IQueryable<t_Station> GetT_Station()
        {
            return this.ObjectContext.t_Station;
        }

        public void InsertT_Station(t_Station t_Station)
        {
            if ((t_Station.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Station, EntityState.Added);
            }
            else
            {
                this.ObjectContext.t_Station.AddObject(t_Station);
            }
        }

        public void UpdateT_Station(t_Station currentt_Station)
        {
            this.ObjectContext.t_Station.AttachAsModified(currentt_Station, this.ChangeSet.GetOriginal(currentt_Station));
        }

        public void DeleteT_Station(t_Station t_Station)
        {
            if ((t_Station.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(t_Station, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.t_Station.Attach(t_Station);
                this.ObjectContext.t_Station.DeleteObject(t_Station);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“v_DeviceStatus”查询添加顺序。
        public IQueryable<v_DeviceStatus> GetV_DeviceStatus()
        {
            return this.ObjectContext.v_DeviceStatus;
        }

        public void InsertV_DeviceStatus(v_DeviceStatus v_DeviceStatus)
        {
            if ((v_DeviceStatus.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_DeviceStatus, EntityState.Added);
            }
            else
            {
                this.ObjectContext.v_DeviceStatus.AddObject(v_DeviceStatus);
            }
        }

        public void UpdateV_DeviceStatus(v_DeviceStatus currentv_DeviceStatus)
        {
            this.ObjectContext.v_DeviceStatus.AttachAsModified(currentv_DeviceStatus, this.ChangeSet.GetOriginal(currentv_DeviceStatus));
        }

        public void DeleteV_DeviceStatus(v_DeviceStatus v_DeviceStatus)
        {
            if ((v_DeviceStatus.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_DeviceStatus, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.v_DeviceStatus.Attach(v_DeviceStatus);
                this.ObjectContext.v_DeviceStatus.DeleteObject(v_DeviceStatus);
            }
        }

        // TODO:
        // 考虑约束查询方法的结果。如果需要其他输入，
        //可向此方法添加参数或创建具有不同名称的其他查询方法。
        // 为支持分页，需要向“v_NetDevice”查询添加顺序。
        public IQueryable<v_NetDevice> GetV_NetDevice()
        {
            return this.ObjectContext.v_NetDevice;
        }

        public void InsertV_NetDevice(v_NetDevice v_NetDevice)
        {
            if ((v_NetDevice.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_NetDevice, EntityState.Added);
            }
            else
            {
                this.ObjectContext.v_NetDevice.AddObject(v_NetDevice);
            }
        }

        public void UpdateV_NetDevice(v_NetDevice currentv_NetDevice)
        {
            this.ObjectContext.v_NetDevice.AttachAsModified(currentv_NetDevice, this.ChangeSet.GetOriginal(currentv_NetDevice));
        }

        public void DeleteV_NetDevice(v_NetDevice v_NetDevice)
        {
            if ((v_NetDevice.EntityState != EntityState.Detached))
            {
                this.ObjectContext.ObjectStateManager.ChangeObjectState(v_NetDevice, EntityState.Deleted);
            }
            else
            {
                this.ObjectContext.v_NetDevice.Attach(v_NetDevice);
                this.ObjectContext.v_NetDevice.DeleteObject(v_NetDevice);
            }
        }
    }
}


