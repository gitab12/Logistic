using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using ExponantAARMSMS;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;
using System.Configuration;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Security.Cryptography;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    DataTable dt_Read = new DataTable();

    string obj_FileName, obj_Path;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_UploadAndDisplay_Click1(object sender, EventArgs e)
 {

    if (ExcelUpload.HasFile)
         {
             obj_FileName = ExcelUpload.PostedFile.FileName;
             ExcelUpload.SaveAs(Server.MapPath(@"temp\") + ExcelUpload.FileName);
             obj_Path = Server.MapPath(@"Excel\") + ExcelUpload.FileName;
             Session["obj_Path"] = Server.MapPath(@"temp\") + ExcelUpload.FileName;
         }
         string excelConnectionString = "";
         String Extension = System.IO.Path.GetExtension(ExcelUpload.PostedFile.FileName);
        
             switch (Extension)
             {
                 case ".xls": //Excel 97-03
                     //  excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(@"Excel\" + ExcelUpload.FileName) + ";Extended Properties='Excel 8.0;HDR={1}'";
                     excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Session["obj_Path"].ToString() + ";Extended Properties='Excel 12.0;HDR={1}'";
                     break;
                 case ".xlsx": //Excel 07
                     excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Session["obj_Path"].ToString() + ";Extended Properties='Excel 12.0;HDR={1}'";
                     break;
             }
             //  Response.Write(Session["obj_Path"].ToString());
             OleDbConnection myExcelConnection = new OleDbConnection(excelConnectionString);
            // myExcelConnection.Open();
             OleDbDataAdapter myAdapter = new OleDbDataAdapter("select * from [Sheet1$]", myExcelConnection);
             //OleDbDataReader reader = myAdapter.SelectCommand.ExecuteReader();
          
             myAdapter.Fill(dt_Read);


  
}
    }