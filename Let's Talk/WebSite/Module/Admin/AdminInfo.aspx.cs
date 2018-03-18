using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class Module_Admin_AdminInfo : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session["UserName"] == null)
        //{
        //    Response.Redirect("../../Index.aspx");
        //}

        if (!IsPostBack)
        {
            try
            {
                SqlConnection mycon = new SqlConnection(ConfigurationManager.AppSettings["conStr"]);
                mycon.Open();
                DataSet mydataset = new DataSet();
                SqlDataAdapter mydataadapter = new SqlDataAdapter("select * from tb_Admin where id=" + Request["id"],
                                                                  mycon);
                mydataadapter.Fill(mydataset, "tb_Admin");
                DataRowView rowview = mydataset.Tables["tb_Admin"].DefaultView[0];
                txtName.Text = Convert.ToString(rowview["UserName"]);
                txtPwd.Text = Convert.ToString(rowview["PassWord"]);
                ddlSex.SelectedValue = Convert.ToString(rowview["Sex"]);
                txtRealName.Text = Convert.ToString(rowview["ReallyName"]);
                txtBirthday.Text = Convert.ToString(rowview["Birthday"]);
                txtAddress.Text = Convert.ToString(rowview["Address"]);
                txtPostCode.Text = Convert.ToString(rowview["PostCode"]);
                txtQues.Text = Convert.ToString(rowview["Question"]);
                txtAns.Text = Convert.ToString(rowview["Answer"]);
                txtEmail.Text = Convert.ToString(rowview["Email"]);
                txtHphone.Text = Convert.ToString(rowview["HomePhone"]);
                txtMphone.Text = Convert.ToString(rowview["MobilePhone"]);
                txtQQ.Text = Convert.ToString(rowview["QQ"]);
                txtICQ.Text = Convert.ToString(rowview["ICQ"]);
                TextBox1.Text = Convert.ToString(rowview["RegTime"]);
                DropDownList1.SelectedValue = Convert.ToString(rowview["SuperAdmin"]);
                txtIP.Text = Convert.ToString(rowview["IP"]);
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
        try
        {
            SqlData da = new SqlData();
            string P_str_Com = "update tb_Admin set UserName='" + txtName.Text + "',PassWord='" + txtOKpwd.Text + "'"
                               + ",Sex='" + ddlSex.SelectedValue + "',ReallyName='" + txtRealName.Text + "'"
                               + ",Birthday='" + txtBirthday.Text + "',Email='" + txtEmail.Text + "',HomePhone='" +
                               txtHphone.Text + "'"
                               + ",MobilePhone='" + txtMphone.Text + "',PostCode='" + txtPostCode.Text + "',QQ='" +
                               txtQQ.Text + "'"
                               + ",ICQ='" + txtICQ.Text + "',Address='" + txtAddress.Text + "',Answer='" + txtAns.Text +
                               "',Question='" + txtQues.Text + "',SuperAdmin='" + DropDownList1.SelectedValue + "'"
                               + " where ID='" + Request["ID"] + "'";
            bool add = da.ExceSQL(P_str_Com);
            if (add)
            {
                Response.Write("<script language=javascript>alert('修改信息成功!');location='AdminManage.aspx'</script>");
            }
            else
            {
                Response.Write(
                    "<script language=javascript>alert('修改信息失败！');location='javascript:history.go(-1)'</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


    protected void txtBack_Click(object sender, EventArgs e)
    {
        Page.Response.Redirect("AdminManage.aspx");
    }
}