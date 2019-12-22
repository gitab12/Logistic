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
/// Summary description for Class1
/// </summary>
public class ParcelModule
{

    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
	public ParcelModule()
	{
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
	}

    public DataTable Get_TransportforParcel(int ClientID,string fromloc,string toloc, int rid,int type)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        try
        {
            SqlCommand comm = new SqlCommand("Get_TransportforParcel", obj_BizConn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@obj_Client", ClientID);
            comm.Parameters.AddWithValue("@FromLoc", fromloc);
            comm.Parameters.AddWithValue("@ToLoc", toloc );
            comm.Parameters.AddWithValue("@rid", rid);
            comm.Parameters.AddWithValue("@Type", type);
            
          
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }

    //Get_parcelAgreementDetailsofTransporter
    public DataTable Get_parcelAgreementDetailsofTransporter(int ClientID, string fromloc, string toloc,int rid)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        try
        {
            SqlCommand comm = new SqlCommand("Get_parcelAgreementDetailsofTransporter", obj_BizConn);
            comm.CommandType = CommandType.StoredProcedure;
            comm.Parameters.AddWithValue("@obj_Client", ClientID);
            comm.Parameters.AddWithValue("@FromLoc", fromloc);
            comm.Parameters.AddWithValue("@ToLoc", toloc);
            comm.Parameters.AddWithValue("@Rid", rid);


            SqlDataAdapter adp = new SqlDataAdapter(comm);
            adp.Fill(dt);
        }
        catch (Exception ex)
        {
        }
        return dt;
    }
}