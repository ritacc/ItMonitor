using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using GDK.Entity.SYS;
using System.Linq;

namespace GDK.DAL.SYS
{

    public class Device
    {
        public string Guid { get; set; }
        public string Displayname { get; set; } // 类型/品牌/型号的显示名称
        public string SubName { get; set; }  // 规格
        public string ParentGuid { get; set; }
        public string RootGuid { get; set; }
        public int Flag { get; set; }
        public int Level { get; set; }
        public bool CanDelete { get; set; }
        public string Remark { get; set; }
        public string FullName { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DEVICETYPEDA : DALBase
    {

        #region 查询
        public DataTable selectAllDateByWhere(int pageCrrent, int pageSize, out int pageCount, string where)
        {
            string sql = "select * from T_SYS_DEVICE_TYPE";
            if (!string.IsNullOrEmpty(where))
            {
                sql = string.Format(" {0} where {1}", sql, where);
            }
            DataTable dt = null;
            int returnC = 0; try
            {
                dt = db.ExecuteQuery(sql, pageCrrent, pageSize, out returnC);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            pageCount = returnC;
            return dt;
        }
        public void UpdateType(DEVICETYPEOR type)
        {

        }

        public Device SingleByID(string strID)
        {
            DataTable dt = db.ExecuteQueryProc("P_GetDevicesById", new SqlParameter("@Guid", strID));

            List<DEVICETYPEOR> listDev = new List<DEVICETYPEOR>();
            foreach (DataRow dr in dt.Rows)
            {
                DEVICETYPEOR m_DEVI = new DEVICETYPEOR(dr);
                listDev.Add(m_DEVI);
            }

            if(listDev.Count==0)
                 return new Device();;

            var model = listDev.Last();
            return new Device()
            {
                Guid = model.Guid,
                Displayname = string.Join("-", listDev.Select(a => a.Displayname).ToArray()),
                SubName = model.SubName,
                ParentGuid = model.Parentguid,
                RootGuid = model.Rootguid,
                Flag = model.Flag,
                Level = model.Level,
                Remark = model.Remark,
                FullName = string.Join("￥", listDev.Select(a => a.Displayname).ToArray())
            };
        }

        public DEVICETYPEOR Single(string m_id)
        {
            string sql = string.Format("select * from T_SYS_DEVICE_TYPE where  Guid='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            DataRow dr = dt.Rows[0];
            DEVICETYPEOR m_DEVI = new DEVICETYPEOR(dr);
            return m_DEVI;

        }
        public IEnumerable<DEVICETYPEOR> SelectExtend(string guid, int level)
        {
            string procedureName = "P_GetDevicesRecursion";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@ParentGuid", guid)
                ,new SqlParameter("@Level", level)
            };
            DataTable dt = db.ExecuteQueryProc(procedureName, parameters);
            if (dt == null)
                return null;
            List<DEVICETYPEOR> listDev = new List<DEVICETYPEOR>();
            foreach (DataRow dr in dt.Rows)
            {
                DEVICETYPEOR m_DEVI = new DEVICETYPEOR(dr);
                listDev.Add(m_DEVI);
            }
            return listDev;
        }

        public IEnumerable<DEVICETYPEOR> SelectExtend(string guid)
        {
            string sql = string.Format("select * from T_SYS_DEVICE_TYPE where  ParentGuid='{0}'", guid);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<DEVICETYPEOR> listDev = new List<DEVICETYPEOR>();
            foreach (DataRow dr in dt.Rows)
            {
                DEVICETYPEOR m_DEVI = new DEVICETYPEOR(dr);
                listDev.Add(m_DEVI);
            }
            return listDev;
        }

        public List<DEVICETYPEOR> Select(string m_id)
        {
            string sql = string.Format("select * from T_SYS_DEVICE_TYPE where  RootGuid='{0}'", m_id);
            DataTable dt = null;
            try
            {
                dt = db.ExecuteQueryDataSet(sql).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (dt == null)
                return null;
            if (dt.Rows.Count == 0)
                return null;
            List<DEVICETYPEOR> listDev = new List<DEVICETYPEOR>();
            foreach (DataRow dr in dt.Rows)
            {
                DEVICETYPEOR m_DEVI = new DEVICETYPEOR(dr);
                listDev.Add(m_DEVI);
            }
            return listDev;

        }
        
        #endregion

        #region 插入
        /// <summary>
        /// 插入T_SYS_DEVICE_TYPE
        /// </summary>
        public virtual bool Insert(DEVICETYPEOR dEVICETYPE)
        {
            string sql = "insert into T_SYS_DEVICE_TYPE (Guid, DisplayName, SubName, ParentGuid, RootGuid, Flag, Level, Remark) values (@Guid, @DisplayName, @SubName, @ParentGuid, @RootGuid, @Flag, @Level, @Remark)";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Guid", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Guid", DataRowVersion.Default, dEVICETYPE.Guid),
				new SqlParameter("@DisplayName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "DisplayName", DataRowVersion.Default, dEVICETYPE.Displayname),
				new SqlParameter("@SubName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "SubName", DataRowVersion.Default, dEVICETYPE.SubName),
				new SqlParameter("@ParentGuid", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ParentGuid", DataRowVersion.Default, dEVICETYPE.Parentguid),
				new SqlParameter("@RootGuid", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "RootGuid", DataRowVersion.Default, dEVICETYPE.Rootguid),
				new SqlParameter("@Flag", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Flag", DataRowVersion.Default, dEVICETYPE.Flag),
				new SqlParameter("@Level", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Level", DataRowVersion.Default, dEVICETYPE.Level),
				new SqlParameter("@Remark", SqlDbType.NVarChar, 2048, ParameterDirection.Input, false, 0, 0, "Remark", DataRowVersion.Default, dEVICETYPE.Remark)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 更新T_SYS_DEVICE_TYPE
        /// </summary>
        public virtual bool Update(DEVICETYPEOR dEVICETYPE)
        {
            string sql = "update T_SYS_DEVICE_TYPE set  DisplayName = @DisplayName,  SubName = @SubName,  ParentGuid = @ParentGuid,  RootGuid = @RootGuid,  Flag = @Flag,  Level = @Level,  Remark = @Remark where  Guid = @Guid";
            SqlParameter[] parameters = new SqlParameter[]
			{
				new SqlParameter("@Guid", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "Guid", DataRowVersion.Default, dEVICETYPE.Guid),
				new SqlParameter("@DisplayName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "DisplayName", DataRowVersion.Default, dEVICETYPE.Displayname),
				new SqlParameter("@SubName", SqlDbType.NVarChar, 128, ParameterDirection.Input, false, 0, 0, "SubName", DataRowVersion.Default, dEVICETYPE.SubName),
				new SqlParameter("@ParentGuid", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "ParentGuid", DataRowVersion.Default, dEVICETYPE.Parentguid),
				new SqlParameter("@RootGuid", SqlDbType.VarChar, 36, ParameterDirection.Input, false, 0, 0, "RootGuid", DataRowVersion.Default, dEVICETYPE.Rootguid),
				new SqlParameter("@Flag", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Flag", DataRowVersion.Default, dEVICETYPE.Flag),
				new SqlParameter("@Level", SqlDbType.Int, 4, ParameterDirection.Input, false, 0, 0, "Level", DataRowVersion.Default, dEVICETYPE.Level),
				new SqlParameter("@Remark", SqlDbType.NVarChar, 2048, ParameterDirection.Input, false, 0, 0, "Remark", DataRowVersion.Default, dEVICETYPE.Remark)
			};
            return db.ExecuteNoQuery(sql, parameters) > -1;
        }
        #endregion

        #region DELETE
        /// <summary>
        /// 删除T_SYS_DEVICE_TYPE
        /// </summary>
        public virtual int Delete(string strGuid)
        {
            return db.ExecuteNoQueryProc("P_DeleteDeviceByGuid", new SqlParameter("@Guid", strGuid));
        }
        #endregion
    }
}

