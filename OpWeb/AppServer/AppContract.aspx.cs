﻿using Busines.DAL;
using Busines.IDAO;
using Common.DotNetCode;
using Common.DotNetUI;
using OpWeb.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.DotNetData;


namespace OpWeb.AppServer
{
    public partial class AppContract : System.Web.UI.Page
    {
        private Contract_IDAO peridal = new Contract_Dal();
        public StringBuilder sb = new StringBuilder();

        protected void Page_Load(object sender, EventArgs e)
        {
            DataBindGrid();
        }

        private void DataBindGrid()
        {
            StringBuilder SqlWhere = new StringBuilder();
            IList<SqlParam> IList_param = new List<SqlParam>();
            SqlWhere.Append(" WHERE WFStatus=1 ");
            
            DataTable dt = this.peridal.GetMyApproveList(SqlWhere);
            if (DataTableHelper.IsExistRows(dt))
            {
                sb.Append(" <ul class=\"lists\">");
                foreach (DataRow dr in dt.Rows)
                {
                    sb.AppendFormat("<li><a href=\"AppCustomer.aspx?UID={3}&documentType={4}\">{0}--[授信金额：{1}]--[分期数：{2}]</a></li>", dr["Card_Name"].ToString(), dr["M_Loan_Cap"].ToString(), dr["M_Loan_Months"].ToString(), dr["UID"].ToString(), dr["documentType"].ToString());
                }
                sb.Append("</ul>");
            }
            //ControlBindHelper.BindRepeaterList(dt, this.rp_Item);
            //this.PageControl1.RecordCount = Convert.ToInt32(count);
            //this.PageControl1.PageChecking();
        }

    }
}