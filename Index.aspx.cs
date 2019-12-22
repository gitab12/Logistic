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

public partial class Index : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    UserControl obj_left;
    protected void Page_Load(object sender, EventArgs e)
    {
       // Response.Redirect("http://www.scmbizconnect.com/scm/scmbizconnect/index.html");

        if (Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (Convert.ToInt32(Session["UserID"].ToString()) != 2)
            {
                if (Convert.ToInt32(Session["ClientID"].ToString()) == 1129)
                {
                    Response.Redirect("Biddingstatus.aspx");
                }
                else
                {
                    Response.Redirect("Dashboard.aspx");
                }
            }
            else
            {
                Response.Redirect("AArmsDashboard.aspx");
            }
        }
        ChkAuthentication();
    }

    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        obj_Navi = null;
        obj_Navihome = null;

        obj_Authenticated = Session["Authenticated"].ToString();
        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("right1");
           
            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");

               // obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
                //obj_Navihome = (UserControl)obj_Tabs.FindControl("Navihome1");
               

                if (obj_LoginCtrl != null & obj_WelcomCtrl!= null)
                {
                    if (obj_Authenticated == "1")
                    {
                        SetVisualON();
                       
                      
                    }
                    else
                    {
                        SetVisualOFF();
                       
                    }


                }
            }
            else
            {

            }
        }
        else
        {

        }
    }
    public void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
        Response.Redirect("Dashboard.aspx");
        //obj_Navi.Visible = true;
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
       obj_WelcomCtrl.Visible = false;
     
      // obj_Navi.Visible = true;
       //obj_Navihome.Visible = false;
    }
}
