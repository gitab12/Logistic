using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BillPreview : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
           if(Convert.ToInt32 (Session["ImageID"].ToString())<0)
            {
          Session["ImageID"] = Request.QueryString["imgID"].ToString();
           }
            BillImage.ImageUrl = "BillImage.ashx?ImageID=" + Session["ImageID"].ToString();
            Session["ImageID"] = "0";
        }
        catch (Exception ex)
        {
        }
    }
}
