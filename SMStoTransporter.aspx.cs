using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExponantAARMSMS ;
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
using System.Security.Cryptography;
using System.Data.OleDb;

public partial class SMStoTransporter : System.Web.UI.Page
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
   BizConnectClass obj_class=new BizConnectClass();
    DataSet ds;
    DataSet dset = new DataSet();
    DataTable dt_TripDetails = new DataTable();
    string tableheader, body;
    DataTable dt = new DataTable();
    ArrayList arr = new ArrayList();

    string CutoffTime, BidStartTime, EnclTypeID, obj_FileName, obj_Path, obj_Message, obj_Message1, obj_Message11;
    string clientname = "";
    DataTable TempDataTable = new DataTable();
    DataTable myDataTable = new DataTable();
    DataColumn myDataColumn;
    DataTable dt_TruckType = new DataTable();
    DataTable dt_Read = new DataTable();
    Aumjunction_DB_ConnectionString aumjcon = new Aumjunction_DB_ConnectionString();
    BizCon_DB_ConnectionString bizcon = new BizCon_DB_ConnectionString();


    #region RakeshSendsmsemailapi_Details

    string username = "aarscm";
    string password = "demo1234";
    string channel = "TRANS";
    string DCS = "0";
    string flashsms = "0";
    string mobile_no = "";
    string message = "";
    string unicode = "0";
    string senderid = "aarmsa";
    string route = "2";
    string url = "http://cannyinfotech.in/api/mt/SendSMS?";

    #endregion


    private static string EncryptionKey = "!#853g`de";
 private static byte[] key = { };
 private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

    
    protected void Page_Load(object sender, EventArgs e)
    {

        //if (DDLEnclType.Items.Count > 0)
        //{
        //    DDLEnclType.Items[DDLEnclType.SelectedIndex].Selected = false;
        //    DDLEnclType.Items[0].Selected = true;
        //}

        if (DDLTravelType.Items.Count > 0)
        {
            DDLTravelType.Items[DDLTravelType.SelectedIndex].Selected = false;
            DDLTravelType.Items[0].Selected = true;
        }
        if (DDLTruckType.Items.Count > 0)
        {
            DDLTruckType.Items[DDLTruckType.SelectedIndex].Selected = false;
            DDLTruckType.Items[0].Selected = true;
        }

        
        Session["RefrechCheck"] = DateTime.Now.ToString();
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
            ChkAuthentication();
           
            FillEnclosureType();
            FillTruckType();
            FillTravelType();
          //  CreateDataTable();
          btnadd.Visible = false;
            btnsubmit.Visible = false;
            tbl_BulkUpload.Visible = false;
            GridRouteplan.DataBind();
        }
        }
      
        
              else
        {
            Response.Redirect("Index.html");
        }
    }
    protected void Page_PreRender(object sender, EventArgs e)
      {
        ViewState["RefrechCheck"] = Session["RefrechCheck"];
      }

    public void FillTravelType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillTravelType();
        if (ds.Tables["TravelType"].Rows.Count > 0)
        {
            DDLTravelType.Items.Clear();
            DDLTravelType.DataSource = ds.Tables["TravelType"];
            DDLTravelType.DataTextField = "TravelType";
            DDLTravelType.DataValueField = "TravelTypeID";
            DDLTravelType.DataBind();           
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
            DDLTruckType.SelectedIndex = 37;
            //DDLTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
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


    protected void Butsendsms_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(txttravelDate.Text) < DateTime.Now.Date)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter valid travel date');</script>");
        }
        else
        {
            
            PostAd();
           //SendSMS();            
            SendMail();
            sendsmssend();
            ResetFormControlValues(this);
           if (Page.IsValid && Session["RefrechCheck"].ToString() == ViewState["RefrechCheck"].ToString())
             {
                Session["RefrechCheck"] = DateTime.Now.ToString();
                 int result = SaveComment();
               }
        }
    }

    private int SaveComment()
    {
        throw new NotImplementedException();
    }
    private void ResetFormControlValues(Control parent)
    {
        foreach (Control c in parent.Controls)
        {
            if (c.Controls.Count > 0)
            {
                ResetFormControlValues(c);
            }
            else
            {
                switch (c.GetType().ToString())
                {
                    case "System.Web.UI.WebControls.TextBox":
                        ((TextBox)c).Text = "";
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)c).ClearSelection();
                   
                        break;
                   

                }
            }
        }
    }
    #region RakeshSendsmsemailapi
    public void sendsmssend()
    {
        string crid = "";
        string _mailid = "";
        string _cmobile = "";
        DateTime dttb = new DateTime();
        dttb = Convert.ToDateTime(txttravelDate.Text);
        string dateb = dttb.ToString("dd-MMM-yyyy");
        try
        {
            bizcon.Sql_OpenCon();
            aumjcon.Sql_OpenCon();
            string _clientid = Session["ClientID"].ToString();

            string[] arhscd = { "@ClientID" };
            string[] argsvalcd = { _clientid };
            DataSet _dssc = bizcon.Sql_GetData("SP_Get_Client_Name", arhscd, argsvalcd);
            if (_dssc.Tables[0].Rows.Count > 0)
            {
                clientname = Convert.ToString(_dssc.Tables[0].Rows[0]["CompanyName"]);

                string[] Argsrid = { "@ClientID" };
                string[] Argsvalrid = { _clientid };
                DataSet _dsrid = bizcon.Sql_GetData("SP_Get_Rid_By_Client_Id", Argsrid, Argsvalrid);
                foreach (DataRow drrid in _dsrid.Tables[0].Rows)
                {
                    crid = Convert.ToString(drrid["UserID"]);

                    string[] Argsm = { "@rid" };
                    string[] Argsvalm = { crid };
                    //string[] Argsm = { "@clientid" };
                    //string[] Argsvalm = { _clientid };
                    DataSet _dsm = new DataSet();
                    _dsm = aumjcon.Sql_GetData("SP_Get_Email_Mobile_By_Rid", Argsm, Argsvalm);
                    //_dsm = aumjcon.Sql_GetData("SP_Get_Email_Mobile_By_ClientID", Argsm, Argsvalm);
                    foreach (DataRow drem in _dsm.Tables[0].Rows)
                    {
                        _mailid = Convert.ToString(drem["mailid"]);
                        _cmobile = Convert.ToString(drem["Mobile"]);
                        mobile_no = "91" + _cmobile;
                        message = "Req." + txtCapacity.Text + DDLTruckType.SelectedItem.Text + " for " + clientname + " " + " From " + txtFrom.Text + " To " + txtto.Text + " on " + dateb.ToString() + "  Check the mail for Quoting Thanks"; ;
                        SMSR.Send_smsR(username, password, channel, DCS, flashsms, mobile_no, message, unicode, senderid, route, url);
                    }

                }
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            bizcon.Sql_CloseCon();
            aumjcon.Sql_CloseCon();
        }
    }
    #endregion
     // adding  additional   indent  to last uploaded indent (Post Ads) or same indent
    public void PostAdSame()
    {

        if (radmultiple.Checked == true || rdb_BulkUpload.Checked == true)
        {

            for (int j = 0; j < GridRouteplan.Rows.Count; j++)
            {
                CheckBox chkrow = (CheckBox)GridRouteplan.Rows[j].FindControl("Checkplan");
                {
                    if (chkrow.Checked)
                    {
                        try
                        {

                            string obj_AdID = "";
                            Label from = (Label)GridRouteplan.Rows[j].FindControl("lblfrom");
                            Label to = (Label)GridRouteplan.Rows[j].FindControl("lblTo");
                            Label lbldate = (Label)GridRouteplan.Rows[j].FindControl("lbldate");
                            Label lbltruck = (Label)GridRouteplan.Rows[j].FindControl("lbltruck");
                            Label lbltrucktype = (Label)GridRouteplan.Rows[j].FindControl("lblTruckID");
                            Label lblenctype = (Label)GridRouteplan.Rows[j].FindControl("lblEnclosureID");
                            Label lblcapacity = (Label)GridRouteplan.Rows[j].FindControl("lblcapacity");
                            Label lbltraveltype = (Label)GridRouteplan.Rows[j].FindControl("lblTravelID");
                            Label lblremarks = (Label)GridRouteplan.Rows[j].FindControl("lblremarks");
                            Label lblcity = (Label)GridRouteplan.Rows[j].FindControl("lblcity");
                            DateTime dtt = new DateTime();
                            dtt = Convert.ToDateTime(lbldate.Text);
                            Session["TravelDate"] = dtt.ToShortDateString();
                            string date = dtt.ToString("dd-MMM-yyyy");
                            obj_AdID = SameAdIDProcess(from.Text, to.Text, date.ToString());
                            DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

                            obj_TravelDate = Convert.ToDateTime(date.ToString());

                            obj_DateOfExpiry = obj_TravelDate; //Remove =obj_TravelDate if u Uncomment Expiry Date in Script and use following commented statements also->  //DateTime.Parse(DateOfExpiry, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);lblenctype
                            obj_LastDate = obj_TravelDate; // DateTime.Parse(LastDateForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

                            //   int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 2, from.Text, to.Text, obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(lbltruck.Text), lblcapacity.Text, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, obj_DateOfExpiry, obj_LastDate, "posted By Godrej", Convert.ToInt32(Session["GroupID"].ToString()), 1, 0, "Tons");
                            //   int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, from.Text, to.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lbltruck.Text), 0, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), "Posted By Godrej", 1, 0, 0, lblcity.Text);

                            if (rdb_BulkUpload.Checked == true)
                            {
                                CutoffTime = ddl_BulkEndHours.SelectedValue.ToString() + ":" + ddl_BulkEndMins.SelectedValue.ToString() + " " + ddl_BulkEndAmPm.SelectedValue.ToString();
                                BidStartTime = "BidStartTime is " + ddl_BulkStartHours.SelectedValue.ToString() + ":" + ddl_BulkStartMins.SelectedValue.ToString() + " " + ddl_BulkStartAmPm.SelectedValue.ToString();
                            }
                            else
                            {
                                CutoffTime = ddl_Hours.SelectedValue.ToString() + ":" + ddl_Minutes.SelectedValue.ToString() + " " + ddl_Ampm.SelectedValue.ToString();
                                BidStartTime = "BidStartTime is " + ddl_BidStartHours.SelectedValue.ToString() + ":" + ddl_BidStartMinutes.SelectedValue.ToString() + " " + ddl_BidStartAmpm.SelectedValue.ToString();
                            }
                            int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, from.Text, to.Text, obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(lbltruck.Text), lblcapacity.Text, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, obj_DateOfExpiry, obj_LastDate, lblremarks.Text + "- Cutoff Time is " + CutoffTime, Convert.ToInt32(Session["GroupID"].ToString()), Convert.ToInt32(DDLTravelType.SelectedValue), 0, "Tons", lblcity.Text, BidStartTime);
                            int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, from.Text, to.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, Convert.ToInt32(DDLTravelType.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lbltruck.Text), 0, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, 0, Convert.ToDouble(lblcapacity.Text), 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), lblremarks.Text + "- Cutoff Time is " + CutoffTime, 1, 0, 0, lblcity.Text, 0);
                            int result = obj_BizConnectLogisticsPlanClass.InsertPostRFQ_TMS(Convert.ToInt32(Session["ClientID"].ToString()), obj_AdID, from.Text, lblcity.Text, "NA", Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), Convert.ToInt32(lbltruck.Text), Convert.ToSingle(lblcapacity.Text), "NA", lblremarks.Text);

                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                            //GridRouteplan.DataSource = null;
                            //GridRouteplan.DataBind();
                            //Session["data"] = "";
                            CreateDataTable();
                        }

                        catch (Exception ex)
                        {
                            Response.Write("Oops !! Following error occured: " + ex.Message.ToString());
                        }
                    }

                }
            }
        }

        else
        {
            try
            {
                string obj_AdID = "";
                DateTime dtt = new DateTime();
                dtt = Convert.ToDateTime(txttravelDate.Text);
                string date = dtt.ToString("dd-MMM-yyyy");
                obj_AdID = SameAdIDProcess(txtFrom.Text, txtto.Text, date.ToString());
                DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

                obj_TravelDate = Convert.ToDateTime(date.ToString());

                obj_DateOfExpiry = obj_TravelDate; //Remove =obj_TravelDate if u Uncomment Expiry Date in Script and use following commented statements also->  //DateTime.Parse(DateOfExpiry, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
                obj_LastDate = obj_TravelDate; // DateTime.Parse(LastDateForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

                // int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 2, txtFrom.Text.Trim(), txtto.Text.Trim(), obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(txtnooftrucks.Text), Convert.ToString(txtCapacity.Text.Trim()), Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, obj_DateOfExpiry, obj_LastDate, "posted By Godrej", Convert.ToInt32(Session["GroupID"].ToString()), 1, 0, "Tons");
                //  int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, txtFrom.Text, txtto.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(txtnooftrucks.Text), 0, Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), "Posted By Godrej", 1, 0, 0,txtCity.Text);

                CutoffTime = ddl_Hours.SelectedValue.ToString() + ":" + ddl_Minutes.SelectedValue.ToString() + " " + ddl_Ampm.SelectedValue.ToString();
                BidStartTime = "BidStartTime is " + ddl_BidStartHours.SelectedValue.ToString() + ":" + ddl_BidStartMinutes.SelectedValue.ToString() + " " + ddl_BidStartAmpm.SelectedValue.ToString();
                int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, txtFrom.Text.Trim(), txtto.Text.Trim(), obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(txtnooftrucks.Text), Convert.ToString(txtCapacity.Text.Trim()), Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, obj_DateOfExpiry, obj_LastDate, txtremark.Text + " - Cutoff Time is " + CutoffTime, Convert.ToInt32(Session["GroupID"].ToString()), Convert.ToInt32(DDLTravelType.SelectedValue), 0, "Tons", txtCity.Text, BidStartTime);
                int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, txtFrom.Text, txtto.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, Convert.ToInt32(DDLTravelType.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(txtnooftrucks.Text), 0, Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), txtremark.Text + " - Cutoff Time is " + CutoffTime, 1, 0, 0, txtCity.Text, 0);
                int result = obj_BizConnectLogisticsPlanClass.InsertPostRFQ_TMS(Convert.ToInt32(Session["ClientID"].ToString()), obj_AdID, txtFrom.Text, txtCity.Text, "NA", Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), Convert.ToInt32(txtnooftrucks.Text), Convert.ToSingle(txtCapacity.Text), "NA", txtremark.Text);

                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");

                // GridRouteplan.DataSource = null;
                // GridRouteplan.DataBind();
                // Session["data"] = "";
                CreateDataTable();
            }

            catch (Exception ex)
            {
                Response.Write("Oops !! Following error occured: " + ex.Message.ToString());
            }
        }
    }

    // taking same group id here am not creating new group id for adding  additional   indent  to last uploaded indent (Post Ads) or same indent
    public string SameAdIDProcess(string obj_FromLocation, string obj_ToLocation, string obj_TravelDte)
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
                //obj_ID += 1;
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
        if (Session["UserID"].ToString() == "357")
        {
            obj_Temp = "#GDJ" + obj_From.Substring(0, 3) + "-" + obj_To.Substring(0, 3) + obj_TravelDt.ToString("-" + "MMyyyy") + "-" + obj_PostAdType + "-" + obj_ID.ToString();
        }
        else
        {
            obj_Temp = "#" + obj_From.Substring(0, 3) + "-" + obj_To.Substring(0, 3) + obj_TravelDt.ToString("-" + "MMyyyy") + "-" + obj_PostAdType + "-" + obj_ID.ToString();
        }

        return obj_Temp;
    }
  
    public void PostAd()
    {

        if (radmultiple.Checked == true || rdb_BulkUpload.Checked == true)
        {

           for (int j = 0; j < GridRouteplan.Rows.Count; j++)
            //foreach (GridViewRow row in GridRouteplan.Rows)
            {
                CheckBox chkrow = (CheckBox)GridRouteplan.Rows[j].FindControl("Checkplan");
                //CheckBox check = (CheckBox)row.FindControl("Checkplan");
                {
                    if (chkrow.Checked)
                    
                    {
                        try
                        {
                           
                            string obj_AdID = "";
                            Label from = (Label)GridRouteplan.Rows[j].FindControl("lblfrom");
                            Label to = (Label)GridRouteplan.Rows[j].FindControl("lblTo");
                            Label lbldate = (Label)GridRouteplan.Rows[j].FindControl("lbldate");
                            Label lbltruck = (Label)GridRouteplan.Rows[j].FindControl("lbltruck");
                            Label lblenctype = (Label)GridRouteplan.Rows[j].FindControl("lblEnclosureID");
                            Label lbltrucktype = (Label)GridRouteplan.Rows[j].FindControl("lblTruckID");
                            Label lblcapacity = (Label)GridRouteplan.Rows[j].FindControl("lblcapacity");
                            Label lbltraveltype = (Label)GridRouteplan.Rows[j].FindControl("lblTravelID");
                            Label lblremarks = (Label)GridRouteplan.Rows[j].FindControl("lblremarks");
							Label lblcity = (Label)GridRouteplan.Rows[j].FindControl("lblcity");
                            DateTime dtt = new DateTime();
                            dtt = Convert.ToDateTime(lbldate.Text);
                            Session["TravelDate"] = dtt.ToShortDateString();
                            string date = dtt.ToString("dd-MMM-yyyy");
                            obj_AdID = AdIDProcess(from.Text, to.Text, date.ToString());
                            DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

                            obj_TravelDate = Convert.ToDateTime(date.ToString());

                            obj_DateOfExpiry = obj_TravelDate; //Remove =obj_TravelDate if u Uncomment Expiry Date in Script and use following commented statements also->  //DateTime.Parse(DateOfExpiry, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);lblenctype
                            obj_LastDate = obj_TravelDate; // DateTime.Parse(LastDateForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

                         //   int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 2, from.Text, to.Text, obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(lbltruck.Text), lblcapacity.Text, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, obj_DateOfExpiry, obj_LastDate, "posted By Godrej", Convert.ToInt32(Session["GroupID"].ToString()), 1, 0, "Tons");
                         //   int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, from.Text, to.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lbltruck.Text), 0, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), "Posted By Godrej", 1, 0, 0, lblcity.Text);

                            if (rdb_BulkUpload.Checked == true)
                            {
                                CutoffTime = ddl_BulkEndHours.SelectedValue.ToString() + ":" + ddl_BulkEndMins.SelectedValue.ToString() + " " + ddl_BulkEndAmPm.SelectedValue.ToString();
                                BidStartTime = "BidStartTime is " + ddl_BulkStartHours.SelectedValue.ToString() + ":" + ddl_BulkStartMins.SelectedValue.ToString() + " " + ddl_BulkStartAmPm.SelectedValue.ToString();
                            }
                            else
                            {
                                CutoffTime = ddl_Hours.SelectedValue.ToString() + ":" + ddl_Minutes.SelectedValue.ToString() + " " + ddl_Ampm.SelectedValue.ToString();
                                BidStartTime = "BidStartTime is " + ddl_BidStartHours.SelectedValue.ToString() + ":" + ddl_BidStartMinutes.SelectedValue.ToString() + " " + ddl_BidStartAmpm.SelectedValue.ToString();
                            }
                            int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, from.Text, to.Text, obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(lbltruck.Text), lblcapacity.Text, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, obj_DateOfExpiry, obj_LastDate, lblremarks.Text+"- Cutoff Time is "+CutoffTime, Convert.ToInt32(Session["GroupID"].ToString()), Convert.ToInt32(DDLTravelType.SelectedValue), 0, "Tons", lblcity.Text,BidStartTime);

                            if (obj_Response > 0)
                            {
                                try
                                {
                                    string clientid = Session["ClientID"].ToString();
                                    string client_name = "";
                                    string posteduserl_name = "";
                                    string posteduserf_name = "";
                                    string[] arhsc = { "@ClientID" };
                                    string[] argsvalc = { clientid };
                                    DataSet _ds = bizcon.Sql_GetData("SP_Get_Client_Name", arhsc, argsvalc);
                                    if (_ds.Tables[0].Rows.Count > 0)
                                    {
                                        client_name = Convert.ToString(_ds.Tables[0].Rows[0]["CompanyName"]);
                                        clientname = client_name;
                                    }

                                    string useridd = Session["UserID"].ToString();
                                    string[] arhscu = { "@UserID" };
                                    string[] argsvalcu = { useridd };
                                    DataSet _dsu = bizcon.Sql_GetData("SP_Get_User_Name", arhscu, argsvalcu);
                                    if (_dsu.Tables[0].Rows.Count > 0)
                                    {
                                        posteduserf_name = Convert.ToString(_dsu.Tables[0].Rows[0]["FirstName"]);
                                        posteduserl_name = Convert.ToString(_dsu.Tables[0].Rows[0]["LastName"]);
                                    }

                                    string[] argsss = { "@PostByID", "@clientID", "@clientname", "@status_id", "@PostedByName" };
                                    string[] argsvval = { useridd, clientid, client_name, "1", posteduserf_name };
                                    int res = aumjcon.Sql_ExecuteNonQuery("SP_Insert_Details_postbyclient", argsss, argsvval);

                                }
                                catch (Exception ex)
                                {
                                    Response.Write("Oops !! Following error occured: " + ex.Message.ToString());
                                }
                            }

                            int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, from.Text, to.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, Convert.ToInt32(DDLTravelType.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lbltruck.Text), 0, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, 0, Convert.ToDouble(lblcapacity.Text), 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), lblremarks.Text+"- Cutoff Time is "+CutoffTime, 1, 0, 0, lblcity.Text,0);
                             int result = obj_BizConnectLogisticsPlanClass.InsertPostRFQ_TMS(Convert.ToInt32(Session["ClientID"].ToString()), obj_AdID, from.Text, lblcity.Text, "NA", Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), Convert.ToInt32(lbltruck.Text), Convert.ToSingle(lblcapacity.Text), "NA", lblremarks.Text);
                             sendsmssend();
                            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                            //GridRouteplan.DataSource = null;
                            //GridRouteplan.DataBind();
                            //Session["data"] = "";
                            CreateDataTable();
                        }

                        catch (Exception ex)
                        {
                            Response.Write("Oops !! Following error occured: " + ex.Message.ToString());
                        }
                    }

                }
            }
        }

        else
        {
            try
            {
                string obj_AdID = "";
                DateTime dtt = new DateTime();
                dtt = Convert.ToDateTime(txttravelDate.Text);
                string date = dtt.ToString("dd-MMM-yyyy");
                obj_AdID = AdIDProcess(txtFrom.Text, txtto.Text, date.ToString());
                DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

                obj_TravelDate = Convert.ToDateTime(date.ToString());

                obj_DateOfExpiry = obj_TravelDate; //Remove =obj_TravelDate if u Uncomment Expiry Date in Script and use following commented statements also->  //DateTime.Parse(DateOfExpiry, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
                obj_LastDate = obj_TravelDate; // DateTime.Parse(LastDateForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

              // int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 2, txtFrom.Text.Trim(), txtto.Text.Trim(), obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(txtnooftrucks.Text), Convert.ToString(txtCapacity.Text.Trim()), Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, obj_DateOfExpiry, obj_LastDate, "posted By Godrej", Convert.ToInt32(Session["GroupID"].ToString()), 1, 0, "Tons");
              //  int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, txtFrom.Text, txtto.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(txtnooftrucks.Text), 0, Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), "Posted By Godrej", 1, 0, 0,txtCity.Text);

                string enclytype = DDLEnclType.SelectedValue;
                string enclytype1 = DDLEnclType.SelectedItem.Value;

               CutoffTime = ddl_Hours.SelectedValue.ToString() + ":" + ddl_Minutes.SelectedValue.ToString() + " " + ddl_Ampm.SelectedValue.ToString();
               BidStartTime ="BidStartTime is " + ddl_BidStartHours.SelectedValue.ToString() + ":" + ddl_BidStartMinutes.SelectedValue.ToString() + " " + ddl_BidStartAmpm.SelectedValue.ToString();
               int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, txtFrom.Text.Trim(), txtto.Text.Trim(), obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(txtnooftrucks.Text), Convert.ToString(txtCapacity.Text.Trim()), Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, obj_DateOfExpiry, obj_LastDate, txtremark.Text+" - Cutoff Time is "+CutoffTime, Convert.ToInt32(Session["GroupID"].ToString()), Convert.ToInt32(DDLTravelType.SelectedValue), 0, "Tons",txtCity.Text,BidStartTime);

               
               int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, txtFrom.Text, txtto.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, Convert.ToInt32(DDLTravelType.SelectedValue), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(txtnooftrucks.Text), 0, Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), txtremark.Text+" - Cutoff Time is "+CutoffTime, 1, 0, 0,txtCity.Text,0);
			   int result = obj_BizConnectLogisticsPlanClass.InsertPostRFQ_TMS(Convert.ToInt32(Session["ClientID"].ToString()), obj_AdID, txtFrom.Text, txtCity.Text, "NA", Convert.ToInt32(DDLTruckType.SelectedValue), Convert.ToInt32(DDLEnclType.SelectedValue), Convert.ToInt32(txtnooftrucks.Text), Convert.ToSingle(txtCapacity.Text), "NA", txtremark.Text);
               sendsmssend();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                
               // GridRouteplan.DataSource = null;
               // GridRouteplan.DataBind();
               // Session["data"] = "";
                CreateDataTable();
            }

            catch (Exception ex)
            {
                Response.Write("Oops !! Following error occured: " + ex.Message.ToString());
            }
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
        if (Session["UserID"].ToString() == "357")
        {
            obj_Temp = "#GDJ" + obj_From.Substring(0, 3) + "-" + obj_To.Substring(0, 3) + obj_TravelDt.ToString("-" + "MMyyyy") + "-" + obj_PostAdType + "-" + obj_ID.ToString();
        }
        else
        {
            obj_Temp = "#" + obj_From.Substring(0, 3) + "-" + obj_To.Substring(0, 3) + obj_TravelDt.ToString("-" + "MMyyyy") + "-" + obj_PostAdType + "-" + obj_ID.ToString();
        }
            
            return obj_Temp;
    }


   
    public void SendSMS()
    {
  
        Int32 obj_resp=3;
        String obj_Message;
         String obj_UID;
        String obj_Password;
        String obj_MobileNo ;
        DateTime dtt = new DateTime();
                dtt =Convert.ToDateTime (txttravelDate.Text);
                string date = dtt.ToString("dd-MMM-yyyy");

        obj_Message = "Req." + txtCapacity.Text + DDLTruckType.SelectedItem.Text + " for Godrej " + " From " + txtFrom.Text + " To " + txtto.Text + " on " + date.ToString() + "Check the mail for Quoting Regards,Godrej ";
        obj_UID =  ConfigurationManager.AppSettings.Get("Way2SMSUID").ToString();
        obj_Password = ConfigurationManager.AppSettings.Get("Way2SMSPassword").ToString();
        try
        {

          //  obj_MobileNo = "9739833063";

              ds = obj_class.get_EmailandMobileForGodrej();
              ds = obj_class.get_EmailandMobileForGodrej();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //  for (int i = 0; i <= 0; i++)
              {
                  obj_MobileNo = ds.Tables[0].Rows[i].ItemArray [2].ToString();
                  //Declaration Section for AARMSMS Control
                  ExponantAARMSMS.SendSMS SMSCtrl = new ExponantAARMSMS.SendSMS();
                  SMSCtrl.ExponantSendSMS(obj_UID, obj_Password, obj_MobileNo, obj_Message, "N");
                  obj_resp = 1;
                  mobile_no = "91"+obj_MobileNo;
                  message = "Req." + txtCapacity.Text + DDLTruckType.SelectedItem.Text + " for " + clientname + " " + " From " + txtFrom.Text + " To " + txtto.Text + " on " + date.ToString() + "Check the mail for Quoting Thanks"; ;
                  SMSR.Send_smsR(username, password, channel, DCS, flashsms, mobile_no, message, unicode, senderid, route, url);
              }
        }

        catch (Exception ex)
        {
        }
    }

    public void SendMail()
    {
 //Email Settings from Web Config
        if (Session["ClientID"].ToString() == "1132")
        {
        string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid").ToString();
        string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
        string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
        string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
        string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
        string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
        string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
        string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
        Boolean SMTPUseSSL;
        string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
       
        try
        {
            ds = new DataSet();
            AARMEmail.EmailControl em = new AARMEmail.EmailControl();
            dset = obj_class.Bizconnect_GetClientName(Convert.ToInt32(Session["ClientID"].ToString()));

            if (Session["ClientID"].ToString() == "1132")
            {
                //ds = obj_class.get_EmailandMobileForGodrej();
                ds = obj_class.Bizconnect_GetTransporterForBidding(Convert.ToInt32(Session["ClientID"].ToString()));
            }
           
            else
            {
               ds = obj_class.Bizconnect_GetTransporterForBidding(Convert.ToInt32(Session["ClientID"].ToString()));
            }
           for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
           //  for (int i = 0; i <= 0; i++)
            {
               
               string obj_CLName = dset.Tables[0].Rows[0].ItemArray[0].ToString();
                string obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string obj_Rid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                if (radmultiple.Checked|| radsingle.Checked )
                {
                    // obj_Message = "Dear Sir/madam,<br/>Please Quote your competative price for various trips</br> <b><a href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + txttravelDate.Text + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID="+ Session["GroupID"].ToString() +" > Click the link to Quote your Price</a> </b> <br/><b>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</b><br/>Thank You,<br/>AARMS VALUE CHAIN PRIVATE LIMITED<br>#211, Temple Street,9th Main Road,BEML 3rd stage,<br/><br>RajarajeshwariNagar,Bangalore - 560098<br/><br>Ph:080-66270268;09739870001<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";

                    obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + txttravelDate.Text + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + " > Click the link to Quote your Price for " + obj_CLName .ToString()+ "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                    

                    #region Mailsendc
                    //your code
                   
                    try
                    {
                        obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&GrpID=" + Session["GroupID"].ToString() + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                       

                    }
                    catch (Exception ex)
                    {

                    }
                    #endregion Mailsendc

                }
                else if (rdb_BulkUpload.Checked)
                {
                    // obj_Message = "Dear Sir/madam,<br/>Please Quote your competative price for various trips</br> <b><a href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + " > Click the link to Quote your Price</a> </b> <br/><b>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</b><br/>Thank You,<br/>AARMS VALUE CHAIN PRIVATE LIMITED<br>#211, Temple Street,9th Main Road,BEML 3rd stage,<br/><br>RajarajeshwariNagar,Bangalore - 560098<br/><br>Ph:080-66270268;09739870001<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
                    obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  style='width:200px;height:80px' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px;'><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "  > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                    //obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  style='width:200px;height:80px' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px;'><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://localhost:59168/SCMJunction/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "  > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";

                    #region emailsendf
                    try
                    {
                        obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&GrpID=" + Session["GroupID"].ToString() + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";


                    }
                    catch (Exception ex)
                    {

                    }
                    #endregion emailsendf

                }

               //Declaration Section for AARMEmail Control
               // try
               // {
               //     obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
               //     int obj_resp11 = em.SendEmail("madhuchoudhary@miisky.com", obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message11.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

               // }
               // catch (Exception ex)
               // {

               // }
                int obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                


                //int obj_resp = em.SendEmail("madhuchoudhary@miisky.com", obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
              
               //   int obj_resp = em.SendEmail("nandha@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Request for your Quote", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

            }
           //#region sentemaia

           //string mymaill = "satyammiisky@gmail.com,prabhat.92pbt@gmail.com,madhumiiskytechnovation@gmail.com";
           //int obj_resp11 = em.SendEmail(mymaill, obj_FromEmail, obj_Password, "", "", obj_FromEmail, mymaill, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message11.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

           //#endregion sentemaia
            dt = obj_class.Get_ClientNameByClientID(Convert.ToInt32(Session["ClientID"]));
            //sending  mail to aarms admin
            if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
            {
                if (Session["Trip"] != "")
                {
                    DataSet dt_TripDetails = (DataSet)Session["Trip"];
                    tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>FromLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ToLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoOfTrucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td></tr>";
                    if (dt_TripDetails.Tables[0].Rows.Count != 0)
                    {
                        for (int j = 0; j <= GridRouteplan.Rows.Count - 1; j++)
                        {
                            body += "<tr><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][0] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][1] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][2] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][3] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][5] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][6] + " </font></td></tr>";
                        }
                        body += "</table>";

                        int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "godrej@scmbizconnect.com", "connectscm", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                        Session["Trip"] = "";
                    }
                }
                else
                {
                    tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>FromLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ToLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoOfTrucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td></tr>";
                    body += "<tr><td align=center><font size=2>" + txtFrom.Text + "</font></td><td align=center><font size=2 >" + txtto.Text + "</font></td><td align=center><font size=2 >" + txttravelDate.Text + "</font></td><td align=center><font size=2>" + txtnooftrucks.Text + "</font></td><td align=center><font size=2 >" + DDLTruckType.SelectedItem.Text + "</font></td><td align=center><font size=2>" + txtCapacity.Text + " </font></td></tr></table>";
                    int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "godrej@scmbizconnect.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                }
                // int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/><br/>Client has posted a trip plan. <br>Client Name :" + dt.Rows[0][0].ToString() + "<br> Please Check and do the needfull.", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
            }
        }
        catch (Exception err)
        {

        }
		}
		else
		{
		    string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid1").ToString();
            string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
            string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
            string obj_Password = ConfigurationManager.AppSettings.Get("Password1").ToString();
            string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
            string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
            string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
            string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
            Boolean SMTPUseSSL;
            string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();

            try
            {
                ds = new DataSet();
                AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                dset = obj_class.Bizconnect_GetClientName(Convert.ToInt32(Session["ClientID"].ToString()));

                if (Session["ClientID"].ToString() == "1132")
                {
                    //ds = obj_class.get_EmailandMobileForGodrej();
                    ds = obj_class.Bizconnect_GetTransporterForBidding(Convert.ToInt32(Session["ClientID"].ToString()));
                }

                else
                {
                    ds = obj_class.Bizconnect_GetTransporterForBidding(Convert.ToInt32(Session["ClientID"].ToString()));
                }
                for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
                //  for (int i = 0; i <= 0; i++)
                {

                    string obj_CLName = dset.Tables[0].Rows[0].ItemArray[0].ToString();
                    string obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                    string obj_Rid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    if (radmultiple.Checked || radsingle.Checked)
                    {
                        // obj_Message = "Dear Sir/madam,<br/>Please Quote your competative price for various trips</br> <b><a href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + txttravelDate.Text + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID="+ Session["GroupID"].ToString() +" > Click the link to Quote your Price</a> </b> <br/><b>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</b><br/>Thank You,<br/>AARMS VALUE CHAIN PRIVATE LIMITED<br>#211, Temple Street,9th Main Road,BEML 3rd stage,<br/><br>RajarajeshwariNagar,Bangalore - 560098<br/><br>Ph:080-66270268;09739870001<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
                        //obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  style='width:200px;height:80px' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px;'><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://localhost:55044/SCMJunction/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "  > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                        obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + txttravelDate.Text + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + " > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";

                        #region emailsentg
                        try
                        {
                            obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&GrpID=" + Session["GroupID"].ToString() + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";


                        }
                        catch (Exception ex)
                        {

                        }
                        #endregion emailsentg


                    }
                    else if (rdb_BulkUpload.Checked)
                    {
                        // obj_Message = "Dear Sir/madam,<br/>Please Quote your competative price for various trips</br> <b><a href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + " > Click the link to Quote your Price</a> </b> <br/><b>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</b><br/>Thank You,<br/>AARMS VALUE CHAIN PRIVATE LIMITED<br>#211, Temple Street,9th Main Road,BEML 3rd stage,<br/><br>RajarajeshwariNagar,Bangalore - 560098<br/><br>Ph:080-66270268;09739870001<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
                        obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  style='width:200px;height:80px' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px;'><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "  > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                        //obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  style='width:200px;height:80px' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px;'><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://localhost:59168/SCMJunction/GQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + Session["TravelDate"].ToString() + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "  > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";

                        #region emailsenth
                        try
                        {
                            obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                            

                        }
                        catch (Exception ex)
                        {

                        }
                        #endregion emailsenth

                    }

                    //Declaration Section for AARMEmail Control

                    //int obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    int obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    //int obj_resp11 = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message11.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    //int obj_resp = em.SendEmail("madhuchoudhary@miisky.com", obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    //   int obj_resp = em.SendEmail("nandha@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Request for your Quote", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                   


                }
                #region sentemmailb
                try
                {
                    //obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                    //int obj_resp11 = em.SendEmail("madhuchoudhary@miisky.com", obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message11.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    //string mymaill = "satyammiisky@gmail.com,prabhat.92pbt@gmail.com,madhuchoudhary@miisky.com";
                   // int obj_resp11 = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message11.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                }
                catch (Exception ex)
                {

                }
                #endregion sentemmailb
                dt = obj_class.Get_ClientNameByClientID(Convert.ToInt32(Session["ClientID"]));
                //sending  mail to aarms admin
                if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
                {
                    if (Session["Trip"] != "")
                    {
                        DataSet dt_TripDetails = (DataSet)Session["Trip"];
                        tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>FromLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ToLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoOfTrucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td></tr>";
                        if (dt_TripDetails.Tables[0].Rows.Count != 0)
                        {
                            for (int j = 0; j <= GridRouteplan.Rows.Count - 1; j++)
                            {
                                body += "<tr><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][0] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][1] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][2] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][3] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][5] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][6] + " </font></td></tr>";
                            }
                            body += "</table>";

                            int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "connectscm", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                            Session["Trip"] = "";
                        }
                    }
                    else
                    {
                        tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>FromLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ToLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoOfTrucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td></tr>";
                        body += "<tr><td align=center><font size=2>" + txtFrom.Text + "</font></td><td align=center><font size=2 >" + txtto.Text + "</font></td><td align=center><font size=2 >" + txttravelDate.Text + "</font></td><td align=center><font size=2>" + txtnooftrucks.Text + "</font></td><td align=center><font size=2 >" + DDLTruckType.SelectedItem.Text + "</font></td><td align=center><font size=2>" + txtCapacity.Text + " </font></td></tr></table>";
                        int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    }
                    // int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/><br/>Client has posted a trip plan. <br>Client Name :" + dt.Rows[0][0].ToString() + "<br> Please Check and do the needfull.", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                }
            }
            catch (Exception err)
            {

            }
		}
		
		
    }
    

     protected void radmultiple_CheckedChanged(object sender, EventArgs e)
    {
        tbl_BulkUpload.Visible = false;
        Table1.Visible = true;
        divouter.Visible = true;
        divinner.Visible = true;
        Butsendsms.Visible = false;
        btnadd.Visible = true;    
        GridRouteplan.DataSource = null;
        GridRouteplan.DataBind();
        Session["data"] = "";
        CreateDataTable();    
    }
     protected void radsingle_CheckedChanged(object sender, EventArgs e)
    {
        tbl_BulkUpload.Visible = false;
        Table1.Visible = true;
        divouter.Visible = true;
        divinner.Visible = true;
        Butsendsms.Visible = true;
        btnadd.Visible = false;
        GridRouteplan.Visible = false;
         btnsubmit.Visible = false;
        GridRouteplan.DataSource = null;
        GridRouteplan.DataBind();
        
    }
      public void clear()
    {
        txtFrom.Text = "";
        txtto.Text = "";
       
        txtnooftrucks.Text = "";
        txtCapacity.Text = "";
        txtremark.Text = "";
         txtCity.Text="";
        
    }

   protected void btnadd_Click(object sender, EventArgs e)
    {
        DataSet ds = (DataSet)Session["data"];  
        DataRow dr = ds.Tables[0].NewRow();        
        dr[0] = txtFrom.Text;
        dr[1] = txtto.Text;
        dr[2] = txttravelDate.Text;
        dr[3] = txtnooftrucks.Text;
        dr[4] = DDLEnclType.SelectedItem.Text;
        dr[5] = DDLTruckType.SelectedItem.Text;
        dr[6] = txtCapacity.Text;
        dr[7] = DDLTravelType.SelectedItem.Text;
        dr[11] = txtremark.Text;
        dr[8] = DDLTruckType.SelectedValue;
        dr[9] = DDLEnclType.SelectedValue;
        dr[10] = DDLTravelType.SelectedValue;
        dr[12] = txtCity.Text;
        ds.Tables[0].Rows.Add(dr);
        GridRouteplan.DataSource = ds;
        GridRouteplan.DataBind();
        Session["Trip"] = ds;
        btnsubmit.Visible = true;
        GridRouteplan.Visible = true;
        clear();
        //Response.Redirect(Request.Url.AbsoluteUri);
       // Response.Redirect("SMStoTransporter.aspx");
       
    }


  protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)GridRouteplan.HeaderRow.FindControl("ChkAll");
        if (chk.Checked)
        {
            for (int i = 0; i < GridRouteplan.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)GridRouteplan.Rows[i].FindControl("Checkplan");

                chkrow.Checked = true;

            }

        }
        else
        {
            for (int i = 0; i < GridRouteplan.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)GridRouteplan.Rows[i].FindControl("Checkplan");
                chkrow.Checked = false;

            }
        }
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        PostAd();
        SendMail();
        btnsubmit.Enabled = false;
        btnsubmit.Enabled = true;

    }

    public void CreateDataTable()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn from = new DataColumn("From");
        DataColumn to = new DataColumn("To");
        DataColumn date = new DataColumn("TravelDate");
        DataColumn nooftrucks = new DataColumn("NoofTrucks");
        DataColumn encltype = new DataColumn("EnclosureType");
        DataColumn trucktype = new DataColumn("TruckType");
        DataColumn capacity = new DataColumn("Capacity");
        DataColumn travel = new DataColumn("TravelType");
        DataColumn remarks = new DataColumn("Remarks");
        DataColumn truckid = new DataColumn("TruckTypeID");
        DataColumn enclosureid = new DataColumn("EnclosureTypeID");
        DataColumn travelid = new DataColumn("TravelTypeID");
        DataColumn city = new DataColumn("City");
        dt.Columns.Add(from);
        dt.Columns.Add(to);
        dt.Columns.Add(date);
        dt.Columns.Add(nooftrucks);
        dt.Columns.Add(encltype);
        dt.Columns.Add(trucktype);
        dt.Columns.Add(capacity);
        dt.Columns.Add(travel);
        dt.Columns.Add(truckid);
        dt.Columns.Add(enclosureid);
        dt.Columns.Add(travelid);
        dt.Columns.Add(remarks);
        dt.Columns.Add(city);
        ds.Tables.Add(dt);
        Session["data"] = ds;
    }


 public string Encrypt(string Input)
    {
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }


 protected void rdb_BulkUpload_CheckedChanged(object sender, EventArgs e)
 {
     Table1.Visible = false;
     divouter.Visible = false;
     divinner.Visible = false;
     tbl_BulkUpload.Visible = true;
 }


 protected void btn_UploadAndDisplay_Click1(object sender, EventArgs e)
 {
     System.Threading.Thread.Sleep(1000);
     try
     {
         if (ExcelUpload.HasFile)
         {
             obj_FileName = ExcelUpload.PostedFile.FileName;
             ExcelUpload.SaveAs(Server.MapPath(@"temp\") + ExcelUpload.FileName);
             obj_Path = Server.MapPath(@"Excel\") + ExcelUpload.FileName;
             Session["obj_Path"] = Server.MapPath(@"temp\") + ExcelUpload.FileName;
         }
         string excelConnectionString = "";
         String Extension = System.IO.Path.GetExtension(ExcelUpload.PostedFile.FileName);
         try
         {
             switch (Extension)
             {
                 case ".xls": //Excel 97-03
                     //  excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(@"Excel\" + ExcelUpload.FileName) + ";Extended Properties='Excel 8.0;HDR={1}'";
                     excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Session["obj_Path"].ToString() + ";Extended Properties='Excel 8.0;HDR={1}'";
                     break;
                 case ".xlsx": //Excel 07
                     excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Session["obj_Path"].ToString() + ";Extended Properties='Excel 8.0;HDR={1}'";
                     break;
             }
             //  Response.Write(Session["obj_Path"].ToString());
             OleDbConnection myExcelConnection = new OleDbConnection(excelConnectionString);
            // myExcelConnection.Open();
             OleDbDataAdapter myAdapter = new OleDbDataAdapter("select * from [Sheet1$]", myExcelConnection);
             //OleDbDataReader reader = myAdapter.SelectCommand.ExecuteReader();
             myAdapter.Fill(dt_Read);
             //Creating Data Table
             dt = CreateTempDataTable();
             //while (reader.Read())
             //{
             //    if (reader.ToString() != "")
             //    {
             //        TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(),
             //            reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(),
             //            reader.GetValue(9).ToString(), dt);
             //    }

             //}
             //reader.Dispose();
             //reader.Close();

             for (int i = 0; i < dt_Read.Rows.Count; i++)
             {
                 if (dt_Read.Rows[i][0].ToString() != "")
                 {
                     TempDataTable = AddDataToTempTable(dt_Read.Rows[i][0].ToString(), dt_Read.Rows[i][1].ToString(), dt_Read.Rows[i][2].ToString(), dt_Read.Rows[i][3].ToString(),
                     dt_Read.Rows[i][4].ToString(), dt_Read.Rows[i][5].ToString(), dt_Read.Rows[i][6].ToString(), dt_Read.Rows[i][7].ToString(), dt_Read.Rows[i][8].ToString(),
                     dt_Read.Rows[i][9].ToString(), dt);
                 }
             }

             GridRouteplan.DataSource = TempDataTable;
             GridRouteplan.DataBind();
             myExcelConnection.Close();
             File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));
             btnsubmit.Visible = true;

         }
         catch (Exception err)
         {

             File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));
         }
     }
     catch (Exception ex)
     {
     }
 }

 private DataTable CreateTempDataTable()
 {
     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "From";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "To";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "City";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "TravelDate";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "NoofTrucks";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "EnclosureType";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "TruckType";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "Capacity";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "TravelType";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "Remarks";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "EnclosureTypeID";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "TruckTypeID";
     myDataTable.Columns.Add(myDataColumn);

     myDataColumn = new DataColumn();
     myDataColumn.DataType = Type.GetType("System.String");
     myDataColumn.ColumnName = "TravelTypeID";
     myDataTable.Columns.Add(myDataColumn);


     return myDataTable;

 }
 private DataTable AddDataToTempTable(string FromLoc, string ToLoc, string City, string TravelDate, string NoofTrucks, string EnclType, string TruckType, string Capacity, string TravelType, string Remarks, DataTable dt)
 {
     
         DataRow row;
         row = dt.NewRow();
         row["From"] = FromLoc;
         row["To"] = ToLoc;
         row["City"] = City;
         row["TravelDate"] = TravelDate;
         row["NoofTrucks"] = NoofTrucks;
         row["EnclosureType"] = EnclType;
         row["TruckType"] = TruckType;
         row["Capacity"] = Capacity;
         row["TravelType"] = TravelType;
         row["Remarks"] = Remarks;
         string _EnclType = EnclType.Trim();
         //if (_EnclType == "Close" || _EnclType == "Open")
         //{
         //    EnclTypeID = _EnclType.ToLower() == "Close" ? "2" : "1";
         //}
         if (_EnclType == "Close")
         {
             EnclTypeID = "2";
         }
         else
         {
             EnclTypeID = "1";
         }
         row["EnclosureTypeID"] = EnclTypeID;
         dt_TruckType = obj_BizConnectLogisticsPlanClass.Bizconnect_GetTruckTypeIDByTruckType(TruckType);
         if (dt_TruckType.Rows.Count > 0)
         {
             row["TruckTypeID"] = dt_TruckType.Rows[0][0].ToString();
         }
         row["TravelTypeID"] = 1;
         dt.Rows.Add(row);
         
     
         return dt;
    
 }
    //  adding  additional   indent  to last uploaded indent or same indent
 protected void btn_UploadWithMail_Click(object sender, EventArgs e)
 {
     try
     {
         if (GridRouteplan.Rows.Count > 0)
         {
             PostAdSame(); // before here used PostAd() function but i changed now  PostAdSame()  function & same fuction inside also i change  AdIDProcess() function into SameAdIDProcess
         }
         else
         {
             ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Upload after validating the Indent');</script>");
         }
     }
     catch (Exception ex)
     {

     }
 }

 protected void btn_uploads_Click(object sender, EventArgs e)
 {
     if (FileUpload1.HasFile)
     {
         string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
         string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
         string FolderPath = Server.MapPath("Files/");//ConfigurationManager.AppSettings["FolderPath"];

         string FilePath = Server.MapPath("Files/" + FileName);
         FileUpload1.SaveAs(FilePath);
         Import_To_Grid(FilePath, Extension);
         File.Delete(FilePath);
     }
 }

 private void Import_To_Grid(string FilePath, string Extension)
 {

     try
     {
         int i = 0; //Convert.ToInt32(Session["clientid"].ToString());
         string conStr = "";
         switch (Extension)
         {
             case ".xls": //Excel 97-03
                 conStr = ConfigurationManager.ConnectionStrings["Excel03ConString"]
                          .ConnectionString;
                 break;
             case ".xlsx": //Excel 07
                 conStr = ConfigurationManager.ConnectionStrings["Excel07ConString"]
                           .ConnectionString;
                 break;
         }
         conStr = String.Format(conStr, FilePath, "Yes");
         OleDbConnection connExcel = new OleDbConnection(conStr);
         OleDbCommand cmdExcel = new OleDbCommand();
         OleDbDataAdapter oda = new OleDbDataAdapter();
         DataTable dt = new DataTable();
         cmdExcel.Connection = connExcel;

         //Get the name of First Sheet
         connExcel.Open();
         DataTable dtExcelSchema;
         dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
         string SheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
         connExcel.Close();

         //Read Data from First Sheet
         connExcel.Open();
         cmdExcel.CommandText = "SELECT * From [" + SheetName + "]";
         oda.SelectCommand = cmdExcel;
         oda.Fill(dt);
         connExcel.Close();
         //dt.Columns.Add("DeliveryDate", typeof(string));
         int count = 0;

         try
         {
             DateTime strdate_date = DateTime.Now;
             string _startdate = strdate_date.ToString("MM/dd/yyyy");
             foreach (DataRow dr in dt.Rows)
             {

                 string FromLocation = dr["FromLocation"].ToString();
                 string ToLocation = dr["ToLocation"].ToString();
                 string City = dr["City"].ToString();
                 string TravelDate = dr["TravelDate"].ToString();
                 string NoofTrucks = dr["NoofTrucks"].ToString();
                 string EnclosureType = dr["EnclosureType"].ToString();
                 string TruckType = dr["TruckType"].ToString();
                 string Capacity = dr["Capacity"].ToString();
                 string TravelType = dr["TravelType"].ToString();
                 string Remarks = dr["Remarks"].ToString();


             }
             //Bind Data to GridView
             gv_exceldatadisplay.Caption = Path.GetFileName(FilePath);
             gv_exceldatadisplay.DataSource = dt;
             gv_exceldatadisplay.DataBind();
             //Session.Add("PlanRecords", dt);                
             //lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Test"); //"No. Of Data Uploaded='" + gv_exceldatadisplay.Rows.Count + "'";
             upload_gid_div.Visible = true;
         }
         catch (Exception ex)
         {

         }

     }
     catch (Exception ex)
     {

     }
 }
}
