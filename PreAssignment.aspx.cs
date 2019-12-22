using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;

public partial class PreAssignment : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    String obj_ClientID, obj_ClientCode, obj_ClientName;

    Int32 obj_Resp = 0;
    Int32 obj_LocationTypeID = 0;


    DateTime obj_TripDate;
    DateTime obj_LastDateForQuote;
    DateTime obj_LastDateForClosingDeal;
    Int32 obj_LogisticsPlanID;

    BizConnectDealProcess obj_BizConnectDealProcessClass = new BizConnectDealProcess();
    DataSet ds = new DataSet();
    String obj_AdID,obj_LogisticsPlanNo;

    //Page Load
    protected void Page_Load(object sender, EventArgs e)
    {
    
     if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {

        if (IsPostBack == false)
        {
            Bind();

        }
        else
        {
            //Executing from Script
            string arg = Request.Form["__EVENTTARGET"];
            string val = Request.Form["__EVENTARGUMENT"];
            if( arg == "BindWindow" )
            {
                BindWindow();
            }
       }
       }
       
        else
        {
            Response.Redirect("Index.html");
        }
    }

    public void Bind()
    {
        try
        {
            ChkAuthentication();
            //Session["UserID"] = 1;
            ds.Clear();
            ds = obj_BizConnectDealProcessClass.get_Assignment(Convert.ToInt32(Session["UserID"].ToString()));
            GridAssign.DataSource = ds;
           GridAssign.DataMember = "Assignment";
            GridAssign.DataBind();
            RemoveDuplicates();
        }
        catch
        {
        }
    }

    //Remove Duplicates in Gridview
    public void RemoveDuplicates()
    {
        String obj_TempAdID;
        obj_TempAdID = "Nil";
        Session.Add("obj_TempAdID", obj_TempAdID);
        foreach (GridViewRow row in GridAssign.Rows)
        {
            TextBox txtAdID = (TextBox)row.FindControl("txtAdID");
            if (Session["obj_TempAdID"].ToString() != txtAdID.Text.Trim())
            {
                Session["obj_TempAdID"] = txtAdID.Text.Trim();
            }
            else
            {
                row.Visible = false;
            }

        }
    }
  
    //Adding AdId to Session
    public void BindWindow()
    {
        if (hdf_AdID.Value != "")
        {
            obj_AdID=hdf_AdID.Value.ToString().Trim();
            Session["AdID"] = obj_AdID;
            obj_LogisticsPlanNo = hdf_LogisticsPlanNo.Value.ToString().Trim();
            Session["LogisticsPlanNo"] = obj_LogisticsPlanNo;
        }
    }

    //Authentication Section
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