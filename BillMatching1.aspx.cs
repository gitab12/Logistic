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


public partial class BillMatching1 : System.Web.UI.Page
{

    string obj_Authenticated, obj_emailid;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;


    BillingModule obj_class = new BillingModule();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string cidd = Session["ClientID"].ToString();
            if (cidd == null || cidd == String.Empty)
            {
                lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Please Login again!");
            }
            else
            {
                LoadBillNumber();
                ChkAuthentication();
            }
            
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




    public void LoadBillNumber()
    {
        DataSet ds = new DataSet();

        string cid = Session["ClientID"].ToString();

        ds = obj_class.Get_BillNoForClient(Convert.ToInt32(Session["ClientID"].ToString()));
        ddlBillNo.DataSource = ds.Tables["confirmno"];
        ddlBillNo.DataTextField = "BillNo";
        ddlBillNo.DataValueField = "BillNo";
        ddlBillNo.DataBind();
        ddlBillNo.Items.Insert(0, new ListItem("-Select-", "0"));
    }


    protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
     try
        {
            DataSet ds = new DataSet();

            string cid = Session["ClientID"].ToString();           
            if (cid == null || cid == String.Empty)
            {
                lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Please Login again!");
            }

            ds = obj_class.Get_BillDetailsForBillMatching_new(ddlBillNo.SelectedItem.Value);
           
            //ds = obj_class.Get_BillDetailsForBillMatching((ddlBillNo.SelectedValue),ddlBillNo .SelectedValue );
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Transporter Bill
                txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtto.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtLRNo.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();

                chkbl_MultipleLR.DataSource = ds;
                chkbl_MultipleLR.DataBind();
                chkbl_MultipleLR.DataTextField = "LRNumber";
                chkbl_MultipleLR.DataValueField = "LRNumber";
                chkbl_MultipleLR.SelectedValue = ds.Tables[0].Rows[0][3].ToString();

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


                //Client Bill
               txtBillNoc.Text=ds.Tables[0].Rows[0].ItemArray[6].ToString();
                txtfromc.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txttoc.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txttrucktypec.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtLRNoc.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                txtRCDatec.Text = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                txtdatec.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
txtLRDatec.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
txtConfirmnoc.Text = ds.Tables[0].Rows[0].ItemArray[12].ToString();
                //txtbasicfreightc.Text = ds.Tables[0].Rows[0].ItemArray[25].ToString();
txtbasicfreightc.Text = ds.Tables[0].Rows[0]["BasicFreight"].ToString();

                txtloadingdetentionc.Text = ds.Tables[0].Rows[0].ItemArray[14].ToString();
                txtunloadingdetentionc.Text = ds.Tables[0].Rows[0].ItemArray[15].ToString();
                txtLoadingChargesc.Text = ds.Tables[0].Rows[0].ItemArray[16].ToString();
                txtunloadingChargesc.Text = ds.Tables[0].Rows[0].ItemArray[17].ToString();
                txtoctroidc.Text = ds.Tables[0].Rows[0].ItemArray[18].ToString();
                txtDimensionDiffc.Text = ds.Tables[0].Rows[0].ItemArray[19].ToString();
                txtOtherClaimsc.Text = ds.Tables[0].Rows[0].ItemArray[20].ToString();
                //Less
                txtinsurancec.Text = ds.Tables[0].Rows[0].ItemArray[21].ToString();
                txtDamagesc.Text = ds.Tables[0].Rows[0].ItemArray[22].ToString();
                txtshortagesc.Text = ds.Tables[0].Rows[0].ItemArray[23].ToString();
                txtOtherChargesc.Text = ds.Tables[0].Rows[0].ItemArray[24].ToString();
                txtbillvaluec.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();

            }
        }
 catch (Exception ex)
 {
     lbl_msg.Text = Resources.Resource.alert_error.Replace("{@message}", "Please Login again!");
 }

    }




    protected void LinkHistory_Click(object sender, EventArgs e)
    {
        OpenWindow();
    }
    public void OpenWindow()
    {
      //  ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('ViewDetails.aspx?CID=" + TxtCNconfirmno.Text + "', 'mynewwin', 'width=1050,height=850,scrollbars=yes,toolbar=1')</script>");

    }
    protected void ButValidated_Click(object sender, EventArgs e)
    {
        obj_class.ClientID = Convert.ToInt32(Session["ClientID"].ToString());
        obj_class.ConfirmNo = Convert.ToInt32(txtConfirmno.Text);
        obj_class.BillNo = ddlBillNo.SelectedItem.Text;
        obj_class.BillDate = Convert.ToDateTime(txtdate.Text);
        obj_class.LRNumber = txtLRNo.Text;
        obj_class.LRDate =Convert.ToDateTime(txtLRDate.Text);
        obj_class.VehicleNo =txtRCDate.Text;
        obj_class.FromLocation =txtfrom.Text;
        obj_class.ToLocation =txtto.Text;
        obj_class.SubmissionAddress =txtaddress.Text;
        obj_class.TransporterPrice =Convert.ToSingle(txtbasicfreight.Text);
        obj_class.ClientPrice = Convert.ToInt32(txtbasicfreightc.Text);//Convert.ToSingle(txtbasicfreightc.Text);
        obj_class.TransLoadingDetentionCharges = Convert.ToSingle(txtloadingdetention.Text);
        obj_class.ClientLoadingDetentionCharges = Convert.ToSingle(txtloadingdetentionc.Text);

        obj_class.TransUnLoadingDetentionCharges = Convert.ToSingle(txtunloadingdetention.Text);
        obj_class.ClientUnLoadingDetentionCharges = Convert.ToSingle(txtunloadingdetentionc.Text);
        obj_class.TransLoadingCharges = Convert.ToSingle(txtLoadingCharges.Text);
        obj_class.ClientLoadingCharges = Convert.ToSingle(txtLoadingChargesc.Text);
        obj_class.TransUnLoadingCharges = Convert.ToSingle(txtunloadingCharges.Text);
        obj_class.ClientUnLoadingCharges = Convert.ToSingle(txtunloadingChargesc.Text);
        obj_class.TransoctroiCharges = Convert.ToSingle(txtoctroid.Text);
        obj_class.ClientoctroiCharges = Convert.ToSingle(txtoctroidc.Text);
        obj_class.TransoDimentionDiff = Convert.ToSingle(txtDimensionDiff.Text);
        obj_class.ClientDimentionDiff = Convert.ToSingle(txtDimensionDiffc.Text);

        obj_class.TransOtherClaimsCharges = Convert.ToSingle(txtOtherClaims.Text);
        obj_class.ClientOtherClaimsCharges = Convert.ToSingle(txtOtherClaimsc.Text);
        obj_class.TransInsurance = Convert.ToSingle(txtinsurance.Text);
        obj_class.ClientInsurance = Convert.ToSingle(txtinsurancec.Text);
        obj_class.TransDamages = Convert.ToSingle(txtDamages.Text);
        obj_class.ClientDamages = Convert.ToSingle(txtDamagesc.Text);
        obj_class.TransShortages = Convert.ToSingle(txtshortages.Text);
        obj_class.ClientShortages = Convert.ToSingle(txtshortagesc.Text);
        obj_class.TransOtherCharges = Convert.ToSingle(txtOtherCharges.Text);
        obj_class.ClientOtherCharges = Convert.ToSingle(txtOtherChargesc.Text);
        obj_class.TransNetValue = Convert.ToSingle(txtbillvalue.Text);
        obj_class.ClientNetValue = Convert.ToSingle(txtbillvaluec.Text);
        obj_class.AARMSRemarks = txtaarmsRemarks.Text;
        obj_class.CheckedBy = txtcheckedby.Text;
        obj_class.IncreasePrice = Convert.ToSingle(0);

        int resp = obj_class.Bizconnect_InsertBillValidation();
        if (resp == 1)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Validated Successfully');</script>");
        }
    }
}
