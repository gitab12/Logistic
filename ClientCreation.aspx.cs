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
using System.IO;
using System.Text;
using System.Security.Cryptography;
using System.Data.SqlClient;

public partial class ClientCreation : System.Web.UI.Page
{
    
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass bizconnect = new BizConnectClass();
    BizConnectClient bizconnectclient = new BizConnectClient();
   
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    protected void Page_Load(object sender, EventArgs e)
    {
      // if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        
        if (IsPostBack == false)
        {
            
            ChkAuthentication();
            filldesg();
            fillgender();
            //filllocation();
            fillcity();
            id();
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
    public void filldesg()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.FillDesignation();

        ddldesg.DataSource = ds;
        ddldesg.DataTextField = "Designation";
        ddldesg.DataValueField = "Designationid";
        ddldesg.DataBind();

        ddldesgreg.DataSource = ds;
        ddldesgreg.DataTextField = "Designation";
        ddldesgreg.DataValueField = "Designationid";
        ddldesgreg.DataBind();
    }
    public void fillgender()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.Get_Gender();
        ddlgender.DataSource = ds;
        ddlgender.DataTextField = "GenderName";
        ddlgender.DataValueField = "GenderID";
        ddlgender.DataBind();

    }
    public void fillcity()
    {
        //Fill Bank Location
        DataSet dsl = new DataSet();
        dsl = bizconnectclient.FillBankLocation();
        ddlcity.DataSource = dsl;
        ddlcity.DataTextField = "City";
        ddlcity.DataValueField = "City";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("--- Select City Location ---", "0"));
    }
    //public void filllocation()
    //{
    //    DataSet ds = new DataSet();
    //    ds = bizconnect.get_LocationType();

    //    DDLLocation.DataSource = ds;
    //    DDLLocation.DataTextField = "LocationType";
    //    DDLLocation.DataValueField = "LocationTypeID";
    //    DDLLocation.DataBind();
    //}

    //private string GetUniqueKey()
    //{
    //    int maxSize = 8;
    //    int minSize = 5;
    //    char[] chars = new char[62];
    //    string a;
    //    a = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    //    chars = a.ToCharArray();
    //    int size = maxSize;
    //    byte[] data = new byte[1];
    //    RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
    //    crypto.GetNonZeroBytes(data);
    //    size = maxSize;
    //    data = new byte[size];
    //    crypto.GetNonZeroBytes(data);
    //    StringBuilder result = new StringBuilder(size);
    //    foreach (byte b in data)
    //    { result.Append(chars[b % (chars.Length - 1)]); }
    //    return result.ToString();
    //}
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
        
        string str = "Select max(ClientID) from Bizconnect_clientMaster";
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
    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        //Checking wheather the email is already exist
        //-------------------------------------------------------------------------------------------------------------------------------------
        SqlConnection con1 = new SqlConnection();
        con1.ConnectionString = connStr;
        con1.Open();
        SqlDataReader mydatareader;
        //Dim con1 As New SqlConnection(ConfigurationManager.ConnectionStrings("con1").ToString)
        //con1.Open()
        SqlCommand cmdc = new SqlCommand("select emailid from bizconnect_userlogdb where EmailID='" + txt_loginid.Text + "'", con1);
        mydatareader = cmdc.ExecuteReader();
        mydatareader.Read();
        //-------------------------------------------------------------------------------------------------------------------------------------
        if (mydatareader.HasRows)
        {
            goto lbl;
        }
        else
        {

            int res = 0;
            //int g = Convert.ToInt32(ddlgender.SelectedValue);
            // int a = Convert.ToInt32(txt_age.Text);
            //int d = Convert.ToInt32(ddldesgreg.SelectedValue);
            string name = txt_middlename.Text.ToString();
            res = bizconnectclient.Insert_Client(lblaid.Text,Txt_companyname.Text, Convert.ToInt32(txt_noE.Text), Convert.ToInt32(Txt_YOE.Text), Convert.ToDouble(txt_Annualturnover.Text), txt_url.Text, txt_pno.Text, txt_tno.Text, txt_cenvat.Text, txt_stax.Text, Convert.ToInt32(DDLLocation.SelectedValue), txt_cperson.Text, Txt_address.Text,ddlcity.SelectedValue.ToString(), Txt_state.Text, Convert.ToInt32(txt_pincode.Text),txt_Boardno.Text, Txt_fax.Text, txt_Email.Text, Txt_country.Text, Convert.ToInt32(ddldesg.SelectedValue), txt_Mobile.Text, txt_loginid.Text, txt_password.Text, txt_firstname.Text, txt_middlename.Text, txt_lastname.Text, Convert.ToInt32(ddldesgreg.SelectedValue), txt_dept.Text, Convert.ToInt32(txt_age.Text), Convert.ToInt32(ddlgender.SelectedValue), txt_phone.Text, txt_mobl.Text,Convert.ToDouble(txtdunningrate.Text));
            bizconnectclient.Insert_ClientMapping();
            if (res == 1)
            {
                lblmsg.Visible = true;
                lblmsg.Text =  "<span style='color:green;'>Data Saved Successfully</span>";//"Data Saved Successfully";
                goto lbl1;
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "<span style='color:red;'>Data Not Saved</span>";//"Data Not Saved";
                goto lbl1;
            }

        }
    lbl: ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Email ID Already Exists');</script>");
    lbl1: ;
    }

}
  