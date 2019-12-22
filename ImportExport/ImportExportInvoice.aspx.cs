using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class ImportExport_ImportExportInvoice : System.Web.UI.Page
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
    ImportExport obj_Class = new ImportExport();
    int resp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
            LoadPoNo();
            pnl_Ordermanagement.Visible = false;
            //pnl_Invoice.Visible = false;
        }
    }
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddl_PoNo.SelectedItem.Text != "--Select--")
            {
                if (Convert.ToInt32(txt_InvoiceAmount.Text) > 100)
                {
                    obj_Class.OrderID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
                    obj_Class.InvoiceNo = txt_InvoiceNo.Text;
                    obj_Class.InvoiceDate = DateTime.ParseExact(txt_InvoiceDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj_Class.InvoiceAmount = Convert.ToSingle(txt_InvoiceAmount.Text);
                    obj_Class.BLorAWBNo = txt_BlOrAWBNo.Text;
                    obj_Class.VesselName = txt_Vesselname.Text;
                    obj_Class.ETD = DateTime.ParseExact(txt_ETD.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj_Class.ETA = DateTime.ParseExact(txt_ETA.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj_Class.Portofloading = txt_Loadingport.Text;
                    obj_Class.Portofdischarge = txt_Dischargeport.Text;
                    obj_Class.Docsent = rdb_Yes.Checked == true ? "Yes" : "No";
                    obj_Class.BLorAWBDate = DateTime.ParseExact(txt_BlOrAWBDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj_Class.ORIDoccourierAWBno = txt_OriAWBNo.Text;
                    obj_Class.ORIDoccourierAWBDate = DateTime.ParseExact(txt_OriAWBDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    resp = obj_Class.Bizconnect_UpdateOrdermanagementInvoiceDetails();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice amount should not be less than 100');</script>");
                }
                if (resp != 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice details submitted successfully');</script>");
                    ClearFields();
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice details can not be submitted because custom document submitted');</script>");
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
        txt_InvoiceNo.Text = "";
        txt_InvoiceDate.Text = "";
        txt_InvoiceAmount.Text = "";
        txt_BlOrAWBNo.Text = "";
        txt_Vesselname.Text = "";
        txt_ETD.Text = "";
        txt_ETA.Text = "";
        txt_OriAWBNo.Text = "";
        txt_OriAWBDate.Text = "";
        txt_BlOrAWBDate.Text = "";
        txt_Dischargeport.Text = "";
        txt_Loadingport.Text = "";
        rdb_No.Checked = false;
        rdb_Yes.Checked = false;
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

    protected void ddl_PoNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            pnl_Ordermanagement.Visible = true;
           
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
            //pnl_Invoice.Visible = true;
            //obj_Class.OrderID = Convert.ToInt32(ddl_PoNo.SelectedValue.ToString());
            dt_Invoice = obj_Class.Bizconnect_LoadInvoicedetailsForUpdate();
            
                if (dt_Invoice.Rows[0][0].ToString() != string.Empty)
                {
                    txt_InvoiceNo.Text = dt_Invoice.Rows[0][0].ToString();
                    txt_InvoiceDate.Text = dt_Invoice.Rows[0][1].ToString();
                    txt_InvoiceAmount.Text = dt_Invoice.Rows[0][2].ToString();
                    txt_BlOrAWBNo.Text = dt_Invoice.Rows[0][3].ToString();
                    txt_Vesselname.Text = dt_Invoice.Rows[0][4].ToString();
                    txt_ETD.Text = dt_Invoice.Rows[0][5].ToString();
                    txt_ETA.Text = dt_Invoice.Rows[0][6].ToString();
                    txt_BlOrAWBDate.Text = dt_Invoice.Rows[0][10].ToString();
                    txt_OriAWBNo.Text = dt_Invoice.Rows[0][11].ToString();
                    txt_OriAWBDate.Text = dt_Invoice.Rows[0][12].ToString();
                    txt_Loadingport.Text = dt_Invoice.Rows[0][7].ToString();
                    txt_Dischargeport.Text = dt_Invoice.Rows[0][8].ToString();
                    if (dt_Invoice.Rows[0][9].ToString() == "No")
                    {
                        rdb_No.Checked = true;
                    }
                    else
                    {
                        rdb_Yes.Checked = true;
                    }
                }
            else
            {
                //ClearFields();
            }
        }
        catch (Exception ex)
        {

        }
    }
}