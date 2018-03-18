using System;
using System.Web.UI;

public partial class Module_Admin_ST_type : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Response.Redirect("../../BlogIndex.aspx");
        }
    }
}