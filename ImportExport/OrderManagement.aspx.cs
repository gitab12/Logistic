using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data ;

public partial class OrderManagement : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
        FileUpload FileCtrl;
        byte[] bytes;
        int result = 0;
        string filename;
    ImportExport obj_Class = new ImportExport();
    DataTable dt_Product = new DataTable();
    DataTable dt_UOM = new DataTable();
    DataTable dt_Country = new DataTable();
   DataTable dt_Code = new DataTable();
   DataTable dt_Buyer = new DataTable();

   DataTable dt_Vendor = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lbl_Msg.Visible = false;
            ChkAuthentication();
            //LoadProductName();
            LoadUOM();
                LoadCountry();
                LoadBuyer();
                LoadVendor();
        }
    }

    //public void LoadProductName()
    //{
    //    dt_Product = obj_Class.Bizconnect_LoadProductName();
    //    ddl_ProductName.DataSource = dt_Product;
    //    ddl_ProductName.DataTextField = "ProductName";
    //    ddl_ProductName.DataBind();
    //    ddl_ProductName.Items.Insert(0, "--Select--");
        
    //}


    public void LoadBuyer()
    {
        dt_Buyer = obj_Class.Bizconnect_LoadBuyer();
        ddl_Buyer.DataSource = dt_Buyer;
        ddl_Buyer.DataTextField = "buyername";
        ddl_Buyer.DataValueField = "buyerid";
        ddl_Buyer.DataBind();
        ddl_Buyer.Items.Insert(0, "--Select--");

    }

    public void LoadVendor()
    {
        dt_Vendor = obj_Class.Bizconnect_LoadVendor();
        ddl_Vendor.DataSource = dt_Vendor;
        ddl_Vendor.DataTextField = "Vendorname";
        ddl_Vendor.DataValueField = "VendorID";
        ddl_Vendor.DataBind();
        ddl_Vendor.Items.Insert(0, "--Select--");

    }

    public void LoadUOM()
    {
        dt_Product = obj_Class.Bizconnect_LoadUOM();
        ddl_Uom.DataSource = dt_Product;
        ddl_Uom.DataTextField = "Unit";
        ddl_Uom.DataValueField = "UnitID";
        ddl_Uom.DataBind();
        ddl_Uom.Items.Insert(0, "--Select--");

    }

    public void LoadCountry()
    {
        dt_Product = obj_Class.Bizconnect_LoadCountry();
        ddl_Country.DataSource = dt_Product;
        ddl_Country.DataTextField = "Country";
        ddl_Country.DataBind();
        ddl_Country.Items.Insert(0, "--Select--");

    }

    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;
        obj_Navi = null;
        obj_Navihome = null;
        obj_Authenticated = Session["Authenticated"].ToString();
        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        ContentPlaceHolder contp;
        contp = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        obj_Navihome = (UserControl)contp.FindControl("navihome1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("right1");
            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");
                obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
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


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        obj_Class.BuyerID = Convert .ToInt32 (ddl_Buyer.SelectedValue.ToString());
        obj_Class.ClientID = 0;
        obj_Class.UserID = 0;
        obj_Class.PoNumber = txt_Pono.Text;
        obj_Class.PoDate = Convert.ToDateTime(txt_Podate.Text);
        obj_Class.Product = txt_Product.Text;
        obj_Class.ProductDesc = txt_ProductDesc.Text;
        obj_Class.VendorID = Convert.ToInt32(ddl_Vendor.SelectedValue.ToString());
        obj_Class.Country = ddl_Country.SelectedValue.ToString();
        obj_Class.UOM = Convert .ToInt32 (ddl_Uom.SelectedValue.ToString());
        obj_Class.ModeofShipment = ddl_Shipmentmode.SelectedItem.Text;
        obj_Class.ModeofPayment = ddl_Paymentmode.SelectedItem.Text;
        obj_Class.CreditTerms = txt_Creditterms.Text;
        obj_Class.BasicValue = Convert.ToSingle(txt_Basicvalue.Text);
        obj_Class.CurrencyConversion = ddl_Currency.SelectedItem.Text;
        obj_Class.Exchangerate = Convert .ToInt32 (txt_Exchangerate.Text);
        obj_Class.Unit = txt_Unit.Text;
        obj_Class.Quantity = Convert .ToInt32 (txt_Quantity.Text);
        obj_Class.Unitrate = Convert.ToSingle(txt_Unitrate.Text);
        obj_Class.Incoterms = ddl_Incoterms.SelectedItem.Text;
        obj_Class.Nominatepickup = txt_Nominatepickup.Text;
        obj_Class .XWKSCostofinlandtransport =Convert.ToSingle(txt_XwksCostofinlandtransport .Text);
        obj_Class .XWKSCutomduty = Convert.ToSingle(txt_XwksCustomduty .Text);
        obj_Class.XWKSInsurance = Convert.ToSingle(txt_XWKSInsurance.Text);
        obj_Class.XWKSOceanfreight =Convert.ToSingle( txt_XwksOceanfreight.Text);
        obj_Class.XWKSLocaltransportcost = Convert.ToSingle(txt_XwksLocalTransportcost.Text);
        obj_Class.XWKSLandedcost =Convert.ToSingle( txt_XwksLandedcost.Text);
        obj_Class .FOBCustomduty =Convert.ToSingle(txt_FOBCustomduty .Text );
        obj_Class.FOBFreight = Convert.ToSingle(txt_FOBFreight.Text);
        obj_Class .FOBInsurance =Convert.ToSingle(txt_FOBInsurance .Text);
        obj_Class.FOBLocaltransport = Convert.ToSingle(txt_FOBLocaltransport.Text);
        obj_Class.FOBLandedcost = Convert.ToSingle(txt_FOBLandedcost.Text);
        obj_Class.CandFCustomduty = Convert.ToSingle(txt_CANDFCusotmduty .Text);
        obj_Class.CandFInsurance = Convert.ToSingle(txt_CANDFInsurance .Text);
        obj_Class.CandFLocaltransport = Convert.ToSingle(txt_CANDFLocaltransport .Text);
        obj_Class.CandFLandedcost = Convert.ToSingle(txt_CANDFLandedcost .Text);
        obj_Class .CIFCustomduty =Convert.ToSingle(txt_CifCustomduty  .Text);
        obj_Class .CIFLocaltransport =Convert.ToSingle(txt_CIifLocaltransport.Text);
        obj_Class .CIFLandedcost =Convert.ToSingle(txt_CifLandedcost .Text);

        string filePath;
        
        try
        {
            if (FileUpload1.HasFile)
            {
                Session["FileCtrl"] = (FileUpload)FileUpload1;
                FileCtrl = (FileUpload)Session["FileCtrl"];
                // Read the file and convert it to Byte Array
                filePath = FileCtrl.PostedFile.FileName;
            }
            else
            {
                // Read the file and convert it to Byte Array
                filePath = Server.MapPath("noimage.jpeg");
                filename = "No-Image";
            }
            filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            //Set the contenttype based on File Extension
            switch (ext)
            {
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".JPG":
                    contenttype = "image/jpg";
                    break;
                case ".JPEG":
                    contenttype = "image/jpg";
                    break;
                case ".jpeg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".tif":
                    contenttype = "image/tif";
                    break;
            }
            if (contenttype != String.Empty)
            {
                if (FileUpload1.HasFile)
                {
                    Stream fs = FileCtrl.PostedFile.InputStream;
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                }
                else
                {
                    FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    bytes = br.ReadBytes((Int32)fs.Length);
                }
            }
            obj_Class.FileName = filename;
            obj_Class.ScanCopy = bytes;
            obj_Class.Status = 0;
            result = obj_Class.Bizconnect_InsertOrderManagementDetails();
            if (result != 0)
            {
                lbl_Msg.Visible = true;
                lbl_Msg.Text = "Order management details inserted successfully";
                lbl_Msg.ForeColor = System.Drawing.Color.Red;
                lbl_Msg.Attributes.Add("class", "myClass1 ");
                //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Order management details inserted successfully');</script>");
                ClearFields();
            }
            else
            {
                lbl_Msg.Visible = true;
                lbl_Msg.Text = "This Po no already exists,so you cannot enter same po no again";
                lbl_Msg.ForeColor = System.Drawing.Color.Green;
                lbl_Msg.Attributes.Add("class", "myClass2");
            }
        }
        catch (Exception ex)
        {

        }

    }
    public void ClearFields()
    {
        ddl_Buyer.SelectedIndex = -1;
        txt_Pono.Text="";
        txt_Podate.Text = "";
        txt_Product.Text = "";
        txt_ProductDesc.Text = "";
        ddl_Vendor.SelectedIndex = -1;
        ddl_Country.SelectedIndex = -1;
        ddl_Uom.SelectedIndex=-1;
        ddl_Shipmentmode.SelectedIndex = -1;
        ddl_Paymentmode.SelectedIndex = -1;
        txt_Creditterms.Text = "";
        txt_Basicvalue.Text="0";
        ddl_Currency.SelectedIndex=-1;
        txt_Exchangerate .Text ="0";
        txt_Unit .Text ="";
        txt_Quantity .Text ="0";
        txt_Unitrate .Text ="0";
        ddl_Incoterms .SelectedIndex =-1;
        txt_Nominatepickup .Text ="";

        txt_XwksCostofinlandtransport .Text ="0";
        txt_XwksCustomduty .Text ="0";
        txt_XWKSInsurance .Text ="0";
        txt_XwksLocalTransportcost .Text ="0";
        txt_XwksOceanfreight .Text ="0";
        txt_XwksLandedcost .Text ="0";

        txt_FOBCustomduty .Text ="0";
        txt_FOBFreight .Text ="0";
        txt_FOBInsurance .Text ="0";
        txt_FOBLocaltransport .Text ="0";
        txt_FOBLandedcost .Text ="0";
        
        txt_CANDFCusotmduty .Text ="0";
        txt_CANDFInsurance .Text ="0";
        txt_CANDFLocaltransport .Text ="0";
        txt_CANDFLandedcost  .Text ="0";

        txt_CifCustomduty .Text ="0";
        txt_CIifLocaltransport .Text ="0";
        txt_CifLandedcost.Text ="0";
        
    }
    protected void ddl_Incoterms_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Incoterms.SelectedItem.Text == "XWKS")
        {
            lbl_Msg.Visible = false;

            pnl_XWKS.Visible = true;

            pnl_FOB.Visible = false ;
            pnl_CandF.Visible = false ;
            pnl_CIF.Visible = false ;
        }
        else if (ddl_Incoterms.SelectedItem.Text == "FOB")
        {

            lbl_Msg.Visible = false;
            pnl_FOB.Visible = true;

            pnl_XWKS.Visible = false;
            pnl_CandF.Visible = false;
            pnl_CIF.Visible = false;
        }
        else if (ddl_Incoterms.SelectedItem.Text == "C&F")
        {
            lbl_Msg.Visible = false;

            pnl_CandF.Visible = true;

            pnl_XWKS.Visible = false;
            pnl_FOB.Visible = false;
            pnl_CIF.Visible = false;
        }
        else if (ddl_Incoterms.SelectedItem.Text == "CIF")
        {
            lbl_Msg.Visible = false;

            pnl_CIF.Visible = true;

            pnl_CandF.Visible = false ;
            pnl_XWKS.Visible = false;
            pnl_FOB.Visible = false;
        }
    }
}