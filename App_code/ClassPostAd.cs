using System;
using System.Collections.Generic;
//using System.Linq;
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
/// Summary description for CLassPostAd
/// </summary>
public class ClassPostAd
{
  string connStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    ArrayList arr = new ArrayList();

    public ClassPostAd()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    //Retrieving all Post Type
    public DataSet get_PostType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_PostType", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "PostType");
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
    // from cities for search//
    public DataSet get_SourceCities()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_source_Cities", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "FromLocation");
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

    //to cities for search//
    public DataSet get_Destinationcities()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_destination_Cities", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "ToLocation");
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

    //Retrieving all Goods Type
    public DataSet get_GoodsType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_GoodsType", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "GoodsType");
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


    //Retreiving Records for Alert------***************************
    public DataTable get_MobileForAutoReminder()
    {
        DataTable obj_DataTable = new DataTable();
        DataColumn obj_DataColumn;

        obj_DataColumn = new DataColumn();
        obj_DataColumn.DataType = Type.GetType("System.String");
        obj_DataColumn.ColumnName = "Response";
        obj_DataTable.Columns.Add(obj_DataColumn);

        obj_DataColumn = new DataColumn();
        obj_DataColumn.DataType = Type.GetType("System.String");
        obj_DataColumn.ColumnName = "Mobile";
        obj_DataTable.Columns.Add(obj_DataColumn);

        obj_DataColumn = new DataColumn();
        obj_DataColumn.DataType = Type.GetType("System.String");
        obj_DataColumn.ColumnName = "AdID";
        obj_DataTable.Columns.Add(obj_DataColumn);

        arr.Clear();
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_MobileForAutoReminder", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    while (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            DataRow obj_DataRow;
                            obj_DataRow = obj_DataTable.NewRow();
                            obj_DataRow["Response"] = "1";
                            obj_DataRow["Mobile"] = dr["Mobile"].ToString();
                            obj_DataRow["AdID"] = dr["AdID"].ToString();
                            obj_DataTable.Rows.Add(obj_DataRow);
                        }
                        else
                        {
                            arr.Clear();
                            resp = 0;
                            arr.Add(resp);
                        }
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    arr.Clear();
                    resp = 0;
                    arr.Add(resp);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return obj_DataTable;
    }


    //Retrieving Mobile No from Post Ad Table by Ad ID--******************
    public ArrayList get_MobileByAdID(String obj_AdID)
    {
        String obj_MobileNo;
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_MobileNumberByAdID1", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdID", obj_AdID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_MobileNo = dr.GetValue(0).ToString();
                                arr.Add(obj_MobileNo);
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        arr.Add(resp);
        return arr;
    }

    //Retrieving Mobile No from Post Ad Table by RID--******************
    public ArrayList get_MobileByRID(Int32 obj_rid)
    {
        String obj_MobileNo;
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_MobilenoByRID1", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_RID", obj_rid);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_MobileNo = dr.GetValue(0).ToString();
                                arr.Add(obj_MobileNo);
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //arr.Add(resp);
        return arr;
    }

    

    //Retreving Email ID from Registration table by ADID
    public ArrayList get_EmailIDByRID(int obj_rid)
    {
        String obj_Email;
        ArrayList arr1 = new ArrayList();
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("[get_EmailIDByRID]", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_RID", obj_rid);
                try
                {
                    conn.Open();
                    SqlDataReader dr1 = ada.SelectCommand.ExecuteReader();
                    if (dr1.HasRows)
                    {
                        if (dr1.Read())
                        {
                            if (!dr1.IsDBNull(0))
                            {
                                resp = 1;
                                while (dr1.Read())
                                {
                                    if (!dr1.IsDBNull(0))
                                    {
                                        obj_Email = dr1["Email"].ToString(); ;
                                        arr1.Add(obj_Email);
                                    }
                                }
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr1.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        //arr.Add(resp);
        return arr1;
    }

    //Retrieving all Travel Type--------******************************* (not available in bakup class)
    public DataSet get_TravelType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_TravelType", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "TravelType");
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


    //Retrieving Mobile No from Post Ad Table by Ad ID----******************
    public ArrayList get_NameByPostByID(Int32 obj_PostByID)
    {
        String obj_FullName;
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_NameByPostByID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostByID", obj_PostByID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_FullName = dr.GetValue(0).ToString();
                                arr.Add(obj_FullName);
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        arr.Add(resp);
        return arr;
    }

    //Retrieving EmailID from Registration Table by PostByID----****************
    public ArrayList get_EmailID(Int32 obj_PostByID)
    {
        String obj_EmailID;
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_EmailByPostByID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostByID", obj_PostByID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_EmailID = dr.GetValue(0).ToString();
                                arr.Add(obj_EmailID);
                            }
                            else
                            {
                                resp = 0;
                            }
                        }
                        else
                        {
                            resp = 0;
                        }
                    }
                    else
                    {
                        resp = 0;
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        arr.Add(resp);
        return arr;
    }



    //Retrieving all Truck Type
    public DataSet get_TruckType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_TruckType", conn))
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


    //Retrieving all Enclosure Type
    public DataSet get_EnclosureType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_EnclosureType", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "EnclosureType");
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

    //Retrieving all Truck Brand
    public DataSet get_TruckBrand()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_TruckBrand", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "TruckBrand");
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

    //Retrieving all Truck Model
    public DataSet get_TruckModel(Int32 obj_TruckBrandID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_TruckModel", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", obj_TruckBrandID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "TruckModel");
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


    //Retrieving Duration of Expiry from User Configuration Table
    public ArrayList get_DateExpiry(string obj_Expiry)
    {
        arr.Clear();
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_DateExpiry", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Expiry", obj_Expiry);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            resp = 1;
                            arr.Add(resp);
                            arr.Add(dr.GetValue(0).ToString());
                        }
                    }
                    else
                    {
                        arr.Clear();
                        resp = 0;
                        arr.Add(resp);
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    arr.Clear();
                    resp = 0;
                    arr.Add(resp);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return arr;
    }


    //Retrieving ID from Post Ad Table
    public ArrayList get_PostID()
    {
        int ID = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_PostID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            arr.Add(1);
                            ID = Convert.ToInt32(dr.GetValue(0));
                            arr.Add(ID);
                        }
                        else
                        {
                            arr.Add(0);
                            ID = 0;
                        }
                    }
                    else
                    {
                        arr.Add(0);
                        ID = 0;
                    }
                    dr.Close();
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
        return arr;
    }


    ///Insert Record into Post Ad Table when User click submit button
    ///
    public Int32 Insert_AdPost(string obj_AdID,
        Int32 obj_PostByID, Int32 obj_PostTypeID, string obj_FromLocation,
        string obj_ToLocation, DateTime obj_RequirementDate, string obj_GoodsDesc,
        Int32 obj_GoodsTypeID, Int32 obj_NoOfTrucks, String  obj_TruckCapacity,
        Int32 obj_TruckTypeID, Int32 obj_EnclosureTypeID, Double obj_CostPerTruck,
        Double obj_TotalTruckCost, DateTime obj_PostExpiryDateTimeStamp,
        DateTime obj_PostQuoteLastDateTimeStamp, string obj_AdditionalComments, Int32 obj_GroupID,Int32 obj_TravelType,Int32 obj_TruckModelID,String obj_CapacityUnit,string City,string BidstartTime)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_PostAd", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdID", obj_AdID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostByID", obj_PostByID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostTypeID", obj_PostTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FromLocation", obj_FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ToLocation", obj_ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_RequirementDate", obj_RequirementDate);
                ada.SelectCommand.Parameters.AddWithValue("@obj_GoodsDesc", obj_GoodsDesc);
                ada.SelectCommand.Parameters.AddWithValue("@obj_GoodsTypeID", obj_GoodsTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NoOfTrucks", obj_NoOfTrucks);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckCapacity", obj_TruckCapacity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", obj_TruckTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_EnclosureTypeID", obj_EnclosureTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CostPerTruck", obj_CostPerTruck);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TotalTruckCost", obj_TotalTruckCost);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostExpiryDateTimeStamp", obj_PostExpiryDateTimeStamp);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostQuoteLastDateTimeStamp", obj_PostQuoteLastDateTimeStamp);
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdditionalComments", obj_AdditionalComments);
                ada.SelectCommand.Parameters.AddWithValue("@obj_GroupID", obj_GroupID);
				ada.SelectCommand.Parameters.AddWithValue("@obj_TravelType", obj_TravelType);
                //ada.SelectCommand.Parameters.AddWithValue("@obj_ReturnableCost", obj_ReturnableCost);
				ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModelID", obj_TruckModelID);
				ada.SelectCommand.Parameters.AddWithValue("@obj_CapacityUnit", obj_CapacityUnit);
				 ada.SelectCommand.Parameters.AddWithValue("@obj_City", City );
				 ada.SelectCommand.Parameters.AddWithValue("@obj_BidStartTime", BidstartTime);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }


      //Retrieving Posted Ads for Update
    public ArrayList get_PostedAd(Int32  obj_PostID)
    {
        arr.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_PostedAd", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostID", obj_PostID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            arr.Add(1);
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
                    conn.Close();
                }
            }
        }
        return arr;
    }


    //Update process of Posted Ads
    public Int32 Update_AdPost(Int32 obj_PostID, string obj_AdditionalComments)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_PostAd", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostID", obj_PostID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdditionalComments", obj_AdditionalComments);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }

     //Geting All Trucks
    ////////////////
    public DataTable GetTruck(Int32 obj_PostTypeID)
    {
        arr.Clear();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {

            using (SqlCommand comm = new SqlCommand("get_TruckByCategoryAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostTypeID", obj_PostTypeID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "TruckDetails");
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
    ////////////////////////////////////////////////////
    //Code for Default Page
    //Display Records from Posting Ad table  +
    //Geting Totla Quote Count and Minimum Quote Price
    ////////////////
    public DataTable GetTruck(Int32 obj_PostTypeID, Int32 LoginID)
    {
        arr.Clear();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            if (obj_PostTypeID == 1 || obj_PostTypeID == 2)
            {
                using (SqlCommand comm = new SqlCommand("get_TruckByCategory", conn))
                {
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_PostTypeID", obj_PostTypeID);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        ada.Fill(ds, "TruckDetails");
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
            else
            {
                //My MATCHES
                if (LoginID > 0)
                {
                    string location = "";
                    string qry = "select distinct fromlocation,tolocation from scmJunction_PostAd where postbyid=" + LoginID + " and RequirementDate>=GETDATE()";
                    SqlCommand cmd = new SqlCommand(qry, conn);
                    SqlDataAdapter adp = new SqlDataAdapter(cmd);

                    adp.Fill(ds1);
                    for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                    {
                        location += "" + ds1.Tables[0].Rows[i][0].ToString() + "," + ds1.Tables[0].Rows[i][1].ToString() + ",";
                    }
                    try
                    {
                        location = location.Remove(location.Length - 1, 1);
                        ds1.Clear();
                    }
                    catch (Exception err)
                    {

                    }
                    using (SqlCommand comm = new SqlCommand("get_MyMatches", conn))
                    {
                        SqlDataAdapter ada = new SqlDataAdapter(comm);
                        ada.SelectCommand.Parameters.AddWithValue("@Location", location);
                        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            conn.Open();
                            ada.Fill(ds, "TruckDetails");
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
                else
                {

                }


            }
        }
        return dt;


    }


    //Retreive Posted Ad in Detail for View
     public DataSet get_PostedAdInDetailView(String  obj_AdID)
    {
        arr.Clear();
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_PostedAdByAdID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdID", obj_AdID);
                try
                {
                    conn.Open();
                    ds.Clear();
                    ada.Fill(ds, "PostedAdInDetail");
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

    //Retrieving all Carriage Goods Category
    public DataSet get_CarriageGoodsCategory()
    {
        arr.Clear();
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_CarriageGoodsCategory", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "CarriageGoodsCategory");
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
    //Retrieving User Configuration details
    public ArrayList get_Expiry(string obj_Expiry)
    {
        arr.Clear();
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_Expiry", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Expiry", obj_Expiry);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            resp = 1;
                            arr.Add(resp);
                            arr.Add(dr.GetValue(0).ToString());
                        }
                    }
                    else
                    {
                        arr.Clear();
                        resp = 0;
                        arr.Add(resp);
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
                    arr.Clear();
                    resp = 0;
                    arr.Add(resp);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return arr;
    }
    //Retrieving ID from Posting Add Table
    public ArrayList get_ID()
    {
        int ID = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_ID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            arr.Add(1);
                            ID = Convert.ToInt32(dr.GetValue(0));
                            arr.Add(ID);
                        }
                        else
                        {
                            arr.Add(0);
                            ID = 0;
                        }
                    }
                    else
                    {
                        arr.Add(0);
                        ID = 0;
                    }
                    dr.Close();
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
        return arr;
    }
    //Retrieving RecID from Registration Table
    public ArrayList get_RecID(string obj_UserID)
    {
        int obj_RecID = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_RecID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
                try
                {
                    conn.Open();
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            arr.Add(1);
                            obj_RecID = Convert.ToInt32(dr.GetValue(0));
                            arr.Add(obj_RecID);
                        }
                        else
                        {
                            arr.Add(0);
                            obj_RecID = 0;
                        }
                    }
                    else
                    {
                        arr.Add(0);
                        obj_RecID = 0;
                    }
                    dr.Close();
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
        return arr;
    }

    ///Insert Record into Post Add Table when User click submit button
    public Int32 Insert_AddPost(string obj_AdID, Int32 obj_UserID, string obj_AddType, string obj_FromLocation, string obj_ToLocation,
                                    DateTime obj_TravelDate, string obj_TruckType, int obj_NoOfTrucks,
                                    int obj_TruckCapacity, string obj_EnclosureType, double obj_CostPerTruck,
                                    string obj_CarriageGoodsCategory, string obj_GoodsPreference,
                                    string obj_GoodsToBeShipped, DateTime obj_ExpiryDate, DateTime obj_LastDateForQuote)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_PostAdds", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdID", obj_AdID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_AddType", obj_AddType);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FromLocation", obj_FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ToLocation", obj_ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDate", obj_TravelDate);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckType", obj_TruckType);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NoOfTrucks", obj_NoOfTrucks);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckCapacity", obj_TruckCapacity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_EnclosureType", obj_EnclosureType);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CostPerTruck", obj_CostPerTruck);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CarriageGoodsCategory", obj_CarriageGoodsCategory);
                ada.SelectCommand.Parameters.AddWithValue("@obj_GoodsPreference", obj_GoodsPreference);
                ada.SelectCommand.Parameters.AddWithValue("@obj_GoodsToBeShipped", obj_GoodsToBeShipped);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ExpiryDate", obj_ExpiryDate);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LastDateForQuote", obj_LastDateForQuote);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }

     //getting search results from tab_search usercontrol
    public DataTable get_searchresults(int post_type, string source, string destination, int truck_type, int enclosure_type,int travel_type,string frm_date,string to_date,string frm_cost,string to_cost,string no_f_trucks,int truck_range,string capacity1,string capacity2,string unit)
    {
        DataTable dt_searchresults = new DataTable();
        dt_searchresults.Clear();
        SqlConnection conn = new SqlConnection(connStr);
        SqlCommand cmd = new SqlCommand("sp_searchresults",conn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Parameters.AddWithValue("@post_typeid", post_type);
        da.SelectCommand.Parameters.AddWithValue("@source", source);
        da.SelectCommand.Parameters.AddWithValue("@destination", destination);
        da.SelectCommand.Parameters.AddWithValue("@truck_typeid", truck_type);
        da.SelectCommand.Parameters.AddWithValue("@enclosure_typeid", enclosure_type);
        da.SelectCommand.Parameters.AddWithValue("@travel_typeid", travel_type);
        da.SelectCommand.Parameters.AddWithValue("@from_date", frm_date);
        da.SelectCommand.Parameters.AddWithValue("@to_date", to_date);
        da.SelectCommand.Parameters.AddWithValue("@from_cost_pt", frm_cost);
        da.SelectCommand.Parameters.AddWithValue("@to_cost_pt", to_cost);
        da.SelectCommand.Parameters.AddWithValue("@no_of_trucks", no_f_trucks);
        da.SelectCommand.Parameters.AddWithValue("@trucks_range", truck_range);
        da.SelectCommand.Parameters.AddWithValue("@capacity1", capacity1);
        da.SelectCommand.Parameters.AddWithValue("@capacity2", capacity2);
        da.SelectCommand.Parameters.AddWithValue("@units", unit);
        da.SelectCommand.CommandType = CommandType.StoredProcedure;
        try
        {
            conn.Open();
            da.Fill(dt_searchresults);
            conn.Close();
        }
        catch
        {

        }
        return dt_searchresults;
    }

    //Retrieving Post ADS
    public DataSet get_PostADS()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_PostADS", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "PostADS");
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

    //UpdatePostADSDates
    public Int32 Update_PostAdDates(Int32 obj_PostID, DateTime RequirementDate,DateTime PostedDate,DateTime LastDate)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_PostAdDates", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostID", obj_PostID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_RequirementDate", RequirementDate);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostedDateTimeStamp", PostedDate);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PostQuoteLasteDateTimeStamp", LastDate);
                try
                {
                    conn.Open();
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                }
                catch (Exception err)
                {
                    resp = 0;
                }
                finally
                {
                    conn.Close();
                    comm.Dispose();
                    ada.Dispose();
                }
            }
        }
        return resp;
    }

}
