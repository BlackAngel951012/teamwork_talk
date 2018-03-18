using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Blog_AmendLink : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserName"] == null && Session["PassWord"] == null)
        {
            Response.Redirect("~/BlogIndex.aspx");
        }
        if (!IsPostBack)
        {
            SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
            SqlDataAdapter mydataadapter = new SqlDataAdapter("select * from ST_link where ST_l_id=" + Request["id"],
                                                              mycon);
            DataSet mydataset = new DataSet();
            mydataadapter.Fill(mydataset, "ST_link");
            DataRowView rowview = mydataset.Tables["ST_link"].DefaultView[0];
            txtName.Text = Convert.ToString(rowview["ST_l_name"]);
            txtUrl.Text = Convert.ToString(rowview["ST_l_url"]);
            mycon.Close();
        }
    }

    protected void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("LinkManage.aspx");
    }

    protected void btnAmend_Click(object sender, EventArgs e)
    {
        string P_str_Com = "update ST_link set ST_l_name='" + txtName.Text + "',ST_l_url='" + txtUrl.Text +
                           "' where ST_l_id='" + Request["ID"] + "'";
        SqlData da = new SqlData();
        bool add = da.ExceSQL(P_str_Com);
        if (add)
        {
            Response.Write("<script language=javascript>alert('修改链接成功!');location='LinkManage.aspx'</script>");
        }
        else
        {
            Response.Write("<script language=javascript>alert('修改链接失败！');location='javascript:history.go(-1)'</script>");
        }
    }
}