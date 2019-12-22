using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SMS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Random generator = new Random();
        String r = generator.Next(0, 1000000).ToString("D6");
        string username = "aarscm";
        string password = "demo1234";
        string channel = "TRANS";
        string DCS = "0";
        string flashsms = "0";
        string mobile_no = "919980777576";
        string message = "MY API with dll server code is Rakesh: " + r;
        string unicode="0";
        string senderid = "aarmsa";
        string route = "2";
        string url = "http://cannyinfotech.in/api/mt/SendSMS?";

        SMSR.Send_smsR(username, password, channel, DCS, flashsms, mobile_no, message, unicode, senderid, route, url);
    }
}