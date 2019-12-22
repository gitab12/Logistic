using System;
using System.Data;
using System.Data.SqlClient;
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
using System.Security.Cryptography;

public partial class Bulkmail : System.Web.UI.Page
{

    private static string EncryptionKey = "!#853g`de";
    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
    string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    int obj_res = 0;
    int NOofAD = 0;
    string obj_From, obj_To, obj_username, obj_pwd;
    BizConnectClass obj_class = new BizConnectClass();

    DataSet ds = new DataSet();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_EmailID;
        String cc = "";
        string obj_Rid = "0";
        ArrayList arr = new ArrayList();
        //Email Settings from Web Config
        string obj_FromEmail = "ebid@scmbizconnect.com";//ConfigurationManager.AppSettings.Get("fromemailid").ToString();
        string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
        string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
        string obj_Password = "ebidding";//ConfigurationManager.AppSettings.Get("Password").ToString();
        string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
        string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
        string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
        string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
        Boolean SMTPUseSSL;
        string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
        //

        obj_EmailID = "Nil";
        //---------------------------------------------------
        //For EBidding

        string FileName;
        FileName = "InviteforQuote.html";//Path.GetFileName(obj_HtmlPath);
        StreamReader streamReader;

        streamReader = File.OpenText(Server.MapPath(@"Documents\" + FileName));
        string contents = streamReader.ReadToEnd();
        streamReader.Close();

        //---------------------------------------------------------
        ds = new DataSet();
        ds = obj_class.get_EmailIDByRID();
        //for (int i = 0; i <=ds.Tables[0].Rows.Count - 1; i++)
       for (int i = 0; i <= 0; i++)
        {
            obj_EmailID = "nanda@aarmsvaluechain.com";
            obj_Rid = "345";
            obj_pwd = "nanda";
           // obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();

            //obj_Rid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            //obj_pwd = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            //obj_Message = "Dear Sir/Madam,<br/>Greetings, Sincere thanks for participating in E-Bidding process carried out on behalf of  M/s Wipro Consumer Products reverse auction.<br/><br/> We are pleased to inform you that you have qualified for the Live Bidding which is scheduled on 4th february 2014(Tuesday) from 10.30 AM Onwards.<br/><br/><br/>Your Userid and Password along with the access URL is giver below<br/><b>URL: <a href=http://www.scmjunction.com>www.scmjunction.com</a><br/>UserName:" + obj_EmailID.ToString() + "</br>Password:" + obj_pwd.ToString() + "</br><br/><br/>Our helpdesk will communicate with you today and train you on the bidding process.You can also call/speak to Mr. Vinay Singh- 09739870001 or Mr. Shashidhar : 09980823571 for any further clarification. <br/><br/><a href=http://www.scmbizconnect.com/Documents/wiproTermsandCondition.docx> View Terms and Conditions</a><br/><a href=http://www.scmbizconnect.com/Documents/due-diligence-signoff1.docx> Download DueDiligence Template</a><br/> Thank You,<br/>Web Master,<br> SCM Junction<br/>";
            obj_Message = contents.Replace("webaccesslink", "<a href=http://www.scmjunction.com/BidQuotePrice.aspx?Lid=" + Server.UrlEncode(Encrypt(obj_Rid)) + ">Click here for Quote</a>");

            //   obj_Message = "Dear sir/madam,<br/>We Sincerely thank you for participating in E-Bidding on behalf of our client.<br/>We have posted the expected rebid price for your kind consideration and confirmation.<a href=http://www.scmjunction.com/Rebid.aspx?Lid=" + obj_Rid + ">Please Click the link to ReBid your Quotes </a><br/>Your Confirmation is expected before 6pm on 19/Apr/2012.<br/>Please visit:<a href=http://www.scmjunction.com>www.scmjunction.com</a><br/> <br/><br/>Thank You,<br/>Web Master,<br> SCM Junction<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
            obj_AttachmentPath = "";//Server.MapPath(@"Documents\SCM-Junction-summary.doc");
            //DataSet dsc = new DataSet();
            //dsc = obj_class.get_CCsByRID(Convert.ToInt32(obj_Rid));
            //if (dsc.Tables[0].Rows.Count > 0)
            //{
            //    for (int j = 0; j <= dsc.Tables[0].Rows.Count - 1; j++)
            //    {

            //        cc = dsc.Tables[0].Rows[j].ItemArray[1].ToString() + "," + cc;
            //    }
            //}
            //Declaration Section for AARMEmail Control
            AARMEmail.EmailControl em = new AARMEmail.EmailControl();
            obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, cc, "", obj_FromEmail, obj_BounceBakEmail, "Reverse Auction Cargill -Road Transport", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
            //obj_resp = 1;


            //AARMEmail.EmailControl em = new AARMEmail.EmailControl();
            //em.SendEmail("nandha@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "", "", "New ADs posted in scmjunction", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

            //obj_resp = 1;
        }
        if (obj_resp == 1)
        {
            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Mails sent successfully!');", true);
        }

    }

    public string Encrypt(string Input)
    {
        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            Byte[] inputByteArray = Encoding.UTF8.GetBytes(Input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }



}