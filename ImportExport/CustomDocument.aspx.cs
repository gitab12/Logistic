using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class ImportExport_CustomDocument : System.Web.UI.Page
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
    ImportExport obj_Class = new ImportExport();
    int resp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadPoNo();
            //pnl_CustomDocument.Visible = false;
            pnl_Po.Visible = false;
            pnl_Invoice.Visible =false;
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

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_PoNo.SelectedItem.Text != "--Select--")
            {
                obj_Class.OrderID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
                obj_Class.IGM = txt_IGM.Text;
                obj_Class.Billofentryno = txt_Billentryno.Text;
                obj_Class.Billofentrydate = DateTime.ParseExact(txt_Billentrydate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.Assessablevalue = Convert.ToSingle(txt_Assessablevalue.Text);
                //obj_Class.Basicduty = Convert.ToSingle(txt_Basicduty.Text);
                obj_Class.CVD = txt_CVD.Text;
                //obj_Class.EduCess = Convert.ToSingle(txt_Educationcess.Text);
                //obj_Class.ServiceCharge = Convert.ToSingle(txt_Servicecharge.Text);
                obj_Class.HSCodeno = txt_HSCodeno.Text;
                obj_Class.TotalDuty = Convert.ToSingle(txt_Totalduty.Text);
                obj_Class.Dutypaymentpayorderno = txt_payorderno.Text;
                obj_Class.Dutypaymentpayorderdate = DateTime.ParseExact(txt_Payorderdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.FRTFWDname = txt_FRTFWDname.Text;
                obj_Class.CHAname = txt_Chaname.Text;
                obj_Class.Billofentrytype = txt_Billentrytype.Text;
                obj_Class.Homebillofentryno = txt_Homebillentryno.Text;
                obj_Class.Exchrate = Convert.ToSingle(txt_Exchrate.Text);
                obj_Class.Dutysctructure = txt_Dutystructure.Text;
                obj_Class.Dutypaidon = DateTime.ParseExact(txt_Dutypaidon.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.Licencedetail = txt_Licence.Text;
                resp = obj_Class.Bizconnect_UpdateOrdermanagementCustomDocumentDetails();
             if (resp !=0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Custom document details submitted successfully');</script>");
                    ClearFields();
                }
             else
             {
                 ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Custom document details can not be submitted because Invoice details not submitted for this PO no');</script>");
             }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select Po no ');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void ClearFields()
    {
        ddl_PoNo.SelectedIndex = -1;
        txt_IGM.Text = "";
        txt_Billentryno.Text = "";
        txt_Billentrydate.Text = "";
        txt_Assessablevalue.Text = "";
        //txt_Basicduty.Text = "";
        txt_CVD.Text = "";
        //txt_Educationcess.Text = "";
        //txt_Servicecharge.Text = "";
        txt_Totalduty.Text = "";
        txt_payorderno.Text = "";

        txt_Payorderdate.Text = "";
        txt_Dutystructure.Text = "";
        txt_Chaname.Text = "";
        txt_Dutypaidon.Text = "";
        txt_Exchrate.Text = "";
        txt_Licence.Text = "";
        txt_Homebillentryno.Text = "";
        txt_FRTFWDname.Text = "";
        txt_Billentrytype.Text = "";
    }

    protected void ddl_PoNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnl_CustomDocument.Visible = true;
            obj_Class.OrderID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
            dt = obj_Class.Bizconnect_LoadPoDetails();
            if (dt.Rows.Count > 0)
            {
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
            if (dt_Invoice.Rows .Count  > 0)
            {
                if (dt_Invoice.Rows[0][0].ToString ()!="")
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
            
            pnl_Po.Visible = true;

            dt_Custom = obj_Class.Bizconnect_LoadCustomDocDetailsForUpdate();
            if (dt_Custom.Rows[0][1].ToString() != string.Empty)
            {
                txt_FRTFWDname.Text = dt_Custom.Rows[0][0].ToString();
                txt_Chaname.Text = dt_Custom.Rows[0][1].ToString();
                txt_IGM.Text = dt_Custom.Rows[0][2].ToString();
                txt_Billentrytype.Text = dt_Custom.Rows[0][3].ToString();
                txt_Homebillentryno.Text = dt_Custom.Rows[0][4].ToString();
                txt_Billentryno.Text = dt_Custom.Rows[0][5].ToString();
                txt_Billentrydate.Text = dt_Custom.Rows[0][6].ToString();
                txt_Exchrate.Text = dt_Custom.Rows[0][7].ToString();
                txt_Assessablevalue.Text = dt_Custom.Rows[0][8].ToString();
                txt_Dutystructure.Text = dt_Custom.Rows[0][9].ToString();
                txt_Totalduty.Text = dt_Custom.Rows[0][10].ToString();
                txt_CVD.Text = dt_Custom.Rows[0][11].ToString();
                txt_payorderno.Text = dt_Custom.Rows[0][12].ToString();
                txt_Payorderdate.Text = dt_Custom.Rows[0][13].ToString();
                txt_Dutypaidon.Text = dt_Custom.Rows[0][14].ToString();
                txt_Licence.Text = dt_Custom.Rows[0][15].ToString();
                //txt_Basicduty.Text = dt_Custom.Rows[0][16].ToString();
                //txt_Educationcess.Text = dt_Custom.Rows[0][17].ToString();
                //txt_Servicecharge.Text = dt_Custom.Rows[0][18].ToString();
                
            }
            else
            {
                txt_IGM.Text = "";
                txt_Billentryno.Text = "";
                txt_Billentrydate.Text = "";
                txt_Assessablevalue.Text = "0";
                //txt_Basicduty.Text = "0";
                txt_CVD.Text = "0";
                //txt_Educationcess.Text = "0";
                //txt_Servicecharge.Text = "0";
                txt_Totalduty.Text = "0";
                txt_payorderno.Text = "";

                txt_Payorderdate.Text = "";
                txt_Dutystructure.Text = "";
                txt_Chaname.Text = "";
                txt_Dutypaidon.Text = "";
                txt_Exchrate.Text = "0";
                txt_Licence.Text = "";
                txt_Homebillentryno.Text = "";
                txt_FRTFWDname.Text = "";
                txt_Billentrytype.Text = "";
            }
        }
        catch (Exception ex)
        {

        }
    }

}