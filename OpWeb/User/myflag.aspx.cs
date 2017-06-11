﻿using Busines;
using Busines.DAL;
using Busines.IDAO;
using Common.DotNetBean;
using Common.DotNetCode;
using Common.DotNetUI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OpWeb.User
{
    public partial class myflag : System.Web.UI.Page
    {
        private IMPC_Person_IDAO peridal = new IMPC_Person_DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.PageControl1.pageHandler += new EventHandler(this.pager_PageChanged);
            if (!base.IsPostBack)
            {
                this.BindSelect();
            }
        }
        private void BindSelect()
        {
            DataTable dt = DataFactory.SqlDataBase().GetDataTable("School_Area");
            ControlBindHelper.BindHtmlSelect(dt, this.AreaName, "AreaName", "AreaName", "院校所在地");

            DataTable dtEduBack = DataFactory.SqlDataBase().GetDataTable("EduBack");
            ControlBindHelper.BindHtmlSelect(dtEduBack, this.EduBackName, "name", "name", "学历");

            DataTable dtEduType = DataFactory.SqlDataBase().GetDataTable("EduType");
            ControlBindHelper.BindHtmlSelect(dtEduType, this.EduTypeName, "name", "name", "教育类型");

            DataTable dtCompany = DataFactory.SqlDataBase().GetDataTable("Company");
            ControlBindHelper.BindHtmlSelect(dtCompany, this.CompanyID, "companyName", "companyID", "申报单位");

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT specName  FROM Specialty  group by specName");
            DataTable dtSpecialty = DataFactory.SqlDataBase().GetDataTableBySQL(sb);
            ControlBindHelper.BindHtmlSelect(dtSpecialty, this.specName, "specName", "specName", "申报专业");

            DataTable dtUserStatus = DataFactory.SqlDataBase().GetDataTable("UserStatus");
            ControlBindHelper.BindHtmlSelect(dtUserStatus, this.status, "status", "status", "审核状态");

            DataTable dtChecks = DataFactory.SqlDataBase().GetDataTable("Keys");
            ControlBindHelper.BindHtmlSelect(dtChecks, this.Checks, "value", "value", "确认简历");

        }
        protected void pager_PageChanged(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }
        private void DataBindGrid()
        {
            int count = 0;
            StringBuilder SqlWhere = new StringBuilder();
            IList<SqlParam> IList_param = new List<SqlParam>();
            SqlWhere.AppendFormat(" WHERE sysUserID='{0}' ", RequestSession.GetSessionUser().UserId.ToString());
            if (!string.IsNullOrEmpty(this.AreaName.Value))
            {
                SqlWhere.AppendFormat(" AND AreaName='{0}' ", this.AreaName.Value);
            }
            if (!string.IsNullOrEmpty(this.EduBackName.Value))
            {
                SqlWhere.AppendFormat(" AND EduBackName='{0}' ", this.EduBackName.Value);
            }
            if (!string.IsNullOrEmpty(this.EduTypeName.Value))
            {
                SqlWhere.AppendFormat(" AND EduTypeName='{0}' ", this.EduTypeName.Value);
            }
            if (!string.IsNullOrEmpty(this.CompanyID.Value))
            {
                SqlWhere.AppendFormat(" AND CompanyID='{0}' ", this.CompanyID.Value);
            }
            if (!string.IsNullOrEmpty(this.specName.Value))
            {
                SqlWhere.AppendFormat(" AND specName='{0}' ", this.specName.Value);
            }
            if (!string.IsNullOrEmpty(this.status.Value))
            {
                SqlWhere.AppendFormat(" AND status='{0}' ", this.status.Value);
            }
            if (!string.IsNullOrEmpty(this.Checks.Value))
            {
                SqlWhere.AppendFormat(" AND Checks='{0}' ", this.Checks.Value);
            }
            if (!string.IsNullOrEmpty(this.txt_Search.Value))
            {
                SqlWhere.Append(" AND U." + this.Searchwhere.Value + " like @obj ");
                IList_param.Add(new SqlParam("@obj", '%' + this.txt_Search.Value.Trim() + '%'));
            }

            DataTable dt = this.peridal.GetFlagListPage(SqlWhere, IList_param, this.PageControl1.PageIndex, this.PageControl1.PageSize, ref count);
            ControlBindHelper.BindRepeaterList(dt, this.rp_Item);
            this.PageControl1.RecordCount = Convert.ToInt32(count);
            this.PageControl1.PageChecking();
        }
        protected void lbtSearch_Click(object sender, EventArgs e)
        {
            this.DataBindGrid();
        }
    }
}