using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Globalization;

public partial class BillDeletion : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    BillingModule obj_class = new BillingModule();
    DataTable dt = new DataTable();
    int resp;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLrNumber();
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
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        // obj_Navi.Visible = true;
        //obj_Navihome.Visible = false;
    }
    public void LoadLrNumber()
    {
        dt = obj_class.Bizconnect_GetLrNumberandConfirmnoByLrno(Convert.ToInt32(Session["ClientID"].ToString()),string .Empty);
        ddl_LrNo.DataSource = dt;
        ddl_LrNo.DataTextField = "LRNumber";
        ddl_LrNo.DataValueField = "LRNumber";
        ddl_LrNo.DataBind();
        ddl_LrNo.Items.Insert(0, new ListItem("-Select-", "0"));
    }

    protected void ddl_LrNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt.Clear();
            dt = obj_class.Bizconnect_GetLrNumberandConfirmnoByLrno(Convert.ToInt32(Session["ClientID"].ToString()), ddl_LrNo.SelectedItem.Text);
            ddl_ConfirmNo.DataSource = dt;
            ddl_ConfirmNo.DataTextField = "CofirmNo";
            ddl_ConfirmNo.DataValueField = "CofirmNo";
            ddl_ConfirmNo.DataBind();
            ddl_ConfirmNo.Items.Insert(0, new ListItem("-Select-", "0"));
            ClearFields();
        }
        catch (Exception ex)
        {

        }
    }

    protected void ddl_ConfirmNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            dt.Clear();
            dt = obj_class.Bizconnect_GetBillDetailsByConfirmNo(Convert.ToInt32(ddl_ConfirmNo.SelectedValue));

            txt_Billno.Text=dt.Rows [0][0].ToString ();
                txt_Billdate.Text=dt.Rows [0][1].ToString ();
                txt_Billvalue.Text=dt.Rows [0][2].ToString ();
                    txt_Confirmno.Text=dt.Rows [0][5].ToString ();
                    txt_Lrno.Text=dt.Rows [0][3].ToString ();
                        txt_Lrdate.Text=dt.Rows [0][4].ToString ();
                        txt_Agreementvalue.Text=dt.Rows [0][6].ToString ();
                            txt_Othercharges.Text=dt.Rows [0][7].ToString ();
                            txt_Basicfreight.Text=dt.Rows [0][8].ToString ();
                                txt_Loadingdetention.Text=dt.Rows [0][9].ToString ();
                                txt_Unloadingdetention.Text=dt.Rows [0][10].ToString ();
                                    txt_Octroid.Text=dt.Rows [0][13].ToString ();
                                    txt_Loadingcharges.Text=dt.Rows [0][11].ToString ();
                                        txt_Unloadingcharges.Text=dt.Rows [0][12].ToString ();
                                        txt_Dimensiondiff.Text=dt.Rows [0][14].ToString ();
                                            txt_Otherclaims.Text=dt.Rows [0][15].ToString ();
                                            txt_Insurance.Text=dt.Rows [0][16].ToString ();
                                                txt_Damages.Text=dt.Rows [0][17].ToString ();
                                                txt_Shortages.Text=dt.Rows [0][18].ToString ();

        }
        catch (Exception ex)
        {

        }
    }
    protected void btn_Edit_Click(object sender, EventArgs e)
    {
       
            try
            {
                if ((Convert.ToInt32(Session["UserID"]) == 381 && Session["name"].ToString() == "BABUTHOMAS BABUTHOMAS") || (Convert.ToInt32(Session["UserID"]) == 2921 && Session["name"].ToString() == "Amit Yadav"))
                {
                    obj_class.ConfirmNo = Convert.ToInt32(Convert.ToInt32(ddl_ConfirmNo.SelectedValue));
                    obj_class.BillNo = txt_Billno.Text;
                    obj_class.BillDate = DateTime.ParseExact(txt_Billdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj_class.TransNetValue = Convert.ToSingle(txt_Billvalue.Text);
                    obj_class.LRNumber = txt_Lrno.Text;
                    obj_class.LRDate = DateTime.ParseExact(txt_Lrdate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    obj_class.TransOtherCharges = Convert.ToSingle(txt_Othercharges.Text);
                    obj_class.TransLoadingDetentionCharges = Convert.ToSingle(txt_Loadingdetention.Text);
                    obj_class.TransUnLoadingDetentionCharges = Convert.ToSingle(txt_Unloadingdetention.Text);
                    obj_class.TransLoadingCharges = Convert.ToSingle(txt_Loadingcharges.Text);
                    obj_class.TransUnLoadingCharges = Convert.ToSingle(txt_Unloadingcharges.Text);
                    obj_class.TransoctroiCharges = Convert.ToSingle(txt_Octroid.Text);
                    obj_class.TransoDimentionDiff = Convert.ToSingle(txt_Dimensiondiff.Text);
                    obj_class.TransOtherClaimsCharges = Convert.ToSingle(txt_Otherclaims.Text);
                    obj_class.TransInsurance = Convert.ToSingle(txt_Insurance.Text);
                    obj_class.TransDamages = Convert.ToSingle(txt_Damages.Text);
                    obj_class.TransShortages = Convert.ToSingle(txt_Shortages.Text);

                    resp = obj_class.Bizconnect_EditBillSubmissionDetailsByConfirmNo(Convert.ToSingle(txt_Agreementvalue.Text), Convert.ToSingle(txt_Basicfreight.Text));
                    if (resp == 1)
                    {
                        this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Bill No : " + txt_Billno.Text + "   Details Edited Successfully');", true);
                        ClearFields();
                        ddl_LrNo.SelectedIndex = -1;
                        ddl_ConfirmNo.SelectedIndex = -1;
                    }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Access Denied');", true);
                }
            }
            catch (Exception ex)
            {

            }
    }

    protected void btn_Delete_Click(object sender, EventArgs e)
    {
        resp = 0;
        try
        {
            if ((Convert.ToInt32(Session["UserID"]) == 381 && Session["name"].ToString() == "BABUTHOMAS BABUTHOMAS") || (Convert.ToInt32(Session["UserID"]) == 2921 && Session["name"].ToString() == "Amit Yadav"))
            {
            obj_class.ConfirmNo = Convert.ToInt32(Convert.ToInt32(ddl_ConfirmNo.SelectedValue));
            resp = obj_class.Bizconnect_DeleteBillDetailsByConfirmNo();

            if (resp == 1)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Bill No  :  "   + txt_Billno.Text +   "   Details Deleted Successfully');", true);
                ClearFields();
                ddl_LrNo.SelectedIndex = -1;
                ddl_ConfirmNo.SelectedIndex = -1;
                LoadLrNumber();
            }
                }
                else
                {
                    this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Access Denied');", true);
                }

        }
        catch (Exception ex)
        {

        }
    }

    public void ClearFields()
    {
       // ddl_ConfirmNo.SelectedIndex = -1;
       // ddl_LrNo.SelectedIndex = -1;
        txt_Billno.Text="";
        txt_Billdate.Text = "";
        txt_Billvalue.Text = "";
        txt_Lrno.Text = "";
        txt_Lrdate.Text = "";
        txt_Othercharges.Text = "";
        txt_Loadingdetention.Text = "";
        txt_Unloadingdetention.Text = "";
        txt_Loadingcharges.Text = "";
        txt_Unloadingcharges.Text = "";
        txt_Octroid.Text = "";
        txt_Dimensiondiff.Text = "";
        txt_Otherclaims.Text = "";
        txt_Insurance.Text = "";
        txt_Damages.Text = "";
        txt_Shortages.Text = "";
        txt_Agreementvalue.Text="";
        txt_Basicfreight.Text = "";
        txt_Confirmno.Text = "";
    }
}