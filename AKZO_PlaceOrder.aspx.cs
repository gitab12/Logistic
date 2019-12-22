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

public partial class AKZO_PlaceOrder : System.Web.UI.Page
{
    string InvNo, Loc, DisID, DID, DBID;
    AndroidClass ObjAndroidClass = new AndroidClass();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            InvNo = Page.Request.Form["InvNo"];
            Loc = Page.Request.Form["Loc"];
            DisID = Page.Request.Form["DisID"];
            DID = Page.Request.Form["DID"];
            DBID = Page.Request.Form["DBID"];
            DataSet checkinvoiceds = new DataSet();
            checkinvoiceds = ObjAndroidClass.checkakzoinvoice(InvNo);
            if (checkinvoiceds.Tables[0].Rows.Count <= 0)
            {
                int resp = ObjAndroidClass.InsertAKZOOrder(InvNo, Loc, Convert.ToInt32(DisID), Convert.ToInt32(DID), Convert.ToInt32(DBID));
                if (resp == 1)
                {
                    DataSet dealerds = new DataSet();
                    dealerds = ObjAndroidClass.GetAKZODealerNo(Convert.ToInt32(DID));
                    if (dealerds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string mobile1 = dealerds.Tables[0].Rows[0]["MobileNo"].ToString();
                            string message1 = "Order has been processed for invoice no. " + InvNo;
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
                    DataSet deliveryboyds = new DataSet();
                    deliveryboyds = ObjAndroidClass.GetAKZODealerNo(Convert.ToInt32(DBID));
                    if (deliveryboyds.Tables[0].Rows.Count > 0)
                    {
                        try
                        {
                            string mobile1 = deliveryboyds.Tables[0].Rows[0]["MobileNo"].ToString();
                            string message1 = "New order came for delivery.";
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
                    Response.Headers.Add("response", "1");
                }
                
            }
            else
            {
                Response.Headers.Add("response", "0");
            }
            
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
}