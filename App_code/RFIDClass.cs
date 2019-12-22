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
/// Summary description for RFIDClass
/// </summary>
public class RFIDClass
{
    SqlConnection obj_BIZConn = new SqlConnection();
	public RFIDClass()
	{
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        obj_BIZConn.ConnectionString = BizConnStr;
        obj_BIZConn.Open();
	}
    public Int32 InsertRFID_LatLng(string TagID, string LatLng, string Address, string Sender)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("InsertRFID_LatLng", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_TagID", TagID);
                ada.SelectCommand.Parameters.AddWithValue("@Obj_LatLng", LatLng);
                ada.SelectCommand.Parameters.AddWithValue("@Obj_Address", Address);
                ada.SelectCommand.Parameters.AddWithValue("@Obj_Sender", Sender);
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
                comm.Dispose();
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
    public Int32 UpdateRFID_Table(string TagID)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("UpdateRFID_Table", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_TagID", TagID);
                ada.SelectCommand.Parameters.Add("@result", SqlDbType.Int).Direction = ParameterDirection.Output;
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = Convert.ToInt32(ada.SelectCommand.Parameters["@result"].Value);
                comm.Dispose();
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
    public Int32 InsertRFID_MasterTableDispatched(string TagID)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("InsertRFID_MasterTableDispatched", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_TagID", TagID);
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
                comm.Dispose();
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
    public Int32 UpdateRFID_MasterTableDelivered(string TagID)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("UpdateRFID_MasterTableDelivered", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_TagID", TagID);
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
                comm.Dispose();
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
    public DataSet GetRFID()
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand cmd1 = new SqlCommand("GetRFID", obj_BIZConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(cmd1);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "aaumconnect");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    }
    public DataSet GetMasterRFID()
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand cmd1 = new SqlCommand("GetMasterRFID", obj_BIZConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(cmd1);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "aaumconnect");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    }
    public Int32 UpdateRFIDTABLE()
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("UpdateRFIDTABLE", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
                comm.Dispose();
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
    public Int32 Delete_RFID_MasterTable()
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Delete_RFID_MasterTable", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.ExecuteNonQuery();
                obj_resp = 1;
                comm.Dispose();
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
    public void RFIDAttendance(string TagID)
    {
        try
        {
            using (SqlCommand comm = new SqlCommand("RFIDAttendance", obj_BIZConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_TagID", TagID);
                ada.SelectCommand.ExecuteNonQuery();
                comm.Dispose();
            }
        }
        catch (Exception err)
        {
        }
        finally
        {

        }
    }
    public DataSet GetRFIDAttendanceList()
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand cmd1 = new SqlCommand("GetRFIDAttendanceList", obj_BIZConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(cmd1);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "aaumconnect");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    }
}