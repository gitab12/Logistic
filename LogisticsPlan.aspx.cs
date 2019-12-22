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

public partial class LogisticsPlan : System.Web.UI.Page
{
    String obj_Authenticated;
    PlaceHolder maPlaceHolder = new PlaceHolder();
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_bannerCtrl;
    String obj_ClientID, obj_ClientCode, obj_ClientName;
    
    Int32 obj_Resp=0;
    Int32 obj_LocationTypeID = 0;

    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();

    DateTime obj_TripDate;
    DateTime obj_LastDateForQuote;
    DateTime obj_LastDateForClosingDeal;
    Int32 obj_LogisticsPlanID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
         if (IsPostBack == false)
          {
            Bind();
          }
        }
        
          else
        {
            Response.Redirect("Index.html");
        }
    }
   
    public void Bind()
    {
        CheckAuthentication();
        GenerateRandomString();

        drpDesignation1.Visible = false;
        drpDesignation2.Visible = false;

        //txtOtherProductCategory.Visible = false;
       

        txtOtherProductName.Visible = false;
        

        Panel1.Enabled = false;
        Panel2.Enabled = false;
        PanelProductAndPackingMethodDetails.Enabled = false;
        PanelTruckDetails.Enabled = false;
        PanelAdditionalInformation.Enabled = false;
        Panel3.Enabled = false;

        //drpName1.Items.Insert(0, new ListItem("--- List ---", "0"));
        //drpName2.Items.Insert(0, new ListItem("--- List ---", "0"));
        //drpLocationType1.Items.Insert(0, new ListItem("--- Location Type ---", "0"));
        //drpLocationType2.Items.Insert(0, new ListItem("--- Location Type ---", "0"));
        //drpLocationCity1.Items.Insert(0, new ListItem("--- City List ---", "0"));
        //drpLocationCity2.Items.Insert(0, new ListItem("--- City List ---", "0"));
        //drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        //drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        //drpTravelType.Items.Insert(0, new ListItem("--- Travel Type ---", "0"));
        //drpProductType.Items.Insert(0, new ListItem("--- Product Type ---", "0"));
        //drpProductCategory.Items.Insert(0, new ListItem("--- Category ---", "0"));
        //drpProductName.Items.Insert(0, new ListItem("--- Product Name ---", "0"));
        //drpTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
        //drpEnclosureType.Items.Insert(0, new ListItem("--- Enclosure Type ---", "0"));
        //drpTruckBrand.Items.Insert(0, new ListItem("--- Truck Brand ---", "0"));
        //drpTruckModel.Items.Insert(0, new ListItem("--- Truck model ---", "0"));

        DisableLocationOther1();
        DisableLocationOther2();
        FillTravelType();
        FillTruckType();
        FillEnclosureType();
        FillTruckBrand();
    }

    //Authentication Process
    public void CheckAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

       // obj_Navi = null;
       // obj_Navihome = null;

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
    
    //Generate String Randomly
    public void GenerateRandomString()
    {
        DateTime obj_CurrentDate;
        obj_CurrentDate = DateTime.Now.Date;
        String obj_DateStr;
        obj_DateStr = obj_CurrentDate.ToString("ddMMyyyy");
        String obj_LogosticsPlanString = "";
        obj_LogosticsPlanString = RandomString(4, false) + '-';
        
        obj_LogisticsPlanID = obj_BizConnectLogisticsPlanClass.get_MaxLogisticsPlanID();
        Session["LogisticsPlanID"] = 0;
        Session["LogisticsPlanID"] = obj_LogisticsPlanID;
        obj_LogosticsPlanString += obj_DateStr+"-"+ obj_LogisticsPlanID.ToString();
        lblLogisticsPlaneNo.Text = obj_LogosticsPlanString;
    }

    //Random Generation of String
    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    //Fill Route Type
    public void FillTravelType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillTravelType();
        if (ds.Tables["TravelType"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpTravelType.DataSource = ds.Tables["TravelType"];
            drpTravelType.DataTextField = "TravelType";
            drpTravelType.DataValueField = "TravelTypeID";
            drpTravelType.DataBind();
            drpTravelType.Items.Insert(0, new ListItem("--- Travel Type ---", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }

    //Fill Location Type
    public void FillLocationType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillLocationType();
        if (ds.Tables["LocationType"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpLocationType1.DataSource = ds.Tables["LocationType"];
            drpLocationType1.DataTextField = "LocationType";
            drpLocationType1.DataValueField = "LocationTypeID";
            drpLocationType1.DataBind();
            drpLocationType1.Items.Insert(0, new ListItem("--- Location Type ---", "0"));

            //For Location Type2 DropdownlistBox
            drpLocationType2.DataSource = ds.Tables["LocationType"];
            drpLocationType2.DataTextField = "LocationType";
            drpLocationType2.DataValueField = "LocationTypeID";
            drpLocationType2.DataBind();
            drpLocationType2.Items.Insert(0, new ListItem("--- Location Type ---", "0"));

        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }

    public void FillTruckType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillTruckType();
        if (ds.Tables["TruckType"].Rows.Count > 0)
        {
            drpTruckType.Items.Clear();
            drpTruckType.DataSource = ds.Tables["TruckType"];
            drpTruckType.DataTextField = "TruckType";
            drpTruckType.DataValueField = "TruckTypeID";
            drpTruckType.DataBind();
            drpTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        //drpTruckType.Items.Add("Other");
    }

    public void FillEnclosureType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillEnclosureType();
        if (ds.Tables["EnclosureType"].Rows.Count > 0)
        {
            drpEnclosureType.Items.Clear();
            drpEnclosureType.DataSource = ds.Tables["EnclosureType"];
            drpEnclosureType.DataTextField = "EnclosureType";
            drpEnclosureType.DataValueField = "EnclosureTypeID";
            drpEnclosureType.DataBind();
            drpEnclosureType.Items.Insert(0, new ListItem("--- Enclosure Type ---", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        //drpEnclosureType.Items.Add("Other");
    }

    public void FillTruckBrand()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillTruckBrand();
        if (ds.Tables["TruckBrand"].Rows.Count > 0)
        {
            drpTruckBrand.Items.Clear();
            drpTruckBrand.DataSource = ds.Tables["TruckBrand"];
            drpTruckBrand.DataTextField = "TruckBrandName";
            drpTruckBrand.DataValueField = "TruckBrandID";
            drpTruckBrand.DataBind();
            drpTruckBrand.Items.Insert(0, new ListItem("--- Truck Brand ---", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        //drpTruckBrand.Items.Add("Other");
    }
    
    public void DisableLocationOther1()
    {
        drpLocationType1.Visible = true;
        drpLocationType1.DataBind();
        drpLocationAddress1.Visible = true;
        drpLocationAddress1.DataBind();
        drpLocationCity1.Visible = true;
        drpLocationCity1.DataBind();

        //txtLocationType1.Visible = false;
        txtLocationCity1.Visible = false;
        txtLocationAddress1.Visible = false;
        //txtLocationType1.Text = "";
        txtLocationAddress1.Text = "";
        txtLocationCity1.Text = "";
        txtLocationCountry1.Text = "";
        txtBoardNo1.Text = "";
        txtCorporateEmail1.Text = "";
        txtLocationState1.Text = "";
    }

    public void DisableLocationOther2()
    {
        drpLocationType2.Visible = true;
        drpLocationType2.DataBind();
        drpLocationAddress2.Visible = true;
        drpLocationAddress2.DataBind();
        drpLocationCity2.Visible = true;
        drpLocationCity2.DataBind();

        //txtLocationType2.Visible = false;
        txtLocationCity2.Visible = false;
        txtLocationAddress2.Visible = false;
        //txtLocationType2.Text = "";
        txtLocationAddress2.Text = "";
        txtLocationCity2.Text = "";
        txtLocationCountry2.Text = "";
        txtBoardNo2.Text = "";
        txtCorporateEmail2.Text = "";
        txtLocationState2.Text = "";
    }

    protected void RadioButtonSale_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonSale.Checked == true)
        {
            RadioButtonTransfer.Checked = false;
            RadioButtonTransfer.DataBind();

                
            //Clear the Text
            txtLocationCity1.Text = "";
            txtLocationAddress1.Text = "";
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
            txtContactPerson1.Text = "";
            txtDesignation1.Text = "";
            txtMobileNumber1.Text = "0";

            txtLocationCity2.Text = "";
            txtLocationAddress2.Text = "";
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";
            txtContactPerson2.Text = "";
            txtDesignation2.Text = "";
            txtMobileNumber2.Text = "0";
        }
        obj_Resp= TripDateValidation();
        if (obj_Resp > 0)
        {
            

            //TripDateValidator.IsValid = true;
            System.Threading.Thread.Sleep(1000);
            Panel1.Enabled = true;
            Panel2.Enabled = true;
            Panel3.Enabled = true;
            PanelProductAndPackingMethodDetails.Enabled = true;
            PanelTruckDetails.Enabled = true;
            PanelAdditionalInformation.Enabled = true;
            Panel1.DataBind();
            Panel2.DataBind();
            Panel3.DataBind();
            PanelProductAndPackingMethodDetails.DataBind();
            PanelTruckDetails.DataBind();
            PanelAdditionalInformation.DataBind();

            if (RadioButtonSale.Checked == true)
            {
                FillLocationType();
                //RadioButtonTransfer.Checked = false;
                //RadioButtonTransfer.DataBind();

                lblCode1.Text = Session["ClientCode"].ToString();
                drpName1.Items.Clear();
                drpName1.Items.Add(Session["ClientName"].ToString());
                drpName1.SelectedItem.Text = Session["ClientName"].ToString();

                drpName2.Visible = true;
                drpName2.Items.Clear();
                //Fill Customer Name dpending on the ClientID
                FillCustomerByClientID();
                lblCode2.Text = "";
            }
            drpLocationAddress1.Items.Clear();
            drpLocationAddress2.Items.Clear();
            drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
            drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
            drpLocationCity1.Items.Clear();
            drpLocationCity2.Items.Clear();
            drpLocationCity1.Items.Insert(0, new ListItem("--- City ---", "0"));
            drpLocationCity2.Items.Insert(0, new ListItem("--- City ---", "0"));

            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";

            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
        }
    }

    //Trip Date Validation
    public Int32 TripDateValidation()
    {
        Int32 resp = 0;
        Int32 obj_QuoteReceivingValue=0;
        Int32  obj_QuoteClosingValue=0;

        DateTime obj_Dt;
        TimeSpan obj_QuoteReceivingTimeSpan;
        TimeSpan obj_QuoteClosingTimeSpan;

        ArrayList arr = new ArrayList();

        if (txtTravelDate.Text != "")
        {
            
            string obj_TripDt = txtTravelDate.Text.Trim();
            obj_TripDate = DateTime.Parse(obj_TripDt, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);     //TypeDescriptor.GetConverter(obj_Date).ConvertFrom(dt);
            if (obj_TripDate < DateTime.Now.Date)
            {
                lblMessageTop.Text = "Date should be greater then Current Date...!";
               // TripDateValidator.IsValid = false;
                //TripDateValidator.DataBind();
                resp = 0;
                RadioButtonSale.Checked = false;
                RadioButtonSale.DataBind();
                RadioButtonTransfer.Checked = false;
                RadioButtonTransfer.DataBind();
            }
            else
            {
                arr = obj_BizConnectLogisticsPlanClass.FillUserConfigurationMasterByKeyName("ReceivingQuote");
                if (arr.Count > 0)
                {
                    obj_QuoteReceivingValue = Convert.ToInt32(arr[0].ToString());
                    obj_QuoteReceivingTimeSpan = new TimeSpan(obj_QuoteReceivingValue, 0, 0);
                    obj_Dt = obj_TripDate.Subtract(obj_QuoteReceivingTimeSpan);
                    txtLastDateForReceivingQuotes.Text = obj_Dt.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtLastDateForReceivingQuotes.Text = "Config Table Empty";
                }

                /////
                arr.Clear();
                obj_Dt = DateTime.Now.Date ;
                arr = obj_BizConnectLogisticsPlanClass.FillUserConfigurationMasterByKeyName("ClosingQuote");
                if (arr.Count > 0)
                {
                    obj_QuoteClosingValue = Convert.ToInt32(arr[0].ToString());
                    obj_QuoteClosingTimeSpan = new TimeSpan(obj_QuoteClosingValue, 0, 0);
                    obj_Dt = obj_TripDate.Subtract(obj_QuoteClosingTimeSpan);
                    txtLastDateForClosingDeal.Text = obj_Dt.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtLastDateForClosingDeal.Text = "Config Table Empty";
                }
                lblMessageTop.Text = "";
                lblMessageTop.DataBind();
               // TripDateValidator.IsValid = true;
               // TripDateValidator.DataBind();
                resp = 1;
                
            }
        }
        else if (txtTravelDate.Text == "")
        {
            lblMessageTop.Text = "Trip Date should not be Empty...!";
            //TripDateValidator.IsValid = false;
           // TripDateValidator.DataBind();
            resp= 0;
            RadioButtonSale.Checked = false;
            RadioButtonSale.DataBind();
            RadioButtonTransfer.Checked = false;
            RadioButtonTransfer.DataBind();
        }
        //else
        //{
            
        //    lblMessageTop.Text = "";
        //    lblMessageTop.DataBind();
        //    resp= 1;
        //}
        return resp;
    }

    //Fill Customer By Client ID
    public void FillCustomerByClientID()
    {
        DataSet ds = new DataSet();
        Int32 obj_ClientID;
        obj_ClientID=Convert.ToInt32(Session["ClientID"].ToString());
        ds = obj_BizConnectLogisticsPlanClass.FillCustomerByClientID(obj_ClientID);
        if (ds.Tables["Customer"].Rows.Count > 0)
        {
            if (RadioButtonSale.Checked == true)
            {
                drpName2.DataSource = ds.Tables["Customer"];
                drpName2.DataTextField = "CompanyName";
                drpName2.DataValueField = "CustomerID";
                drpName2.DataBind();
                drpName2.Items.Insert(0, new ListItem("--- Customer List ---", "0"));
            }
            else if (RadioButtonTransfer.Checked == true)
            {
                drpName1.DataSource = ds.Tables["Customer"];
                drpName1.DataTextField = "CompanyName";
                drpName1.DataValueField = "CustomerID";
                drpName1.DataBind();
                drpName1.Items.Insert(0, new ListItem("--- Customer List ---", "0"));
            }
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }
    //Fill Customer By Client ID
    public void FillClientByClientID()
    {
        DataSet ds = new DataSet();
        Int32 obj_ClientID;
        obj_ClientID = Convert.ToInt32(Session["ClientID"].ToString());
        ds = obj_BizConnectLogisticsPlanClass.FillClientByClientID(obj_ClientID);
        if (ds.Tables["Customer"].Rows.Count > 0)
        {
            if (RadioButtonSale.Checked == true)
            {
                drpName2.DataSource = ds.Tables["Customer"];
                drpName2.DataTextField = "CompanyName";
                drpName2.DataValueField = "CustomerID";
                drpName2.DataBind();
                drpName2.Items.Insert(0, new ListItem("--- Customer List ---", "0"));
            }
            else if (RadioButtonTransfer.Checked == true)
            {
                drpName1.DataSource = ds.Tables["Customer"];
                drpName1.DataTextField = "CompanyName";
                drpName1.DataValueField = "ClientID";
                drpName1.DataBind();
                drpName1.Items.Insert(0, new ListItem("--- Client List ---", "0"));
            }
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }
    protected void RadioButtonTransfer_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonTransfer.Checked == true)
        {

            RadioButtonSale.Checked = false;
            RadioButtonSale.DataBind();
            
            //Clear the Text
            txtLocationCity1.Text = "";
            txtLocationAddress1.Text = "";
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
            txtContactPerson1.Text = "";
            txtDesignation1.Text = "";
            txtMobileNumber1.Text = "0";

            txtLocationCity2.Text = "";
            txtLocationAddress2.Text = "";
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";
            txtContactPerson2.Text = "";
            txtDesignation2.Text = "";
            txtMobileNumber2.Text = "0";
        }
        obj_Resp = TripDateValidation();
        if (obj_Resp > 0)
        {
            System.Threading.Thread.Sleep(1000);
         //   TripDateValidator.IsValid = true;
            Panel1.Enabled = true;
            Panel2.Enabled = true;
            Panel3.Enabled = true;
            PanelProductAndPackingMethodDetails.Enabled = true;
            PanelTruckDetails.Enabled = true;
            PanelAdditionalInformation.Enabled = true;
            Panel1.DataBind();
            Panel2.DataBind();
            Panel3.DataBind();
            PanelProductAndPackingMethodDetails.DataBind();
            PanelTruckDetails.DataBind();
            PanelAdditionalInformation.DataBind();

            if (RadioButtonTransfer.Checked == true)
            {
                FillLocationType();
                //RadioButtonSale.Checked = false;
                //RadioButtonSale.DataBind();

                lblCode2.Text = Session["ClientCode"].ToString();
                drpName2.Items.Clear();
                drpName2.Items.Add(Session["ClientName"].ToString());
                drpName2.SelectedItem.Text = Session["ClientName"].ToString();

                drpName1.Visible = true;
                drpName1.Items.Clear();
                //Fill Customer Name dpending on the ClientID
                //FillCustomerByClientID();old code
                FillClientByClientID();


                lblCode1.Text = "";

            }
            drpLocationAddress1.Items.Clear();
            drpLocationAddress2.Items.Clear();
            drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
            drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
            drpLocationCity1.Items.Clear();
            drpLocationCity2.Items.Clear();
            drpLocationCity1.Items.Insert(0, new ListItem("--- City ---", "0"));
            drpLocationCity2.Items.Insert(0, new ListItem("--- City ---", "0"));

            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";

            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
        }
    }
 
    protected void drpLocationCity1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpLocationCity1.SelectedItem.Text == "Other")
        {
            drpLocationAddress1.Items.Clear();
            drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
            txtLocationCity1.Visible = true;
            txtLocationAddress1.Visible = true;
            txtContactPerson1.Text = "";
            txtDesignation1.Text = "";
            txtMobileNumber1.Text = "0";
            txtLocationCity1.Focus();

            //Resize the Panel
            PanelShipmentDetails.Height = 660;
            Panel1.Height = 380;
        }
        else
        {
            //Resize the Panel back
            PanelShipmentDetails.Height = 630;
            Panel1.Height = 365;
            String obj_City;
            obj_City = drpLocationCity1.SelectedItem.Text.ToString();
            FillAddressByCity(obj_City);
        }
    }

    //Fill Address Details depending on the Selected City
    public void FillAddressByCity(String obj_Cy)
    {
        if (RadioButtonSale.Checked == true)
        {
            drpLocationAddress1.Visible = true;
            //txtLocationType1.Visible = false;
            txtLocationCity1.Visible = false;
            txtLocationAddress1.Visible = false;
            //Fill Address Details depending on the Selected City.
           

            DataSet ds = new DataSet();
            int obj_LocationTypeID = 0;
            drpLocationAddress1.Items.Clear();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType1.SelectedValue.ToString());
            obj_ClientID = Session["ClientID"].ToString();

            //ds = obj_BizConnectLogisticsPlanClass.FillClientAddressByClientIDandLocationTypeIDByCity(Convert.ToInt32(obj_ClientID), obj_LocationTypeID, obj_Cy);
            //if (ds.Tables["ClientAddress"].Rows.Count > 0)
            //{
            //    drpLocationAddress1.DataSource = ds.Tables["ClientAddress"];
            //    drpLocationAddress1.DataTextField = "Address";
            //    drpLocationAddress1.DataValueField = "ClientAddressLocationID";old
            ds = obj_BizConnectLogisticsPlanClass.FillClientAddressByClientIDandLocationTypeIDByCity(Convert.ToInt32(obj_ClientID), obj_LocationTypeID, obj_Cy);
            if (ds.Tables["ClientAddress"].Rows.Count > 0)
            {
                drpLocationAddress1.DataSource = ds.Tables["ClientAddress"];
                drpLocationAddress1.DataTextField = "Address";
                drpLocationAddress1.DataValueField = "ClientAddressLocationID";
                drpLocationAddress1.DataBind();
                //drpLocationCity1.Items.Insert(drpLocationCity1.Items.Count, new ListItem("Other", "0"));
                drpLocationAddress1.Items.Insert(0, new ListItem("--- Address ---", "0"));
            }
            else
            {

                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            //For Other Option
            drpLocationAddress1.Items.Add("Other");
            drpLocationAddress1.Focus();
        }
        else if (RadioButtonTransfer.Checked == true)
        {
            drpLocationAddress1.Visible = true;
            //txtLocationType1.Visible = false;
            txtLocationCity1.Visible = false;
            txtLocationAddress1.Visible = false;
            //Fill Address Details depending on the Selected City.

            DataSet ds = new DataSet();
            String obj_CustomerID;
            int obj_LocationTypeID = 0;
            drpLocationAddress1.Items.Clear();
            obj_CustomerID = drpName1.SelectedValue.ToString();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType1.SelectedValue.ToString());
            obj_ClientID = Session["ClientID"].ToString();
            //ds = obj_BizConnectLogisticsPlanClass.FillCustomerAddressByCustomerIDandLocationTypeIDByCity(Convert.ToInt32(obj_CustomerID), obj_LocationTypeID, obj_Cy);
            //if (ds.Tables["CustomerAddress"].Rows.Count > 0)
            //{
            //    drpLocationAddress1.DataSource = ds.Tables["CustomerAddress"];
            //    drpLocationAddress1.DataTextField = "Address";
            //    drpLocationAddress1.DataValueField = "CustomerAddressLocationID"; old
            ds = obj_BizConnectLogisticsPlanClass.FillClientAddressByClientIDandLocationTypeIDByCity(Convert.ToInt32(obj_ClientID), obj_LocationTypeID, obj_Cy);
            if (ds.Tables["ClientAddress"].Rows.Count > 0)
            {
                drpLocationAddress1.DataSource = ds.Tables["ClientAddress"];
                drpLocationAddress1.DataTextField = "Address";
                drpLocationAddress1.DataValueField = "ClientAddressLocationID";

                drpLocationAddress1.DataBind();
                //drpLocationCity1.Items.Insert(drpLocationCity1.Items.Count, new ListItem("Other", "0"));
                drpLocationAddress1.Items.Insert(0, new ListItem("--- Address ---", "0"));
            }
            else
            {

                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }

            if (drpLocationAddress1.Items.Count < 1)
            {
                drpLocationAddress1.Items.Add("No Address Found");
            }
            //For Other Option
            drpLocationAddress1.Items.Add("Other");
            drpLocationAddress1.Focus();
        }
    }

    protected void drpLocationCity2_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDistance();
         System.Threading.Thread.Sleep(1000);
         if (drpLocationCity2.SelectedItem.Text == "Other")
            {
                drpLocationAddress2.Items.Clear();
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                txtLocationCity2.Visible = true;
                txtLocationAddress2.Visible = true;
                txtLocationCity2.Focus();

                //Resize the Panel
                PanelShipmentDetails.Height = 660;
                Panel1.Height = 380;
            }
         else
         {
                //Resize the Panel back
             PanelShipmentDetails.Height = 630;
             Panel1.Height = 365;
             String obj_City;
             obj_City = drpLocationCity2.SelectedItem.Text.ToString();
             FillAddressByCity2(obj_City);
         }
    }

    //Fill Address Details depending on the Selected City
    public void FillAddressByCity2(String obj_Cy)
    {
        if (RadioButtonSale.Checked == true)
        {
            drpLocationAddress2.Visible = true;
            //txtLocationType2.Visible = false;
            txtLocationCity2.Visible = false;
            txtLocationAddress2.Visible = false;
            //Fill Address Details depending on the Selected City.

            DataSet ds = new DataSet();
            String obj_CustomerID;
            int obj_LocationTypeID = 0;
            drpLocationAddress2.Items.Clear();
            obj_CustomerID = drpName2.SelectedValue.ToString();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType2.SelectedValue.ToString());
            ds = obj_BizConnectLogisticsPlanClass.FillCustomerAddressByCustomerIDandLocationTypeIDByCity(Convert.ToInt32(obj_CustomerID), obj_LocationTypeID, obj_Cy);
            if (ds.Tables["CustomerAddress"].Rows.Count > 0)
            {
                drpLocationAddress2.DataSource = ds.Tables["CustomerAddress"];
                drpLocationAddress2.DataTextField = "Address";
                drpLocationAddress2.DataValueField = "CustomerAddressLocationID";

                drpLocationAddress2.DataBind();
                //drpLocationCity1.Items.Insert(drpLocationCity1.Items.Count, new ListItem("Other", "0"));
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address ---", "0"));
            }
            else
            {

                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }

            if (drpLocationAddress2.Items.Count < 1)
            {
                drpLocationAddress2.Items.Add("No Address Found");
            }
            //For Other Option
            drpLocationAddress2.Items.Add("Other");
            drpLocationAddress2.Focus();
        }
        else if (RadioButtonTransfer.Checked == true)
        {
            drpLocationAddress2.Visible = true;
            //txtLocationType2.Visible = false;
            txtLocationCity2.Visible = false;
            txtLocationAddress2.Visible = false;
            //Fill Address Details depending on the Selected City.


            DataSet ds = new DataSet();
            int obj_LocationTypeID = 0;
            drpLocationAddress2.Items.Clear();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType2.SelectedValue.ToString());
            obj_ClientID = Session["ClientID"].ToString();

            ds = obj_BizConnectLogisticsPlanClass.FillClientAddressByClientIDandLocationTypeIDByCity(Convert.ToInt32(obj_ClientID), obj_LocationTypeID, obj_Cy);
            if (ds.Tables["ClientAddress"].Rows.Count > 0)
            {
                drpLocationAddress2.DataSource = ds.Tables["ClientAddress"];
                drpLocationAddress2.DataTextField = "Address";
                drpLocationAddress2.DataValueField = "ClientAddressLocationID";

                drpLocationAddress2.DataBind();
                //drpLocationCity2.Items.Insert(drpLocationCity1.Items.Count, new ListItem("Other", "0"));
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address ---", "0"));
            }
            else
            {

                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            //For Other Option
            drpLocationAddress2.Items.Add("Other");
            drpLocationAddress2.Focus();
        }
    }

    protected void drpLocationAddress1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpLocationAddress1.SelectedItem.Text == "Other")
        {
            txtLocationAddress1.Visible = true;
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
            txtLocationAddress1.Focus();

            //Resize the Panel
            PanelShipmentDetails.Height = 660;
            Panel1.Height = 380;
       }
        else
        {
            //Resize the Panel Back
            PanelShipmentDetails.Height = 630;
            Panel1.Height = 365;
           
            Int32 obj_ClientAddressLocationTypeID;
            obj_ClientAddressLocationTypeID = Convert.ToInt32(drpLocationAddress1.SelectedValue.ToString());
            DisplayClientDetailsByAddress(obj_ClientAddressLocationTypeID);
           
        }
    }

    //Fill Address Details depending on the Selected City
    public void DisplayClientDetailsByAddress(Int32 obj_AddressLocationTypeID)
    {
        if (RadioButtonSale.Checked == true)
        {
            txtLocationAddress1.Visible = false;
            //Fill Complete Address Details in text Box depending on the Selected Address.

            //Get_BizConnect_ClientAddressLocationByID
            ArrayList arr = new ArrayList();
            arr = obj_BizConnectLogisticsPlanClass.FillClientAddressDetailsByClientLocationTypeID(obj_AddressLocationTypeID);
            if (arr.Count > 0)
            {
                txtLocationState1.Text = arr[1].ToString();
                txtLocationCountry1.Text = arr[2].ToString();
                txtBoardNo1.Text = arr[3].ToString();
                txtCorporateEmail1.Text = arr[4].ToString();
                txtContactPerson1.Text = arr[5].ToString();
                txtDesignation1.Text = arr[6].ToString();
                txtMobileNumber1.Text = arr[7].ToString();
                txtLocationPinCode1.Text = arr[8].ToString();
                txtFaxNo1.Text = arr[9].ToString();
            }
            else 
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            txtLastDateForReceivingQuotes.Focus();
        }
        else if (RadioButtonTransfer.Checked == true)
        {
            txtLocationAddress1.Visible = false;
            //Fill Complete Address Details in text Box depending on the Selected Address.

            //Get_BizConnect_ClientAddressLocationByID
            ArrayList arr = new ArrayList();
           // arr = obj_BizConnectLogisticsPlanClass.FillCustomerAddressDetailsByCustomerLocationTypeID(obj_AddressLocationTypeID);old
            arr = obj_BizConnectLogisticsPlanClass.FillClientAddressDetailsByClientLocationTypeID(obj_AddressLocationTypeID);
            if (arr.Count > 0)
            {
                txtLocationState1.Text = arr[1].ToString();
                txtLocationCountry1.Text = arr[2].ToString();
                txtBoardNo1.Text = arr[3].ToString();
                txtCorporateEmail1.Text = arr[4].ToString();
                txtContactPerson1.Text = arr[5].ToString();
                txtDesignation1.Text = arr[6].ToString();
                txtMobileNumber1.Text = arr[7].ToString();
                txtLocationPinCode1.Text = arr[8].ToString();
                txtFaxNo1.Text = arr[9].ToString();
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            txtLastDateForReceivingQuotes.Focus();
        }
        
    }

    public void FillDistanceUnit()
    {
        System.Threading.Thread.Sleep(1000);
        DataSet ds = new DataSet();
        ds.Clear();
        ds = obj_BizConnectLogisticsPlanClass.FillUnit(5);
        if (ds.Tables["Unit"].Rows.Count > 0)
        {
            //For Units for Travel Distance
            drpTravelDistanceUnit.Items.Clear();
            drpTravelDistanceUnit.DataSource = ds.Tables["Unit"];
            drpTravelDistanceUnit.DataTextField = "Unit";
            drpTravelDistanceUnit.DataValueField = "UnitID";
            drpTravelDistanceUnit.DataBind();
            drpTravelDistanceUnit.Items.Insert(0, new ListItem("- Units -", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }

    public void FillDistance()
    {
        string obj_from, obj_to;
        DataSet ds = new DataSet();
        ds=obj_BizConnectLogisticsPlanClass.FillCityId(drpLocationCity1.SelectedItem.Text.ToString());
        obj_from = ds.Tables[0].Rows[0][0].ToString();

        DataSet dst = new DataSet();
        dst = obj_BizConnectLogisticsPlanClass.FillCityId(drpLocationCity2.SelectedItem.Text.ToString());
        obj_to = dst.Tables[0].Rows[0][0].ToString();

        System.Threading.Thread.Sleep(1000);
        ArrayList arr = new ArrayList();
        arr  = obj_BizConnectLogisticsPlanClass.get_citydistance(Convert.ToInt32(obj_from), Convert.ToInt32(obj_to));
        if (arr[0].ToString() == "1")
        {
            txtTravelDistance.Text = arr[3].ToString();
        }
        else
        {
            txtTravelDistance.Text = "0";

        }
    }
    protected void drpLocationAddress2_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        if (drpLocationAddress2.SelectedItem.Text == "Other")
        {
            txtLocationAddress2.Visible = true;
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";
            txtLocationAddress2.Focus();

            //Resize the Panel
            PanelShipmentDetails.Height = 660;
            Panel1.Height = 380;
        }
        else
        {
            //Resize the Panel Back
            PanelShipmentDetails.Height = 630;
            Panel1.Height = 365;
            
           
            Int32 obj_CustomerAddressLocationTypeID;
            obj_CustomerAddressLocationTypeID = Convert.ToInt32(drpLocationAddress2.SelectedValue.ToString());
            DisplayCustomerDetailsByAddress(obj_CustomerAddressLocationTypeID);
        }
    }

    public void DisplayCustomerDetailsByAddress(Int32 obj_AddressLocationTypeID)
    {
        if (RadioButtonSale.Checked == true)
        {
            txtLocationAddress2.Visible = false;
            //Fill Complete Address Details in text Box depending on the Selected Address.

            //Get_BizConnect_ClientAddressLocationByID
            ArrayList arr = new ArrayList();
            arr = obj_BizConnectLogisticsPlanClass.FillCustomerAddressDetailsByCustomerLocationTypeID(obj_AddressLocationTypeID);
            if (arr.Count > 0)
            {
                txtLocationState2.Text = arr[1].ToString();
                txtLocationCountry2.Text = arr[2].ToString();
                txtBoardNo2.Text = arr[3].ToString();
                txtCorporateEmail2.Text = arr[4].ToString();
                txtContactPerson2.Text = arr[5].ToString();
                txtDesignation2.Text = arr[6].ToString();
                txtMobileNumber2.Text = arr[7].ToString();
                txtLocationPinCode2.Text = arr[8].ToString();
                txtFaxNo2.Text = arr[9].ToString();
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            txtLastDateForReceivingQuotes.Focus();
        }
        else  if (RadioButtonTransfer.Checked == true)
        {
            txtLocationAddress2.Visible = false;
            //Fill Complete Address Details in text Box depending on the Selected Address.

            //Get_BizConnect_ClientAddressLocationByID
            ArrayList arr = new ArrayList();
            arr = obj_BizConnectLogisticsPlanClass.FillClientAddressDetailsByClientLocationTypeID(obj_AddressLocationTypeID);
            if (arr.Count > 0)
            {
                txtLocationState2.Text = arr[1].ToString();
                txtLocationCountry2.Text = arr[2].ToString();
                txtBoardNo2.Text = arr[3].ToString();
                txtCorporateEmail2.Text = arr[4].ToString();
                txtContactPerson2.Text = arr[5].ToString();
                txtDesignation2.Text = arr[6].ToString();
                txtMobileNumber2.Text = arr[7].ToString();
                txtLocationPinCode2.Text = arr[8].ToString();
                txtFaxNo2.Text = arr[9].ToString();
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            txtLastDateForReceivingQuotes.Focus();
        }
    }
   
    protected void drpLocationType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpLocationType1.SelectedItem.Text == "Other")
        {
            txtDesignation1.Visible = false;
            drpDesignation1.Visible = true;
            //Fill Designation
            FillDesignation1();


            //drpLocationType1.Visible = false;
            drpLocationCity1.Visible = false;
            drpLocationAddress1.Visible = false;

            //txtLocationType1.Visible = true;
            txtLocationCity1.Visible = true;
            txtLocationAddress1.Visible = true;
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
            txtContactPerson1.Text = "";
            txtDesignation1.Text = "";
            txtMobileNumber1.Text = "0";
            txtLocationState1.ReadOnly = false;
            txtLocationCountry1.ReadOnly = false;
            txtBoardNo1.ReadOnly = false;
            txtCorporateEmail1.ReadOnly = false;
            //txtLocationType1.Focus();


            //Resize the Panel
            PanelShipmentDetails.Height = 660;
            Panel1.Height = 380;
            
        }
        else
        {
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
            txtContactPerson1.Text = "";
            txtDesignation1.Text = "";
            txtMobileNumber1.Text = "0";

            //Make Designation dropdownlist visible off
            txtDesignation1.Visible = true;
            drpDesignation1.Visible = false;

            PanelShipmentDetails.Height = 630;
            Panel1.Height = 365;
            FillLocationCity();
        }
    }

    //Fill Designation - Left Side
    public void FillDesignation1()
    {
        drpDesignation1.Items.Clear();
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillDesignation();
        if (ds.Tables["Designation"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpDesignation1.DataSource = ds.Tables["Designation"];
            drpDesignation1.DataTextField = "Designation";
            drpDesignation1.DataValueField = "DesignationID";
            drpDesignation1.DataBind();
            drpDesignation1.Items.Insert(0, new ListItem("-- Designation --", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }

    

    //Fill Location City
    public void FillLocationCity()
    {
        if (RadioButtonSale.Checked == true)
        {
            //drpLocationType1.Visible = true;
            drpLocationAddress1.Visible = true;
            //txtLocationType1.Visible = false;
            txtLocationCity1.Visible = false;
            txtLocationAddress1.Visible = false;
            drpLocationCity1.Visible = true;
            drpLocationCity1.Items.Clear();

            DataSet ds = new DataSet();
            int obj_LocationTypeID = 0;
            drpLocationCity1.Items.Clear();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType1.SelectedValue.ToString());
            obj_ClientID = Session["ClientID"].ToString();
            ds = obj_BizConnectLogisticsPlanClass.FillClientCityByClientIDandLocationTypeID(Convert.ToInt32(obj_ClientID), obj_LocationTypeID);
            if (ds.Tables["ClientCity"].Rows.Count > 0)
            {
                drpLocationCity1.DataSource = ds.Tables["ClientCity"];
                drpLocationCity1.DataTextField = "City";
                drpLocationCity1.DataValueField = "City";

                drpLocationCity1.DataBind();
                //drpLocationCity1.Items.Insert(drpLocationCity1.Items.Count, new ListItem("Other", "0"));
                drpLocationCity1.Items.Insert(0, new ListItem("--- City ---", "0"));
                
            }
            else
            {

                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            //For Other Option
            drpLocationCity1.Items.Add("Other");
            drpLocationCity1.Focus();
        }
        else if (RadioButtonTransfer.Checked == true)
        {
            //drpLocationType2.Visible = true;
            drpLocationCity1.Visible = true;
            drpLocationAddress1.Visible = true;

            //txtLocationType1.Visible = false;
            txtLocationCity1.Visible = false;
            txtLocationAddress1.Visible = false;
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";

            DataSet ds = new DataSet();
            int obj_LocationTypeID = 0;
            String obj_CustomerID;
            drpLocationCity1.Items.Clear();
            obj_ClientID = Session["ClientID"].ToString();
            obj_CustomerID = drpName1.SelectedValue.ToString();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType1.SelectedValue.ToString());
           // ds = obj_BizConnectLogisticsPlanClass.FillCustomerCityByClientIDByCustomerIDLocationTypeID(Convert.ToInt32(obj_ClientID), Convert.ToInt32(obj_CustomerID), obj_LocationTypeID);
            //if (ds.Tables["CustomerCity"].Rows.Count > 0)
            //{
            //    drpLocationCity1.DataSource = ds.Tables["CustomerCity"];
            ds = obj_BizConnectLogisticsPlanClass.FillClientCityByClientIDandLocationTypeID(Convert.ToInt32(obj_ClientID), obj_LocationTypeID);
            if (ds.Tables["ClientCity"].Rows.Count > 0)
            {
                drpLocationCity1.DataSource = ds.Tables["ClientCity"];
                drpLocationCity1.DataTextField = "City";
                drpLocationCity1.DataValueField = "City";
               
                drpLocationCity1.DataBind();
                drpLocationCity1.Items.Insert(0, new ListItem("--- City ---", "0"));
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            if (drpLocationCity1.Items.Count < 1)
            {
                drpLocationCity1.Items.Add("No City Found");
            }
            //For Other Option
            drpLocationCity1.Items.Add("Other");
            drpLocationCity1.Focus();
        }
        
    }

    protected void drpLocationType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDistanceUnit();
       
        if (drpLocationType2.SelectedItem.Text == "Other")
        {
            txtDesignation2.Visible = false;
            drpDesignation2.Visible = true;
            FillDesignation2();

            //drpLocationType2.Visible = false;
            drpLocationCity2.Visible = false;
            drpLocationAddress2.Visible = false;

            //txtLocationType2.Visible = true;
            txtLocationCity2.Visible = true;
            txtLocationAddress2.Visible = true;
            txtLocationState2.ReadOnly = false;
            txtLocationCountry2.ReadOnly = false;
            txtBoardNo2.ReadOnly = false;
            txtCorporateEmail2.ReadOnly = false;

            txtLocationCity2.Text = "";
            txtLocationAddress2.Text = "";
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";
            txtContactPerson2.Text = "";
            txtMobileNumber2.Text = "0";

            //txtLocationType2.Focus();

            //Resize the Panel
            //PanelShipmentDetails.Height = 630;
            //Panel1.Height = 380;
        }
        else
        {
            //PanelShipmentDetails.Height = 580;
            //Panel1.Height = 320;

            txtLocationCity2.Text = "";
            txtLocationAddress2.Text = "";
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";
            txtContactPerson2.Text = "";
            txtDesignation2.Text = "";
            txtMobileNumber2.Text = "0";

            txtDesignation2.Visible = true;
            drpDesignation2.Visible = false;
            FillLocationCity2();
            
        }
    }


    //Fill Designation - Right Side
    public void FillDesignation2()
    {
        drpDesignation2.Items.Clear();
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillDesignation();
        if (ds.Tables["Designation"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpDesignation2.DataSource = ds.Tables["Designation"];
            drpDesignation2.DataTextField = "Designation";
            drpDesignation2.DataValueField = "DesignationID";
            drpDesignation2.DataBind();
            drpDesignation2.Items.Insert(0, new ListItem("-- Designation --", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }

    //Fill Location City
    public void FillLocationCity2()
    {
        if (RadioButtonSale.Checked == true)
        {
            //drpLocationType2.Visible = true;
            drpLocationCity2.Visible = true;
            drpLocationAddress2.Visible = true;

            //txtLocationType2.Visible = false;
            txtLocationCity2.Visible = false;
            txtLocationAddress2.Visible = false;
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";

            DataSet ds = new DataSet();
            int obj_LocationTypeID = 0;
            String obj_CustomerID;
            drpLocationCity2.Items.Clear();
            obj_ClientID = Session["ClientID"].ToString();
            obj_CustomerID = drpName2.SelectedValue.ToString();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType2.SelectedValue.ToString());
            ds = obj_BizConnectLogisticsPlanClass.FillCustomerCityByClientIDByCustomerIDLocationTypeID(Convert.ToInt32(obj_ClientID), Convert.ToInt32(obj_CustomerID), obj_LocationTypeID);
            if (ds.Tables["CustomerCity"].Rows.Count > 0)
            {
                drpLocationCity2.DataSource = ds.Tables["CustomerCity"];
                drpLocationCity2.DataTextField = "City";
                drpLocationCity2.DataValueField = "City";
                drpLocationCity2.DataBind();
                drpLocationCity2.Items.Insert(0, new ListItem("--- City ---", "0"));
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            if (drpLocationCity2.Items.Count < 1)
            {
                drpLocationCity2.Items.Add("No City Found");
            }
            //For Other Option
            drpLocationCity2.Items.Add("Other");
            drpLocationCity2.Focus();
        }
        else if (RadioButtonTransfer.Checked == true)
        {
            //drpLocationType2.Visible = true;
            drpLocationAddress2.Visible = true;
            //txtLocationType2.Visible = false;
            txtLocationCity2.Visible = false;
            txtLocationAddress2.Visible = false;
            drpLocationCity2.Visible = true;
            drpLocationCity2.Items.Clear();

            DataSet ds = new DataSet();
            int obj_LocationTypeID = 0;
            drpLocationCity2.Items.Clear();
            obj_LocationTypeID = Convert.ToInt32(drpLocationType2.SelectedValue.ToString());
            obj_ClientID = Session["ClientID"].ToString();
            ds = obj_BizConnectLogisticsPlanClass.FillClientCityByClientIDandLocationTypeID(Convert.ToInt32(obj_ClientID), obj_LocationTypeID);
            if (ds.Tables["ClientCity"].Rows.Count > 0)
            {
                drpLocationCity2.DataSource = ds.Tables["ClientCity"];
                drpLocationCity2.DataTextField = "City";
                drpLocationCity2.DataValueField = "City";

                drpLocationCity2.DataBind();
                //drpLocationCity2.Items.Insert(drpLocationCity1.Items.Count, new ListItem("Other", "0"));
                drpLocationCity2.Items.Insert(0, new ListItem("--- City ---", "0"));

            }
            else
            {

                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
            //For Other Option
            drpLocationCity2.Items.Add("Other");
            drpLocationCity2.Focus();
        }
    }
   
    protected void drpProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        FillProductCategory(Convert.ToInt32(drpProductType.SelectedItem.Value));
    }

    //Fill Products depending on the Selected Product Type
    public void FillProductCategory(Int32 obj_ProductCategoryID)
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillProductCategory(obj_ProductCategoryID);
        if (ds.Tables["ProductCategory"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpProductCategory.DataSource = ds.Tables["ProductCategory"];
            drpProductCategory.DataTextField = "CategoryName";
            drpProductCategory.DataValueField = "ProductCategoryID";
            drpProductCategory.DataBind();
            drpProductCategory.Items.Insert(0, new ListItem("--- Product Category ---", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        //drpProductCategory.Items.Add("Other");
        drpProductCategory.Focus();
    }
  
    protected void drpProductCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        FillTruckType();
        FillEnclosureType();
        FillTruckBrand();
        drpTruckModel.Items.Clear();
        txtTruckCapacity.Text = "0";
        txtQuantityPerTruck.Text = "0";
        txtTruckRequired.Text = "0";
        txtCostPerTruck.Text = "0";
        FillPackingMethods();

        System.Threading.Thread.Sleep(1000);
        if (drpProductCategory.SelectedItem.Text == "Other Solid Items" | drpProductCategory.SelectedItem.Text == "Other Liquid Items")
        {
            //txtOtherProductCategory.Visible = true;
            drpProductName.Items.Clear();
            drpProductName.Items.Add("Other");
            drpProductName.SelectedItem.Text = "Other";
            //drpProductName.Visible = false;
            txtOtherProductName.Visible = true;
            txtOtherProductName.Focus();
            PanelProductAndPackingMethodDetails.Height = 220;
            //txtOtherProductCategory.Focus();

        }
        else
        {
            drpProductName.Visible = true;
            //txtOtherProductCategory.Visible = false;
            txtOtherProductName.Visible = false;
            PanelProductAndPackingMethodDetails.Height = 175;
            
            //Filling Products Name
            DataSet ds = new DataSet();
            ds = obj_BizConnectLogisticsPlanClass.FillProductsName(Convert.ToInt32(drpProductCategory.SelectedItem.Value));
            //if (ds.HasErrors)
            //{
                if (ds.Tables["ProductsName"].Rows.Count > 0)
                {
                    //For Location Type1 DropdownlistBox
                    drpProductName.DataSource = ds.Tables["ProductsName"];
                    drpProductName.DataTextField = "ProductName";
                    drpProductName.DataValueField = "ProductID";
                    drpProductName.DataBind();
                    //drpProductName.Items.Add("Other");
                    drpProductName.Items.Insert(0, new ListItem("--- Product Name ---", "0"));
                    //drpProductName.Items.Insert(1, new ListItem("Other", "25"));
                }
                else
                {
                    drpProductName.Items.Clear();
                    drpProductName.Items.Add("Other");
                    drpProductName.Items.Insert(0, new ListItem("--- Product Name ---", "0"));
                   // drpProductName.Items.Insert(1, new ListItem("Other", "25"));

                    lblMessage.Text = "";
                    lblMessage.Text = "There is no Products under the above Product Category...!";
                }
            //}
            //else
            //{
            //    drpProductName.Items.Clear();
            //    drpProductName.Items.Add("Other");
            //    drpProductName.Items.Insert(0, new ListItem("--- Product Name ---", "0"));

            //    lblMessage.Text = "";
            //    lblMessage.Text = "There is no Products under the above Product Category...!";
            //}


            //if (ds.Tables["ProductsName"].Rows.Count > 0)
            //{
            //    drpProductName.Items.Add("Other");
            //}
            //drpProductName.Items.Add("Other");
            //else
            //{
            //    drpProductName.Items.Clear();
            //    drpProductName.Items.Add("Other");
            //    drpProductName.Items.Insert(0, new ListItem("--- Product Name ---", "0"));
            //}
            drpProductName.Focus();
        }
        
    }

    public void FillPackingMethods()
    {
        //Filling Packing Method Type
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillPackingMethodType();
        if (ds.Tables["PackingMethodType"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpPackingMethod1.DataSource = ds.Tables["PackingMethodType"];
            drpPackingMethod1.DataTextField = "PackingMethodType";
            drpPackingMethod1.DataValueField = "PackingMethodTypeID";
            drpPackingMethod1.DataBind();
            drpPackingMethod1.Items.Insert(0, new ListItem("-- Type --", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        drpPackingMethod1.Focus();
    }

    protected void drpProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpProductName.SelectedItem.Text == "Other")
        {
            ProductNameValidator.Enabled = true;
            txtOtherProductName.Visible = true;
            PanelProductAndPackingMethodDetails.Height = 210;
            txtOtherProductName.Focus();
        }
        else
        {
            ProductNameValidator.Enabled = false;
            txtOtherProductName.Visible = false;
            PanelProductAndPackingMethodDetails.Height = 175;
            drpPackingMethod1.Focus();
        }

            
    }
   
    protected void drpPackingMethod1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        //Filling Packing Methods depending on the Product Type
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillPackingMethods(Convert.ToInt32(drpProductType.SelectedItem.Value));
        if (ds.Tables["PackingMethods"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpPackingMethod2.Items.Clear();
            drpPackingMethod2.DataSource = ds.Tables["PackingMethods"];
            drpPackingMethod2.DataTextField = "PackingMethod";
            drpPackingMethod2.DataValueField = "PackingMethodID";
            drpPackingMethod2.DataBind();
            drpPackingMethod2.Items.Insert(0, new ListItem("-- Methods --", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        drpPackingMethod2.Focus();

        //Fill Units for All Dropdown Combo Box
        ds.Clear();
        ds = obj_BizConnectLogisticsPlanClass.FillUnit(1);
        if (ds.Tables["Unit"].Rows.Count > 0)
        {
            //For Units for Width
            drpProductWidthUnit.Items.Clear();
            drpProductWidthUnit.DataSource = ds.Tables["Unit"];
            drpProductWidthUnit.DataTextField = "Unit";
            drpProductWidthUnit.DataValueField = "UnitID";
            drpProductWidthUnit.DataBind();
            drpProductWidthUnit.Items.Insert(0, new ListItem("- Units -", "0"));

            //For Units for Length
            drpProductLengthUnit.Items.Clear();
            drpProductLengthUnit.DataSource = ds.Tables["Unit"];
            drpProductLengthUnit.DataTextField = "Unit";
            drpProductLengthUnit.DataValueField = "UnitID";
            drpProductLengthUnit.DataBind();
            drpProductLengthUnit.Items.Insert(0, new ListItem("- Units -", "0"));

            //For Units for Height
            drpProductHeightUnit.Items.Clear();
            drpProductHeightUnit.DataSource = ds.Tables["Unit"];
            drpProductHeightUnit.DataTextField = "Unit";
            drpProductHeightUnit.DataValueField = "UnitID";
            drpProductHeightUnit.DataBind();
            drpProductHeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }

        ////Fill Units for Quantity
        //ds.Clear();
        //ds = obj_BizConnectLogisticsPlanClass.FillUnit(1);
        //if (ds.Tables["Unit"].Rows.Count > 0)
        //{
        //    //For Units for Quantity
        //    drpProductWidthUnit.Items.Clear();
        //    drpProductWidthUnit.DataSource = ds.Tables["Unit"];
        //    drpProductWidthUnit.DataTextField = "Unit";
        //    drpProductWidthUnit.DataValueField = "UnitID";
        //    drpProductWidthUnit.DataBind();
        //    drpProductWidthUnit.Items.Insert(0, new ListItem("- Units -", "0"));
        //}
        //else
        //{
        //    lblMessage.Text = "";
        //    lblMessage.Text = "Empty Table";
        //}

        //Fill Units for Weight
        //ds.Clear();
        //ds = obj_BizConnectLogisticsPlanClass.FillUnit(2);
        //if (ds.Tables["Unit"].Rows.Count > 0)
        //{
        //    //For Units for Weight
        //    drpProductWeightUnit.Items.Clear();
        //    drpProductWeightUnit.DataSource = ds.Tables["Unit"];
        //    drpProductWeightUnit.DataTextField = "Unit";
        //    drpProductWeightUnit.DataValueField = "UnitID";
        //    drpProductWeightUnit.DataBind();
        //    drpProductWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));
        //}
        //else
        //{
        //    lblMessage.Text = "";
        //    lblMessage.Text = "Empty Table";
        //}

        //Fill Units for Volume
        ds.Clear();
        ds = obj_BizConnectLogisticsPlanClass.FillUnit(3);
        if (ds.Tables["Unit"].Rows.Count > 0)
        {
            //For Units for Volume
            drpProductVolumeUnit.Items.Clear();
            drpProductVolumeUnit.DataSource = ds.Tables["Unit"];
            drpProductVolumeUnit.DataTextField = "Unit";
            drpProductVolumeUnit.DataValueField = "UnitID";
            drpProductVolumeUnit.DataBind();
            drpProductVolumeUnit.Items.Insert(0, new ListItem("- Units -", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }

        //Fill Units for Quantity Per Truck
        //ds.Clear();
        //ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
        //if (ds.Tables["Unit"].Rows.Count > 0)
        //{
        //    //For Units for Volume
        //    drpQuantityPerTruck.Items.Clear();
        //    drpQuantityPerTruck.DataSource = ds.Tables["Unit"];
        //    drpQuantityPerTruck.DataTextField = "Unit";
        //    drpQuantityPerTruck.DataValueField = "UnitID";
        //    drpQuantityPerTruck.DataBind();
        //    drpQuantityPerTruck.Items.Insert(0, new ListItem("- Units -", "0"));
        //}
        //else
        //{
        //    lblMessage.Text = "";
        //    lblMessage.Text = "Empty Table";
        //}

        //Fill Truck Capacity Unit
        if (Convert.ToInt32(drpProductType.SelectedItem.Value) == 1) // For Solid Goods
        {
            ds.Clear();
            ds = obj_BizConnectLogisticsPlanClass.FillUnit(2);
            if (ds.Tables["Unit"].Rows.Count > 0)
            {
                //For Units for Volume
                drpTruckCapacityUnit.Items.Clear();
                drpTruckCapacityUnit.DataSource = ds.Tables["Unit"];
                drpTruckCapacityUnit.DataTextField = "Unit";
                drpTruckCapacityUnit.DataValueField = "UnitID";
                drpTruckCapacityUnit.DataBind();
                drpTruckCapacityUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Quantity Per Truck - Solid type of Goods
                drpQuantityPerTruck.Items.Clear();
                drpQuantityPerTruck.DataSource = ds.Tables["Unit"];
                drpQuantityPerTruck.DataTextField = "Unit";
                drpQuantityPerTruck.DataValueField = "UnitID";
                drpQuantityPerTruck.DataBind();
                drpQuantityPerTruck.Items.Insert(0, new ListItem("- Units -", "0"));

                

                //Fill Units for Weight Per Truck - Solid type of Goods
                drpProductWeightUnit.Items.Clear();
                drpProductWeightUnit.DataSource = ds.Tables["Unit"];
                drpProductWeightUnit.DataTextField = "Unit";
                drpProductWeightUnit.DataValueField = "UnitID";
                drpProductWeightUnit.DataBind();
                drpProductWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));
                
                //Fill Units for Quantity Unit - Solid type of Goods
                ds.Clear();
                ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
                drpQuantityUnit.Items.Clear();
                drpQuantityUnit.DataSource = ds.Tables["Unit"];
                drpQuantityUnit.DataTextField = "Unit";
                drpQuantityUnit.DataValueField = "UnitID";
                drpQuantityUnit.DataBind();
                drpQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
        }
        else if (Convert.ToInt32(drpProductType.SelectedItem.Value) == 2) // For Liquid Goods
        {
            ds.Clear();
            ds = obj_BizConnectLogisticsPlanClass.FillUnit(3);
            if (ds.Tables["Unit"].Rows.Count > 0)
            {
                //For Units for Volume
                drpTruckCapacityUnit.Items.Clear();
                drpTruckCapacityUnit.DataSource = ds.Tables["Unit"];
                drpTruckCapacityUnit.DataTextField = "Unit";
                drpTruckCapacityUnit.DataValueField = "UnitID";
                drpTruckCapacityUnit.DataBind();
                drpTruckCapacityUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Quantity Per Truck - Liquid type of Goods
                drpQuantityPerTruck.Items.Clear();
                drpQuantityPerTruck.DataSource = ds.Tables["Unit"];
                drpQuantityPerTruck.DataTextField = "Unit";
                drpQuantityPerTruck.DataValueField = "UnitID";
                drpQuantityPerTruck.DataBind();
                drpQuantityPerTruck.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Weight Per Truck - Liquid type of Goods
                drpProductWeightUnit.Items.Clear();
                drpProductWeightUnit.DataSource = ds.Tables["Unit"];
                drpProductWeightUnit.DataTextField = "Unit";
                drpProductWeightUnit.DataValueField = "UnitID";
                drpProductWeightUnit.DataBind();
                drpProductWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Quantity Unit - Liquid type of Goods
                ds.Clear();
                ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
                drpQuantityUnit.Items.Clear();
                drpQuantityUnit.DataSource = ds.Tables["Unit"];
                drpQuantityUnit.DataTextField = "Unit";
                drpQuantityUnit.DataValueField = "UnitID";
                drpQuantityUnit.DataBind();
                drpQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));
            }
            else
            {
                lblMessage.Text = "";
                lblMessage.Text = "Empty Table";
            }
        }


    }
  
    protected void drpPackingMethod2_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpPackingMethod2.SelectedItem.Text == "Liquid Container")
        {
            DisableWeightLengthWidthHeight();
            txtProductWidth.Text = "0";
            txtProductLength.Text = "0";
            txtProductHeight.Text = "0";
            txtQuantity.Text = "0";
            txtProductWeight.Text = "0";
            txtProductVolume.Text = "0";
            txtProductVolume.Focus();
        }
        else
        {
            EnableWeightLengthWidthHeight();
            txtProductWidth.Text = "0";
            txtProductLength.Text = "0";
            txtProductHeight.Text = "0";
            txtQuantity.Text = "0";
            txtProductWeight.Text = "0";
            txtProductVolume.Text = "0";
            txtProductWidth.Focus();
        }
    }

    //Disable Weight Length Width and Height
    public void DisableWeightLengthWidthHeight()
    {
        lblQuantityTitle.Enabled = false;
        QuantityValidator.Enabled = false;
        txtQuantity.Enabled = false;
        txtQuantity.Text = "";
        lblProductWeightTitle.Enabled = false;
        WeightValidator.Enabled = false;
        txtProductWeight.Enabled = false;
        txtProductWeight.Text = "";
        lblProductWeightUnitTitle.Enabled = false;
        drpProductWeightUnit.Enabled = false;
        lblProductLengthTitle.Enabled = false;
        LengthValidator.Enabled = false;
        txtProductLength.Enabled = false;
        txtProductLength.Text = "";
        lblProductLengthUnitTitle.Enabled = false;
        drpProductLengthUnit.Enabled = false;
        lblProductWidthTitle.Enabled = false;
        WidthValidator.Enabled = false;
        txtProductWidth.Enabled = false;
        txtProductWidth.Text = "";
        lblProductWidthUnitTitle.Enabled = false;
        drpProductWidthUnit.Enabled = false;
        lblProductHeightTitle.Enabled = false;
        HeightValidator.Enabled = false;
        txtProductHeight.Enabled = false;
        txtProductHeight.Text = "";
        lblProductHeightUnitTitle.Enabled = false;
        drpProductHeightUnit.Enabled = false;
        lblQtyPerTruckTitle.Enabled = false;
        QuantityPerTruckValidator.Enabled = false;
        txtQuantityPerTruck.Enabled = false;
        txtQuantityPerTruck.Text = "0";
        lblQuantityPerTruckUnitTitle.Enabled = false;
        drpQuantityPerTruck.Enabled = false;
        drpQuantityUnit.Enabled = false;


        lblProductVolumeTitle.Enabled = true;
        VolumeValidator.Enabled = true;
        txtProductVolume.Text = "";
        txtProductVolume.Enabled = true;
        lblProductVolumeUnitTitle.Enabled = true;
        drpProductVolumeUnit.Enabled = true;
    }

    //Enable Weight Length Width and Height
    public void EnableWeightLengthWidthHeight()
    {
        lblQuantityTitle.Enabled = true;
        QuantityValidator.Enabled = true;
        txtQuantity.Enabled = true;
        txtQuantity.Text = "";
        lblProductWeightTitle.Enabled = true;
        WeightValidator.Enabled = true;
        txtProductWeight.Enabled = true;
        txtProductWeight.Text = "";
        lblProductWeightUnitTitle.Enabled = true;
        drpProductWeightUnit.Enabled = true;
        lblProductLengthTitle.Enabled = true;
        LengthValidator.Enabled = true;
        txtProductLength.Enabled = true;
        txtProductLength.Text = "";
        lblProductLengthUnitTitle.Enabled = true;
        drpProductLengthUnit.Enabled = true;
        lblProductWidthTitle.Enabled = true;
        WidthValidator.Enabled = true;
        txtProductWidth.Enabled = true;
        txtProductWidth.Text = "";
        lblProductWidthUnitTitle.Enabled = true;
        drpProductWidthUnit.Enabled = true;
        lblProductHeightTitle.Enabled = true;
        HeightValidator.Enabled = true;
        txtProductHeight.Enabled = true;
        txtProductHeight.Text = "";
        lblProductHeightUnitTitle.Enabled = true;
        drpProductHeightUnit.Enabled = true;
        lblQtyPerTruckTitle.Enabled = true;
        QuantityPerTruckValidator.Enabled = true;
        txtQuantityPerTruck.Enabled = true;
        txtQuantityPerTruck.Text = "0";
        lblQuantityPerTruckUnitTitle.Enabled = true;
        drpQuantityPerTruck.Enabled = true;
        drpQuantityUnit.Enabled = true;


        lblProductVolumeTitle.Enabled = false;
        VolumeValidator.Enabled = false;
        txtProductVolume.Enabled = false;
        txtProductVolume.Text = "";
        lblProductVolumeUnitTitle.Enabled = false;
        drpProductVolumeUnit.Enabled = false;
    }

    protected void drpTruckBrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        DataSet ds = new DataSet();
        ds.Clear();
        ds = obj_BizConnectLogisticsPlanClass.FillTruckModelByBrandIDByCarrierGoodsType(Convert.ToInt32(drpTruckBrand.SelectedItem.Value),Convert.ToString(drpProductType.SelectedItem.Text.Trim()));
        if (ds.Tables["TruckModel"].Rows.Count > 0)
        {
            //For Units for Volume
            drpTruckModel.Items.Clear();
            drpTruckModel.DataSource = ds.Tables["TruckModel"];
            drpTruckModel.DataTextField = "TruckModel";
            drpTruckModel.DataValueField = "TruckModelID";
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("-- Models --", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
        drpTruckModel.Focus();
    }
 
    protected void drpTruckType_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpEnclosureType.Focus();
    }
  
    protected void drpEnclosureType_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpTruckBrand.Focus();
    }
 
    protected void drpTruckModel_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        txtTruckCapacity.Focus();
        //if (drpProductType.SelectedItem.Text == "Liquid")
        //{
        //    drpTruckCapacityUnit.Items.Clear();
        //    drpTruckCapacityUnit.Items.Add("Litters");
        //    drpTruckCapacityUnit.Items.Add("Kilo Litters");
        //}
        //else
        //{
        //    drpTruckCapacityUnit.Items.Clear();
        //    drpTruckCapacityUnit.Items.Add("Kgs");
        //    drpTruckCapacityUnit.Items.Add("Tonnes");
        //}
    }
   
    protected void drpTruckCapacityUnit_TextChanged(object sender, EventArgs e)
    {
        txtQuantityPerTruck.Focus();
    }
   
    protected void drpTravelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        obj_Resp = 0;
        obj_Resp = LastDateForeQuoteAndClosingValidation();
        if (obj_Resp > 0)
        {
            FillProductType();
            drpProductType.Focus();
        }
        else
        {
            txtLastDateForReceivingQuotes.Focus();
            FillTravelType();
        }
    }

    //Fill Product Types
 
    public void FillProductType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillProductType();
        if (ds.Tables["ProductType"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            drpProductType.DataSource = ds.Tables["ProductType"];
            drpProductType.DataTextField = "ProductType";
            drpProductType.DataValueField = "ProductTypeID";
            drpProductType.DataBind();
            drpProductType.Items.Insert(0, new ListItem("--- Product Type ---", "0"));
        }
        else
        {
            lblMessage.Text = "";
            lblMessage.Text = "Empty Table";
        }
    }
  
    public Int32 LastDateForeQuoteAndClosingValidation()
    {
        Int32 resp = 0;
        string obj_TripDt = txtTravelDate.Text.Trim();
        obj_TripDate = DateTime.Parse(obj_TripDt, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);     //TypeDescriptor.GetConverter(obj_Date).ConvertFrom(dt);
            
        string obj_LastDtForQuote = txtLastDateForReceivingQuotes.Text.Trim();
        obj_LastDateForQuote = DateTime.Parse(obj_LastDtForQuote, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);     //TypeDescriptor.GetConverter(obj_Date).ConvertFrom(dt);
        
        string obj_LastDtForClosingDeal  = txtLastDateForClosingDeal.Text.Trim();
        obj_LastDateForClosingDeal = DateTime.Parse(obj_LastDtForClosingDeal, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);     //TypeDescriptor.GetConverter(obj_Date).ConvertFrom(dt);
        
        if (obj_LastDateForQuote < DateTime.Now.Date)
        {
            resp = 0;
            LastDateForQuoteValidator.ErrorMessage = "Date should not be less then Current Date...!";
            LastDateForQuoteValidator.IsValid = false;
            LastDateForQuoteValidator.DataBind();
        }
        else if (obj_LastDateForQuote > obj_TripDate)
        {
            resp = 0;
            LastDateForQuoteValidator.ErrorMessage = "Date should not be greater then Trip Date...!";
            LastDateForQuoteValidator.IsValid = false;
            LastDateForQuoteValidator.DataBind();
        }
        else if (obj_LastDateForClosingDeal < DateTime.Now.Date)
        {
            resp = 0;
            LastDateForClosingValidator.ErrorMessage = "Date should not be less then Current Date...!";
            LastDateForClosingValidator.IsValid = false;
            LastDateForClosingValidator.DataBind();
        }
        else if (obj_LastDateForClosingDeal > obj_TripDate)
        {
            resp = 0;
            LastDateForClosingValidator.ErrorMessage = "Date should not be greater then Trip Date...!";
            LastDateForClosingValidator.IsValid = false;
            LastDateForClosingValidator.DataBind();
        }
        else
        {
            resp = 1;
            LastDateForQuoteValidator.ErrorMessage = "";
            LastDateForQuoteValidator.IsValid = true;
            LastDateForQuoteValidator.DataBind();
            LastDateForClosingValidator.IsValid = true;
            LastDateForClosingValidator.DataBind();
        }
        return resp;
    }

    protected void RadioButtonEvaluate_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonEvaluate.Checked == true)
        {
            RadioButtonManual.Checked = false;
            RadioButtonManual.DataBind();
            txtTruckCapacity.Text = "0";
            txtQuantityPerTruck.Text = "0";
            txtTruckRequired.Text = "0";
            txtCostPerTruck.Text = "0";
        }
    }
    
    protected void RadioButtonManual_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonManual.Checked == true)
        {
            RadioButtonEvaluate.Checked = false;
            RadioButtonEvaluate.DataBind();
            txtTruckCapacity.Text = "0";
            txtQuantityPerTruck.Text = "0";
            txtTruckRequired.Text = "0";
            txtCostPerTruck.Text = "0";
        }
    }
   
    protected void drpQuantityPerTruck_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtTruckRequired.Focus();
    }

    //Insertion function
    protected void cmdSubmit_Click(object sender, EventArgs e)
    {
        //TripDateValidator.Enabled = false;
        Int32 obj_resp;
        Int32 obj_ClientID;
        Int32 obj_UserID;
        Int32 obj_CustomerID;
        Int32 obj_AARMSUserID;
        Int32 obj_TravelGroupID;
        Int32 obj_StatusID;
        Int32 obj_ShipmentID;
        Int32 obj_ProductID;
        Int32 obj_TransportationMethodID;
        Double obj_ProductVolume;
        String obj_JunctionAdID;
        String obj_ProductName;
        String obj_FromFirstName, obj_FromMiddleName, obj_FromLastName, obj_ToFirstName, obj_ToMiddleName, obj_ToLastName,obj_FromCity, obj_ToCity, obj_FromAddress, obj_ToAddress, obj_FromState, obj_ToState, obj_FromCountry, obj_ToCountry, obj_FromCorporateEmail, obj_ToCorporateEmail,obj_FromBoardNumber,obj_ToBoardNumber,obj_FromFax,obj_ToFax;
        Int32  obj_FromPinCode,obj_ToPinCode;
        
        DateTime obj_TravelDate;
        DateTime obj_LastDateTimeStampForReceivingQuote;
        DateTime obj_LastDateTimeStampForClosingDeal;
        DateTime obj_LastDateTimeStampToModifyPlan;
        Int32  obj_IsActive;

        obj_FromFirstName = "Nil";
        obj_FromMiddleName = "Nil";
        obj_FromLastName = "Nil";
        obj_FromCity= "Nil";
        obj_FromAddress = "Nil";
        obj_FromState = "Nil";
        obj_FromCountry = "Nil";
        obj_FromPinCode = 0;
        obj_FromBoardNumber = "0";
        obj_FromFax = "0";
        obj_FromCorporateEmail = "Nil";

        obj_ToFirstName = "Nil";
        obj_ToMiddleName = "Nil";
        obj_ToLastName = "Nil";
        obj_ToCity = "Nil";
        obj_ToAddress = "Nil";
        obj_ToState = "Nil";
        obj_ToCountry = "Nil";
        obj_ToPinCode = 0;
        obj_ToBoardNumber = "0";
        obj_ToFax = "0";
        obj_ToCorporateEmail = "Nil";

        obj_ProductName = "Nil";

        obj_ClientID = Convert.ToInt32(Session["ClientID"]);
        obj_UserID =  Convert.ToInt32(Session["UserID"]);
        obj_CustomerID = Convert.ToInt32(Session["CustomerID"]);
        obj_AARMSUserID = Convert.ToInt32(Session["AARMSUserID"]);
        obj_JunctionAdID = "0"; //Convert.ToString(Session["JunctionAdID"]);
        obj_ShipmentID = 0;
        obj_TravelGroupID = 0;
        obj_StatusID = 2;
        obj_IsActive = 1;
        obj_ProductVolume = 0;
        obj_ProductID = 0;
        obj_TransportationMethodID=0;

        obj_TravelDate = DateTime.Parse(txtTravelDate.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
        obj_LastDateTimeStampForReceivingQuote = DateTime.Parse(txtLastDateForReceivingQuotes.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
        obj_LastDateTimeStampForClosingDeal = DateTime.Parse(txtLastDateForClosingDeal.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
        obj_LastDateTimeStampToModifyPlan = obj_LastDateTimeStampForClosingDeal; //DateTime.Parse(txtLastDateForEditingPlan.Text, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);

        if (RadioButtonSale.Checked == true)
        {
            if (drpLocationType1.SelectedItem.Text == "Other")
            {
                obj_FromCity = txtLocationCity1.Text.Trim();
                obj_FromAddress = txtLocationAddress1.Text.Trim();
                
            }
            else
            {
                obj_FromCity = drpLocationCity1.SelectedItem.Text.Trim();
                obj_FromAddress = drpLocationAddress1.SelectedItem.Text.Trim();

            }

            if (drpLocationType2.SelectedItem.Text == "Other")
            {
                obj_ToCity = txtLocationCity2.Text.Trim();
                obj_ToAddress = txtLocationAddress2.Text.Trim();
            }
            else
            {
                obj_ToCity = drpLocationCity2.SelectedItem.Text.Trim();
                obj_ToAddress = drpLocationAddress2.SelectedItem.Text.Trim();
            }
            
            //From Location
            obj_FromFirstName = drpName1.SelectedItem.Text.Trim();
            obj_FromMiddleName = "Nil";
            obj_FromLastName = "Nil";
            obj_FromState = txtLocationState1.Text.Trim();
            obj_FromCountry = txtLocationCountry1.Text.Trim();
            obj_FromBoardNumber = txtBoardNo1.Text;
            obj_FromPinCode = Convert.ToInt32(txtLocationPinCode1.Text.Trim());
            obj_FromFax = txtFaxNo1.Text;
            obj_FromCorporateEmail = txtCorporateEmail1.Text.Trim();

            //To Location
            obj_ToFirstName = drpName2.SelectedItem.Text.Trim();
            obj_ToMiddleName = "Nil";
            obj_ToLastName = "Nil";
            obj_ToState = txtLocationState2.Text.Trim();
            obj_ToCountry = txtLocationCountry2.Text.Trim();
            obj_ToBoardNumber = txtBoardNo2.Text;
            obj_ToPinCode = Convert.ToInt32(txtLocationPinCode2.Text.Trim());
            obj_ToFax = txtFaxNo2.Text;
            obj_ToCorporateEmail = txtCorporateEmail2.Text.Trim();
        }
        else if (RadioButtonTransfer.Checked == true)
        {
            if (drpLocationType1.SelectedItem.Text == "Other")
            {
                obj_FromCity = txtLocationCity1.Text.Trim();
                obj_FromAddress = txtLocationAddress1.Text.Trim();
            }
            else
            {
                obj_FromCity = drpLocationCity1.SelectedItem.Text.Trim();
                obj_FromAddress = drpLocationAddress1.SelectedItem.Text.Trim();
            }

            if (drpLocationType2.SelectedItem.Text == "Other")
            {
                obj_ToCity = txtLocationCity2.Text.Trim();
                obj_ToAddress = txtLocationAddress2.Text.Trim();
            }
            else 
            {
                obj_ToCity = drpLocationCity2.SelectedItem.Text.Trim();
                obj_ToAddress = drpLocationAddress2.SelectedItem.Text.Trim();
            }

           

            //From Location
            obj_FromFirstName = drpName1.SelectedItem.Text.Trim();
            obj_FromMiddleName = "Nil";
            obj_FromLastName = "Nil";
            obj_FromState = txtLocationState1.Text.Trim();
            obj_FromCountry = txtLocationCountry1.Text.Trim();
            obj_FromBoardNumber = txtBoardNo1.Text;
            obj_FromPinCode = Convert.ToInt32(txtLocationPinCode1.Text.Trim());
            obj_FromFax = txtFaxNo1.Text;
            obj_FromCorporateEmail = txtCorporateEmail1.Text.Trim();

            //To Location
            obj_ToFirstName = drpName2.SelectedItem.Text.Trim();
            obj_ToMiddleName = "Nil";
            obj_ToLastName = "Nil";
            obj_ToState = txtLocationState2.Text.Trim();
            obj_ToCountry = txtLocationCountry2.Text.Trim();
            obj_ToBoardNumber = txtBoardNo2.Text;
            obj_ToPinCode = Convert.ToInt32(txtLocationPinCode2.Text.Trim());
            obj_ToFax = txtFaxNo2.Text;
            obj_ToCorporateEmail = txtCorporateEmail2.Text.Trim();
        }

        if (drpPackingMethod2.SelectedItem.Text == "Liquid Container")
        {
            obj_ProductVolume = Convert.ToDouble(txtProductVolume.Text);
        }
        else
        {
            obj_ProductVolume = 0;
        }

        if (drpProductName.SelectedItem.Text == "Other")
        {
            obj_ProductName = txtOtherProductName.Text.Trim();
        }
        else
        {
            obj_ProductName = drpProductName.SelectedItem.Text.Trim();
        }

        if (drpProductCategory.SelectedItem.Text == "Other Solid Items" | drpProductCategory.SelectedItem.Text == "Other Liquid Items")
        {
            obj_ProductID = 0;
            obj_ProductName = txtOtherProductName.Text.Trim();
        }
        else if (drpProductCategory.SelectedItem.Text == "Other")
        {
            obj_ProductID = 0;
            obj_ProductName = txtOtherProductName.Text.Trim();
        }
        else
        {
            if (drpProductName.SelectedItem.Text == "Other")
            {
                //obj_ProductID = 0;
                obj_ProductID = Convert.ToInt32(drpProductName.SelectedItem.Value);
                obj_ProductName = txtOtherProductName.Text.Trim();
            }
            else
            {
                obj_ProductID = Convert.ToInt32(drpProductName.SelectedItem.Value);
                obj_ProductName = drpProductName.SelectedItem.Text.Trim();
            }
        }

        if(drpProductType.SelectedItem.Text=="Solid")
        {
            obj_TransportationMethodID=Convert.ToInt32( drpQuantityUnit.SelectedItem.Value);
        }
        else if(drpProductType.SelectedItem.Text=="Liquid")
        {
             obj_TransportationMethodID=Convert.ToInt32(drpProductVolumeUnit.SelectedItem.Value);
        }
      
        obj_LocationTypeID = Convert.ToInt32(Convert.ToInt32(drpLocationType1.SelectedItem.Value));// - 1
        obj_Resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(Convert.ToString(lblLogisticsPlaneNo.Text.Trim()), Convert.ToInt32(obj_ClientID), Convert.ToInt32(obj_UserID), Convert.ToInt32(obj_CustomerID), Convert.ToInt32(obj_AARMSUserID), Convert.ToString(obj_JunctionAdID), obj_LocationTypeID, Convert.ToString(obj_FromCity), Convert.ToString(obj_ToCity), Convert.ToDateTime(obj_TravelDate), Convert.ToInt32(drpProductType.SelectedValue.ToString()), Convert.ToInt32(drpProductCategory.SelectedValue.ToString()), obj_ProductID, Convert.ToString(obj_ProductName), Convert.ToDouble(txtQuantity.Text.Trim()), Convert.ToInt32(drpTravelType.SelectedValue.ToString()), Convert.ToInt32(txtTravelDistance.Text.Trim()), Convert.ToInt32(drpTravelDistanceUnit.SelectedItem.Value.ToString()), Convert.ToDouble(txtCostPerTruck.Text.Trim()), Convert.ToDouble(txtProductWeight.Text.Trim()), Convert.ToInt32(drpProductWeightUnit.SelectedValue.ToString()), Convert.ToDouble(txtProductLength.Text.Trim()), Convert.ToInt32(drpProductLengthUnit.SelectedValue.ToString()), Convert.ToDouble(txtProductWidth.Text.Trim()), Convert.ToInt32(drpProductWidthUnit.SelectedValue.ToString()), Convert.ToDouble(txtProductHeight.Text.Trim()), Convert.ToInt32(drpProductHeightUnit.SelectedValue.ToString()), Convert.ToDouble(obj_ProductVolume), Convert.ToInt32(drpProductVolumeUnit.SelectedValue.ToString()), Convert.ToInt32(txtTruckRequired.Text.Trim()), Convert.ToDouble(txtQuantityPerTruck.Text.Trim()), Convert.ToInt32(drpTruckType.SelectedValue.ToString()), Convert.ToInt32(drpEnclosureType.SelectedValue.ToString()), Convert.ToInt32(drpTruckBrand.SelectedValue.ToString()), Convert.ToInt32(drpTruckModel.SelectedValue.ToString()), Convert.ToInt32(obj_ShipmentID), Convert.ToDouble(txtTruckCapacity.Text.Trim()), Convert.ToInt32(drpTruckCapacityUnit.SelectedValue.ToString()), Convert.ToInt32(obj_TravelGroupID), Convert.ToDateTime(obj_LastDateTimeStampForReceivingQuote), Convert.ToDateTime(obj_LastDateTimeStampForClosingDeal), Convert.ToDateTime(obj_LastDateTimeStampToModifyPlan), Convert.ToString(txtAdditionalInformation.Text.Trim()), Convert.ToInt32(obj_StatusID), Convert.ToInt32(obj_IsActive),10,Convert.ToString(obj_ToCity),1);

        if (obj_Resp > 0)
        {
            Int32  obj_ShipmentType;
            
            //From Address
            obj_ShipmentType=1;
            //Insert From Record in Shipment Master
            obj_resp=0;
            obj_LogisticsPlanID = Convert.ToInt32(Session["LogisticsPlanID"]);
            obj_resp = obj_BizConnectLogisticsPlanClass.Insert_Shipment(obj_LogisticsPlanID, obj_ShipmentType,obj_FromFirstName,obj_FromMiddleName,obj_FromLastName,obj_FromCity,obj_FromAddress,obj_FromState,obj_FromCountry,obj_FromPinCode,obj_FromBoardNumber,obj_FromFax,obj_FromCorporateEmail,1);

            obj_ShipmentType = 2;
            //Insert From Record in Shipment Master
            obj_resp = 0;
            obj_resp = obj_BizConnectLogisticsPlanClass.Insert_Shipment(obj_LogisticsPlanID, obj_ShipmentType,obj_ToFirstName,obj_ToMiddleName,obj_ToLastName,obj_ToCity,obj_ToAddress,obj_ToState,obj_ToCountry,obj_ToPinCode,obj_ToBoardNumber,obj_ToFax,obj_ToCorporateEmail,1);
            if (obj_resp > 0)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Your Logistics Plan is Posted Sucessfully...!";
                obj_resp = 0;
              //  obj_resp=SendSMS(lblLogisticsPlaneNo.Text.Trim());
                if (obj_resp < 1)
                {

                }
               // obj_resp = SendEmail(lblLogisticsPlaneNo.Text.Trim(), obj_FromCity, obj_ToCity, txtTruckRequired.Text.Trim(), obj_TravelDate.ToString("dd-MMM-yyyy"),Convert.ToString(txtCostPerTruck.Text.Trim()));
                if (obj_resp < 1)
                {

                }
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Your Logistics Plan is Posted Cancelled...!";
            }
        }
        GenerateRandomString();
    }

    //Sending SMS after successfully Posting Ad 
    public Int32 SendSMS(String obj_PlanId)
    {
        String obj_UserId;
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_UID;
        String obj_Password;
        String obj_MobileNo;
        ArrayList arr = new ArrayList();

        obj_UserId = Session["UserID"].ToString();

        obj_MobileNo = "0";
        obj_Message = "Your Logistics Plan Ad is sucessfully posted on SCMBizConnect Your. Plan ID:" + obj_PlanId;
        obj_UID = ConfigurationManager.AppSettings.Get("Way2SMSUID").ToString();
        obj_Password = ConfigurationManager.AppSettings.Get("Way2SMSPassword").ToString();
        try
        {
            arr.Clear();
            arr = obj_BizConnectLogisticsPlanClass.get_MobileByUserID(obj_UserId);
            if (arr[1].ToString() != "1")
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = "Sending SMS Failed,because Mobile No does not exist in the table...!";
                obj_resp = 0;
            }
            else
            {
                obj_MobileNo = arr[0].ToString();
                //Declaration Section for Exponant SMS Control
                ExponantAARMSMS.SendSMS sms = new ExponantAARMSMS.SendSMS();
                String Message = Regex.Replace(obj_Message, "#", "");
                sms.ExponantSendSMS(obj_UID, obj_Password, obj_MobileNo, Message, "N");
                obj_resp = 1;
            }
        }
        catch (Exception err)
        {
            obj_resp = 3;
        }
        return obj_resp;
    }

    //Sending Email after successfully Posting Ad 
    public Int32 SendEmail(String obj_LogisticsPlanNumber, String obj_From, String obj_To, String obj_NoOfTrucks, String obj_TravelDate,String obj_Cost)
    {
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_EmailID;
        ArrayList arr = new ArrayList();
        //Email Settings from Web Config
        string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid").ToString();
        string objFromEmail = ConfigurationManager.AppSettings.Get("from_emailid").ToString();
        string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
        string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
        string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
        string objPassword = ConfigurationManager.AppSettings.Get("pass_adalert").ToString();

        
        string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
        string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
        string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
        string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
        Boolean SMTPUseSSL;
        string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
        //

        obj_EmailID = "Nil";
        String obj_FullName = Session["Name"].ToString() ;
        String obj_ClientID = Session["ClientID"].ToString();
        String obj_ClientName = Session["ClientName"].ToString();
        obj_EmailID = Session["EmailID"].ToString();
            //obj_Message = "Thank you for posting your Ad [" + obj_AdId + "] in scmjunction.com";
            
            DateTime obj_PostedDate = new DateTime();
            obj_PostedDate = DateTime.Now.Date;
            String dt;
            dt = obj_PostedDate.ToString("dd-MMM-yyyy");
            String obj_AdType;
            obj_AdType = "Vehicle Wanted";
            String Body = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td bgcolor=#585858 align=center colspan=1 ><font size=2 color=yellow><strong>Client ID -" + obj_ClientID + "<strong></font></td><td bgcolor=#585858 align=center colspan=4><font color=White><strong>Name - " + obj_ClientName + "</strong></font</td><td bgcolor=#585858 align=center colspan=2><font size=2 color=yellow><strong>User -" + obj_EmailID + "</strong></font></td></tr><tr><td align=center><font size=2 color=#003366><strong>Posted Date:&nbsp;</font><font size=2 color=Maroon>" + dt + "</strong></font></td><td align=center colspan=4><font size=3 color=#003366><strong><a href=http://www.scmbizconnect.com title=www.scmbizconnect.com target=_Blank>www.scmbizconnect.com<a></strong></font></td><td align=center><strong><font size=2 color=#003366>Ad Type:&nbsp;</font><font size=2 color=Maroon>" + obj_AdType + "</td></strong></font></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>Logistics Plan ID </strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>From Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>No of Trucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Expected Cost</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Travel Date</strong></font></td></tr><tr><td align=center><a href=http://www.scmjunction.com/ViewLogisticsPlan.aspx?LogisticPlanID=" + obj_LogisticsPlanNumber + " title=Click for View this Ad target=_Blank ><strong>" + obj_LogisticsPlanNumber  + "</strong></a></td><td align=center><font size=2>" + obj_From + "</font></td><td align=center><font size=2>" + obj_To + "</font></td><td align=center><font size=2>2</font></td><td align=center><font size=2>" + obj_Cost + "</font></td><td align=center><font size=2>" + obj_TravelDate + "</font></td></tr><tr bgcolor=#585858><td align=center>&nbsp;</td><td align=center colspan=4><Font size=2 color=White><strong><font size=2>Total no of  Posted Logistics Plan : 01</font></strong></font></td><td align=center>&nbsp;</td></tr></table>";
            obj_Message = "Dear " + obj_FullName + ",<br/>Thank you for posting your Ad with <a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a><br/><br/>The details of the Posted Ad are listed below:<br/><br/>" + Body + "<br/><br/>Thank You,<br/>Web Master,<br> SCM BizConnect<br/><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a>";
            try
            {
                   //Declaration Section for AARMEmail Control
                    AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                    em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Your Ad is successfully posted in www.scmbizconnect.com", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), false, obj_AttachmentPath.ToString().Trim());
                    obj_resp = 1;
            }
            catch (Exception err)
            {
                obj_resp = 3;
            }
        return obj_resp; 
    }



    protected void drpName2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonSale.Checked == true)
        {
            ArrayList arr = new ArrayList();
            arr = obj_BizConnectLogisticsPlanClass.Get_BizConnect_CustomerCodeByCustomerName(drpName2.SelectedItem.Text.Trim());
            if (arr[2].ToString() == "0")
            {
                lblMessage.Text = "Customer code is not Exist...!";
            }
            else
            {
                lblCode2.Text = arr[0].ToString();
                Session["CustomerID"] = arr[1].ToString();
            }
        }
        
    }
    protected void drpName1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonTransfer.Checked == true)
        {
            ArrayList arr = new ArrayList();
            arr = obj_BizConnectLogisticsPlanClass.Get_BizConnect_CustomerCodeByCustomerName(drpName1.SelectedItem.Text.Trim());
            if (arr[2].ToString() == "0")
            {
                lblMessage.Text = "Customer code is not Exist...!";
            }
            else
            {
                lblCode1.Text = arr[0].ToString();
                Session["CustomerID"] = arr[1].ToString();
            }
        }
    }
}





