using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Clear();
        Session["Authenticated"] = 0;
        Session["name"] = "Guest";
        Session["UserID"] = 0;

        Response.Redirect("Index.html");
    }
}