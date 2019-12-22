<%@ WebHandler Language="C#" Class="PDFHandler" %>

using System;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class PDFHandler : IHttpHandler {

    private static string EncryptionKey = "!#853g`de";
    private static byte[] key = { };
    private static byte[] IV = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

    public void ProcessRequest(HttpContext context)
    {

        string code = context.Request.QueryString["PLid"];
        code = code.Replace(" ", "+");
        string idd = Decrypt(code);

        int id = Convert.ToInt32(idd.ToString());
        // int id = int.Parse(context.Request.QueryString["ID"]);
        byte[] bytes;
        string fileName, contentType;
        string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT TruckImage,ImageName,ImageExt FROM Bizconnect_PreloadDetails where PLid=@id";

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["TruckImage"];
                    contentType = sdr["ImageExt"].ToString();// ".pdf";
                    fileName = sdr["ImageName"].ToString();
                }
                con.Close();
            }
        }

        context.Response.Buffer = true;
        context.Response.Charset = "";
        if (context.Request.QueryString["download"] == "1")
        {
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        }
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.ContentType = "application/pdf";
        context.Response.BinaryWrite(bytes);
        context.Response.Flush();
        context.Response.End();

    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }

    public string Decrypt(string Input)
    {
        Byte[] inputByteArray = new Byte[Input.Length];

        try
        {
            key = System.Text.Encoding.UTF8.GetBytes(EncryptionKey.Substring(0, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(Input);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(key, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            Encoding encoding = Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return "";
        }
    }
}