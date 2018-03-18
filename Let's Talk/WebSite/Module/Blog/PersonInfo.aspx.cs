using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Blog_PersonInfo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["VisitorID"] != "")
        {
            if (!IsPostBack)
            {
                SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                mycon.Open();
                SqlDataAdapter mydataadapter =
                    new SqlDataAdapter("select * from tb_Visitor where VisitorID=" + Request["VisitorID"], mycon);
                DataSet mydataset = new DataSet();
                mydataadapter.Fill(mydataset, "tb_Visitor");
                DataRowView rowview = mydataset.Tables["tb_Visitor"].DefaultView[0];
                txtName.Text = Convert.ToString(rowview["VisitorName"]);
                DropDownList1.SelectedValue = Convert.ToString(rowview["Sex"]);
                txtRealName.Text = Convert.ToString(rowview["ReallyName"]);
                txtBirthday.Text = Convert.ToString(rowview["Birthday"]);
                txtAddress.Text = Convert.ToString(rowview["Address"]);
                txtPostCode.Text = Convert.ToString(rowview["PostCode"]);
                txtEmail.Text = Convert.ToString(rowview["Email"]);
                txtHphone.Text = Convert.ToString(rowview["HomePhone"]);
                txtMphone.Text = Convert.ToString(rowview["MobilePhone"]);
                txtQQ.Text = Convert.ToString(rowview["QQ"]);
                txtICQ.Text = Convert.ToString(rowview["ICQ"]);
                mycon.Close();
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReplyManage2.aspx");
    }
}