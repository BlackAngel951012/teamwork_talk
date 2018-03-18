using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Admin_Findpwd : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select * from tb_Admin where UserName='" + Session["Name"] + "'");
        read.Read();
        if (read.HasRows)
        {
            txtQues.Text = read["Question"].ToString();
        }
        else
        {
            Response.Write("<script language=javascript>alert('此用户不存在！');location='Findpwd1.aspx'</script>");
        }
        read.Close();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("~/Module/Admin/Index.aspx");
    }

    protected void btnOK_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        SqlDataReader read = da.ExceRead("select * from tb_Admin where UserName='" + Session["Name"] + "'");
        read.Read();
        if (txtQues.Text == read["Question"].ToString() && txtAns.Text == read["Answer"].ToString())
        {
            Session["pwd"] = read["ID"].ToString();
            Page.Response.Redirect("ShowPwd.aspx");
        }
        else
        {
            Response.Write("<script language=javascript>alert('您输入的信息不正确，请重新输入！');</script>");
        }
        read.Close();
    }
}