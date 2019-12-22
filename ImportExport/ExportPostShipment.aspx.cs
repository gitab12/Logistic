using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class ImportExport_ExportPostShipment : System.Web.UI.Page
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
            pnl_Preshipment.Visible = false;
            pnl_Postshipment.Visible = true;
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
                    pnl_Preshipment.Visible = true;
                    if (dt_Preshipment.Rows[0][0].ToString() != "")
                    {
                        lbl_deliverydate.Text = "Delivery date : "+ dt_Preshipment.Rows[0][0].ToString();
                        lbl_3rdpartyinspection.Text = "3rd pary inspection date : " + dt_Preshipment.Rows[0][1].ToString();
                        lbl_Stuffingdate.Text = "Stuffing date : " + dt_Preshipment.Rows[0][2].ToString();
                        lbl_Chaname.Text = "CHA name : " + dt_Preshipment.Rows[0][3].ToString();
                        lbl_Freightforwardedname.Text = "Freight forwarded name : " + dt_Preshipment.Rows[0][4].ToString();
                        lbl_Vehicleno.Text = "Vehicle no : " + dt_Preshipment.Rows[0][5].ToString();
                        lbl_Vesselname.Text = "Vessel name :" + dt_Preshipment.Rows[0][6].ToString();
                        lbl_Etd.Text = "ETD : " + dt_Preshipment.Rows[0][7].ToString();
                        lbl_Eta.Text = "ETA : " + dt_Preshipment.Rows[0][8].ToString();
                        lbl_Preshipmentinvoiceno.Text = "Pre shipment invoice no : " + dt_Preshipment.Rows[0][9].ToString();
                        lbl_Preshipmentinvoicedate.Text = "Pre shipment invoice date : " + dt_Preshipment.Rows[0][10].ToString();
                        lbl_Invoiceamount.Text = "Invoice amount : " + dt_Preshipment.Rows[0][11].ToString();
                        lbl_Cha.Text = "LOT size : " + dt_Preshipment.Rows[0][12].ToString();
                        lbl_ETDdetailstocustomeron.Text = "ETD detail to customer on : " + dt_Preshipment.Rows[0][13].ToString();
                        lbl_Preshipmentdocsenttocha.Text = "Pre shipment doc sent to CHA on  : " + dt_Preshipment.Rows[0][14].ToString();
                        lbl_Shippingbillno.Text = "Shipping bill no  : " + dt_Preshipment.Rows[0][15].ToString();
                        lbl_Shippingbilldate.Text = "Shipping bill date : " + dt_Preshipment.Rows[0][16].ToString();
                        lbl_Cargohandedovertoliner.Text = "Cargo handed over to liner on  : " + dt_Preshipment.Rows[0][17].ToString();
                        lbl_Cargoonboard.Text = "Cargo on board : " + dt_Preshipment.Rows[0][18].ToString();
                        lbl_Actualetd.Text = "Actual ETD : " + dt_Preshipment.Rows[0][19].ToString();
                        lbl_COOGSPAppliedon.Text = "C.O.O /GSP applied on  : " + dt_Preshipment.Rows[0][20].ToString();
                        lbl_Docsubmittedtoconsulate.Text = "Doc submitted to consulate : " + dt_Preshipment.Rows[0][21].ToString();
                        lbl_Netweight.Text = "Net weight : " + dt_Preshipment.Rows[0][22].ToString();
                        lbl_Scheme.Text = "Scheme : " + dt_Preshipment.Rows[0][23].ToString();

                    }
                    else
                    {
                        pnl_Preshipment.Visible = false;
                    }
                }
                dt.Clear();
                dt = obj_Class.Bizconnect_LoadExportPostshipmentdetailsbyPONo();
                if (dt.Rows.Count > 0)
                {
                    txt_Originalshippingdocreceivedon.Text = dt.Rows[0][0].ToString(); 
                    txt_nnsenttocustomeron.Text = dt.Rows[0][1].ToString(); 
                    txt_Commerdoclodgedbankon.Text = dt.Rows[0][2].ToString(); 
                    txt_Lodgementrefno.Text = dt.Rows[0][3].ToString(); 
                    txt_Lodgementrefdate.Text = dt.Rows[0][4].ToString(); 
                    txt_Paymentduedate.Text = dt.Rows[0][5].ToString(); 
                    txt_TTremittanceno.Text = dt.Rows[0][6].ToString(); 
                    txt_TTremittancedate.Text = dt.Rows[0][7].ToString() ;
                    txt_Disburseadvisesenttobank.Text = dt.Rows[0][8].ToString(); 
                    txt_Transactionadvisedate.Text = dt.Rows[0][9].ToString(); 
                    txt_BRCuploadedon.Text = dt.Rows[0][10].ToString(); 
                    txt_Dutydrawbackreceivedon.Text = dt.Rows[0][11].ToString(); 
                    txt_Proofofexportdocreceivedon.Text = dt.Rows[0][12].ToString(); 
                    txt_Proofofexportdocsenttofactory.Text = dt.Rows[0][13].ToString(); 
                    txt_Proofofexportdocsenttolicencedepton.Text = dt.Rows[0][14].ToString(); 
                    txt_CHAbillno.Text = dt.Rows[0][15].ToString();
                        txt_CHAbilldate .Text = dt.Rows[0][16].ToString();
                        txt_CHAbillamount .Text = dt.Rows[0][17].ToString();
                        txt_Freightamount .Text = dt.Rows[0][18].ToString();
                        txt_Detention .Text = dt.Rows[0][19].ToString();
                        txt_whCharges.Text = dt.Rows[0][20].ToString();
                }
               
            }
            else
            {
                pnl_ExportOrder.Visible = false;
                pnl_Preshipment.Visible = false;
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
                obj_Class.OriginalShippingDocReceivedOn = DateTime .ParseExact (txt_Originalshippingdocreceivedon .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class.NNSentToCustomerOn = DateTime.ParseExact(txt_nnsenttocustomeron.Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .CommercialDocLodgedwithBankOn = DateTime .ParseExact( txt_Commerdoclodgedbankon .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .LodmentRefNo =txt_Lodgementrefno .Text;
                obj_Class .LodmentRefDate = DateTime .ParseExact(txt_Lodgementrefdate .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .PaymentdueDate =  DateTime .ParseExact(txt_Paymentduedate .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .TTRemittanceNo =txt_TTremittanceno .Text;
                obj_Class .TTRemittanceDate =  DateTime .ParseExact(txt_TTremittancedate .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .DisbursementAdviseSentToBankOn =  DateTime .ParseExact(txt_Disburseadvisesenttobank .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .TransactionAdviseDate =  DateTime .ParseExact(txt_Transactionadvisedate .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .BRCUploadedOn =  DateTime .ParseExact(txt_BRCuploadedon .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .DutyDrawbackReceivedOn =  DateTime .ParseExact(txt_Dutydrawbackreceivedon .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .ProofOfExportDocReceivedOn =  DateTime .ParseExact(txt_Proofofexportdocreceivedon .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class .ProofOfExportDocSentToFactory =  DateTime .ParseExact(txt_Proofofexportdocsenttofactory .Text,"dd/MM/yyyy",CultureInfo .InvariantCulture);
                obj_Class.ProofOfExportDocSentToLicenceDept = DateTime.ParseExact(txt_Proofofexportdocsenttolicencedepton.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.CHAbillno = txt_CHAbillno.Text;
                obj_Class.CHAbilldate = DateTime.ParseExact(txt_CHAbilldate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.CHAbillamount = Convert.ToSingle(txt_CHAbillamount.Text);
                obj_Class.Freightamount = Convert.ToSingle(txt_Freightamount.Text);
                obj_Class.Detention = Convert.ToSingle(txt_Detention.Text);
                obj_Class.WHcharges = Convert.ToSingle(txt_whCharges.Text);
                res = obj_Class.Bizconnect_UpdateExportPostShipmentDetails();
                if (res != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Export post shipment details submitted successfully');</script>");
                    ClearFields();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Post shipment details cannot be submitted since pre shipment details have not submitted ');</script>");
                }

            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select the PO no to submit the post shipment details');</script>");
            }
        }

        catch (Exception ex)
        {

        }
    }


    public void ClearFields()
    {
        txt_Originalshippingdocreceivedon.Text = "";
        txt_nnsenttocustomeron.Text = "";
        txt_Commerdoclodgedbankon.Text = "";
        txt_Lodgementrefno.Text = "";
        txt_Lodgementrefdate.Text = "";
        txt_Paymentduedate.Text = "";
        txt_TTremittanceno.Text = "";
        txt_TTremittancedate.Text = "";
        txt_Disburseadvisesenttobank.Text = "";
        txt_Transactionadvisedate.Text = "";
        txt_BRCuploadedon.Text = "";
        txt_Dutydrawbackreceivedon.Text = "";
        txt_Proofofexportdocreceivedon.Text = "";
        txt_Proofofexportdocsenttofactory.Text = "";
        txt_Proofofexportdocsenttolicencedepton.Text = "";

        txt_CHAbillno.Text = "";
        txt_CHAbilldate.Text = "";
        txt_CHAbillamount.Text = "";
        txt_Detention.Text = "";
        txt_whCharges.Text = "";
        txt_Freightamount.Text = "";

    }
}