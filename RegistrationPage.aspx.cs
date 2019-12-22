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

public partial class RegistrationPage : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;



    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string page = ConfigurationManager.AppSettings["Title"];
    int gps =0;
    int sim = 0;
    int resp=0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
        //   obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        //obj_Navi.Visible = true;
        //  obj_Navihome.Visible = false;
    }
    public int vehicleregister(string TransporterName, int category, string VehicleOwnerName, string VehicleNo, string DriverName, int DriverAge, string DriverMobileNo, string Mobilemake, string ServiceProvider, string HASGPS, int SingleDoubleSIM)
    {
        SqlConnection conn = new SqlConnection(constr);
        conn.Open();
        SqlCommand cmd = new SqlCommand("vehicleregistration", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@TransporterName", TransporterName);
        cmd.Parameters.AddWithValue("@Category", category);
        cmd.Parameters.AddWithValue("@VehicleOwnerName", VehicleOwnerName);
        cmd.Parameters.AddWithValue("@VehicleNo", VehicleNo);
        cmd.Parameters.AddWithValue("@DriverName", DriverName);
        cmd.Parameters.AddWithValue("@DriverAge", DriverAge);
        cmd.Parameters.AddWithValue("@DriverMobileNo", DriverMobileNo);
        cmd.Parameters.AddWithValue("@Mobilemake", Mobilemake);
        cmd.Parameters.AddWithValue("@ServiceProvider", ServiceProvider);
        cmd.Parameters.AddWithValue("@HASGPS", HASGPS);
        cmd.Parameters.AddWithValue("@SingleDoubleSIM", SingleDoubleSIM);
        cmd.ExecuteNonQuery();
        conn.Close();
        resp = 1;
        return resp;
    }

    public void clear()
    {
        txttransportername.Text = "";
       
        txtvehicleownername.Text = "";
        txtvehicleno.Text = "";
        txtdrivername.Text = "";
        txtdriverage.Text = "";
        txtdrivermobno.Text = "";
        DDLMobileMake.SelectedIndex=0;
        DDLServiceProvider.SelectedIndex=0;
        ddlgps.Text = "";
        radyes.Text= "";
        radno.Text = "";
    }


    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        try
        {       
            if (radyes.Checked)
            {
                sim = 1;
            }
            else
            {
                sim = 0;
            }
            int category = 0;
            if (RadTransportCompany.Checked)
            {
                category = 1;
            }
            else if (RadTransportCompany.Checked)
            {
                category = 2;
            }
            else if (RadTransportCompany.Checked)
            {
                category=3;
            }


            resp=vehicleregister(txttransportername.Text, category , txtvehicleownername.Text, txtvehicleno.Text, txtdrivername.Text, Convert.ToInt32(txtdriverage.Text), txtdrivermobno.Text, DDLMobileMake.SelectedItem.Text, DDLServiceProvider.SelectedItem.Text, ddlgps.SelectedItem.Text, Convert.ToInt32(sim.ToString()));
            if (resp == 1)
            {
                btnsubmit.Enabled = false;
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registered  Successfully');</script>");
            }
        }

        catch (Exception ex)
        {
        }

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Registered Not Successfully');</script>");

        clear();
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        clear();
        btnsubmit.Enabled = true;
    }
}
