using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Admin_ReplyInfo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SqlConnection sqlconn = new SqlConnection(ConfigurationSettings.AppSettings["conStr"]);
        if (!IsPostBack)
        {
            sqlconn.Open();
            string strid = Page.Request.QueryString["ST_r_id"];
            string sqlstr = "select * from ST_replay where ST_r_id='" + strid + "'";
            SqlDataAdapter myda = new SqlDataAdapter(sqlstr, sqlconn);
            DataSet myds = new DataSet();
            myda.Fill(myds, "ST_replay");
            DataRowView mydrv = myds.Tables["ST_replay"].DefaultView[0];
            txtGID.Text = Convert.ToString(mydrv.Row["ST_r_id"]);
            txtGName.Text = Convert.ToString(mydrv.Row["ST_r_nick"]);
            txtGType.Text = Convert.ToString(mydrv.Row["ST_r_title"]);
            txtGStore.Text = Convert.ToString(mydrv.Row["ST_r_date"]);
            txtGIntro.Text = Convert.ToString(mydrv.Row["ST_r_content"]) + "…";
        }
    }
}