using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TruckImage : System.Web.UI.Page
{
private double swift = 10;
    protected void Page_Load(object sender, EventArgs e)
    {
    if (!IsPostBack)
        {
        try
        {
            if (Convert.ToInt32(Session["ImageID"].ToString()) < 0)
            {
                Session["ImageID"] = Request.QueryString["imgID"].ToString();
            }
            TruckImagebox.ImageUrl = "ImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            Session["ImageID"] = "0";
        }
        catch (Exception ex)
        {
        }
    }
}


public void ChangeSize(object sender, EventArgs e)
    {
            
        double w = this.TruckImagebox.Width.Value;
        double h = this.TruckImagebox.Height.Value;
        Button button = sender as Button;
        if (button.CommandName.Equals("ZI"))
        {
            h += swift;
            w += swift;
        }
        else if (button.CommandName.Equals("ZO"))
        {
            w -= swift;
            h -= swift;
        }
        this.TruckImagebox.Height = new Unit(h);
        this.TruckImagebox.Width = new Unit(w);
    }        

}