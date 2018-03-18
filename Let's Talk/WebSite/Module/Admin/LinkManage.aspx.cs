using System;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Module_Blog_LinkManage : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*判断是否登录*/
        ST_check_Login();
        SqlData da = new SqlData();
        //调用公共类中的ExceDS方法执行SQL语句
        GridView1.DataSource = da.ExceDS("select * from ST_link");
        GridView1.DataKeyNames = new[] {"ST_l_id"};
        GridView1.DataBind();
    }

    public void ST_check_Login()
    {
        if ((Session["UserName"] == null))
        {
            Response.Write("<script>alert('对不起！您还没注册，请先注册再登录！');location='../../BlogIndex.aspx'</script>");
            Response.End();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SqlData da = new SqlData();
        string search = ddlSearch.SelectedValue;
        switch (search)
        {
            case "地址ID":
                da.BindData(GridView1, "Select * From ST_link Where ST_l_id  Like  '%" + txtKey.Text + "%'");
                break;
            case "网站名称":
                da.BindData(GridView1, "Select * From ST_link Where ST_l_name  Like  '%" + txtKey.Text + "%'");
                break;
            case "链接网址":
                da.BindData(GridView1, "Select * From ST_link Where ST_l_url  Like  '%" + txtKey.Text + "%'");
                break;
            default:
                Response.Write("<script lanuage=javascript>alert('查询失败！');location='javascript:history.go(-1)'</script>");
                break;
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        SqlData da = new SqlData();
        da.ExceSQL("delete from ST_link where ST_l_id='" + GridView1.DataKeys[e.RowIndex].Value + "'");
        Page.Response.Redirect("LinkManage.aspx");
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridView1.DataBind();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if ((e.Row.Cells[1].Text).Length > 6)
            {
                e.Row.Cells[1].Text = (e.Row.Cells[1].Text).Substring(0, 6) + "…";
            }
            if ((e.Row.Cells[0].Text).Length > 6)
            {
                e.Row.Cells[0].Text = (e.Row.Cells[0].Text).Substring(0, 6) + "…";
            }
            if ((e.Row.Cells[0].Text).Length > 6)
            {
                e.Row.Cells[0].Text = (e.Row.Cells[0].Text).Substring(0, 6) + "…";
            }
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ((LinkButton) (e.Row.Cells[4].Controls[0])).Attributes.Add("onclick", "return confirm('确定删除吗？')");
        }
    }

    protected void lnkbtnAdd_Click(object sender, EventArgs e)
    {
    }
}