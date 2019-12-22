using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Home : System.Web.UI.Page
{

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lblName.Text = "Welcome : " +
                          " " + Session["name"].ToString();
            }
            catch (Exception ex)
            {

            }
        }
        //protected void Butsignout_Click(object sender, EventArgs e)
        //{
        //    Session.Clear();
        //    Session["Authenticated"] = 0;
        //    Session["name"] = "Guest";
        //    Session["UserID"] = 0;

        //    Response.Redirect("Index.aspx");
        //}
    
}