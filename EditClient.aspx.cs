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
using System.Drawing;
using System.Data.SqlClient;

public partial class EditClient : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass obj_class = new BizConnectClass();
    SqlConnection connStrbiz = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
    SqlDataReader dr;
    int id;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ChkAuthentication();
            Panel1.Visible = false;
            id = Convert.ToInt32(Session["ClientID"].ToString());
           
            BindClient(id,Convert.ToInt32( Session["UserID"].ToString()));
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
       

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
      
    }
    public void BindClient(int id,int UID)
    {
        try
        {
            Panel1.Visible = true;
          
            //Getting ClientID On Label
           

            //Getting LocationType from BizConnect_LocationTypeMaster
            DDLLocation.DataSource = obj_class.get_LocationType();
            DDLLocation.DataTextField = "LocationType";
            DDLLocation.DataValueField = "LocationTypeID";
            DDLLocation.DataBind();

            //Getting Designation from BizConnect_DesignationMaster
            ddldesg.DataSource = obj_class.FillDesignation();
            ddldesg.DataTextField = "Designation";
            ddldesg.DataValueField = "DesignationID";
            ddldesg.DataBind();

            //Getting Designation from BizConnect_DesignationMaster
            ddldesgreg.DataSource = obj_class.FillDesignation();
            ddldesgreg.DataTextField = "Designation";
            ddldesgreg.DataValueField = "DesignationID";
            ddldesgreg.DataBind();

            //Getting Gender from BizConnect_GenderMaster
            ddlgender.DataSource = obj_class.Get_Gender();
            ddlgender.DataTextField = "GenderName";
            ddlgender.DataValueField = "GenderID";
            ddlgender.DataBind();

            //Getting Values from BizConnect_ClientMaster
            connStrbiz.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connStrbiz;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Get_BizConnect_ClientMasterAndAddressLocationALL'" + id + "',"+ UID +"";
            dr = cmd.ExecuteReader();
           // while (dr.Read() == true)
            dr.Read();
                if(dr.HasRows)
            {
                lblaid.Text = dr["ClientCode"].ToString();
                Txt_companyname.Text = dr["CompanyName"].ToString();
                txt_noE.Text = dr["NoOfEmployees"].ToString();
                txt_url.Text = dr["WebsiteURL"].ToString();
                Txt_YOE.Text = dr["YearOfEstablishment"].ToString();
                txt_Annualturnover.Text = dr["TurnOver"].ToString();
                txt_pno.Text = dr["PermenantAccountNumber"].ToString();
                txt_tno.Text = dr["TaxpayerIdentificationNumber"].ToString();
                txt_cenvat.Text = dr["CentralValueAddedTaxRegistrationNumber"].ToString();
                txt_stax.Text = dr["ServiceTaxRegistrationNumber"].ToString();
                DDLLocation.SelectedIndex  =Convert.ToInt32(dr["LocationTypeID"].ToString())-1;
                Txt_city.Text = dr["City"].ToString();
                Txt_address.Text = dr["Address"].ToString();
                Txt_state.Text = dr["State"].ToString();
                Txt_country.Text = dr["Country"].ToString();
                txt_Mobile.Text = dr["MobileNumber"].ToString();
                txt_pincode.Text = dr["PinCode"].ToString();
                Txt_fax.Text = dr["Fax"].ToString();
                txt_Email.Text = dr["CorporateEmail"].ToString();
                txt_cperson.Text = dr["ContactPerson"].ToString();
                txt_Boardno.Text = dr["BoardNo"].ToString();
                txt_Email.Text = dr["CorporateEmail"].ToString();
                txt_Email.Text = dr["CorporateEmail"].ToString();
                ddldesg.SelectedIndex = Convert.ToInt32(dr["Designation"].ToString())-1;
                txt_loginid.Text = dr["EmailID"].ToString();
                txt_password.Text = dr["Password"].ToString();
                txt_firstname.Text = dr["FirstName"].ToString();
                txt_middlename.Text = dr["MiddleName"].ToString();
                txt_lastname.Text = dr["LastName"].ToString();
                txt_dept.Text = dr["Department"].ToString();
                txt_age.Text = dr["Age"].ToString();
                txt_phone.Text = dr["Phone"].ToString();
                txt_mobl.Text = dr["Mobile"].ToString();
                ddldesgreg.SelectedIndex = Convert.ToInt32(dr["DesignationID"].ToString())-1;
                ddlgender.SelectedItem.Text = dr["GenderName"].ToString();
            }
        }
        catch (Exception ex)
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = ex.Message;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int res;
        try
        {
            //Updating BizConnect_ClientMaster
            res = obj_class.Update_BizConnect_ClientMasterALL(Convert.ToInt32(Session["ClientID"].ToString()), Txt_companyname.Text, Convert.ToInt32(txt_noE.Text.ToString()), txt_pno.Text, txt_tno.Text, txt_cenvat.Text, txt_stax.Text, Convert.ToInt32(Txt_YOE.Text.ToString()), Convert.ToInt32(txt_Annualturnover.Text.ToString()), txt_url.Text, Txt_city.Text, Txt_address.Text, Txt_state.Text, Txt_country.Text, Convert.ToInt32(txt_pincode.Text.ToString()), txt_Boardno.Text.ToString(), txt_Mobile.Text, Txt_fax.Text.ToString(), txt_Email.Text, txt_cperson.Text, Convert.ToInt32(ddldesg.SelectedValue.ToString()),Convert.ToInt32(ddldesgreg.SelectedValue.ToString()),Convert.ToInt32(DDLLocation.SelectedIndex)+1, txt_loginid.Text, txt_password.Text, txt_firstname.Text, txt_middlename.Text, txt_lastname.Text, txt_dept.Text, Convert.ToInt32(txt_age.Text.ToString()), Convert.ToInt32(ddlgender.SelectedValue.ToString()), txt_phone.Text, txt_mobl.Text,Convert.ToInt32(Session["UserId"].ToString()));
            lblmsg.ForeColor = Color.Green;
            lblmsg.Text = "Client Details Updated Successfully";
        }
        catch (Exception ex)
        {
            lblmsg.ForeColor = Color.Red;
            lblmsg.Text = ex.Message;
        }
    }
}
