using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Masterpages_SiteMaster : System.Web.UI.MasterPage
{
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string user_name = Session["EmailID"].ToString();
            string[] args = { "@username" };
            string[] argval = { user_name };
            DataSet ds = new DataSet();
            ds = con.Sql_GetData("SP_User_Login_Details", args, argval);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string username = ds.Tables[0].Rows[0]["username"].ToString();
                string role_id = ds.Tables[0].Rows[0]["role_id"].ToString();
                string name = ds.Tables[0].Rows[0]["name"].ToString();
                string department_id = ds.Tables[0].Rows[0]["department_id"].ToString();
                string user_id = ds.Tables[0].Rows[0]["user_id"].ToString();
                string email = ds.Tables[0].Rows[0]["email"].ToString();
                string userimage = ds.Tables[0].Rows[0]["image"].ToString();
                string department_name = ds.Tables[0].Rows[0]["department_name"].ToString();
                string role_name = ds.Tables[0].Rows[0]["role_name"].ToString();
                img_profile.ImageUrl = "~/" + userimage;
                img_profile2.ImageUrl = "~/" + userimage;
                spam_username.Text = name;
                lbldepartmant.Text = department_name;
                lblusername.Text = name;
                img_profile3.ImageUrl = "~/" + userimage;
                lbl_username2.Text = name;
            }
            //else
            //{
            //    img_profile.ImageUrl = "";
            //    img_profile2.ImageUrl = "";
            //    spam_username.Text = "";
            //    lbldepartmant.Text = "";
            //    lblusername.Text = "";
            //    img_profile3.ImageUrl = "";
            //    lbl_username2.Text = "";
            //}
        }
        catch (Exception ex)
        {
            Response.Redirect("LoginAdmin.aspx?expire=1");
        }
    }
}
