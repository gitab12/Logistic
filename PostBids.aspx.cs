using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class PostBids : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass obj_class = new BizConnectClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    public void Bind()
    {
        LblFrom.Text = Request.QueryString["from"].ToString();
        LbTo.Text = Request.QueryString["to"].ToString();
        Lbltrucktype.Text = Request.QueryString["trucktype"].ToString();
        Lblcapacity.Text = Request.QueryString["capacity"].ToString();
        Lblrouteprice.Text = Request.QueryString["price"].ToString();
        txtbidprice.Text = Request.QueryString["price"].ToString();

    }
    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        int t = Convert.ToInt32(Request.QueryString["TID"].ToString());
        int u = Convert.ToInt32(Session["UserID"].ToString());
        int cl = Convert.ToInt32(Request.QueryString["clientid"].ToString());

        int resp = obj_class.InsertReBid(LblFrom.Text, LbTo.Text, Lbltrucktype.Text, Lblcapacity.Text, txttrucksreq.Text, Lblrouteprice.Text, txtbidprice.Text, Convert.ToInt32(Request.QueryString["TID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(Request.QueryString["clientid"].ToString()), txtremarks.Text);
        if (resp == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Quoted Successfully!');", true);

        }
    }




    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        obj_Navi = null;
        obj_Navihome = null;

        if (Session["Authenticated"] == null)
        {
            Session["Authenticated"] = "0";
        }
        else
        {
            obj_Authenticated = Session["Authenticated"].ToString();
        }


        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("loginheader1");

            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");

                // obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
                //obj_Navihome = (UserControl)obj_Tabs.FindControl("Navihome1");


                if (obj_LoginCtrl != null & obj_WelcomCtrl != null)
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