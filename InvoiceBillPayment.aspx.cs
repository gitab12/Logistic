using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class InvoiceBillPayment : System.Web.UI.Page
{
    InvoiceClass obj_Class = new InvoiceClass();
    DataSet ds_InvoBilling = new DataSet();
    DataSet ds_InvoBillDetails = new DataSet();
    DataTable dt = new DataTable();
    double BalanceAmt,AmountPaid;
    int resp,i;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (!IsPostBack)
            {
                txt_PaymentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        else
        {
            Response.Redirect("Index.html");
        }
    }

    protected void imgbtn_Search_Click(object sender, ImageClickEventArgs e)
    {


        SearchInvoiceDetails(Convert.ToInt32(txt_InvoiceID.Text));

    }

    public void SearchInvoiceDetails(int InvoiceID)
    {
        //ClearFields();
        ds_InvoBillDetails = obj_Class.Search_InvoiceBillingDetails(InvoiceID);
        obj_Class.InvoiceID = Convert.ToInt32(txt_InvoiceID.Text);
        ds_InvoBilling = obj_Class.Search_InvoiceBilling(InvoiceID);
        if (ds_InvoBilling.Tables[0].Rows.Count > 0)
        {
            try
            {
                txt_Dated.Text = ds_InvoBilling.Tables[0].Rows[0][0].ToString();
                ddl_Domain.SelectedValue = ds_InvoBilling.Tables[0].Rows[0][1].ToString();
                txt_OtherRef.Text = ds_InvoBilling.Tables[0].Rows[0][2].ToString();
                txt_Remarks.Text = ds_InvoBilling.Tables[0].Rows[0][3].ToString();
                ddl_BuyerorTo.SelectedValue = ds_InvoBilling.Tables[0].Rows[0][4].ToString();
                txt_BuyerOrTodetails.Text = ds_InvoBilling.Tables[0].Rows[0][5].ToString();
                lbl_BillNO.Text = ds_InvoBilling.Tables[0].Rows[0][6].ToString();
                txt_BillAmount.Text=ds_InvoBillDetails.Tables [0].Rows [0][8].ToString ();

                dt = obj_Class.Bizconnect_InvoiceBillPaidAmount();
                if (dt.Rows.Count > 0)
                {
                    for (i = 0; i < dt.Rows.Count; i++)
                    {
                        AmountPaid += Convert.ToDouble(dt.Rows[i][5]);
                    }
                    txt_AmountPaid.Text = AmountPaid.ToString();

                    txt_PaymentDate.Text = dt.Rows[0][0].ToString();
                    txt_RecievedFrom.Text = dt.Rows[0][1].ToString();
                    //ddl_PaymentMode.SelectedItem.Text = dt.Rows[0][2].ToString();
                    txt_BillAmount.Text = dt.Rows[0][3].ToString();
                    txt_InvoiceRemarks.Text = dt.Rows[0][6].ToString();

                }
                else
                {
                    txt_AmountPaid.Text = "0";
                    txt_RecievedFrom.Text = "";
                    txt_InvoiceRemarks.Text = "";
                }
                
                BalanceAmt= (Convert .ToDouble (txt_BillAmount.Text))-(Convert .ToDouble (txt_AmountPaid.Text));

                txt_BalanceAmount.Text = BalanceAmt.ToString();

                txt_AmountPayment.Text = "";
                lbl_Msg.Visible = false;
            }
            catch (Exception ex)
            {
            }
        }
    }


    protected void ddl_Domain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Domain.SelectedValue == "SCMBizconnect")
        {
            lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
            img_Logo.Visible = false;
            lbl_BillNO.Text = "ARM/BIZ-2013/";
        }
        else if (ddl_Domain.SelectedValue == "SCMJunction")
        {
            lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
            img_Logo.Visible = false;
            lbl_BillNO.Text = "ARM/SCM-2013/";
        }
        else if (ddl_Domain.SelectedValue == "AaumConnect")
        {
            lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
            img_Logo.Visible = false;
            lbl_BillNO.Text = "ARM/AUM-2013/";
        }
        else if (ddl_Domain.SelectedValue == "SCMBizconnect1")
        {
            lbl_Companyname.Text = "AARMS VALUE CHAIN PRIVATE LIMITED";
            img_Logo.Visible = true;
            lbl_BillNO.Text = "AARMSCM/BIZ-2013/";
        }
    }

    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        if (txt_AmountPayment.Text != "")
        {
            try
            {

                obj_Class.InvoiceID = Convert.ToInt32(txt_InvoiceID.Text);
                obj_Class.BuyerorToDetails = txt_RecievedFrom.Text;
                obj_Class.GrandTotal = Convert.ToSingle(txt_BillAmount.Text);
                obj_Class.Dated = DateTime.ParseExact(txt_PaymentDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                obj_Class.InvoiceRemarks = txt_InvoiceRemarks.Text;
                resp = obj_Class.Bizconnect_InsertInvoiceBillPaymentDetails(ddl_PaymentMode.SelectedItem.Text, Convert.ToSingle(txt_AmountPaid.Text), Convert.ToSingle(txt_AmountPayment.Text));
                if (resp == 1)
                {
                    lbl_Msg.Visible = true;
                    lbl_Msg.Text = " Bill No :  " + txt_InvoiceID.Text + "   payment Details Inserted Successfully!";
                   // this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invoice Billpayment Details Inserted Successfully!');", true);
                    ClearFields();
                    txt_InvoiceID.Text = "";
                }
            }
            catch (Exception ex)
            {

            }
        }
        else
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please Enter Amount Payment!');", true);
        }

    }

    public void ClearFields()
    {
        txt_PaymentDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txt_RecievedFrom.Text = "";
        //ddl_PaymentMode.SelectedItem.Text = "Cheque";
        txt_BillAmount.Text ="";
        txt_AmountPaid.Text = "";
            txt_BalanceAmount.Text="";
            txt_AmountPayment.Text = "";
            txt_InvoiceRemarks.Text = "";

            txt_Dated.Text = "";
            txt_OtherRef.Text = "";
            txt_Remarks.Text = "";
            txt_BuyerOrTodetails.Text = "";
            lbl_BillNO.Text = "";
            txt_BillAmount.Text = "";
    }
}
