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
using System.Xml.XPath;
using System.Web.Services;
using System.Net;
using System.Threading;
using System.Xml;
using System.IO;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;


public partial class AKZO_OTP : System.Web.UI.Page
{
    AndroidClass ObjAndroidClass = new AndroidClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Response.Headers.Add("Response", "OK");
            if (Page.Request.Form["mode"].ToString().Equals("0"))
            {
                string value = AKZO_OTP.TOTPGenerator(Page.Request.Form["InvoiceNo"].ToString());
                int resp = ObjAndroidClass.AKZO_Process_OTP(value, Convert.ToInt32(Page.Request.Form["OID"].ToString()), 0);
                if (resp == 1)
                {
                    DataSet dealerds = new DataSet();
                    dealerds = ObjAndroidClass.GetDealerMobileNo(Convert.ToInt32(Page.Request.Form["OID"].ToString()));
                    if (dealerds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string mobile1 = dealerds.Tables[0].Rows[0]["DealerMobileNo"].ToString();
                            string message1 = "OTP for Invoice No. " + dealerds.Tables[0].Rows[0]["InvoiceNo"].ToString() + " is " + dealerds.Tables[0].Rows[0]["OTP"].ToString();
                            string username1 = "aarmscm";
                            string password1 = "demo1234";
                            string senderid = "AARMSA";
                            string domian1 = "sms.cannyinfotech.com";
                            string result = apicall("http://" + domian1 + "/sendsms.jsp?user=" + username1 + "&password=" + password1 + "&mobiles=91" + mobile1 + "&sms=" + message1 + "&unicode=0&senderid=" + senderid + "&version=3");
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
                    }
                }
                else
                {
                    Response.Headers.Add("Response", "Error1");
                }
            }
            else
            {
                DataSet dealerds = new DataSet();
                dealerds = ObjAndroidClass.GetDealerMobileNo(Convert.ToInt32(Page.Request.Form["OID"].ToString()));
                if (dealerds.Tables[0].Rows.Count > 0)
                {
                    if (dealerds.Tables[0].Rows[0]["OTP"].ToString() == Page.Request.Form["OTP"].ToString())
                    {
                        int resp = ObjAndroidClass.AKZO_Process_OTP(Page.Request.Form["OTP"].ToString(), Convert.ToInt32(Page.Request.Form["OID"].ToString()), 1);
                        if (resp == 1)
                        {
                            try
                            {
                                string mobile1 = dealerds.Tables[0].Rows[0]["DistributorMobileNo"].ToString() + "," + dealerds.Tables[0].Rows[0]["DealerMobileNo"].ToString();
                                string message1 = "Order for Invoice No. " + dealerds.Tables[0].Rows[0]["InvoiceNo"].ToString() + " has been delivered sucessfully.";
                                string username1 = "aarmscm";
                                string password1 = "demo1234";
                                string senderid = "AARMSA";
                                string domian1 = "sms.cannyinfotech.com";
                                string result = apicall("http://" + domian1 + "/sendsms.jsp?user=" + username1 + "&password=" + password1 + "&mobiles=91" + mobile1 + "&sms=" + message1 + "&unicode=0&senderid=" + senderid + "&version=3");
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
                        }
                        else
                        {
                            Response.Headers.Add("Response", "Error2");
                        }
                    }
                }
            }
        }
        //Response.Headers.Add("OTP", value);
    }
    public static string TOTPGenerator(string uniqueIdentity)
    {
        string oneTimePassword = "";
        DateTime dateTime = DateTime.Now;
        string _strParsedReqNo = dateTime.Day.ToString();
        _strParsedReqNo = _strParsedReqNo + dateTime.Month.ToString();
        _strParsedReqNo = _strParsedReqNo + dateTime.Year.ToString();
        _strParsedReqNo = _strParsedReqNo + dateTime.Hour.ToString();
        _strParsedReqNo = _strParsedReqNo + dateTime.Minute.ToString();
        _strParsedReqNo = _strParsedReqNo + dateTime.Second.ToString();
        _strParsedReqNo = _strParsedReqNo + dateTime.Millisecond.ToString();
        _strParsedReqNo = _strParsedReqNo + uniqueIdentity;
        //Append above string with Policy number to get desired output.
        Console.WriteLine("TOTP value: " + _strParsedReqNo);
        using (MD5 md5 = MD5.Create())
        {
            //Get hash code of entered request id in byte format.
            byte[] _reqByte = md5.ComputeHash(Encoding.UTF8.GetBytes(_strParsedReqNo));
            //convert byte array to integer.
            int _parsedReqNo = BitConverter.ToInt32(_reqByte, 0);
            string _strParsedReqId = Math.Abs(_parsedReqNo).ToString();
            //Check if length of hash code is less than 9.
            //If so, then prepend multiple zeros upto the length becomes atleast 9 characters.
            if (_strParsedReqId.Length < 9)
            {
                StringBuilder sb = new StringBuilder(_strParsedReqId);
                for (int k = 0; k < (9 - _strParsedReqId.Length); k++)
                {
                    sb.Insert(0, '0');
                }
                _strParsedReqId = sb.ToString();
            }
            oneTimePassword = _strParsedReqId;
        }
        //Adding random letters to the OTP.
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        string randomString = "";
        for (int i = 0; i < 4; i++)
        {
            randomString += Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
        }
        //Deciding number of characters in OTP.
        Random ran = new Random();
        int randomNumber = ran.Next(2, 5);
        Random num = new Random();
        //Form alphanumeric OTP and rearrange it reandomly.
        string otpString = randomString.Substring(0, randomNumber);
        otpString += oneTimePassword.Substring(0, 7 - randomNumber);
        oneTimePassword = new string(otpString.ToCharArray().OrderBy(s => (num.Next(2) % 2) == 0).ToArray());
        return oneTimePassword;
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
}