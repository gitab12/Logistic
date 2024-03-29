﻿using System;
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

public partial class AARMSDashboard : System.Web.UI.Page
{
    BizConnectClass obj_Class = new BizConnectClass();
    DataSet ds = new DataSet();
        DataTable dt = new DataTable();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ShowAARMSDashboard();
            ChkAuthentication();
            Load_ClientName();
        }
    }

public void Load_ClientName()
    {
        dt = obj_Class.Get_AARMSDashBoardClientname();
        ddl_ClientName.DataSource = dt;
        ddl_ClientName.DataTextField = "CompanyName";
        ddl_ClientName.DataValueField = "ClientID";
        ddl_ClientName.DataBind();
        ddl_ClientName.Items.Insert(0, "--All--");
    }

    public void ShowAARMSDashboard()
    {
        ds.Clear();
        ds = obj_Class.AARMSDashBoard();
        Gridwindow.DataSource = ds;
        Gridwindow.DataBind();
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
    
    
     protected void ddl_ClientName_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt.Clear();
        dt = obj_Class.Search_AARMSDashBoardByClientname(ddl_ClientName .SelectedItem .Text);
        Gridwindow.DataSource = dt;
        Gridwindow.DataBind();
    }
    
}
