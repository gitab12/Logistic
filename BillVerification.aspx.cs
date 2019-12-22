using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class BillVerification : System.Web.UI.Page
{


    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    BillingModule obj_Class = new BillingModule();
    DataTable dt_Transporter = new DataTable();
    DataTable dt_ProjectNo = new DataTable();
    DataTable dt_BillNo = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTransporters();
            pnl_BillVerification.Visible = false;
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
    public void LoadTransporters()
    {
        try
        {
            dt_Transporter = obj_Class.Bizconnect_LoadTransportersForBillVerification(Convert.ToInt32(Session["ClientID"].ToString()));
            ddl_Transporter.DataSource = dt_Transporter;
            ddl_Transporter.DataTextField = "Transporter";
            ddl_Transporter.DataValueField = "TransporterID";
            ddl_Transporter.DataBind();
            ddl_Transporter.Items.Insert(0, new ListItem("-Select-", "0"));
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddl_Transporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        try{

            pnl_BillVerification.Visible = false;
                if (ddl_Transporter.SelectedItem.Text != "--Select--")
                {
                    dt_ProjectNo = obj_Class.Bizconnect_LoadProjectNosForBillVerification(Convert.ToInt32(ddl_Transporter.SelectedValue.ToString()));
                    ddl_Projectno.DataSource = dt_ProjectNo;
                    ddl_Projectno.DataTextField = "ProjectNo";
                    //ddl_Projectno.DataValueField = "TransporterID";
                    ddl_Projectno.DataBind();
                    ddl_Projectno.Items.Insert(0, new ListItem("-Select-", "0"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select transporter');</script>");
                }
        }
        catch (Exception ex)
        {

        }
    }
    protected void ddl_Projectno_SelectedIndexChanged(object sender, EventArgs e)
    {
        try{

            pnl_BillVerification.Visible = false;
                if (ddl_Projectno.SelectedItem.Text != "--Select--")
                {
                    dt_BillNo = obj_Class.Bizconnect_LoadBillNoandLrNoForBillVerificationByProjectNo(ddl_Projectno.SelectedItem.Text);
                    ddl_BillNo.DataSource = dt_BillNo;
                    ddl_BillNo.DataTextField = "BillNo";
                    ddl_BillNo.DataValueField = "BillNo";
                    ddl_BillNo.DataBind();
                    ddl_BillNo.Items.Insert(0, new ListItem("-Select-", "0"));


                    dt_BillNo = obj_Class.Bizconnect_LoadBillNoandLrNoForBillVerificationByProjectNo(ddl_Projectno.SelectedItem.Text);
                    ddl_LrNo.DataSource = dt_BillNo;
                    ddl_LrNo.DataTextField = "LRNumber";
                    ddl_LrNo.DataValueField = "LRNumber";
                    ddl_LrNo.DataBind();
                    ddl_LrNo.Items.Insert(0, new ListItem("-Select-", "0"));
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Please select project no');</script>");
                }

        }
        catch (Exception ex)
        {

        }
    }
    protected void ddl_BillNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try{
            pnl_BillVerification.Visible = true;
                if (ddl_BillNo.SelectedItem.Text != "--Select--")
                {
                    ddl_LrNo.SelectedIndex = -1;
                    dt_Transporter.Clear();
                    dt_Transporter = obj_Class.Bizconnect_SearchBillingDetailsByBillNoOrLrNo(ddl_BillNo.SelectedItem.Text,"--Select--");
                    grd_BillVerification.DataSource = dt_Transporter;
                    grd_BillVerification.DataBind();

                }
        }
        catch (Exception ex)
        {

        }

    }
    protected void ddl_LrNo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try{
            pnl_BillVerification.Visible = true;
                if (ddl_LrNo.SelectedItem.Text != "--Select--")
                {
                    ddl_BillNo.SelectedIndex = -1;
                    dt_Transporter.Clear();
                    dt_Transporter = obj_Class.Bizconnect_SearchBillingDetailsByBillNoOrLrNo("--Select--", ddl_LrNo.SelectedItem.Text);
                    grd_BillVerification.DataSource = dt_Transporter;
                    grd_BillVerification.DataBind();
                }

        }
        catch (Exception ex)
        {

        }
    }

    protected void Image1_Click(object sender, ImageClickEventArgs e)
    {
        try{
                //Session["ImageID"]
                ImageButton b = (ImageButton)sender;
                GridViewRow row = (GridViewRow)b.NamingContainer;
                if (row != null)
                {
                    Label imgid = (Label)grd_BillVerification.Rows[row.RowIndex].FindControl("imgID");
                    Session["ImageID"] = imgid.Text;
                    OpenNewWindow();
                }
        }
        catch (Exception ex)
        {

        }
    }

    public void OpenNewWindow()
    {
        try{

        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('BillPreview.aspx?imgID=" + Session["ImageID"].ToString() + "', 'mynewwin', 'width=900,height=1000,scrollbars=yes,toolbar=1')</script>");
        }
        catch (Exception ex)
        {

        }
    }

    protected void link_preview_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)grd_BillVerification.Rows[row.RowIndex].FindControl("lbl_ConfirmNo");
            Session["ImageID"] = imgid.Text;
            OpenFourViewWindow();
        }
    }
    public void OpenFourViewWindow()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('TruckFourView.aspx?imgID=" + Session["ImageID"].ToString() + "', 'mynewwin', 'width=600,height=500,scrollbars=yes,toolbar=1')</script>");
    }

    protected void link_Unloading_Click(object sender, EventArgs e)
    {
        LinkButton b = (LinkButton)sender;
        GridViewRow row = (GridViewRow)b.NamingContainer;
        if (row != null)
        {
            Label imgid = (Label)grd_BillVerification.Rows[row.RowIndex].FindControl("lbl_ConfirmNo");
            Session["UnImgID"] = imgid.Text;
            OpenUnloadImageWindow();
        }
    }

    public void OpenUnloadImageWindow()
    {
        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('UnloadingTruckFrontImage.aspx?ImgID=" + Session["UnImgID"].ToString() + "', 'mynewwin', 'width=600,height=500,scrollbars=yes,toolbar=1')</script>");
    }


}