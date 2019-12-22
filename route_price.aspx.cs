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

public partial class route_price : System.Web.UI.Page
{
    BizConnectClass cls = new BizConnectClass();
    Class_City obj_cls = new Class_City();
    static DataSet ds;
    static SqlDataAdapter da;
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string page = ConfigurationManager.AppSettings["Title"];
    string rep = "";
    string month, year;
    int citydistid = 0;
    double costperkm = 0.0;
 string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    SqlConnection cn;
    protected void Page_Load(object sender, EventArgs e)
    {
    
     if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
        {
        if (!IsPostBack)
        {
        ChkAuthentication();
            fill_transportername();
            fill_trucktype();
            fill_enclosuretype();
            DataSet dsf = new DataSet();
            dsf = cls.get_SourceCities();
            ddlfrom.DataSource = dsf;
            ddlfrom.DataTextField = "CityName";
            ddlfrom.DataValueField = "MasterCityID";
            ddlfrom.DataBind();
            ddlfrom.Items.Insert(0, new ListItem("--- From Location ---", "0"));


            DataSet dst = new DataSet();
            dst = cls.get_SourceCities();
            ddlto.DataSource = dst;
            ddlto.DataTextField = "CityName";
            ddlto.DataValueField = "MasterCityID";
            ddlto.DataBind();
            ddlto.Items.Insert(0, new ListItem("--- To Location ---", "0"));
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

    ////To bind the Team members  from  aarms.Teammaster
    public void fill_transportername()
    {

        try
        {

            SqlConnection conn = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from aarmjunction.dbo.scmjunction_registration order by CompanyName ";
           // Drp_transportname.Text = Session["name"].ToString();
            cmd.Connection = conn;

            conn.Open();

            Drp_transportname.DataSource = cmd.ExecuteReader();
            Drp_transportname.DataValueField = "rid";  
            Drp_transportname.DataTextField = "CompanyName";
            Drp_transportname.DataBind();

        }

        catch (Exception ex)
        {

            Response.Write(ex.StackTrace);

        }

    }

    /// Bind Enclosure Type
    public void fill_enclosuretype()
    {

        try
        {

            SqlConnection conn = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select  EnclosureType,EnclosureTypeID  from bizconnect.dbo.BizConnect_EnclosureTypeMaster order by EnclosureType";
            // Drp_transportname.Text = Session["name"].ToString();
            cmd.Connection = conn;

            conn.Open();

            Drp_enclosure.DataSource = cmd.ExecuteReader();
            Drp_enclosure.DataValueField = "EnclosureTypeID";
            Drp_enclosure.DataTextField = "EnclosureType";


            Drp_enclosure.DataBind();

        }

        catch (Exception ex)
        {

            Response.Write(ex.StackTrace);

        }

    }
    /// </summary>


    public void fill_trucktype()
    {

        try
        {

            SqlConnection conn = new SqlConnection(constr);

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select distinct TruckType,TruckTypeID   from  BizConnect_TruckTypeMaster   order by TruckType asc";
           // Drp_transportname.Text = Session["TruckTypeID"].ToString();
            cmd.Connection = conn;

            conn.Open();

            Drp_trucktype.DataSource = cmd.ExecuteReader();

            Drp_trucktype.DataTextField = "TruckType";
            Drp_trucktype.DataValueField = "TruckTypeID";
            Drp_trucktype.DataBind();

        }

        catch (Exception ex)
        {

            Response.Write(ex.StackTrace);

        }

    }


    protected void btn_submit_Click(object sender, EventArgs e)
    {
        int res = 0;
        SqlConnection con = new SqlConnection(constr);
        con.Open();
        SqlCommand cmd = new SqlCommand("Insert_BizConnect_routeprice", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Transporter_ID", Drp_transportname.SelectedValue );
        cmd.Parameters.AddWithValue("@Transporter_Name", Drp_transportname.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@From_Loc", ddlfrom.SelectedItem.Text.ToString());
        cmd.Parameters.AddWithValue("@To_Loc", ddlto.SelectedItem.Text.ToString());
        cmd.Parameters.AddWithValue("@Trucktype_ID",Drp_trucktype.SelectedValue);
        cmd.Parameters.AddWithValue("@Enclosure_ID", Drp_enclosure.SelectedValue);
        cmd.Parameters.AddWithValue("@Capacity", Convert.ToDouble(txt_capacity.Text));
        cmd.Parameters.AddWithValue("@Unit", Drp_capacity.SelectedItem.Text);
        cmd.Parameters.AddWithValue("@Oneway_price", txt_oneway.Text);
        cmd.Parameters.AddWithValue("@Toway_price", txt_twowayprice.Text);
        cmd.ExecuteNonQuery();

        DataSet ds = new DataSet();
        ds = obj_cls.get_RouteID(Convert.ToInt32(Drp_transportname.SelectedValue.ToString()), ddlfrom.SelectedItem.Text.ToString(), ddlto.SelectedItem.Text.ToString());
        int routeid = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());


        try
        {
            ArrayList arr = new ArrayList();
            arr = cls.get_citydistance(Convert.ToInt32(ddlfrom.SelectedValue.ToString()), Convert.ToInt32(ddlto.SelectedValue.ToString()));
            if (Convert.ToInt32(arr[4].ToString()) > 0)
            {
                 citydistid = Convert.ToInt32(arr[4].ToString());




                 costperkm = (Convert.ToDouble(txt_oneway.Text)) / (Convert.ToDouble(arr[3].ToString()));
            }

            else
            {
                 citydistid = 0;
                 costperkm = 0.0;
            }
        }
        catch { }
       

        res = obj_cls.Insert_Bizconnect_RouteChartMaster(routeid, Convert.ToInt32(Drp_transportname.SelectedValue.ToString()), ddlfrom.SelectedItem.Text.ToString(), ddlto.SelectedItem.Text.ToString(), Convert.ToInt32(Drp_trucktype.SelectedValue.ToString()), citydistid, costperkm, costperkm);

        if (res == 1)
        {
            lbl_message.Text = "Route Price Submitted Successfully";
            clear();
        }
        else
        {
            lbl_message.Text = "Not Inserted";
        }

       
    }

    public void clear()
    {

        ddlfrom.SelectedIndex = 0;
        ddlto.SelectedIndex = 0;
        txt_capacity.Text="";
        txt_oneway.Text="";
        txt_twowayprice.Text="";
        txtdist.Text = "";

    }


    protected void btn_view_Click(object sender, EventArgs e)
    {
        OpenNewWindow();
    }

    public void OpenNewWindow()
    {


        ClientScript.RegisterStartupScript(this.GetType(), "OpenWin", "<script>window.open('rpt_route_price.aspx', 'mynewwin', 'width=950,height=350,scrollbars=yes,toolbar=1')</script>");
    }
    protected void ddlto_SelectedIndexChanged(object sender, EventArgs e)
    {
        ArrayList arr = new ArrayList();
        arr = cls.get_citydistance(Convert.ToInt32(ddlfrom.SelectedValue.ToString()), Convert.ToInt32(ddlto.SelectedValue.ToString()));
        if (arr[0].ToString() == "1")
        {
            txtdist.Text = arr[3].ToString()+" "+"kms";
        }
        else
        {
            txtdist.Text = "0";

        }
    }
}
