using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using ExponantAARMSMS;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;

public partial class Mails : System.Web.UI.Page
{
    MailClass obj_mail = new MailClass();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    int j = 0;
     BizConnectClass obj_class = new BizConnectClass();
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


    protected void ButMAIL_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();

            ds = obj_mail.Transporter_RoutePricestatus();
            SendRebidMail(ds);
        }
        catch (Exception ex)
        {
        }
    }

    public int SendRebidMail(DataSet ds)
    {
        try
        {
            //Email Settings from Web Config
            string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid").ToString();
            string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
            string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
            string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
            string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
            string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
            string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
            string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
            Boolean SMTPUseSSL;
            string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
            string obj_Message = "";
            string BodyMiddle = "";
            string BodyHeader = "";
            string BodyFooter = "";
            string Transportername = "";
            string obj_EmailID = "";
            string Body = "";
            string obj_From = "";
            string obj_To = "";

            string obj_LowestPrice = "";


            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            //for (int i = 0; i <= 4 - 1; i++)
            {

                obj_From = ds.Tables[0].Rows[i].ItemArray[1].ToString().Trim();

                obj_To = ds.Tables[0].Rows[i].ItemArray[2].ToString().Trim();
                obj_EmailID = ds.Tables[0].Rows[i].ItemArray[8].ToString().Trim();
                obj_LowestPrice = ds.Tables[0].Rows[i].ItemArray[7].ToString().Trim();

                BodyHeader = "<table bgcolor=white bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><font size=2 color=#003366><strong>From</font><font size=2 color=Maroon></strong></font></td><td align=center><font size=2 color=#003366><strong>To</strong></font></td><td align=center><font size=2 color=#003366><strong>Truck Type</strong></font></td><td align=center><font size=2 color=#003366><strong>Capacity</strong></font></td><td align=center><font size=2 color=#003366><strong>Encl.Type</strong></font></td><td align=center><font size=2 color=#003366><strong>Your Price</strong></font></td><td align=center><font size=2 color=#003366><strong>Lowest Bid</strong></font></td><td align=center><font size=2 color=#003366><strong>Quote Level</strong></font></td></tr>";


                for ( j = i; j <= ds.Tables[0].Rows.Count - 1; j++)
                {
                    if (obj_EmailID.ToString().Trim() == ds.Tables[0].Rows[j].ItemArray[8].ToString().Trim())
                    {
                        if ((Convert.ToInt32(ds.Tables[0].Rows[j].ItemArray[6].ToString().Trim()) > Convert.ToInt32(ds.Tables[0].Rows[j].ItemArray[7].ToString().Trim())))
                        {
                            BodyMiddle += "<tr><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[1].ToString().Trim() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[2].ToString().Trim() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[3].ToString().Trim() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[5].ToString().Trim() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[4].ToString().Trim() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[6].ToString().Trim() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[j].ItemArray[7].ToString().Trim() + "</font></td><td align=center><font size=2><a href=http://www.scmjunction/Quotinglevel.aspx?Fromloc=" + ds.Tables[0].Rows[j].ItemArray[1].ToString().Trim() + "&Toloc=" + ds.Tables[0].Rows[j].ItemArray[2].ToString().Trim() + "&Price=" + ds.Tables[0].Rows[j].ItemArray[7].ToString().Trim() + "&Rid=" + ds.Tables[0].Rows[j].ItemArray[9].ToString().Trim() + "&TT=" + ds.Tables[0].Rows[j].ItemArray[10].ToString().Trim() + "&ET=" + ds.Tables[0].Rows[j].ItemArray[11].ToString().Trim() + "&CY=" + ds.Tables[0].Rows[j].ItemArray[5].ToString().Trim() + ">Click to view your level</a></font></td></tr>";


                        }
                    }
                    else
                    {

                        i = j - 1;
                     goto n;
                       
                    }

                }
            n:
                if (j == ds.Tables[0].Rows.Count)
                {
                    i = ds.Tables[0].Rows.Count;
                }
                BodyFooter = "</table><br><br>Best Regards,<br>SCM Junction<br><a href=http://www.scmjunction.com>www.scmjunction.com</a><br><br>";

                //Declaration Section for AARMEmail Control
                AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                Body = "Dear Sir,<br>We sincerely thank you for the Quote against our Trip Plan.  We are sharing with you, the Quotes received by us, from other various contacts.  This will help you in assessing the level at which you are placed, and will help you, in re-estimating your quote. <br>Looking forward to get your action plan for taking the project further.";
                Body = Body + BodyHeader + BodyMiddle + BodyFooter;
                em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Revised Quote", Body.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                BodyHeader = "";
                BodyMiddle = "";
                BodyFooter = "";



            }

            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Mail Send Successfully');", true);
        }

        catch (Exception ex)
        {
        }
        return 0;
    }
    protected void ButSendRebid_Click(object sender, EventArgs e)
    {
    SendReBidEmailALL();
    }

    public Int32 SendReBidEmailALL()
    {
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_EmailID;
        String cc = "";
        string obj_Rid = "0";
        ArrayList arr = new ArrayList();
        //Email Settings from Web Config
        string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid").ToString();
        string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
        string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
        string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
        string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
        string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
        string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
        string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
        Boolean SMTPUseSSL;
        string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
        //

        obj_EmailID = "Nil";
       string  obj_pwd = "Nil";
        // arr.Clear();
        // arr = obj_class.get_NameByPostByID(Convert.ToInt32(Session["UserID"].ToString()));

        //if (arr[1].ToString() != "0")
        //{
        // String obj_FullName = arr[0].ToString();
        //obj_Message = "Thank you for posting your Ad [" + obj_AdID + "] in scmjunction.com";
        //String x_AdID = obj_AdID;
        // obj_AdID = Regex.Replace(obj_AdID, "#", "X");
        DateTime obj_PostedDate = new DateTime();
        obj_PostedDate = DateTime.Now.Date;
        String dt;
        dt = obj_PostedDate.ToString("dd-MMM-yyyy");
        String obj_AdType;
        String Body = "";
        String BodyHeader = "";
        String BodyMiddle = "";
        String BodyFooter = "";
        obj_AdType = "Wanted Ads";
        
            //---------------------------------------------------------
        try{
       
           DataSet  ds = new DataSet();
            ds = obj_class.get_EmailIDByRID();
            for (int i = 0; i <=ds.Tables[0].Rows.Count - 1; i++)
           // for (int i = 0; i <= 0; i++)
            {
                //obj_EmailID = "nandha@aarmscmsolutions.com";
               obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                obj_Rid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                obj_pwd = ds.Tables[0].Rows[i].ItemArray[2].ToString();
             string obj_trans=ds.Tables[0].Rows[i].ItemArray[3].ToString().Replace(" ","_");
                string FileName;
                FileName = "ReBid.htm";//Path.GetFileName(obj_HtmlPath);
                StreamReader streamReader;

                streamReader = File.OpenText(Server.MapPath(@"Documents\" + FileName));
                string contents = streamReader.ReadToEnd();
                streamReader.Close();
				String ID=obj_EmailID.ToString()+" Password: "+obj_pwd.ToString();

               
                obj_Message = contents.Replace("UN", ""+ ID.ToString() +"");
                //obj_Message = contents.Replace("Pwd", ""+ obj_pwd.ToString() +"");
              
                DataSet dsc = new DataSet();
                 dsc = obj_class.get_CCsByRID(Convert.ToInt32(obj_Rid));
                  cc="";
                if (dsc.Tables[0].Rows.Count > 0)
                {
               
                    for (int j = 0; j <= dsc.Tables[0].Rows.Count - 1; j++)
                    {

                        cc = dsc.Tables[0].Rows[j].ItemArray[1].ToString() + "," + cc;
                    }
                }
                //Declaration Section for AARMEmail Control
                AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                 em.SendEmail(obj_EmailID, "ebid@scmbizconnect.com", "ebid123456", cc, "connect@scmjunction.com", "connect@scmjunction.com", obj_BounceBakEmail, "Invitation For Online E-Bidding", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                obj_resp = 1;


                //AARMEmail.EmailControl em = new AARMEmail.EmailControl();
               // em.SendEmail("nandha@aarmscmsolutions.com", "ebid@scmbizconnect.com", "ebid123456", "g.jagan@aarmscmsolutions.com", "connect@scmjunction.com", "", "", "Invitation For Online E-Bidding", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                // obj_resp = 1;
            }
            if (obj_resp == 1)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Mails sent successfully!');", true);
            }
        }
        catch (Exception err)
        {
            obj_resp = 3;
        }
        // }
        return obj_resp;
    }

}
