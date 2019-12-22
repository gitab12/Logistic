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

public partial class AddBranches : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    BizConnectClass bizconnect = new BizConnectClass();
    BizConnectClient bizcl = new BizConnectClient();
    string obj_emailid;
    string obj_clientid, obj_customerid;
    protected void Page_Load(object sender, EventArgs e)
    {
        obj_emailid = Session["EmailID"].ToString();
        DataSet ds = new DataSet();
        ds = bizconnect.get_clientname(obj_emailid);
        lblcname.Text = ds.Tables[0].Rows[0][0].ToString();
        obj_clientid = ds.Tables[0].Rows[0][1].ToString();
        Pnldisp.Visible = true;
        if (IsPostBack == false)
        {
            ChkAuthentication();
            filllocation();
            filldesg();
            fillcity();
            fillgender();
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
    protected void client_CheckedChanged(object sender, EventArgs e)
    {
        lblcustomername.Visible = false;
        ddlcustname.Visible = false;
        customer.Checked = false;
        Pnldisp.Visible=true;

    }
    protected void customer_CheckedChanged(object sender, EventArgs e)
    {
        client.Checked = false;
        lblcustomername.Visible = true;
        ddlcustname.Visible = true;
        fillcustomer();
        Pnldisp.Visible = false;

    }
    public void filllocation()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.FillLocationType();

        DDLLocation.DataSource = ds;
        DDLLocation.DataTextField = "LocationType";
        DDLLocation.DataValueField = "LocationTypeID";
        DDLLocation.DataBind();
    }
    public void fillcustomer()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.get_customername(obj_emailid);
        ddlcustname.DataSource = ds;
        ddlcustname.DataTextField = "CompanyName";
        ddlcustname.DataValueField = "CustomerID";
        ddlcustname.DataBind();



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

    public void filldesg()
    {
        DataSet ds = new DataSet();
        ds = bizconnect.FillDesignation();

        ddldesg.DataSource = ds;
        ddldesg.DataTextField = "Designation";
        ddldesg.DataValueField = "Designationid";
        ddldesg.DataBind();

        DataSet ds1 = new DataSet();
        ds1 = bizconnect.FillDesignation();

        ddldesgreg.DataSource = ds1;
        ddldesgreg.DataTextField = "Designation";
        ddldesgreg.DataValueField = "Designationid";
        ddldesgreg.DataBind();

    }

    public void fillcity()
    {
        //Fill Bank Location
        DataSet dsl = new DataSet();
        dsl = bizcl.FillBankLocation();
        ddlcity.DataSource = dsl;
        ddlcity.DataTextField = "City";
        ddlcity.DataValueField = "City";
        ddlcity.DataBind();
        ddlcity.Items.Insert(0, new ListItem("--- Select City Location ---", "0"));
    }

    protected void Btn_submit_Click(object sender, EventArgs e)
    {
        if (client.Checked == true)
        {
            int res;
            
            res = bizcl.Insert_Clientbr(Convert.ToInt32(obj_clientid), Convert.ToInt32(DDLLocation.SelectedValue), Txt_address.Text,ddlcity.SelectedValue, Txt_state.Text, Convert.ToInt32(txt_pincode.Text), txt_Boardno.Text, Txt_fax.Text, txt_Email.Text, Txt_country.Text, txt_cperson.Text, Convert.ToInt32(ddldesg.SelectedValue), txt_Mobile.Text, txt_loginid.Text, txt_password.Text, txt_firstname.Text, txt_middlename.Text, txt_lastname.Text, Convert.ToInt32(ddldesgreg.SelectedValue), txt_dept.Text, Convert.ToInt32(txt_age.Text), Convert.ToInt32(ddlgender.SelectedValue), txt_phone.Text, txt_mobl.Text);
            bizcl.Insert_ClientMapping();
            if (res == 1)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Data saved Successfully";
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Oops Data Not saved";
            }



        }
        if (customer.Checked == true)
        {
            int res;
           
            res = bizcl.Insert_Customerbr(Convert.ToInt32(ddlcustname.SelectedValue), Convert.ToInt32(DDLLocation.SelectedValue), Txt_address.Text,ddlcity.SelectedValue, Txt_state.Text, Convert.ToInt32(txt_pincode.Text), txt_Boardno.Text, Txt_fax.Text, txt_Email.Text, Txt_country.Text, txt_cperson.Text, Convert.ToInt32(ddldesg.SelectedValue), txt_Mobile.Text);
            if (res == 1)
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Data saved Successfully";
            }
            else
            {
                lblmsg.Visible = true;
                lblmsg.Text = "Oops Data Not saved";
            }



        }

    }
    protected void ddlcustname_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
