using System;
using System.Web.Security;
using System.Web.UI;

public partial class UseControls_MainControls_Navigation : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void lnkbtnCancle_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut(); //清除验证信息
        Session.Clear(); //清除Session的内存
        Session.Abandon(); //取消会话状态
        Response.Redirect("../../BlogIndex.aspx");
    }
}