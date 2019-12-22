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
using System.Data.SqlClient;

/// <summary>
/// Summary description for BizConnectTransporter
/// </summary>
public class BizConnectTransporter
{
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    public int res;
	public BizConnectTransporter()
	{

		//
		// TODO: Add constructor logic here
		//
	}
    //Retrieving Designation from bizconnect_desg table
    public DataSet get_desg()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("Get_BizConnect_DesignationMasterAll", conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.Fill(ds, "Designation");
                }
                catch
                {

                }
                finally
                {
                    conn.Close();
                }
            }

        }
        return ds;
    }

    //Retrieving Location from bizconnect_locationtypemaster table
    public DataSet get_LocationType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_LocationTypeMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "LocationType");
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return ds;
    }
    

    //retrieving clientid
    public DataSet get_clientid(string obj_Clientemailid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using(SqlConnection conn=new SqlConnection(connStr))
        {

        using (SqlCommand comm = new SqlCommand("Get_BizConnect_Clientbyemailid", conn))
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
    }

        return ds;
    }

    //insert into transportetmodule
    public Int32 Insert_Transporter(string transportercode, int clientID, string companyname,string trname, int NOE, int YOE, double Turnover, string URL, string panno, string tinno, string cenvatno, string servicetaxno, int locationid, string contactperson, string address, string city, string state, int pincode, string boardno,
                                    string fax, string email, string country, int desg, string mobno)
    {
        int res;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_TransporterMaster", conn))
            {
                
                    SqlDataAdapter da = new SqlDataAdapter(comm);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        da.SelectCommand.Parameters.AddWithValue("@obj_TransporterCode", transportercode);
                        da.SelectCommand.Parameters.AddWithValue("@obj_ClientID", clientID);
                        da.SelectCommand.Parameters.AddWithValue("@obj_CompanyName", companyname);
                        da.SelectCommand.Parameters.AddWithValue("@obj_TransporterName", trname);
                        da.SelectCommand.Parameters.AddWithValue("@obj_NoOfEmployees", NOE);
                        da.SelectCommand.Parameters.AddWithValue("@obj_PermenantAccountNumber", panno);
                        da.SelectCommand.Parameters.AddWithValue("@obj_TaxpayerIdentificationNumber", tinno);
                        da.SelectCommand.Parameters.AddWithValue("@obj_CentralValueAddedTaxRegistrationNumber", cenvatno);
                        da.SelectCommand.Parameters.AddWithValue("@obj_ServiceTaxRegistrationNumber", servicetaxno);
                        da.SelectCommand.Parameters.AddWithValue("@obj_YearOfEstablishment", YOE);
                        da.SelectCommand.Parameters.AddWithValue("@obj_TurnOver", Turnover);
                        da.SelectCommand.Parameters.AddWithValue("@obj_WebsiteURL", URL);
                        da.SelectCommand.ExecuteNonQuery();
                        res = 1;



                    }
                    catch (Exception exe)
                    {
                        res = 0;
                    }
                    finally
                    {
                        conn.Close();
                    }
             
            }

        }
        //Insert Data into CustomerAdress Location 
        using(SqlConnection con=new SqlConnection(connStr))
        {
            using (SqlCommand comm1 = new SqlCommand("Insert_BizConnect_TransporterAddressLocation", con))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                con.Open();
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
                con.Close();
            }
        }
    }
        return res;
    }
    //Transporter RoutepriceReport
    public DataSet get_RoutePriceReport(int Type, int EnclType, int TruckType, int Capacity)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_RoutepriceReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.SelectCommand.Parameters.Add("@obj_Type", Type);
                    ada.SelectCommand.Parameters.Add("@obj_EnclType", EnclType);
                    ada.SelectCommand.Parameters.Add("@obj_TruckType", TruckType);
                    ada.SelectCommand.Parameters.Add("@obj_Capacity", Capacity);
                    comm.CommandTimeout = 30000;
                    ada.Fill(ds, "LocationType");
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return ds;
    }

    //Get TruckType
    public DataSet Get_TruckType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_TruckType", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds, "TruckType");
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return ds;
    }
    //Get Get_Units
    public DataSet Get_Units()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_Units", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds, "Get_Units");
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return ds;
    }
    
    
 public DataSet Get_Report_Routeprice()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_Report_RoutePrice", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Get_routeprice");
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return ds;
    }

    
 public DataSet   Get_TruckConfirmationDetails(int ClientID,string ProjectNo)
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_ConsignmentDetails", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.Add("@obj_ClientID", ClientID);
                ada.SelectCommand.Parameters.Add("@obj_ProjectNo", ProjectNo);
                try
                {
                    conn.Open();
                    ada.Fill(ds,"Report");
                    //ada.Fill(ds);
                }
                catch (Exception err)
                {

                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return ds;
    }
    
}
