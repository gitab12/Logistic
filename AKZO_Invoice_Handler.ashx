<%@ WebHandler Language="C#" Class="AKZO_Invoice_Handler" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class AKZO_Invoice_Handler : IHttpHandler {

    string strcon = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    public void ProcessRequest (HttpContext context) {
        try
        {
            string imageid = context.Request.QueryString["ImageID"];
            SqlConnection connection = new SqlConnection(strcon);
            connection.Open();
            SqlCommand command = new SqlCommand("select InvoiceCopy from AKZO_OrderProcess where InvoiceNo = '" + imageid + "'", connection);
            SqlDataReader dr = command.ExecuteReader();
            dr.Read();
            context.Response.BinaryWrite((Byte[])dr[0]);
            connection.Close();
            context.Response.End();
        }
        catch (Exception ex)
        {

        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}