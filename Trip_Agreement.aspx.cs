using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Trip_Agreement : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClient bizcl = new BizConnectClient();
    //TripAgreementClass Trip_Agreement = new TripAgreementClass();
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    DataSet ds;
    int AgreementID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
            if (!IsPostBack)
            {
                ChkAuthentication();
                Client();
                Transporter();
                option.Visible = false;
                div_ftl.Visible = false;
                div_parcel.Visible = false;
                div_transporter.Visible = false;
            }

        }
    }

    private void Client()
    {
        try
        {
            DataSet ds_client = new DataSet();
            string clientid = Session["ClientID"].ToString();
            if (clientid != "")
            {
                string[] args = { "@clientid" };
                string[] argsval = { clientid };
                ds_client = con.Sql_GetData("Get_BizConnect_UniqueClient_New", args, argsval);
                if (ds_client.Tables[0].Rows.Count > 0)
                {
                    ddl_client.Items.Clear();
                    ddl_client.DataSource = ds_client;
                    ddl_client.DataTextField = "CompanyName";
                    ddl_client.DataValueField = "ClientID";
                    ddl_client.DataBind();
                    ddl_client.Items.Insert(0, new ListItem("--- Select Client ---", "0"));
                }
                else
                {

                }
            }
            else
            {
                Response.Redirect("Index.html");
            }
        }
        catch(Exception ex)
        {

        }
    }

    private void Transporter()
    {
        try
        {
            DataSet ds_transporter = new DataSet();
            ds_transporter = con.Sql_GetData("Get_Transporter");
            if (ds_transporter.Tables[0].Rows.Count > 0)
            {
                DDLTransporter.Items.Clear();
                DDLTransporter.DataSource = ds_transporter;
                DDLTransporter.DataTextField = "Transporter";
                DDLTransporter.DataValueField = "TransporterID";
                DDLTransporter.DataBind();
                DDLTransporter.Items.Insert(0, new ListItem("--- Select Transporter ---", "0"));
            }
        }
        catch(Exception ex)
        {


        }
    }
    private void ChkAuthentication()
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
    private void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
    }
    private void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
    }
    protected void rdb_ftl_CheckedChanged(object sender, EventArgs e)
    {
        option.Visible = true;
        div_ftl.Visible = true;
        div_parcel.Visible = false;
        div_transporter.Visible = false;
        FillEnclosureType();
        FillTruckType();
    }

    private void FillTruckType()
    {
        try
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
        catch (Exception ex)
        {


        }
    }

    private void FillEnclosureType()
    {
        try
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
        catch (Exception ex)
        {

        }
    }
    protected void rdb_parcel_CheckedChanged(object sender, EventArgs e)
    {
        option.Visible = true;
        div_ftl.Visible = false;
        div_parcel.Visible = true ;
        div_transporter.Visible = false;
        Load_Parcel_Details();
    }

    private void Load_Parcel_Details()
    {
        try
        {
            DataSet ds_parttrans = new DataSet();
            string client = ddl_client.SelectedValue;
            string clientaddress = DDLClientAddrLoction.SelectedValue;
            string transporter = DDLTransporter.SelectedValue;
            string[] args = { "@clientid", "@clientlocid", "@transid" };
            string[] argsval = { client, clientaddress, transporter };
            ds_parttrans = con.Sql_GetData("DisplayAgreementRoutes_Parcel", args, argsval);
            if (ds_parttrans.Tables[0].Rows.Count > 0)
            {
                div_parcel.Visible = true;
                gv_parceldetails.DataSource = ds_parttrans;
                gv_parceldetails.DataBind();
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void rdb_active_CheckedChanged(object sender, EventArgs e)
    {
        option.Visible = true;
        div_ftl.Visible = false;
        div_parcel.Visible = false;
        div_transporter.Visible = true;
        string cid = Session["ClientID"].ToString();
        if (cid != "")
        {
            string[] args = { "@ClientId" };
            string[] argsval = { cid };
            DataSet ds_active = new DataSet();
            ds_active = con.Sql_GetData("Bizconnect_Active_Transporter", args, argsval);
            if (ds_active.Tables[0].Rows.Count > 0)
            {
                div_transporter.Visible = true;
                gridview_trans_details.DataSource = ds_active;
                gridview_trans_details.DataBind();
            }
            else
            {

            }
        }
        else
        {
            Response.Redirect("Index.html");
        }

    }
    protected void ddl_client_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DataSet ds_client = new DataSet();
            string client = ddl_client.SelectedValue;
            string[] args = { "@clientid" };
            string[] argsval = { client };
            ds_client = con.Sql_GetData("Get_BizConnect_Clientcity_New", args, argsval);
            if(ds_client.Tables[0].Rows.Count > 0)
            {
                option.Visible = true;
                DDLClientAddrLoction.Items.Clear();
                DDLClientAddrLoction.DataSource = ds_client;
                DDLClientAddrLoction.DataTextField = "City";
                DDLClientAddrLoction.DataValueField = "ClientAddressLocationID";
                DDLClientAddrLoction.DataBind();
                DDLClientAddrLoction.Items.Insert(0, new ListItem("--- Select Client Location ---", "0"));
            }
        }
        catch(Exception ex)
        {

        }
    }
    protected void DDLTransporter_SelectedIndexChanged(object sender, EventArgs e)
    {
        Load_details();
        GetAgreementID(Convert.ToInt32(ddl_client.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
        if (AgreementID > 0)
        {
            option.Visible = true;
            if (Session["IsActive"].ToString() == "True")
            {
                btn_submit.Text = "DeActivate";
            }
            else if (Session["IsActive"].ToString() == "False")
            {
                btn_submit.Text = "Activate";
            }

        }
        else
        {

            div_ftl.Visible = false;
            btn_submit.Visible = true;


        }
    }

    private void GetAgreementID(int ClientID, int ClientAdrID, int TransID)
    {
        AgreementID = 0;
        //DataTable Agreement = Trip_Agreement.GetAgreementID(ClientID, ClientAdrID, TransID);
        DataSet ds = new DataSet();
        int clientid = Convert.ToInt32(ddl_client.SelectedValue);
        int clientadd = Convert.ToInt32(DDLClientAddrLoction.SelectedValue);
        int transporterid = Convert.ToInt32(DDLTransporter.SelectedValue);
        string[] args = { "@clientid", "@clientlocid", "@transid" };
        string[] argsval = { clientid.ToString(), clientadd.ToString(), transporterid.ToString() };
        ds = con.Sql_GetData("GetAgreementID_New", args, argsval);
        if (ds.Tables[0].Rows.Count > 0)
        {
            Session["AgreementID"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
            AgreementID = Convert.ToInt32(Session["AgreementID"].ToString());
            Session["IsActive"] = ds.Tables[0].Rows[0].ItemArray[1].ToString();
        }
        else
        {
            AgreementID = 0;
        }
    }

    private void Load_details()
    {
        try
        {
            DataSet ds_trans = new DataSet();
            string client = ddl_client.SelectedValue;
            string clientaddress = DDLClientAddrLoction.SelectedValue;
            string transporter = DDLTransporter.SelectedValue;
            string[] args = { "@clientid", "@clientlocid", "@transid" };
            string[] argsval = { client, clientaddress, transporter };
            ds_trans = con.Sql_GetData("DisplayAgreementRoutes_New", args, argsval);
            if (ds_trans.Tables[0].Rows.Count > 0)
            {
                div_ftl.Visible = true;
                gv_ftldetails.DataSource = ds_trans;
                gv_ftldetails.DataBind();
            }
        }
        catch (Exception ex)
        {


        }
    }
    protected void btn_add_Click(object sender, EventArgs e)
    {
        try
        {
            string client = ddl_client.SelectedValue;
            string clientadd = DDLClientAddrLoction.SelectedValue;
            string transporter = DDLTransporter.SelectedValue;
            string agreementid = Session["AgreementID"].ToString();
            string source = txt_ftlsource.Text;
            string destination = txt_ftlto.Text;
            string encl = DDLEnclType.SelectedValue;
            string trucktype = DDLTruckType.SelectedValue;
            string capacity = txt_capacity.Text;
            string decideprice = txt_agreement.Text;
            string days = txt_days.Text;
            string emailid = txt_emailid.Text;

            string[] args = { "@clientid", "@clientaddid", "@trnasid", "@agreementid", "@source", "@destination", "@enclid", "@trucktype", "@capacity", "@decideprice", "@days", "@emailid", "@transporterprice", "@rfqtype" };
            string[] argsval = { client, clientadd, transporter, agreementid, source, destination, encl, trucktype, capacity, decideprice, days, emailid, decideprice, "FTL" };
            int res = con.Sql_ExecuteNonQuery("SP_Insert_Into_Agreement", args, argsval);
            if (res > 0)
            {
                Load_details();
                lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Route Added Succesfully!!");
            }
            else
            {
                lbl_msg.Text = Resources.Resource.alert_warning.Replace("{@message}", "Something Went Wrong!!");
            }

        }
        catch(Exception ex)
        {

        }
    }
    protected void btn_parcel_add_Click(object sender, EventArgs e)
    {
        try
        {
            string client = ddl_client.SelectedValue;
            string clientadd = DDLClientAddrLoction.SelectedValue;
            string transporter = DDLTransporter.SelectedValue;
            string agreementid = Session["AgreementID"].ToString();
            string source = txt_parcelsource.Text;
            string destination = txt_partdest.Text;
            string encl = ddl_packtype.SelectedValue;
            string trucktype = ddl_delv.SelectedValue;
            string capacity = txt_units.Text;
            string decideprice = txt_partprice.Text;
            string days = txt_transitdays.Text;
            string emailid = txt_emailid.Text;
            string size =txt_cft.Text+ "," + "L- " + txtlen.Text + "," + "B- " + txtbdth.Text + "," + "H- " + txtwth.Text + "," + "Weight- " + txtwt.Text;

            string[] args = { "@clientid", "@clientaddid", "@trnasid", "@agreementid", "@source", "@destination", "@enclid", "@trucktype", "@capacity", "@decideprice", "@days", "@emailid", "@transporterprice", "@size","@rfqtype" };
            string[] argsval = { client, clientadd, transporter, agreementid, source, destination, encl, trucktype, capacity, decideprice, days, emailid,decideprice,size,"Parcel" };
            int res = con.Sql_ExecuteNonQuery("SP_Insert_Into_Agreement_Parcel", args, argsval);
            if (res > 0)
            {
                Load_Parcel_Details();  
                lbl_message.Text = Resources.Resource.alert_success.Replace("{@message}", "Route Added Succesfully!!");

            }
            else
            {
                lbl_message.Text = Resources.Resource.alert_warning.Replace("{@message}", "Something Went Wrong!!");
            }

        }
        catch(Exception ex)
        {

        }
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {
        try
        {
            if (btn_submit.Text == "Submit")
            {
                string client = ddl_client.SelectedValue;
                string clientadd = DDLClientAddrLoction.SelectedValue;
                string transporter = DDLTransporter.SelectedValue;
                string[] args = { "@clientid", "@clientaddid", "@transid", "@mode" };
                string[] argsval = { client, clientadd, transporter, "0" };
                int res = con.Sql_ExecuteNonQuery("Bizconnect_InsertAgreement_New", args, argsval);
                if (res > 0)
                {
                    GetAgreementID(Convert.ToInt32(ddl_client.SelectedValue), Convert.ToInt32(DDLClientAddrLoction.SelectedValue), Convert.ToInt32(DDLTransporter.SelectedValue));
                    btn_submit.Text = "DeActivate";

                }
            }
            else if (btn_submit.Text == "DeActivate")
            {
                string _client = ddl_client.SelectedValue;
                string _clientadd = DDLClientAddrLoction.SelectedValue;
                string _transporter = DDLTransporter.SelectedValue;
                string[] _args = { "@clientid", "@clientaddid", "@transid", "@mode" };
                string[] _argsval = { _client, _clientadd, _transporter, "1" };
                int _res = con.Sql_ExecuteNonQuery("Bizconnect_InsertAgreement_New", _args, _argsval);
                if (_res > 0)
                {
                    btn_submit.Text = "Activate";
                }
            }
            else if (btn_submit.Text == "Activate")
            {
                string client_ = ddl_client.SelectedValue;
                string _clientadd_ = DDLClientAddrLoction.SelectedValue;
                string _transporter_ = DDLTransporter.SelectedValue;
                string[] args_ = { "@clientid", "@clientaddid", "@transid", "@mode" };
                string[] _argsval_ = { client_, _clientadd_, _transporter_, "2" };
                int _res_ = con.Sql_ExecuteNonQuery("Bizconnect_InsertAgreement_New", args_, _argsval_);
                if (_res_ > 0)
                {
                    btn_submit.Text = "Activate";
                }

            }
        }

        catch(Exception ex)
        {

        }
    }
}