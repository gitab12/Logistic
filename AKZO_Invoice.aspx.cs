using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AKZO_Invoice : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Image1.ImageUrl = "AKZO_Invoice_Handler.ashx?ImageID=" + Request.QueryString["Invoice"] + "";
    }
}