using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;

/// <summary>
/// Summary description for BizConnectDealProcess
/// </summary>
public class BizConnectDealProcess
{
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();

	public BizConnectDealProcess()
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
    
    //Retreving Records for Assignments 
    public DataSet get_Assignment(Int32 obj_PostByID)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_Assignment", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostByID", obj_PostByID);
                ada.Fill(ds, "Assignment");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {

        }
        return ds;
	}

    //Retreving Records from Post Reply Table depending on the AdID 
    public DataSet get_QuoteDetails(String  obj_AdID)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_QuoteDetailsByAdID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdID", obj_AdID);
                ada.Fill(ds, "QuoteDetails");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {

        }
        return ds;
    }

    //Insert Record into SCMJunction PreAssignment Table
    public Int32 Insert_SCMJunctionPreAssignment(Int32 obj_PostReplyID, Int32 obj_PostID,Double obj_NegotiableCost, Int32 obj_NegotiableTrucks, String obj_LogisticsPlanNo, String obj_PreAssignmentStatus, String obj_PreAssignmentApproval, Int32 obj_PostedBy, Int32 obj_UpdatedBy, Int32 obj_IsActive)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Insert_scmJunction_PreAssignment", obj_SCMConn))
            {

                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostReplyID", obj_PostReplyID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostID", obj_PostID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NegotiableCost", obj_NegotiableCost);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NegotiableTruck", obj_NegotiableTrucks);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LogisticsPlanNo", obj_LogisticsPlanNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PreAssignmentStatus", obj_PreAssignmentStatus);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PreAssignmentApproval", obj_PreAssignmentApproval);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostedBy", obj_PostedBy);
                ada.SelectCommand.Parameters.AddWithValue("@obj_UpdatedBy", obj_UpdatedBy);
                ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", obj_IsActive);
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
            }
        }
        catch (Exception err)
        {
            obj_resp = 0;
        }
        finally
        {

        }
        return obj_resp;
    }

    //Update Record into SCMJunction PostReply Table
    public Int32 Update_SCMJunctionPostReply(Int32 obj_PostReplyID)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Update_PostReplyForPreAssignment", obj_SCMConn))
            {

                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostReplyID", obj_PostReplyID);
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
            }
        }
        catch (Exception err)
        {
            obj_resp = 0;
        }
        finally
        {

        }
        return obj_resp;
    }

    //Retreving Mobile Number and Email by LogisticsPlanNo for Sending SMS and Email 
    public ArrayList get_MobileNoAndEmailByLogisticsPlanNo(String obj_LogisticsPlanNo)
    {
        ArrayList arr = new ArrayList();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_MobileNumberAndEmailByLogisticsPlanNo", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_LogisticsPlanNo", obj_LogisticsPlanNo);
                SqlDataReader dr =ada.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            arr.Add("1");
                            arr.Add(dr.GetValue(0).ToString());
                            arr.Add(dr.GetValue(1).ToString());
                            arr.Add(dr.GetValue(2).ToString());
                            arr.Add(dr.GetValue(3).ToString());
                            arr.Add(dr.GetValue(4).ToString());
                            arr.Add(dr.GetValue(5).ToString());
                            arr.Add(dr.GetValue(6).ToString());
                            arr.Add(dr.GetValue(7).ToString());
                            arr.Add(dr.GetValue(8).ToString());
                        }
                        else
                        {
                            arr.Add("0");
                        }
                    }
                }
                else
                {
                    arr.Add("0");
                }
                dr.Close();
            }
        }
        catch (Exception err)
        {
            arr.Add("0");
        }
        finally
        {

        }
        return arr;
    }

    //Retreving Mobile Number and Email by LogisticsPlanNo for Sending SMS and Email 
    public DataSet  Get_scmJunction_PreAssignmentByPostReplyIDAndLogisticsPlanNo(String obj_PostReplyID,String obj_LogisticsPlanNo)
    {
        DataSet ds=new DataSet();
        ArrayList arr = new ArrayList();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_scmJunction_PreAssignmentByPostReplyIDAndLogisticsPlanNo", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostReplyID", obj_PostReplyID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LogisticsPlanNo", obj_LogisticsPlanNo);
                ada.Fill(ds, "PreAssignment");
            }
        }
        catch (Exception err)
        {
           // arr.Add("0");
        }
        finally
        {

        }
        return ds;
    }
    
     public DataSet Get_TruckType_ForOptimization()
    {
        DataSet ds = new DataSet();
        ds.Clear();
            using (SqlCommand comm = new SqlCommand("Bizconnect_Get_TruckType", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
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
    
    
     public DataSet Get_OptimizationDetails(int ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_Get_Optimization", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                try
                {
                    ada.Fill(ds, "PostADS");
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
    
     public DataSet  Bizconnet_Get_CubicFeet( int Capacity)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnet_Get_CubicFeet", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", Capacity);
            try
            {
                ada.Fill(ds, "CubicFeet");
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


     public DataSet bizconnect_Get_Fromlocation(int ClientID, string ToLoc)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct FromLocation   from Bizconnect_DespatchPlan  where ClientID ='" + ClientID + "'  and ToLocation ='" + ToLoc + "'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text ;
            try
            {
                ada.Fill(ds, "FromLoc");
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

    public DataSet bizconnect_Get_ToLocation(int ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct ToLocation    from Bizconnect_DespatchPlan  where ClientID='" + ClientID + "'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            try
            {
                ada.Fill(ds, "ToLoc");
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

    public DataSet bizconnect_Get_TransporterandLowQuote(string FromLoc,string ToLoc,int TruckTypeID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select top 1 MIN(a.MinQuotePrice)as MinQuotePrice ,a.Transporter from(select top 1 MIN(negotiablecost)as MinQuotePrice,sr.CompanyName as Transporter from aarmjunction .dbo.scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_PostReply PR on pa.PostID=pr.PostID inner join aarmjunction .dbo.Scmjunction_Registration sr on sr.RID=pr.ReplyByID where FromLocation='" + FromLoc + "' and ToLocation='" + ToLoc + "' and TruckTypeID='" + TruckTypeID + "' group by CompanyName order by MIN(negotiablecost) asc union select top 1 MIN(oneway_price) as MinQuotePrice,Transporter_Name from Bizconnect_Route_Price where From_loc='" + FromLoc + "' and To_loc ='" + ToLoc + "' and Truck_type_ID='" + TruckTypeID + "' group by Transporter_Name order by MIN(oneway_price) asc)a group by Transporter ", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            try
            {
                ada.Fill(ds, "TransporterLowQuote");
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
    
    public DataSet Bizconnet_Get_CapacityCubicfeet()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select  Tc.TruckID,tt.TruckType  ,Tc.CubicFeet ,Tc.Capacity  from Bizconnect_Truck_Capacity TC inner join  BizConnect_TruckTypeMaster TT on Tc.TruckID = TT.TruckTypeID order by TruckID ", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            try
            {
                ada.Fill(ds, "CapacityCubic");
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
    
     public DataSet Bizconnect_Get_LowestQuoteBasedOnTruck(string FromLoc, string ToLoc)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        SqlCommand comm1 = new SqlCommand("select top 1 MIN(a.MinQuotePrice)as MinQuotePrice ,a.Transporter from(select top 1 MIN(negotiablecost)as MinQuotePrice,sr.CompanyName as Transporter from aarmjunction .dbo.scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_PostReply PR on pa.PostID=pr.PostID inner join aarmjunction .dbo.Scmjunction_Registration sr on sr.RID=pr.ReplyByID where FromLocation='" + FromLoc + "' and ToLocation='" + ToLoc + "' and TruckTypeID= 7  group by CompanyName order by MIN(negotiablecost) asc union select top 1 MIN(oneway_price) as MinQuotePrice,Transporter_Name from Bizconnect_Route_Price where From_loc='" + FromLoc + "' and To_loc ='" + ToLoc + "' and Truck_type_ID= 7    group by Transporter_Name order by MIN(oneway_price) asc)a group by Transporter ", obj_BizConn);
        SqlCommand comm2 = new SqlCommand("select top 1 MIN(a.MinQuotePrice)as MinQuotePrice ,a.Transporter from(select top 1 MIN(negotiablecost)as MinQuotePrice,sr.CompanyName as Transporter from aarmjunction .dbo.scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_PostReply PR on pa.PostID=pr.PostID inner join aarmjunction .dbo.Scmjunction_Registration sr on sr.RID=pr.ReplyByID where FromLocation='" + FromLoc + "' and ToLocation='" + ToLoc + "' and TruckTypeID= 14  group by CompanyName order by MIN(negotiablecost) asc union select top 1 MIN(oneway_price) as MinQuotePrice,Transporter_Name from Bizconnect_Route_Price where From_loc='" + FromLoc + "' and To_loc ='" + ToLoc + "' and Truck_type_ID= 14  group by Transporter_Name order by MIN(oneway_price) asc)a group by Transporter ", obj_BizConn);
        SqlCommand comm3 = new SqlCommand("select top 1 MIN(a.MinQuotePrice)as MinQuotePrice ,a.Transporter from(select top 1 MIN(negotiablecost)as MinQuotePrice,sr.CompanyName as Transporter from aarmjunction .dbo.scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_PostReply PR on pa.PostID=pr.PostID inner join aarmjunction .dbo.Scmjunction_Registration sr on sr.RID=pr.ReplyByID where FromLocation='" + FromLoc + "' and ToLocation='" + ToLoc + "' and TruckTypeID= 15  group by CompanyName order by MIN(negotiablecost) asc union select top 1 MIN(oneway_price) as MinQuotePrice,Transporter_Name from Bizconnect_Route_Price where From_loc='" + FromLoc + "' and To_loc ='" + ToLoc + "' and Truck_type_ID= 15  group by Transporter_Name order by MIN(oneway_price) asc)a group by Transporter ", obj_BizConn);
        SqlCommand comm4 = new SqlCommand("select top 1 MIN(a.MinQuotePrice)as MinQuotePrice ,a.Transporter from(select top 1 MIN(negotiablecost)as MinQuotePrice,sr.CompanyName as Transporter from aarmjunction .dbo.scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_PostReply PR on pa.PostID=pr.PostID inner join aarmjunction .dbo.Scmjunction_Registration sr on sr.RID=pr.ReplyByID where FromLocation='" + FromLoc + "' and ToLocation='" + ToLoc + "' and TruckTypeID= 49  group by CompanyName order by MIN(negotiablecost) asc union select top 1 MIN(oneway_price) as MinQuotePrice,Transporter_Name from Bizconnect_Route_Price where From_loc='" + FromLoc + "' and To_loc ='" + ToLoc + "' and Truck_type_ID= 49  group by Transporter_Name order by MIN(oneway_price) asc)a group by Transporter ", obj_BizConn);
            SqlDataAdapter ada1 = new SqlDataAdapter(comm1);
            SqlDataAdapter ada2 = new SqlDataAdapter(comm2);
            SqlDataAdapter ada3 = new SqlDataAdapter(comm3);
            SqlDataAdapter ada4 = new SqlDataAdapter(comm4);
            ada1.SelectCommand.CommandType = CommandType.Text;
            ada2.SelectCommand.CommandType = CommandType.Text;
            ada3.SelectCommand.CommandType = CommandType.Text;
            ada4.SelectCommand.CommandType = CommandType.Text;
            try
            {
                ada1.Fill(ds, "lowquote1");
                ada2.Fill(ds, "lowquote2");
                ada3.Fill(ds, "lowquote3");
                ada4.Fill(ds, "lowquote4");
            }
            catch (Exception err)
            {

            }
            finally
            {
            }
        return ds;
        }


     public DataTable Bizconnet_Get_DespatchPlanNoByTolocation(int ClientID, string ToLocation)
     {
         DataTable dt = new DataTable();
         using (SqlCommand comm = new SqlCommand("select distinct PlanNo  from Bizconnect_DespatchPlan  where ClientID =" + ClientID + " and ToLocation= '" + ToLocation + "'", obj_BizConn))
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


     public DataTable Bizconnect_SearchDespatchplanByPlannoAndTolocation(int ClientID, string ToLocation, string PlanNo)
     {
         DataTable dt = new DataTable();
         using (SqlCommand comm = new SqlCommand("Bizconnect_SearchDespatchplanByPlannoAndTolocation", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
             ada.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
             ada.SelectCommand.Parameters.AddWithValue("@PlanNo", PlanNo);
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

     public DataSet Bizconnect_Get_OptimizationAnalysis(int ClientID)
     {
         DataSet ds = new DataSet();

         using (SqlCommand comm = new SqlCommand("Bizconnect_Get_OptimizationAnalysis", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
             try
             {
                 ada.Fill(ds,"Analysis");
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

     public DataTable Bizconnect_SearchDespatchplanAnalysisByPlannoAndTolocation(int ClientID, string ToLocation, string PlanNo)
     {
         DataTable dt = new DataTable();
         using (SqlCommand comm = new SqlCommand("Bizconnect_SearchDespatchplanAnalysisByPlannoAndTolocation", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
             ada.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
             ada.SelectCommand.Parameters.AddWithValue("@PlanNo", PlanNo);
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


     public DataTable Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno(int ClientID, string ToLocation, string PlanNo)
     {
         DataTable dt = new DataTable();
         using (SqlCommand comm = new SqlCommand("Bizconnect_SearchDespatchVolumeAnalysisbyTolocationandPlanno", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
             ada.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
             ada.SelectCommand.Parameters.AddWithValue("@PlanNo", PlanNo);
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