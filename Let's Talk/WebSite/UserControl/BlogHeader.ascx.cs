using System;
using System.Web.UI;

public partial class UseControls_LoginHeader : UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["UserName"] != null)
            {
                labName.Text = Session["UserName"].ToString();
            }
        }
    }
}