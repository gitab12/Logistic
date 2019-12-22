using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UnloadingTruckFrontImage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["UnImgID"].ToString()) < 0)
            {
                Session["UnImgID"] = Request.QueryString["ImgID"].ToString();
            }
            FrontView.ImageUrl = "UnloadImageHandler.ashx?ImgID=" + Session["UnImgID"].ToString();
            imgID.ImageUrl = "UnloadImageHandler.ashx?ImgID=" + Session["UnImgID"].ToString();
            Session["UnImgID"] = "0";
        }
        catch (Exception ex)
        {
        }
    }
}