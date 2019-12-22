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
using System.IO;
using System.Text;

public partial class Transporter : System.Web.UI.Page
{
    string obj_Authenticated, obj_emailid;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectTransporter biztrans = new BizConnectTransporter();
    BizConnectClass bizconnect = new BizConnectClass();

    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
       if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        obj_emailid = Session["EmailID"].ToString();
        if (IsPostBack == false)
        {

            ChkAuthentication();
            filldesg();
            fillloc();
            id();
        }
        }
        
          else
        {
            Response.Redirect("Index.html");
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
        ds = biztrans.get_desg();

        ddldesg.DataSource = ds;
        ddldesg.DataTextField = "Designation";
        ddldesg.DataValueField = "Designationid";
        ddldesg.DataBind();
    }
    public void fillloc()
    {
        DataSet ds = new DataSet();
        ds = biztrans.get_LocationType();

        DDLLocation.DataSource = ds;
        DDLLocation.DataTextField = "LocationType";
        DDLLocation.DataValueField = "LocationTypeid";
        DDLLocation.DataBind();
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

        string str = "Select max(TransporterID) from BizConnect_TransporterMaster";
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
        ds = biztrans.get_clientid(obj_emailid);
        return ds;
    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        int res;
        DataSet ds=getclientid();
        int clientid=Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
        res = biztrans.Insert_Transporter(lblaid.Text, clientid, Txt_companyname.Text,txt_trname.Text, Convert.ToInt32(txt_noE.Text), Convert.ToInt32(Txt_YOE.Text), Convert.ToDouble(txt_Annualturnover.Text), txt_url.Text, txt_pno.Text, txt_tno.Text, txt_cenvat.Text, txt_stax.Text, Convert.ToInt32(DDLLocation.SelectedValue), txt_cperson.Text, Txt_address.Text, Txt_city.Text, Txt_state.Text, Convert.ToInt32(txt_pincode.Text), txt_Boardno.Text, Txt_fax.Text, txt_Email.Text, Txt_country.Text, Convert.ToInt32(ddldesg.SelectedValue), txt_Mobile.Text);
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

    protected void But_Addtransporter_Click(object sender, EventArgs e)
    {

        Txt_companyname.Text = "";
        txt_noE.Text = "";
        Txt_YOE.Text = "";
        txt_trname.Text = "";
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
}
