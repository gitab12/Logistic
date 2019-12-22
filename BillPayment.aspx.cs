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
public partial class BillPayment : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    String obj_ImageID = "0";
    BillingModule obj_class = new BillingModule();
    DataTable dt = new DataTable();
    DataTable dt_BillNo = new DataTable();
    int resp = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Authentication Section

            LoadProjectName();
            ChkAuthentication();
            LoadConfirmno();

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
    public void LoadConfirmno()
    {
        //DataSet ds = new DataSet();
        //ds = obj_class.Get_ConfirmNumber(Convert.ToInt32 ( Session["ClientID"] .ToString()));
        //ddlCofirm.DataSource = ds.Tables["Confirmno"];
        //ddlCofirm.DataTextField = "CofirmNo";
        //ddlCofirm.DataValueField = "CofirmNo";
        //ddlCofirm.DataBind();
        //ddlCofirm.Items.Insert(0, new ListItem("-Select-", "0"));
    }


    protected void ddlCofirm_SelectedIndexChanged(object sender, EventArgs e)
    {
//        try
//        {
//            DataSet ds = new DataSet();
//            ds = obj_class.Get_BillDetailsForPayment(Convert.ToInt32(ddlCofirm.SelectedValue));
//            if (ds.Tables[0].Rows.Count > 0)
//            {
//                txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
//                txtto.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
//                txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
//                txtLRNo.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
//                txtbillvalue.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
//                txtbillno.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
//                inputField.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();
                
//                Session["ImageID"] = ds.Tables[0].Rows[0].ItemArray[9].ToString();
////image
//                BillImage.ImageUrl = "BillImage.ashx?ImageID=" + ds.Tables[0].Rows[0].ItemArray[9].ToString();
//                lblBillID .Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
//            }

//        }
//        catch (Exception ex)
//        {
//        }
    }
    protected void But_Submit_Click(object sender, EventArgs e)
    {
        try
        {
            DateTime dt=Convert.ToDateTime(inputField.Text);

            if (ddlCofirm.SelectedIndex > 0)
            {
                 resp = obj_class.Insert_BillPayment(Convert.ToInt32(lblBillID.Text), txtbillno.Text, Convert.ToDateTime(inputField.Text), Convert.ToInt32(ddlCofirm.SelectedValue), Convert.ToInt32(ddlpaymentMode.SelectedIndex), txtchequeNo.Text, Convert.ToDateTime(txtchequedate.Text), Convert.ToDouble(txtamount.Text), txtRemarks.Text);
            }
            else
            {
                resp = obj_class.Insert_BillPayment(Convert.ToInt32(lblBillID.Text), txtbillno.Text, Convert.ToDateTime(inputField.Text), Convert.ToInt32(ddlBillNo.SelectedValue), Convert.ToInt32(ddlpaymentMode.SelectedIndex), txtchequeNo.Text, Convert.ToDateTime(txtchequedate.Text), Convert.ToDouble(txtamount.Text), txtRemarks.Text);

            }
            if (resp == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Payment Made Successfully');</script>");
            }

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
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('ViewDetails.aspx?CID="+ ddlCofirm.SelectedItem.Text  +"', 'mynewwin', 'width=1050,height=850,scrollbars=yes,toolbar=1')</script>");

    }

    public void LoadProjectName()
    {
        dt = obj_class.Get_BizconnectProjectName(Convert.ToInt32(Session["ClientID"].ToString()),2);
        ddl_ProjectName.DataSource = dt;
        ddl_ProjectName.DataTextField = "ProjectName";
        ddl_ProjectName.DataValueField = "ProjectName";
        ddl_ProjectName.DataBind();
        ddl_ProjectName.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    protected void ddl_ProjectNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        dt_BillNo = obj_class.Bizconnect_GetBillNoByProjecNameAndNoForBillApproval(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ProjectName.SelectedItem.Text, ddl_ProjectNo.SelectedItem.Text, 2);
        ddlBillNo.DataSource = dt_BillNo;
        ddlBillNo.DataTextField = "BillNo";
        ddlBillNo.DataValueField = "ConfirmNo";
        ddlBillNo.DataBind();
        ddlBillNo.Items.Insert(0, new ListItem("-Select-", "0"));
        ClearFields();
    }
    protected void ddl_ProjectName_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt.Clear();
            dt = obj_class.Get_BizconnectProjectNo(Convert.ToInt32(Session["ClientID"].ToString()), ddl_ProjectName.SelectedItem.Text,2);
            ddl_ProjectNo.DataSource = dt;
            ddl_ProjectNo.DataTextField = "ProjectNo";
            ddl_ProjectNo.DataValueField = "ProjectNo";
            ddl_ProjectNo.DataBind();
            ddl_ProjectNo.Items.Insert(0, new ListItem("-Select-", "0"));
            ClearFields();
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddlBillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            ddlCofirm.Items.Clear();
            if (ddlBillNo.SelectedIndex > 0)
            {
                ddlCofirm.Items.Add(new ListItem(ddlBillNo.SelectedValue.ToString(),"0"));
            }

            DataSet ds = new DataSet();
            ds = obj_class.Get_BillDetailsForPayment(Convert.ToInt32(ddlBillNo.SelectedValue.ToString ()));
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtfrom.Text = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                txtto.Text = ds.Tables[0].Rows[0].ItemArray[1].ToString();
                txttrucktype.Text = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                txtLRNo.Text = ds.Tables[0].Rows[0].ItemArray[3].ToString();
                txtbillvalue.Text = ds.Tables[0].Rows[0].ItemArray[5].ToString();
                txtbillno.Text = ds.Tables[0].Rows[0].ItemArray[6].ToString();
                inputField.Text = ds.Tables[0].Rows[0].ItemArray[7].ToString();

                Session["ImageID"] = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                //image
                BillImage.ImageUrl = "BillImage.ashx?ImageID=" + ds.Tables[0].Rows[0].ItemArray[9].ToString();
                lblBillID.Text = ds.Tables[0].Rows[0].ItemArray[9].ToString();
                txt_Transporter.Text = ds.Tables[0].Rows[0].ItemArray[10].ToString();
            }

        }
        catch (Exception ex)
        {
        }
    }
    public void ClearFields()
    {
        txtbillno.Text = "";
        inputField.Text = "";
        txtbillvalue.Text = "";
        txtfrom.Text = "";
        txtto.Text = "";
        txttrucktype.Text = "";
        txtLRNo.Text = "";
        txtchequedate.Text = "";
        txtchequeNo.Text = "";
        txtamount.Text = "";
        BillImage.ImageUrl = "";
        ddlCofirm.Items.Clear();
    }

}
