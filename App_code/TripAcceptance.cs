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
/// Summary description for TripAcceptance
/// </summary>
public class TripAcceptance
{
    int resp = 0;

    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    SqlDataReader dr;
    public TripAcceptance()
    {
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();

        
    }

    //Get Confirmation Number
    public DataSet Get_ConfirmNumber(int obj_ClientID, int obj_ClientAdrID)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_ConfirmNumber", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("obj_ClientAdrID", obj_ClientAdrID);
            try
            {

                ada.Fill(ds, "TruckType");
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
    //Get PreloadingDetails
    public DataSet Get_PreloadingDetails(int obj_ClientID, int obj_ClientAdrID)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_PreloadingDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            // ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            try
            {

                ada.Fill(ds, "TruckType");
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
    //Get PreloadingDetails by Cofirmation Date
    public DataSet Get_PreloadingDetails(int obj_ClientID, int obj_ClientAdrID,DateTime Date1, DateTime Date2)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_PreloadingDetailsSearchbyConfirmDate", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@date1", Date1);
            ada.SelectCommand.Parameters.AddWithValue("@date2", Date2);

            try
            {

                ada.Fill(ds, "TruckType");
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


    //Insert LoadingDetails
     public int Bizconnect_InsertLoadingDetails(int obj_AcceptanceID, DateTime obj_LoadingTime, DateTime obj_TripTime, string obj_LRNumber, DateTime obj_DeliveryDate, byte[] obj_image, string obj_imageext, string obj_imagename, byte[] obj_Rearimage, byte[] obj_LeftImage, byte[] obj_RightImage,string ERoadNo,DateTime LoadingDate,int Speedometer)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertLoadingDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LoadingTime", obj_LoadingTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TripTime", obj_TripTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNumber", obj_LRNumber);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DeliveryDate", obj_DeliveryDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Image", obj_image );
            ada.SelectCommand.Parameters.AddWithValue("@obj_ImageExt", obj_imageext );
            ada.SelectCommand.Parameters.AddWithValue("@obj_ImageName", obj_imagename );
            ada.SelectCommand.Parameters.AddWithValue("@RearImage", obj_Rearimage);
            ada.SelectCommand.Parameters.AddWithValue("@LeftImage", obj_LeftImage);
            ada.SelectCommand.Parameters.AddWithValue("@RightImage", obj_RightImage);
            ada.SelectCommand.Parameters.AddWithValue("@ERoadNo", ERoadNo);
             ada.SelectCommand.Parameters.AddWithValue("@LoadingDate", LoadingDate);
             ada.SelectCommand.Parameters.AddWithValue("@Speedometer", Speedometer);
           
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
    
    
   
 //Insert LoadingDetailswithoutimage
    public int Bizconnect_InsertLoadingDetailswithoutimage(int obj_AcceptanceID, DateTime obj_LoadingTime, DateTime obj_TripTime, string obj_LRNumber, DateTime obj_DeliveryDate, double obj_Weight , DateTime obj_LoadingDate,string ERoadNo,int Speedometer)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertLoadingDetailswithoutimage", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LoadingTime", obj_LoadingTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TripTime", obj_TripTime);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNumber", obj_LRNumber);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DeliveryDate", obj_DeliveryDate);
             ada.SelectCommand.Parameters.AddWithValue("@obj_Weight", obj_Weight);
              ada.SelectCommand.Parameters.AddWithValue("@obj_LoadingDate", obj_LoadingDate);
              ada.SelectCommand.Parameters.AddWithValue("@ERoadNo", ERoadNo);
              ada.SelectCommand.Parameters.AddWithValue("@Speedometer",Speedometer);
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


    //Get ReceivedDetails
    public DataSet Bizconnect_Received(int obj_ClientID,int obj_ClientAdrID )
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_Received", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            // ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            try
            {

                ada.Fill(ds, "TruckType");
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
    
    
     //Get Receiving Infp
    public DataSet Bizconnect_Receivedinfo(int obj_ClientID,int obj_ClientAdrID ,int obj_AcceptanceID)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_Receivedinfo", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
             ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            try
            {

                ada.Fill(ds, "TruckType");
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
    //Insert ReceivingDetails
    public int Bizconnect_InsertReceivingDetails(int obj_PLid, int obj_AcceptanceID, string obj_LRNumber, DateTime obj_ReceivedDate, string obj_Remarks,DateTime obj_UnLoadingDate,string obj_VehicleNo,int Speedometer)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertReceivingDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_PLid", obj_PLid);
            ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNumber", obj_LRNumber);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ReceivedDate", obj_ReceivedDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Remarks", obj_Remarks);
              ada.SelectCommand.Parameters.AddWithValue("@obj_UnLoadingDate", obj_UnLoadingDate);
              ada.SelectCommand.Parameters.AddWithValue("@obj_VehicleNo", obj_VehicleNo);
              ada.SelectCommand.Parameters.AddWithValue("@Speedometer",Speedometer);
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
    
    
    //Insert ReceivingDetailswith image
    public int Bizconnect_InsertReceivingDetailsWithImage(int obj_PLid, int obj_AcceptanceID, string obj_LRNumber, DateTime obj_ReceivedDate, string obj_Remarks,DateTime obj_UnLoadingDate,string obj_VehicleNo,byte[] FrontImage,byte[] RearImage,byte[] ImageLeft,byte[] ImageRight)
    {

        using (SqlCommand comm = new SqlCommand("Bizconnect_InsertReceivingDetailsWithImage", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_PLid", obj_PLid);
            ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNumber", obj_LRNumber);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ReceivedDate", obj_ReceivedDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Remarks", obj_Remarks);
              ada.SelectCommand.Parameters.AddWithValue("@obj_UnLoadingDate", obj_UnLoadingDate);
              ada.SelectCommand.Parameters.AddWithValue("@obj_VehicleNo", obj_VehicleNo);
              ada.SelectCommand.Parameters.AddWithValue("@FrontImage", FrontImage);
              ada.SelectCommand.Parameters.AddWithValue("@RearImage", RearImage);
              ada.SelectCommand.Parameters.AddWithValue("@LeftImage", ImageLeft);
              ada.SelectCommand.Parameters.AddWithValue("@RightImage", ImageRight);
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
    
    
   //Get LoadingDetails
    public DataSet Get_LoadingDetails_Info(int obj_ClientID, int obj_ClientAdrID, int obj_TransporterID)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_LoadingDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", obj_TransporterID);
           
            try
            {

                ada.Fill(ds, "TruckType");
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
    
     public DataSet Bizconnect_SearchReceivedinfobyLRNumber(int obj_ClientID,  string LRNumber)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_SearchReceivedinfobyLRNumber", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            //ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNumber", LRNumber);
            try
            {
                ada.Fill(ds, "SearchLRNumber");
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

public DataTable Bizconnect_GetClientEmail(int obj_ClientID)
    {
        DataTable ds = new DataTable();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_GetClientEmail", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            try
            {
                ada.Fill(ds);
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
    
     //Retreving Email ID of Client for CC
    public DataSet get_EmailIDCCstoClient(int obj_ClientID)
    {
        String obj_Email;
        string obj_Rid;
        DataSet ds = new DataSet();
        Int32 resp = 3;
      
            using (SqlCommand comm = new SqlCommand("get_EmailIDCCstoClient", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
                try
                {
                   
                    ada.Fill(ds,"getccs");

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
    
    
 public DataTable Bizconnect_GetUniqueClientEmail(int obj_ClientID)
    {
        DataTable dt = new DataTable();
        dt.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_GetUniqueClientEmail", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
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
 public DataTable Bizconnect_GetClientEmailForReceivingPoint(int obj_ClientID, string obj_ProjectNo)
    {
        DataTable ds = new DataTable();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_GetClientEmailForReceivingPoint", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", obj_ProjectNo);
            try
            {
                ada.Fill(ds);
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
    
    public DataTable Bizconnect_GetReceivingPointEmail(int obj_AgreeMentID)
    {
        DataTable ds = new DataTable();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_GetReceivingPointEmail", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_AgreeMentID", obj_AgreeMentID);
            try
            {
                ada.Fill(ds);
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
    
    public DataSet Bizconnect_SearchVehiclePlaced(int ClientID,string Tolocation,DateTime Fromdate,DateTime Todate)
    {
        DataSet ds = new DataSet();

        using (SqlCommand comm = new SqlCommand("Bizconnect_SearchVehiclePlaced", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@Tolocation", Tolocation);
            ada.SelectCommand.Parameters.AddWithValue("@FromDate", Fromdate);
            ada.SelectCommand.Parameters.AddWithValue("@ToDate", Todate);
            try
            {

                ada.Fill(ds, "Searchvehplaced");

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
    
    //public DataTable  Update_PreloadingDetails(int obj_ClientID, int obj_ClientAdrID)
    //{
    //    DataTable dt = new DataTable();
    //    //ds.Clear();

    //    using (SqlCommand comm = new SqlCommand("Update_BizconnectPreloadDetails", obj_BizConn))
    //    {
    //        SqlDataAdapter ada = new SqlDataAdapter(comm);
    //        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
    //        ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
    //        ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddID", obj_ClientAdrID);      
    //        try
    //        {

    //            ada.Fill(dt);
    //        }
    //        catch (Exception err)
    //        {

    //        }
    //        finally
    //        {

    //        }

    //    }
    //    return dt;
    //}


    public SqlDataReader Update_PreloadingDetails(int obj_ClientID, int obj_ClientAdrID)
    {
        //SqlDataReader dr;
        using (SqlCommand comm = new SqlCommand("Update_BizconnectPreloadDetails", obj_BizConn))
        {
            //SqlDataAdapter ada = new SqlDataAdapter(comm);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            comm.Parameters.AddWithValue("@obj_ClientAddID", obj_ClientAdrID);
            obj_BizConn.Close();
            obj_BizConn.Open();
            try
            {
                dr = comm.ExecuteReader();
            }
            catch (Exception err)
            {

            }
            finally
            {

            }

        }
        return dr;
    }



    public int Bizconnect_Update_Preloaddetails(int obj_PLid, int obj_AcceptanceID, string VehicleNo, string Name, string MobNo, DateTime obj_RptDate, DateTime obj_LoadDate, DateTime obj_ReleaseDate, double obj_weight, string obj_ERoadNo,string LRNo, byte[] obj_truckimage, string obj_imageext, string obj_imagename, byte[] obj_Rearimage, byte[] obj_LeftImage, byte[] obj_RightImage, DateTime obj_DeliveryDate)
    {

        using (SqlCommand comm = new SqlCommand("Update_Preloaddetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_PLid", obj_PLid);
            ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_VehicleNo", VehicleNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Name", Name);
            ada.SelectCommand.Parameters.AddWithValue("@obj_MobNo", MobNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ReportDate", obj_RptDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LoadDate", obj_LoadDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ReleaseDate", obj_ReleaseDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Weight", obj_weight);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ERoad", obj_ERoadNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNo",LRNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TruckImg", obj_truckimage);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Imgext", obj_imageext);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ImgName", obj_imagename);
            ada.SelectCommand.Parameters.AddWithValue("@obj_RearImg", obj_Rearimage);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ImgLeft", obj_LeftImage);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ImgRight", obj_RightImage);
            ada.SelectCommand.Parameters.AddWithValue("@obj_DeliveryDate", obj_DeliveryDate);

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



    public int Bizconnect_Update_PreloaddetailsWithoutImages(int obj_PLid, int obj_AcceptanceID, string VehicleNo, string Name, string MobNo, DateTime obj_RptDate, DateTime obj_LoadDate, DateTime obj_ReleaseDate, double obj_weight, string obj_ERoadNo,string LRNo, DateTime obj_DeliveryDate)
    {

        using (SqlCommand comm = new SqlCommand("Update_PreloaddetailsWithoutImages", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_PLid", obj_PLid);
            ada.SelectCommand.Parameters.AddWithValue("@obj_AcceptanceID", obj_AcceptanceID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_VehicleNo", VehicleNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Name", Name);
            ada.SelectCommand.Parameters.AddWithValue("@obj_MobNo", MobNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ReportDate", obj_RptDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LoadDate", obj_LoadDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ReleaseDate", obj_ReleaseDate);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Weight", obj_weight);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ERoad", obj_ERoadNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LRNo",LRNo );
            ada.SelectCommand.Parameters.AddWithValue("@obj_DeliveryDate", obj_DeliveryDate);

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

    public DataTable Search_UpdateBizconnectPreloadDetailsByprojectAndWbsno(int obj_ClientID, int obj_ClientAdrID, string ProjectNo, string WBSNo)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("Search_UpdateBizconnectPreloadDetailsByprojectAndWbsno", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddID", obj_ClientAdrID);
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

    // Get_PreloadingDetailsByAcceptanceID
    public DataTable Get_PreloadingDetailsByAcceptanceID(int obj_ClientID, int obj_ClientAdrID, int AcceptanceID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("Get_PreloadingDetailsByAcceptanceID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            ada.SelectCommand.Parameters.AddWithValue("@AcceptanceID", AcceptanceID);
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

    public DataTable Bizconnect_LoadUpdateloadinginfoByAcceptacneID(int obj_ClientID, int obj_ClientAdrID, int AcceptanceID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("Bizconnect_LoadUpdateloadinginfoByAcceptacneID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddID", obj_ClientAdrID);
            ada.SelectCommand.Parameters.AddWithValue("@AcceptanceID", AcceptanceID);
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

    public DataTable Bizconnect_LoadProductCode(int ClientID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("select distinct ProductCode,ProductID   from BizConnect_ProductMaster where ClientID=" + ClientID + " order by ProductCode", obj_BizConn))
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

    public DataTable Bizconnect_LoadProductNameByProductCode(int ClientID, string ProductCode)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("select distinct ProductName,ProductID  from BizConnect_ProductMaster where ProductCode =" + ProductCode + " and ClientID=" + ClientID + "", obj_BizConn))
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


    public DataTable Bizconnect_CheckAcceptIDExistsOrNot(int AcceptanceID)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("select AcceptanceID  from Bizconnect_PreloadDetails where AcceptanceID =" + AcceptanceID, obj_BizConn))
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
