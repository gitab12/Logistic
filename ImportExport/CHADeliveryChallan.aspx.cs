using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class ImportExport_CHADeliveryChallan : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    DataTable dt_PoNo = new DataTable();
    DataTable dt = new DataTable();
    DataTable dt_Invoice = new DataTable();
    DataTable dt_Custom = new DataTable();
    DataTable dt_CHA = new DataTable();
    ImportExport obj_Class = new ImportExport();
    int resp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadPoNo();
            //pnl_CHADelivery.Visible = false;
            pnl_Po.Visible = false;
            pnl_Invoice.Visible = false;
            pnl_CustomDocument.Visible = false;
        }
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

    public void LoadPoNo()
    {
        dt_PoNo = obj_Class.Bizconnect_LoadPoNumber();
        ddl_PoNo.DataSource = dt_PoNo;
        ddl_PoNo.DataTextField = "PoNumber";
        ddl_PoNo.DataValueField = "OrderID";
        ddl_PoNo.DataBind();
        ddl_PoNo.Items.Insert(0, "--Select--");
    }
    protected void ddl_PoNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnl_CHADelivery.Visible = true;
            obj_Class.OrderID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
            dt = obj_Class.Bizconnect_LoadPoDetails();
            if (dt.Rows.Count > 0)
            {
                pnl_Po.Visible = true;
                lbl_PoNo.Text = ddl_PoNo.SelectedItem.Text;
                lbl_Podate.Text = "PO Date : " + dt.Rows[0][0].ToString();
                lbl_Product.Text = "Product : " + dt.Rows[0][1].ToString();
                lbl_Vendor.Text = " Vendor : " + dt.Rows[0][2].ToString();
                lbl_Address.Text = "Vendor Address : " + dt.Rows[0][3].ToString();
                lbl_Basicvalue.Text = "Basic Value : " + dt.Rows[0][4].ToString();
                lbl_Buyer.Text = "Buyer : " + dt.Rows[0][5].ToString();
                lbl_Quantity.Text = "Quantity : " + dt.Rows[0][6].ToString();
                lbl_Creditterms.Text = "Credit terms : " + dt.Rows[0][10].ToString();
                lbl_Incoterms.Text = "Inco terms : " + dt.Rows[0][11].ToString();
                lbl_Shipmentmode.Text = "Mode of shipment : " + dt.Rows[0][7].ToString();
                lbl_Paymentmode.Text = "Mode of payment : " + dt.Rows[0][8].ToString();
                lbl_BuyerAddress.Text = "Buyer Address : " + dt.Rows[0][9].ToString();
            }
            dt_Invoice = obj_Class.Bizconnect_LoadInvoicedetailsForUpdate();
            if (dt_Invoice.Rows.Count > 0)
            {
                if (dt_Invoice.Rows[0][0].ToString() != "")
                {
                    pnl_Invoice.Visible = true;
                    lbl_InvoiceNo.Text = "Invoice No : " + dt_Invoice.Rows[0][0].ToString();
                    lbl_InvoiceDate.Text = "Invoice Date : " + dt_Invoice.Rows[0][1].ToString();
                    lbl_InvoiceAmount.Text = "Invoice Amount : " + dt_Invoice.Rows[0][2].ToString();
                    lbl_Vessel.Text = "Vessel : " + dt_Invoice.Rows[0][4].ToString();
                    lbl_ETD.Text = "ETD : " + dt_Invoice.Rows[0][5].ToString();
                    lbl_ETA.Text = "ETA : " + dt_Invoice.Rows[0][6].ToString();
                    lbl_BlOrAWBNo.Text = "B/L (or) AWB No : " + dt_Invoice.Rows[0][3].ToString();
                    lbl_Portofdischarge.Text = "Port of delivery : " + dt_Invoice.Rows[0][8].ToString();
                    lbl_Portofloading.Text = "Port of loading : " + dt_Invoice.Rows[0][7].ToString();
                    lbl_ORIAWBno.Text = "ORIAWBNO : " + dt_Invoice.Rows[0][11].ToString();
                    lbl_Docsent.Text = "Document sent : " + dt_Invoice.Rows[0][9].ToString();
                    lbl_BlOrAWBDate.Text = "B/L (or) AWB date : " + dt_Invoice.Rows[0][10].ToString();
                }
                else
                {
                    pnl_Invoice.Visible = false;
                }
            }

            dt_Custom = obj_Class.Bizconnect_LoadCustomDocDetailsForUpdate();
            if (dt_Custom.Rows.Count > 0)
            {
                if (dt_Custom.Rows[0][0].ToString() != "")
                {
                    pnl_CustomDocument.Visible = true;
                    lbl_FRTFWD.Text = "FRTFWD Name : " + dt_Custom.Rows[0][0].ToString();
                    lbl_CHAName.Text = "CHA Name : " + dt_Custom.Rows[0][1].ToString();
                    lbl_IGM.Text = "IGM : " + dt_Custom.Rows[0][2].ToString();
                    lbl_Billentrytype.Text = "Bill of entry type : " + dt_Custom.Rows[0][3].ToString();
                    lbl_Homebillentryno.Text = "Home bill of entry no : " + dt_Custom.Rows[0][4].ToString();
                    lbl_Billentryno.Text = "Bond  bill of entry no : " + dt_Custom.Rows[0][5].ToString();
                    lbl_Billentrydate.Text = "Bill of entry date : " + dt_Custom.Rows[0][6].ToString();
                    lbl_Exchrate.Text = "Exch.rate : " + dt_Custom.Rows[0][7].ToString();
                    lbl_Assesablevalue.Text = "Assessable value : " + dt_Custom.Rows[0][8].ToString();
                    lbl_Dutystructure.Text = "Duty structure : " + dt_Custom.Rows[0][9].ToString();
                    lbl_Totalduty.Text = "Total duty : " + dt_Custom.Rows[0][10].ToString();
                    lbl_CVD.Text = "CVD : " + dt_Custom.Rows[0][11].ToString();
                    lbl_Dutypaymentorderno.Text = "Duty payment pay-order no : " + dt_Custom.Rows[0][12].ToString();
                    lbl_Dutypaymentorderdate.Text = "Duty payment pay-order date : " + dt_Custom.Rows[0][13].ToString();
                    lbl_Dutypaidon.Text = "Duty paid on : " + dt_Custom.Rows[0][14].ToString();
                    lbl_Licence.Text = "Licence details : " + dt_Custom.Rows[0][15].ToString();
                    lbl_Basicduty.Text = "HS code no : " + dt_Custom.Rows[0][19].ToString();
                    //lbl_Educess.Text = "Eduation cess : " + dt_Custom.Rows[0][17].ToString();
                    //lbl_ServiceCharge.Text = "Service Charges : " + dt_Custom.Rows[0][18].ToString();
                }
                else
                {
                    pnl_CustomDocument.Visible = false;
                }
            }

            pnl_Po.Visible = true;
            dt_CHA = obj_Class.Bizconnect_LoadCHAChallanDetailsForUpdate();
            if (dt_CHA.Rows[0][0].ToString() != "")
            {
                txt_Deliverychallanno.Text = dt_CHA.Rows[0][0].ToString();
                txt_Deliverychallandate.Text = dt_CHA.Rows[0][1].ToString();
                txt_Transporter.Text = dt_CHA.Rows[0][2].ToString();
                txt_Vehicleno.Text = dt_CHA.Rows[0][3].ToString();
                txt_Lrno.Text = dt_CHA.Rows[0][4].ToString();
                txt_Lrdate.Text = dt_CHA.Rows[0][5].ToString();
                txt_Deliveryon.Text = dt_CHA.Rows[0][6].ToString();
                txt_Chabillno.Text = dt_CHA.Rows[0][7].ToString();
                txt_Chadate.Text = dt_CHA.Rows[0][8].ToString();
                txt_Chaamount.Text = dt_CHA.Rows[0][9].ToString();
                txt_Chabillpaymentdetail.Text = dt_CHA.Rows[0][10].ToString();
                txt_Shipmentclearancecost.Text = dt_CHA.Rows[0][11].ToString();
            }
            else
            {
                ClearFields();
            }

        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {

            obj_Class.OrderID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
            obj_Class.DeliveryChallanno = txt_Deliverychallanno.Text;
            obj_Class.DeliveryChallanDate = DateTime.ParseExact(txt_Deliverychallandate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj_Class.Transporter = txt_Transporter.Text;
            obj_Class.Vehicleno = txt_Vehicleno.Text;
            obj_Class.LRNo = txt_Lrno.Text;
            obj_Class.LRDate = DateTime.ParseExact(txt_Lrdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj_Class.Deliveryon = DateTime.ParseExact(txt_Deliveryon.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj_Class.CHABillno = txt_Chabillno.Text;
            obj_Class.CHADate = DateTime.ParseExact(txt_Chadate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            obj_Class.CHAAmount = Convert.ToSingle(txt_Chaamount.Text);
            obj_Class.CHABillpaymentdetail = txt_Chabillpaymentdetail.Text;
            obj_Class.ShipmentclearanceCost = Convert.ToSingle(txt_Shipmentclearancecost.Text);
            resp = obj_Class.Bizconnect_UpdateOrdermanagementCHADeliveryDetails();
            if (resp!=0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('CHA delivery details submitted successfully');</script>");
                ClearFields();
            }
            else 
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Either invoice no or bill of entry no not submitted');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void ClearFields()
    {
        txt_Deliverychallanno.Text = "";
        txt_Deliverychallandate.Text = "";
        txt_Transporter.Text = "";
        txt_Vehicleno.Text = "";
        txt_Lrno.Text = "";
        txt_Lrdate.Text = "";
        txt_Deliveryon.Text = "";
        txt_Chabillno.Text = "";
        txt_Chadate.Text = "";
        txt_Chaamount.Text = "";
        txt_Chabillpaymentdetail.Text = "";
        txt_Shipmentclearancecost.Text = "";
    }
}