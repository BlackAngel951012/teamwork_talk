using System;
using System.Web.UI;

public partial class Module_Blog_LonginOut : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session.Abandon();
        Response.Redirect("../../BlogIndex.aspx");
    }
}