using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        Thread.Sleep(5000);
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Loading Is working!!');</script>");
        lbl_msg_advice.Text = "Hello";
    }
}