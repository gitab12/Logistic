using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class ImportExport_ExportPreShipment : System.Web.UI.Page
{
    DataTable dt_PoNo = new DataTable();
    DataTable dt = new DataTable();
    DataTable dt_Preshipment = new DataTable();
    ImportExport obj_Class = new ImportExport();
    int res = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadPoNo();
            pnl_ExportOrder.Visible = false;
            pnl_Preshipment.Visible = true;
        }
    }
    public void LoadPoNo()
    {
        dt_PoNo = obj_Class.Bizconnect_LoadExportPoNumber();
        ddl_PoNo.DataSource = dt_PoNo;
        ddl_PoNo.DataTextField = "PoNo";
        ddl_PoNo.DataValueField = "ExportID";
        ddl_PoNo.DataBind();
        ddl_PoNo.Items.Insert(0, "--Select--");

    }

    protected void ddl_PoNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnl_ExportOrder.Visible = true;
            if (ddl_PoNo.SelectedItem.Text != "--Select--")
            {
                obj_Class.ExportID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
                dt = obj_Class.Bizconnect_LoadExportPODetailsByPoNo();
                if (dt.Rows.Count > 0)
                {
                    lbl_Buyername.Text = "Buyer : " + dt.Rows[0][0].ToString();
                    lbl_Buyercountry.Text = "Buyer country : " + dt.Rows[0][1].ToString();
                    lbl_PoNumber.Text = "PO no : " + dt.Rows[0][2].ToString();
                    lbl_Podate.Text = "PO date : " + dt.Rows[0][3].ToString();
                    lbl_Itemdesc.Text = "Item Description : " + dt.Rows[0][4].ToString();
                    lbl_Quantity.Text = "Quantity : " + dt.Rows[0][5].ToString();
                    lbl_Creditterms.Text = "Credit terms : " + dt.Rows[0][6].ToString();
                    lbl_Paymentterms.Text = "Payment terms : " + dt.Rows[0][7].ToString();
                    lbl_Povalue.Text = "PO value : " + dt.Rows[0][8].ToString();
                    lbl_Shipmentmode.Text = "Mode of shipment : " + dt.Rows[0][9].ToString();
                    lbl_Currency.Text = "Currency : " + dt.Rows[0][10].ToString();
                    lbl_Loadingport.Text = "Port of loading : " + dt.Rows[0][11].ToString();
                    lbl_Dischargeport.Text = "Port of discharge : " + dt.Rows[0][12].ToString();
                    lbl_Internalworksorder.Text = "Internal works order : " + dt.Rows[0][13].ToString();
                    lbl_PoNo.Text = dt.Rows[0][2].ToString();
                }
                dt_Preshipment = obj_Class.Bizconnect_LoadPreshipmentdetailsByPONo();
                if (dt_Preshipment.Rows.Count > 0)
                {
                    txt_Deliverydate.Text = dt_Preshipment.Rows[0][0].ToString();
                    txt_InspectionDate.Text = dt_Preshipment.Rows[0][1].ToString();
                    txt_Stuffingdate.Text = dt_Preshipment.Rows[0][2].ToString();
                    txt_CHAname.Text = dt_Preshipment.Rows[0][3].ToString();
                    txt_Freightforwardername.Text = dt_Preshipment.Rows[0][4].ToString();
                    txt_Vehicleno.Text = dt_Preshipment.Rows[0][5].ToString();
                    txt_Vesselname.Text = dt_Preshipment.Rows[0][6].ToString();
                    txt_ETD.Text = dt_Preshipment.Rows[0][7].ToString();
                    txt_ETA.Text = dt_Preshipment.Rows[0][8].ToString();
                    txt_Preshipmentinvoiceno.Text = dt_Preshipment.Rows[0][9].ToString();
                    txt_Preshipmentinvoicedate.Text = dt_Preshipment.Rows[0][10].ToString();
                    txt_Invoiceamount.Text = dt_Preshipment.Rows[0][11].ToString();
                    txt_Lotsize.Text = dt_Preshipment.Rows[0][12].ToString();
                   
                    txt_ETDdetailtocustomeron.Text = dt_Preshipment.Rows[0][13].ToString();
                    txt_Preshipmentdocsenttochaon.Text = dt_Preshipment.Rows[0][14].ToString();
                    txt_Shippingbillno.Text = dt_Preshipment.Rows[0][15].ToString();
                    txt_Shippingbilldate.Text = dt_Preshipment.Rows[0][16].ToString();
                    txt_Cargohadedovertolineron.Text = dt_Preshipment.Rows[0][17].ToString();
                    txt_Cargoonboard.Text = dt_Preshipment.Rows[0][18].ToString();
                    txt_Actialetd.Text = dt_Preshipment.Rows[0][19].ToString();
                    txt_COOGSPappliedon.Text = dt_Preshipment.Rows[0][20].ToString();
                    txt_Docsubmittedtoconsulate.Text = dt_Preshipment.Rows[0][21].ToString();
                    txt_Netweight.Text = dt_Preshipment.Rows[0][22].ToString();
                    txt_Scheme.Text = dt_Preshipment.Rows[0][23].ToString();
                }
            }
            else
            {
                pnl_ExportOrder.Visible = false;
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
            if (ddl_PoNo.SelectedItem.Text != "--Select--")
            {
                obj_Class.ExportID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
                obj_Class.DeliveryDate = DateTime .ParseExact (txt_Deliverydate.Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class.ThirdpartyInspectionDate = DateTime.ParseExact(txt_InspectionDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.StuffingDate = DateTime.ParseExact(txt_Stuffingdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.CHAName = txt_CHAname.Text;
                obj_Class.FreightForwardedName = txt_Freightforwardername.Text;
                obj_Class.VehicleNo = txt_Vehicleno.Text;
                obj_Class.LOTsize = txt_Lotsize.Text;
                obj_Class.VesselName = txt_Vesselname.Text;
                obj_Class.ETD = DateTime.ParseExact(txt_ETD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.ETA = DateTime.ParseExact(txt_ETA.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.PreShipmentInvoiceNo = txt_Preshipmentinvoiceno.Text;
                obj_Class.PreShipmentInvoiceDate = DateTime.ParseExact(txt_Preshipmentinvoicedate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.InvoiceAmount = Convert.ToSingle(txt_Invoiceamount.Text);
                obj_Class.NetWeight = txt_Netweight.Text;
                obj_Class.ETDDetailToCustomerOn = DateTime.ParseExact(txt_ETDdetailtocustomeron.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.PReShipmentDocSentToCHAOn = DateTime.ParseExact(txt_Preshipmentdocsenttochaon.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.ShippingBillNo = txt_Shippingbillno.Text;
                obj_Class.ShippingBillDate = DateTime.ParseExact(txt_Shippingbilldate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.Scheme = txt_Scheme.Text;
                obj_Class.CargoHandedOverToLinerOn = DateTime.ParseExact(txt_Cargohadedovertolineron.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.CargoOnBoard = DateTime.ParseExact(txt_Cargoonboard.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.ActualETD = DateTime.ParseExact(txt_Actialetd.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.COOorGSPAppliedOn = DateTime.ParseExact(txt_COOGSPappliedon.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.DocSubmittedToConsulate = txt_Docsubmittedtoconsulate .Text;
                res = obj_Class.Bizconnect_UpdateExportPreShipmentDetails();
                if (res != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Details updated successsfully');</script>");
                    ClearFields();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Preshipment details cannot be updated since post shipment details have been already submitted');</script>");
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select the PO no to submit the pre shipment details');</script>");
            }
        }

        catch (Exception ex)
        {

        }
    }

     public void ClearFields()
     {
         txt_Deliverydate.Text = "";
         txt_InspectionDate.Text = "";
         txt_Stuffingdate.Text = "";
         txt_CHAname.Text = "";
         txt_Freightforwardername.Text = "";
         txt_Vehicleno.Text = "";
         txt_Lotsize.Text = "";
         txt_Vesselname.Text = "";
         txt_ETD.Text = "";
         txt_ETA.Text = "";
         txt_Preshipmentinvoiceno.Text = "";
         txt_Preshipmentinvoicedate.Text = "";
         txt_Invoiceamount.Text = "";
         txt_ETDdetailtocustomeron.Text = "";
         txt_Preshipmentdocsenttochaon.Text = "";
         txt_Shippingbillno.Text = "";
         txt_Shippingbilldate.Text = "";
         txt_Cargohadedovertolineron.Text = "";
         txt_Cargoonboard.Text = "";
         txt_Actialetd.Text = "";
         txt_COOGSPappliedon.Text = "";
         txt_Docsubmittedtoconsulate.Text = "";
         txt_Netweight.Text = "";
         txt_Scheme.Text = "";
     }
}