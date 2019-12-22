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
using System.Collections;
using System.Data.SqlClient;

/// <summary>
/// Summary description for FindIDs
/// </summary>
public class FindIDs
{
    string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string connJun = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    ArrayList arr = new ArrayList();
    int resp = 0;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
	public FindIDs()
	{
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
    }
    ~FindIDs()
    {
        //obj_BizConn.Close();
       // obj_SCMConn.Close();
    }
	
    public ArrayList FindCustomerID(string CustomerName)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerIDByCustomerName", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_customername", CustomerName);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        arr.Add(dr[0].ToString());
                        dr.Close();

                    }
                }
                else
                {
                    arr.Add(0);
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        return arr;
    }
    public ArrayList FindProductID(string ProductName)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ProductIDByProductName", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_productname", ProductName);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        arr.Add(dr[0].ToString());
                        dr.Close();

                    }
                }
                else
                {
                    arr.Add(0);
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        return arr;
    }
    public ArrayList FindCategoryID(string CategoryName)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm1 = new SqlCommand("Get_BizConnect_CategoryIDByCategoryName", obj_BizConn))
        {
            SqlDataAdapter ada1 = new SqlDataAdapter(comm1);
            ada1.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada1.SelectCommand.Parameters.AddWithValue("@obj_categoryname", CategoryName);
          
            SqlDataReader drc = ada1.SelectCommand.ExecuteReader();
            try
            {
                if (drc.HasRows)
                {
                    while (drc.Read())
                    {

                        arr.Add(drc[0].ToString());
                        drc.Close();
                    }
                }
                else
                {
                    arr.Add(0);
                    drc.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        return arr;
    }

    public ArrayList FindTruckTypeID(string TruckName)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckIDByTruckName", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_truckname", TruckName);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        arr.Add(dr[0].ToString());
                        dr.Close();
                    }
                }
                else
                {
                    arr.Add(0);
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        return arr;
    }

    //Get_BizconnectCustomerAddressDetails
    public ArrayList FindCustomerDetails(int Customerid, int Loctypeid)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizconnectCustomerAddressDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_customerid", Customerid);
            ada.SelectCommand.Parameters.AddWithValue("@obj_Loc", Loctypeid);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        arr.Add(dr[0].ToString());
                        arr.Add(dr[1].ToString());
                        arr.Add(dr[2].ToString());
                        arr.Add(dr[3].ToString());
                        arr.Add(dr[4].ToString());
                        arr.Add(dr[5].ToString());
                        arr.Add(dr[6].ToString());
                        arr.Add(dr[7].ToString());
                        arr.Add(dr[8].ToString());
                        dr.Close();

                    }
                }
                else
                {
                    arr.Add(0);
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        return arr;
    }
    public ArrayList FindClientDetails(int Clientid,int Loctypeid)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizconnectClientAddressDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_clientid", Clientid );
            ada.SelectCommand.Parameters.AddWithValue("@obj_Loc", Loctypeid);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {

                        arr.Add(dr[0].ToString());
                        arr.Add(dr[1].ToString());
                        arr.Add(dr[2].ToString());
                        arr.Add(dr[3].ToString());
                        arr.Add(dr[4].ToString());
                        arr.Add(dr[5].ToString());
                        arr.Add(dr[6].ToString());
                        arr.Add(dr[7].ToString());
                        arr.Add(dr[8].ToString());
                        dr.Close();

                    }
                }
                else
                {
                    arr.Add(0);
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }
        return arr;
    }
}
