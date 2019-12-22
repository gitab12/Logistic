using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for ClientsReport
/// </summary>
public class ClientsReport
{

    public int res;
    ArrayList arr = new ArrayList();
    int resp = 0;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    SqlConnection obj_GSTConn = new SqlConnection();
    string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    SqlCommand cmd = new SqlCommand();
    public ClientsReport()
    {
        
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        string GSTConnStr = ConfigurationManager.ConnectionStrings["GST"].ConnectionString;

        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;
        obj_GSTConn.ConnectionString = GSTConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
        obj_GSTConn.Open();
    }

    //BizConnect_UserTripAssignReport
    public DataSet   BizConnect_UserTripAssignReport(int obj_UserID)
    {
        DataSet ds = new DataSet();
        using (SqlCommand comm = new SqlCommand("BizConnect_UserTripAssignReport", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
            try
            {
                ada.Fill(ds,"Report");
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
    //Bizconnect_DeliveryReport

    public DataSet Bizconnect_DeliveryReport(int obj_ClientID, int obj_ClientAdrID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_DeliveryReport", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            try
            {
                ada.Fill(ds, "LocationType");
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
    
     //BizConnect_SearchTripAssignReport By Requirementdate and Status 
     public DataSet   BizConnect_SearchTripAssignByReqDateAndStatus(DateTime Requirementdate,string Status,string ProjectNo,int Userid)
    {
        DataSet ds = new DataSet();
        using (SqlCommand comm = new SqlCommand("BizConnect_SearchTripAssignByReqDateAndStatus", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            //ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@RequirementDate", Requirementdate);
            ada.SelectCommand.Parameters.AddWithValue("@Status", Status);
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@Userid", Userid );
            try
            {
                ada.Fill(ds,"Report");
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

     public DataSet BizConnect_SearchTripAssignByReqDateAndStatusbyMonth(int UserID,int Month,int Year)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("BizConnect_Get_UserTripAssignMonthlyReport", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;    
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", UserID);       
            ada.SelectCommand.Parameters.AddWithValue("@Month", Month);
            ada.SelectCommand.Parameters.AddWithValue("@Year", Year);
            try
            {
                ada.Fill(ds, "TripAssign");
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
    
    public DataTable  BizConnect_Get_ThermaxProjectNO(int ClientID)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct ProjectID ,ProjectNo  from Bizconnect_ProjectMaster where ClientID ="+ ClientID +"order by ProjectNo" , obj_BizConn))
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
    
    public SqlDataReader  Bizconnect_RebidlogReport(int UserID)
    {
        SqlConnection obj_BizConn = new SqlConnection(BizConnStr);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Bizconnect_RebidlogReport";
        cmd.Parameters.AddWithValue("@obj_UserID", UserID);
        cmd.Connection = obj_BizConn;
        obj_BizConn.Open();
        SqlDataReader Datareader = cmd.ExecuteReader();
        return Datareader;
    }


    public SqlDataReader Bizconnect_Search_RebidlogReport(int UserID,DateTime BidDate)
    {
        SqlConnection obj_BizConn = new SqlConnection(BizConnStr);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "Bizconnect_Search_RebidlogReport";
        cmd.Parameters.AddWithValue("@obj_UserID", UserID);
        cmd.Parameters.AddWithValue("@obj_BidDate", BidDate);
        cmd.Connection = obj_BizConn;
        obj_BizConn.Open();
        SqlDataReader Datareader = cmd.ExecuteReader();
        return Datareader;
    }
    
    public DataTable  Bizconnect_ThermaxCnote_LoadWBSNoByProjectNo(string ProjectNo)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxCnote_LoadWBSNoByProjectNo", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
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



public DataTable Bizconnect_Search_PreloadingDetailsByprojectandWbsno( int ClientID,int ClientAddID,string ProjectNo,string Wbsno)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_Search_PreloadingDetailsByprojectandWbsno", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID",ClientID );
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", ClientAddID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Wbsno", Wbsno);
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
    
    
    public DataTable Bizconnect_LoadReceivedWbsnoByProjectNo(int ClientID,int ClientAddID, string ProjectNo)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_LoadReceivedWbsnoByProjectNo", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID",ClientID );
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", ClientAddID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
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



 public DataTable Bizconnect_Search_ReceivedDetailsByWbsAndProjectNo(int ClientID, int ClientAddID, string ProjectNo, string Wbsno,string LrNo)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_Search_ReceivedDetailsByWbsAndProjectNo", obj_BizConn))
        {

            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", ClientAddID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_WbsNo", Wbsno);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Lrno", LrNo);
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
    
    public DataTable  Bizconnect_Search_DeliveryReportByProjectNoAndWbSNo(int obj_ClientID, int obj_ClientAdrID,string ProjectNo ,string WBSNo)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_Search_DeliveryReportByProjectNoAndWbSNo", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@WBSNo", WBSNo);
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
    //Trip Cancellation 

    public DataSet BizConnect_TripCancellation(int obj_UserID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("BizConnect_TripCancellation", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
            try
            {
                ada.Fill(ds, "LocationType");
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

    public DataTable BizConnect_LoadPjtNoForUpdateloadinginfo(int ClientID, int ClientAddID)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand(" select distinct cn.ProjectNo from dbo.BizConnect_TripAssign TA  left join (select AgreementRouteID    from dbo.Bizconnect_AgreementRoutes) TR on TR.AgreementRouteID=TA.AgreementRouteID  inner join dbo.bizconnect_TripAcceptanceDetails TD  on TA.TripAssignID =TD.TripAssignID    inner join dbo.Bizconnect_PreloadDetails PD  on PD.AcceptanceID =TD.AcceptanceID  left join (Select rid from aarmjunction.dbo.scmjunction_registration     )r on r. rid=td.TransporterID   left join (select CollectionNoteID ,ProjectNo ,WBSNo  from CollectionNote )    cn on cn.CollectionNoteID =ta.IndentID  where td.ClientID=" + ClientID + " and td.ClientAddressLocationID=" + ClientAddID + " and  TD.LoadedStatus=1 order by ProjectNo", obj_BizConn))
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

    public DataTable BizConnect_LoadWBSNoForUpdateloadinginfo(int ClientID, int ClientAddID, string ProjectNo)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct cn.WBSNo from dbo.BizConnect_TripAssign TA  left join (select AgreementRouteID    from dbo.Bizconnect_AgreementRoutes) TR on TR.AgreementRouteID=TA.AgreementRouteID  inner join dbo.bizconnect_TripAcceptanceDetails TD  on TA.TripAssignID =TD.TripAssignID    inner join dbo.Bizconnect_PreloadDetails PD  on PD.AcceptanceID =TD.AcceptanceID  left join (Select rid from aarmjunction.dbo.scmjunction_registration     )r on r. rid=td.TransporterID   left join (select CollectionNoteID ,ProjectNo ,WBSNo  from CollectionNote )    cn on cn.CollectionNoteID =ta.IndentID  where td.ClientID=" + ClientID + " and td.ClientAddressLocationID=" + ClientAddID + " and cn.ProjectNo ='" + ProjectNo + "' and TD.LoadedStatus=1 order by cn.WBSNo", obj_BizConn))
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

}
