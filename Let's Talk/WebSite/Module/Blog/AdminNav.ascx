<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminNav.ascx.cs" Inherits="UseControls_MainControls_Navigation" %>
<table style="width: 240px" cellpadding="0" cellspacing="0">
    <tr>
        <td colspan="1" style="height: 15px; text-align: center; width: 67px;">
            <span style="color: #cc0033; font-size: 9pt;">◎ 
                <asp:LinkButton ID="lnkbtnAdmin" runat="server" Font-Size="9pt" Font-Underline="False"
                                ForeColor="Black" PostBackUrl="~/Module/Admin/AdminManage.aspx" CausesValidation="False">管理员</asp:LinkButton></span></td>
        <td colspan="1" style="height: 15px; text-align: center; width: 80px;">
            <span style="color: #cc0033; font-size: 9pt;">◎ 
                <span style="font-size: 9pt"></span></span></td>
        <td colspan="1" 
            style="color: #000000; height: 15px; text-align: center; width: 80px;">
            <span style="color: #cc0033; font-size: 9pt;">◎ <a href="~/Module/Admin/Index.aspx" style="color: #000000; text-decoration: none">
                                                                <asp:LinkButton ID="lnkbtnCancle" runat="server" Font-Size="9pt" Font-Underline="False"
                                                                                ForeColor="Black" OnClick="lnkbtnCancle_Click" CausesValidation="False">退出登录</asp:LinkButton></a> </span></td>
    </tr>
</table>