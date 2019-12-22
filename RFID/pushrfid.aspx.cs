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

public partial class RFID_pushrfid : System.Web.UI.Page
{
    RFIDClass Obj = new RFIDClass();
    public string BIZCon = ConfigurationManager.ConnectionStrings["BizCon"].ToString();
    string TagID, msgcontent, Lat, Long, Address, Sender;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                TagID = Request.QueryString["tagid"].ToString();
                Lat = Request.QueryString["lt"].ToString();
                Long = Request.QueryString["ln"].ToString();
                Sender = Request.QueryString["mb"].ToString();
                Obj.RFIDAttendance(TagID);
                //if (Long.ToString() == "")
                //{

                //}
                //else
                //{
                //    //Find Location from Latitude and Longitude
                //    string xmlResult = null;
                //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://maps.googleapis.com/maps/api/geocode/xml?address=" + Lat + "," + Long + "&sensor=false");
                //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //    StreamReader resStream = new StreamReader(response.GetResponseStream());
                //    XmlDocument doc = new XmlDocument();
                //    xmlResult = resStream.ReadToEnd();
                //    doc.LoadXml(xmlResult);
                //    try
                //    {
                //        if (doc.DocumentElement.SelectSingleNode("/GeocodeResponse/status").InnerText.ToString().ToUpper() != "OK")
                //        {
                //            Address = "";
                //        }
                //        else
                //        {
                //            XmlNodeList xnList = doc.SelectNodes("/GeocodeResponse");
                //            foreach (XmlNode xn in xnList)
                //            {
                //                if (xn["status"].InnerText.ToString() == "OK")
                //                {
                //                    XmlNodeList elemList = doc.GetElementsByTagName("formatted_address");
                //                    Address = elemList[1].InnerText;

                //                }
                //                else
                //                {
                //                    Address = "";
                //                }
                //            }
                //        }
                //    }
                //    catch (Exception ex)
                //    {
                //        Address = "";
                //    }
                //    msgcontent = Lat + "," + Long;
                //    string[] tokens = new string[10];
                //    tokens = TagID.Split(',');
                //    for (int i = 0; i < tokens.Length; i++)
                //    {
                //        int res = Obj.UpdateRFID_Table(tokens[i]);
                //        if (res == 1)
                //        {
                //            int res1 = Obj.InsertRFID_MasterTableDispatched(tokens[i]);
                //        }
                //        else if (res == 2)
                //        {
                //            int res2 = Obj.UpdateRFID_MasterTableDelivered(tokens[i]);
                //        }
                //        int resp = Obj.InsertRFID_LatLng(tokens[i], msgcontent, Address, Sender);
                //        if (resp == 1)
                //        {
                //            Response.Write("Sucessfully Inserted!!!!");
                //        }
                //        else
                //        {
                //            Response.Write("Not Inserted!!!!");
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}