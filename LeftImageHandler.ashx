<%@ WebHandler Language="C#" Class="LeftImageHandler" %>


using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public class LeftImageHandler : IHttpHandler {

    public void ProcessRequest(HttpContext context)
    {
        //context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        string ImageDestinationLocationID = context.Request.QueryString["ImageID"];

        //Int32  obj_UserID =Convert.ToInt32(context.Request.QueryString["UserID"]);


        SqlConnection obj_BizConn = new SqlConnection();
        string BizConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_BizConn.Open();
        SqlCommand command = new SqlCommand("select imageLeft FROM Bizconnect_PreloadDetails WHERE   AcceptanceID=" + ImageDestinationLocationID, obj_BizConn);
        SqlDataReader dr = command.ExecuteReader();
        if (dr.HasRows)
        {
            if (dr.Read())
            {
                if (!dr.IsDBNull(0))
                {
                    context.Response.BinaryWrite((Byte[])dr[0]);
                    context.Response.End();
                }
            }
        }

        dr.Close();
        obj_BizConn.Close();
    }
    public bool IsReusable
    {
        get
        {
            return false;
        }
    }


}