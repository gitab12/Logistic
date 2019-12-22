using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class TripAgreement : System.Web.UI.Page
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

    DataSet ds;
    int AgreementID;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
            Client();
            Transporter();
            FillEnclosureType();
            FillTruckType();
        }
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
    public void Client()
    {
        //Fill Client
        DataSet dsl = new DataSet();
        dsl = Trip_Agreement.Bizconnect_GetUniqueClient(Session["ClientID"].ToString());
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

    public void FillTruckType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillTruckType();
        if (ds.Tables["TruckType"].Rows.Count > 0)
        {
            DDLTruckType.Items.Clear();
            DDLTruckType.DataSource = ds.Tables["TruckType"];
            DDLTruckType.DataTextField = "TruckType";
            DDLTruckType.DataValueField = "TruckTypeID";
            DDLTruckType.DataBind();
            DDLTruckType.Items.Insert(0, new ListItem("--- Truck Type ---", "0"));
        }

    }

    public void FillEnclosureType()
    {
        DataSet ds = new DataSet();
        ds = obj_BizConnectLogisticsPlanClass.FillEnclosureType();
        if (ds.Tables["EnclosureType"].Rows.Count > 0)
        {
            DDLEnclType.Items.Clear();
            DDLEnclType.DataSource = ds.Tables["EnclosureType"];
            DDLEnclType.DataTextField = "EnclosureType";
            DDLEnclType.DataValueField = "EnclosureTypeID";
            DDLEnclType.DataBind();
            DDLEnclType.Items.Insert(0, new ListItem("--- Enclosure Type ---", "0"));
        }

    }



    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        try
        {
            if (ButSubmit.Text == "Submit")
            {
                int res = Trip_Agreement.Bizconnect_InsertAgreement(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue), 0);
                if (res == 1)
                {
                    GetAgreementID(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
                    lblmsg.Visible = true;
                    lblmsg1.Visible = true;
                    TblAgreement.Visible = true;
                    ButSubmit.Text = "DeActivate";
                }
            }
            else if (ButSubmit.Text == "DeActivate")
            {
                int res = Trip_Agreement.Bizconnect_InsertAgreement(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue), 1);
                if (res == 1)
                {
                    lblmsg.Text = "DeActivated Sucessfully";
                    lblmsg1.Visible = false;
                    TblAgreement.Visible = false;
                    ButSubmit.Text = "Activate";
                }
            }
            else if (ButSubmit.Text == "Activate")
            {
                int res = Trip_Agreement.Bizconnect_InsertAgreement(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue), 2);
                if (res == 1)
                {
                    lblmsg.Text = "Activated Sucessfully";
                    lblmsg1.Visible = false;
                    TblAgreement.Visible = false;
                    ButSubmit.Text = "DeActivate";
                }
            }

        }
        catch (Exception ex)
        {
        }
    }
    public void GetAgreementID(int ClientID, int ClientAdrID, int TransID)
    {
        AgreementID = 0;
        DataTable Agreement = Trip_Agreement.GetAgreementID(ClientID, ClientAdrID, TransID);
        if (Agreement.Rows.Count > 0)
        {
            Session["AgreementID"] = Agreement.Rows[0].ItemArray[0].ToString();
            AgreementID = Convert.ToInt32(Session["AgreementID"].ToString());
            Session["IsActive"] = Agreement.Rows[0].ItemArray[1].ToString();
        }
        else
        {
            AgreementID = 0;
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
    protected void DDLClient_SelectedIndexChanged(object sender, EventArgs e)
    {
        Clientcity();
    }
    protected void ButAssign_Click(object sender, EventArgs e)
    {
        try
        {
            string email = txtemailid.Text;
            if (email == "")
            {
                int resp = Trip_Agreement.Insert_AgreementRoute(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue), Convert.ToInt32(Session["AgreementID"].ToString()), txtFrom.Text, txtto.Text, Convert.ToInt32(DDLEnclType.SelectedValue), Convert.ToInt32(DDLTruckType.SelectedValue), txtCapacity.Text, Convert.ToSingle(txtDecideprice.Text), Convert.ToInt32(txttransitdays.Text));
                if (resp == 1)
                {
                    LoadAgreementRoutes();
                    Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Route Add Successfully');</script>");
                }
            }
            else
            {
                int resp = Trip_Agreement.InsertintoAgreementRoute(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue), Convert.ToInt32(Session["AgreementID"].ToString()), txtFrom.Text, txtto.Text, Convert.ToInt32(DDLEnclType.SelectedValue), Convert.ToInt32(DDLTruckType.SelectedValue), txtCapacity.Text, Convert.ToSingle(txtDecideprice.Text), Convert.ToInt32(txttransitdays.Text), txtemailid.Text);
                if (resp == 1)
                {
                    LoadAgreementRoutes();
                    Clear();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Route Add Successfully');</script>");
                }
            }

           
        }
        catch (Exception ex)
        {
        }
    }

    public void Clear()
    {
        txtFrom.Text = "";
        txtto.Text = "";
        txtCapacity.Text = "";
        txtDecideprice.Text = "";
        DDLEnclType.SelectedIndex = 0;
        DDLTruckType.SelectedIndex = 0;
    }
    protected void DDLTransporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        LoadAgreementRoutes();
        GetAgreementID(Convert.ToInt32(DDLClient.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
        if (AgreementID > 0)
        {
            lblmsg.Visible = true;
            lblmsg1.Visible = true;
            TblAgreement.Visible = true;
            if (Session["IsActive"].ToString() == "True")
            {
                ButSubmit.Text = "DeActivate";
            }
            else if (Session["IsActive"].ToString() == "False")
            {
                ButSubmit.Text = "Activate";
            }

        }
        else
        {
            lblmsg.Visible = false;
            lblmsg1.Visible = false;
            TblAgreement.Visible = false;


        }
    }
    protected void BtnActveTrans_Click(object sender, EventArgs e)
    {
        string clientid = Session["ClientID"].ToString();
       
            try
            {
                String conn = ConfigurationManager.ConnectionStrings["Bizcon"].ConnectionString;
                using (SqlConnection con1 = new SqlConnection(conn))
                {
                    using (SqlCommand cmd1 = new SqlCommand("Bizconnect_Active_Transporter", con1))
                    {
                        SqlDataAdapter sda = new SqlDataAdapter(cmd1);
                        sda.SelectCommand.CommandType = CommandType.StoredProcedure;
                        sda.SelectCommand.Parameters.AddWithValue("@ClientId", clientid);

                          try
                            {
                                cmd1.Connection = con1;
                                con1.Open();
                                sda.SelectCommand = cmd1;

                                DataSet ds = new DataSet();
                                sda.Fill(ds);

                                // BIND DATABASE WITH THE GRIDVIEW.
                                Active_Transporter.DataSource = ds;
                                Active_Transporter.DataBind();
                                Lbl_msg.Text = "No of Active Transporter='" + Active_Transporter.Rows.Count + "'";
                            }
                            catch (Exception ex)
                            {
                                Lbl_msg.Text = "<span style='font-size: 20px; color: red;'>Please try again!</span>";
                            }
                        }
                    }
                
            }

            catch (Exception ex)
            {
            }

        
    }
}


