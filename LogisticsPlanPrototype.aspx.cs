using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogisticsPlanPrototype : System.Web.UI.Page
{


    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;



  //  PlaceHolder maPlaceHolder = new PlaceHolder();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Bind();
            ChkAuthentication();
        }
    }
   
    public void Bind()
    {
        lblLogisticsPlaneNo.Text = "BLR-MUM-01-2011";
        txtOtherProductCategory.Visible = false;
       

        txtOtherProductName.Visible = false;
        

        Panel1.Enabled = false;
        Panel2.Enabled = false;
        PanelProductAndPackingMethodDetails.Enabled = false;
        PanelTruckDetails.Enabled = false;
        PanelAdditionalInformation.Enabled = false;
        Panel3.Enabled = false;

        drpName1.Items.Insert(0, new ListItem("--- List ---", "0"));
        drpName2.Items.Insert(0, new ListItem("--- List ---", "0"));
        drpLocationType1.Items.Insert(0, new ListItem("--- Location Type ---", "0"));
        drpLocationType2.Items.Insert(0, new ListItem("--- Location Type ---", "0"));
        drpLocationCity1.Items.Insert(0, new ListItem("--- City List ---", "0"));
        drpLocationCity2.Items.Insert(0, new ListItem("--- City List ---", "0"));
        drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        drpTravelType.Items.Insert(0, new ListItem("--- Travel Type ---", "0"));
        drpProductType.Items.Insert(0, new ListItem("--- Product Type ---", "0"));
        drpProductCategory.Items.Insert(0, new ListItem("--- Category ---", "0"));
        drpProductName.Items.Insert(0, new ListItem("--- Product Name ---", "0"));
        drpTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
        drpEnclosureType.Items.Insert(0, new ListItem("--- Enclosure Type ---", "0"));
        drpTruckBrand.Items.Insert(0, new ListItem("--- Truck Brand ---", "0"));
        drpTruckModel.Items.Insert(0, new ListItem("--- Truck model ---", "0"));

        DisableLocationOther1();
        DisableLocationOther2();
        FillTruckType();
        FillEnclosureType();
        FillTruckBrand();
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

    public void FillTruckType()
    {
        drpTruckType.Items.Clear();
        drpTruckType.Items.Add("Rigid Truck");
        drpTruckType.Items.Add("Heulage Truck");
        drpTruckType.Items.Add("Container Truck");
        drpTruckType.Items.Add("Tractor Truck");
        drpTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
    }

    public void FillEnclosureType()
    {
        drpEnclosureType.Items.Clear();
        drpEnclosureType.Items.Add("Open");
        drpEnclosureType.Items.Add("Close");
        drpEnclosureType.Items.Insert(0, new ListItem("--- Enclosure Type ---", "0"));
    }

    public void FillTruckBrand()
    {
        drpTruckBrand.Items.Clear();
        drpTruckBrand.Items.Add("Volvo");
        drpTruckBrand.Items.Add("Man");
        drpTruckBrand.Items.Add("Tata");
        drpTruckBrand.Items.Add("Leyland");
        drpTruckBrand.Items.Add("Force");
        drpTruckBrand.Items.Add("Mazda");
        drpTruckBrand.Items.Insert(0, new ListItem("--- Truck Brand ---", "0"));
    }
    public void DisableLocationOther1()
    {
        drpLocationType1.Visible = true;
        drpLocationType1.DataBind();
        drpLocationAddress1.Visible = true;
        drpLocationAddress1.DataBind();
        drpLocationCity1.Visible = true;
        drpLocationCity1.DataBind();

        txtLocationType1.Visible = false;
        txtLocationCity1.Visible = false;
        txtLocationAddress1.Visible = false;
        txtLocationType1.Text = "";
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

        txtLocationType2.Visible = false;
        txtLocationCity2.Visible = false;
        txtLocationAddress2.Visible = false;
        txtLocationType2.Text = "";
        txtLocationAddress2.Text = "";
        txtLocationCity2.Text = "";
        txtLocationCountry2.Text = "";
        txtBoardNo2.Text = "";
        txtCorporateEmail2.Text = "";
        txtLocationState2.Text = "";
    }

    protected void RadioButtonSale_CheckedChanged(object sender, EventArgs e)
    {
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
            RadioButtonTransfer.Checked = false;
            RadioButtonTransfer.DataBind();
            
            lblCode1.Text = "SNTGBN001";
            drpName1.Items.Clear();
            drpName1.Items.Add("Saint Goban");
            drpName1.SelectedItem.Text = "Saint Goban";
            lblCode2.Text = "";

            drpName2.Visible = true;
            drpName2.Items.Clear();
            drpName2.Items.Add("Sony");
            drpName2.Items.Add("LG");
            drpName2.Items.Add("Whirlpool");
            drpName2.Items.Add("Kenstar");
            drpName2.Items.Add("Haier");
            drpName2.DataBind();

        }
        drpLocationAddress1.Items.Clear();
        drpLocationAddress2.Items.Clear();
        drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        
        txtLocationState2.Text = "";
        txtLocationCountry2.Text = "";
        txtBoardNo2.Text = "";
        txtCorporateEmail2.Text = "";

        txtLocationState1.Text = "";
        txtLocationCountry1.Text = "";
        txtBoardNo1.Text = "";
        txtCorporateEmail1.Text = "";
        
    }

    protected void RadioButtonTransfer_CheckedChanged(object sender, EventArgs e)
    {
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

        if (RadioButtonTransfer.Checked == true)
        {
            RadioButtonSale.Checked = false;
            RadioButtonSale.DataBind();

            lblCode2.Text = "SNTGBN001";
            drpName2.Items.Clear();
            drpName2.Items.Add("Saint Goban");
            drpName2.SelectedItem.Text  = "Saint Goban";
            lblCode1.Text = "";

            drpName1.Visible = true;
            drpName1.Items.Clear();
            drpName1.Items.Add("Sony");
            drpName1.Items.Add("LG");
            drpName1.Items.Add("Whirlpool");
            drpName1.Items.Add("Kenstar");
            drpName1.Items.Add("Haier");
            drpName1.DataBind();

        }
        drpLocationAddress1.Items.Clear();
        drpLocationAddress2.Items.Clear();
        drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
        drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));

        txtLocationState2.Text = "";
        txtLocationCountry2.Text = "";
        txtBoardNo2.Text = "";
        txtCorporateEmail2.Text = "";

        txtLocationState1.Text = "";
        txtLocationCountry1.Text = "";
        txtBoardNo1.Text = "";
        txtCorporateEmail1.Text = "";
    }
 
    protected void drpLocationCity1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (RadioButtonSale.Checked == true)
        {
            if (drpLocationCity1.SelectedItem.Text == "Bangalore")
            {
                txtLocationCity1.Visible = false;
                txtLocationAddress1.Visible = false;
                drpLocationAddress1.Items.Clear();
                drpLocationAddress1.Items.Add("123/C,Padmanabha Nagar,B'lore");
                drpLocationAddress1.Items.Add("13/C,Malleswaram,B'lore");
                drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                drpLocationAddress1.Focus();
            }
             else if (drpLocationCity1.SelectedItem.Text == "New Delhi")
            {
                txtLocationCity1.Visible = false;
                txtLocationAddress1.Visible = false;
                drpLocationAddress1.Items.Clear();
                drpLocationAddress1.Items.Add("123/C,Mayoor Vihar,New Delhi");
                drpLocationAddress1.Items.Add("13/C,Chandni Chouk,New Delhi");
                drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                drpLocationAddress1.Focus();
            }
            else if (drpLocationCity1.SelectedItem.Text == "Other")
            {
                drpLocationAddress1.Items.Clear();
                drpLocationAddress1.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                txtLocationCity1.Visible = true;
                txtLocationAddress1.Visible = true;
                txtLocationCity1.Focus();
            }
        }
        
    }
    protected void drpLocationCity2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (RadioButtonTransfer.Checked == true)
        {
            if (drpLocationCity2.SelectedItem.Text == "Bangalore")
            {
                txtLocationCity2.Visible = false;
                txtLocationAddress2.Visible = false;
                drpLocationAddress2.Items.Clear();
                drpLocationAddress2.Items.Add("123/C,Padmanabha Nagar,B'lore");
                drpLocationAddress2.Items.Add("13/C,Malleswaram,B'lore");
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                drpLocationAddress2.Focus();
            }
            else if (drpLocationCity2.SelectedItem.Text == "New Delhi")
            {
                txtLocationCity2.Visible = false;
                txtLocationAddress2.Visible = false;
                drpLocationAddress2.Items.Clear();
                drpLocationAddress2.Items.Add("123/C,Mayoor Vihar,New Delhi");
                drpLocationAddress2.Items.Add("13/C,Chandni Chouk,New Delhi");
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                drpLocationAddress2.Focus();
            }
            else if (drpLocationCity2.SelectedItem.Text == "Other")
            {
                drpLocationAddress2.Items.Clear();
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                txtLocationCity2.Visible = true;
                txtLocationAddress2.Visible = true;
                txtLocationCity2.Focus();
            }
        }
        if (RadioButtonTransfer.Checked == false )
        {
            if (drpLocationCity2.SelectedItem.Text == "Bangalore")
            {
                txtLocationCity2.Visible = false;
                txtLocationAddress2.Visible = false;
                drpLocationAddress2.Items.Clear();
                drpLocationAddress2.Items.Add("123/C,Indira Nagar,B'lore");
                drpLocationAddress2.Items.Add("13/C,Madiwala,B'lore");
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                drpLocationAddress2.Focus();
            }
            else if (drpLocationCity2.SelectedItem.Text == "Other")
            {
                drpLocationAddress2.Items.Clear();
                drpLocationAddress2.Items.Insert(0, new ListItem("--- Address List ---", "0"));
                txtLocationCity2.Visible = true;
                txtLocationAddress2.Visible = true;
                txtLocationCity2.Focus();
            }
        }
        
    }
    protected void drpLocationAddress1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpLocationAddress1.SelectedItem.Text == "123/C,Padmanabha Nagar,B'lore")
        {
            txtLocationState1.Text="Karnataka";
            txtLocationCountry1.Text = "India";
            txtBoardNo1.Text = "123456";
            txtCorporateEmail1.Text = "snt@saintgoban.com";
        }
        else if (drpLocationAddress1.SelectedItem.Text == "13/C,Malleswaram,B'lore")
        {
            txtLocationState1.Text = "Karnataka";
            txtLocationCountry1.Text = "India";
            txtBoardNo1.Text = "123456";
            txtCorporateEmail1.Text = "snt@saintgoban.com";
        }
        txtLastDateForReceivingQuotes.Focus();
    }
    protected void drpLocationAddress2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpLocationAddress2.SelectedItem.Text == "123/C,Indira Nagar,B'lore")
        {
            txtLocationState2.Text = "Karnataka";
            txtLocationCountry2.Text = "India";
            txtBoardNo2.Text = "5675456";
            txtCorporateEmail2.Text = "sony@soney.com";
        }
        else if (drpLocationAddress2.SelectedItem.Text == "13/C,Madiwala,B'lore")
        {
            txtLocationState2.Text = "Karnataka";
            txtLocationCountry2.Text = "India";
            txtBoardNo2.Text = "154656";
            txtCorporateEmail2.Text = "sony@sony.com";
        }
        txtLastDateForReceivingQuotes.Focus();
    }
    protected void drpLocationType1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpLocationType1.SelectedItem.Text == "Other")
        {
            //drpLocationType1.Visible = false;
            drpLocationCity1.Visible = false;
            drpLocationAddress1.Visible = false;

            txtLocationType1.Visible = true;
            txtLocationCity1.Visible = true;
            txtLocationAddress1.Visible = true;
            txtLocationState1.Text = "";
            txtLocationCountry1.Text = "";
            txtBoardNo1.Text = "";
            txtCorporateEmail1.Text = "";
            txtLocationType1.Focus();
        }
        else
        {
            //drpLocationType1.Visible = true;
            drpLocationCity1.Visible = true;
            drpLocationAddress1.Visible = true;

            txtLocationType1.Visible = false;
            txtLocationCity1.Visible = false;
            txtLocationAddress1.Visible = false;
            drpLocationCity1.Focus();
        }
    }
    protected void drpLocationType2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (drpLocationType2.SelectedItem.Text == "Other")
        {
            //drpLocationType2.Visible = false;
            drpLocationCity2.Visible = false;
            drpLocationAddress2.Visible = false;

            txtLocationType2.Visible = true;
            txtLocationCity2.Visible = true;
            txtLocationAddress2.Visible = true;
            txtLocationType2.Focus();
        }
        else
        {
            //drpLocationType2.Visible = true;
            drpLocationCity2.Visible = true;
            drpLocationAddress2.Visible = true;

            txtLocationType2.Visible = false;
            txtLocationCity2.Visible = false;
            txtLocationAddress2.Visible = false;
            txtLocationState2.Text = "";
            txtLocationCountry2.Text = "";
            txtBoardNo2.Text = "";
            txtCorporateEmail2.Text = "";
            drpLocationCity2.Focus();
        }
    }
    protected void drpProductType_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpProductType.SelectedItem.Text=="Solid")
        {
            drpProductCategory.Items.Clear();
            drpProductCategory.Items.Add("TV");
            drpProductCategory.Items.Add("Computers");
            drpProductCategory.Items.Add("Laptops");
            drpProductCategory.Items.Add("Washing Meachine");
            drpProductCategory.Items.Add("Other");
            drpProductCategory.Items.Insert(0, new ListItem("--- Category List ---", "0"));
        }
        else if (drpProductType.SelectedItem.Text == "Liquid")
        {
            drpProductCategory.Items.Clear();
            drpProductCategory.Items.Add("Gas");
            drpProductCategory.Items.Add("Petrol");
            drpProductCategory.Items.Add("Diesel");
            drpProductCategory.Items.Add("Chemicals");
            drpProductCategory.Items.Add("Other");
            drpProductCategory.Items.Insert(0, new ListItem("--- Category List ---", "0"));
        }
        drpProductCategory.Focus();
    }
    protected void drpProductCategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        FillTruckType();
        FillEnclosureType();
        FillTruckBrand();
        drpTruckModel.Items.Clear();
        txtTruckCapacity.Text = "";
        txtQuantityPerTruck.Text = "";
        txtTruckRequired.Text = "";
        txtCostPerTruck.Text = "";

        if (drpProductCategory.SelectedItem.Text == "Other")
        {
            txtOtherProductCategory.Visible = true;
            drpProductName.Items.Clear();
            drpProductName.Items.Add("Other");
            drpProductName.SelectedItem.Text = "Other";
            txtOtherProductName.Visible = true;
            PanelProductAndPackingMethodDetails.Height = 220;
            txtOtherProductCategory.Focus();
        }
        else
        {
            txtOtherProductCategory.Visible = false;
            txtOtherProductName.Visible = false;
            PanelProductAndPackingMethodDetails.Height = 175;
            drpProductName.Focus();
        }

        if (drpProductCategory.SelectedItem.Text == "TV")
        {
            drpProductName.Items.Clear();
            drpProductName.Items.Add("Sony Bravio");
            drpProductName.Items.Add("Hitachi001");
            drpProductName.Items.Add("ThoshibaTS01");
            drpProductName.Items.Add("LG002");
            drpProductName.Items.Add("Other");
            drpProductName.Items.Insert(0, new ListItem("--- Product List ---", "0"));
           
        }
        else if (drpProductCategory.SelectedItem.Text == "Laptops")
        {
            drpProductName.Items.Clear();
            drpProductName.Items.Add("Dell Studio");
            drpProductName.Items.Add("Sony PC001");
            drpProductName.Items.Add("HP001");
            drpProductName.Items.Add("Apple Imac");
            drpProductName.Items.Add("Other");
            drpProductName.Items.Insert(0, new ListItem("--- Product List ---", "0"));
        }
        else if (drpProductCategory.SelectedItem.Text == "Computers")
        {
            drpProductName.Items.Clear();
            drpProductName.Items.Add("DellPC001");
            drpProductName.Items.Add("Sony PC001");
            drpProductName.Items.Add("HP001");
            drpProductName.Items.Add("Apple Imac");
            drpProductName.Items.Add("Other");
            drpProductName.Items.Insert(0, new ListItem("--- Product List ---", "0"));
        }
        else if (drpProductCategory.SelectedItem.Text == "Washing Meachine")
        {
            drpProductName.Items.Clear();
            drpProductName.Items.Add("LG WM001");
            drpProductName.Items.Add("Sony WM001");
            drpProductName.Items.Add("Kenstar WM001");
            drpProductName.Items.Add("Whirlpool WM001");
            drpProductName.Items.Add("Other");
            drpProductName.Items.Insert(0, new ListItem("--- Product List ---", "0"));
        }
        else if (drpProductCategory.SelectedItem.Text == "Gas" | drpProductCategory.SelectedItem.Text == "Petrol" | drpProductCategory.SelectedItem.Text == "Diesel")
        {
            drpProductName.Items.Clear();
            drpProductName.Items.Add("HP");
            drpProductName.Items.Add("Indian Oil");
            drpProductName.Items.Add("BP");
            drpProductName.Items.Add("Shell");
            drpProductName.Items.Add("Other");
            drpProductName.Items.Insert(0, new ListItem("--- Product List ---", "0"));
        }
        else if (drpProductCategory.SelectedItem.Text == "Chemicals")
        {
            drpProductName.Items.Clear();
            drpProductName.Items.Add("Liquid Nitrogen");
            drpProductName.Items.Add("Liquid Pesticides");
            drpProductName.Items.Add("Liquid Medicine");
            drpProductName.Items.Add("Trichloro-Ethylene");
            drpProductName.Items.Add("Benzene");
            drpProductName.Items.Add("Other");
            drpProductName.Items.Insert(0, new ListItem("--- Product List ---", "0"));
        }
        
    }  
          

    protected void drpProductName_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpProductName.SelectedItem.Text == "Other")
        {
            txtOtherProductName.Visible = true;
            PanelProductAndPackingMethodDetails.Height = 210;
            txtOtherProductName.Focus();
        }
        else
        {
            txtOtherProductName.Visible = false;
            PanelProductAndPackingMethodDetails.Height = 175;
            drpPackingMethod1.Focus();
        }

        if (drpProductType.SelectedItem.Text == "Solid")
        {
            drpPackingMethod1.Items.Clear();
            drpPackingMethod1.Items.Add("Primary");
            drpPackingMethod1.Items.Add("Secondary");
            drpPackingMethod1.Items.Insert(0, new ListItem("--- Type ---", "0"));
        }
        else if (drpProductType.SelectedItem.Text == "Liquid")
        {
            drpPackingMethod1.Items.Clear();
            drpPackingMethod1.Items.Add("Primary");
            drpPackingMethod1.Items.Add("Secondary");
            drpPackingMethod1.Items.Insert(0, new ListItem("--- Type ---", "0"));
        }
       
    }
    protected void drpPackingMethod1_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (drpProductType.SelectedItem.Text == "Solid")
        {
            if (drpPackingMethod1.SelectedItem.Text == "Primary" | drpPackingMethod1.SelectedItem.Text == "Secondary")
            {
                drpPackingMethod2.Items.Clear();
                drpPackingMethod2.Items.Add("Carton");
                drpPackingMethod2.Items.Add("Food Container");
                drpPackingMethod2.Items.Add("Freezer Container");
                drpPackingMethod2.Items.Insert(0, new ListItem("-- Methods --", "0"));
            }
        }
        else if (drpProductType.SelectedItem.Text == "Liquid")
        {
            if (drpPackingMethod1.SelectedItem.Text == "Primary" | drpPackingMethod1.SelectedItem.Text == "Secondary")
            {
                drpPackingMethod2.Items.Clear();
                drpPackingMethod2.Items.Add("Barrel");
                drpPackingMethod2.Items.Add("Jerry Cans");
                drpPackingMethod2.Items.Add("Liquid Container");
                drpPackingMethod2.Items.Insert(0, new ListItem("-- Methods --", "0"));
               
            }
        }
        drpPackingMethod2.Focus();
    }
    protected void drpPackingMethod2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(1000);
        if (drpPackingMethod2.SelectedItem.Text == "Liquid Container")
        {
            DisableWeightLengthWidthHeight();
            txtProductVolume.Focus();
        }
        else
        {
            EnableWeightLengthWidthHeight();
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
        txtQuantityPerTruck.Text = "";
        lblQuantityPerTruckUnitTitle.Enabled = false;
        drpQuantityPerTruck.Enabled = false;

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
        txtQuantityPerTruck.Text = "";
        lblQuantityPerTruckUnitTitle.Enabled = true;
        drpQuantityPerTruck.Enabled = true;

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
        if (drpTruckBrand.SelectedItem.Text == "Volvo")
        {
            drpTruckModel.Items.Clear();
            drpTruckModel.Items.Add("V001");
            drpTruckModel.Items.Add("V002");
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("--- Truck Models ---", "0"));
        }
        else if (drpTruckBrand.SelectedItem.Text == "Man")
        {
            drpTruckModel.Items.Clear();
            drpTruckModel.Items.Add("M001");
            drpTruckModel.Items.Add("M002");
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("--- Truck Models ---", "0"));
        }
        else if (drpTruckBrand.SelectedItem.Text == "Tata")
        {
            drpTruckModel.Items.Clear();
            drpTruckModel.Items.Add("T001");
            drpTruckModel.Items.Add("T002");
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("--- Truck Models ---", "0"));
        }
        else if (drpTruckBrand.SelectedItem.Text == "Leyland")
        {
            drpTruckModel.Items.Clear();
            drpTruckModel.Items.Add("L001");
            drpTruckModel.Items.Add("L002");
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("--- Truck Models ---", "0"));
        }
        else if (drpTruckBrand.SelectedItem.Text == "Mazda")
        {
            drpTruckModel.Items.Clear();
            drpTruckModel.Items.Add("MAZ001");
            drpTruckModel.Items.Add("MAZ002");
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("--- Truck Models ---", "0"));
        }
        else if (drpTruckBrand.SelectedItem.Text == "Force")
        {
            drpTruckModel.Items.Clear();
            drpTruckModel.Items.Add("FC001");
            drpTruckModel.Items.Add("FC002");
            drpTruckModel.DataBind();
            drpTruckModel.Items.Insert(0, new ListItem("--- Truck Models ---", "0"));
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
        if (drpProductType.SelectedItem.Text == "Liquid")
        {
            drpTruckCapacityUnit.Items.Clear();
            drpTruckCapacityUnit.Items.Add("Litters");
            drpTruckCapacityUnit.Items.Add("Kilo Litters");
        }
        else
        {
            drpTruckCapacityUnit.Items.Clear();
            drpTruckCapacityUnit.Items.Add("Kgs");
            drpTruckCapacityUnit.Items.Add("Tonnes");
        }
    }
    protected void drpTruckCapacityUnit_TextChanged(object sender, EventArgs e)
    {
        txtCostPerTruck.Focus();
    }
    protected void drpTravelType_SelectedIndexChanged(object sender, EventArgs e)
    {
        drpProductType.Focus();
    }

    protected void RadioButtonEvaluate_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonEvaluate.Checked == true)
        {
            RadioButtonManual.Checked = false;
            RadioButtonManual.DataBind();
            txtTruckCapacity.Text = "";
            txtQuantityPerTruck.Text = "";
            txtTruckRequired.Text = "";
            txtCostPerTruck.Text = "";
        }
    }
    protected void RadioButtonManual_CheckedChanged(object sender, EventArgs e)
    {
        if (RadioButtonManual.Checked == true)
        {
            RadioButtonEvaluate.Checked = false;
            RadioButtonEvaluate.DataBind();
            txtTruckCapacity.Text = "";
            txtQuantityPerTruck.Text = "";
            txtTruckRequired.Text = "";
            txtCostPerTruck.Text = "";
        }
    }
}