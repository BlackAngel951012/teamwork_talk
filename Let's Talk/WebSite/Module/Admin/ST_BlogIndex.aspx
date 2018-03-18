<%@ Page Language="C#" MasterPageFile="~/MasterPage/AdminMasterPage.master" AutoEventWireup="true" CodeFile="ST_BlogIndex.aspx.cs" Inherits="Module_Admin_ST_type" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="height: 384px; width: 632px;" cellpadding="0" cellspacing="0" class="style1">
        <tr>
            <td style="height: 432px; width: 84px;">
                <iframe src="TreeMenuSys.aspx"  name="leftFrame" width="200"  frameborder="no" scrolling="no" style="background-image: url(../../Images/Skin/left.jpg); height: 478px; width: 157px;" ></iframe>
            </td>
            <td style="height: 432px; width: 95px;">
                <iframe src="CommonPage.aspx" name="rightFrame" frameborder="no" scrolling="no" 
                        height="500" style="height: 483px; width: 760px;"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>