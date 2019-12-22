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

public partial class Contactus : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    UserControl obj_left;
    BizConnectClient bizconnectclient = new BizConnectClient();
    protected void Page_Load(object sender, EventArgs e)
    {
        ChkAuthentication();
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

    protected void Button2_Click(object sender, EventArgs e)
    {
        int res;
        String str = "";
        if (CheckBox1.Checked == true)
        {
            if (str == "")
                str = "2";
            else
                str += "," + "2";
        }
        if (CheckBox2.Checked == true)
        {
            if (str == "")
                str = "3";
            else
                str += "," + "3";
        }
        if (CheckBox3.Checked == true)
        {
            if (str == "")
                str = "6";
            else
                str += "," + "6";
        }
        if (CheckBox4.Checked == true)
        {
            if (str == "")
                str = "5";
            else
                str += "," + "5";
        }
        if (CheckBox5.Checked == true)
        {
            if (str == "")
                str = "4";
            else
                str += "," + "4";


        }
        if (CheckBox6.Checked == true)
        {
            if (str == "")
                str = "7";
            else
                str += "," + "7";

        }

        res = bizconnectclient.Insert_Contactdetails(TxtName.Text, TextCompanyName.Text, TxtCompanyWebsite.Text, TxtEmail.Text, TxtMobile.Text, str, TextComment1.Text);
        if (res == 1)
        {
            lblcommnt.ForeColor = System.Drawing.Color.Red;
            lblcommnt.Text = "Thanks for Contacting Us.....";
            ClearValues();
        }
        else
        {
            lblcommnt.ForeColor = System.Drawing.Color.Red;
            lblcommnt.Text = "Please Correct the error and submit again....";
        }

    }
    public void ClearValues()
    {
        TxtName.Text = "";
        TextCompanyName.Text = "";
        TxtCompanyWebsite.Text = "";
        TxtEmail.Text = "";
        TxtMobile.Text = "";
        TextComment1.Text = "";
        CheckBox1.Checked = false;
        CheckBox2.Checked = false;
        CheckBox3.Checked = false;
        CheckBox4.Checked = false;
        CheckBox5.Checked = false;
        CheckBox6.Checked = false;
        

    }
}