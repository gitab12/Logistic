using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AAUMCONNECTION
/// </summary>
public class AAUMCONNECTION
{
    SqlConnection obj_aaumConn = new SqlConnection();
  
    SqlDataReader dr;
    int resp = 0;
    public AAUMCONNECTION()
    {
        string obj_aaumconnstr = ConfigurationManager.ConnectionStrings["AAUMCon"].ConnectionString;
        obj_aaumConn.ConnectionString = obj_aaumconnstr;




    }
    public DataSet getdataset(string sqlquery)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand(sqlquery, obj_aaumConn))
        {
            comm.CommandTimeout = 4000;
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds);
            }
            catch (Exception err)
            {

            }
            finally
            {
                comm.Dispose();
            }
        }
        return ds;
    }
    public int aaumconnect_plancreation(string clientid,string clientname,string vehtype,string destlatlong,string senderno, string from, string to, string obj_LRNumber, string drivernam, string driverno, string vehicleno, DateTime startdate)
    {
        obj_aaumConn.Open();
        using (SqlCommand comm = new SqlCommand("sp_plancreation", obj_aaumConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@clientid", senderno);
            ada.SelectCommand.Parameters.AddWithValue("@clientname", senderno);
            ada.SelectCommand.Parameters.AddWithValue("@vehtype", senderno);
            ada.SelectCommand.Parameters.AddWithValue("@destlatlong", destlatlong);
            ada.SelectCommand.Parameters.AddWithValue("@senderno", senderno);
            ada.SelectCommand.Parameters.AddWithValue("@fromloc", from);
            ada.SelectCommand.Parameters.AddWithValue("@toloc", to);
            ada.SelectCommand.Parameters.AddWithValue("@Lrno", obj_LRNumber);
            ada.SelectCommand.Parameters.AddWithValue("@drivername", drivernam);
            ada.SelectCommand.Parameters.AddWithValue("@drivermob", driverno);
            ada.SelectCommand.Parameters.AddWithValue("@vehicleno", vehicleno);
            ada.SelectCommand.Parameters.AddWithValue("@startdate", startdate);
            DataSet ds = new DataSet();
            try
            {
                ada.Fill(ds);
            }
            catch (Exception e)
            {
            }
            finally
            {
                obj_aaumConn.Close();
                if (ds.Tables[0].Rows[0][0].ToString() == "1")
                {
                    resp = 1;
                }
                else
                {
                    resp = 0;
                }
            }

           
           
                
           
        }
        return resp;
    }
}