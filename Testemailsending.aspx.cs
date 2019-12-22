using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Testemailsending : System.Web.UI.Page
{
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btn_sendmail_Click(object sender, EventArgs e)
    {
        Session["AID"] = "Test";
        string txtjustification = "Test";
        string ApprovalPerson = "geethamiisky@gmail.com";
        //string LogisticsManager1 = "thermaxbabu@gmail.com" + "," + "babu.thomas@thermaxglobal.com";
        string LogisticsManager1 = "thermaxbabu@gmail.com" ;
        string body = "Test";//" <table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 650px; display: block !important;max-width: 600px !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/Madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>The below mention collection note required your approval.\n\n Note:" + txtjustification + " </td></tr><tr><td style=' padding: 0 0 20px;'><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;'href=http://www.scmbizconnect.com/ColllectionNoteApproval.aspx?Confno=4&CollectionNoteID=" + Session["AID"].ToString() + ">Please click here for approve the collectionnote</a></center> </br><tr><td style='padding: 0 0 20px;'>Thank You,</td></tr> <tr><td style='width: 656px;' ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";
        try
        {
            mail.SendEmail(LogisticsManager1.ToString(), "thermax@scmbizconnect.com", "thermax123", ApprovalPerson, "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
            lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Message Sent Sucessfully" + "465");//"465";
        }
        catch
        {
            mail.SendEmail(LogisticsManager1.ToString(), "thermax@scmbizconnect.com", "thermax123", ApprovalPerson, "", "connect@scmjunction.com", "thermax@scmbizconnect.com", "Collection Note- " + txtCNNumber.Text + "", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "587", "2", "1", true, "");
            lbl_msg.Text = Resources.Resource.alert_success.Replace("{@message}", "Message Sent Sucessfully" + "587");
        }
        //rakesh 587
       
    }
}