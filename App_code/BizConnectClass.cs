using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections;
/// <summary>
/// Summary description for BizConnectConnection
/// </summary>
public class BizConnectClass
{
  string connStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string connJun = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    string GSTConnStr = ConfigurationManager.ConnectionStrings["GST"].ConnectionString;
    public int res;
    ArrayList arr = new ArrayList();
    int resp = 0;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
    SqlConnection obj_GSTConn = new SqlConnection();

	public BizConnectClass()
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

        obj_BizConn.Open();
        obj_SCMConn.Open();
        obj_GSTConn.Open();
	}

    ~BizConnectClass()
    {
        //obj_BizConn.Close();
       // obj_SCMConn.Close();
    }



    //////////////////////////////////////////////////////////////////////////////////////////
    // Nanda's Code

    //Retrieving Location from bizconnect_locationtypemaster table




    public DataSet get_LocationType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_LocationTypeMasterAll", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "LocationType");
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
    //Retrieving Designation from bizconnect_desg table
    public DataSet get_desg()
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand cmd = new SqlCommand("get_desg", obj_BizConn))
        {
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {

                da.Fill(ds, "Designation");
            }
            catch
            {

            }
            finally
            {

            }
        }


        return ds;
    }

    //Retrieving producttype from bizconnect_locationtypemaster table
    public DataSet get_ProductType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("get_ProductType", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "LocationType");
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

    //Retrieving Measurementtype from bizconnect_locationtypemaster table
    public DataSet get_MeasurementType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("get_MeasurementType", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "Measurementtype");
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


    //Retrieving Gender from bizconnect_GenderMaster Table
    public DataSet Get_Gender()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_GenderMasterAll", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "Gender");
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

    //Fill Designation
    public DataSet FillDesignation()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_DesignationMasterAll", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
              
                ada.Fill(ds, "Designation");
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


    //Retrieving ProductCategory from bizconnect_locationtypemaster table
    public DataSet get_ProductCategory(int id)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("get_ProductCategory", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ProdID", id);
            try
            {
                ada.Fill(ds, "LocationType");
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

    //Retrieving PackingType from bizconnect_PackingTypemaster table
    public DataSet get_PackingType(int id)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("get_PackingType", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@measurementID", id);
            try
            {
                ada.Fill(ds, "PackingType");
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

    //Retrieving Unit from bizconnect_unitofmeasurementmaster table
    public DataSet get_unit(int id)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("get_unit", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@measurementID", id);
            try
            {
                ada.Fill(ds, "LocationType");
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

    //Fill Travel Type
    public DataSet FillTravelType()
    {
        DataSet obj_TravelTypeDs = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("get_TravelType", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(obj_TravelTypeDs, "TravelType");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {

        }
        return obj_TravelTypeDs;
    }

    //Fill Product Type
    public DataSet FillProductType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("get_GoodsType", obj_SCMConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "ProductType");
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

    //Fill CLient
    public DataSet FillClient()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ClientMasterAll", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
          
            try
            {
                ada.Fill(ds, "Client");
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
    //Fill FromLocation from RoutePrice Table
    public DataSet FillFromLocation()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("LoadFromLocation", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;

            try
            {
                ada.Fill(ds, "FromLocation");
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

    //Fill Customer By ClientID
    public DataSet FillCustomerByClientID(Int32 obj_ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerMasterByClientID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            try
            {
                ada.Fill(ds, "Customer");
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

    //Fill Location Type
    public DataSet FillLocationType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_LocationTypeMasterAll", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "Location");
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


    //Fill Customer City By Customer ID and Location Type ID
    public DataSet FillCustomerCityByCustomerIDandLocationTypeID(Int32 obj_CustomerID, Int32 obj_LocationTypeID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerCityByClientIDandByLocationTypeID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerID", obj_CustomerID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", obj_LocationTypeID);
            try
            {
                ada.Fill(ds, "CustomerCity");
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

    //Fill Customer Address By Customer ID and Location Type ID and City
    public DataSet FillCustomerAddressByCustomerIDandLocationTypeIDByCity(Int32 obj_CustomerID, Int32 obj_LocationTypeID, String obj_City)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerAddressByCityNameByCustomerIDByLocationTypeID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerID", obj_CustomerID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", obj_LocationTypeID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_City", obj_City);
            try
            {
                ada.Fill(ds, "CustomerAddress");
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

    //
    //Fill Customer Address By Customer ID and Location Type ID
    public ArrayList FillCustomerAddressDetailsByCustomerLocationTypeID(Int32 obj_CustomerAddressLocationID)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerAddressLocationByID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerAddressLocationID", obj_CustomerAddressLocationID);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        arr.Add(dr["City"].ToString());
                        arr.Add(dr["State"].ToString());
                        arr.Add(dr["Country"].ToString());
                        arr.Add(dr["BoardNo"].ToString());
                        arr.Add(dr["CorporateEmail"].ToString());
                    }
                }

            }
            catch (Exception err)
            {

            }
            finally
            {

            }
        }
        return arr;
    }

    //Fill Product Category
    public DataSet FillProductCategory(Int32 obj_ProductTypeID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ProductCategoryMasterByProductTypeID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProductTypeID", obj_ProductTypeID);
            try
            {
                ada.Fill(ds, "ProductCategory");
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


    //Fill Product Name
    public DataSet FillProductsName(Int32 obj_ProductCategoryID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ProductMasterByProductCategoryID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProductCategoryID", obj_ProductCategoryID);
            try
            {
                ada.Fill(ds, "ProductsName");
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


  //Fill Product Name
    public DataSet FillProductsDetails(Int32 obj_ProductID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ProductMasterByProductID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProductID", obj_ProductID);
            try
            {
                ada.Fill(ds, "ProductsName");
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

    //Fill Measurement Type
    public DataSet FillUnit(Int32 obj_MeasurementTypeID)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_UnitOfMeasurementMasterByMeasurementTypeID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_MeasurementTypeID", obj_MeasurementTypeID);
                ada.Fill(ds, "Unit");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {
            //obj_SCMConn.Close();
        }
        return ds;
    }

    //Fill Truck Type
    public DataSet FillTruckType()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("get_TruckType", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(ds, "TruckType");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {
            //obj_SCMConn.Close();
        }
        return ds;
    }

    //Fill Truck Type
    public DataSet FillEnclosureType()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("get_EnclosureType", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(ds, "EnclosureType");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {
            //obj_SCMConn.Close();
        }
        return ds;
    }

    //Fill Packing Method Type
    public DataSet FillPackingMethodType()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_PackingMethodTypeMasterAll", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(ds, "PackingMethodType");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {
            //obj_SCMConn.Close();
        }
        return ds;
    }

    //Fill Truck Brand
    public DataSet FillTruckBrand()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("get_TruckBrand", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.Fill(ds, "TruckBrand");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {
            //obj_SCMConn.Close();
        }
        return ds;
    }

    //Fill Truck Model
    public DataSet FillTruckModel(Int32 obj_TruckBrandID)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("get_TruckModel", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", obj_TruckBrandID);
                ada.Fill(ds, "TruckModel");
            }
        }
        catch (Exception err)
        {

        }
        finally
        {
            //obj_SCMConn.Close();
        }
        return ds;
    }

    //Fill PackingMethods
    public DataSet FillPackingMethods(Int32 obj_ProductTypeID)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_PackingMethodMasterByProductTypeID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProductTypeID", obj_ProductTypeID);
                ada.Fill(ds, "PackingMethods");
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

    //Reading Logostics Plan Table and get largest No
    public Int32 get_MaxLogisticsPlanID()
    {
        Int32 obj_LogisticsPlanID = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_MaxLogisticsPlanID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            //If found then flag value will be 1
                            obj_LogisticsPlanID = Convert.ToInt32(dr.GetValue(0));
                        }
                        else
                        {
                            obj_LogisticsPlanID = 1000;
                        }
                    }
                    else
                    {
                        obj_LogisticsPlanID = 1000;
                    }
                }
                else
                {
                    obj_LogisticsPlanID = 1000;
                }
                dr.Close();
                dr.Dispose();
                comm.Dispose();

            }

        }
        catch (Exception err)
        {

        }
        finally
        {

        }
        return obj_LogisticsPlanID;
    }


    //Function for DASHBOARD
    public DataSet DashBoard(string obj_userid, string month)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_Dashboard", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@UserID", obj_userid);
                ada.SelectCommand.Parameters.AddWithValue("@month", month);
                ada.Fill(ds, "Dashboard");
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


    //Function for DASHBOARD
    public DataSet OverallDashBoard(string month)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_OverallDashboard", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                ada.SelectCommand.Parameters.AddWithValue("@month", month);
                ada.Fill(ds, "Dashboard");
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




















    ///----------------------------------Shruthi's Code----------------------------------------

    //Function to Inserting BizConnect_TruckBrandMaster
    public Int32 Insert_TruckBrand(string TruckBrandName, string TruckBrandDescription, string IsActive)
    {
        int res = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_TruckBrandMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    //Inserting to Bizconnect_TruckBrandMaster
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandName", TruckBrandName);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandDescription", TruckBrandDescription);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return res;
    }

    //Function to Getting BizConnect_TruckBrandMaster
    public DataSet GetBizConnectTruckBrand()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckBrandMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_TruckBrandMaster");
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
        return ds;
    }

    //Function to Updating BizConnect_TruckBrandMaster
    public Int32 Update_TruckBrand(int TruckBrandkID, string TruckBrandName, string TruckBrandDescription, string IsActive)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_BizConnect_TruckBrandMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", TruckBrandkID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandName", TruckBrandName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandDescription", TruckBrandDescription);
                ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
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

    //Function to Deleting BizConnect_TruckBrandMaster
    public Int32 Delete_TruckBrand(int TruckBrandkID)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Delete_BizConnect_TruckBrandMasterByID", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", TruckBrandkID);

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

    //Function to Getting BizConnect_TruckModelMaster
    public DataSet GetBizConnectTruckModel()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckModelMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_TruckModelMaster");
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
        return ds;
    }

    //Function to Inserting BizConnect_TruckModelMaster
    public Int32 Insert_TruckModelMaster(string TruckModel, int TruckBrandId, int TrucktypeId, string CarrierGoodsType, float TruckCapacity, string TruckModelDescription, string IsActive)
    {
        int res = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_TruckModelMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModel", TruckModel);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", TruckBrandId);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", TrucktypeId);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_CarrierGoodsType", CarrierGoodsType);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckCapacity", TruckCapacity);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModelDescription", TruckModelDescription);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);

                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return res;
    }

    //Function to Updating BizConnect_TruckModelMaster
    public Int32 Update_TruckModelMaster(int TruckModelID, string TruckModel, int TruckBrandId, int TrucktypeId, string CarrierGoodsType, float TruckCapacity, string TruckModelDescription, string IsActive)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_BizConnect_TruckModelMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModelID", TruckModelID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModel", TruckModel);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", TruckBrandId);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", TrucktypeId);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CarrierGoodsType", CarrierGoodsType);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckCapacity", TruckCapacity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModelDescription", TruckModelDescription);
                ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
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

    //Function to Getting BizConnect_TruckTypeMaster
    public DataSet GetBizConnectTruckTypeMaster()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckTypeMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_TruckTypeMaster");
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
        return ds;
    }

    //Function to Inserting BizConnect_TruckTypeMaster
    public Int32 Insert_TruckTypeMaster(string TruckType, string TruckTyprDescription, string IsActive)
    {
        int res = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_TruckTypeMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckType", TruckType);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeDescription", TruckTyprDescription);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return res;
    }

    //Function to Updating BizConnect_TruckTypeMaster
    public Int32 Update_TruckTypeMaster(int TruckTypekID, string TruckTypeName, string TruckTypeDescription, string IsActive)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_BizConnect_TruckTypeMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", TruckTypekID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckType", TruckTypeName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeDescription", TruckTypeDescription);
                ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
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

    //Function to Getting BizConnect_UnitOfMeasurementMaster
    public DataSet GetBizConnectUnitOfMeasurementMaster()
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_UnitOfMeasurementMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_UnitOfMeasurementMaster");
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
        return ds;
    }

    //Function to Inserting BizConnect_UnitOfMeasurementMaster
    public Int32 Insert_UnitOfMeasurementMaster(int MeasurementTypeID, string Unit, string UnitOfMeasurementDescription, string IsActive)
    {
        int res = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_UnitOfMeasurementMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    //Inserting to Bizconnect_UnitOfMeasurementMaster
                    ada.SelectCommand.Parameters.AddWithValue("@obj_MeasurementTypeID", MeasurementTypeID);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Unit", Unit);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_UnitOfMeasurementDescription", UnitOfMeasurementDescription);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return res;
    }

    //Function to Updating BizConnect_TruckTypeMaster
    public Int32 Update_UnitOfMeasurementMaster(int UnitID, int MeasurementTypeID, string Unit, string UnitOfMeasurementDescription, string IsActive)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_BizConnect_UnitOfMeasurementMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UnitID", UnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_MeasurementTypeID", MeasurementTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Unit", Unit);
                ada.SelectCommand.Parameters.AddWithValue("@obj_UnitOfMeasurementDescription", UnitOfMeasurementDescription);
                ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", IsActive);
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

    //Retrieving Location from bizconnect_TruckTypeMaster table
    public DataSet get_TruckTypeMaster()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckTypeMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_TruckTypeMaster");
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

    //Retrieving Location from BizConnect_TruckBrandMaster table
    public DataSet get_TruckBrandMaster()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckBrandMasterAll", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_TruckBrandMasterAll");
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

    //Retrieving MeasurementType from BizConnect_MeasurementTypeMaster table
    public DataSet get_MeasurementTypeMaster()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_MeasurementTypeMaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "BizConnect_MeasurementTypeMaster");
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




    //------------------------NANDA'S Class------------------------------------------------------

    //Getting the Client Ads
    public DataSet GetMyTripplan(string userid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("BizConnect_GetMyTripplan", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Userid", userid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "GetMyTripplan");
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
    //Getting the Details of Client Ads
    public DataSet GetMyTripplan(string userid, string LPid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("BizConnect_GetMyTripplanDetails", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Userid", userid);
                ada.SelectCommand.Parameters.AddWithValue("@LPid", LPid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "GetMyTripplan");
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
    //Aarms Getting their Client Tripplans
    public DataSet GetClientTripplan()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("BizConnect_GetClientTripplan", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                // ada.SelectCommand.Parameters.AddWithValue("@userid", userid);

                try
                {
                    conn.Open();
                    ada.Fill(ds, "GetMyTripplan");
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
    //Search Tripplans by Clientwise
    public DataSet searchtripplanByClient(string Clientname)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("searchtripplanByClient", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Clientname", Clientname);

                try
                {
                    conn.Open();
                    ada.Fill(ds, "GetMyTripplan");
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



    //Consolidation of Trip plan

    public DataSet ConsolidationTripplan()
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("ConsolidateTripplan", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "GetMyTripplan");
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
        return dsc;


    }

    //Getting Details of  the clients Trip plan

    public DataSet ShowClientsplan(string source, string desination, string tdate, string Traveltype, string Truckcapacity, string Trucktype)
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("Showclienttripdetails", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Source", source);
                ada.SelectCommand.Parameters.AddWithValue("@Desination", desination);
                ada.SelectCommand.Parameters.AddWithValue("@tdate", tdate);
                ada.SelectCommand.Parameters.AddWithValue("@Traveltypeid", Traveltype);
                ada.SelectCommand.Parameters.AddWithValue("@capacity", Truckcapacity);
                ada.SelectCommand.Parameters.AddWithValue("@Trucktypeid", Trucktype);
                try
                {
                    conn.Open();
                    ada.Fill(dsc, "Tripplan");
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
        return dsc;


    }

    //Retrieving ID from Post Ad Table
    public ArrayList get_PostID()
    {
        int ID = 0;
        using (SqlConnection conn = new SqlConnection(connJun))
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
                            arr.Clear();
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
        Int32 obj_GoodsTypeID, Int32 obj_NoOfTrucks, String obj_TruckCapacity,
        Int32 obj_TruckTypeID, Int32 obj_EnclosureTypeID, Double obj_CostPerTruck,
        Double obj_TotalTruckCost, DateTime obj_PostExpiryDateTimeStamp,
        DateTime obj_PostQuoteLastDateTimeStamp, string obj_AdditionalComments, Int32 obj_GroupID, Int32 obj_TravelType, Int32 obj_TruckModelID, String obj_CapacityUnit,string City)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connJun))
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
                  ada.SelectCommand.Parameters.AddWithValue("@obj_BidStartTime", "NA" );
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

    ///Insert Record into Post Ad Table when User click submit button
    ///
    public Int32 Update_JunctionADid(string Adid, DateTime Traveldate,
         string obj_FromLocation, string obj_ToLocation, Double    obj_TruckCapacity, int Traveltypeid, int Trucktypeid,string pagename)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("BiZCONNECT_UpdateJunctionADid", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@ADid", Adid);
                ada.SelectCommand.Parameters.AddWithValue("@Traveldate", Traveldate);
                ada.SelectCommand.Parameters.AddWithValue("@Source", obj_FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@Designation", obj_ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@Traveltypeid", Traveltypeid);
                ada.SelectCommand.Parameters.AddWithValue("@Trucktypeid", Trucktypeid);
                ada.SelectCommand.Parameters.AddWithValue("@Capacity", obj_TruckCapacity);
                ada.SelectCommand.Parameters.AddWithValue("@Pagename", pagename);
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

    //Get the Quotes Received from Junction

    public DataSet GetQuotesReceived(string userid)
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("Bizconnect_GetQuotes", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_userid", userid);

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "Bizconnect_GetQuotes");
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
        return dsc;


    }

    // For retriving AArms Ads
    ////////////
    public DataSet GetMyAds(string obj_userid)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand comm = new SqlCommand("get_MyAds", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.Parameters.AddWithValue("@obj_userid", obj_userid);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyAds");
                    
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
        return ds;
    }

    //Get the PReAssigned Quotes of the Particular Client

    public DataSet GetBizConnectApproval(string obj_userid)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_Approval", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.Parameters.AddWithValue("@userid", obj_userid);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
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
        return ds;
    }

    //Get the Assigned Quotes of the Particular Client

    public DataSet GetBizConnectApprovalQuotes(string obj_userid)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_ApprovalQuotes", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.Parameters.AddWithValue("@userid", obj_userid);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
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
        return ds;
    }


    public int Update_Approval(int obj_preAid)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand comm = new SqlCommand("Update_Approval", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.Parameters.AddWithValue("@preassigid", obj_preAid);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
                    ada.Fill(dt);
                    resp = 1;
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
        return resp;
    }

    //Get the PREApproved Quotes from the Clients(Assignment)

    public DataSet BiZconnect_Assignment()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("BiZconnect_Assignment", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
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
        return ds;
    }

    //MY ASSIGNMENT

    public int Update_Assignment(int costpertruck, int Assignedtrucks, int replyid, int postid)
    {


        try
        {
            using (SqlConnection conn = new SqlConnection(connJun))
            {
                using (SqlCommand comm = new SqlCommand("Update_Assignment", conn))
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@CostperTruck", costpertruck);
                    ada.SelectCommand.Parameters.AddWithValue("@AssignedTrucks", Assignedtrucks);
                    ada.SelectCommand.Parameters.AddWithValue("@Replyid", replyid);
                    ada.SelectCommand.Parameters.AddWithValue("@postid", postid);

                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                    conn.Close();
                }
            }
        }
        catch (Exception err)
        {
            resp = 0;
        }
        finally
        {
        }

        return resp;
    }

    //Getting Details for Deal To Do

    public DataSet BiZconnect_DealToDo()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("BiZconnect_DealToDo", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
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
        return ds;
    }

    //Update DealToDo 

    public int Update_DealDone(int replyid, int postid)
    {


        try
        {
            using (SqlConnection conn = new SqlConnection(connJun))
            {
                using (SqlCommand comm = new SqlCommand("Update_DealDone", conn))
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                    ada.SelectCommand.Parameters.AddWithValue("@Replyid", replyid);
                    ada.SelectCommand.Parameters.AddWithValue("@postid", postid);

                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                    conn.Close();
                }
            }
        }
        catch (Exception err)
        {
            resp = 0;
        }
        finally
        {
        }

        return resp;
    }

    //Displaying Details of DealDone

    public DataSet BiZconnect_DealDone()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("BiZconnect_DealDone", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
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
        return ds;
    }
    //Cancel DealDone

    public int Cancel_DealDone(int replyid, int postid)
    {


        try
        {
            using (SqlConnection conn = new SqlConnection(connJun))
            {
                using (SqlCommand comm = new SqlCommand("Cancel_DealDone", conn))
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                    ada.SelectCommand.Parameters.AddWithValue("@Replyid", replyid);
                    ada.SelectCommand.Parameters.AddWithValue("@postid", postid);

                    ada.SelectCommand.ExecuteNonQuery();
                    resp = 1;
                    conn.Close();
                }
            }
        }
        catch (Exception err)
        {
            resp = 0;
        }
        finally
        {
        }

        return resp;
    }
    //Swetha's code
    //Retrieving client name
    public DataSet get_clientname(string obj_Clientemailid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_clientname", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Clientemailid", obj_Clientemailid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "clientname");
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

    //Retrieving data to list products
    public DataSet get_product(string clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_productlist", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_clientID", clientid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "product");
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


    //retrieving deactive product list
    public DataSet get_productdeactive(string clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_productlistdeactive", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_clientid", clientid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "product");
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
    public int connection_nonquery(string cmdstr)
    {
        SqlConnection con = new SqlConnection(connStr);


        con.Open();
        SqlCommand cmd = new SqlCommand(cmdstr, con);
        res = (int)cmd.ExecuteNonQuery();
        con.Close();
        return res;
    }
    //retrieving cities
    public DataSet FillCity()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_GST_BankAddressLocationID", obj_GSTConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;


            try
            {
                ada.Fill(ds, "Location");
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



    //Retrieving customer name
    public DataSet get_customername(string obj_Clientemailid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_customername", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Clientemailid", obj_Clientemailid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "clientname");
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

    //Function to Updating BizConnect_ClientMaster
    public Int32 Update_BizConnect_ClientMasterALL(int ClientID, string Companyname, int NOE, string PAN, string TIN, string CVATN, string STRN, int YOE, int Turnover, string URL,

        string City, string Address, string State, string Country, int PIN, string  BoardNumber, string MobileNo, string  FAX, string CorporateEmail, string ContactPerson, int Designation,int DesignationID,int LocTypeID,

        string EmailID, string Password, string FirstName, string MiddleName, string LastName, string Department, int Age, int Gender, string PhoneNo, string Mobile, int userid)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_BizConnect_ClientMasterALL", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                //ada.SelectCommand.Parameters.AddWithValue("@obj_ClientCode", Clientcode);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CompanyName", Companyname);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NoOfEmployees", NOE);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PermenantAccountNumber", PAN);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TaxpayerIdentificationNumber", TIN);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CentralValueAddedTaxRegistrationNumber", CVATN);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ServiceTaxRegistrationNumber", STRN);
                ada.SelectCommand.Parameters.AddWithValue("@obj_YearOfEstablishment", YOE);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TurnOver", Turnover);
                ada.SelectCommand.Parameters.AddWithValue("@obj_WebsiteURL", URL);

                ada.SelectCommand.Parameters.AddWithValue("@obj_City", City);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Address", Address);
                ada.SelectCommand.Parameters.AddWithValue("@obj_State", State);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Country", Country);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PinCode", PIN);
                ada.SelectCommand.Parameters.AddWithValue("@obj_BoardNo", BoardNumber);
                ada.SelectCommand.Parameters.AddWithValue("@obj_MobileNumber", MobileNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Fax", FAX);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CorporateEmail", CorporateEmail);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ContactPerson", ContactPerson);
                ada.SelectCommand.Parameters.AddWithValue("@obj_DesignationID", Designation);
                ada.SelectCommand.Parameters.AddWithValue("@LocTypeID", LocTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_EmailID", EmailID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Password", Password);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FirstName", FirstName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_MiddleName", MiddleName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LastName", LastName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Designation", DesignationID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Department", Department);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Age", Age);
                ada.SelectCommand.Parameters.AddWithValue("@obj_GenderID", Gender);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Phone", PhoneNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Mobile", Mobile);
                ada.SelectCommand.Parameters.AddWithValue("@obj_userID", userid);
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

//Sending Email to all users in SCM Junction Registrations

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

    //Retreving Email ID from Registration table by ADID
    public DataSet get_EmailIDByRID()
    {
        String obj_Email;
        string  obj_Rid;
       DataSet ds = new DataSet();
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("get_EmailIDALL", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "MyassignedAssignments");
                    
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

    //Retreving Email ID from Registration table by ADID
    public DataSet get_CCsByRID(int rid)
    {
        String obj_Email;
        string obj_Rid;
        DataSet ds = new DataSet();
        Int32 resp = 3;
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand comm = new SqlCommand("get_EmailIDCCsALL", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_Rid", rid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "getccs");

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
    
    
  
    
    //RoutepriceReport
    public DataSet get_RoutePriceReport()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_RoutePriceReport", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "LocationType");
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
    //Clients Logistics Plan
    public DataSet Get_BizConnect_ClientLogisticsPlan()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ClientLogisticsPlan", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "LocationType");
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

    //Get Transporter
    public DataSet Get_BizConnect_Transporter()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_Transporter", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "LocationType");
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
  //Get_BizConnect_RoutePriceReportByTransporter

    public DataSet Get_BizConnect_RoutePriceReportByTransporter(int Tid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_RoutePriceReportByTransporter", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@Tid", Tid);
            try
            {
                ada.Fill(ds, "LocationType");
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
    //Get Bizconnect Route price

    public DataSet Get_Bizconnect_RoutePrice(int UserID)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_Bizconnect_RoutePrice", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", UserID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Get_Bizconnect_RoutePrice");
                   
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

    //Updating Bizconnect_Route_Price 
    public int Update_Bizconnect_Route_Price(int RuteID, double Capacity, string Unit, double Oneway_Price, double Twoway_price)
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Update_BizConnect_Route_Price", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.Parameters.AddWithValue("@obj_RouteID", RuteID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Capacity", Capacity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Unit", Unit);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Oneway_Price", Oneway_Price);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Twoway_price", Twoway_price);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_Route_Price");
                    ada.Fill(dt);
                    resp = 1;
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
        return resp;
    }

    //Insert Rebid Data
    public int InsertReBid(string from, string to, string trucktype, string capacity, string trucksreq, string price, string rebidprice, int tid, int Userid, int clientid, string Remarks)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_InsertRebidPrice", conn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@FromLoc", from);
                    ada.SelectCommand.Parameters.AddWithValue("@ToLoc", to);
                    ada.SelectCommand.Parameters.AddWithValue("@TruckType", trucktype);
                    ada.SelectCommand.Parameters.AddWithValue("@Capactiy", capacity);
                    ada.SelectCommand.Parameters.AddWithValue("@TrucksReq", trucksreq);
                    ada.SelectCommand.Parameters.AddWithValue("@RoutePrice", price);
                    ada.SelectCommand.Parameters.AddWithValue("@ReBidPrice", rebidprice);
                    ada.SelectCommand.Parameters.AddWithValue("@TransporterID", tid);
                    ada.SelectCommand.Parameters.AddWithValue("@UserID", Userid);
                    ada.SelectCommand.Parameters.AddWithValue("@ClientID", clientid);
                    ada.SelectCommand.Parameters.AddWithValue("@Remarks", Remarks);
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

    //Get ALL Bizconnect Route price

    public DataSet Get_Bizconnect_AllRoutePrices()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_Bizconnect_AllRoutePrices", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds, "Get_Bizconnect_AllRoutePrices");

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

    //Get ALL Bizconnect Route price Search

    public DataSet Get_Bizconnect_AllRoutePricesSearch(string obj_FromLoc,string obj_Client, int obj_TransID ,int obj_Type)
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_Bizconnect_AllRoutePricesSearch", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_FromLoc", obj_FromLoc);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Client", obj_Client);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransID", obj_TransID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Type", obj_Type);

                try
                {
                    conn.Open();
                    ada.Fill(ds, "Get_Bizconnect_AllRoutePrices");

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



    //Get Clients ReBid price

    public DataSet Get_ClientReBidPrice()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_ClientReBidPrice", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds, "ClientReBidPrice");

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

    //get the distance
    public ArrayList get_citydistance(Int32 obj_SourceCityID, Int32 obj_DestinationCityID)
    {
        Int32 resp = 3;
        ArrayList arr = new ArrayList();
        string src, dest, dist,id;
        arr.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
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
                                id = dr[0].ToString().Trim();
                                resp = 1;
                                arr.Add(resp);
                                arr.Add(src);
                                arr.Add(dest);
                                arr.Add(dist);
                                arr.Add(id);
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

    public DataSet get_SourceCities()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
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
    //Get ALL Bizconnect FleetMaster

    public DataSet Fleetmaster()
    {

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Fleetmaster", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);


                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(ds, "Fleetmaster");

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
    //AARMSDASH BOARD
    public DataSet AARMSDashBoard()
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("AARMSDashBoard", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "AARMSDashBoard");
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
        return dsc;


    }
  //get_EmailandMobileForGodrej
    public DataSet get_EmailandMobileForGodrej()
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("get_EmailandMobileForGodrej", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "get_EmailandMobileForGodrej");
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
        return dsc;


    }

    //get_EmailandMobileForKurlon
    public DataSet get_EmailandMobileForKurlon()
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("get_EmailandMobileForKurlon", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "get_EmailandMobileForKurlon");
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
        return dsc;


    }
//Display Bidding log

    public DataTable ScmJunction_DisplayLog(int ReplyByID,int PostID)
    {
        DataTable dsc = new DataTable();
       
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("ScmJunction_DisplayLog", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
ada.SelectCommand.Parameters.AddWithValue("@ReplyByID", ReplyByID);
ada.SelectCommand.Parameters.AddWithValue("@postID", PostID );
                try
                {
                    conn.Open();
                    ada.Fill(dsc);
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
        return dsc;
}
//Display audit log

    public DataTable ScmJunction_DisplayAudit(int ReplyByID)
    {
        DataTable dsc = new DataTable();
       
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("ScmJunction_DisplayAudit", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
ada.SelectCommand.Parameters.AddWithValue("@obj_IndentID", ReplyByID);
                try
                {
                    conn.Open();
                    ada.Fill(dsc);
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
        return dsc;


    }

public Int32 Insert_Branchdetails(int RID, string BranchName, string Address, string City, string Pincode, string FirstName, string Designation, string MobNo, string BranchEmail, string BranchPassword)
    {
        int res = 0;
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_AddBranch", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.SelectCommand.Parameters.AddWithValue("@obj_RID", RID);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_BranchName", BranchName);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Address", Address);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_City", City);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Pincode", Pincode);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_FName", FirstName);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Designation", Designation);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_MobNo", MobNo);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Email", BranchEmail);
                    ada.SelectCommand.Parameters.AddWithValue("@obj_Pwd", BranchPassword);
                    ada.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        return res;
    }
    
    
     // Client Dispatch Plan
    public DataSet Client_DispatchPlan(int ClientID)
    {
        DataSet Dispatch_Ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("Get_DispatchPlan_Sp", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);

                try
                {
                    conn.Open();
                    ada.Fill(Dispatch_Ds, "get_EmailandMobileForGodrej");
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
        return Dispatch_Ds;

    }

 //get_EmailandMobileForClient
    public DataSet Bizconnect_GetTransporterForBidding(int ClientID)
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("Bizconnect_GetTransporterForBidding", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "get_EmailandMobileForGodrej");
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
        return dsc;


    }
    //Get Client Name 
    public DataSet Bizconnect_GetClientName(int ClientID)
    {
        DataSet dsc = new DataSet();
        dsc.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("Bizconnect_GetClientName", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;

                try
                {
                    conn.Open();
                    ada.Fill(dsc, "get_GetClientID");
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
        return dsc;


    }

public DataTable  Get_AARMSDashBoardClientname()
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("select distinct  CompanyName  ,LP.ClientID from Bizconnect.dbo.BizConnect_LogisticsPlan LP  inner join Bizconnect.dbo.BizConnect_ClientMaster CM on LP.ClientID=CM.ClientID ", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
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

    public DataTable Search_AARMSDashBoardByClientname(string ClientName)
    {
        DataTable dt = new DataTable();
        dt.Clear();
        using (SqlConnection conn = new SqlConnection(connJun))
        {
            using (SqlCommand cmd = new SqlCommand("Search_AARMSDashBoardByClientname", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure ;
                ada.SelectCommand.Parameters.AddWithValue("@Obj_ClientName", ClientName);
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

    public DataTable Get_ClientNameByClientID(int ClientID)
    {
        DataTable dt = new DataTable();
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand comm = new SqlCommand("Get_ClientNameByClientID", conn))
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
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


    
}

