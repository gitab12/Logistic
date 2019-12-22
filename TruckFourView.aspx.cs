using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TruckFourView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Convert.ToInt32(Session["ImageID"].ToString()) < 0)
            {
                Session["ImageID"] = Request.QueryString["imgID"].ToString();
            }
            FrontView.ImageUrl = "ImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            imgID.ImageUrl = "ImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            RearView.ImageUrl = "RearImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            imgID0.ImageUrl = "RearImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            LeftView.ImageUrl = "LeftImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            imgID1.ImageUrl = "LeftImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            RightView.ImageUrl = "RightImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            imgID2.ImageUrl = "RightImageHandler.ashx?ImageID=" + Session["ImageID"].ToString();
            Session["ImageID"] = "0";
        }
        catch (Exception ex)
        {
        }
    }
}
