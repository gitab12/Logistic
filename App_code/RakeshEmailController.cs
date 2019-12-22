using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for RakeshEmailController
/// </summary>
public class RakeshEmailController
{
    string server = "smtp.gmail.com";
    string username = "thermaxbabu@gmail.com";
    string password = "thermax123";
    int port = 587;
    public bool Send_Mail(string Sender, string Receiver, string Subject, string Message, bool HTML, string Sender_Name)
    {

        MailMessage msg = new MailMessage();
        try
        {
            msg.From = new MailAddress("" + Sender + "", Sender_Name);
            msg.To.Add("" + Receiver + "");
            msg.Subject = Subject;
            msg.Body = Message;
            msg.IsBodyHtml = HTML;
            msg.Priority = MailPriority.Normal;
            SmtpClient sc = new SmtpClient(server);
            sc.Port = port;
            sc.EnableSsl = true;
            sc.UseDefaultCredentials = true;
            sc.Credentials = new NetworkCredential(username, password);
            sc.Send(msg);
            return true;

        }
        catch (Exception ex)
        {
            return false;

        }
    }
}