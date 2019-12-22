using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;
using System.Globalization;

public partial class Invoice : System.Web.UI.Page
{

    InvoiceClass obj_Class = new InvoiceClass();
    int res1, res2,res3,res4,GrandTotal;
    DataSet ds_InvoiceID = new DataSet();
    DataSet ds_InvoBilling = new DataSet();
    DataSet ds_InvoBillDetails = new DataSet();
    double total, Amount1, Amount2, Amount3, Amount4, AmtTotal, STax, ECess, HesCess, TotalGrand;
           string GTotal;
           public string Tblcount;
    protected void Page_Load(object sender, EventArgs e)
    {
    //if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
    //    {
        if (IsPostBack != true)
        {

                if (Request.QueryString.Count > 0)
                 {
                txt_InvoiceID.Text = Request.QueryString["InVID"];
                SearchInvoiceDetails(Convert.ToInt32(Request.QueryString["InVID"]));
                }
                 else
                    {
                txt_Dated.Text = DateTime.Now.ToString("dd/MM/yyyy");
                Get_InvoiceID();
                lbl_BillNO.Text = "AARMS/BIZ-2014/";
                    }
                 }
            //}
   //else
   //     {
   //         Response.Redirect("Index.aspx");
   //     }
    }

    public void Get_InvoiceID()
    {
        ds_InvoiceID = obj_Class.Get_InvoiceID();
        txt_InvoiceID.Text = ds_InvoiceID.Tables[0].Rows[0][0].ToString();
    }
    protected void ddl_Domain_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_Domain.SelectedValue == "SCMBizconnect")
        {
            lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
            img_Logo.Visible = false ;
            lbl_BillNO.Text = "ARM/BIZ-2013/";
            lbl_Name.Text = "ARM SUPPLY CHAIN SOLUTIONS";
        }
        else if (ddl_Domain.SelectedValue == "SCMJunction")
        {
            lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
            img_Logo.Visible = false;
            lbl_BillNO.Text = "ARM/SCM-2013/";
            lbl_Name.Text = "ARM SUPPLY CHAIN SOLUTIONS";
        }
        else if (ddl_Domain.SelectedValue == "AaumConnect")
        {
            lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
            img_Logo.Visible = false;
            lbl_BillNO.Text = "ARM/AUM-2013/";
            lbl_Name.Text = "ARM SUPPLY CHAIN SOLUTIONS";
        }
        else if (ddl_Domain.SelectedValue == "SCMBizconnect1")
        {
            lbl_Companyname.Text = "AARMS VALUE CHAIN PRIVATE LIMITED";
            img_Logo.Visible = true;
            lbl_BillNO.Text = "AARMSCM/BIZ-2013/";
            lbl_Name.Text = "AARMS VALUE CHAIN PRIVATE LIMITED";
        }
        Clearfields2();
        GetZerosforNumericfields();
    }
    //protected void btn_Print_Click(object sender, EventArgs e)
    //{
    //    lbl_Particulars.Visible = true;
    //    lbl_Particulars.Text = ddl_particulars.SelectedValue.ToString();
    //    ddl_particulars.Visible = false;
    //    lbl_Quantity.Visible = true;
    //    lbl_Quantity.Text = ddl_QuantityorNooftrucks.SelectedValue.ToString();
    //    ddl_QuantityorNooftrucks.Visible = false;
    //    lbl_Buyer.Visible = true;
    //    ddl_BuyerorTo.Visible = false;
    //    lbl_Buyer.Text = ddl_BuyerorTo.SelectedValue.ToString();
        
    //    lbl_Domain.Visible = true;
    //    lbl_Domain.Text = ddl_Domain.SelectedValue.ToString();
    //    ddl_Domain.Visible = false;
    //    //Page.ClientScript.RegisterStartupScript(GetType(), "MyKey1", "callPrint('divReport');", true);
    //}
    protected void btn_Submit_Click(object sender, EventArgs e)
    {
		obj_Class.InvoiceID = Convert .ToInt32(txt_InvoiceID.Text);
        obj_Class.Dated = DateTime.ParseExact(txt_Dated.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        obj_Class.Domain = ddl_Domain.SelectedValue;
        obj_Class.OtherReferences = txt_OtherRef.Text;
        obj_Class.InvoiceRemarks = txt_Remarks.Text;
        obj_Class.BuyerorTo = ddl_BuyerorTo.SelectedValue;
        obj_Class.BuyerorToDetails = txt_BuyerOrTodetails.Text;
        obj_Class.BillNo = lbl_BillNO.Text;
        obj_Class.Status = 2;
        res1 = obj_Class.Insert_InvoiceBilling();
        if (res1 == 0)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('This Invoice BillNo Already Exists!Click Reset Button For New BillNo');", true);
        }
        else
        {

        obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
        obj_Class.Tax12percent = Convert.ToSingle(txt_12percent.Text);
        obj_Class.Tax2percent = Convert.ToSingle(txt_2percent.Text);
        obj_Class.Tax1percent = Convert.ToSingle(txt_1percent.Text);
        obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
        obj_Class.ServiceTax=Convert.ToSingle(txt_Tax12per.Text);
        obj_Class.EducationCess=Convert.ToSingle(txt_Tax2per.Text);
        obj_Class.HigherEducationCess=Convert.ToSingle(txt_Tax1per.Text);
        string Words = retWord(Convert.ToInt32(txt_Total.Text));
            txt_AmountInwords.Text = Words;
            obj_Class.AmountInwords = txt_AmountInwords.Text+" Only";
        
        if (txt_Desc1.Text != string.Empty)
        {
            obj_Class.Particulars = txt_Desc1.Text;
            if (txt_Quantity1.Text == string.Empty)
            {
                obj_Class.QuantityNoofTrucks = 0;
            }
            else
            {
                obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity1.Text);
            }
            obj_Class.Rate = Convert.ToSingle(txt_Rate1.Text);
            obj_Class.Amount = Convert.ToSingle(txt_Amount1.Text);

            res2 = obj_Class.Insert_InvoiceBilling_Details();
        }
        if (txt_Desc2.Text != string.Empty)
        {
            obj_Class.Particulars = txt_Desc2.Text;
            if (txt_Quantity1.Text == string.Empty)
            {
                obj_Class.QuantityNoofTrucks = 0;
            }
            else
            {
                obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity1.Text);
            }
            obj_Class.Rate = Convert.ToSingle(txt_Rate2.Text);
            obj_Class.Amount = Convert.ToSingle(txt_Amount2.Text);
            res2 = obj_Class.Insert_InvoiceBilling_Details();
        }
        if (txt_Desc3.Text != string.Empty)
        {
            obj_Class.Particulars = txt_Desc3.Text;
            obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity3.Text);
            obj_Class.Rate = Convert.ToSingle(txt_Rate3.Text);
            obj_Class.Amount = Convert.ToSingle(txt_Amount3.Text);
            res2 = obj_Class.Insert_InvoiceBilling_Details();
        }
        if (txt_Desc4.Text != string.Empty)
        {
            obj_Class.Particulars = txt_Desc4.Text;
            obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity4.Text);
            obj_Class.Rate = Convert.ToSingle(txt_Rate4.Text);
            obj_Class.Amount = Convert.ToSingle(txt_Amount4.Text);
            res2 = obj_Class.Insert_InvoiceBilling_Details();
        }
        //if (txt_Desc5.Text != string.Empty)
        //{
        //    obj_Class.Particulars = txt_Desc5.Text;
        //    obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity5.Text);
        //    obj_Class.Rate = Convert.ToSingle(txt_Rate5.Text);
        //    obj_Class.Amount = Convert.ToSingle(txt_Amount5.Text);
        //    res2 = obj_Class.Insert_InvoiceBilling_Details();
        //}
        if (res1 == 1 && res2 == 1)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice Details Inserted Successfully');</script>");
            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invoice Details Inserted Successfully! And The BillNo is " + txt_InvoiceID.Text + "');", true);
            Clearfields();
            Get_InvoiceID();
            GetZerosToAmountFields();
        }
        }
        txt_Dated.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //btn_Print.Enabled =true;
    }
    public void Clearfields()
    {
        txt_Dated.Text = "";
        txt_OtherRef.Text = "";
        txt_Remarks.Text = "";
        txt_BuyerOrTodetails.Text = "";
        txt_Amount1.Text = "";
        txt_Amount2.Text = "";
        txt_Amount3.Text = "";
        txt_Amount4.Text = "";
        //txt_Amount5.Text = "";
        txt_Desc1.Text = "";
        txt_Desc2.Text = "";
        txt_Desc3.Text = "";
        txt_Desc4.Text = "";
        txt_Desc4.Text = "";
        //txt_Desc5.Text = "";
        txt_Quantity1.Text = "";
        txt_Quantity2.Text = "";
        txt_Quantity3.Text = "";
        txt_Quantity4.Text = "";
        //txt_Quantity5.Text = "";
        txt_Rate1.Text = "";
        txt_Rate2.Text = "";
        txt_Rate3.Text = "";
        txt_Rate4.Text = "";
        //txt_Rate5.Text = "";
        txt_GrandTotal.Text = "";
        txt_Total.Text="";
        txt_12percent.Text = "";
        txt_2percent.Text = "";
        txt_1percent.Text = "";
        txt_Tax12per.Text = "";
        txt_Tax2per.Text = "";
        txt_Tax1per.Text = "";
        txt_AmountInwords.Text = "";
        ddl_BuyerorTo.SelectedIndex = -1;
        ddl_BuyerorTo.ClearSelection();
        ddl_Domain.SelectedIndex = -1;
        ddl_Domain.ClearSelection();
        ddl_particulars.SelectedIndex = -1;
        ddl_particulars.ClearSelection();
        ddl_QuantityorNooftrucks.SelectedIndex = -1;
        ddl_QuantityorNooftrucks.ClearSelection();
    }
    protected void imgbtn_Search_Click(object sender, ImageClickEventArgs e)
    {


        SearchInvoiceDetails(Convert.ToInt32(txt_InvoiceID.Text));
       
    }


    public void SearchInvoiceDetails(int InvoiceID)
    {

        ds_InvoBillDetails = obj_Class.Search_InvoiceBillingDetails(InvoiceID);
        Tblcount = ds_InvoBillDetails.Tables[0].Rows.Count.ToString();
        Session["Tblcount"] = Convert.ToInt32(Tblcount);
        ddl_particulars.Visible = true;
        lbl_Particulars.Visible = false;
        lbl_Quantity.Visible = false;
        ddl_QuantityorNooftrucks.Visible = true;
        Clearfields();
        GetZerosToAmountFields();
        //btn_Print.Enabled =true;
        btn_Update.Enabled = true;
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
            }
            catch (Exception ex)
            {
            }
            txt_AmountInwords.Text = "";
        }

        ds_InvoBillDetails = obj_Class.Search_InvoiceBillingDetails(InvoiceID);
        if (ds_InvoBillDetails.Tables[0].Rows.Count > 0)
        {

            if (ds_InvoBillDetails.Tables[0].Rows.Count == 1)
            {
                txt_Desc1.Text = ds_InvoBillDetails.Tables[0].Rows[0][0].ToString();
                txt_Quantity1.Text = ds_InvoBillDetails.Tables[0].Rows[0][1].ToString();
                txt_Rate1.Text = ds_InvoBillDetails.Tables[0].Rows[0][2].ToString();
                txt_Amount1.Text = ds_InvoBillDetails.Tables[0].Rows[0][3].ToString();

                txt_GrandTotal.Text = ds_InvoBillDetails.Tables[0].Rows[0][4].ToString();
                txt_12percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][5]).ToString();
                txt_2percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][6]).ToString();
                txt_1percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][7]).ToString();
                //total=Math.Ceiling(ds_InvoBillDetails.Tables[0].Rows[0][8]);
                txt_Total.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][8]).ToString();
                txt_Tax12per.Text = ds_InvoBillDetails.Tables[0].Rows[0][9].ToString();
                txt_Tax2per.Text = ds_InvoBillDetails.Tables[0].Rows[0][10].ToString();
                txt_Tax1per.Text = ds_InvoBillDetails.Tables[0].Rows[0][11].ToString();
                txt_AmountInwords.Text = ds_InvoBillDetails.Tables[0].Rows[0][12].ToString();
                Session["InvoiceBillID1"] = ds_InvoBillDetails.Tables[0].Rows[0][13].ToString();
                tr1.Visible = true;

                tr2.Visible = false;
                tr3.Visible = false;
                tr4.Visible = false;
            }

            if (ds_InvoBillDetails.Tables[0].Rows.Count == 2)
            {

                txt_Desc1.Text = ds_InvoBillDetails.Tables[0].Rows[0][0].ToString();
                txt_Quantity1.Text = ds_InvoBillDetails.Tables[0].Rows[0][1].ToString();
                txt_Rate1.Text = ds_InvoBillDetails.Tables[0].Rows[0][2].ToString();
                txt_Amount1.Text = ds_InvoBillDetails.Tables[0].Rows[0][3].ToString();

                txt_GrandTotal.Text = ds_InvoBillDetails.Tables[0].Rows[0][4].ToString();
                txt_12percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][5]).ToString();
                txt_2percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][6]).ToString();
                txt_1percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][7]).ToString();
                //total=Math.Ceiling(ds_InvoBillDetails.Tables[0].Rows[0][8]);
                txt_Total.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][8]).ToString();
                txt_Tax12per.Text = ds_InvoBillDetails.Tables[0].Rows[0][9].ToString();
                txt_Tax2per.Text = ds_InvoBillDetails.Tables[0].Rows[0][10].ToString();
                txt_Tax1per.Text = ds_InvoBillDetails.Tables[0].Rows[0][11].ToString();
                txt_AmountInwords.Text = ds_InvoBillDetails.Tables[0].Rows[0][12].ToString();
                Session["InvoiceBillID1"] = ds_InvoBillDetails.Tables[0].Rows[0][13].ToString();

                txt_Desc2.Text = ds_InvoBillDetails.Tables[0].Rows[1][0].ToString();
                txt_Quantity2.Text = ds_InvoBillDetails.Tables[0].Rows[1][1].ToString();
                txt_Rate2.Text = ds_InvoBillDetails.Tables[0].Rows[1][2].ToString();
                txt_Amount2.Text = ds_InvoBillDetails.Tables[0].Rows[1][3].ToString();
                Session["InvoiceBillID2"] = ds_InvoBillDetails.Tables[0].Rows[1][13].ToString();
                tr1.Visible = true;
                tr2.Visible = true;

                tr3.Visible = false;
                tr4.Visible = false;
            }

            if (ds_InvoBillDetails.Tables[0].Rows.Count == 3)
            {

                txt_Desc1.Text = ds_InvoBillDetails.Tables[0].Rows[0][0].ToString();
                txt_Quantity1.Text = ds_InvoBillDetails.Tables[0].Rows[0][1].ToString();
                txt_Rate1.Text = ds_InvoBillDetails.Tables[0].Rows[0][2].ToString();
                txt_Amount1.Text = ds_InvoBillDetails.Tables[0].Rows[0][3].ToString();

                txt_GrandTotal.Text = ds_InvoBillDetails.Tables[0].Rows[0][4].ToString();
                txt_12percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][5]).ToString();
                txt_2percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][6]).ToString();
                txt_1percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][7]).ToString();
                //total=Math.Ceiling(ds_InvoBillDetails.Tables[0].Rows[0][8]);
                txt_Total.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][8]).ToString();
                txt_Tax12per.Text = ds_InvoBillDetails.Tables[0].Rows[0][9].ToString();
                txt_Tax2per.Text = ds_InvoBillDetails.Tables[0].Rows[0][10].ToString();
                txt_Tax1per.Text = ds_InvoBillDetails.Tables[0].Rows[0][11].ToString();
                txt_AmountInwords.Text = ds_InvoBillDetails.Tables[0].Rows[0][12].ToString();
                Session["InvoiceBillID1"] = ds_InvoBillDetails.Tables[0].Rows[0][13].ToString();

                txt_Desc2.Text = ds_InvoBillDetails.Tables[0].Rows[1][0].ToString();
                txt_Quantity2.Text = ds_InvoBillDetails.Tables[0].Rows[1][1].ToString();
                txt_Rate2.Text = ds_InvoBillDetails.Tables[0].Rows[1][2].ToString();
                txt_Amount2.Text = ds_InvoBillDetails.Tables[0].Rows[1][3].ToString();
                Session["InvoiceBillID2"] = ds_InvoBillDetails.Tables[0].Rows[1][13].ToString();

                txt_Desc3.Text = ds_InvoBillDetails.Tables[0].Rows[2][0].ToString();
                txt_Quantity3.Text = ds_InvoBillDetails.Tables[0].Rows[2][1].ToString();
                txt_Rate3.Text = ds_InvoBillDetails.Tables[0].Rows[2][2].ToString();
                txt_Amount3.Text = ds_InvoBillDetails.Tables[0].Rows[2][3].ToString();
                Session["InvoiceBillID3"] = ds_InvoBillDetails.Tables[0].Rows[2][13].ToString();
                tr1.Visible = true;
                tr2.Visible = true;
                tr3.Visible = true;

                tr4.Visible = false;
            }

            if (ds_InvoBillDetails.Tables[0].Rows.Count == 4)
            {
                txt_Desc1.Text = ds_InvoBillDetails.Tables[0].Rows[0][0].ToString();
                txt_Quantity1.Text = ds_InvoBillDetails.Tables[0].Rows[0][1].ToString();
                txt_Rate1.Text = ds_InvoBillDetails.Tables[0].Rows[0][2].ToString();
                txt_Amount1.Text = ds_InvoBillDetails.Tables[0].Rows[0][3].ToString();

                txt_GrandTotal.Text = ds_InvoBillDetails.Tables[0].Rows[0][4].ToString();
                txt_12percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][5]).ToString();
                txt_2percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][6]).ToString();
                txt_1percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][7]).ToString();
                //total=Math.Ceiling(ds_InvoBillDetails.Tables[0].Rows[0][8]);
                txt_Total.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][8]).ToString();
                txt_Tax12per.Text = ds_InvoBillDetails.Tables[0].Rows[0][9].ToString();
                txt_Tax2per.Text = ds_InvoBillDetails.Tables[0].Rows[0][10].ToString();
                txt_Tax1per.Text = ds_InvoBillDetails.Tables[0].Rows[0][11].ToString();
                txt_AmountInwords.Text = ds_InvoBillDetails.Tables[0].Rows[0][12].ToString();
                Session["InvoiceBillID1"] = ds_InvoBillDetails.Tables[0].Rows[0][13].ToString();

                txt_Desc2.Text = ds_InvoBillDetails.Tables[0].Rows[1][0].ToString();
                txt_Quantity2.Text = ds_InvoBillDetails.Tables[0].Rows[1][1].ToString();
                txt_Rate2.Text = ds_InvoBillDetails.Tables[0].Rows[1][2].ToString();
                txt_Amount2.Text = ds_InvoBillDetails.Tables[0].Rows[1][3].ToString();
                Session["InvoiceBillID2"] = ds_InvoBillDetails.Tables[0].Rows[1][13].ToString();

                txt_Desc3.Text = ds_InvoBillDetails.Tables[0].Rows[2][0].ToString();
                txt_Quantity3.Text = ds_InvoBillDetails.Tables[0].Rows[2][1].ToString();
                txt_Rate3.Text = ds_InvoBillDetails.Tables[0].Rows[2][2].ToString();
                txt_Amount3.Text = ds_InvoBillDetails.Tables[0].Rows[2][3].ToString();
                Session["InvoiceBillID3"] = ds_InvoBillDetails.Tables[0].Rows[2][13].ToString();

                txt_Desc4.Text = ds_InvoBillDetails.Tables[0].Rows[3][0].ToString();
                txt_Quantity4.Text = ds_InvoBillDetails.Tables[0].Rows[3][1].ToString();
                txt_Rate4.Text = ds_InvoBillDetails.Tables[0].Rows[3][2].ToString();
                txt_Amount4.Text = ds_InvoBillDetails.Tables[0].Rows[3][3].ToString();
                Session["InvoiceBillID4"] = ds_InvoBillDetails.Tables[0].Rows[3][13].ToString();
                tr1.Visible = true;
                tr2.Visible = true;
                tr3.Visible = true;
                tr4.Visible = true;
            }

            //try
            //{
            //    if (ds_InvoBillDetails.Tables[0].Rows[0] != null)
            //    {
            //        txt_Desc1.Text = ds_InvoBillDetails.Tables[0].Rows[0][0].ToString();
            //        txt_Quantity1.Text = ds_InvoBillDetails.Tables[0].Rows[0][1].ToString();
            //        txt_Rate1.Text = ds_InvoBillDetails.Tables[0].Rows[0][2].ToString();
            //        txt_Amount1.Text = ds_InvoBillDetails.Tables[0].Rows[0][3].ToString();

            //        txt_GrandTotal.Text = ds_InvoBillDetails.Tables[0].Rows[0][4].ToString();
            //        txt_12percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][5]).ToString();
            //        txt_2percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][6]).ToString();
            //        txt_1percent.Text = String.Format("{0:F2}", ds_InvoBillDetails.Tables[0].Rows[0][7]).ToString();
            //        //total=Math.Ceiling(ds_InvoBillDetails.Tables[0].Rows[0][8]);
            //        txt_Total.Text = String.Format("{0:F2}",ds_InvoBillDetails.Tables[0].Rows[0][8]).ToString();
            //        txt_Tax12per.Text= ds_InvoBillDetails.Tables[0].Rows[0][9].ToString();
            //        txt_Tax2per.Text= ds_InvoBillDetails.Tables[0].Rows[0][10].ToString();
            //        txt_Tax1per.Text=ds_InvoBillDetails.Tables[0].Rows[0][11].ToString();
            //        txt_AmountInwords .Text =ds_InvoBillDetails.Tables[0].Rows[0][12].ToString();
            //        Session["InvoiceBillID1"] = ds_InvoBillDetails.Tables[0].Rows[0][13].ToString();
            //    }
            //    if (ds_InvoBillDetails.Tables[0].Rows[1] != null)
            //    {
            //        txt_Desc2.Text = ds_InvoBillDetails.Tables[0].Rows[1][0].ToString();
            //        txt_Quantity2.Text = ds_InvoBillDetails.Tables[0].Rows[1][1].ToString();
            //        txt_Rate2.Text = ds_InvoBillDetails.Tables[0].Rows[1][2].ToString();
            //        txt_Amount2.Text = ds_InvoBillDetails.Tables[0].Rows[1][3].ToString();
            //        Session["InvoiceBillID2"] = ds_InvoBillDetails.Tables[0].Rows[1][13].ToString();
            //    }
            //    if (ds_InvoBillDetails.Tables[0].Rows[2] != null)
            //    {
            //        txt_Desc3.Text = ds_InvoBillDetails.Tables[0].Rows[2][0].ToString();
            //        txt_Quantity3.Text = ds_InvoBillDetails.Tables[0].Rows[2][1].ToString();
            //        txt_Rate3.Text = ds_InvoBillDetails.Tables[0].Rows[2][2].ToString();
            //        txt_Amount3.Text = ds_InvoBillDetails.Tables[0].Rows[2][3].ToString();
            //        Session["InvoiceBillID3"] = ds_InvoBillDetails.Tables[0].Rows[2][13].ToString();
            //    }
            //    if (ds_InvoBillDetails.Tables[0].Rows[3] != null)
            //    {
            //        txt_Desc4.Text = ds_InvoBillDetails.Tables[0].Rows[3][0].ToString();
            //        txt_Quantity4.Text = ds_InvoBillDetails.Tables[0].Rows[3][1].ToString();
            //        txt_Rate4.Text = ds_InvoBillDetails.Tables[0].Rows[3][2].ToString();
            //        txt_Amount4.Text = ds_InvoBillDetails.Tables[0].Rows[3][3].ToString();
            //        Session["InvoiceBillID4"] = ds_InvoBillDetails.Tables[0].Rows[3][13].ToString();
            //    }

            //}
            //catch (Exception ex)
            //{
            //}
            if (ddl_Domain.SelectedValue == "SCMBizconnect")
            {
                lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
                lbl_Name.Text = "ARM SUPPLY CHAIN SOLUTIONS";
                img_Logo.Visible = false;
            }
            else if (ddl_Domain.SelectedValue == "SCMJunction")
            {
                lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
                lbl_Name.Text = "ARM SUPPLY CHAIN SOLUTIONS";
                img_Logo.Visible = false;
            }
            else if (ddl_Domain.SelectedValue == "AaumConnect")
            {
                lbl_Companyname.Text = "ARM SUPPLY CHAIN SOLUTIONS";
                lbl_Name.Text = "ARM SUPPLY CHAIN SOLUTIONS";
                img_Logo.Visible = false;
            }
            else if (ddl_Domain.SelectedValue == "SCMBizconnect1")
            {
                lbl_Companyname.Text = "AARMS VALUE CHAIN PRIVATE LIMITED";
                lbl_Name.Text = "AARMS VALUE CHAIN PRIVATE LIMITED";
                img_Logo.Visible = true;
            }
        }

    }

    public void Clearfields2()
    {
        txt_OtherRef.Text = "";
        txt_Remarks.Text = "";
        txt_BuyerOrTodetails.Text = "";
        txt_Amount1.Text = "";
        txt_Amount2.Text = "";
        txt_Amount3.Text = "";
        txt_Amount4.Text = "";
        //txt_Amount5.Text = "";
        txt_Desc1.Text = "";
        txt_Desc2.Text = "";
        txt_Desc3.Text = "";
        txt_Desc4.Text = "";
        txt_Desc4.Text = "";
        //txt_Desc5.Text = "";
        txt_Quantity1.Text = "";
        txt_Quantity2.Text = "";
        txt_Quantity3.Text = "";
        txt_Quantity4.Text = "";
        //txt_Quantity5.Text = "";
        txt_Rate1.Text = "";
        txt_Rate2.Text = "";
        txt_Rate3.Text = "";
        txt_Rate4.Text = "";
        txt_GrandTotal.Text = "";
        txt_12percent.Text = "";
        txt_2percent.Text = "";
        txt_1percent.Text = "";
        txt_Total.Text = "";
        txt_Tax12per.Text = "";
        txt_Tax2per.Text = "";
        txt_Tax1per.Text = "";
        //txt_Rate5.Text = "";
        ddl_BuyerorTo.SelectedIndex = -1;
        ddl_BuyerorTo.ClearSelection();
    }
    
    protected void btn_Reset_Click(object sender, EventArgs e)
    {
        Get_InvoiceID();
        
        ddl_particulars.Visible = true;
        lbl_Particulars.Visible = false;
        lbl_Quantity.Visible = false;
        ddl_QuantityorNooftrucks.Visible = true;
        
        //lbl_Buyer.Visible = false;
        //lbl_Domain.Visible = false;
        ddl_Domain.Visible = true;
        ddl_BuyerorTo.Visible = true;
        
        txt_Dated.Text = DateTime.Now.ToString("dd/MM/yyyy");
        ddl_Domain.SelectedIndex = 0;
        txt_OtherRef.Text = "";
        txt_Remarks.Text = "";
        ddl_BuyerorTo.SelectedIndex = 0;
        txt_BuyerOrTodetails.Text = "";
        ddl_particulars.SelectedIndex = 0;
        txt_Desc1.Text = "";
        ddl_QuantityorNooftrucks.SelectedIndex = 0;
        txt_Desc2.Text = "";
        txt_Desc3.Text = "";
        txt_Desc4.Text = "";
        txt_AmountInwords.Text="";
        GetZerosforNumericfields();
        
    }
    public void GetZerosforNumericfields()
    {
        txt_Quantity1.Text = "0";
        txt_Rate1.Text = "0";
        txt_Amount1.Text = "0";
        txt_Quantity2.Text = "0";
        txt_Rate2.Text = "0";
        txt_Amount2.Text = "0";
        txt_Quantity3.Text = "0";
        txt_Rate3.Text = "0";
        txt_Amount3.Text = "0";
        txt_Quantity4.Text = "0";
        txt_Rate4.Text = "0";
        txt_Amount4.Text = "0";
        txt_GrandTotal.Text = "0";
        txt_12percent.Text = "0";
        txt_2percent.Text = "0";
        txt_1percent.Text = "0";
        txt_Total.Text = "0";
        txt_Tax12per.Text = "0";
        txt_Tax2per.Text = "0";
        txt_Tax1per.Text = "0";
        txt_Dated.Text = DateTime.Now.ToString("dd/MM/yyyy");
            Get_InvoiceID();
    }
    
    
    public string retWord(int number)

{

if (number == 0) return "Zero";

if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

int[] num = new int[4];

int first = 0;

int u, h, t;

System.Text.StringBuilder sb = new System.Text.StringBuilder();

if (number < 0)

{

sb.Append("Minus");

number = -number;

}

string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };

string[] words = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };

string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

string[] words3 = { "Thousand ", "Lakh ", "Crore " };

num[0] = number % 1000; // units

num[1] = number / 1000;

num[2] = number / 100000;

num[1] = num[1] - 100 * num[2]; // thousands

num[3] = number / 10000000; // crores

num[2] = num[2] - 100 * num[3]; // lakhs

 

for (int i = 3; i > 0; i--)

{

if (num[i] != 0)

{

first = i;

break;

}

}

for (int i = first; i >= 0; i--)

{

if (num[i] == 0) continue;

u = num[i] % 10; // ones

t = num[i] / 10;

h = num[i] / 100; // hundreds

t = t - 10 * h; // tens

if (h > 0) sb.Append(words0[h] + "Hundred ");

if (u > 0 || t > 0)

{

if (h > 0 || i == 0) sb.Append("and ");

if (t == 0)

sb.Append(words0[u]);

else if (t == 1)

sb.Append(words[u]);

else

sb.Append(words2[t - 2] + words0[u]);

}

if (i != 0) sb.Append(words3[i - 1]);

}

return sb.ToString().TrimEnd();

}
    
    public string  Get_GrandTotal()
    {
        GTotal = txt_Total.Text;
        if (GTotal.Contains("."))
        {
            GrandTotal = Convert.ToInt32(GTotal.Remove(GTotal.Length - 3, 3));
        }
        else
        {
            GrandTotal = Convert.ToInt32(GTotal);
        }
        string Words = retWord(GrandTotal);
        return Words;
    }
    
    // protected void btn_Update_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        Assign_InvoiceDetails();
    //        res3 = obj_Class.Update_InvoiceBilling();

            

    //        if (txt_Desc1.Text != string.Empty)
    //        {
    //            obj_Class.Particulars = txt_Desc1.Text;
    //            if (txt_Quantity1.Text == string.Empty)
    //            {
    //                obj_Class.QuantityNoofTrucks = 0;
    //            }
    //            else
    //            {
    //                obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity1.Text);
    //            }
    //            txt_AmountInwords.Text="";
    //            obj_Class.Rate = Convert.ToSingle(txt_Rate1.Text);
    //            obj_Class.Amount = Convert.ToSingle(txt_Amount1.Text);
    //             obj_Class.ServiceTax = Convert.ToSingle(txt_Tax12per.Text);
    //            obj_Class.EducationCess = Convert.ToSingle(txt_Tax2per.Text);
    //            obj_Class.HigherEducationCess = Convert.ToSingle(txt_Tax1per.Text);
    //            obj_Class.Tax12percent = Convert.ToSingle(txt_12percent.Text);
    //            obj_Class .Tax2percent =Convert.ToSingle(txt_2percent .Text);
    //            obj_Class.Tax1percent = Convert.ToSingle(txt_1percent.Text);
    //            obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
    //            obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
    //            string AmountWords = Get_GrandTotal();
    //            txt_AmountInwords.Text = AmountWords;
    //            obj_Class.AmountInwords = txt_AmountInwords.Text;
    //            obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID1"]);
    //            res4 = obj_Class.Update_InvoiceBilling_Details();
    //        }
    //        if (txt_Desc2.Text != string.Empty)
    //        {
    //            obj_Class.Particulars = txt_Desc2.Text;
    //            if (txt_Quantity2.Text == string.Empty)
    //            {
    //                obj_Class.QuantityNoofTrucks = 0;
    //            }
    //            else
    //            {
    //                obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity2.Text);
    //            }
    //            obj_Class.Rate = Convert.ToSingle(txt_Rate2.Text);
    //            obj_Class.Amount = Convert.ToSingle(txt_Amount2.Text);
    //            obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
    //            obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
    //            string AmountWords = Get_GrandTotal();
    //            txt_AmountInwords.Text = AmountWords;
    //            obj_Class.AmountInwords = txt_AmountInwords.Text;
    //            obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID2"]);
    //            res4 = obj_Class.Update_InvoiceBilling_Details();
    //        }
    //        if (txt_Desc3.Text != string.Empty)
    //        {
    //            obj_Class.Particulars = txt_Desc3.Text;
    //            if (txt_Quantity3.Text == string.Empty)
    //            {
    //                obj_Class.QuantityNoofTrucks = 0;
    //            }
    //            else
    //            {
    //                obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity3.Text);
    //            }
    //            obj_Class.Rate = Convert.ToSingle(txt_Rate3.Text);
    //            obj_Class.Amount = Convert.ToSingle(txt_Amount3.Text);
    //            obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
    //            obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
    //            string AmountWords = Get_GrandTotal();
    //            txt_AmountInwords.Text = AmountWords;
    //            obj_Class.AmountInwords = txt_AmountInwords.Text;
    //            obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID3"]);
    //            res4 = obj_Class.Update_InvoiceBilling_Details();
    //        }
    //        if (txt_Desc4.Text != string.Empty)
    //        {
    //            obj_Class.Particulars = txt_Desc4.Text;
    //            if (txt_Quantity4.Text == string.Empty)
    //            {
    //                obj_Class.QuantityNoofTrucks = 0;
    //            }
    //            else
    //            {

    //                obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity4.Text);
    //            }
    //            obj_Class.Rate = Convert.ToSingle(txt_Rate4.Text);
    //            obj_Class.Amount = Convert.ToSingle(txt_Amount4.Text);
    //            obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
    //            obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
    //            string AmountWords = Get_GrandTotal();
    //            txt_AmountInwords.Text = AmountWords;
    //            obj_Class.AmountInwords = txt_AmountInwords.Text;
    //            obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID4"]);
    //            res4 = obj_Class.Update_InvoiceBilling_Details();
    //        }

           
    //        if (res3 == 1 && res4 == 1)
    //        {
    //            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice Details Inserted Successfully');</script>");
    //            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invoice Details Updated Successfully! With The BillNo is " + txt_InvoiceID.Text + "');", true);
    //            Clearfields();
    //            Get_InvoiceID();
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //    }
        
    //}
    
     public void Assign_InvoiceDetails()
    {
        obj_Class.InvoiceID = Convert.ToInt32(txt_InvoiceID.Text);
        obj_Class.OtherReferences = txt_OtherRef.Text;
        obj_Class.Domain = ddl_Domain.SelectedValue;
        obj_Class.InvoiceRemarks = txt_Remarks.Text;
        obj_Class.BuyerorTo = ddl_BuyerorTo.SelectedValue;
        obj_Class.BuyerorToDetails = txt_BuyerOrTodetails.Text;
        obj_Class.Status = 0;
    }
     public void GetZerosToAmountFields()
    {
        txt_Quantity1.Text = "0";
        txt_Rate1.Text = "0";
        txt_Amount1.Text = "0";
        txt_Quantity2.Text = "0";
        txt_Rate2.Text = "0";
        txt_Amount2.Text = "0";
        txt_Quantity3.Text = "0";
        txt_Rate3.Text = "0";
        txt_Amount3.Text = "0";
        txt_Quantity4.Text = "0";
        txt_Rate4.Text = "0";
        txt_Amount4.Text = "0";
        txt_GrandTotal.Text = "0";
        txt_12percent.Text = "0";
        txt_2percent.Text = "0";
        txt_1percent.Text = "0";
        txt_Total.Text = "0";
        txt_Tax12per.Text = "0";
        txt_Tax2per.Text = "0";
        txt_Tax1per.Text = "0";
    }

     protected void btn_Edit_Click(object sender, EventArgs e)
     {

         if (txt_Username.Text == "admin" && txt_Password.Text == "admin")
         {
             try
             {
                 Assign_InvoiceDetails();
                 res3 = obj_Class.Update_InvoiceBilling();



                 if (txt_Desc1.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc1.Text;
                     if (txt_Quantity1.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {
                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity1.Text);
                     }
                     txt_AmountInwords.Text = "";
                     obj_Class.Rate = Convert.ToSingle(txt_Rate1.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount1.Text);
                     obj_Class.ServiceTax = Convert.ToSingle(txt_Tax12per.Text);
                     obj_Class.EducationCess = Convert.ToSingle(txt_Tax2per.Text);
                     obj_Class.HigherEducationCess = Convert.ToSingle(txt_Tax1per.Text);
                     obj_Class.Tax12percent = Convert.ToSingle(txt_12percent.Text);
                     obj_Class.Tax2percent = Convert.ToSingle(txt_2percent.Text);
                     obj_Class.Tax1percent = Convert.ToSingle(txt_1percent.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text + " Olny";
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID1"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }
                 if (txt_Desc2.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc2.Text;
                     if (txt_Quantity2.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {
                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity2.Text);
                     }
                     obj_Class.Rate = Convert.ToSingle(txt_Rate2.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount2.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID2"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }
                 if (txt_Desc3.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc3.Text;
                     if (txt_Quantity3.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {
                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity3.Text);
                     }
                     obj_Class.Rate = Convert.ToSingle(txt_Rate3.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount3.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID3"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }
                 if (txt_Desc4.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc4.Text;
                     if (txt_Quantity4.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {

                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity4.Text);
                     }
                     obj_Class.Rate = Convert.ToSingle(txt_Rate4.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount4.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID4"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }


                 if (res3 == 1 && res4 == 1)
                 {
                     //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice Details Inserted Successfully');</script>");
                     this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invoice Details Updated Successfully! With The BillNo is " + txt_InvoiceID.Text + "');", true);
                     Clearfields();
                     Get_InvoiceID();
                     
                     txt_Password.Text = "";
                     txt_Username.Text = "";
                 }
             }
             catch (Exception ex)
             {
             }
         }

         else
         {
             this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invalid Username and Password');", true);
         
             txt_Password.Text = "";
             txt_Username.Text = "";
         }
     }

     protected void btn_EditCalculationst_Click(object sender, EventArgs e)
     {
         if (Convert.ToInt32(Session["Tblcount"]) == 4)
         {
             Amount1 = (Convert.ToDouble(txt_Quantity1.Text) * Convert.ToDouble(txt_Rate1.Text));
             Amount2 = (Convert.ToDouble(txt_Quantity2.Text) * Convert.ToDouble(txt_Rate2.Text));
             Amount3 = (Convert.ToDouble(txt_Quantity3.Text) * Convert.ToDouble(txt_Rate3.Text));
             Amount4 = (Convert.ToDouble(txt_Quantity4.Text) * Convert.ToDouble(txt_Rate4.Text));
             AmtTotal = (Amount1 + Amount2 + Amount3 + Amount4);
             STax = (AmtTotal) * Convert.ToDouble(txt_Tax12per.Text) / 100;
             ECess = (STax * Convert.ToDouble(txt_Tax2per.Text) / 100);
             HesCess = (STax * Convert.ToDouble(txt_Tax1per.Text) / 100);
             TotalGrand = (AmtTotal + STax + ECess + HesCess);
             txt_Amount1.Text = Amount1.ToString();
             txt_Amount2.Text = Amount2.ToString();
             txt_Amount3.Text = Amount3.ToString();
             txt_Amount4.Text = Amount4.ToString();
             txt_GrandTotal.Text = AmtTotal.ToString();
             txt_12percent.Text = STax.ToString();
             txt_2percent.Text = ECess.ToString();
             txt_1percent.Text = HesCess.ToString();
             txt_Total.Text = Math.Round(TotalGrand, 0).ToString();

             txt_AmountInwords.Text = retWord(Convert.ToInt32(TotalGrand))+" Only";
         }

         if (Convert.ToInt32(Session["Tblcount"]) == 3)
         {
             Amount1 = (Convert.ToDouble(txt_Quantity1.Text) * Convert.ToDouble(txt_Rate1.Text));
             Amount2 = (Convert.ToDouble(txt_Quantity2.Text) * Convert.ToDouble(txt_Rate2.Text));
             Amount3 = (Convert.ToDouble(txt_Quantity3.Text) * Convert.ToDouble(txt_Rate3.Text));
             AmtTotal = (Amount1 + Amount2 + Amount3);
             STax = (AmtTotal) * Convert.ToDouble(txt_Tax12per.Text) / 100;
             ECess = (STax * Convert.ToDouble(txt_Tax2per.Text) / 100);
             HesCess = (STax * Convert.ToDouble(txt_Tax1per.Text) / 100);
             TotalGrand = (AmtTotal + STax + ECess + HesCess);
             txt_Amount1.Text = Amount1.ToString();
             txt_Amount2.Text = Amount2.ToString();
             txt_Amount3.Text = Amount3.ToString();
             txt_GrandTotal.Text = AmtTotal.ToString();
             txt_12percent.Text = STax.ToString();
             txt_2percent.Text = ECess.ToString();
             txt_1percent.Text = HesCess.ToString();
             txt_Total.Text = Math.Round(TotalGrand, 0).ToString();
             txt_AmountInwords.Text = retWord(Convert.ToInt32(TotalGrand)) + " Only";
         }

         if (Convert.ToInt32(Session["Tblcount"]) == 2)
         {
             Amount1 = (Convert.ToDouble(txt_Quantity1.Text) * Convert.ToDouble(txt_Rate1.Text));
             Amount2 = (Convert.ToDouble(txt_Quantity2.Text) * Convert.ToDouble(txt_Rate2.Text));
             AmtTotal = (Amount1 + Amount2);
             STax = (AmtTotal) * Convert.ToDouble(txt_Tax12per.Text) / 100;
             ECess = (STax * Convert.ToDouble(txt_Tax2per.Text) / 100);
             HesCess = (STax * Convert.ToDouble(txt_Tax1per.Text) / 100);
             TotalGrand = (AmtTotal + STax + ECess + HesCess);
             txt_Amount1.Text = Amount1.ToString();
             txt_Amount2.Text = Amount2.ToString();
             txt_GrandTotal.Text = AmtTotal.ToString();
             txt_12percent.Text = STax.ToString();
             txt_2percent.Text = ECess.ToString();
             txt_1percent.Text = HesCess.ToString();
             txt_Total.Text = Math.Round(TotalGrand, 0).ToString();
             txt_AmountInwords.Text = retWord(Convert.ToInt32(TotalGrand)) + " Only";
         }

         if (Convert.ToInt32(Session["Tblcount"]) == 1)
         {
             Amount1 = (Convert.ToDouble(txt_Quantity1.Text) * Convert.ToDouble(txt_Rate1.Text));
             AmtTotal = (Amount1);
             STax = (AmtTotal) * Convert.ToDouble(txt_Tax12per.Text) / 100;
             ECess = (STax * Convert.ToDouble(txt_Tax2per.Text) / 100);
             HesCess = (STax * Convert.ToDouble(txt_Tax1per.Text) / 100);
             TotalGrand = (AmtTotal + STax + ECess + HesCess);
             txt_Amount1.Text = Amount1.ToString();
             txt_GrandTotal.Text = AmtTotal.ToString();
             txt_12percent.Text = STax.ToString();
             txt_2percent.Text = ECess.ToString();
             txt_1percent.Text = HesCess.ToString();
             txt_Total.Text = Math.Round (TotalGrand,0).ToString();
             txt_AmountInwords.Text = retWord(Convert.ToInt32(TotalGrand)) + " Only";
         }


     }


     protected void btn_Update_Click(object sender, EventArgs e)
     {
             try
             {
                 Assign_InvoiceDetails();
                 res3 = obj_Class.Update_InvoiceBilling();



                 if (txt_Desc1.Text != string.Empty)
                 {
                     //obj_Class.Particulars = txt_Desc1.Text;
                     if (txt_Quantity1.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {
                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity1.Text);
                     }
                     txt_AmountInwords.Text = "";
                     obj_Class.Rate = Convert.ToSingle(txt_Rate1.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount1.Text);
                     obj_Class.ServiceTax = Convert.ToSingle(txt_Tax12per.Text);
                     obj_Class.EducationCess = Convert.ToSingle(txt_Tax2per.Text);
                     obj_Class.HigherEducationCess = Convert.ToSingle(txt_Tax1per.Text);
                     obj_Class.Tax12percent = Convert.ToSingle(txt_12percent.Text);
                     obj_Class.Tax2percent = Convert.ToSingle(txt_2percent.Text);
                     obj_Class.Tax1percent = Convert.ToSingle(txt_1percent.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID1"]);
                     res4 = obj_Class.Update_InvoiceBilling_DetailsWithoutFirstParticulars();
                 }
                 if (txt_Desc2.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc2.Text;
                     if (txt_Quantity2.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {
                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity2.Text);
                     }
                     obj_Class.Rate = Convert.ToSingle(txt_Rate2.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount2.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID2"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }
                 if (txt_Desc3.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc3.Text;
                     if (txt_Quantity3.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {
                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity3.Text);
                     }
                     obj_Class.Rate = Convert.ToSingle(txt_Rate3.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount3.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID3"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }
                 if (txt_Desc4.Text != string.Empty)
                 {
                     obj_Class.Particulars = txt_Desc4.Text;
                     if (txt_Quantity4.Text == string.Empty)
                     {
                         obj_Class.QuantityNoofTrucks = 0;
                     }
                     else
                     {

                         obj_Class.QuantityNoofTrucks = Convert.ToInt32(txt_Quantity4.Text);
                     }
                     obj_Class.Rate = Convert.ToSingle(txt_Rate4.Text);
                     obj_Class.Amount = Convert.ToSingle(txt_Amount4.Text);
                     obj_Class.Total = Convert.ToSingle(txt_GrandTotal.Text);
                     obj_Class.GrandTotal = Convert.ToSingle(txt_Total.Text);
                     string AmountWords = Get_GrandTotal();
                     txt_AmountInwords.Text = AmountWords;
                     obj_Class.AmountInwords = txt_AmountInwords.Text;
                     obj_Class.InvoiceBillID = Convert.ToInt32(Session["InvoiceBillID4"]);
                     res4 = obj_Class.Update_InvoiceBilling_Details();
                 }


                 if (res3 == 1 && res4 == 1)
                 {
                     //ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Invoice Details Inserted Successfully');</script>");
                     this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invoice Details Updated Successfully! With The BillNo is " + txt_InvoiceID.Text + "');", true);
                     Clearfields();
                     Get_InvoiceID();
                    
                     txt_Password.Text = "";
                     txt_Username.Text = "";
                 }
             }
             catch (Exception ex)
             {
             }
        
     }
     protected void btn_Report_Click(object sender, EventArgs e)
     {
         Response.Redirect("~/InvoiceBillReport.aspx");
     }
     protected void btn_BillPayment_Click(object sender, EventArgs e)
     {
         Response.Redirect("~/InvoiceBillPayment.aspx");
     }
}
