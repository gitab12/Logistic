using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class MyTripPlan_Details : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            ChkAuthentication();
            GetData();
        }
    }

    private void GetData()
    {
        try
        {
            string userid=Session["UserID"].ToString();
            if (userid != "")
            {
                string planid = Request.QueryString["LPid"].ToString();

                string[] args = { "@Userid", "@planid" };
                string[] argsval = { userid, planid };
                DataSet ds = new DataSet();
                ds = con.Sql_GetData("SP_Get_Details_for_Trip", args, argsval);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    LblPlanno.Text = ds.Tables[0].Rows[0]["Planno"].ToString();
                    Lbltraveldate.Text = ds.Tables[0].Rows[0]["TravelDate"].ToString();
                    Lblsource.Text = ds.Tables[0].Rows[0]["Source"].ToString();
                    LblDesination.Text = ds.Tables[0].Rows[0]["Desination"].ToString();
                    Lblnooftrucks.Text = ds.Tables[0].Rows[0]["Truckcount"].ToString();
                    LblTrucktype.Text = ds.Tables[0].Rows[0]["TruckType"].ToString();
                    Lbltraveltype.Text = ds.Tables[0].Rows[0]["TravelType"].ToString();
                    Lblpostedon.Text = ds.Tables[0].Rows[0]["Postedon"].ToString();
                    Lblproductname.Text = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    LblQuantity.Text = ds.Tables[0].Rows[0]["QuantityPerTruck"].ToString();
                    Lblcostpertruck.Text = ds.Tables[0].Rows[0]["CostPerTruck"].ToString();
                    Lblvolume.Text = ds.Tables[0].Rows[0]["Volume"].ToString();
                    Lblweight.Text = ds.Tables[0].Rows[0]["Weight"].ToString();
                    Lbllength.Text = ds.Tables[0].Rows[0]["Length"].ToString();
                    Lblwidth.Text = ds.Tables[0].Rows[0]["Width"].ToString();
                    Lblheight.Text = ds.Tables[0].Rows[0]["Height"].ToString();
                    if (ds.Tables[0].Rows[0]["EnclosureTypeID"].ToString() == "1")
                        lblEncl.Text = "Open";
                    else
                    {
                        lblEncl.Text = "Closed";
                        
                    }
                    lblTransit.Text = ds.Tables[0].Rows[0]["TransitDay"].ToString();

                }
                
            }
            else
            {

            }

        }
        catch(Exception ex)
        {

        }
        finally

        {


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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }
}