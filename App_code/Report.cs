using System;
using System.Collections.Generic;

using System.Web;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Summary description for Report
/// </summary>
public class Report
{
    string connStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    string Bizconn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    SqlDataReader dr;
	public Report()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public int CNNo { get; set; }
    public int ConfirmNo { get; set; }
    public string BillNo { get; set; }


   //Get_TripScheduleReport
    public DataSet Get_TripScheduleReport(int ClientID)
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Get_TripScheduleReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Get_TripScheduleReport");
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

    //Get_TripAgreementReport

    public DataSet Get_TripAgreementReport(int ClientID)
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Get_TripAgreementReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "TripAgreementReport");
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
    //
    //Collection Note Status Report
    public DataSet Bizconnect_CollectionNoteStatusReport()
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_CollectionNoteStatusReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_CollectionNoteStatusReport");
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
 //CollectionNote vs Indent

    public DataSet Bizconnect_CollectionNotevsIndent()
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_CollectionNotevsIndent", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_CollectionNotevsIndent");
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
    
    
     //Loading Status Report

    //public DataSet Bizconnect_LoadingStatusReport(int obj_ClientID,int obj_ClientAdrID )
    //{

    //    DataSet ds = new DataSet();
    //    ds.Clear();
    //    using (SqlConnection conn = new SqlConnection(Bizconn))
    //    {
    //        using (SqlCommand comm = new SqlCommand("Bizconnect_LoadingStatusReport", conn))
    //        {
    //            SqlDataAdapter ada = new SqlDataAdapter(comm);
    //            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
    //            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
    //            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);

    //            try
    //            {
    //                conn.Open();
    //                ada.Fill(ds, "Bizconnect_LoadingStatusReport");
    //            }
    //            catch (Exception err)
    //            {

    //            }
    //            finally
    //            {
    //                conn.Close();
    //            }
    //        }
    //    }
    //    return ds;
    //}
     public SqlDataReader  Bizconnect_LoadingStatusReport(int obj_ClientID, int obj_ClientAdrID)
    {
        SqlConnection conn = new SqlConnection(Bizconn);
        SqlCommand comm = new SqlCommand();
        comm.CommandType = CommandType.StoredProcedure;
        comm.CommandText = "Bizconnect_LoadingStatusReport";
        comm.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
        comm.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
        conn.Close();
        comm.Connection = conn;
        conn.Open();
        try
        {
            dr = comm.ExecuteReader();
        }
        catch (Exception err)
        {

        }
        finally
        {
            //conn.Close();
        }
        return dr;
    }
    
    //Bizconnect_DelayStatusReport
    public DataSet Bizconnect_DelayStatusReport(int obj_ClientID)
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_DelayStatusReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@ClientID", obj_ClientID);
               
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_DelayStatusReport");
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
//Bizconnect_DelayStatusReportSearch
    public DataSet Bizconnect_DelayStatusReportSearch(int obj_ClientID,DateTime obj_dtFrom,DateTime obj_dtTo,string ProjectNo)
    {
System.Data.SqlTypes.SqlDateTime sqlDateTime_From = new System.Data.SqlTypes.SqlDateTime(obj_dtFrom);
        System.Data.SqlTypes.SqlDateTime sqlDateTime_To = new System.Data.SqlTypes.SqlDateTime(obj_dtTo);

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_DelayStatusReportSearch", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_ClientID", obj_ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@dtFrom", sqlDateTime_From);
                ada.SelectCommand.Parameters.AddWithValue("@dtTo", sqlDateTime_To);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
               
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_DelayStatusReportSearch");
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

public DataSet   Bizconnect_MSIReport()
    {
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_MSIReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds,"MIS Report");
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
//Bizconnect_MSIReportSearch

public DataTable Bizconnect_MSIReportSearch(int objType , string CNFlag,int TAFlag,string LSFlag,string projectno)
    {
        DataTable ds = new DataTable();
       
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_MSIReportSearch", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Type", objType);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CnFlag", CNFlag);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TAFlag", TAFlag);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LSFlag", LSFlag);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", projectno);
               // ada.SelectCommand.Parameters.AddWithValue("@obj_WBSNo", wbsno);
                try
                {
                    conn.Open();
                    ada.Fill(ds);
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
    
    
public DataSet Bizconnect_LoadingStatusReportSearch(int obj_ClientID, int obj_ClientAdrID, DateTime  from, DateTime  to,string ProjectNo)
{
 System.Data.SqlTypes.SqlDateTime sqlDateTime_From = new System.Data.SqlTypes.SqlDateTime(from);
    System.Data.SqlTypes.SqlDateTime sqlDateTime_To = new System.Data.SqlTypes.SqlDateTime(to);

    DataSet ds = new DataSet();
    ds.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_LoadingStatusReportSearch", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAdrID", obj_ClientAdrID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_from", sqlDateTime_From);
            ada.SelectCommand.Parameters.AddWithValue("@obj_to", sqlDateTime_To);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);

            try
            {
                conn.Open();
                ada.Fill(ds, "Bizconnect_LoadingStatusReportSearch");
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
  //MIS
  public DataSet Bizconnect_MISReport(int obj_ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_MISReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_MsiReport");
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
    
     public DataTable  Bizconnect_Search_CNoteStatusReportByPJTNoAndWbsno(string ProjectNo ,string WBSNo)
  {
      DataTable dt = new DataTable();
      dt.Clear();
      using (SqlConnection conn = new SqlConnection(Bizconn))
      {
          using (SqlCommand comm = new SqlCommand("Bizconnect_Search_CNoteStatusReportByPJTNoAndWbsno", conn))
          {
              SqlDataAdapter ada = new SqlDataAdapter(comm);
              ada.SelectCommand.CommandType = CommandType.StoredProcedure;
              ada.SelectCommand.Parameters.AddWithValue("@ProjectNo",ProjectNo );
              ada.SelectCommand.Parameters.AddWithValue("@WBSNo", WBSNo);
              try
              {
                  conn.Open();
                  ada.Fill(dt);
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
      return dt;
  }
  
   public DataTable Bizconnect_Search_CNotevsRateContractByPJTNoAndWBSNo(string ProjectNo, string WBSNo)
  {
      DataTable dt = new DataTable();
      dt.Clear();
      using (SqlConnection conn = new SqlConnection(Bizconn))
      {
          using (SqlCommand comm = new SqlCommand("Bizconnect_Search_CNotevsRateContractByPJTNoAndWBSNo", conn))
          {
              SqlDataAdapter ada = new SqlDataAdapter(comm);
              ada.SelectCommand.CommandType = CommandType.StoredProcedure;
              ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
              ada.SelectCommand.Parameters.AddWithValue("@obj_WBSNo", WBSNo);
              try
              {
                  conn.Open();
                  ada.Fill(dt);
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
      return dt;
  }
  
  public DataTable Bizconnect_Search_MSIReportByPJTNoAndWBSNo(string ProjectNo, string WBSNo)
  {
      DataTable dt = new DataTable();
      dt.Clear();
      using (SqlConnection conn = new SqlConnection(Bizconn))
      {
          using (SqlCommand comm = new SqlCommand("Bizconnect_Search_MSIReportByPJTNoAndWBSNo", conn))
          {
              SqlDataAdapter ada = new SqlDataAdapter(comm);
              ada.SelectCommand.CommandType = CommandType.StoredProcedure;
              ada.SelectCommand.Parameters.AddWithValue("@Obj_ProjectNo", ProjectNo);
              ada.SelectCommand.Parameters.AddWithValue("@Obj_WBSNo", WBSNo);
              try
              {
                  conn.Open();
                  ada.Fill(dt);
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
      return dt;
  }  
  
   public DataTable Bizconnect_AlternateTransporterReport(int ClientID)
  {
      DataTable dt = new DataTable();
      dt.Clear();
      using (SqlConnection conn = new SqlConnection(Bizconn))
      {
          using (SqlCommand comm = new SqlCommand("Bizconnect_AlternateTransporterReport", conn))
          {
              SqlDataAdapter ada = new SqlDataAdapter(comm);
              ada.SelectCommand.CommandType = CommandType.StoredProcedure;
              ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
              try
              {
                  conn.Open();
                  ada.Fill(dt);
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
      return dt;
  }


   public DataTable Bizconnect_CNoteStatusReportAdvancedSearchByPJTNo(string FromProjectNo, string ToProjectNo)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_CNoteStatusReportAdvancedSearchByPJTNo", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@FromProjectNo", FromProjectNo);
               ada.SelectCommand.Parameters.AddWithValue("@ToProjectNo", ToProjectNo);
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_GetDetailReport(int ClientID, int UserID, DateTime FromDate, DateTime ToDate)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_GetDetailReport", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
               ada.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
               ada.SelectCommand.Parameters.AddWithValue("@FromDate", FromDate);
               ada.SelectCommand.Parameters.AddWithValue("@ToDate", ToDate);
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }

   public DataTable Bizconnect_AgreementReport()
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_AgreementReport", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_LoadAgreementReportClients()
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("select distinct CLIM .CompanyName from Bizconnect_Agreement Agrm inner join Bizconnect_AgreementRoutes AgrmR on Agrm.AgreementID =AgrmR.AgreementID inner join BizConnect_ClientMaster CLIM on Agrm .ClientID =CLIM .ClientID order by  CompanyName ", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.Text;
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_AgreementReportSearch(string ClientName)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_AgreementReportSearch", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@ClientName", ClientName);
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }

   public DataTable Bizconnect_QuickViewSearch(int ClientId)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_QuickViewSearch", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@CNoteNo", CNNo);
               ada.SelectCommand.Parameters.AddWithValue("@ConfirmationNo", ConfirmNo);
               ada.SelectCommand.Parameters.AddWithValue("@BillNo", BillNo);
               ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientId);
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_RcVsActual( int ClientID)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("select  ProjectNo ,WBS ,DESCRIPTION ,Qty,SerialNo ,PlaceofDespatch ,PlaceofDelivery ,TrucksPlanned , TruckType ,round (IndentAmount,2)as  IndentAmount ,TransitDays  from Bizconnect_TripIndent where ProjectNo in ( select ProjectNo from Bizconnect_ProjectMaster  where ClientID =" + ClientID + " )  order by ProjectNo desc", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.Text;
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_RcVsActualDetails(string ProjectNo, string WbsNo, int SNo)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_RcVsActualDetails", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
               ada.SelectCommand.Parameters.AddWithValue("@WbsNo", WbsNo);
               ada.SelectCommand.Parameters.AddWithValue("@SerialNo", SNo);
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_LoadProectNoForRcVsActual(int ClientID)
   {
       DataTable dt = new DataTable();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("select distinct ProjectNo  from Bizconnect_TripIndent where ProjectNo in ( select ProjectNo from Bizconnect_ProjectMaster  where ClientID =" + ClientID + " )order by ProjectNo", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.Text;
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }

   public DataTable Bizconnect_LoadWbsNoForRcVsActual(string ProjectNo)
   {
       DataTable dt = new DataTable();
       string Pjt = ProjectNo.Trim();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("select distinct WBS   from Bizconnect.dbo.Bizconnect_TripIndent where ProjectNo ='" + Pjt + "' order by WBS ", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.Text;
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_SearchRcVsActualDetailsByProjectAndWbsNo(string ProjectNo, string WbsNo)
   {
       DataTable dt = new DataTable();
       string Pjt = ProjectNo.Trim();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_SearchRcVsActualDetailsByProjectAndWbsNo", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", Pjt);
               ada.SelectCommand.Parameters.AddWithValue("@WbsNo", WbsNo);
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataTable Bizconnect_LoadTransporterforRcvsActual(string ProjectNo)
   {
       DataTable dt = new DataTable();
       string Pjt = ProjectNo.Trim();
       dt.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("select Transporter  from Bizconnect_ProjectMaster where ProjectNo ='" + Pjt + "' ", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.Text;
               try
               {
                   conn.Open();
                   ada.Fill(dt);
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
       return dt;
   }


   public DataSet Get_TransportAnalysisReport(string Userid, string month, string year,string day,int mode)
   {
       DataSet ds = new DataSet();
       ds.Clear();
       using (SqlConnection conn = new SqlConnection(Bizconn))
       {
           using (SqlCommand comm = new SqlCommand("Bizconnect_TransportAnalysisReport", conn))
           {
               SqlDataAdapter ada = new SqlDataAdapter(comm);
               ada.SelectCommand.CommandType = CommandType.StoredProcedure;
               ada.SelectCommand.Parameters.AddWithValue("@UserID", Userid);
               ada.SelectCommand.Parameters.AddWithValue("@Month", month);
               ada.SelectCommand.Parameters.AddWithValue("@year", year);
               ada.SelectCommand.Parameters.AddWithValue("@day", day);
               ada.SelectCommand.Parameters.AddWithValue("@mode", mode);
               try
               {
                   ada.Fill(ds, "Bizconnect_TransportAnalysisReport");
               }
               catch (Exception err)
               {

               }
               finally
               {
                   comm.Dispose();
               }
           }
       }
       return ds;
   }



}
