using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class AgreementReport : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;



    Report obj_Class = new Report();
    DataTable dt = new DataTable();
    DataTable dt_Clients = new DataTable();
    string[] Client;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadClients();
            dt = obj_Class.Bizconnect_AgreementReport();
            grd_AgreementReport.DataSource = dt;
            grd_AgreementReport.DataBind();
            ChkAuthentication();
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
    public void LoadClients()
    {
        dt_Clients = obj_Class.Bizconnect_LoadAgreementReportClients();
        ddl_Client.DataSource = dt_Clients;
        ddl_Client.DataTextField = "CompanyName";
        ddl_Client.DataValueField = "CompanyName";
        ddl_Client.DataBind();
        ddl_Client.Items.Insert(0, "--Select--");
    }

    protected void ddl_Client_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt.Clear();
        Client = ddl_Client.SelectedValue.ToString().Split('-');
        dt = obj_Class.Bizconnect_AgreementReportSearch(Client[0]);
        grd_AgreementReport.DataSource = dt;
        grd_AgreementReport.DataBind();
    }
}