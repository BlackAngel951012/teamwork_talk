using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;

public partial class Module_Blog_LinkManInfo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserName"] == null)
        //{
        //    Response.Redirect("../../Index.aspx");
        //}
        if (!IsPostBack)
        {
            SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            SqlDataAdapter mydataadapter =
                new SqlDataAdapter("select * from tb_Message where MessageID=" + Request["id"], mycon);
            DataSet mydataset = new DataSet();
            mydataadapter.Fill(mydataset, "tb_Message");
            DataRowView rowview = mydataset.Tables["tb_Message"].DefaultView[0];
            txtName.Text = Convert.ToString(rowview["FriendName"]);
            DropDownList1.SelectedValue = Convert.ToString(rowview["Sex"]);
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

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        string P_str_Com = "update tb_Message set FriendName='" + txtName.Text + "'"
                           + ",Sex='" + DropDownList1.SelectedValue + "',MobilePhone='" + txtMphone.Text +
                           "',PostCode='" + txtPostCode.Text + "'"
                           + ",Birthday='" + txtBirthday.Text + "',Email='" + txtEmail.Text + "',HomePhone='" +
                           txtHphone.Text + "'"
                           + ",ICQ='" + txtICQ.Text + "',Address='" + txtAddress.Text + "',QQ='" + txtQQ.Text + "'"
                           + " where MessageID='" + Request["ID"] + "'";
        if (!ValidateDate1(txtBirthday.Text) && !ValidateDate2(txtBirthday.Text) && !ValidateDate3(txtBirthday.Text))
        {
            Response.Write(
                "<script language=javascript>alert('输入的日期格式有误！');location='javascript:history.go(-1)'</script>");
        }
        bool add = da.ExceSQL(P_str_Com);
        if (add)
        {
            Response.Write("<script language=javascript>alert('修改成功!');location='LinkManManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('修改失败！');location='javascript:history.go(-1)'</script>");
        }
    }

    public bool ValidateDate1(string input)
    {
        return Regex.IsMatch(input, "\\b(?<year>\\d{2,4})/(?<month>\\d{1,2})/(?<day>\\d{1,2})\\b");
    }

    public bool ValidateDate2(string input)
    {
        return Regex.IsMatch(input, "\\b(?<year>\\d{2,4})-(?<month>\\d{1,2})-(?<day>\\d{1,2})\\b");
    }

    public bool ValidateDate3(string input)
    {
        return Regex.IsMatch(input, "\\b(?<year>\\d{2,4})年(?<month>\\d{1,2})月(?<day>\\d{1,2})日\\b");
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("LinkManManage.aspx");
    }
}