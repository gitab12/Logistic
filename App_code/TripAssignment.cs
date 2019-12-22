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
/// Summary description for TripAssignment
/// </summary>
public class TripAssignment
{
    int resp = 0;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    int ResultID;
    public TripAssignment()
    {
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
    }
    //Get Trip Plan for  assignment 
    public DataSet Bizconnect_AssignTrip()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("bizconnect_AssignTrip", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            // ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            try
            {
                ada.Fill(ds, "TripAssignment");
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

    //Get Trucks for  assignment 
    public DataSet Bizconnect_TruckAssign(int obj_UserID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_TruckAssignment", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);

            try
            {
                ada.Fill(ds, "TripAssignment");
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
   
    //Insert Trip

    public int Bizconnect_InsertTripAssign(int AgreementRouteID, string obj_FromLoc, string obj_ToLoc, string obj_TruckType, string obj_EnclType, string obj_Capacity, int obj_DecidePrice, int obj_TransporterID, int obj_TrucksReq, DateTime obj_Date, string obj_TravelTime, int obj_UserID,string obj_remarks)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertTripAssign", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_AgreementRouteID", AgreementRouteID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_FromLoc", obj_FromLoc);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ToLoc", obj_ToLoc);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TruckType", obj_TruckType);
            ada.SelectCommand.Parameters.AddWithValue("@obj_EnclType", obj_EnclType);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", obj_Capacity);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DecidePrice", obj_DecidePrice);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TrucksReq", obj_TrucksReq);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDate", obj_Date);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelTime", obj_TravelTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);//@obj_remarks
            ada.SelectCommand.Parameters.AddWithValue("@obj_remarks", obj_remarks);
            ada.SelectCommand.ExecuteNonQuery();
            try
            {
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
//    //Insert Tripwith indent

    public int Bizconnect_InsertTripAssignwithIndent(int AgreementRouteID, string obj_FromLoc, string obj_ToLoc, string obj_TruckType, string obj_EnclType, string obj_Capacity, int obj_DecidePrice, int obj_TransporterID, int obj_TrucksReq, DateTime obj_Date, string obj_TravelTime, int obj_UserID,int obj_IndentID)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertTripAssignwithIndent", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_AgreementRouteID", AgreementRouteID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_FromLoc", obj_FromLoc);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ToLoc", obj_ToLoc);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TruckType", obj_TruckType);
            ada.SelectCommand.Parameters.AddWithValue("@obj_EnclType", obj_EnclType);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", obj_Capacity);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DecidePrice", obj_DecidePrice);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TrucksReq", obj_TrucksReq);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDate", obj_Date);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelTime", obj_TravelTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
             ada.SelectCommand.Parameters.AddWithValue("@obj_IndentID", obj_IndentID);
            ada.SelectCommand.ExecuteNonQuery();
            try
            {
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




//Get Trip Routes for Acceptance without Agreement 
    public DataSet Bizconnect_TripAcceptancewithoutAgreement(int obj_TransporterID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_TripAcceptancewithoutAgreement", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
           
            try
            {
                ada.Fill(ds, "TripAssignment");
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





    //Get Trip Routes for Acceptance
    public DataSet Bizconnect_TripAcceptance(int obj_TransporterID, string obj_AgreementRouteID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_TripAcceptance", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_AgreementRouteID", obj_AgreementRouteID);

            try
            {
                ada.Fill(ds, "TripAssignment");
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
    //Insert TripConfirmAcceptance

    public int Bizconnect_InsertTripAcceptanceDetails(int obj_TransporterID, int obj_ClientID, int obj_ClientAddressLocationID, int obj_TripAssignID, string obj_VehicleNo, string obj_DriverName, string obj_MobileNo, DateTime VehiclePlacementDatetime)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertTripAcceptanceDetails", obj_BizConn))
        {
            try
            {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddressLocationID", obj_ClientAddressLocationID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TripAssignID", obj_TripAssignID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_VehicleNo", obj_VehicleNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DriverName", obj_DriverName);
            ada.SelectCommand.Parameters.AddWithValue("@obj_mobileNo", obj_MobileNo);
            ada.SelectCommand.Parameters.AddWithValue("@VehiclePlaceemntDateTime", VehiclePlacementDatetime);

            ada.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            ada.SelectCommand.ExecuteNonQuery();
            ResultID = Convert.ToInt32(ada.SelectCommand.Parameters["@Result"].Value);
            
            }
            catch (Exception err)
            {
                ResultID = 0;
            }
            finally
            {

            }
        }
        return ResultID;
    }
    //Get TripAcceptance Details

    public DataSet TripAcceptance(string @obj_TripAssignID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("TripAcceptance", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_TripAssignID", @obj_TripAssignID);

            ada.SelectCommand.ExecuteNonQuery();
            try
            {

                ada.Fill(ds, "AcceptanceDetails");
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
//FillProject
    public DataSet FillProject(int @obj_ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("FillProject", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", @obj_ClientID);

            ada.SelectCommand.ExecuteNonQuery();
            try
            {

                ada.Fill(ds, "FillProject");
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

  //Bizconnect_ConfirmCollectionNote

    public Int32 Bizconnect_ConfirmCollectionNote(int ConfirmationID, DateTime PlacementDate)
    {
        int resp = 0;

        using (SqlCommand comm = new SqlCommand("Bizconnect_ConfirmCollectionNote", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteID", ConfirmationID);
            ada.SelectCommand.Parameters.AddWithValue("@PlacementDate", PlacementDate);
            ada.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        return resp;
    }

//Abandon of CollectionNote
    public Int32 Bizconnect_AbandonCollectionNote(int ConfirmationID, int CollectionNoteAcceptanceFlag, string Remarks)
    {
        int resp = 0;

        using (SqlCommand comm = new SqlCommand("Bizconnect_AbandonCollectionNote", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteID", ConfirmationID);
            ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteAcceptanceFlag", CollectionNoteAcceptanceFlag);
            ada.SelectCommand.Parameters.AddWithValue("@Remarks", Remarks);
            ada.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        return resp;
    }
    
    //Bizconnect_CollectionNoteApproval

    public Int32 Bizconnect_ApprovalCollectionNote(int ConfirmationID, DateTime PlacementDate, int VehiclePlanned, string FromLocation, string ToLocation, string Description, string  TruckType,string ApprovalNo,int SignID,double DiffAmount,string ApprovalJustification)
    {
        int resp = 0;

        using (SqlCommand comm = new SqlCommand("Bizconnect_ApprovalCollectionNote", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteID", ConfirmationID);
            ada.SelectCommand.Parameters.AddWithValue("@PlacementDate", PlacementDate);
            ada.SelectCommand.Parameters.AddWithValue("@VehiclePlanned", VehiclePlanned);
            ada.SelectCommand.Parameters.AddWithValue("@FromLocation", FromLocation);
            ada.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
            ada.SelectCommand.Parameters.AddWithValue("@Description", Description);
            ada.SelectCommand.Parameters.AddWithValue("@TruckType", TruckType);
            ada.SelectCommand.Parameters.AddWithValue("@ApprovalNo", ApprovalNo);
            ada.SelectCommand.Parameters.AddWithValue("@SignID", SignID);
            ada.SelectCommand.Parameters.AddWithValue("@DiffAmount", DiffAmount);
             ada.SelectCommand.Parameters.AddWithValue("@ApprovalJustification", ApprovalJustification);
            ada.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        return resp;
    }


    public DataTable Bizconnect_AarmsAttachedVechicleReport()
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("Bizconnect_AarmsAttachedVechicleReport", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            ada.SelectCommand.ExecuteNonQuery();
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

    public DataTable Bizconnect_LoadTrucksRequirement(int ClientID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("select FromLocation,ToLocation ,TruckType ,Convert(varchar(20),TravelDateTimeStamp,106) as Date, NoOfTrucks as TrucksReq from BizConnect_LogisticsPlan LP inner join BizConnect_TruckTypeMaster tt on tt.TruckTypeID=lp.TruckTypeID where clientid=" + ClientID + "  and LocationTypeID in(1,3)   order by LogisticsPlanID desc", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;

            ada.SelectCommand.ExecuteNonQuery();
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


    //Get Trucks for  TripRequestassignment 
    public DataTable Bizconnect_TripRequestAssignment(int ClientID, DateTime TravelDate)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("Bizconnect_TripRequestAssignment", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@TravelDate", TravelDate);

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

    //Insert TripRequestAssignment

    public int Bizconnect_InsertTripAssign(int AgreementRouteID, string obj_FromLoc, string obj_ToLoc, string obj_TruckType, string obj_EnclType, string obj_Capacity, int obj_DecidePrice, int obj_TransporterID, int obj_TrucksReq, DateTime obj_Date, string obj_TravelTime, int obj_UserID, int LogisticPlanID)
    {

        using (SqlCommand comm = new SqlCommand("[Bizconnect_InsertTripRequestAssignment]", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_AgreementRouteID", AgreementRouteID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_FromLoc", obj_FromLoc);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ToLoc", obj_ToLoc);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TruckType", obj_TruckType);
            ada.SelectCommand.Parameters.AddWithValue("@obj_EnclType", obj_EnclType);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", obj_Capacity);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DecidePrice", obj_DecidePrice);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TrucksReq", obj_TrucksReq);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDate", obj_Date);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelTime", obj_TravelTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LogisticPlanID", LogisticPlanID);
           
            ada.SelectCommand.ExecuteNonQuery();
            try
            {
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


    public DataTable Bizconnect_CheckTripIndentIDExistance(int IndentID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("select count (*) as Count from BizConnect_TripAssign where IndentID =" + IndentID, obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
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


    public DataTable Bizconnect_CheckCnNoteAcceptacneFlag(int CnNoteID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("select CollectionNoteAcceptanceFlag  from CollectionNote where CollectionNoteID =" + CnNoteID + "", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;

            ada.SelectCommand.ExecuteNonQuery();
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

    public DataTable Bizconnect_GetTransporterEmailIDForSendingTripConfirmMail(int TransporterID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand(" select Email +(',')+ isnull(secEmail,'') as Email,mobile from aarmjunction .dbo.scmjunction_registration where rid=" + TransporterID + "", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            ada.SelectCommand.ExecuteNonQuery();
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
}
