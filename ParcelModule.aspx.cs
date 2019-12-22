using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
public partial class ParcelModule : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClient bizcl = new BizConnectClient();
    TripAgreementClass Trip_Agreement = new TripAgreementClass();
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();
    int AgreementID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           
            ChkAuthentication();
            Client();
            Transporter();
           
        }
    }
    public void Client()
    {
        //Fill Client
        DataSet dsl = new DataSet();
        dsl = Trip_Agreement.Bizconnect_GetClient();
        DDLClient.Items.Clear();
        DDLClient.DataSource = dsl;
        DDLClient.DataTextField = "CompanyName";
        DDLClient.DataValueField = "ClientID";
        DDLClient.DataBind();
        DDLClient.Items.Insert(0, new ListItem("--- Select Client ---", "0"));
    }
    public void Clientcity()
    {
        //Fill Client Location
        DataSet dsl = new DataSet();
        dsl = bizcl.Fillclientcity(Convert.ToInt32(DDLClient.SelectedValue));
        DDLClientAddrLoction.Items.Clear();
        DDLClientAddrLoction.DataSource = dsl;
        DDLClientAddrLoction.DataTextField = "City";
        DDLClientAddrLoction.DataValueField = "ClientAddressLocationID";
        DDLClientAddrLoction.DataBind();
        DDLClientAddrLoction.Items.Insert(0, new ListItem("--- Select Client Location ---", "0"));
    }

    public void Transporter()
    {
        //Fill Transporter
        DataSet dsl = new DataSet();
        dsl = Trip_Agreement.Get_Transporter();
        DDLTransporter.Items.Clear();
        DDLTransporter.DataSource = dsl;
        DDLTransporter.DataTextField = "Transporter";
        DDLTransporter.DataValueField = "TransporterID";
        DDLTransporter.DataBind();
        DDLTransporter.Items.Insert(0, new ListItem("--- Select Transporter ---", "0"));
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
    protected void DDLClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clientcity();
    }
    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            int res = Trip_Agreement.Bizconnect_InsertAgreement(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue),1);
            if (res == 1)
            {
                GetAgreementID(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
                lblmsg.Visible = true;
                lblmsg1.Visible = true;
                TblAgreement.Visible = true;

                string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
                SqlConnection conn = new SqlConnection();
                SqlCommand cmd;
                conn.ConnectionString = Conn;
                conn.Open();
                  string qry = "insert into Bizconnect_ParcelParameters(ClientID,TransporterId,FSC,VSC,FOV,DHC,IntimationCharges,MinimumCharges,LRCharges)values(" + Convert.ToInt32(DDLClient.SelectedValue) + " ," + Convert.ToInt32(DDLTransporter.SelectedValue) + "," + Convert.ToSingle(txtFSCpercent.Text) + "," + Convert.ToSingle(txtVSCpercent.Text) + "," + Convert.ToSingle(txtFOVpercent.Text) + "," + Convert.ToSingle(txtDHC.Text) + "," + Convert.ToSingle(txtinitimation.Text) + "," + Convert.ToSingle(txtminimumbasic.Text) + "," + Convert.ToSingle(txtLRcharges.Text) + ")";
                cmd = new SqlCommand(qry, conn);
                cmd.ExecuteNonQuery();
            }

        }
        catch (Exception ex)
        {
        }
    }
    public void GetAgreementID(int ClientID, int ClientAdrID, int TransID)
    {
        AgreementID = 0;
        AgreementID = Trip_Agreement.GetAgreementID(ClientID, ClientAdrID, TransID);
        Session["AgreementID"] = AgreementID.ToString();
    }
    public void LoadAgreementRoutes()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Trip_Agreement.DisplayAgreementRoutes(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
            Gridwindow.DataSource = dt;
            Gridwindow.DataBind();
            if (dt.Rows.Count > 0)
            {
                TblAgreement.Visible = true;
            }
            else
            {
                TblAgreement.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    //display details in gridview after selecting from transporter drop down list
    public void LoadDetails()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = Trip_Agreement.Agreement_Details(Convert.ToInt32(Session["ClientID"].ToString()));
            Gridwindow.DataSource = dt;
            Gridwindow.DataBind();
            if (dt.Rows.Count > 0)
            {
                TblAgreement.Visible = true;
            }
            else
            {
                TblAgreement.Visible = false;
            }
        }
        catch (Exception ex)
        {
        }
    }
    
    protected void DDLTransporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        //LoadAgreementRoutes();
        LoadDetails();
        GetAgreementID(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
        if (AgreementID > 0)
        {
            lblmsg1.Visible = true;
            TblAgreement.Visible = true;
        }
        else
        {

            lblmsg1.Visible = false;
            TblAgreement.Visible = false;
        }
    }
    protected void ButAssign_Click(object sender, EventArgs e)
    {
        try
        {
            Trip_Agreement.FromLocation =txtFrom .Text ;
            Trip_Agreement .ToLocation =txtto .Text ;
            Trip_Agreement .EnclosureType =1;
            Trip_Agreement .TruckType =1;
            Trip_Agreement .RatePerKG =Convert .ToSingle (txtDecideprice .Text);
            Trip_Agreement .DeliveryPeriod =ddl_UOM .SelectedValue;
            Trip_Agreement .OtherCharges =0;
            Trip_Agreement .LRCharges =0;
            Trip_Agreement .DoorDeliveryCharges =0;
            Trip_Agreement .DoorCollectionCharges =0;
            int resp = Trip_Agreement.Insert_ParcelAgreementDetails();
            if (resp == 1)
            {
                LoadAgreementRoutes();
                Clear();
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Route Add Successfully');</script>");
            }

            //int resp = Trip_Agreement.Insert_AgreementRoute(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue), Convert.ToInt32(Session["AgreementID"].ToString()), txtFrom.Text, txtto.Text, 1, 1, ddl_UOM.SelectedItem.Text, Convert.ToSingle(txtDecideprice.Text), Convert.ToInt32(txttransitdays.Text));
                
            if (resp == 1)
            {
                LoadAgreementRoutes(); 
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Route Add Successfully');</script>");
            }
        }
        catch (Exception ex)
        {
        }
    }
    public void Clear()
    {
    }

    protected void ButAddslab_Click(object sender, EventArgs e)
    {
        string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd;
        conn.ConnectionString = Conn;
        conn.Open();
       string  qry = "insert into DoorDeliverySlap(ClientID,TransporterID,NoofBoxs,charge)values(" + Convert.ToInt32(DDLClient.SelectedValue) + " ," + Convert.ToInt32(DDLTransporter.SelectedValue) + "," + Convert.ToInt32(ddl_CotonBox.SelectedValue) + ","+ Convert.ToInt32(txtDoordeliverycharges.Text)+")";
        cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Slap Added Successfully');</script>");
    }
}