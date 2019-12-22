using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

/// <summary>
/// Summary description for AarmsUser
/// </summary>
public class AarmsUser
{

    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string connJun = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    ArrayList arr = new ArrayList();
    int resp = 0;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    DataSet ds;
	public AarmsUser()
	{
		//
		// TODO: Add constructor logic here
		//
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();

	}
    //Insertion for UserLogDb Table
    public Int32 Insert_Aarmsuser(string  obj_EmailID,string obj_Password, string obj_FirstName, string obj_MiddleName, string obj_LastName, int obj_DesignationID, string obj_Department, int obj_Age, int obj_GenderID,  string obj_Mobile)
    {
        using (SqlCommand comm1 = new SqlCommand("Insert_BizConnect_UserLogDB", obj_BizConn))
            {
                
                SqlDataAdapter da = new SqlDataAdapter(comm1);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    //inserting into user log table
                    da.SelectCommand.Parameters.AddWithValue("@obj_EmailID", obj_EmailID);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Password", obj_Password);
                    da.SelectCommand.Parameters.AddWithValue("@obj_FirstName", obj_FirstName);
                    da.SelectCommand.Parameters.AddWithValue("@obj_MiddleName", obj_MiddleName);
                    da.SelectCommand.Parameters.AddWithValue("@obj_LastName", obj_LastName);
                    da.SelectCommand.Parameters.AddWithValue("@obj_DesignationID", obj_DesignationID);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Department", obj_Department);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Age", obj_Age);
                    da.SelectCommand.Parameters.AddWithValue("@obj_GenderID", obj_GenderID);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Phone","No Phone");
                    da.SelectCommand.Parameters.AddWithValue("@obj_Mobile", obj_Mobile);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Aarmsrep", "1");
                    da.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception e)
                {
                    resp = 0;
                }
                finally
                {
                    
                }
            }
        return resp;
    }

    //

    //Insert data into mapping table
    public Int32 Insert_ClientMapping()
    {
        int res = 0;
        using (SqlCommand comm = new SqlCommand("Insert_BizConnect_AarmsUserClientCustomerMapping", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception e)
            {
                res = 0;
            }
        }
        return res;
    }


    //Insertion for AarmsProfile
    public Int32 Insert_AarmsProfile(int obj_TLID, string obj_Business, string obj_FirstName, 
        string obj_MiddleName, string obj_LastName, string obj_Department,
        int obj_Age, string obj_Designation, string obj_Address, string obj_area, string obj_city, string obj_pincode,
        string obj_ESI, string obj_PF, string obj_PAN, string obj_BloodGroup, string obj_Mobile, int obj_GenderID, string obj_EmailID, string obj_Password)
    {
        using (SqlCommand comm1 = new SqlCommand("Aarms_profileInsert", obj_BizConn))
        {

            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                //inserting into user log table
                da.SelectCommand.Parameters.AddWithValue("@TID", obj_TLID);
              
                da.SelectCommand.Parameters.AddWithValue("@Business", obj_Business);
                da.SelectCommand.Parameters.AddWithValue("@Firstname", obj_FirstName);
                da.SelectCommand.Parameters.AddWithValue("@Middlename", obj_MiddleName);
                da.SelectCommand.Parameters.AddWithValue("@Lastname", obj_LastName);
                da.SelectCommand.Parameters.AddWithValue("@Department", obj_Department );
                 da.SelectCommand.Parameters.AddWithValue("@age", obj_Age);
                da.SelectCommand.Parameters.AddWithValue("@Designation", obj_Designation);
                da.SelectCommand.Parameters.AddWithValue("@Address", obj_Address);
                da.SelectCommand.Parameters.AddWithValue("@Area", obj_area );
                da.SelectCommand.Parameters.AddWithValue("@City", obj_city);
                da.SelectCommand.Parameters.AddWithValue("@Pincode", obj_pincode);
                da.SelectCommand.Parameters.AddWithValue("@Esinumber", obj_ESI);
                da.SelectCommand.Parameters.AddWithValue("@PFnumber", obj_PF);
                 da.SelectCommand.Parameters.AddWithValue("@PANnumber", obj_PAN);
               da.SelectCommand.Parameters.AddWithValue("@BloadGroup", obj_BloodGroup);
               da.SelectCommand.Parameters.AddWithValue("@Mobilenumber", obj_Mobile);
                da.SelectCommand.Parameters.AddWithValue("@Gender", obj_GenderID);
                da.SelectCommand.Parameters.AddWithValue("@EmailID", obj_EmailID);
                da.SelectCommand.Parameters.AddWithValue("@Password", obj_Password);
              
                da.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception e)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;
    }
    //Insert User permission
public Int32 Insert_Userpermission(string obj_serviceid,string obj_accessid)
{
   
        using (SqlCommand comm1 = new SqlCommand("User_permission", obj_BizConn))
        {

            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                //inserting into BizConnect_UserPermission  table
                
                da.SelectCommand.Parameters.AddWithValue("@obj_serviceid", obj_serviceid);
                da.SelectCommand.Parameters.AddWithValue("@obj_accessid", obj_accessid);
                da.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception e)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;
    }
public DataSet Bizconnect_ShowLogisticsplan()
{
    using (SqlCommand cmd = new SqlCommand("Bizconnect_ShowLogisticsplan", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.ExecuteNonQuery ();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}
public DataSet Bizconnect_ShowQuotedRates()
{
    using (SqlCommand cmd = new SqlCommand("Bizconnect_ShowQuotedRates", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.ExecuteNonQuery();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}
//Get_ClientsPostedADs
public DataSet Get_ClientsPostedADs(int ClientID)
{
    using (SqlCommand cmd = new SqlCommand("Get_ClientsPostedADs", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
        da.SelectCommand.ExecuteNonQuery();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}
//Get_ReceivedQuoted
public DataSet Get_ReceivedQuoted(int ClientID, DateTime FromDate, DateTime ToDate)
{
    using (SqlCommand cmd = new SqlCommand("Get_ReceivedQuoted", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
        da.SelectCommand.Parameters.AddWithValue("@FromDate", FromDate);
        da.SelectCommand.Parameters.AddWithValue("@ToDate", ToDate);
        da.SelectCommand.ExecuteNonQuery();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}

//TripRequested

public DataSet TripRequested(int ClientID)
{
    using (SqlCommand cmd = new SqlCommand("TripRequested", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@obj_Client", ClientID);
        da.SelectCommand.ExecuteNonQuery();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}
//Trip cofirmed


public DataSet TripConfirmed(int ClientID)
{
    using (SqlCommand cmd = new SqlCommand("TripConfirmed", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@obj_Client", ClientID);
        da.SelectCommand.ExecuteNonQuery();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}

  //Insert Bizconnect_InsertActivity

public Int32 Bizconnect_InsertActivity(string obj_ClientName, string obj_Location, string obj_Industry, string obj_ContactPerson,
    string obj_MobileNumber, string obj_Department, string obj_EnteredBy, DateTime  obj_AppDate,string obj_emailid,string obj_action,string obj_Remarks)
{
    using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertActivity", obj_BizConn))
    {

        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //inserting into user log table
            da.SelectCommand.Parameters.AddWithValue("@ClientName", obj_ClientName);
            da.SelectCommand.Parameters.AddWithValue("@Location", obj_Location);
            da.SelectCommand.Parameters.AddWithValue("@Industry", obj_Industry);
            da.SelectCommand.Parameters.AddWithValue("@ContactPerson", obj_ContactPerson);
            da.SelectCommand.Parameters.AddWithValue("@MobileNumber", obj_MobileNumber);
            da.SelectCommand.Parameters.AddWithValue("@Department", obj_Department);
            da.SelectCommand.Parameters.AddWithValue("@EnteredBy", obj_EnteredBy);
            da.SelectCommand.Parameters.AddWithValue("@AppointmentDate", obj_AppDate);
            da.SelectCommand.Parameters.AddWithValue("@EmailID", obj_emailid);
            da.SelectCommand.Parameters.AddWithValue("@Action", obj_action);
            da.SelectCommand.Parameters.AddWithValue("@Remarks", obj_Remarks);

            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}

    //DisplayAppointDetails


public DataSet DisplayAppointDetails(DateTime  AppDate,int mode)
{
    using (SqlCommand cmd = new SqlCommand("DisplayAppointDetails", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@AppDate", AppDate);
        da.SelectCommand.Parameters.AddWithValue("@Mode", mode);
        da.SelectCommand.ExecuteNonQuery();
        ds = new DataSet();
        da.Fill(ds);
    }
    return ds;
}

    //Bizconnect_UpdateStatus
public Int32 Bizconnect_UpdateStatus(string obj_ContactPerson,
string obj_MobileNumber,string obj_EmailID ,string obj_Department, string obj_EnteredBy, DateTime obj_AppDate,string obj_MetBy ,string obj_Tripplan,string obj_action,string  obj_Remarks,int obj_ActivityID )
{
    using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateStatus", obj_BizConn))
    {

        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //Update into user log table
          
            da.SelectCommand.Parameters.AddWithValue("@ContactPerson", obj_ContactPerson);
            da.SelectCommand.Parameters.AddWithValue("@MobileNumber", obj_MobileNumber);
            da.SelectCommand.Parameters.AddWithValue("@EmailID", obj_EmailID);

            da.SelectCommand.Parameters.AddWithValue("@Department", obj_Department);
            da.SelectCommand.Parameters.AddWithValue("@EnteredBy", obj_EnteredBy);
            da.SelectCommand.Parameters.AddWithValue("@AppointmentDate", obj_AppDate);
            da.SelectCommand.Parameters.AddWithValue("@MetBy", obj_MetBy);
            da.SelectCommand.Parameters.AddWithValue("@Tripplan", obj_Tripplan);
            da.SelectCommand.Parameters.AddWithValue("@Action", obj_action);
            da.SelectCommand.Parameters.AddWithValue("@Remarks", obj_Remarks);            
            da.SelectCommand.Parameters.AddWithValue("@ActivityID", obj_ActivityID);


            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}



public Int32 Bizconnect_InsertAARMSOperation(DateTime obj_CalDate, string obj_client, DateTime obj_ReceiveDate,string obj_transporter, int obj_Quotereceive,
DateTime obj_ActionDate, int obj_rebid,string obj_marketaction,string EnteredBy)
{
    using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertAARMSOperation", obj_BizConn))
    {

        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //inserting into user log table
            da.SelectCommand.Parameters.AddWithValue("@obj_CalDate", obj_CalDate);
            da.SelectCommand.Parameters.AddWithValue("@obj_client", obj_client);
            da.SelectCommand.Parameters.AddWithValue("@obj_ReceiveDate", obj_ReceiveDate);
            da.SelectCommand.Parameters.AddWithValue("@obj_transporter", obj_transporter);
            da.SelectCommand.Parameters.AddWithValue("@obj_Quotereceive", obj_Quotereceive);
            da.SelectCommand.Parameters.AddWithValue("@obj_ActionDate", obj_ActionDate);
            da.SelectCommand.Parameters.AddWithValue("@obj_rebid", obj_rebid);
            da.SelectCommand.Parameters.AddWithValue("@obj_marketaction", obj_marketaction);           
			da.SelectCommand.Parameters.AddWithValue("@obj_EnteredBy", EnteredBy);
            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}
public DataSet AARMSPageReport()
{
    DataSet ds_Report = new DataSet();
    using (SqlCommand cmd = new SqlCommand("Get_AARMSPageReport", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            da.Fill(ds_Report);
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return ds_Report;
}

//Update Client Price

public Int32 Update_ClientPrice(float ClientPrice, int LogisticsPlanid)
{
    using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateClientQuoteprice", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //inserting into BizConnect_UserPermission  table

            da.SelectCommand.Parameters.AddWithValue("@ClientPrice",ClientPrice);
            da.SelectCommand.Parameters.AddWithValue("@LogisticsPlanID",LogisticsPlanid);
            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}

// Update CostperTruck price
public Int32 Update_CostperTruck(float Costpertruck,float clientPrice, int LogisticsPlanid)
{
    using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateCostPerTruck", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //inserting into BizConnect_UserPermission  table

            da.SelectCommand.Parameters.AddWithValue("@LogisticSplanID", LogisticsPlanid);
            da.SelectCommand.Parameters.AddWithValue("@CostperTruck", Costpertruck);
            da.SelectCommand.Parameters.AddWithValue("@ClientPrice", clientPrice);
            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}

public Int32 ScmJunPostReply_UpdateQuoteprice(int Replyid,float  QuotePrice,string Type)
{
    using (SqlCommand comm1 = new SqlCommand("ScmJunPostReply_UpdateQuoteprice", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //inserting into BizConnect_UserPermission  table

            da.SelectCommand.Parameters.AddWithValue("@ReplyId", Replyid);
            da.SelectCommand.Parameters.AddWithValue("@QuotePrice", QuotePrice);
            da.SelectCommand.Parameters.AddWithValue("@Type", Type);
            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}

//Tracking Updates
public DataTable  Bizconnect_TrackingUpdates()
{
    DataTable dt = new DataTable();
    using (SqlCommand cmd = new SqlCommand("Bizconnect_TrackingUpdates", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.ExecuteNonQuery();
       
        da.Fill(dt);
    }
    return dt;
}
    //Insert Tracking Log in Database

public Int32 Bizconnect_InsertTrackingLog(int  obj_AcceptanceID, string obj_Remarks)
{

    using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertTrackingLog", obj_BizConn))
    {

        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            //inserting into BizConnect_UserPermission  table

            da.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            da.SelectCommand.Parameters.AddWithValue("@obj_Remarks", obj_Remarks);
            da.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return resp;
}

public DataSet Get_PrelaodClients()
{
    DataSet ds_Report = new DataSet();
    using (SqlCommand cmd = new SqlCommand("Bizconect_PreloadClients", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            da.Fill(ds_Report);
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return ds_Report;
}

public DataSet Get_PrelaodClientsReport(int ClientID, int Month)
{
    DataSet Report = new DataSet();
    using (SqlCommand cmd = new SqlCommand("Bizconnect_PreloadReport", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@obj_Client", ClientID);
        da.SelectCommand.Parameters.AddWithValue("@obj_Month", Month);        
        try
        {
            da.Fill(Report);
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return Report;
}


public DataTable Search_DisplayAppointDetails(string SearchBy, int Mode)
{
    DataTable dt = new DataTable();
    using (SqlCommand cmd = new SqlCommand("Search_DisplayAppointDetails", obj_BizConn))
    {
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        da.SelectCommand.Parameters.AddWithValue("@SearchBy", SearchBy);
        da.SelectCommand.Parameters.AddWithValue("@Mode", Mode);
        try
        {
            da.Fill(dt);
        }
        catch (Exception e)
        {
            resp = 0;
        }
        finally
        {

        }
    }
    return dt;
}


}
