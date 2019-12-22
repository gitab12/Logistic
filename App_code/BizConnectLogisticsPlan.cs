using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for BizConnectLogisticsPlan
/// </summary>
public class BizConnectLogisticsPlan
{
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
     SqlConnection obj_TMSConn = new SqlConnection();
	public BizConnectLogisticsPlan()
	{
		//
		// TODO: Add constructor logic here
		//
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        string TMSCon = ConfigurationManager.ConnectionStrings["TMScon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;
        obj_TMSConn.ConnectionString = TMSCon;

        obj_BizConn.Open();
        obj_SCMConn.Open();
        obj_TMSConn.Open();
        
	}

    ~BizConnectLogisticsPlan()
    {
        //obj_BizConn.Close();
       // obj_SCMConn.Close();
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
                            obj_LogisticsPlanID += 1;
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

    //Fill City By Client ID and Location Type ID
    public DataSet FillClientCityByClientIDandLocationTypeID(Int32 obj_ClientID, Int32 obj_LocationTypeID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ClientCityByClientIDandByLocationTypeID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", obj_LocationTypeID);
            try
            {
                ada.Fill(ds, "ClientCity");
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

    //Fill Client Address By Client ID and Location Type ID and City
    public DataSet FillClientAddressByClientIDandLocationTypeIDByCity(Int32 obj_ClientID, Int32 obj_LocationTypeID, String obj_City)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ClientAddressLocationByClientIDByLocationTypeIDByCity", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", obj_LocationTypeID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_City", obj_City);
            try
            {
                ada.Fill(ds, "ClientAddress");
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

    //Fill Client Address By ClientLocationTypeID
    public ArrayList FillClientAddressDetailsByClientLocationTypeID(Int32 obj_ClientAddressLocationID)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ClientAddressLocationByID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientAddressLocationID", obj_ClientAddressLocationID);
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
                        arr.Add(dr["ContactPerson"].ToString());
                        arr.Add(dr["Designation"].ToString());
                        arr.Add(dr["MobileNumber"].ToString());
                        arr.Add(dr["PinCode"].ToString());
                        arr.Add(dr["Fax"].ToString());
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

    //Fill Customer City By Customer ID and Location Type ID
    public DataSet FillCustomerCityByClientIDByCustomerIDLocationTypeID(Int32 obj_ClientID,Int32 obj_CustomerID, Int32 obj_LocationTypeID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerCityByClientIDByCustomerIDByLocationTypeID", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
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
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerAddressByCustomerIDByLocationTypeIDByCityName", obj_BizConn))
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

    //Fill Customer Address Details By Customer ID 
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
                        arr.Add(dr["ContactPerson"].ToString());
                        arr.Add(dr["Designation"].ToString());
                        arr.Add(dr["MobileNumber"].ToString());
                        arr.Add(dr["PinCode"].ToString());
                        arr.Add(dr["Fax"].ToString());
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

    //Fill Travel Type
    public DataSet FillTravelType()
    {
        DataSet obj_TravelTypeDs = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TravelTypeMasterAll", obj_BizConn))
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

    //Fill User Configuration Master by Key Name
    public ArrayList FillUserConfigurationMasterByKeyName(String obj_KeyName)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_UserConfigurationMasterByKeyName", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_KeyName", obj_KeyName);
            SqlDataReader dr = ada.SelectCommand.ExecuteReader();
            try
            {
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        arr.Add(dr["KeyValue"].ToString());
                        arr.Add(dr["ID"].ToString());
                    }
                }
                dr.Close();
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
    //Fill Client By ClientID
    public DataSet FillClientByClientID(Int32 obj_ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ClientMasterAllByClientID", obj_BizConn))
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
    //Fill Product Type
    public DataSet FillProductType()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_ProductTypeMasterAll", obj_BizConn))
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

    //Fill Products Name
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

    //Fill Truck Type
    public DataSet FillTruckType()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckTypeMasterAll", obj_BizConn))
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

    //Fill Enclosure Type
    public DataSet FillEnclosureType()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_EnclosureTypeMasterAll", obj_BizConn))
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

    //Fill Truck Brand
    public DataSet FillTruckBrand()
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckBrandMasterAll", obj_BizConn))
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

    //Fill Truck Model
    public DataSet FillTruckModelByBrandIDByCarrierGoodsType(Int32 obj_TruckBrandID, String obj_CarrierGoodsType)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckModelMasterByBrandIDByCarrierGoodsType", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", obj_TruckBrandID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CarrierGoodsType", obj_CarrierGoodsType);
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

    //Insert Record into Logistics Plan
    public Int32 Insert_LogisticsPlan(String obj_LogisticsPlanNo, Int32 obj_ClientID, Int32 obj_UserID, Int32 obj_CustomerID, Int32 obj_AARMSUserID,
                                    String obj_JunctionAdID,Int32 obj_LocationTypeID, String obj_FromLocation, String obj_ToLocation, DateTime obj_TravelDateTimeStamp,
                                    Int32 obj_ProductTypeID, Int32 obj_ProductCategoryID,Int32 obj_ProductID, String obj_ProductName, Double obj_Quantity, Int32 obj_TravelTypeID, 
                                    Int32 obj_TravelDistance,
                                    Int32 obj_TravelDistanceUnitID,
                                     Double obj_CostPerTruck, Double obj_Weight, Int32 obj_WeightUnitID,
                                    Double obj_Length, Int32 obj_LengthUnitID, Double obj_Width, Int32 obj_WidthUnitID, Double obj_Height,
                                    Int32 obj_HeightUnitID, Double obj_Volume, Int32 obj_VolumeUnitID, Int32 obj_NoOfTrucks,
                                    Double obj_QuantityPerTruck, Int32 obj_TruckTypeID, Int32 obj_EnclosureTypeID, Int32 obj_TruckBrandID,
                                    Int32 obj_TruckModelID, Int32 obj_ShipmentID, Double obj_TruckCapacity, Int32 obj_TruckCapacityUnitID,
                                    Int32 obj_TravelGroupID, DateTime obj_LastDateTimeStampForReceivingQuote, DateTime obj_LastDateTimeStampForClosingDeal,
                                    DateTime obj_LastDateTimeStampToModifyPlan, String obj_AdditionalComments, Int32 obj_StatusID, Int32 obj_IsActive,Int32 obj_TransitDay,string city,int ClientPrice)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_LogisticsPlan", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_LogisticsPlanNo", obj_LogisticsPlanNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", obj_ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerID", obj_CustomerID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_AARMSUserID", obj_AARMSUserID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_JunctionAdID", obj_JunctionAdID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LocationTypeID", obj_LocationTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FromLocation", obj_FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ToLocation", obj_ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDateTimeStamp", obj_TravelDateTimeStamp);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProductTypeID", obj_ProductTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProductCategoryID", obj_ProductCategoryID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProductID", obj_ProductID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProductName", obj_ProductName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Quantity", obj_Quantity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TravelTypeID", obj_TravelTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDistance", obj_TravelDistance);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDistanceUnitID", obj_TravelDistanceUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CostPerTruck", obj_CostPerTruck);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Weight", obj_Weight);
                ada.SelectCommand.Parameters.AddWithValue("@obj_WeightUnitID", obj_WeightUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Length", obj_Length);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LengthUnitID", obj_LengthUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Width", obj_Width);
                ada.SelectCommand.Parameters.AddWithValue("@obj_WidthUnitID", obj_WidthUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Height", obj_Height);
                ada.SelectCommand.Parameters.AddWithValue("@obj_HeightUnitID", obj_HeightUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Volume", obj_Volume);
                ada.SelectCommand.Parameters.AddWithValue("@obj_VolumeUnitID", obj_VolumeUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_NoOfTrucks", obj_NoOfTrucks);
                ada.SelectCommand.Parameters.AddWithValue("@obj_QuantityPerTruck", obj_QuantityPerTruck);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckTypeID", obj_TruckTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_EnclosureTypeID", obj_EnclosureTypeID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckBrandID", obj_TruckBrandID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckModelID", obj_TruckModelID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ShipmentID", obj_ShipmentID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckCapacity", obj_TruckCapacity);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckCapacityUnitID", obj_TruckCapacityUnitID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TravelGroupID", obj_TravelGroupID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LastDateTimeStampForReceivingQuote", obj_LastDateTimeStampForReceivingQuote);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LastDateTimeStampForClosingDeal", obj_LastDateTimeStampForClosingDeal);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LastDateTimeStampToModifyPlan", obj_LastDateTimeStampToModifyPlan);
                ada.SelectCommand.Parameters.AddWithValue("@obj_AdditionalComments", obj_AdditionalComments);
                ada.SelectCommand.Parameters.AddWithValue("@obj_StatusID", obj_StatusID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_IsActive", obj_IsActive);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TransitDay", obj_TransitDay);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_city", city );
                 ada.SelectCommand.Parameters.AddWithValue("@obj_ClientPrice", ClientPrice );
                
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

   
    //Insert record into Shipment Master
    public Int32 Insert_Shipment(Int32 obj_LogisticsPlanID,Int32 obj_ShipmentType,String obj_FirstName,
        String obj_MiddleName,String obj_LastName,String obj_City,String obj_Address,String obj_State,
        String obj_Country,Int32 obj_PinCode,string obj_BoardNumber,string obj_Fax,String obj_CorporateEmail,
        Int32 obj_IsActive)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_ShipmentMaster", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_LogisticsPlanID", obj_LogisticsPlanID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ShipmentType", obj_ShipmentType);
                ada.SelectCommand.Parameters.AddWithValue("@obj_FirstName", obj_FirstName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_MiddleName", obj_MiddleName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LastName", obj_LastName);
                ada.SelectCommand.Parameters.AddWithValue("@obj_City", obj_City);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Address", obj_Address);
                ada.SelectCommand.Parameters.AddWithValue("@obj_State", obj_State);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Country", obj_Country);
                ada.SelectCommand.Parameters.AddWithValue("@obj_PinCode", obj_PinCode);
                ada.SelectCommand.Parameters.AddWithValue("@obj_BoardNo", obj_BoardNumber);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Fax", obj_Fax);
                ada.SelectCommand.Parameters.AddWithValue("@obj_CorporateEmail", obj_CorporateEmail);
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


    //Retrieving Mobile No from User Log Table by UserID
    public ArrayList get_MobileByUserID(String obj_UserID)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        String obj_MobileNo;
        Int32 resp = 3;
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_UserLogDbByUserID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
                try
                {
                    SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                    if (dr.HasRows)
                    {
                        if (dr.Read())
                        {
                            if (!dr.IsDBNull(0))
                            {
                                resp = 1;
                                obj_MobileNo = dr.GetValue(10).ToString();
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

                }
            }
        arr.Add(resp);
        return arr;
    }

 	//Retrieving Customer Code from Customer Master Table by Customer Name
    public ArrayList Get_BizConnect_CustomerCodeByCustomerName(String obj_CustomerName)
    {
        ArrayList arr = new ArrayList();
        arr.Clear();
        String obj_CustomerCode,obj_CustomerID;
        Int32 resp = 3;
        using (SqlCommand comm = new SqlCommand("Get_BizConnect_CustomerCodeByCustomerName", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_CustomerName", obj_CustomerName);
            try
            {
                SqlDataReader dr = ada.SelectCommand.ExecuteReader();
                if (dr.HasRows)
                {
                    if (dr.Read())
                    {
                        if (!dr.IsDBNull(0))
                        {
                            resp = 1;
                            obj_CustomerCode = dr.GetValue(0).ToString();
                            obj_CustomerID = dr.GetValue(1).ToString();
                            arr.Add(obj_CustomerCode);
                            arr.Add(obj_CustomerID);
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

            }
        }
        arr.Add(resp);
        return arr;
    }

 //insert data into produst master
    public Int32 Insert_Product(int clientid, int stckkpngid, string prdctname, string prdctdesc, int prdcttypeid, int catid, int pckgngid, double weight, int weightid, double length, int lengthid, double width, int widthid, double height, int heightid, double vol, int volid, double Quantity,int qtyid,int incpckgsp, double trcost,double aarmscmcomm)
    {
        int res = 0;

        using (SqlCommand cmd = new SqlCommand("Insert_BizConnect_ProductMaster", obj_BizConn))
            {
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    da.SelectCommand.Parameters.AddWithValue("@obj_ClientID", clientid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_StockKeepingUnitID", stckkpngid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_ProductName", prdctname);
                    da.SelectCommand.Parameters.AddWithValue("@obj_ProductDescription", prdctdesc);
                    da.SelectCommand.Parameters.AddWithValue("@obj_ProductTypeID", prdcttypeid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_ProductCategoryID", catid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_PackingMethodID", pckgngid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Weight", weight);
                    da.SelectCommand.Parameters.AddWithValue("@obj_WeightUnitID", weightid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Length", length);
                    da.SelectCommand.Parameters.AddWithValue("@obj_LengthUnitID", lengthid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Width", width);
                    da.SelectCommand.Parameters.AddWithValue("@obj_WidthUnitID", widthid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Height", height);
                    da.SelectCommand.Parameters.AddWithValue("@obj_HeightUnitID", heightid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Volume", vol);
                    da.SelectCommand.Parameters.AddWithValue("@obj_VolumeUnitID", volid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_Quantity",Quantity);
                    da.SelectCommand.Parameters.AddWithValue("@obj_MeasurementTypeID", qtyid);
                    da.SelectCommand.Parameters.AddWithValue("@obj_IncludePackageSpace", incpckgsp);
                    da.SelectCommand.Parameters.AddWithValue("@obj_TransportationCost", trcost);
                    da.SelectCommand.Parameters.AddWithValue("@obj_AARMSCMCommision", aarmscmcomm);
                    da.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception err)
                {
                    res = 0;
                }
                finally
                {
                    
                }
            }
        
        return res;
    }
//--------------Inserting into User access Permission------------------
    public Int32 Insert_UserPermission(Int32 obj_UserID, Int32 obj_portalid, Int32 obj_featureid, Int32 obj_feature_category_id, Int32 obj_Accessid)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Insert_BizConnect_UserPermission", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", obj_UserID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_portalid", obj_portalid);
                ada.SelectCommand.Parameters.AddWithValue("@obj_featureid", obj_featureid);
                ada.SelectCommand.Parameters.AddWithValue("@obj_feature_category_id", obj_feature_category_id);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Accessid", obj_Accessid);
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

    //get the distance
    public ArrayList get_citydistance(Int32 obj_SourceCityID, Int32 obj_DestinationCityID)
    {
        Int32 resp = 3;
        ArrayList arr = new ArrayList();
        string src, dest, dist;
        arr.Clear();

        using (SqlCommand comm = new SqlCommand("get_citydistance", obj_SCMConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_SourcecityID", obj_SourceCityID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_DestcityID", obj_DestinationCityID);
                try
                {
                  
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
                   
                }
            }
        

        return arr;
    }

    //get cityid
    public DataSet FillCityId(String CityName)
    {
        DataSet ds = new DataSet();
        try
        {
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_CityID", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_City", CityName);
                ada.Fill(ds, "CityID");
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

 //Function to Getting BizConnect_TruckMasterByName
    public int Get_BizConnect_TruckTypeByName(string TruckName)
    {
        int resp=0;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        ds.Clear();
       
            using (SqlCommand comm = new SqlCommand("Get_BizConnect_TruckTypeByName", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_TruckName", TruckName);
                try
                {
                   
                    ada.Fill(ds, "BizConnect_TruckModelMaster");
                    resp = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);
                }
                catch (Exception err)
                {

                }
                finally
                {
                   
                }
            }
        
        return resp;
    }


    public DataSet Get_Bizconnect_RouteSearch(int UserID, string TravelDate, int mode, string Time)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Get_Bizconnect_RoutePriceSearch", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", UserID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_TravelDate", TravelDate);
            ada.SelectCommand.Parameters.AddWithValue("@mode", mode);
            ada.SelectCommand.Parameters.AddWithValue("@Time", Time);
            ada.SelectCommand.CommandTimeout = 40000;

            try
            {
                ada.Fill(ds, "Bizconnect_RouteSearch");
            }
            catch (Exception err)
            {

            }

        }
        return ds;
    }

//Insert Despatch Plan in Bizconnect_DespatchPlan table




public int Bizconnect_InsertDespatchPlan(int ProductID, string ProductName ,int SKU,DateTime TravelDate,double  TotalWeightinTons,string FromLocation,string ToLocation,int PlanNo,int ClientID,int NumberofCartons, Double TotalWeight, int Quantity)
    {
        Int32 obj_resp = 0;
        try
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_InsertDespatchPlan", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@ProductID", ProductID);
                ada.SelectCommand.Parameters.AddWithValue("@ProductName", ProductName);
                ada.SelectCommand.Parameters.AddWithValue("@SKU", SKU);
                ada.SelectCommand.Parameters.AddWithValue("@TravelDate", TravelDate);
                ada.SelectCommand.Parameters.AddWithValue("@TotalWeightinTons", TotalWeightinTons);
                ada.SelectCommand.Parameters.AddWithValue("@FromLocation", FromLocation);
                ada.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@PlanNo", PlanNo );
                ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID );                
                ada.SelectCommand.Parameters.AddWithValue("@NumberofCartons", NumberofCartons);
                ada.SelectCommand.Parameters.AddWithValue("@TotalWeight", TotalWeight);
                ada.SelectCommand.Parameters.AddWithValue("@Quantity", Quantity);

                //ada.SelectCommand.Parameters.AddWithValue("@Qty", Qty);
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
    
   
    
    
    public DataTable Get_Bizconnect_InsertGrid(string PlanNo)
    {
        DataTable ds = new DataTable();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_SendDatatomail", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
           ada.SelectCommand.Parameters.AddWithValue("@obj_PlanID", PlanNo);            

            try
            {
                ada.Fill(ds);
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
    
    
    public int InsertPostRFQ_TMS(int ClientID,string AdID,string FromLoc,string ToLoc,string Material,int TruckType,int EnclType,int NoOfTrucks,float Capacity,string Period,string Remarks)
    {
        {
            Int32 obj_resp = 0;
            try
            {
                using (SqlCommand comm = new SqlCommand("Insert_Into_New_RFQ", obj_TMSConn))
                {
                    SqlDataAdapter ada = new SqlDataAdapter(comm);
                    ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                    ada.SelectCommand.Parameters.AddWithValue("@Client", ClientID);
                    ada.SelectCommand.Parameters.AddWithValue("@From_Location",FromLoc);
                    ada.SelectCommand.Parameters.AddWithValue("@To_Location",ToLoc);
                    ada.SelectCommand.Parameters.AddWithValue("@RFQ_NO",AdID);
                    ada.SelectCommand.Parameters.AddWithValue("@Material", Material);
                    ada.SelectCommand.Parameters.AddWithValue("@Type_Of_Vehicle", TruckType);
                    ada.SelectCommand.Parameters.AddWithValue("@Enclosure_Type",EnclType);
                    ada.SelectCommand.Parameters.AddWithValue("@No_Of_Vehicles",NoOfTrucks );
                    ada.SelectCommand.Parameters.AddWithValue("@Capacity",Capacity);
                    ada.SelectCommand.Parameters.AddWithValue("@Period",Period);
                    ada.SelectCommand.Parameters.AddWithValue("@Remarks",Remarks);
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

    }

    public DataSet Get_Bizconnect_LoadDespatchDetailsforDownloadToExcel(int ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("select ProductCode ,dp.ProductName ,FromLocation ,ToLocation ,PlanNo ,TotalWeightinTons from Bizconnect_DespatchPlan  DP left join BizConnect_ProductMaster PM on dp.ProductID =pm.ProductID where dp.ClientID =" + ClientID, obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;

            try
            {
                ada.Fill(ds,"report");
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


    public DataTable Bizconnect_GetTruckTypeIDByTruckType(string TruckType)
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm = new SqlCommand("Bizconnect_GetTruckTypeIDByTruckType", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@TruckType", TruckType);
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