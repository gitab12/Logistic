using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data ;

public partial class QuickView : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    Report obj_Class=new Report ();
    DataTable dt = new DataTable();
    DataSet  ds = new DataSet ();
    BillingModule obj_BillClass = new BillingModule();
    protected void Page_Load(object sender, EventArgs e)
    {
        ChkAuthentication();
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




    protected void btn_Search_Click(object sender, EventArgs e)
    {
        try
        {

            ds.Clear();

            grd_Shipping.DataSource = null;
            grd_Shipping.DataBind();

            grd_BillSubmission.DataSource = null;
            grd_BillSubmission.DataBind();

            grd_BillPayment.DataSource = null;
            grd_BillPayment.DataBind();

            obj_Class.CNNo = rdb_CnNo.Checked == true ? Convert.ToInt32(txt_SearchNo.Text) : 0;
            obj_Class.ConfirmNo = rdb_ConfirmNo.Checked == true ? Convert.ToInt32(txt_SearchNo.Text) : 0;
            obj_Class.BillNo = rdb_BillNo.Checked == true ? txt_SearchNo.Text : "";
            obj_BillClass.ClientID = Convert.ToInt32(Session["ClientID"].ToString());
            if (txt_SearchNo.Text != "")
            {
                int ClientID = Convert.ToInt32(Session["ClientID"].ToString());
                dt = obj_Class.Bizconnect_QuickViewSearch(ClientID);
                if (dt.Rows.Count > 0)
                {
                    TxtCNconfirmno.Text = dt.Rows[0].ItemArray[0].ToString();
                    txtCNNumber.Text = dt.Rows[0].ItemArray[1].ToString();
                    txtCNDate.Text = dt.Rows[0].ItemArray[2].ToString();
                    txtautonumber.Text = dt.Rows[0].ItemArray[3].ToString();
                    txtprojectno.Text = dt.Rows[0].ItemArray[4].ToString();
                    txtwbsno.Text = dt.Rows[0].ItemArray[5].ToString();
                    txtdescription.Text = dt.Rows[0].ItemArray[6].ToString();
                    txtCNTruckType.Text = dt.Rows[0].ItemArray[7].ToString();
                    txttransitdays.Text = dt.Rows[0].ItemArray[8].ToString();
                    txtLength.Text = dt.Rows[0].ItemArray[9].ToString();
                    txtWidth.Text = dt.Rows[0].ItemArray[10].ToString();
                    txtHeight.Text = dt.Rows[0].ItemArray[11].ToString();
                    txtTotalWeight.Text = dt.Rows[0].ItemArray[12].ToString();
                    txtBuyer.Text = dt.Rows[0].ItemArray[13].ToString();
                    txtContactPerson.Text = dt.Rows[0].ItemArray[14].ToString();
                    txtContactNo.Text = dt.Rows[0].ItemArray[15].ToString();
                    txtCNVehiclePlanned.Text = dt.Rows[0].ItemArray[16].ToString();
                    txtCNfrom.Text = dt.Rows[0].ItemArray[17].ToString();
                    txtCNTO.Text = dt.Rows[0].ItemArray[18].ToString();
                    txtApprovedPRice.Text = "0";
                    txtCNBascicFreight.Text = (Convert.ToDouble(dt.Rows[0].ItemArray[20].ToString()) * Convert.ToDouble(dt.Rows[0].ItemArray[16].ToString())).ToString();
                    txtNetPrice.Text = (Convert.ToDouble(txtApprovedPRice.Text) + Convert.ToDouble(txtCNBascicFreight.Text)).ToString();
                    txt_CliTransporter.Text = dt.Rows[0].ItemArray[21].ToString();
                    lbl_Msg.Visible = false;
                }
                else
                {
                    lbl_Msg.Visible = true;
                    lbl_Msg.Text = "No data found";
                    ClearFields();
                }

                obj_BillClass.CNNo = rdb_CnNo.Checked == true ? Convert.ToInt32(txt_SearchNo.Text) : 0;
                string Collectionnote = txt_SearchNo.Text.ToString();
                obj_BillClass.ConfirmNo = rdb_ConfirmNo.Checked == true ? Convert.ToInt32(txt_SearchNo.Text) : 0;
                string ConfirmNo = txt_SearchNo.Text.ToString();
                if (rdb_BillNo.Checked == true)
                {
                    obj_BillClass.ConfirmNo = Convert.ToInt32(TxtCNconfirmno.Text);
                }


                txtclient.Text ="";
                txtTransporter.Text="";
                txtfrom.Text  ="";
                txtto.Text ="";
                txttrucktype.Text ="";
                txtEnclosure.Text ="";
                txtcapacity.Text = "";
                txtassignedDate.Text = "";
                if (Collectionnote != "")
                {

                    ds = obj_BillClass.Bizconnect_CollectionViewDetail();
                    // assigning TripDetails
                    txtclient.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                    txtto.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                    txtEnclosure.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                    txtcapacity.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    txtassignedDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

                    //Shipping Details
                    grd_Shipping.DataSource = ds;
                    grd_Shipping.DataBind();
					
					
					string collectionotenumber = txtCNNumber.Text;

                    string[] args = { "@collectionumber" };
                    string[] argsval = { collectionotenumber };
                    DataSet demo = new DataSet();
                    demo = con.Sql_GetData("SP_Get_Bill_Status", args, argsval);
                    if (demo.Tables[0].Rows.Count > 0)
                    {

                        GridView1.DataSource = demo;
                        GridView1.DataBind();
                    }
                    else
                    {

                    }


                    //Bill Submission
                    grd_BillSubmission.DataSource = ds;
                    grd_BillSubmission.DataBind();

                    //BillPayment
                    grd_BillPayment.DataSource = ds;
                    grd_BillPayment.DataBind();
                }
                else
                {
                    ds = obj_BillClass.Bizconnect_CofirmNoViewDetail();
                    // assigning TripDetails
                    txtclient.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                    txtTransporter.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                    txtto.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                    txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                    txtEnclosure.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                    txtcapacity.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                    txtassignedDate.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();

                    //Shipping Details
                    grd_Shipping.DataSource = ds;
                    grd_Shipping.DataBind();

                    //Bill Submission
                    grd_BillSubmission.DataSource = ds;
                    grd_BillSubmission.DataBind();

                    //BillPayment
                    grd_BillPayment.DataSource = ds;
                    grd_BillPayment.DataBind();
                }
                
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Enter number to search');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void ClearFields()
    {
        TxtCNconfirmno.Text = "";
        txtCNNumber.Text = "";
        txtCNDate.Text = "";
        txtautonumber.Text = "";
        txtprojectno.Text = "";
        txtwbsno.Text = "";
        txtdescription.Text = "";
        txttransitdays.Text = "";
        txtfrom.Text = "";
        txtto.Text = "";
        txtCNTruckType.Text = "";
        txtCNVehiclePlanned.Text = "";
        txtLength.Text = "";
        txtWidth.Text = "";
        txtHeight.Text = "";
        txtTotalWeight.Text = "";
        txtBuyer.Text = "";
        txtContactPerson.Text = "";
        txtContactNo.Text = "";
        txt_CliTransporter.Text = "";
        txtCNBascicFreight.Text = "";
        txtApprovedPRice.Text = "";
        txtNetPrice.Text = "";
        txtCNLoadingCharges.Text = "";
        txtCNUNLoadingCharges.Text = "";
        txtCNLoadingDetention.Text = "";
        txtCNunloadingdetention.Text = "";
        txtCNOctroid.Text = "";
        txtCNDimensionDiff.Text = "";
        txtCNOtherClaims.Text = "";
        txtCNInsurance.Text = "";
        txtCNDamages.Text = "";
        txtCNShortages.Text = "";
        txtCNOtherCharges.Text = "";
        txtclient.Text = "";
        txtTransporter.Text = "";
        txtassignedDate.Text = "";
        txtCNfrom.Text = "";
        txtCNTO.Text = "";
        txtcapacity.Text = "";
        txttrucktype.Text = "";
        txtEnclosure.Text = "";
        
    }
 
 
}