using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Module_Admin_AdminMagage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        gvBlog.DataSource = da.ExceDS("select * from tb_Blog");
        gvBlog.DataKeyNames = new[] {"BlogID"};
        gvBlog.DataBind();
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        string search = ddlSearch.SelectedValue;
        switch (search)
        {
            case "博客ID":
                da.BindData(gvBlog, "Select * From tb_Blog Where BlogID  Like  '%" + txtKey.Text + "%'");
                break;
            case "博客姓名":
                da.BindData(gvBlog, "Select * From tb_Blog Where UserName  Like  '%" + txtKey.Text + "%'");
                break;
            case "QQ":
                da.BindData(gvBlog, "Select * From tb_Blog Where QQ  Like  '%" + txtKey.Text + "%'");
                break;
            default:
                Response.Write("<script lanuage=javascript>alert('出错拉！');location='javascript:history.go(-1)'</script>");
                break;
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlData da = new SqlData();
        da.ExceSQL("delete from tb_Blog where BlogID='" + gvBlog.DataKeys[e.RowIndex].Value + "'");
        Response.Redirect("BlogManage.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvBlog.PageIndex = e.NewPageIndex;
        gvBlog.DataBind();
    }

    protected void gvBlog_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton) (e.Row.Cells[6].Controls[0])).Attributes.Add("onclick", "return confirm('确定删除吗？')");
        }
    }
}