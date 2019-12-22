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
using System.Security.Cryptography;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Serialization;
using System.Threading;


public partial class Parcel_Part : System.Web.UI.Page
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
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    ClassPostAd obj_ClassPostAd = new ClassPostAd();
    BizConnectClass obj_class = new BizConnectClass();
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
    Report obj_Class = new Report();
    private static string EncryptionKey = "!#853g`de";
    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    Aumjunction_DB_ConnectionString con1 = new Aumjunction_DB_ConnectionString();
    //Aumjunction_DB_ConnectionString aumjcon = new Aumjunction_DB_ConnectionString();
    BizCon_DB_ConnectionString bizcon = new BizCon_DB_ConnectionString();
    Aumjunction_DB_ConnectionString aumjcon = new Aumjunction_DB_ConnectionString();

    string length2 = "0";
    string width2 = "0";
    string height2 = "0";
    string breath2 = "0";
    string totalsize = "";
    //Sql_connect con=new Sql_connect;
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

    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (!IsPostBack)
            {
                ChkAuthentication();
                btnsubmit.Visible = false;
                Btn_add.Visible = false;
                //div2.Visible = false;
                
                //btn_submit.Visible = false;
            }
        }
        else
        {
            Response.Redirect("index.html");
        }

    }

   

    private void ChkAuthentication()
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

    private void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
    }

    private void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
    }
    public void CreateDataTable()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        DataColumn from = new DataColumn("source_from");
        DataColumn PickUp = new DataColumn("source_pickup");
        DataColumn To = new DataColumn("destination_to");
        DataColumn City = new DataColumn("destination_city");
        DataColumn DeliveryType = new DataColumn("delivery_type");
        DataColumn NoOfUnits = new DataColumn("no_of_units");
        DataColumn PackingType = new DataColumn("packing_type");
        DataColumn Size = new DataColumn("size");
        DataColumn Remarks = new DataColumn("remarks");
        DataColumn TravelDate = new DataColumn("travel_date");
        dt.Columns.Add(from);
        dt.Columns.Add(PickUp);
        dt.Columns.Add(To);
        dt.Columns.Add(City);
        dt.Columns.Add(DeliveryType);
        dt.Columns.Add(NoOfUnits);
        dt.Columns.Add(PackingType);
        dt.Columns.Add(Size);
        dt.Columns.Add(Remarks);
        dt.Columns.Add(TravelDate);
        ds.Tables.Add(dt);
        Session["data"] = ds;
    }

    protected void radmultiple_CheckedChanged(object sender, EventArgs e)
    {
        //tbl_BulkUpload.Visible = false;
        //Table1.Visible = true;
        //divouter.Visible = true;
        //divinner.Visible = true;
        //Butsendsms.Visible = false;
        Btn_add.Visible = true;
        gv_parceldetails.DataSource = null;
        gv_parceldetails.DataBind();
        Session["data"] = "";
        CreateDataTable();
        btn_submit.Visible = false;
    }
    protected void radsingle_CheckedChanged(object sender, EventArgs e)
    {
        //tbl_BulkUpload.Visible = false;
        //Table1.Visible = true;
        //divouter.Visible = true;
        //divinner.Visible = true;
        //Butsendsms.Visible = true;
        Btn_add.Visible = false;
        gv_parceldetails.Visible = false;
        btn_submit.Visible = true;
        //btnsubmit.Visible = false;
        gv_parceldetails.DataSource = null;
        gv_parceldetails.DataBind();

    }
    protected void Btn_add_click(object sender, EventArgs e)
    {
        string size = "L- " + txtlen.Text + "," + "B- " + txtbdth.Text + "," + "H- " + txtwth.Text + "," + "Weight- " + txtwt.Text;
        DataSet ds = (DataSet)Session["data"];
        DataRow dr = ds.Tables[0].NewRow();
        dr[0] = txt_source.Text;
        dr[1] = txtpick.Text;
        dr[2] = txt_dest.Text;
        dr[3] = txtcity.Text;
        dr[4] = ddl_type.SelectedItem.Text;
        dr[5] =  txtunits.Text;
        dr[6] = ddlpacktype.SelectedItem.Text;
        dr[7] = size;
        dr[8] = txtrem.Text;
        dr[9] = txt_traveldate.Text;
        
        //dr[9] = txtrem.Text;

        ds.Tables[0].Rows.Add(dr);
        gv_parceldetails.DataSource = ds;
        gv_parceldetails.DataBind();
        Session["Trip"] = ds;
        btnsubmit.Visible = true;
        gv_parceldetails.Visible = true;
        cleardata();
    }

    private void cleardata()
    {
        txt_source.Text = "";
        txtpick.Text = "";
        txt_dest.Text = "";
        txtcity.Text = "";
        //txt_traveldate.Text = "";
        txtbdth.Text = "";
        txtwth.Text = "";
        txtlen.Text = "";
        txtrem.Text = "";
        txtunits.Text = "";
        txtwt.Text = "";
        ddl_type.SelectedIndex = 0;
        ddlpacktype.SelectedIndex = 0;
    }

    protected void btnsubmit_Click(object sender, EventArgs e)
    {

       
        PostAdSame();        
        SendMail();
        //SendSMS();
       // sendsmssend();
       // SMSR.Send_smsR(username, password, channel, DCS, flashsms, mobile_no, message, unicode, senderid, route, url);
    }

   

    private void PostAdSame()
    {
        if (radmultiple.Checked == true)
        {
            for (int j = 0; j < gv_parceldetails.Rows.Count; j++)
            {
                CheckBox chkrow = (CheckBox)gv_parceldetails.Rows[j].FindControl("CheckBox1");
                {
                    if (chkrow.Checked)
                    {
                        try
                        {

                            string obj_AdID = "";
                            Label from = (Label)gv_parceldetails.Rows[j].FindControl("lblfrom");
                            Label Pickup = (Label)gv_parceldetails.Rows[j].FindControl("lblpickup");
                            Label To = (Label)gv_parceldetails.Rows[j].FindControl("lblTo");
                            Label lblcity = (Label)gv_parceldetails.Rows[j].FindControl("lblcity");
                            Label lbldeltype = (Label)gv_parceldetails.Rows[j].FindControl("lbldeltype");
                            Label lblunits = (Label)gv_parceldetails.Rows[j].FindControl("lblunits");
                            Label lblpacktype = (Label)gv_parceldetails.Rows[j].FindControl("lblpacktype");
                            Label lblsize = (Label)gv_parceldetails.Rows[j].FindControl("lblsize");
                            Label lblremarks = (Label)gv_parceldetails.Rows[j].FindControl("lblremarks");
                            Label lbltraveldate = (Label)gv_parceldetails.Rows[j].FindControl("lbltraveldate");

                            DateTime dtt = new DateTime();
                            dtt = Convert.ToDateTime(lbltraveldate.Text);
                            Session["TravelDate"] = dtt.ToShortDateString();
                            string date = dtt.ToString("dd-MMM-yyyy");
                            obj_AdID = SameAdIDProcess(from.Text, To.Text, date.ToString());
                            DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

                            obj_TravelDate = Convert.ToDateTime(date.ToString());

                            obj_DateOfExpiry = obj_TravelDate; //Remove =obj_TravelDate if u Uncomment Expiry Date in Script and use following commented statements also->  //DateTime.Parse(DateOfExpiry, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);lblenctype
                            obj_LastDate = obj_TravelDate; // DateTime.Parse(LastDateForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

                            //   int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 2, from.Text, to.Text, obj_TravelDate, "SolidGoods", 1, Convert.ToInt32(lbltruck.Text), lblcapacity.Text, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, obj_DateOfExpiry, obj_LastDate, "posted By Godrej", Convert.ToInt32(Session["GroupID"].ToString()), 1, 0, "Tons");
                            //   int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, from.Text, to.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, "SolidGoods", 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, Convert.ToInt32(lbltruck.Text), 0, Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), 0, 0, 0, 0, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), "Posted By Godrej", 1, 0, 0, lblcity.Text);


                            CutoffTime = ddlhours.SelectedValue.ToString() + ":" + ddlminutes.SelectedValue.ToString() + " " + ddlampm.SelectedValue.ToString();
                            BidStartTime = "BidStartTime is " + ddl_hours.SelectedValue.ToString() + ":" + ddl_minutes.SelectedValue.ToString() + " " + ddl_am_pm.SelectedValue.ToString();
                            
                            int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, from.Text, To.Text, obj_TravelDate, lblsize.Text, 1, Convert.ToInt32(lblunits.Text), "0", 1, 1, 0, 0, obj_DateOfExpiry, obj_LastDate, lblremarks.Text + "- Cutoff Time is " + CutoffTime, 1, Convert.ToInt32(ddl_type.SelectedValue), 0, lblpacktype.Text, lblcity.Text, BidStartTime);

                            //string[] argsss = { };
                            //string[] argssval = { };
                            //int res_Response = con1.Sql_ExecuteNonQuery("", argsss, argssval);


                            if (obj_Response > 0)
                            {
                                int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, from.Text, To.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, lblpacktype.Text, 0, Convert.ToInt32(ddl_type.SelectedValue), 0, 0, 0, Convert.ToDouble(txtwt.Text), 0, Convert.ToDouble(txtlen.Text), 0, Convert.ToDouble(txtbdth.Text), 0, Convert.ToDouble(txtwth.Text), 0, 0, 0, Convert.ToInt32(lblunits.Text), 0, 1, 1, 0, 0, 0, 1, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), lblremarks.Text + "- Cutoff Time is " + CutoffTime, 1, 0, 0, lblcity.Text, 0);
                                if (resp > 0)
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                                    CreateDataTable();
                                    //SendMail();
                                }
                                else
                                {
                                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Oops!Something Went Wrong!!');</script>");
                                }
                            }
                           
                            //if (obj_Response > 0)
                            //{
                              
                            //}
                            //else
                            //{
                            //    
                            //}
                            ////int result = obj_BizConnectLogisticsPlanClass.InsertPostRFQ_TMS(Convert.ToInt32(Session["ClientID"].ToString()), obj_AdID, from.Text, lblcity.Text, "NA", Convert.ToInt32(lbltrucktype.Text), Convert.ToInt32(lblenctype.Text), Convert.ToInt32(lbltruck.Text), Convert.ToSingle(lblcapacity.Text), "NA", lblremarks.Text);

                            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                            ////GridRouteplan.DataSource = null;
                            ////GridRouteplan.DataBind();
                            ////Session["data"] = "";
                            //CreateDataTable();
                        }

                        catch (Exception ex)
                        {

                        }
                    }

                }
            }
        }
        else
        {
            try
            {

                //length2 = txt_L1.Text.Trim();
                //width2 = txt_wt1.Text.Trim();
                //height2 = txt_H1.Text.Trim();
                //breath2 = txt_B1.Text.Trim();

                //string size2 = "L1- " + length2 + "," + "B1- " + breath2 + "," + "H1- " + height2 + "," + "Weight1- " + width2;
           
                string obj_AdID = "";
                DateTime dtt = new DateTime();
                dtt = Convert.ToDateTime(txt_traveldate.Text);
                string date = dtt.ToString("dd-MMM-yyyy");
                //string size = "L- " + txtlen.Text + "," + "B- " + txtbdth.Text + "," + "H- " + txtwth.Text + "," + "Weight- " + txtwt.Text;
                obj_AdID = SameAdIDProcess(txt_source.Text, txt_dest.Text, date.ToString());
                DateTime obj_TravelDate, obj_DateOfExpiry, obj_LastDate;

                obj_TravelDate = Convert.ToDateTime(date.ToString());

                obj_DateOfExpiry = obj_TravelDate;
                obj_LastDate = obj_TravelDate;

                CutoffTime = ddlhours.SelectedValue.ToString() + ":" + ddlminutes.SelectedValue.ToString() + " " + ddlampm.SelectedValue.ToString();
                BidStartTime = "BidStartTime is " + ddl_hours.SelectedValue.ToString() + ":" + ddl_minutes.SelectedValue.ToString() + " " + ddl_am_pm.SelectedValue.ToString();
                //int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, txt_source.Text, txt_dest.Text, obj_TravelDate, size, 1, Convert.ToInt32(txtunits.Text), "0", 1, 1, 0, 0, obj_DateOfExpiry, obj_LastDate, txtrem.Text + "- Cutoff Time is " + CutoffTime, 1, Convert.ToInt32(ddl_type.SelectedValue), 0, ddlpacktype.SelectedItem.Text, txtcity.Text, BidStartTime);

                //if (obj_Response > 0)
                //{
                //    int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, txt_source.Text, txt_dest.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, ddlpacktype.SelectedItem.Text, 0, Convert.ToInt32(ddl_type.SelectedValue), 0, 0, 0, Convert.ToDouble(txtwt.Text), 0, Convert.ToDouble(txtlen.Text), 0, Convert.ToDouble(txtbdth.Text), 0, Convert.ToDouble(txtwth.Text), 0, 0, 0, Convert.ToInt32(txtunits.Text), 0, 1, 1, 0, 0, 0, 1, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), txtrem.Text + "- Cutoff Time is " + CutoffTime, 1, 0, 0, txtcity.Text, 0);
                //}
                //else
                //{
                //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Oops!Something went wrong!!');</script>");
                //}

                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                //CreateDataTable();

                //----Madhu-----//
                string _date = DateTime.Now.ToString();
                string Ad_ID = obj_AdID;
                string userid = Session["UserID"].ToString();
                string postbyid = "3";
                string source = txt_source.Text;
                string destination = txt_dest.Text;
                string traveldate = obj_TravelDate.ToString();
                string size = "L- " + txtlen.Text + "," + "B- " + txtbdth.Text + "," + "H- " + txtwth.Text + "," + "Weight- " + txtwt.Text; ;
                string GoodsTypeID = "1";
                string nooftrucks = txtunits.Text;
                string truckcapacity = "0";
                string trucktypeid = "1";
                string enclosuretypeid = "1";
                string costpertruck = "0";
                string TotalTruckCost = "0";
                string posteddatetime = _date;
                string PostExpiryDateTimeStamp = obj_TravelDate.ToString();
                string PostQuoteLastDateTimeStamp = obj_TravelDate.ToString();
                string AdditionalComments = txtrem.Text + "- Cutoff Time is " + CutoffTime;
                string commentdatetime = _date;
                string GroupID = "1";
                string TravelType = ddl_type.SelectedValue.ToString();
                string TruckModelID = "0";
                string CapacityUnit = ddlpacktype.SelectedItem.Text;
                string City = txtcity.Text;
                string BidstartTime = BidStartTime;

                //if (length2 == "0" && width2 == "0" && height2 == "0" && breath2 == "0")
                //{
                //    totalsize = size;
                //}
                //else
                //{
                //    totalsize = size + "<br>" + size2;
                //}

                string[] args = { "@ad_id", "@postbyid", "@posttypeid", "@fromlocation", "@tolocation", "@traveldate", "@goodsdesc", "@goodtypeid", "@nooftrucks", "@truckcapacity", "@trucktypeid", "@enclosuretypeid", "@costpertruck", "@totaltruckcost", "@posteddatetimestamp", "@PostExpiryDateTimeStamp", "@PostQuoteLastDateTimeStamp", "@AdditionalComments", "@commentdatetime", "@GroupID", "@TravelType", "@TruckModelID", "@CapacityUnit", "@City", "@BidStartTime", "@res" };
                string[] argsval = { Ad_ID, userid, postbyid, source, destination, traveldate, size, GoodsTypeID, nooftrucks, truckcapacity, trucktypeid, enclosuretypeid, costpertruck, TotalTruckCost, posteddatetime, PostExpiryDateTimeStamp, PostQuoteLastDateTimeStamp, AdditionalComments, commentdatetime, GroupID, TravelType, TruckModelID, CapacityUnit, City, BidstartTime, "0" };
                int _res = con1.Sql_ExecuteNonQuery("SP_Insert_PostAD_Parcel", args, argsval);
                if (_res > 0)
                {
                    //Session["PostID"] = _res;
                    string today_date = DateTime.Now.ToString();
                    string ad_id = obj_AdID.ToString();
                    string cid = Session["ClientID"].ToString();
                    string user_id = Session["UserID"].ToString();
                    string custid = "1";
                    string aarmsid = "0";
                    string locationtype = "1";
                    string _source = txt_source.Text;
                    string _destination = txt_dest.Text;
                    string travel_date = obj_TravelDate.ToString();
                    string procat = "1";
                    string prodtype = "1";
                    string prodid = "1";
                    string productname = ddlpacktype.SelectedItem.Text;
                    string quality = "0";
                    string traveltype = ddl_type.SelectedValue.ToString();
                    string traveldist = "0";
                    string traveldistid = "0";
                    string _costpertruck = "0";
                    string weight = txtwt.Text;
                    string weightid = "0";
                    string length = txtlen.Text;
                    string lengthid = "0";
                    string width = txtbdth.Text;
                    string widthid = "0";
                    string height = txtwth.Text;
                    string heightid = "0";
                    string volume = "0";
                    string volumeid = "0";
                    string _nooftrucks = txtunits.Text;
                    string quantity = "0";
                    string _trucktypeid = "1";
                    string _enclid = "1";
                    string truckband = "0";
                    string modelid = "0";
                    string shipmentid = "0";
                    string _truckcapacity = "1";
                    string capacityid = "0";
                    string travelgrpid = "0";
                    string remarks = txtrem.Text + "- Cutoff Time is " + CutoffTime;
                    string statusid = "1";
                    string isactive = "0";
                    string transitday = "0";
                    string _city = txtcity.Text;
                    string cidprice = "0";

                    string[] _args = { "@ad_id", "@clientid", "@userid", "@custid", "@aarmsid", "@junctionid", "@locationtypeid", "@fromlocation", "@tolocation", "@traveldate", "@producttypeid", "@productcategoryid", "@produtid", "@productname", "@quantity", "@traveltypeid", "@traveldist", "@traveldistid", "@costpertruck", "@weight", "@weightid", "@length", "@lengthid", "@width", "@widthid", "@height", "@heightid", "@volume", "@volumeid", "@nooftrucks", "@quantitypertruck", "@trucktypeid", "@enclosuretypeid", "@truckbrandid", "@truckmodelid", "@shipmentid", "@truckcapacity", "@truckcapacityid", "@travelgrpid", "@lastdateforreceiving", "@lastdateforclosing", "@lastdatetomodify", "@remarks", "@statusid", "@isactive", "@createddate", "@lastupdate", "@transitday", "@city", "@clientprice" };
                    string[] _argsval = { ad_id, cid, user_id, custid, aarmsid, ad_id, locationtype, _source, _destination, travel_date, procat, prodtype, prodid, productname, quality, traveltype, traveldist, traveldistid, _costpertruck, weight, weightid, length, lengthid, width, widthid, height, heightid, volume, volumeid, _nooftrucks, quantity, _trucktypeid, _enclid, truckband, modelid, shipmentid, _truckcapacity, capacityid, travelgrpid, travel_date, travel_date, travel_date, remarks, statusid, isactive, today_date, today_date, transitday, _city, cidprice };
                    int resp1 = con.Sql_ExecuteNonQuery("SP_Insert_BizLogistics_Parcel", _args, _argsval);
                    if (resp1 > 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                        CreateDataTable();
                        //SendMail();
                    }
                    else
                    {
                        //string[] myargs = { "@PostID" };
                        //string[] myargsval = { _res.ToString() };
                        //int ress = con1.Sql_ExecuteNonQuery("SP_Delete_PostID_scmJunction_PostAd_byPostID", myargs, myargsval);
                        //if (ress > 0)
                        //{
                           
                        //}

                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Oops!Something Went Wrong!!');</script>");
                        
                    }
                    //int resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(obj_AdID.ToString(), Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["UserID"].ToString()), 1, 0, obj_AdID.ToString(), 1, txt_source.Text, txt_dest.Text, Convert.ToDateTime(obj_TravelDate), 1, 1, 1, ddlpacktype.SelectedItem.Text, 0, Convert.ToInt32(ddl_type.SelectedValue), 0, 0, 0, Convert.ToDouble(txtwt.Text), 0, Convert.ToDouble(txtlen.Text), 0, Convert.ToDouble(txtbdth.Text), 0, Convert.ToDouble(txtwth.Text), 0, 0, 0, Convert.ToInt32(txtunits.Text), 0, 1, 1, 0, 0, 0, 1, 0, 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), txtrem.Text + "- Cutoff Time is " + CutoffTime, 1, 0, 0, txtcity.Text, 0);
                    //if (resp > 0)
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Saved Successfully');</script>");
                    //    CreateDataTable();
                    //}
                    //else
                    //{
                    //    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Oops!Something Went Wrong!!');</script>");
                    //}
                }
               
            }


                //int obj_Response = obj_ClassPostAd.Insert_AdPost(obj_AdID, Convert.ToInt32(Session["UserID"].ToString()), 3, txt_source.Text, txt_dest.Text, obj_TravelDate,
            //    size, 1, Convert.ToInt32(txtunits.Text), "0", 1, 1, 0, 0, obj_DateOfExpiry, obj_LastDate, txtrem.Text + "- Cutoff Time is " + CutoffTime, 1, 
            //    Convert.ToInt32(ddl_type.SelectedValue), 0, ddlpacktype.SelectedItem.Text, txtcity.Text, BidStartTime);







            catch (Exception ex)
            {

            }
    
        }
    }

   

    private string SameAdIDProcess(string obj_FromLocation, string obj_ToLocation, string obj_TravelDte)
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
    
    private void SendMail()
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
            
                ds = obj_class.Bizconnect_GetTransporterForBidding(Convert.ToInt32(Session["ClientID"].ToString()));
            
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //  for (int i = 0; i <= 0; i++)
            {

                string obj_CLName = dset.Tables[0].Rows[0].ItemArray[0].ToString();
                string obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                string obj_Rid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                CutoffTime = ddlhours.SelectedValue.ToString() + ":" + ddlminutes.SelectedValue.ToString() + " " + ddlampm.SelectedValue.ToString();
                Session["CutoffTime"] = CutoffTime;
                string date = txt_traveldate.Text;
                BidStartTime = "BidStartTime is " + ddl_hours.SelectedValue.ToString() + ":" + ddl_minutes.SelectedValue.ToString() + " " + ddl_am_pm.SelectedValue.ToString();
                Session["GroupID"] = 1;
                if (Session["ClientID"].ToString() != null)
                {
                    foreach (GridViewRow row in gv_parceldetails.Rows)
                    {
                        CheckBox check = (CheckBox)row.FindControl("CheckBox1");
                        if (radmultiple.Checked || radsingle.Checked)
                        {
                            obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/GQuotePrice_Parcel.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + date + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "&cutofftime=" + Session["CutoffTime"].ToString() + " > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                            try
                            {
                                obj_Message11 = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/BiddingWeb.aspx?UserID=" + Session["UserID"].ToString() + "&Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "> Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                                string mymaill = "madhuchoudhary@miisky.com,prabhat.92pbt@gmail.com,manasabsrinivas@gmail.com";
                                int obj_resp11 = em.SendEmail(mymaill, obj_FromEmail, obj_Password, "", "", obj_FromEmail, mymaill, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message11.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                            }
                            catch (Exception ex)
                            {

                            }
                            //obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img style='width:200px;height:80px;' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://localhost:55044/SCMJunction/GQuotePrice_Parcel.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + date + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "&cutofftime=" + Session["CutoffTime"].ToString() + " > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                        }
                        //else
                        //{
                        //    obj_Message = "<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  style='width:200px;height:80px' src=http://www.scmjunction.com/images/scm_junction_logo.png /></center></td></tr> <tr><td style='padding: 0 0 20px;'><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please Quote your competative price for various trips</td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmjunction.com/GQuotePrice_Parcel.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + "&TDate=" + txt_traveldate.Text + "&Uid=" + Session["UserID"].ToString() + "&Bct=" + Server.UrlEncode(Encrypt(CutoffTime.ToString())) + "&GrpID=" + Session["GroupID"].ToString() + "  > Click the link to Quote your Price for " + obj_CLName.ToString() + "</a></center> </td></tr> <tr><td style='padding: 0 0 20px'>NOTE: Please quote your price before  " + CutoffTime.ToString() + ", System will close the bidding at " + CutoffTime.ToString() + "</td> </tr> <tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td > AARMS VALUE CHAIN PRIVATE LIMITED</td></tr><tr><td>#211, Temple Street,9th Main Road,BEML 3rd stage,</td></tr> <tr><td >RajarajeshwariNagar,Bangalore - 560098</td></tr><tr><td >Ph:080-66270268;09739870001</td></tr><tr><td >www.scmjunction.com</td></tr> </table></td></tr></table></div></td> </table>";
                        //}
                      //int obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                        int obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Request for your Quote -No Grace Time. Today's Cut off Time " + CutoffTime.ToString(), obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                       
                        //   int obj_resp = em.SendEmail("nandha@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Request for your Quote", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                    }
                }
            }

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
                            for (int j = 0; j <= gv_parceldetails.Rows.Count - 1; j++)
                            {
                                body += "<tr><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][0] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][1] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][2] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][3] + "</font></td><td align=center><font size=2 >" + dt_TripDetails.Tables[0].Rows[j][5] + "</font></td><td align=center><font size=2>" + dt_TripDetails.Tables[0].Rows[j][6] + " </font></td></tr>";
                            }
                            body += "</table>";

                           // int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "connectscm", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                            int resp=em.SendEmail("madhuchoudhary@miisky.com","","","","","", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                            Session["Trip"] = "";
                        }
                    }
                    else
                    {
                        tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Details</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>FromLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>ToLocation</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoOfTrucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td></tr>";
                        body += "<tr><td align=center><font size=2>" + Request.Form["autocomplete"].ToString() + "</font></td><td align=center><font size=2 >" + Request.Form["autocomplete1"].ToString() + "</font></td><td align=center><font size=2 >" + txt_traveldate.Text + "</font></td><td align=center><font size=2>" + txtunits.Text + "</font></td><td align=center><font size=2 >" + ddl_type.SelectedItem.Text + "</font></td><td align=center><font size=2>" + ddlpacktype.SelectedItem.Text + " </font></td></tr></table>";
                        //int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/>Client has posted a trip plan. <br/>Client Name :" + dt.Rows[0][0].ToString() + "<br/> Please Check and do the needfull.<br/><br/>" + tableheader + body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                    }
                    // int resp = em.SendEmail("aarms_logistics@aarmscmsolutions.com;shashidhar@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "connect@scmsolutions.com", obj_BounceBakEmail, "Alert-Trip Plan Posted by Client", "Dear Sir,<br/><br/>Client has posted a trip plan. <br>Client Name :" + dt.Rows[0][0].ToString() + "<br> Please Check and do the needfull.", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                }
            }
        catch (Exception ex)
        {

        }
        
}
        
    private string Encrypt(string obj_Rid)
    {
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] inputByteArray = Encoding.UTF8.GetBytes(obj_Rid);
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

    protected void ChkAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)gv_parceldetails.HeaderRow.FindControl("checkAll");
        if (chk !=null & chk.Checked)
        {
            for (int i = 0; i < gv_parceldetails.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)gv_parceldetails.Rows[i].FindControl("CheckBox1");

                chkrow.Checked = true;

            }

        }
        else
        {
            for (int i = 0; i < gv_parceldetails.Rows.Count; i++)
            {
                CheckBox chkrow = (CheckBox)gv_parceldetails.Rows[i].FindControl("CheckBox1");
                chkrow.Checked = false;

            }
        }

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            //length2 = txt_L1.Text.Trim();
            //width2 = txt_wt1.Text.Trim();
            //height2 = txt_H1.Text.Trim();
            //breath2 = txt_B1.Text.Trim();

            //string size2 = "L1- " + length2 + "," + "B1- " + breath2 + "," + "H1- " + height2 + "," + "Weight1- " + width2;
           
            // cleardata();
            string source_from = txt_source.Text;
            string destination_to = txt_dest.Text ;
            string source_pickup = txtpick.Text;
            string destination_city = txtcity.Text;
            string delivery_type = ddl_type.SelectedItem.Value;
            string no_of_units = txtunits.Text;
            string packing_type = ddlpacktype.SelectedItem.ToString();
            string size = "L- " + txtlen.Text + "," + "B- " + txtbdth.Text + "," + "H- " + txtwth.Text + "," + "Weight- " + txtwt.Text;
            string remarks = txtrem.Text;
            string bid_start_time = ddl_hours.SelectedValue.ToString() + ":" + ddl_minutes.SelectedValue.ToString() + ":" + ddl_am_pm.SelectedValue.ToString();
            string cut_off_time = ddlhours.SelectedValue.ToString() + ":" + ddlminutes.SelectedValue.ToString() + ":" + ddlampm.SelectedValue.ToString();


            //if (length2 == "0" && width2 == "0" && height2 == "0" && breath2 == "0")
            //{
            //    totalsize = size;
            //}
            //else
            //{
            //    totalsize = size + "<br>" + size2;
            //}


            DateTime dtt = new DateTime();
            dtt = Convert.ToDateTime(txt_traveldate.Text);
            string travel_date = dtt.ToString("MM/dd/yyyy");
            try
            {
                String cnstr = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
                using (SqlConnection con = new SqlConnection(cnstr))
                {
                    using (SqlCommand cmd = new SqlCommand("SP_Insert_Parcel_details", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@source_from", source_from);
                        cmd.Parameters.AddWithValue("@source_pickup", txtpick.Text);
                        cmd.Parameters.AddWithValue("@destination_to", destination_to);
                        cmd.Parameters.AddWithValue("@destination_city", txtcity.Text);
                        cmd.Parameters.AddWithValue("@delivery_type", ddl_type.SelectedItem.Value);
                        cmd.Parameters.AddWithValue("@no_of_units", txtunits.Text);
                        cmd.Parameters.AddWithValue("@packing_type", ddlpacktype.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@size", size);
                        cmd.Parameters.AddWithValue("@remarks", txtrem.Text);
                        cmd.Parameters.AddWithValue("@bid_start_time", bid_start_time);
                        cmd.Parameters.AddWithValue("@cut_off_time ", cut_off_time);
                        cmd.Parameters.AddWithValue("@travel_date", travel_date);
                        con.Open();
                        int res = cmd.ExecuteNonQuery();
                        if (res > 0)
                        {
                            String conn = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
                            using (SqlConnection con1 = new SqlConnection(conn))
                            {
                                using (SqlCommand cmd1 = new SqlCommand("SP_Get_Parcel_details", con1))
                                {
                                    SqlDataAdapter sda = new SqlDataAdapter();
                                    try
                                    {
                                        cmd1.Connection = con1;
                                        con1.Open();
                                        sda.SelectCommand = cmd1;

                                        DataSet ds = new DataSet();
                                        sda.Fill(ds);

                                        // BIND DATABASE WITH THE GRIDVIEW.
                                        gv_parceldetails.DataSource = ds;
                                        gv_parceldetails.DataBind();
                                        btnsubmit.Visible = true;
                                    }
                                    catch (Exception ex)
                                    {
                                    }

                                }
                            }
                        }



                    }
                }
            }
            catch (Exception ex)
            {
            }
        }catch(Exception ex)
        {
        }
       
    }
    protected string Values;
    protected void Post(object sender, EventArgs e)
    {
        string[] textboxValues = Request.Form.GetValues("DynamicTextBox");
        string[] textboxValues1 = Request.Form.GetValues("DynamicTextBox1");
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        this.Values = serializer.Serialize(textboxValues);
        this.Values = serializer.Serialize(textboxValues1);
        string message = "";
        foreach (string textboxValue in textboxValues)
        {
            message += textboxValue + "\\n";
        }
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
    }
    #region RakeshSendsmsemailapi
    public void sendsmssend()
    {
        string crid = "";
        string _mailid = "";
        string _cmobile = "";
        DateTime dttb = new DateTime();
        dttb = Convert.ToDateTime(txt_traveldate.Text);
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
                        message = "Req." + " for " + clientname + " " + " From " + txt_source.Text + " To " + txt_dest.Text + " on " + dateb.ToString() + "  Check the mail for Quoting Thanks"; ;
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



    
}


 
