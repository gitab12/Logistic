using System;
using System.Data;
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
using System.Data.SqlClient;

/// <summary>
/// Summary description for BizConnectClient
/// </summary>
public class BizConnectClient
{
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    SqlConnection obj_GSTConn = new SqlConnection();



    //string connStr = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
    public int res;
    ArrayList arr = new ArrayList();
	public BizConnectClient()
	{
		//
		// TODO: Add constructor logic here
		//

        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        string GSTConnStr = ConfigurationManager.ConnectionStrings["GST"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;
        obj_GSTConn.ConnectionString = GSTConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
        obj_GSTConn.Open();

	}
   
    
    //Insert Data into Client Master
    public Int32 Insert_Client(string clientcode, string companyname, int NOE, int YOE, double Turnover, string URL, string panno, string tinno, string cenvatno, string servicetaxno, int locationid, string contactperson, string address, string city, string state, int pincode, string boardno, string fax, string email, string country, int desg, string mobno, string @obj_EmailID,
                                 string @obj_Password, string @obj_FirstName, string @obj_MiddleName, string @obj_LastName, int @obj_DesignationID, string @obj_Department, int @obj_Age, int @obj_GenderID, string @obj_Phone, string @obj_Mobile, double DunningRate)
    {
        int res = 0;
        using (SqlCommand comm = new SqlCommand("Insert_BizConnect_Client", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    //Inserting to Bizconnect_clientMaster
                    ada.SelectCommand.Parameters.AddWithValue("@clientcode", clientcode);
                    ada.SelectCommand.Parameters.AddWithValue("@Companyname", companyname);
                    ada.SelectCommand.Parameters.AddWithValue("@NOE", NOE);
                    ada.SelectCommand.Parameters.AddWithValue("@YOE", YOE);
                    ada.SelectCommand.Parameters.AddWithValue("@Turnover", Turnover);
                    ada.SelectCommand.Parameters.AddWithValue("@URL", URL);
                    ada.SelectCommand.Parameters.AddWithValue("@panno", panno);
                    ada.SelectCommand.Parameters.AddWithValue("@tinno", tinno);
                    ada.SelectCommand.Parameters.AddWithValue("@cenvatno", cenvatno);
                    ada.SelectCommand.Parameters.AddWithValue("@servicetaxno", servicetaxno);
                    ada.SelectCommand.Parameters.AddWithValue("@DunningRate", DunningRate);
                    //Inserting toBizconnect_clientAddressLocation
                    ada.SelectCommand.Parameters.AddWithValue("@locationTypeID", locationid);
                    ada.SelectCommand.Parameters.AddWithValue("@Address", address);
                    ada.SelectCommand.Parameters.AddWithValue("@City", city);
                    ada.SelectCommand.Parameters.AddWithValue("@State", state);
                    ada.SelectCommand.Parameters.AddWithValue("@Pincode", pincode);
                    ada.SelectCommand.Parameters.AddWithValue("@BoardNo", boardno);
                    ada.SelectCommand.Parameters.AddWithValue("@Fax", fax);
                    ada.SelectCommand.Parameters.AddWithValue("@Email", email);
                    ada.SelectCommand.Parameters.AddWithValue("@country", country);
                    ada.SelectCommand.Parameters.AddWithValue("@contactperson", contactperson);
                    ada.SelectCommand.Parameters.AddWithValue("@desg", desg);
                    ada.SelectCommand.Parameters.AddWithValue("@MobileNumber", mobno);
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
            }

        //Insertion for UserLogDb Table
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
                    da.SelectCommand.Parameters.AddWithValue("@obj_Phone", obj_Phone);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Mobile", obj_Mobile);
 					da.SelectCommand.Parameters.AddWithValue("@obj_Aarmsrep", "0");
					da.SelectCommand.Parameters.AddWithValue("@UserID", "0");//Prabhat
                  da.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception e)
                {
                    res = 0;
                }
                finally
                {
                    
                }
            }
        return res;
    }
   
    //Insert data into mapping table
    public Int32 Insert_ClientMapping()
    {
        int res = 0;
        using (SqlCommand comm = new SqlCommand("Insert_BizConnect_UserClientMapping", obj_BizConn))
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
    //Insert dta into clientaddloc
    public Int32 Insert_Clientbr(int clientid, int locationid, string address, string city, string state, int pincode, string boardno, string fax, string email, string country, string contactperson, int desg, string mobno, string @obj_EmailID,
                                 string @obj_Password, string @obj_FirstName, string @obj_MiddleName, string @obj_LastName, int @obj_DesignationID, string @obj_Department, int @obj_Age, int @obj_GenderID, string @obj_Phone, string @obj_Mobile)
    {
        int res = 0;
        
            using (SqlCommand comm1 = new SqlCommand("Insert_BizConnect_ClientAddressLocation", obj_BizConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(comm1);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                   
                    da.SelectCommand.Parameters.AddWithValue("@obj_ClientID", clientid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", locationid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Address", address);
                    da.SelectCommand.Parameters.AddWithValue("@obj_City", city);
                    da.SelectCommand.Parameters.AddWithValue("@obj_State", state);
                    da.SelectCommand.Parameters.AddWithValue("@obj_PinCode", pincode);
                    da.SelectCommand.Parameters.AddWithValue("@obj_BoardNo", boardno);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Fax", fax);
                    da.SelectCommand.Parameters.AddWithValue("@obj_CorporateEmail", email);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Country", country);
                    da.SelectCommand.Parameters.AddWithValue("@obj_ContactPerson", contactperson);
                    da.SelectCommand.Parameters.AddWithValue("@obj_DesignationID", desg);
                    da.SelectCommand.Parameters.AddWithValue("@obj_MobileNumber", mobno);
                    da.SelectCommand.ExecuteNonQuery();
                    res = 1;

                }
                catch (Exception e)
                {
                    res = 0;
                }
                finally
                {
                   
                }
            }

           //Insertion for UserLogDb Table
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
                    da.SelectCommand.Parameters.AddWithValue("@obj_Phone", obj_Phone);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Mobile", obj_Mobile);
 					da.SelectCommand.Parameters.AddWithValue("@obj_Aarmsrep", "0");
                  da.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception e)
                {
                    res = 0;
                }
                finally
                {
                    
                }
            }
        
    
        
        return res;
    }
    //Insert data into customeraddloc
    public Int32 Insert_Customerbr(int CustomerID,int locationid, string address, string city, string state, int pincode, string boardno, string fax, string email, string country,string contactperson,int desg,string mobno)
    {
        int res = 0;
          using (SqlCommand comm1 = new SqlCommand("Insert_BizConnect_CustomerBranches", obj_BizConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(comm1);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    
                    da.SelectCommand.Parameters.AddWithValue("@obj_CustomerID", CustomerID);
                    da.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", locationid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Address", address);
                    da.SelectCommand.Parameters.AddWithValue("@obj_City", city);
                    da.SelectCommand.Parameters.AddWithValue("@obj_State", state);
                    da.SelectCommand.Parameters.AddWithValue("@obj_PinCode", pincode);
                    da.SelectCommand.Parameters.AddWithValue("@obj_BoardNo", boardno);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Fax", fax);
                    da.SelectCommand.Parameters.AddWithValue("@obj_CorporateEmail", email);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Country", country);
                    da.SelectCommand.Parameters.AddWithValue("@obj_ContactPerson", contactperson);
                    da.SelectCommand.Parameters.AddWithValue("@obj_DesignationID", desg);
                    da.SelectCommand.Parameters.AddWithValue("@obj_MobileNumber", mobno);
                    da.SelectCommand.ExecuteNonQuery();
                    res = 1;

                }
                catch (Exception e)
                {
                    res = 0;
                }
                finally
                {
                   
                }
            }
        
        return res;
    }
    public Int32 Insert_Contactdetails(string name,string companyname,string companywebsite,string emailaddress,string mobno,string id,string comments)
    {
        int res = 0;
       
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_ContactusMaster", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                   
                    //Inserting to Bizconnect_customerMaster
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Name", name);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_CompanyName", companyname);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_CompanyWebsite", companywebsite);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_EmailAddress", emailaddress);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_MobileNumber", mobno);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_InterestedPortalID", id);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Comments", comments);
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                   
                }


            
        }
       return res;
    }
    //Fill Bank Location
    public DataSet FillBankLocation()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_GST_BankAddressLocationID", obj_GSTConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                ada.Fill(ds, "Location");
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
    //Fill client city
    public DataSet Fillclientcity(int clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_Clientcity", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_clientid", clientid);


            try
            {
                ada.Fill(ds, "Location");
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
//Get BiddingStatus
    public DataTable  Get_BiddingStatus(int type,string UserID)
    {
        DataTable dt = new DataTable();
   
        using (SqlCommand comm = new SqlCommand("Get_BiddingStatus", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_Type", type);
            ada.SelectCommand.Parameters.AddWithValue("@UserID", UserID);



            try
            {
                ada.Fill(dt);
            }
            catch (Exception err)
            {

            }
            finally
            {

            }
        }
        return dt;
    }
    //Get QuotingLevel
    public DataTable Get_Level( int postid )
    {
        DataTable dt = new DataTable();

        using (SqlCommand comm = new SqlCommand("Get_Level", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@PostID", postid);


            try
            {
                ada.Fill(dt);
            }
            catch (Exception err)
            {

            }
            finally
            {

            }
        }
        return dt;
    }
    
     //Get QuotingLevel LOG
    public DataTable Get_LevelLog( int postid )
    {
        DataTable dt = new DataTable();

        using (SqlCommand comm = new SqlCommand("Get_Levellog", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@PostID", postid);


            try
            {
                ada.Fill(dt);
            }
            catch (Exception err)
            {

            }
            finally
            {

            }
        }
        return dt;
    }
    
    
//ClientSummaryView
 public DataSet  ClientSummaryView()
    {
        DataSet dt = new DataSet();

      
            using (SqlCommand comm = new SqlCommand("ClientSummaryView", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                 ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                  
                    ada.Fill(dt);
                }
                catch (Exception err)
                {

                }
                finally
                {
                   
                }

            

        }
        return dt;
    }

 public DataTable Get_DisplayBiddingDetails()
 {
     DataTable dt = new DataTable();
     using (SqlCommand comm = new SqlCommand("select CompanyName as Transporter,'12' as TotalRoute, count(p.postid)as QuotedRoute from aarmjunction .dbo.scmJunction_PostAd p inner join aarmjunction .dbo.scmJunction_PostReply r on p.PostID=r.PostID inner join aarmjunction .dbo.scmjunction_registration rr  on rr.rid =r.ReplyByID where p.PostTypeID=4 and  PostByID=2975  group by CompanyName", obj_BizConn))
         {
             try
             {
                 SqlDataAdapter ada = new SqlDataAdapter(comm);
                 ada.SelectCommand.CommandType = CommandType.Text;
                 ada.Fill(dt);
             }
             catch (Exception err)
             {

             }
             finally
             {
             }
         }
     return dt;
 }

 public DataTable Get_BiddingDetails(string Region)
 {
     DataTable dt = new DataTable();
     using (SqlCommand comm = new SqlCommand(" select pa.postid,pa.AdditionalComments  as Region ,pa.FromLocation ,pa.ToLocation ,tt.TruckType , (pa.NumOfTrucks )as NoofTrucks,(ClientPrice) as TotalValue, minquote  from  aarmjunction .dbo.scmJunction_PostAd PA  inner join Bizconnect .dbo.BizConnect_LogisticsPlan LP on LP.JunctionAdID =pa.AdID  inner join Bizconnect .dbo.BizConnect_TruckTypeMaster tt on lp.TruckTypeID =tt.TruckTypeID  left join (select min(negotiablecost) as minquote,PostID  from aarmjunction .dbo.scmJunction_PostReply group by PostID )  Prep on Prep.PostID =PA .PostID    where PostTypeID=4 and pa.AdditionalComments='" + Region + "' order by pa.AdditionalComments ", obj_BizConn)) 
     {
         try
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.Text;
             ada.Fill(dt);
         }
         catch (Exception err)
         {

         }
         finally
         {
         }
     }
     return dt;
 }


}
