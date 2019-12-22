using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for MailClass
/// </summary>
public class MailClass
{
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string connJun = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    string GSTConnStr = ConfigurationManager.ConnectionStrings["GST"].ConnectionString;

    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    SqlConnection obj_GSTConn = new SqlConnection();
    public MailClass()
    {
        //
        // TODO: Add constructor logic here
        //

        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        string GSTConnStr = ConfigurationManager.ConnectionStrings["GST"].ConnectionString;

        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;
        obj_GSTConn.ConnectionString = GSTConnStr;
    }

    public DataSet  MailForReBidPriceToTransporter()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        obj_BizConn.Open();
        using (SqlCommand cmd = new SqlCommand("MailForReBidPriceToTransporter", obj_BizConn))
        {
            try
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(ds, "RebidMail");


            }


            catch (Exception ex)
            {
            }

            finally
            {
                obj_BizConn.Close();
            }

        }
        return ds;
    }

    //Mail to Transporter for RoutePrice Status

    public DataSet Transporter_RoutePricestatus()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        obj_BizConn.Open();
        using (SqlCommand cmd = new SqlCommand("Transporter_RoutePricestatus", obj_BizConn))
        {
            try
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(ds, "RebidMail");


            }


            catch (Exception ex)
            {
            }

            finally
            {
                obj_BizConn.Close();
            }

        }
        return ds;
    }

   

}