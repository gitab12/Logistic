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
/// Summary description for BizConnectCustomer
/// </summary>
public class BizConnectCustomer
{
    int clientcode = 0;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();

  string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;

    //string connStr = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;
    public int res;
    ArrayList arr = new ArrayList();
	public BizConnectCustomer()
	{
		//
		// TODO: Add constructor logic here
		//
      
        //string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        //obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
       // obj_SCMConn.Open();

	}
    public DataSet get_clientid(string obj_Clientemailid)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_BizConnect_Clientbyemailid", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Clientemailid", obj_Clientemailid);
                try
                {
                   
                    ada.Fill(ds, "clientid");
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

    //to get address
    public DataSet get_clientaddress(int obj_Clientid,string city)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_BizConnect_Adress", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_clientid", obj_Clientid);
            ada.SelectCommand.Parameters.AddWithValue("@obj_City", city);
            try
            {

                ada.Fill(ds, "clientad");
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

    //Insert Data into customer Master
    public Int32 Insert_Customer(string customercode, int clientID,int clientadlocid, string companyname, int NOE, int YOE, double Turnover, string URL, string panno, string tinno, string cenvatno, string servicetaxno, int locationid, string contactperson, string address, string city, string state, int pincode, string boardno, 
                                 string fax, string email, string country, int desg, string mobno,int userid,string ClientCustomerCode)
    {
        int res = 0;
        clientcode = clientID;

        using (SqlCommand comm = new SqlCommand("Insert_BizConnect_CustomerMaster", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                   
                    //Inserting to Bizconnect_customerMaster
                    ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerCode",customercode);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", clientID);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddressLocationID", clientadlocid);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_CompanyName", companyname);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_NoOfEmployees", NOE);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_YearOfEstablishment", YOE);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TurnOver", Turnover);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_WebsiteURL", URL);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_PermenantAccountNumber", panno);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TaxpayerIdentificationNumber", tinno);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_CentralValueAddedTaxRegistrationNumber", cenvatno);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_ServiceTaxRegistrationNumber", servicetaxno);
                  
                    
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
               
            }

        //Insert Data into CustomerAdress Location   
            using (SqlCommand comm1 = new SqlCommand("Insert_BizConnect_CustomerAddressLocation", obj_BizConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(comm1);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    da.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", locationid);
                    da.SelectCommand.Parameters.AddWithValue("@ClientCustomerCode", ClientCustomerCode);
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

    //Insert Data into Userclientcustomermapping
    public int Insert_BizConnect_UserClientCustomerMapping(int clientcode, int userid)
    {
        using (SqlCommand comm = new SqlCommand("Insert_BizConnect_UserClientCustomerMapping", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", clientcode);
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", userid);

            try
            {

                  ada.SelectCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {

            }
            return 0;
        }

    }

//Update Customer details
    public Int32 Update_Customer(int CustomerID ,string customercode,string companyname, int NOE, int YOE, 
        double Turnover, string URL, string panno, string tinno, string cenvatno, 
        string servicetaxno, int locationid, string address, string city, string state,
        int pincode, int boardno,int fax, string email, string country,string contactperson, int desg, string mobno)

    {
        int res = 0;
    
        using (SqlCommand comm = new SqlCommand("Update_BizConnect_CustomerMaster", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {

                //Updating to Bizconnect_customerMaster
                ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerID", CustomerID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerCode", customercode);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CompanyName", companyname);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NoOfEmployees", NOE);
                ada.SelectCommand.Parameters.AddWithValue("@obj_YearOfEstablishment", YOE);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TurnOver", Turnover);
                ada.SelectCommand.Parameters.AddWithValue("@obj_WebsiteURL", URL);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PermenantAccountNumber", panno);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TaxpayerIdentificationNumber", tinno);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CentralValueAddedTaxRegistrationNumber", cenvatno);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ServiceTaxRegistrationNumber", servicetaxno);


                ada.SelectCommand.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception err)
            {
                res = 0;
            }

        }

        //Update Data into CustomerAdress Location   
        using (SqlCommand comm1 = new SqlCommand("Update_BizConnect_CustomerAddressLocation", obj_BizConn))
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
    //to get the customer data
    public ArrayList get_customer(Int32 obj_CustomerID)
    {
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerDetails", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerID", obj_CustomerID);
                try
                {
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            
                            arr.Add(dr.GetValue(0).ToString());
                            arr.Add(dr.GetValue(1).ToString());
                            arr.Add(dr.GetValue(2).ToString());
                            arr.Add(dr.GetValue(3).ToString());
                            arr.Add(dr.GetValue(4).ToString());
                            arr.Add(dr.GetValue(5).ToString());
                            arr.Add(dr.GetValue(6).ToString());
                            arr.Add(dr.GetValue(7).ToString());
                            arr.Add(dr.GetValue(8).ToString());
                            arr.Add(dr.GetValue(9).ToString());
                            arr.Add(dr.GetValue(10).ToString());
                            arr.Add(dr.GetValue(11).ToString());
                            arr.Add(dr.GetValue(12).ToString());
                            arr.Add(dr.GetValue(13).ToString());
                            arr.Add(dr.GetValue(14).ToString());
                            arr.Add(dr.GetValue(15).ToString());
                            arr.Add(dr.GetValue(16).ToString());
                            arr.Add(dr.GetValue(17).ToString());
                            arr.Add(dr.GetValue(18).ToString());
                            arr.Add(dr.GetValue(19).ToString());
                            arr.Add(dr.GetValue(20).ToString());
                            arr.Add(dr.GetValue(21).ToString());
                            arr.Add(dr.GetValue(22).ToString());

                        }
                    }
                    else
                    {
                        arr.Add(0);
                    }
                    dr.Close();
                }
                catch (Exception err)
                {

                }
                finally
                {
                    
                }
            }
        
        return arr;
    }
    //Retrieving data to list customer
    public DataSet get_customerdetails(string clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("get_customerlist", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_clientID", clientid);
                try
                {
                    
                    ada.Fill(ds, "customer");
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
    public int connection_nonquery(string cmdstr)
    {
        SqlConnection con = new SqlConnection(BizConnStr);
        con.Open();
        SqlCommand cmd = new SqlCommand(cmdstr, con);
        res = (int)cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }


//Retrieving data to list customer deactive
    public DataSet get_customerdetailsdeactive(string clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("get_customerlistdeactive", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_client", clientid);
            try
            {

                ada.Fill(ds, "customer");
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





}
