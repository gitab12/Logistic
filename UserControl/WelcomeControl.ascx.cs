using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControl_WelcomeControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            lblName.Text = "Hi , " +
                      " " + Session["name"].ToString();
            this.lblName.ForeColor = Color.Blue;
        }
        catch (Exception ex)
        {

        }
    }
}