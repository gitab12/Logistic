using System;
using System.Collections.Generic;
using System.Linq;
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
/// Summary description for Class_City
/// </summary>
public class Class_City
{
    string connStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    string BizCon = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;

    public Class_City()
    {
    }

    // from cities for search//
    public DataSet get_SourceCities()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_CityAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "CityList");
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


    ///Insert Record into City Distance Table
    ///
    public Int32 Insert_CityDistance(Int32 obj_SourceID,Int32 obj_DestinationID,Int32 obj_Distance)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_CityDistance", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_SourceCityID", obj_SourceID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_DestinationCityID", obj_DestinationID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Distance", obj_Distance);
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


    //
    //Retrieving Mobile No from Post Ad Table by Ad ID----******************
    public ArrayList get_CityDistanceBySourceCityID_DestinationCityID(Int32 obj_SourceCityID,Int32 obj_DestinationCityID)
    {
        Int32 resp = 3;
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_CityDistanceBySourceCityID_DestinationCityID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_SourceCityID", obj_SourceCityID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_DestinationCityID", obj_DestinationCityID);
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


    //get the distance
    public ArrayList get_citydistance(Int32 obj_SourceCityID, Int32 obj_DestinationCityID)
    {
        Int32 resp = 3;
        ArrayList arr = new ArrayList();
        string src, dest, dist;
        arr.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_citydistance", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_SourcecityID", obj_SourceCityID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_DestcityID", obj_DestinationCityID);
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
                                src = dr[1].ToString().Trim();
                                dest = dr[2].ToString().Trim();
                                dist = dr[3].ToString().Trim();
                                resp = 1;
                                arr.Add(resp);
                                arr.Add(src);
                                arr.Add(dest);
                                arr.Add(dist);
                            }
                            else
                            {
                                resp = 0;
                                arr.Add(resp);
                            }
                        }
                        else
                        {
                            resp = 0;
                            arr.Add(resp);
                        }
                    }
                    else
                    {
                        resp = 0;
                        arr.Add(resp);
                    }
                    dr.Close();
                }
                catch (Exception err)
                {
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

    //Insert Route Chart Master

    public Int32 Insert_Bizconnect_RouteChartMaster(int RouteID, int TransporterID, string fromloc, string toloc,
                                        int trucktypeid, int citydistanceid, double costperkm, double totalcostpertruck)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(BizCon))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_RoutChartMaster", conn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@RouteID", RouteID);
                    ada.SelectCommand.Parameters.AddWithValue("@TransporterID", TransporterID);
                    ada.SelectCommand.Parameters.AddWithValue("@From_Loc", fromloc);
                    ada.SelectCommand.Parameters.AddWithValue("@To_Loc", toloc);
                    ada.SelectCommand.Parameters.AddWithValue("@Trucktype_ID",trucktypeid);
                    ada.SelectCommand.Parameters.AddWithValue("@CityDistanceID", citydistanceid);
                    ada.SelectCommand.Parameters.AddWithValue("@CostPerKM", costperkm);
                    ada.SelectCommand.Parameters.AddWithValue("@TotalCostPerTruck", totalcostpertruck);
                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
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


        return resp;

    }


    // get routeId
    public DataSet get_RouteID(int trasnsporterid,string fromcity,string tocity)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(BizCon))
        {
            using (SqlCommand comm = new SqlCommand("Get_RouteID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransporterID", trasnsporterid);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FromCity", fromcity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ToCity", tocity);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "RouteID");
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

