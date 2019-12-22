<%@ WebHandler Language="C#" Class="CollectionNoteImage" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

public class CollectionNoteImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context)
    {
        string ImageDestinationLocationID = context.Request.QueryString["ImageID"];

        SqlConnection obj_BizConn = new SqlConnection();
        string BizConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_BizConn.Open();
        SqlCommand command = new SqlCommand("select CollectionNoteImage from bizconnect.dbo.CollectionNote where collectionNoteid=" + ImageDestinationLocationID, obj_BizConn);
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
 
    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}