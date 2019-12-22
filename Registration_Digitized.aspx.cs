using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using AARMEmail;

public partial class Registration_Digitized : System.Web.UI.Page
{
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    ESignature obj_Sign = new ESignature();
    FileUpload FileCtrl;
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
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
        SqlCommand cmdc = new SqlCommand("select EmailAddress from ESignatureRegistration where EmailAddress='" + txt_email.Text + "'", con1);
        mydatareader = cmdc.ExecuteReader();
        mydatareader.Read();
        //-------------------------------------------------------------------------------------------------------------------------------------
        if (mydatareader.HasRows)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Email ID Already Exists');</script>");
        }
        else
        {
          
       try
       {
            if (FileUpload1.HasFile)
            {
                Session["FileCtrl"] = (FileUpload)FileUpload1;
                FileCtrl = (FileUpload)Session["FileCtrl"];
            }
            else
            {
                FileCtrl = (FileUpload)Session["FileCtrl"];
            }
              
            // Read the file and convert it to Byte Array

                string filePath = FileCtrl.PostedFile.FileName;

                string filename = Path.GetFileName(filePath);

                string ext = Path.GetExtension(filename);

                string contenttype = String.Empty;
            

                //Set the contenttype based on File Extension

                switch (ext)

                {
                    case ".jpg":

                        contenttype = "image/jpg";

                        break;
                    case ".JPG":

                        contenttype = "image/JPG";

                        break;
                        case ".JPEG":

                        contenttype = "image/JPEG";

                        break;

                    case ".png":

                        contenttype = "image/png";

                        break;

                    case ".gif":

                        contenttype = "image/gif";

                        break;



                }

                if (contenttype != String.Empty)
                {

                    Stream fs = FileCtrl.PostedFile.InputStream;

                    BinaryReader br = new BinaryReader(fs);

                    byte[] bytes = br.ReadBytes((Int32)fs.Length);

                    int resp = obj_Sign.Insert_BizConnect_ESignatureRegistration(Txt_fname.Text, txt_lname.Text, Txt_designation.Text, txt_email.Text, txt_password.Text, txt_Mobile.Text, Txt_Phone.Text, Txt_address.Text, Txt_area.Text, Txt_city.Text, txt_pincode.Text, Txt_companyname.Text, txt_url.Text, bytes);
                    if (resp == 1)
                    {
                        Btn_submit.Enabled = false;
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Details Saved Successfully');</script>");
                    }
                }
       }
            catch (Exception ex)
            {
            }
        
        }
                   
       
        }
    
}
