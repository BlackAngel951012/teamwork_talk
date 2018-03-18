<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Header.ascx.cs" Inherits="UseControls_Header" %>
<%@ Register Src="VisitorNav.ascx" TagName="VisitorNav" TagPrefix="uc2" %>
<table align="center" 
       style="background-image: url('Images/Skin/head.jpg'); height: 127px; width: 924px;" 
       cellpadding="0" cellspacing="0">
    <tr>
        <td style="height: 8px; text-align: right; width: 716px;">
        </td>
    </tr>
    <tr>
        <td style="height: 1px; text-align: right; width: 716px;">
            <uc2:VisitorNav ID="VisitorNav1" runat="server" />
        </td>
    </tr>
    <tr>
        <td style="height: 59px; text-align: right; width: 716px;">
            &nbsp;
            &nbsp;&nbsp;&nbsp;</td>
    </tr>
    <tr>
        <td style="height: 28px; text-align: center; width: 716px;">
            &nbsp;</td>
    </tr>
</table>