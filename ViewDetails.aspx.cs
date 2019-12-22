using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
public partial class ViewDetails : System.Web.UI.Page
{
    BillingModule obj_class = new BillingModule();
    DataSet ds;
     string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    protected void Page_Load(object sender, EventArgs e)
    {
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
       {
         if (!IsPostBack)
        {
         ChkAuthentication();
         if (Request.QueryString.Count > 0)
         {
             try
             {
                 ds = new DataSet();
                 ds = obj_class.Bizconnect_ViewDetailReport(Convert.ToInt32(Request.QueryString["CID"].ToString()), Convert.ToInt32(Session["ClientID"].ToString()));
                 //TripDetails
                 // txtCofirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                 txtclient.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                 txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                 txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                 txtto.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                 txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                 txtEnclosure.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                 txtcapacity.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                 txtassignedDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                 //Shipping Details
                 lblshippingConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                 txtCofirmDate.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
                 txttravelDate.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                 txtVehicleNo.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                 txtDriverName.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                 txtLoadingStatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                 txtLoadingtime.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                 txtTripTime.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                 txtLRNumber.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
                 lbldeliverydate.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                 lblReceiveddate.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
                 //Bill Submission
                 lblBillSubConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                 txtSbillNo.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                 txtSBillValue.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
                 txtSBillDate.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
                 txtSRemarks.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();

                 //BillPayment
                 lblBPConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
                 txtbpBillno.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
                 txtBillPaid.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
                 txtPaymentdate.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
                 txtBPModeofpayment.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
                 txtBPChequeno.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
                 txtBPChequeDate.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
                 txtBPRemarks.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();

             }
             catch
             {
             }
         }
         else
         {
             LoadConfirmNo();
         }
    }
    }
   
      else
       {
          Response.Redirect("Index.html");
       } 
     }
    
 public void LoadConfirmNo()
    {
        DataSet ds = new DataSet();
        ds = obj_class.LoadConfirmNo(Convert.ToInt32(Session["ClientID"].ToString()));
        ddlConfirmNo.DataTextField = "AcceptanceID";
        ddlConfirmNo.DataValueField = "AcceptanceID";
        ddlConfirmNo.DataSource=ds;
        ddlConfirmNo.DataBind();
        ddlConfirmNo.Items.Insert(0, new ListItem("--Confirm No.--", "0"));
     }
    
     protected void ButShow_Click(object sender, EventArgs e)
    {
        try
        {
            ds = new DataSet();
            ds = obj_class.Bizconnect_ViewDetailReport(Convert.ToInt32(ddlConfirmNo.SelectedValue), Convert.ToInt32(Session["ClientID"].ToString()));
            //TripDetails
           // txtCofirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtclient.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtto.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            txtEnclosure.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            txtcapacity.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txtassignedDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            //Shipping Details
            lblshippingConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtCofirmDate.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            txttravelDate.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            txtVehicleNo.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            txtDriverName.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            txtLoadingStatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            txtLoadingtime.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            txtTripTime.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            txtLRNumber.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
            lbldeliverydate.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            lblReceiveddate.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
            //Bill Submission
            lblBillSubConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtSbillNo.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
            txtSBillValue.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
            txtSBillDate.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
            txtSRemarks.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();

            
            //BillPayment
            lblBPConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
            txtbpBillno.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
            txtBillPaid.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
            txtPaymentdate.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
            txtBPModeofpayment.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
            txtBPChequeno.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
            txtBPChequeDate.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
            txtBPRemarks.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();
        }
        catch
        {
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
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        // obj_Navi.Visible = true;
        //obj_Navihome.Visible = false;
    }
    
     protected void ddlConfirmNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ds = new DataSet();
            ds = obj_class.Bizconnect_ViewDetailReport(Convert.ToInt32(ddlConfirmNo.SelectedValue), Convert.ToInt32(Session["ClientID"].ToString()));
            txtclient.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
            txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
            txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
            txtto.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
            txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
            txtEnclosure.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
            txtcapacity.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
            txtassignedDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
            Session["ImageID"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
             TruckImage.ImageUrl = "ImageHandler.ashx?ImageID=" + ds.Tables[0].Rows[0].ItemArray[0].ToString();
            //Shipping Details
            lblshippingConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtCofirmDate.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();
            txttravelDate.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
            txtVehicleNo.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
            txtDriverName.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            txtLoadingStatus.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
            txtLoadingtime.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
            txtTripTime.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
            txtLRNumber.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
            lbldeliverydate.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
            lblReceiveddate.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
            //Bill Submission
            lblBillSubConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            txtSbillNo.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
            txtSBillValue.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
            txtSBillDate.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
            txtSRemarks.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();

            //BillPayment
            lblBPConfirmNo.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
            txtbpBillno.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString();
            txtBillPaid.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString();
            txtPaymentdate.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString();
            txtBPModeofpayment.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString();
            txtBPChequeno.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString();
            txtBPChequeDate.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString();
            txtBPRemarks.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString();

        }
        catch (Exception ex)
        {
        }
    }
    
}
