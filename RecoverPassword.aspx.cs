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

public partial class RecoverPassword : System.Web.UI.Page
{

    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;



    string connect = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string tableheader = "";
    string body = "";
    string summary = "";
    string getpwd = "";

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
        //obj_Navihome.Visible = true;

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
        // obj_Navi.Visible = true;
        //obj_Navihome.Visible = false;
    }




    protected void btnpwd_Click(object sender, EventArgs e)
    {
        try
        {
            SqlConnection conn = new SqlConnection(connect);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select Password from Bizconnect.dbo.BizConnect_UserLogDB where EmailID='" + txt_Email.Text + "'";
            cmd.Connection = conn;
            conn.Open();
            getpwd=  cmd.ExecuteScalar().ToString();
            if (getpwd!=null)
            {
                SendMail();
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Password recovered, Check your Email');</script>");

        }
        catch (Exception ex)
        {
           lblmsg.Text = "You don't have ScmBizconnect Account!";
        }
        txt_Email.Text = "";
    }

    public void SendMail()
    {
         try
           {
                tableheader = "";
                body = "";
                summary = "";
                string emailtext = null;
                body += "<font size='3'>Dear Sir/Madam,</font>";
                body += "\n";
                body += "\n";
                body += "<font size='3'>As requested, the login password for SCMBizconnect is given below:</font>";
                body += "\n";
                body += "\n";
                body += "<font size='3'>LoginID:</font>" + txt_Email.Text;
                body += "\n";
                body += "<font size='3'>Password:</font>" + getpwd.ToString();
                body += "\n";
                body += "\n";
                emailtext += "<font size='3'>C/o AARMS Value Chain Pvt. Ltd.</font>";
                emailtext += "\n";
                emailtext += "<font size='3'>#211, Temple Street,9th Main Road</font>";
                emailtext += "\n";
                emailtext += "<font size='3'>BEML 3rd stage,RajarajeshwariNagar,</font>";
                emailtext += "\n";
                emailtext += "<font size='3'>Bangalore – 560098</font>";
                string Subject = null;
                Subject = "Passowrd recovery for SCMBizconnect";                      
                string recipient = txt_Email.Text;
                summary = "<pre>" + body + tableheader + emailtext;
                System.Net.Mail.MailMessage MyMailMessage = new System.Net.Mail.MailMessage("aarmsuser@scmbizconnect.com", recipient, Subject, summary);
                MyMailMessage.IsBodyHtml = true;
                //Proper Authentication Details need to be passed when sending email from gmail
                System.Net.NetworkCredential mailAuthentication = new System.Net.NetworkCredential("aarmsuser@scmbizconnect.com", "aarmsuser");
                //Smtp Mail server of Gmail is "smpt.gmail.com" and it uses port no. 587
                //For different server like yahoo this details changes and you can
                //get it from respective server.
                System.Net.Mail.SmtpClient mailClient = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
                //Enable SSL
                mailClient.EnableSsl = true;
                mailClient.UseDefaultCredentials = false;
                mailClient.Credentials = mailAuthentication;
                mailClient.Send(MyMailMessage);
                MyMailMessage.Dispose();
              }
              catch (Exception ex)
              {
                  
              }
                
    }


}