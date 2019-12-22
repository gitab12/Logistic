using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ImportExport_Agencies : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    PlaceHolder maPlaceHolder2;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    ContentPlaceHolder contp;

    ImportExport obj_Class = new ImportExport();
    int resp = 0;
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
        obj_Authenticated = Session["Authenticated"].ToString();
        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        ContentPlaceHolder contp;
        contp = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
        obj_Navihome = (UserControl)contp.FindControl("navihome1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("right1");
            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");
                obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
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


    protected void btn_Submit_Click(object sender, EventArgs e)
    {
        try
        {

            obj_Class.AgencyName = txt_Agencyname .Text;
            obj_Class.ContactPerson = txt_Contactperson.Text;
            obj_Class.ContactNo = txt_Contactno.Text;
            obj_Class.EmailID = txt_Emailid.Text;
            obj_Class.Address = txt_Address.Text;
            resp = obj_Class.Bizconnect_InsertImportExportAgencyDetails();
            if (resp == 1)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Agency details inserted successfully');</script>");
                ClearFields();
            }
        }
        catch (Exception ex)
        {

        }
    }

    public void ClearFields()
    {
        txt_Agencyname.Text = "";
        txt_Contactperson.Text = "";
        txt_Contactno.Text = "";
        txt_Emailid.Text = "";
        txt_Address.Text = "";
    }

}