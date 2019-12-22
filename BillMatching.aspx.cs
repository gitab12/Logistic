using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Configuration;
using System.IO;

public partial class BillMatching : System.Web.UI.Page
{

    string obj_Authenticated, obj_emailid;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    BillingModule obj_class = new BillingModule();
    DataTable dt = new DataTable();
    DataTable dt_BillNo = new DataTable();
    int resp,resp1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
          if(Session["ClientID"].ToString()=="1135")
          {
            //LoadBillNumber();
              LoadProjectName();
            }
            else
            {
              Response.Redirect("BillMatching1.aspx");
            }

          ChkAuthentication();
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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }





    public void LoadProjectName()
    {
        dt = obj_class.Get_BizconnectProjectNoForBillMatching(Convert.ToInt32(Session["ClientID"].ToString()));
        ddl_ProjectName.DataSource = dt;
        ddl_ProjectName.DataTextField = "ProjectName";
        ddl_ProjectName.DataValueField = "ProjectName";
        ddl_ProjectName.DataBind();
        ddl_ProjectName.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    public void LoadBillNumber()
    {
        DataSet ds = new DataSet();
        ds = obj_class.Get_BillNoForClient(Convert.ToInt32(Session["ClientID"].ToString()));
        ddlBillNo .DataSource = ds.Tables["confirmno"];
        ddlBillNo.DataTextField = "BillNo";
        ddlBillNo.DataValueField = "BillSubmissionNo";
        ddlBillNo.DataBind();
        ddlBillNo.Items.Insert(0, new ListItem("-Select-", "0"));
    }
    protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
           
            DataSet ds = new DataSet();


            ds = obj_class.Get_BillDetailsForBillMatching(ddl_ProjectNo .SelectedValue,ddlBillNo.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtto.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtLRNo.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();

                

                txtRCDate.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                txtdate.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                txtLRDate.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
                //image
                Session["ImageID"] = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                BillImage.ImageUrl = "BillImage.ashx?ImageID=" + ds.Tables[0].Rows[0].ItemArray[9].ToString();
                lblBillID.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                txtaddress.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
                txtRemarks.Text = ds.Tables[0].Rows[0].ItemArray[11].ToString();
                txtConfirmno.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();

                txtbasicfreight.Text = ds.Tables[0].Rows[0].ItemArray[13].ToString();


                txtloadingdetention.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                txtunloadingdetention.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                txtLoadingCharges.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                txtunloadingCharges.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
                txtoctroid.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                txtDimensionDiff.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
                txtOtherClaims.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
                //Less
                txtinsurance.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                txtDamages.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
                txtshortages.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
                txtOtherCharges.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
                txtbillvalue.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

                txtCNLoadingDetention.Text = ds.Tables[0].Rows[0].ItemArray[26].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[26].ToString();
                txtCNunloadingdetention.Text = ds.Tables[0].Rows[0].ItemArray[27].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[27].ToString(); ;
                txtCNLoadingCharges.Text = ds.Tables[0].Rows[0].ItemArray[28].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[28].ToString(); ;
                txtCNUNLoadingCharges.Text = ds.Tables[0].Rows[0].ItemArray[29].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[29].ToString(); ;
                txtCNOctroid.Text = ds.Tables[0].Rows[0].ItemArray[30].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[30].ToString(); ;
                txtCNDimensionDiff.Text = ds.Tables[0].Rows[0].ItemArray[31].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[31].ToString(); ;
                txtCNOtherClaims.Text = ds.Tables[0].Rows[0].ItemArray[32].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[32].ToString(); ;
                txtCNInsurance.Text = ds.Tables[0].Rows[0].ItemArray[33].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[33].ToString(); ;
                txtCNDamages.Text = ds.Tables[0].Rows[0].ItemArray[34].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[34].ToString(); ;
                txtCNShortages.Text = ds.Tables[0].Rows[0].ItemArray[35].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[35].ToString(); ;
                txtCNOtherCharges.Text = ds.Tables[0].Rows[0].ItemArray[36].ToString() == "" ? "0" : ds.Tables[0].Rows[0].ItemArray[36].ToString(); ;

                txt_CliTransporter.Text = ds.Tables[0].Rows[0].ItemArray[37].ToString();

            }
              DataSet ds1 = new DataSet();
              ds1 = obj_class.Bizconnect_GetCollectionNoteDetails(Convert.ToInt32(txtConfirmno.Text));
            if (ds1.Tables[0].Rows.Count > 0)
            {
                TxtCNconfirmno.Text = ds1.Tables[0].Rows[0].ItemArray[0].ToString();
                txtCNNumber.Text = ds1.Tables[0].Rows[0].ItemArray[1].ToString();
                txtCNDate.Text = ds1.Tables[0].Rows[0].ItemArray[2].ToString();
                txtautonumber.Text = ds1.Tables[0].Rows[0].ItemArray[3].ToString();
                txtprojectno.Text = ds1.Tables[0].Rows[0].ItemArray[4].ToString();
                txtwbsno.Text = ds1.Tables[0].Rows[0].ItemArray[5].ToString();
                txtdescription.Text = ds1.Tables[0].Rows[0].ItemArray[6].ToString();
                txtCNTruckType.Text = ds1.Tables[0].Rows[0].ItemArray[7].ToString();
                txttransitdays.Text = ds1.Tables[0].Rows[0].ItemArray[8].ToString();
                txtLength.Text = ds1.Tables[0].Rows[0].ItemArray[9].ToString();
                txtWidth.Text = ds1.Tables[0].Rows[0].ItemArray[10].ToString();
                txtHeight.Text = ds1.Tables[0].Rows[0].ItemArray[11].ToString();
                txtTotalWeight.Text = ds1.Tables[0].Rows[0].ItemArray[12].ToString();
                txtBuyer.Text = ds1.Tables[0].Rows[0].ItemArray[13].ToString();
                txtContactPerson.Text = ds1.Tables[0].Rows[0].ItemArray[14].ToString();
                txtContactNo.Text = ds1.Tables[0].Rows[0].ItemArray[15].ToString();
                txtCNVehiclePlanned.Text = ds1.Tables[0].Rows[0].ItemArray[16].ToString();
                txtCNfrom.Text = ds1.Tables[0].Rows[0].ItemArray[17].ToString();
                txtCNTO.Text = ds1.Tables[0].Rows[0].ItemArray[18].ToString();
                txtApprovedPRice.Text = "0";
                txtCNBascicFreight.Text =Math .Round ((Convert.ToDouble( ds1.Tables[0].Rows[0].ItemArray[20].ToString())*Convert.ToDouble( ds1.Tables[0].Rows[0].ItemArray[16].ToString())),0).ToString ();
                txtNetPrice.Text = (Convert.ToDouble(txtApprovedPRice.Text) + Convert.ToDouble(txtCNBascicFreight.Text)).ToString();
                //txtCNBillValue.Text = txtNetPrice.Text;
                 double netvalue= (Convert.ToDouble(txtNetPrice.Text ))+ (Convert.ToDouble(txtCNLoadingDetention.Text)) + (Convert.ToDouble(txtCNunloadingdetention.Text)) + (Convert.ToDouble(txtCNLoadingCharges.Text)) + (Convert.ToDouble(txtCNUNLoadingCharges.Text)) + (Convert.ToDouble(txtCNOctroid.Text)) + (Convert.ToDouble(txtCNDimensionDiff.Text)) + (Convert.ToDouble(txtCNOtherClaims.Text));
                netvalue =netvalue -(Convert.ToDouble(txtCNInsurance.Text))+Convert.ToDouble(txtCNDamages .Text)+Convert.ToDouble(txtCNShortages.Text)+Convert.ToDouble(txtCNOtherCharges.Text);
               // txtCNBillValue .Text =(Convert.ToDouble(txtCNBillValue .Text)-(Convert.ToDouble(txtCNInsurance.Text))+Convert.ToDouble(txtCNDamages .Text))+Convert.ToDouble(txtCNShortages.Text)+Convert.ToDouble(txtCNOtherCharges.Text).ToString ();
                txtCNBillValue.Text = netvalue.ToString();
                txt_Transporter.Text = ds1.Tables[0].Rows[0].ItemArray[21].ToString();

            }

            if (ds.Tables[0].Rows[0][38].ToString() == "")
            {
                txt_ActLength.Text = txtLength.Text;
                txt_ActWidth.Text = txtWidth.Text;
                txt_ActHeight.Text = txtHeight.Text;
                txt_ActTotWeight.Text = txtTotalWeight.Text;
            }
            else
            {
                txt_ActLength.Text = ds.Tables[0].Rows[0][38].ToString();
                txt_ActWidth.Text = ds.Tables[0].Rows[0][39].ToString();
                txt_ActHeight.Text = ds.Tables[0].Rows[0][40].ToString();
                txt_ActTotWeight.Text = ds.Tables[0].Rows[0][41].ToString();
            }

            DisableSaveButton();
        }
        catch (Exception ex)
        {
        }
    }
        protected void LinkHistory_Click(object sender, EventArgs e)
    {
        OpenWindow();
    }
    public void OpenWindow()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('ViewDetails.aspx?CID="+ TxtCNconfirmno.Text  +"', 'mynewwin', 'width=1050,height=850,scrollbars=yes,toolbar=1')</script>");

    }

    public void DisableSaveButton()
    {
        try
        {
            dt_BillNo.Clear();
            dt_BillNo = obj_class.Bizconnect_CheckBilldetailsExistsorNot(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(txtConfirmno.Text));
            if (dt_BillNo.Rows.Count > 0)
            {
                btn_Save.Enabled = false;
            }
            else
            {
                btn_Save.Enabled = true;
            }
        }
        catch (Exception ex)
        {

        }
    }
    
    protected void ButValidated_Click(object sender, EventArgs e)
    {
        try
        {
           
            if (ddlBillNo.SelectedItem.Text != "-Select-")
            {
                Assigning_BillMatchingDetails();
                obj_class.BillMatchFlag = 1;
                resp = obj_class.Bizconnect_InsertBillValidation();
                if (resp == 1)
                {
                    resp1 = obj_class.Update_scmjunction_BillSubmissionStaus(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(txtConfirmno.Text), ddlBillNo.SelectedItem.Text, 1);
                }
                if (resp == 1 && resp1 == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Validated Successfully');</script>");
                    ClearFields();
                    txtCNLoadingDetention.Text = "";
                    txtCNunloadingdetention.Text = "";
                    txtCNLoadingCharges.Text = "";
                    txtCNUNLoadingCharges.Text = "";
                    txtCNOctroid.Text = "";
                    txtCNDimensionDiff.Text = "";
                    txtCNOtherClaims.Text = "";
                    txtCNInsurance.Text = "";
                    txtCNDamages.Text = "";
                    txtCNShortages.Text = "";
                    txtCNOtherCharges.Text = "";

                    txt_ActLength.Text="";
                    txt_ActWidth.Text="";
                    txt_ActHeight.Text="";
                    txt_ActTotWeight.Text = "";

                }
                DisableSaveButton();
                txtConfirmno.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select BillNo for Billmatching');</script>");
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void Assigning_BillMatchingDetails ()
    {
        obj_class.ClientID = Convert.ToInt32(Session["ClientID"].ToString());
        obj_class.ConfirmNo = Convert.ToInt32(txtConfirmno.Text);
        obj_class.BillNo = ddlBillNo.SelectedItem.Text;
        obj_class.BillDate = Convert.ToDateTime(txtdate.Text);
        obj_class.LRNumber = txtLRNo.Text;
        obj_class.LRDate = Convert.ToDateTime(txtLRDate.Text);
        obj_class.VehicleNo = txtRCDate.Text;
        obj_class.FromLocation = txtfrom.Text;
        obj_class.ToLocation = txtto.Text;
        obj_class.SubmissionAddress = txtaddress.Text;
        obj_class.TransporterPrice = Convert.ToSingle(txtbasicfreight.Text);
        obj_class.ClientPrice = Convert.ToSingle(txtCNBascicFreight.Text);
        obj_class.TransLoadingDetentionCharges = Convert.ToSingle(txtloadingdetention.Text);
        obj_class.ClientLoadingDetentionCharges = Convert.ToSingle(txtCNLoadingDetention.Text);

        obj_class.TransUnLoadingDetentionCharges = Convert.ToSingle(txtunloadingdetention.Text);
        obj_class.ClientUnLoadingDetentionCharges = Convert.ToSingle(txtCNunloadingdetention.Text);
        obj_class.TransLoadingCharges = Convert.ToSingle(txtLoadingCharges.Text);
        obj_class.ClientLoadingCharges = Convert.ToSingle(txtCNLoadingCharges.Text);
        obj_class.TransUnLoadingCharges = Convert.ToSingle(txtunloadingCharges.Text);
        obj_class.ClientUnLoadingCharges = Convert.ToSingle(txtCNUNLoadingCharges.Text);
        obj_class.TransoctroiCharges = Convert.ToSingle(txtoctroid.Text);
        obj_class.ClientoctroiCharges = Convert.ToSingle(txtCNOctroid.Text);
        obj_class.TransoDimentionDiff = Convert.ToSingle(txtDimensionDiff.Text);
        obj_class.ClientDimentionDiff = Convert.ToSingle(txtCNDimensionDiff.Text);

        obj_class.TransOtherClaimsCharges = Convert.ToSingle(txtOtherClaims.Text);
        obj_class.ClientOtherClaimsCharges = Convert.ToSingle(txtCNOtherClaims.Text);
        obj_class.TransInsurance = Convert.ToSingle(txtinsurance.Text);
        obj_class.ClientInsurance = Convert.ToSingle(txtCNInsurance.Text);
        obj_class.TransDamages = Convert.ToSingle(txtDamages.Text);
        obj_class.ClientDamages = Convert.ToSingle(txtCNDamages.Text);
        obj_class.TransShortages = Convert.ToSingle(txtshortages.Text);
        obj_class.ClientShortages = Convert.ToSingle(txtCNShortages.Text);
        obj_class.TransOtherCharges = Convert.ToSingle(txtOtherCharges.Text);
        obj_class.ClientOtherCharges = Convert.ToSingle(txtCNOtherCharges.Text);
        obj_class.TransNetValue = Convert.ToSingle(txtbillvalue.Text);
        obj_class.ClientNetValue = Convert.ToSingle(txtCNBillValue.Text);
        obj_class.AARMSRemarks = txtaarmsRemarks.Text;
        obj_class.CheckedBy = txtcheckedby.Text;
        obj_class.IncreasePrice = Convert.ToSingle(txtApprovedPRice.Text);

        obj_class.Length = Convert.ToSingle(txt_ActLength.Text);
        obj_class.Width = Convert.ToSingle(txt_ActWidth.Text);
        obj_class.Height = Convert.ToSingle(txt_ActHeight.Text);
        obj_class.TotalWeight = Convert.ToSingle(txt_ActTotWeight.Text);
    }

    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        string clientid = Session["ClientID"].ToString();
        string projectname = ddl_ProjectName.SelectedItem.Text;
        string projectno = ddl_ProjectNo.SelectedItem.Text;

        string[] args = { "@ClientID", "@ProjectName", "@ProjectNo" };
        string[] argsval = { clientid, "%" + projectname + "%", projectno };
        DataSet dt_BillNo = new DataSet();
        dt_BillNo = con.Sql_GetData("Bizconnect_GetBillNoByProjecNameAndNo_New", args, argsval);
        if (dt_BillNo.Tables[0].Rows.Count > 0)
        {
            //dt_BillNo = obj_class.Bizconnect_GetBillNoByProjecNameAndNo(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ProjectName.SelectedItem.Text, ddl_ProjectNo.SelectedItem.Text);
            ddlBillNo.DataSource = dt_BillNo;
            ddlBillNo.DataTextField = "BillNo";
            ddlBillNo.DataValueField = "BillSubmissionNo";
            ddlBillNo.DataBind();
            ddlBillNo.Items.Insert(0, new ListItem("-Select-", "0"));
            ClearFields();
        }
    }
    protected void ddl_ProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt.Clear();
        dt = obj_class.Get_BizconnectProjectNoForBillMatching(ddl_ProjectName.SelectedItem.Text);
        ddl_ProjectNo.DataSource = dt;
        ddl_ProjectNo.DataTextField = "ProjectNo";
        ddl_ProjectNo.DataValueField = "ProjectNo";
        ddl_ProjectNo.DataBind();
        ddl_ProjectNo.Items.Insert(0, new ListItem("-Select-", "0"));
        ClearFields();
    }

    public void ClearFields()
    {
        txtaarmsRemarks.Text = "";
        txtaddress.Text = "";
        txtApprovedPRice.Text = "";
        txtautonumber.Text = "";
        txtbasicfreight.Text = "";
        txtbillvalue.Text = "";
        txtBuyer.Text = "";
        txtcheckedby.Text = "";
        txtCNBascicFreight.Text = "";
        txtCNBillValue.Text = "";
        TxtCNconfirmno.Text = "";
        txtCNDamages.Text = "";
        txtCNDate.Text = "";
        txtCNDimensionDiff.Text = "";
        txtCNfrom.Text = "";
        txtCNInsurance.Text = "";
        txtCNLoadingCharges.Text = "";
        txtCNLoadingDetention.Text = "";
        txtCNNumber.Text = "";
        txtCNOctroid.Text = "";
        txtCNOtherCharges.Text = "";
        txtCNOtherClaims.Text = "";
        txtCNShortages.Text = "";
        txtCNTO.Text = "";
        txtCNTruckType.Text = "";
        txtCNUNLoadingCharges.Text = "";
        txtCNunloadingdetention.Text = "";
        txtCNVehiclePlanned.Text = "";
        //txtConfirmno.Text = "";
        txtContactNo.Text = "";
        txtContactPerson.Text = "";
        txtDamages.Text = "";
        txtdate.Text = "";
        txtdescription.Text = "";
        txtDimensionDiff.Text = "";
        txtfrom .Text = "";
        txtHeight .Text = "";
        txtinsurance .Text = "";
        txtLength .Text = "";
        txtLoadingCharges .Text = "";
        txtloadingdetention .Text = "";
        txtLRDate .Text = "";
        txtLRNo .Text = "";
        txtNetPrice .Text = "";
        txtTotalWeight.Text = "";
        txttransitdays.Text = "";
        txttrucktype.Text = "";
        txtwbsno.Text = "";
        txtWidth.Text = "";
        txtprojectno.Text = "";
        txtRCDate.Text = "";
        txtto .Text= "";
        txtloadingdetention.Text = "";
        txtLoadingCharges.Text = "";
        txtoctroid.Text = "";
        txtshortages.Text = "";
        txtOtherCharges.Text = "";
        txtOtherClaims.Text = "";
        txtRemarks.Text = "";
        txtunloadingdetention.Text = "";
        txtunloadingCharges.Text = "";
    }
    protected void btn_Save_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlBillNo.SelectedItem .Text != "-Select-")
            {
                Assigning_BillMatchingDetails();
                obj_class.BillMatchFlag = 0;
                int resp = obj_class.Bizconnect_InsertBillValidation();
                if (resp == 1)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Saved Successfully');</script>");
                    ClearFields();
                    txtCNLoadingDetention.Text = "";
                    txtCNunloadingdetention.Text = "";
                    txtCNLoadingCharges.Text = "";
                    txtCNUNLoadingCharges.Text = "";
                    txtCNOctroid.Text = "";
                    txtCNDimensionDiff.Text = "";
                    txtCNOtherClaims.Text = "";
                    txtCNInsurance.Text = "";
                    txtCNDamages.Text = "";
                    txtCNShortages.Text = "";
                    txtCNOtherCharges.Text = "";

                    txt_ActLength.Text = "";
                    txt_ActWidth.Text = "";
                    txt_ActHeight.Text = "";
                    txt_ActTotWeight.Text = "";
                }
                DisableSaveButton();
                txtConfirmno.Text = "";
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please Select BillNo for Billmatching');</script>");
            }

        }
        catch (Exception ex)
        {

        }
    }
}
