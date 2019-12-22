using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CollectionNotePrint : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
          
                Session["ImageID"] = Request.QueryString["ImageID"].ToString();
            
            BillImage.ImageUrl = "CollectionNoteImage.ashx?ImageID=" + Session["ImageID"].ToString();
            Session["ImageID"] = "0";
        }
        catch (Exception ex)
        {
        }
    }
}
