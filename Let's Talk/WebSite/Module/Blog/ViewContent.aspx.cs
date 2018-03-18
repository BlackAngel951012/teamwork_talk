using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Blog_ReplayContent : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserName"] == null)
        //{
        //    Response.Redirect("~/BlogIndex.aspx");
        //}
        if (!IsPostBack)
        {
            try
            {
                string str;
                string str2 = Page.Request["id"];
                //此处用来实现将数据绑定到前台
                SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                mycon.Open();
                SqlDataAdapter myada = new SqlDataAdapter("select * from ST_news where ST_n_id='" + str2 + "'", mycon);
                DataSet ds = new DataSet();
                myada.Fill(ds, "ST_news");
                //创建DataRowView对象的一个实例
                DataRowView rowview = ds.Tables["ST_news"].DefaultView[0];
                //将文章主题读取到labSubject文本框中
                labSubject.Text = rowview["ST_n_title"].ToString();
                //将文章内容读取到txtContent文本框中
                txtContent.Text = rowview["ST_n_content"].ToString();
                mycon.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtContent.Text))
        {
            string id = Request["id"];
            string Com = "update ST_news set ST_n_content='" + txtContent.Text + "' where ST_n_id='" + id + "'";
            //创建公共类SqlData的一个新的实例对象
            SqlData da = new SqlData();
            bool update = da.ExceSQL(Com);
            if (update)
            {
                Response.Write("<script language=javascript>alert('修改成功！');location='ArticleManage.aspx'</script>");
            }
            else
            {
                Response.Write("<script language=javascript>alert('修改失败！');</script>");
            }
        }
    }

    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("ArticleManage.aspx");
    }
}