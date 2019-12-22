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

public partial class AddBranch : System.Web.UI.Page
{
    BizConnectClass obj_class = new BizConnectClass();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;

    protected void Page_Load(object sender, EventArgs e)
    {
          try
            {
                if (!IsPostBack)
                {
                    ddltrasportid.DataSource = obj_class.Get_BizConnect_Transporter();
                    ddltrasportid.DataTextField = "Tname";
                    ddltrasportid.DataValueField = "TID";
                    ddltrasportid.DataBind();
                    ddltrasportid.Items.Insert(0, new ListItem("--SELECT TRANSPORTER--", "0"));
                }
            }
            catch (Exception ex)
            {
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

    protected void btnsubmit_Click(object sender, EventArgs e)
    {
        int res;
        res = obj_class.Insert_Branchdetails(Convert.ToInt32(ddltrasportid.SelectedValue), txtBrnchname.Text, txtaddress.Text, txtcity.Text, txtpincode.Text, txtfname.Text, txtdesig.Text, txtmobno.Text, txtemailid.Text, "123456");
        if (res == 1)
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Data saved successfully";
        }
        else
        {
            lblmsg.Visible = true;
            lblmsg.Text = "Data not saved";
        }

        clear();

    }

    public void clear()
    {
        txtaddress.Text = "";
        txtBrnchname.Text = "";
        txtcity.Text = "";
        txtdesig.Text = "";
        txtemailid.Text = "";
        txtfname.Text = "";
        txtmobno.Text = "";
        txtpincode.Text = "";
    }
}
