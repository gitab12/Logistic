using SMSAPI3_5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

/// <summary>
/// Summary description for SMSR
/// </summary>
public class SMSR
{
    private WebProxy objProxy1 = null;
    public static string Send_smsR(string username, string password, string channel, string DCS, string flashsms, string mobile_no, string message, string unicode, string senderid, string route, string url)
    {
        SMSAPI obj = new SMSAPI();
        //SMSSend obj = new SMSSend();
        string strPostResponse="";
        strPostResponse = obj.senssms(username, password, channel, DCS, flashsms, mobile_no, message, unicode, senderid, route, url);

        return ("Server Response " + strPostResponse);
    }
}