<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
       
            context.Response.ContentType = "text/plain";
            HttpPostedFile uploadFiles = context.Request.Files["Filedata"];
            string pathToSave = HttpContext.Current.Server.MapPath("~/UploadFiles/") + uploadFiles.FileName;
           
            uploadFiles.SaveAs(pathToSave);
          // String filename = uploadFiles.FileName;//the name of the file to be uploaded
           // uploadFiles.SaveAs("E:\\UploadFiles\\" + filename);
            
            try
            {
            MultipleUploadClass.staticvar = MultipleUploadClass.staticvar + "@" + pathToSave;
           //MultipleUploadClass.staticvar = MultipleUploadClass.staticvar + "@" + filename;
            
                
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