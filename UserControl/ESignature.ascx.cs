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
using System.Net;

public partial class UserControl_ESignature : System.Web.UI.UserControl
{
    ESignature obj_Esign = new ESignature();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Butsubmit_Click(object sender, EventArgs e)
    {
        DataSet ds = obj_Esign.EsignatureVerification(txtUserID.Text, txtPassword.Text);
        if (ds.Tables[0].Rows.Count > 0)
        {
            //ECode Generation
            int Ecode = Esignaturecode();
            Session["ECode"] = Ecode.ToString();
            //Update Code in Database
            int Upt = obj_Esign.Update_ESignatureCode(Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0].ToString()), Ecode);

            if (Upt == 1)
            {
                txtUserID.Visible = false;
                txtPassword.Visible = false;
                Butsubmit.Visible = false;
                txtcode.Visible = true;
                ButSign.Visible = true;
                //Send SMS to Mobile
                //string obj_UID = ConfigurationManager.AppSettings.Get("Way2SMSUID").ToString();
                //string obj_Password = ConfigurationManager.AppSettings.Get("Way2SMSPassword").ToString();
                //SMSCtrl.ExponantSendSMS(obj_UID, obj_Password, ds.Tables[0].Rows[0].ItemArray[2].ToString(), "Security Code for Esign:" + Ecode.ToString(), "N");
                try
                {
                    string result = "";
                    string mobile1 = ds.Tables[0].Rows[0].ItemArray[2].ToString();
                    string message1 = "ESign Code: " + Ecode.ToString();
                    string username1 = "aarmscm";
                    string password1 = "demo1234";
                    string senderid = "AARMSA";
                    string domian1 = "sms.cannyinfotech.com";
                    if (mobile1 != "")
                    {
                        result = apicall("http://" + domian1 + "/sendsms.jsp?user=" + username1 + "&password=" + password1 + "&mobiles=91" + mobile1 + "&sms=" + message1 + "&unicode=0&senderid=" + senderid + "&version=3");
                    }
                    if (!result.StartsWith("Wrong Username or Password"))
                    {
                    }
                    else
                    {
                    }
                }
                catch
                {
                }




                Session["ImageID"] = ds.Tables[0].Rows[0].ItemArray[0].ToString();
                Session["FName"] = ds.Tables[0].Rows[0].ItemArray[4].ToString();
                //Send Email
                AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
                mail.SendEmail(ds.Tables[0].Rows[0].ItemArray[1].ToString(), "thermax@scmbizconnect.com", "thermax123", "", "", "", "thermax@scmbizconnect.com", "ESign Security Code", "The Security Code for Esign:'" + Ecode.ToString() + "'", System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            }
        }
        else
        {

            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invalid UserID and Password');", true);
        }
    }
    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
            StreamReader sr = new StreamReader(httpres.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            return results;
        }
        catch
        {
            return "0";
        }
    }
    public int Esignaturecode()
    {
        var random = new Random(System.DateTime.Now.Millisecond);
        int randomNumber = random.Next(1, 500000);
        return randomNumber;

    }
    protected void ButSign_Click(object sender, EventArgs e)
    {
        try
        {
            Session["Code"] = txtcode.Text;
            SignatureImage.ImageUrl = "ESignatureImage.ashx?ImageID=" + Session["ImageID"].ToString() + "&Code=" + txtcode.Text;
            if (Session["Code"].ToString() == Session["ECode"].ToString())
            {
                SignatureImage.Visible = true;
                ButSign.Visible = false;
                lblmsg.Text = "Mr." + Session["FName"].ToString() + " signed on" + DateTime.Now.ToString();
                lblmsg.Visible = true;
                txtcode.Visible = false;
                Session["SignID"] = Session["ImageID"].ToString();
            }
            else
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Invalid Code');", true);
            }
        }
        catch (Exception err)
        {

        }

    }
}