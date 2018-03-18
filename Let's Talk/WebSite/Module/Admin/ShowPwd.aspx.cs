using System;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Admin_Pwd : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SqlData da = new SqlData();
            SqlDataReader read = da.ExceRead("select * from tb_Admin where ID='" + Session["pwd"] + "'");
            while (read.Read())
            {
                txtPwd.Text = read["PassWord"].ToString();
            }
            read.Close();
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("Index.aspx");
    }

    protected void btnChange_Click(object sender, EventArgs e)
    {
        string P_str_Com = "update tb_Admin set PassWord='" + txtOKpwd.Text + "' where ID='" + Session["pwd"] + "'";
        SqlData da = new SqlData();
        bool add = da.ExceSQL(P_str_Com);
        if (add)
        {
            Response.Write("<script language=javascript>alert('修改成功!');location='Index.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('修改失败！');location='javascript:history.go(-1)'</script>");
        }
    }
}