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

public partial class ProductCreation : System.Web.UI.Page
{
    string obj_Authenticated, obj_emailid;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();
    BizConnectClass bizconnect = new BizConnectClass();

    protected void Page_Load(object sender, EventArgs e)
    {
        obj_emailid = Session["EmailID"].ToString();
        if (IsPostBack == false)
        {

            ChkAuthentication();
            FillProductType();
           
            FillPackingMethods();
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
    //Fill Product Types

    public void FillProductType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillProductType();
        if (ds.Tables["ProductType"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            DDLproducttype.DataSource = ds.Tables["ProductType"];
            DDLproducttype.DataTextField = "ProductType";
            DDLproducttype.DataValueField = "ProductTypeID";
            DDLproducttype.DataBind();
            DDLproducttype.Items.Insert(0, new ListItem("--- Product Type ---", "0"));
        }
        else
        {
            lblmsg.Text = "";
            lblmsg.Text = "Empty Table";
        }
    }
    //Fill Products depending on the Selected Product Type
    public void FillProductCategory()
    {
       
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillProductCategory(Convert.ToInt32(DDLproducttype.SelectedItem.Value));
        if (ds.Tables["ProductCategory"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            DDLproductcategory.DataSource = ds.Tables["ProductCategory"];
            DDLproductcategory.DataTextField = "CategoryName";
            DDLproductcategory.DataValueField = "ProductCategoryID";
            DDLproductcategory.DataBind();
            DDLproductcategory.Items.Insert(0, new ListItem("--- Product Category ---", "0"));
        }
        else
        {
            lblmsg.Text = "";
            lblmsg.Text = "Empty Table";
        }
        //drpProductCategory.Items.Add("Other");
        DDLproductcategory.Focus();
    }
    protected void DDLproducttype_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        FillProductCategory();

    }
    protected void DDLproductcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        FillPackingMethods();
        DataSet ds = new DataSet();
          //Fill Truck Capacity Unit
        if (Convert.ToInt32(DDLproductcategory.SelectedItem.Value) == 1) // For Solid Goods
        {
            ds.Clear();
            ds = obj_BizConnectLogisticsPlanClass.FillUnit(2);
            if (ds.Tables["Unit"].Rows.Count > 0)
            {
                
                //Fill Units for Quantity Per Truck - Solid type of Goods
                DDLQuantityUnit.Items.Clear();
                DDLQuantityUnit.DataSource = ds.Tables["Unit"];
                DDLQuantityUnit.DataTextField = "Unit";
                DDLQuantityUnit.DataValueField = "UnitID";
                DDLQuantityUnit.DataBind();
                DDLQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));



                //Fill Units for Weight Per Truck - Solid type of Goods
                DDLWeightUnit.Items.Clear();
                DDLWeightUnit.DataSource = ds.Tables["Unit"];
                DDLWeightUnit.DataTextField = "Unit";
                DDLWeightUnit.DataValueField = "UnitID";
                DDLWeightUnit.DataBind();
                DDLWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Quantity Unit - Solid type of Goods
                ds.Clear();
                ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
                DDLQuantityUnit.Items.Clear();
                DDLQuantityUnit.DataSource = ds.Tables["Unit"];
                DDLQuantityUnit.DataTextField = "Unit";
                DDLQuantityUnit.DataValueField = "UnitID";
                DDLQuantityUnit.DataBind();
                DDLQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));
            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Empty Table";
            }
        }
        else if (Convert.ToInt32(DDLproductcategory.SelectedItem.Value) == 2) // For Liquid Goods
        {
            ds.Clear();
            ds = obj_BizConnectLogisticsPlanClass.FillUnit(3);
            if (ds.Tables["Unit"].Rows.Count > 0)
            {
                //Fill Units for Quantity Per Truck - Liquid type of Goods
                ds.Clear();
                ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
                DDLQuantityUnit.Items.Clear();
                DDLQuantityUnit.DataSource = ds.Tables["Unit"];
                DDLQuantityUnit.DataTextField = "Unit";
                DDLQuantityUnit.DataValueField = "UnitID";
                DDLQuantityUnit.DataBind();
                DDLQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Weight Per Truck - Liquid type of Goods
                DDLWeightUnit.Items.Clear();
                DDLWeightUnit.DataSource = ds.Tables["Unit"];
                DDLWeightUnit.DataTextField = "Unit";
                DDLWeightUnit.DataValueField = "UnitID";
                DDLWeightUnit.DataBind();
                DDLWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));
            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Empty Table";
            }
        }
    

    }
    public void FillPackingMethods()
    {
        //Filling Packing Method Type
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillPackingMethods(Convert.ToInt32(DDLproducttype.SelectedItem.Value));
        if (ds.Tables["PackingMethods"].Rows.Count > 0)
        {
            //For Location Type1 DropdownlistBox
            DDLpackingType.Items.Clear();
            DDLpackingType.DataSource = ds.Tables["PackingMethods"];
            DDLpackingType.DataTextField = "PackingMethod";
            DDLpackingType.DataValueField = "PackingMethodID";
            DDLpackingType.DataBind();
            DDLpackingType.Items.Insert(0, new ListItem("-- Methods --", "0"));
        }
        else
        {
            lblmsg.Text = "";
            lblmsg.Text = "Empty Table";
        }
        DDLpackingType.Focus();
        //Fill Units for All Dropdown Combo Box
        ds.Clear();
        ds = obj_BizConnectLogisticsPlanClass.FillUnit(1);
        if (ds.Tables["Unit"].Rows.Count > 0)
        {
            //For Units for Width
            DDLwidthunit.Items.Clear();
            DDLwidthunit.DataSource = ds.Tables["Unit"];
            DDLwidthunit.DataTextField = "Unit";
            DDLwidthunit.DataValueField = "UnitID";
            DDLwidthunit.DataBind();
            DDLwidthunit.Items.Insert(0, new ListItem("- Units -", "0"));

            //For Units for Length
            DDLLengthUnit.Items.Clear();
            DDLLengthUnit.DataSource = ds.Tables["Unit"];
            DDLLengthUnit.DataTextField = "Unit";
            DDLLengthUnit.DataValueField = "UnitID";
            DDLLengthUnit.DataBind();
            DDLLengthUnit.Items.Insert(0, new ListItem("- Units -", "0"));

            //For Units for Height
            DDLHeightUnit.Items.Clear();
            DDLHeightUnit.DataSource = ds.Tables["Unit"];
            DDLHeightUnit.DataTextField = "Unit";
            DDLHeightUnit.DataValueField = "UnitID";
            DDLHeightUnit.DataBind();
            DDLHeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));

            //For Units for weight
            DDLWeightUnit.Items.Clear();
            DDLWeightUnit.DataSource = ds.Tables["Unit"];
            DDLWeightUnit.DataTextField = "Unit";
            DDLWeightUnit.DataValueField = "UnitID";
            DDLWeightUnit.DataBind();
            DDLWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));

            //For Units for Quantity
            DDLQuantityUnit.Items.Clear();
            DDLQuantityUnit.DataSource = ds.Tables["Unit"];
            DDLQuantityUnit.DataTextField = "Unit";
            DDLQuantityUnit.DataValueField = "UnitID";
            DDLQuantityUnit.DataBind();
            DDLQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));
        }
        else
        {
            lblmsg.Text = "";
            lblmsg.Text = "Empty Table";
        }

        //Fill Units for Volume
        ds.Clear();
        ds = obj_BizConnectLogisticsPlanClass.FillUnit(3);
        if (ds.Tables["Unit"].Rows.Count > 0)
        {
            //For Units for Volume
            DDlvolumeunit.Items.Clear();
            DDlvolumeunit.DataSource = ds.Tables["Unit"];
            DDlvolumeunit.DataTextField = "Unit";
            DDlvolumeunit.DataValueField = "UnitID";
            DDlvolumeunit.DataBind();
            DDlvolumeunit.Items.Insert(0, new ListItem("- Units -", "0"));
        }
        else
        {
            lblmsg.Text = "";
            lblmsg.Text = "Empty Table";
        }
        if (Convert.ToInt32(DDLproducttype.SelectedItem.Value) == 1) // For Solid Goods
        {
            ds.Clear();
            ds = obj_BizConnectLogisticsPlanClass.FillUnit(2);
            if (ds.Tables["Unit"].Rows.Count > 0)
            {

                //Fill Units for Weight Per Truck - Solid type of Goods
                DDLWeightUnit.Items.Clear();
                DDLWeightUnit.DataSource = ds.Tables["Unit"];
                DDLWeightUnit.DataTextField = "Unit";
                DDLWeightUnit.DataValueField = "UnitID";
                DDLWeightUnit.DataBind();
                DDLWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Quantity Unit - Solid type of Goods
                ds.Clear();
                ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
                DDLQuantityUnit.Items.Clear();
                DDLQuantityUnit.DataSource = ds.Tables["Unit"];
                DDLQuantityUnit.DataTextField = "Unit";
                DDLQuantityUnit.DataValueField = "UnitID";
                DDLQuantityUnit.DataBind();
                DDLQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));
            }
            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Empty Table";
            }
        }
        else if (Convert.ToInt32(DDLproducttype.SelectedItem.Value) == 2) // For Liquid Goods
        {
            ds.Clear();
            ds = obj_BizConnectLogisticsPlanClass.FillUnit(3);
            if (ds.Tables["Unit"].Rows.Count > 0)
            {

                //Fill Units for Weight Per Truck - Liquid type of Goods
                DDLWeightUnit.Items.Clear();
                DDLWeightUnit.DataSource = ds.Tables["Unit"];
                DDLWeightUnit.DataTextField = "Unit";
                DDLWeightUnit.DataValueField = "UnitID";
                DDLWeightUnit.DataBind();
                DDLWeightUnit.Items.Insert(0, new ListItem("- Units -", "0"));

                //Fill Units for Quantity Unit - Liquid type of Goods
                ds.Clear();
                ds = obj_BizConnectLogisticsPlanClass.FillUnit(4);
                DDLQuantityUnit.Items.Clear();
                DDLQuantityUnit.DataSource = ds.Tables["Unit"];
                DDLQuantityUnit.DataTextField = "Unit";
                DDLQuantityUnit.DataValueField = "UnitID";
                DDLQuantityUnit.DataBind();
                DDLQuantityUnit.Items.Insert(0, new ListItem("- Units -", "0"));
            }

            else
            {
                lblmsg.Text = "";
                lblmsg.Text = "Empty Table";
            }
            
        }

    }
      
    protected void DDLpackingType_SelectedIndexChanged(object sender, EventArgs e)
    {
        System.Threading.Thread.Sleep(1000);
        if (DDLpackingType.SelectedItem.Text == "Liquid Container")
        {
            DisableWeightLengthWidthHeight();
            Txt_width.Text = "0";
            txt_length.Text = "0";
            txt_height.Text = "0";
            txt_quantity.Text = "0";
            txt_weight.Text = "0";
            txt_volume.Text = "0";
            txt_volume.Focus();
        }
        else
        {
            EnableWeightLengthWidthHeight();
            Txt_width.Text = "0";
            txt_length.Text = "0";
            txt_height.Text = "0";
            txt_quantity.Text = "0";
            txt_weight.Text = "0";
            txt_volume.Text = "0";
            Txt_width.Focus();
        }
    }
    //Disable Weight Length Width and Height
    public void DisableWeightLengthWidthHeight()
    {

        txt_quantity.Enabled = false;
        txt_quantity.Text = "";
        DDLQuantityUnit.Enabled = false;
        txt_weight.Enabled = false;
        txt_weight.Text = "";
        DDLWeightUnit.Enabled = false;
        txt_length.Enabled = false;
        txt_length.Text = "";
        DDLLengthUnit.Enabled = false;
        Txt_width.Enabled = false;
        Txt_width.Text = "";
        DDLwidthunit.Enabled = false;
        txt_height.Enabled = false;
        txt_height.Text = "";
        DDLHeightUnit.Enabled = false;
        txt_quantity.Enabled = false;
        txt_quantity.Text = "0";
        DDLQuantityUnit.Enabled = false;
        txt_volume.Text = "";
        txt_volume.Enabled = true;
        DDlvolumeunit.Enabled = true;
    }

    //Enable Weight Length Width and Height
    public void EnableWeightLengthWidthHeight()
    {

        txt_quantity.Enabled = true;
        txt_quantity.Text = "";
        DDLQuantityUnit.Enabled = true;
        txt_weight.Enabled = true;
        txt_weight.Text = "";
        DDLWeightUnit.Enabled = true;
        txt_length.Enabled = true;
        txt_length.Text = "";
        DDLLengthUnit.Enabled = true;
        Txt_width.Enabled = true;
        Txt_width.Text = "";
        DDLwidthunit.Enabled = true;
        txt_height.Enabled = true;
        txt_height.Text = "";
        DDLHeightUnit.Enabled = true;

        txt_volume.Enabled = false;
        txt_volume.Text = "";
        DDlvolumeunit.Enabled = false;
    }
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
         int res;
        int clientid = Convert.ToInt32(Session["ClientID"].ToString());
        res=obj_BizConnectLogisticsPlanClass.Insert_Product(clientid,Convert.ToInt32(Txt_sku.Text),Txt_productname.Text,txt_productDescription.Text,Convert.ToInt32(DDLproducttype.SelectedValue),Convert.ToInt32(DDLproductcategory.SelectedValue),Convert.ToInt32(DDLpackingType.SelectedValue),Convert.ToDouble(txt_weight.Text),Convert.ToInt32(DDLWeightUnit.SelectedValue),Convert.ToDouble(txt_length.Text),Convert.ToInt32(DDLLengthUnit.SelectedValue),Convert.ToDouble(Txt_width.Text),Convert.ToInt32(DDLwidthunit.SelectedValue),Convert.ToDouble(txt_height.Text),Convert.ToInt32(DDLHeightUnit.SelectedValue),Convert.ToDouble(txt_volume.Text),Convert.ToInt32(DDlvolumeunit.SelectedValue),Convert.ToDouble(txt_quantity.Text),Convert.ToInt32(DDLQuantityUnit.SelectedValue),Convert.ToInt32(DDLpckngsp.SelectedValue),Convert.ToDouble(txt_transcostperunit.Text),Convert.ToDouble(txt_comm.Text));
        if(res == 1)
        {
            //lblmsg.Visible = true;
            //lblmsg.Text = "Data saved successfully";
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Product Created successfully');</script>");
            ClearFields();
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Data not saved";
        }
    }
    public void ClearFields()
    {
        DDLproducttype.SelectedIndex = -1;
        DDLproductcategory.SelectedIndex = -1;
        Txt_productname.Text = "";
        txt_productDescription.Text = "";
        DDLpackingType.SelectedIndex = -1;
        DDLHeightUnit.SelectedIndex = -1;
        DDLWeightUnit.SelectedIndex = -1;
        DDLLengthUnit.SelectedIndex = -1;
        DDLwidthunit.SelectedIndex = -1;
        DDLQuantityUnit.SelectedIndex = -1;
        DDLpckngsp.SelectedIndex = -1;
        Txt_sku.Text = "";
        txt_transcostperunit.Text = "";
        txt_comm.Text = "";
        txt_height.Text = "";
        txt_length.Text = "";
        txt_weight.Text = "";
        Txt_width.Text = "";
    }
}
