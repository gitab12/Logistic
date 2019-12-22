using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;

public class AndroidClass
{
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    SqlConnection obj_BizConn = new SqlConnection();
	public AndroidClass()
	{
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_BizConn.Open();
	}
    public Int32 InsertAKZOOrder(string InvoiceNo, string Location, int DistributorID, int DealerID, int DeliveryBoyID)
    {
        int resp = 0;
        using (SqlCommand comm1 = new SqlCommand("InsertAKZOOrder", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                //inserting into user log table
                da.SelectCommand.Parameters.AddWithValue("@Obj_InvoiceNo", InvoiceNo);
                da.SelectCommand.Parameters.AddWithValue("@Obj_Location", Location);
                da.SelectCommand.Parameters.AddWithValue("@Obj_DistributorID", DistributorID);
                da.SelectCommand.Parameters.AddWithValue("@Obj_DealerID", DealerID);
                da.SelectCommand.Parameters.AddWithValue("@Obj_DeliveryBoyID", DeliveryBoyID);
                da.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception e)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;
    }
    public DataSet GetAKZODealerNo(int RegID)
    {
        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand("GetAKZODealerNo", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Obj_RegID", RegID);
            da.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            da.Fill(ds);
        }
        return ds;
    }
    public DataSet checkakzoinvoice(string InvoiceNo)
    {
        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand("checkakzoinvoice", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Obj_InvoiceNo", InvoiceNo);
            da.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            da.Fill(ds);
        }
        return ds;
    }
    public DataSet GetAKZODeliveryBoyNo(int RegID)
    {
        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand("GetAKZODeliveryBoyNo", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Obj_RegID", RegID);
            da.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            da.Fill(ds);
        }
        return ds;
    }
    public Int32 AKZO_Process_OTP(string OTP, int OrderID, int mode)
    {
        int resp = 0;
        using (SqlCommand comm1 = new SqlCommand("AKZO_Process_OTP", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                //inserting into user log table
                da.SelectCommand.Parameters.AddWithValue("@Obj_OTP", OTP);
                da.SelectCommand.Parameters.AddWithValue("@Obj_OrderID", OrderID);
                da.SelectCommand.Parameters.AddWithValue("@Obj_mode", mode);
                da.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception e)
            {
                resp = 0;
            }
            finally
            {

            }
        }
        return resp;
    }
    public DataSet GetDealerMobileNo(int OrderID)
    {
        DataSet ds = new DataSet();
        using (SqlCommand cmd = new SqlCommand("GetDealerMobileNo", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@Obj_OrderID", OrderID);
            da.SelectCommand.ExecuteNonQuery();
            ds = new DataSet();
            da.Fill(ds);
        }
        return ds;
    }
}