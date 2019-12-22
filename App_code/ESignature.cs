using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

/// <summary>
/// Summary description for ESignature
/// </summary>
public class ESignature
{
    SqlConnection obj_BizConn = new SqlConnection();
   
    DataSet ds;
	public ESignature()
	{
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        
        obj_BizConn.ConnectionString = BizConnStr;
        obj_BizConn.Open();
        
	}

    //Insert into ESignatureRegistration
    public Int32 Insert_BizConnect_ESignatureRegistration(string  FirstName, string  LastName, string Designation, string EmailAddress ,string Password,string MobileNo,string PhoneNo, string CorporateAddress,string Area,string City,string Pincode ,string CompanyName,string website,byte[] Esignature)
    {
        int res;

        using (SqlCommand cmd = new SqlCommand("Insert_BizConnect_ESignatureRegistration", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.Parameters.AddWithValue("@FirstName", FirstName);
                ada.SelectCommand.Parameters.AddWithValue("@LastName", LastName);
                ada.SelectCommand.Parameters.AddWithValue("@Designation", Designation);
                ada.SelectCommand.Parameters.AddWithValue("@EmailAddress", EmailAddress);
                ada.SelectCommand.Parameters.AddWithValue("@Password", Password);
                ada.SelectCommand.Parameters.AddWithValue("@MobileNo", MobileNo);
                ada.SelectCommand.Parameters.AddWithValue("@PhoneNo", PhoneNo);
                ada.SelectCommand.Parameters.AddWithValue("@CorparateAddress", CorporateAddress);
                ada.SelectCommand.Parameters.AddWithValue("@Area", Area);
                ada.SelectCommand.Parameters.AddWithValue("@City", City);
                ada.SelectCommand.Parameters.AddWithValue("@Pincode", Pincode);
                ada.SelectCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
                ada.SelectCommand.Parameters.AddWithValue("@Website", website);
                ada.SelectCommand.Parameters.AddWithValue("@ESignature", Esignature);
                ada.SelectCommand.ExecuteNonQuery();
                res = 1;

                

            }
            catch (Exception exe)
            {
                res = 0;
            }
        }


        return res;
    }

    //EsignatureVerification
    public DataSet EsignatureVerification(string UserID,string Password)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("EsignatureVerification", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
            ada.SelectCommand.Parameters.AddWithValue("@Password", Password);
            try
            {
                ada.Fill(ds, "EsignatureVerification");
            }
            catch (Exception err)
            {

            }
            finally
            {
            }
        }
        return ds;
    }



     //Updateion of ESignatureCode
    public Int32 Update_ESignatureCode(int  UserID, int   Ecode)
    {
        int res;

        using (SqlCommand cmd = new SqlCommand("Update_ESignatureCode", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(cmd);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
                ada.SelectCommand.Parameters.AddWithValue("@Ecode", Ecode);
                ada.SelectCommand.ExecuteNonQuery();
                res = 1;

                

            }
            catch (Exception exe)
            {
                res = 0;
            }
        }


        return res;
    }
}
