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
using System.Text;

public partial class CustomerCreation : System.Web.UI.Page
{
    string obj_Authenticated, obj_emailid;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectCustomer bizconnectcust = new BizConnectCustomer();
    BizConnectClass bizconnect = new BizConnectClass();
    BizConnectClient bizcl = new BizConnectClient();
    int clientid = 0;
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            // obj_emailid = Session["EmailID"].ToString();
            Session["ClientID"] = Request.QueryString["cltid"].ToString();



            if (!IsPostBack == true)
            {

                //ChkAuthentication();
                filldesg();
                id();
                fillcity();

            }

        }
        catch (Exception ex)
        {
        }





    }


    public void filldesg()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.FillDesignation();

        ddldesg.DataSource = ds;
        ddldesg.DataTextField = "Designation";
        ddldesg.DataValueField = "Designationid";
        ddldesg.DataBind();
    }
    public void fillcity()
    {
        //Fill Bank Location
        DataSet dsl = new DataSet();
        dsl = bizcl.Fillclientcity(Convert.ToInt32(Session["ClientID"]));
        ddlclcity.DataSource = dsl;
        ddlclcity.DataTextField = "City";
        ddlclcity.DataValueField = "City";
        ddlclcity.DataBind();
        ddlclcity.Items.Insert(0, new ListItem("--- Select City Location ---", "0"));
    }

    public object connection_reader(string cmdstr)
    {

        string cmdstr1 = cmdstr;

        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        SqlCommand cmd2 = new SqlCommand(cmdstr1, con);
        SqlDataReader reader;
        reader = cmd2.ExecuteReader();
        object resreader = reader;
        return resreader;
    }
    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    public void id()
    {

        string str = "Select max(CustomerID) from BizConnect_CustomerMaster";
        SqlConnection con = new SqlConnection(connStr);
        con.Open();
        SqlCommand cmd1 = new SqlCommand(str, con);
        SqlDataReader reader = (SqlDataReader)connection_reader(str);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                if (!reader.IsDBNull(0))
                {
                    string id = reader[0].ToString();
                    int nid = Convert.ToInt32(id) + Convert.ToInt32(1);
                    lblaid.Text = RandomString(4, false) + "-" + nid;

                }
                else
                {
                    string id = reader[0].ToString();
                    lblaid.Text = RandomString(4, false) + "-" + "1000";


                }
            }
        }
        reader.Close();

    }

    public DataSet getclientid()
    {
        obj_emailid = Session["EmailID"].ToString();
        DataSet ds = new DataSet();
        ds = bizconnectcust.get_clientid(obj_emailid);
        return ds;
    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        int res;
        DataSet ds = getclientid();

        if (ds.Tables[0].Rows.Count > 0)
        {
            clientid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());

        }
        else
        {
            clientid = Convert.ToInt32(Request.QueryString["cltid"].ToString());

        }



        int clientadid = Convert.ToInt32(ddlclad.SelectedValue.ToString());
        int Userid = Convert.ToInt16(Session["UserID"].ToString());
        res = bizconnectcust.Insert_Customer(lblaid.Text, clientid, clientadid, Txt_companyname.Text, Convert.ToInt32(txt_noE.Text), Convert.ToInt32(Txt_YOE.Text), Convert.ToDouble(txt_Annualturnover.Text), txt_url.Text, txt_pno.Text, txt_tno.Text, txt_cenvat.Text, txt_stax.Text, Convert.ToInt32(DDLLocation.SelectedValue), txt_cperson.Text, Txt_address.Text, Txt_city.Text, Txt_state.Text, Convert.ToInt32(txt_pincode.Text), txt_Boardno.Text, Txt_fax.Text, txt_Email.Text, Txt_country.Text, Convert.ToInt32(ddldesg.SelectedValue), txt_Mobile.Text, Userid, lblaid.Text);
        if (res == 1)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Data Saved Successfully";

        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Data Not Saved";
        }
    }


    protected void lnkbtnBulkPost_Click(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void But_Addcustomer_Click1(object sender, EventArgs e)
    {
        Txt_companyname.Text = "";
        txt_noE.Text = "";
        Txt_YOE.Text = "";
        txt_Annualturnover.Text = "";
        txt_url.Text = "";
        DDLLocation.SelectedIndex = 0;
        Txt_address.Text = "";
        Txt_city.Text = "";
        Txt_state.Text = "";
        txt_pincode.Text = "";
        txt_Boardno.Text = "";
        Txt_fax.Text = "";
        txt_Email.Text = "";
        Txt_country.Text = "";
        txt_Mobile.Text = "";
        txt_pno.Text = "";
        txt_tno.Text = "";
        txt_cenvat.Text = "";
        txt_stax.Text = "";
        txt_cperson.Text = "";
        id();
    }
    protected void ddlclcity_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataSet dscl = new DataSet();
        DataSet ds = getclientid();
        if (ds.Tables[0].Rows.Count > 0)
        {
            int clientid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            dscl = bizconnectcust.get_clientaddress(clientid, ddlclcity.SelectedValue);
        }
        else
        {
            int clientid = Convert.ToInt32(Request.QueryString["cltid"].ToString());
            dscl = bizconnectcust.get_clientaddress(clientid, ddlclcity.SelectedValue);
        }

        ddlclad.DataSource = dscl;
        ddlclad.DataTextField = "Address";
        ddlclad.DataValueField = "ClientAddressLocationID";
        ddlclad.DataBind();

    }
}