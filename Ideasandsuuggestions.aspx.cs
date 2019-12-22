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


public partial class Ideasandsuuggestions : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    UserControl obj_left;
    UserAuthentication user = new UserAuthentication();

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
    protected void But_Submit_Click(object sender, EventArgs e)
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
                str = "1";
            else
                str += "," + "1";

        }

        res = user.Insert_Suggestions(TxtName.Text, TxtOccuption.Text, TextCompanyName.Text, TxtCompanyWebsite.Text, TxtEmail.Text,TextLocation.Text, TxtMobile.Text, TxtPhNum.Text, str,TextComment1.Text, TextComment2.Text, TextComment3.Text, TextComment4.Text, TextComment5.Text, TextComment6.Text, TextComment7.Text, TextComment8.Text);
        if (res == 1)
        {
            lblcommnt.ForeColor = System.Drawing.Color.Red;
            lblcommnt.Text = "Thanks for your valuable Ideas and Suggestions.....";
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
       TxtName.Text="";
       TxtOccuption.Text="";
       TextCompanyName.Text="";
       TxtCompanyWebsite.Text="";
       TxtEmail.Text="";
       TextLocation.Text="";
       TxtMobile.Text="";
       TxtPhNum.Text="";
       TextComment1.Text="";
       TextComment2.Text="";
       TextComment3.Text="";
       TextComment4.Text="";
       TextComment5.Text="";
       TextComment6.Text="";
       TextComment7.Text="";
       TextComment8.Text="";
       CheckBox1.Checked = false;
       CheckBox2.Checked = false;
       CheckBox3.Checked = false;
       CheckBox4.Checked = false;
       CheckBox5.Checked = false;
       CheckBox6.Checked = false;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ClearValues();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

    }
}