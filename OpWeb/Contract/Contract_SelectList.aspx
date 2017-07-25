﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contract_SelectList.aspx.cs" Inherits="OpWeb.Contract.Contract_SelectList" %>

<%@ Register Src="../UserControl/PageControl.ascx" TagName="PageControl" TagPrefix="uc1" %>
<%@ Register Src="../UserControl/LoadButton.ascx" TagName="LoadButton" TagPrefix="uc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>合同选择项管理</title>
    <link href="/Themes/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/Themes/Scripts/jquery-1.8.2.min.js" type="text/javascript"></script>
    <script src="/Themes/Scripts/jquery.pullbox.js" type="text/javascript"></script>
    <script src="/Themes/Scripts/FunctionJS.js" type="text/javascript"></script>
    <link href="/css/font-awesome.css?v=4.4.0" rel="stylesheet" />
    <link href="/css/plugins/iCheck/custom.css" rel="stylesheet" />
    <link href="/css/animate.css" rel="stylesheet" />
    <link href="/css/style.css?v=4.1.0" rel="stylesheet" />
    <script type="text/javascript">
        //回车键
        document.onkeydown = function (e) {
            if (!e) e = window.event; //火狐中是 window.event
            if ((e.keyCode || e.which) == 13) {
                var obtnSearch = document.getElementById("lbtSearch");
                obtnSearch.click();
            }
        }
        $(function () {
            divresize(60);
            FixedTableHeader("#table1", $(window).height() - 118);
        })

        function refresh() {
            location.reload();
        }

        //添加
        function add() {

            var url = "/Contract/Contract_SelectListForm.aspx";
            top.openDialog(url, 'Contract_SelectListForm', '合同选择项管理 - 添加', 800,300, 50, 50);
        }
        //编辑
        function edit() {
            var key = CheckboxValue();
            if (IsEditdata(key)) {
                var url = "/Contract/Contract_SelectListForm.aspx?key=" + key;
                top.openDialog(url, 'Contract_SelectListForm', '合同选择项管理 - 编辑', 800, 300, 50, 50);
            }
        }

    </script>
</head>
<body class="gray-bg">
    <div class="wrapper animated fadeInRight">
        <form id="form1" runat="server">

            <div class="btnbarcontetn">
                <div style="float: left;">
                    <input type="text" id="txt_Search" class="txtSearch SearchImg" runat="server" style="width: 180px;" /><asp:LinkButton ID="lbtSearch" runat="server" class="button green" OnClick="lbtSearch_Click"><span class="icon-botton"
            style="background: url('../../Themes/images/Search.png') no-repeat scroll 0px 4px;">
        </span>查 询</asp:LinkButton>

                </div>
                <div style="text-align: right">
                    <uc2:LoadButton ID="LoadButton1" runat="server" />
                </div>
            </div>
            <div class="div-body">
                <table id="table1" class="grid" singleselect="true">
                    <thead>
                        <tr>
                            <td style="width: 20px; text-align: left;">
                                <label id="checkAllOff" onclick="CheckAllLine()" title="全选"></label>
                            </td>
                            <td style="width: 120px; text-align: center;">合同类型</td>
                            <td style="width: 170px; text-align: center;">标题</td>
                            <td style="width: 80px; text-align: center;">排序</td>
                            <td style="width: 130px; text-align: center;">调用代码</td>
                            <td style="min-width:100px; overflow:hidden;">备注</td>
                        </tr>
                    </thead>
                    <tbody style="line-height: 35px;">
                        <asp:Repeater ID="rp_Item" runat="server">
                            <ItemTemplate>
                                <tr>
                                    <td style="width: 20px; text-align: left;">
                                        <input type="checkbox" value="<%#Eval("SL_ID")%>" name="checkbox" />
                                    </td>
                                    <td style="width: 120px; text-align: center;">
                                        <%#Eval("ContractName")%>
                                    </td>
                                    <td style="width: 170px; text-align: center;">
                                        <%#Eval("SL_Desc")%>
                                    </td>
                                    <td style="width: 80px; text-align: center;">
                                        <%#Eval("SL_Order")%>
                                    </td>
                                    <td style="width: 130px; text-align: center;"><%#Eval("SL_Code")%></td>
                                    <td style="min-width:100px; overflow:hidden;"><%#Eval("SL_Memo")%></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <% if (rp_Item != null)
                                    {
                                        if (rp_Item.Items.Count == 0)
                                        {
                                            Response.Write("<tr><td colspan='8' style='color:red;text-align:center'>没有找到您要的相关数据！</td></tr>");
                                        }
                                    } %>
                            </FooterTemplate>
                        </asp:Repeater>
                    </tbody>
                </table>
            </div>
            <uc1:PageControl ID="PageControl1" runat="server" />
        </form>
    </div>
</body>
</html>
