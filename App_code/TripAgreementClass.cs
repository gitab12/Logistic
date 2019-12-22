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
/// Summary description for TripAgreement
/// </summary>
public class TripAgreementClass
{
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    int resp = 0;
    
    private string _FromLocation;
    private string _ToLocation;
    private int _EnclType;
    private int _TruckType;
     private int _AgreementID;
    private float _RateperKg;
    private string _DeliveryPeriod;
    private float _Othercharges;
    private float _LrCharges;
    private float _DoorDelCharges;
    private float _DoorColCharges;




    public int AgreementID
    {
        get { return _AgreementID; }
        set { _AgreementID = value; }
    }

    public string FromLocation
    {
        get { return _FromLocation; }
        set { _FromLocation = value; }
    }
    public string ToLocation
    {
        get { return _ToLocation; }
        set { _ToLocation = value; }
    }
    public int EnclosureType
    {
        get { return _EnclType; }
        set { _EnclType = value; }
    }
    public int TruckType
    {
        get { return _TruckType ; }
        set { _TruckType = value; }
    }
    public float  RatePerKG
    {
        get { return _RateperKg; }
        set { _RateperKg = value; }
    }
    public string DeliveryPeriod
    {
        get { return _DeliveryPeriod ; }
        set { _DeliveryPeriod = value; }
    }
    public float OtherCharges
    {
        get { return _Othercharges; }
        set { _Othercharges = value; }
    }
    
    public float LRCharges
    {
        get { return _LrCharges; }
        set { _LrCharges = value; }
    }
    public float DoorDeliveryCharges
    {
        get { return _DoorDelCharges; }
        set { _DoorDelCharges = value; }
    }
    public float DoorCollectionCharges
    {
        get { return _DoorColCharges; }
        set { _DoorColCharges = value; }
    }

    public int ClientID
    {
        get;
        set;
    }


    public TripAgreementClass()
    {
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
    }

    //Get Client

    public DataSet Bizconnect_GetClient()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_Client", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.Fill(ds, "Client");
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
    //Get_Transporter
    public DataSet Get_Transporter()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_Transporter", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.Fill(ds, "Transporter");
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
    //checking .......

    public DataTable GetAgreementID(int ClientID, int ClientAdrID, int TransporterID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("GetAgreementID", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", ClientAdrID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", TransporterID);
                ada.Fill(dt);
                //SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                //if (dr.HasRows)
                //{
                //    dr.Read();

                //    resp = Convert.ToInt32(dr[0].ToString());

                //}
            }

            catch (Exception err)
            {
                resp = 0;

            }
            finally
            {

            }
        }
        return dt;

    }

    public int Insert_AgreementRoute(int ClientID, int ClientAdrID, int TransporterID, int AgreementID, string FromLocation, string ToLocation, int EnclTypeID, int TruckTypeID, string Capacity, float DecidedPrice, int transitdays)
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_Insert_Bizconnect_AgreementRoutes", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddressLocationID", ClientAdrID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", TransporterID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_AgreementID", AgreementID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FromLocation", FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ToLocation", ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_EnclTypeID", EnclTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", TruckTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", Capacity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_DecidedPrice", DecidedPrice);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransitDay", transitdays);
                ada.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception err)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;

    }
    public DataTable DisplayAgreementRoutes(int ClientID, int ClientAdrID, int TransporterID)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        try
        {
            SqlCommand comm = new SqlCommand("DisplayAgreementRoutes", obj_BizConn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@obj_ClientID", ClientID);
            comm.Parameters.AddWithValue("@obj_AdrID", ClientAdrID);
            comm.Parameters.AddWithValue("@obj_TransporterID", TransporterID);
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
    
    public DataTable DisplayParcelAgreementDetails(int ClientID, int ClientAdrID, int TransporterID)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        try
        {
            SqlCommand comm = new SqlCommand("DisplayParcelAgreementDetails", obj_BizConn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@obj_ClientID", ClientID);
            comm.Parameters.AddWithValue("@obj_AdrID", ClientAdrID);
            comm.Parameters.AddWithValue("@obj_TransporterID", TransporterID);
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }


    //Bizconnect_InsertAgreement

    public int Bizconnect_InsertAgreement(int ClientID, int ClientAdrID, int TransporterID, int Mode)
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertAgreement", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", ClientAdrID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", TransporterID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Mode", Mode);
                ada.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception err)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;
    }
    
    // Insert ParcelAgreementDetails
public int Insert_ParcelAgreementDetails()
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertParcelAgreementDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
             ada.SelectCommand.Parameters.AddWithValue("@AgreementID",AgreementID);
           
                ada.SelectCommand.Parameters.AddWithValue("@Fromlocation",FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@Tolocation",ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@EnclosureType", EnclosureType);
                ada.SelectCommand.Parameters.AddWithValue("@TruckType",TruckType );
                ada.SelectCommand.Parameters.AddWithValue("@RateperKg", RatePerKG);
                ada.SelectCommand.Parameters.AddWithValue("@DeliveryPeriod", DeliveryPeriod);
                ada.SelectCommand.Parameters.AddWithValue("@OtherCharges",OtherCharges );
                ada.SelectCommand.Parameters.AddWithValue("@Lrcharges", LRCharges);
                ada.SelectCommand.Parameters.AddWithValue("@DoorDeliveryCharges", DoorDeliveryCharges);
                ada.SelectCommand.Parameters.AddWithValue("@DoorCollectionCharges", DoorCollectionCharges);
                ada.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception err)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;

    }
//Display agreement Details into grid
    public DataTable Agreement_Details(int obj_ClientID)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        try
        {
        
        
            SqlCommand comm = new SqlCommand("Bizconnect_DisplayAgreementDetails", obj_BizConn);
            
            
            SqlDataAdapter adp = new SqlDataAdapter(comm);
              adp.SelectCommand.CommandType = CommandType.StoredProcedure;
             adp.SelectCommand.Parameters.AddWithValue("@obj_ClientID",obj_ClientID);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
        }
         return dt;
    }
    
     public DataSet Bizconnect_GetUniqueClient(string Clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_UniqueClient", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_Clientid", Clientid);
            try
            {
                ada.Fill(ds, "ClientID");
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

     public DataTable GetFromLocation(string FromLoc)
     {
         DataTable dt = new DataTable();
         using (SqlCommand comm = new SqlCommand("Bizconnect_GetFromLocToAutoComplete", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
             ada.SelectCommand.Parameters.AddWithValue("@FromLoc", FromLoc);
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

     public DataTable GetToLocation(string ToLoc)
     {
         DataTable dt = new DataTable();
         using (SqlCommand comm = new SqlCommand("Bizconnect_GetToLocToAutoComplete", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
             ada.SelectCommand.Parameters.AddWithValue("@ToLoc", ToLoc);
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







     public int InsertintoAgreementRoute(int ClientID, int ClientAdrID, int TransporterID, int AgreementID, string FromLocation, string ToLocation, int EnclTypeID, int TruckTypeID, string Capacity, float DecidedPrice, int transitdays,string EmailID)
     {

         using (SqlCommand comm = new SqlCommand("Bizconnect_InsertintoBizconnect_AgreementRoutes", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;

             try
             {
                 ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddressLocationID", ClientAdrID);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", TransporterID);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_AgreementID", AgreementID);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_FromLocation", FromLocation);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_ToLocation", ToLocation);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_EnclTypeID", EnclTypeID);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", TruckTypeID);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", Capacity);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_DecidedPrice", DecidedPrice);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_TransitDay", transitdays);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_emailid", EmailID);
                 ada.SelectCommand.ExecuteNonQuery();
                 resp = 1;
             }
             catch (Exception err)
             {
                 resp = 0;
             }
             finally
             {

             }
         }
         return resp;
     }
}
