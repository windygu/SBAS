﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DataBase.Dal;
namespace OpWeb.Contract
{
    public partial class ApproveFlow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                this.wfTool.WorkFlowID = "4881a8ce-ce89-47af-a7bf-cb73b7f90ef9";
            }
        }

        protected void btn_addContract_Click(object sender, EventArgs e)
        {
            WorkFlowService flowService = new WorkFlowService();
            flowService.CreateWorkFlow(Guid.NewGuid().ToString(), "48f3889c-af8d-401f-ada2-c383031af92d", 10000);
        }
    }
}