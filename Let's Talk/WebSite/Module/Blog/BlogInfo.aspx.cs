using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Admin_BlogInfo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null)
        {
            Response.Redirect("../../BlogIndex.aspx");
        }
        if (!IsPostBack)
        {
            SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            SqlDataAdapter mydataadapter = new SqlDataAdapter(
                "select * from tb_Blog where BlogID=" + Request["BlogID"], mycon);
            DataSet ds = new DataSet();
            mydataadapter.Fill(ds, "tb_Blog");
            DataRowView rowview = ds.Tables["tb_Blog"].DefaultView[0];
            txtName.Text = Convert.ToString(rowview["UserName"]);
            txtPwd.Text = Convert.ToString(rowview["PassWord"]);
            ddlSex.SelectedValue = Convert.ToString(rowview["Sex"]);
            txtRealName.Text = Convert.ToString(rowview["ReallyName"]);
            txtBirthday.Text = Convert.ToString(rowview["Birthday"]);
            txtAddress.Text = Convert.ToString(rowview["Address"]);
            txtSubject.Text = Convert.ToString(rowview["Subject"]);
            txtPostCode.Text = Convert.ToString(rowview["PostCode"]);
            txtQues.Text = Convert.ToString(rowview["Question"]);
            txtAns.Text = Convert.ToString(rowview["Answer"]);
            txtEmail.Text = Convert.ToString(rowview["Email"]);
            txtHphone.Text = Convert.ToString(rowview["HomePhone"]);
            txtMphone.Text = Convert.ToString(rowview["MobilePhone"]);
            txtQQ.Text = Convert.ToString(rowview["QQ"]);
            txtICQ.Text = Convert.ToString(rowview["ICQ"]);
            TextBox1.Text = Convert.ToString(rowview["RegTime"]);
            txtIP.Text = Convert.ToString(rowview["IP"]);
            mycon.Close();
        }
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        string P_str_Com = "update tb_Blog set UserName='" + txtName.Text + "',PassWord='" + txtOKpwd.Text + "'"
                           + ",Sex='" + ddlSex.SelectedValue + "',ReallyName='" + txtRealName.Text + "'"
                           + ",Birthday='" + txtBirthday.Text + "',Email='" + txtEmail.Text + "',HomePhone='" +
                           txtHphone.Text + "'"
                           + ",MobilePhone='" + txtMphone.Text + "',PostCode='" + txtPostCode.Text + "',QQ='" +
                           txtQQ.Text + "'"
                           + ",ICQ='" + txtICQ.Text + "',Address='" + txtAddress.Text + "',Answer='" + txtAns.Text + "'"
                           + ",Subject='" + txtSubject.Text + "',Question='" + txtQues.Text + "'"
                           + " where BlogID='" + Request["BlogID"] + "'";
        bool add = da.ExceSQL(P_str_Com);
        if (add)
        {
            Response.Write("<script language=javascript>alert('信息修改成功!');location='Index.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('信息修改失败！');location='javascript:history.go(-1)'</script>");
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Index.aspx");
    }
}