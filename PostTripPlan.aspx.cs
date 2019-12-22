using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExponantAARMSMS;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Text;
using AARMEmail;
using System.Web.Services;
public partial class PostTripPlan : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClient bizcl = new BizConnectClient();
    TripAgreementClass Trip_Agreement = new TripAgreementClass();
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();
    ClassPostAd obj_ClassPostAd = new ClassPostAd();
    BizConnectClass obj_class = new BizConnectClass();
    DataSet ds;
    DataTable dt;
    string tableheader, body;
    ArrayList arr = new ArrayList();
     AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    protected void Page_Load(object sender, EventArgs e)
    {
    
     if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
            ChkAuthentication();

            txtfrom.Attributes.Add("onkeyUp", "SearchAddressByGoogle('" + txtfrom.ClientID + "',event);");
            txtTo.Attributes.Add("onkeyUp", "SearchAddressByGoogle('" + txtTo.ClientID + "',event);");

            FillEnclosureType();
            FillTruckType();
            clear();
        }
        }
        
            else
        {
            Response.Redirect("Index.html");
        }
    }

    public void FillTruckType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillTruckType();
        if (ds.Tables["TruckType"].Rows.Count > 0)
        {
            DDLTruckType.Items.Clear();
            DDLTruckType.DataSource = ds.Tables["TruckType"];
            DDLTruckType.DataTextField = "TruckType";
            DDLTruckType.DataValueField = "TruckTypeID";
            DDLTruckType.DataBind();
            DDLTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
        }

    }

    public void FillEnclosureType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillEnclosureType();
        if (ds.Tables["EnclosureType"].Rows.Count > 0)
        {
            DDLEnclType.Items.Clear();
            DDLEnclType.DataSource = ds.Tables["EnclosureType"];
            DDLEnclType.DataTextField = "EnclosureType";
            DDLEnclType.DataValueField = "EnclosureTypeID";
            DDLEnclType.DataBind();
            DDLEnclType.Items.Insert(0, new ListItem("--- Enclosure Type ---", "0"));
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
      

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
       
    }

    public void PostAd()
    {
        try
        {
            string obj_AdID = "";
            
            Session["LoginID"] = Session["UserID"].ToString();
            DateTime dtt =   Convert.ToDateTime(txttravelDate.Text);
            string date = dtt.ToString("dd-MMM-yyyy");
            obj_AdID = AdIDProcess(txtfrom.Text, txtTo.Text, date.ToString());
            DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

            obj_TravelDate = Convert.ToDateTime(date.ToString());

            obj_DateOfExpiry = obj_TravelDate; //Remove =obj_TravelDate if u Uncomment Expiry Date in Script and use following commented statements also->  //DateTime.Parse(DateOfExpiry, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
            obj_LastDate = obj_TravelDate; // DateTime.Parse(LastDateForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

            int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["LoginID"].ToString()), 1, 0, "0", 1, txtfrom.Text, txtTo.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, txtgoods.Text , 0, 1, 0, 0, Convert.ToInt32(txtprice.Text), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(txtnooftruck.Text), 0, Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, 0,Convert.ToInt32(txtcapacity.Text), 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), txtremarks.Text, 1, 0, 0,"", Convert.ToInt32(txtprice.Text));

        }

        catch (Exception ex)
        {
        }
    }

    public string AdIDProcess(string obj_FromLocation, string obj_ToLocation, string obj_TravelDte)
    {
        Int32 obj_ID = 0;
        string obj_Temp = "";
        string obj_From, obj_To;
        String obj_PostAdType = "Nil";
        DateTime obj_TravelDt;

        obj_PostAdType = "VW";

        obj_TravelDt = DateTime.Parse(obj_TravelDte, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
        if (Session["obj_ID"] == null)
        {
            arr.Clear();
            arr = obj_ClassPostAd.get_PostID();

            if (arr[0].ToString() != "0")
            {
                obj_ID = Convert.ToInt32(arr[1]);
                obj_ID += 1;
                Session["obj_ID"] = obj_ID;
                Session["GroupID"] = obj_ID;
            }
            else if (arr[0].ToString() != "1")
            {
                obj_ID = 1000;
                Session["obj_ID"] = obj_ID;
                Session["GroupID"] = obj_ID;
            }
        }
        else if (Session["obj_ID"] != null)
        {
            obj_ID = Convert.ToInt32(Session["obj_ID"]);
            obj_ID += 1;
            Session["obj_ID"] = obj_ID;
        }
        obj_From = obj_FromLocation.Trim();
        obj_To = obj_ToLocation.Trim();
        obj_Temp = "#" + obj_From.Substring(0, 3) + "-" + obj_To.Substring(0, 3) + obj_TravelDt.ToString("-" + "MMyyyy") + "-" + obj_PostAdType + "-" + obj_ID.ToString();
        return obj_Temp;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
      
            PostAd();
            EmailCompose();
        lblmsg.Text="Plan Saved Successfully";
        clear();
    }
    
     public void clear()
    {
        txtfrom.Text = "";
        txtTo.Text = "";
        txtcapacity.Text = "";
        txtgoods.Text = "";
        txtnooftruck.Text="";
        txttravelDate.Text="";
        txtremarks.Text = "";
         txtprice.Text = "0";
    }
    
    
    public void EmailCompose()
    {
        try
        {
            dt = obj_class.Get_ClientNameByClientID(Convert.ToInt32(Session["ClientID"]));
            tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>FromLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ToLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoOfTrucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td></tr>";
            body += "<tr><td align=center><font size=2>" + txtfrom.Text + "</font></td><td align=center><font size=2 >" + txtTo.Text + "</font></td><td align=center><font size=2 >" + txttravelDate.Text + "</font></td><td align=center><font size=2>" + txtnooftruck.Text + "</font></td><td align=center><font size=2 >" + DDLTruckType.SelectedItem.Text + "</font></td><td align=center><font size=2>" + txtcapacity.Text + " </font></td></tr></table>";
            //mail.SendEmail("connect@scmjunction.com", "connect@scmjunction.com", "scmjunction", "g.jagan@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Alert-Trip Plan Posted by Client", "Dear Sir,<br/><br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            mail.SendEmail("connect@scmjunction.com", "connect@scmjunction.com", "scmjunction", "shashidhar@aarmscmsolutions.com,vinaysingh@scmjunction.com", "aarms_logistics@aarmscmsolutions.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Alert-Trip Plan Posted by Client", "Dear Sir,<br/><br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + " Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }
        catch (Exception ex)
        {

        }
    }

    [WebMethod]
    public static List<string> GetFromLocation(string prefixText, int count)
    {
        TripAgreementClass obj_Class = new TripAgreementClass();
        obj_Class.ClientID = Convert.ToInt32(HttpContext.Current.Session["ClientID"]);
        DataTable dt = new DataTable();
        dt = obj_Class.GetFromLocation(prefixText);
        List<string> CountryNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CountryNames.Add(dt.Rows[i][0].ToString());
            //CountryNames.Add(dt.Rows[i][0].ToString());
        }
        return CountryNames;
    }

    [WebMethod]
    public static List<string> GetToLocation(string prefixText, int count)
    {
        TripAgreementClass obj_Class = new TripAgreementClass();
        obj_Class.ClientID = Convert.ToInt32(HttpContext.Current.Session["ClientID"]);
        DataTable dt = new DataTable();
        dt = obj_Class.GetToLocation(prefixText);
        List<string> CountryNames = new List<string>();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CountryNames.Add(dt.Rows[i][0].ToString());
            //CountryNames.Add(dt.Rows[i][0].ToString());
        }
        return CountryNames;
    }

    
}
