using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for ImportExport
/// </summary>
public class ImportExport
{
    public string PoNumber
    {
        get;
        set;
    }

    public string Product
    {
        get;
        set;
    }
    public DateTime PoDate
    {
        get;
        set;
    }

    public string ProductDesc
    {
        get;
        set;
    }

    public int UOM
    {
        get;
        set;
    }
    public string Country
    {
        get;
        set;
    }
    public float  BasicValue
    {
        get;
        set;
    }
    public string CurrencyConversion
    {
        get;
        set;
    }
    public string CustomDuties
    {
        get;
        set;
    }
   
    public string Freight
    {
        get;
        set;
    }
    public string Insurance
    {
        get;
        set;
    }
    public float  OtherCharges
    {
        get;
        set;
    }
    public float  LandPrice
    {
        get;
        set;
    }
    public string FileName
    {
        get;
        set;
    }

    public byte [] ScanCopy
    {
        get;
        set;
    }

    public int  Status
    {
        get;
        set;
    }


    public int BuyerID
    {
        get;
        set;
    }
    public string BuyerName
    {
        get;
        set;
    }
    public int VendorID
    {
        get;
        set;
    }

    public string ContactPerson
    {
        get;
        set;
    }
    public string ContactNo
    {
        get;
        set;
    }
    public string EmailID
    {
        get;
        set;
    }

    public string Address
    {
        get;
        set;
    }

    public string Password
    {
        get;
        set;
    }


    public string VendorName
    {
        get;
        set;
    }

    public string AgencyName
    {
        get;
        set;
    }


    public string ModeofShipment
    {
        get;
        set;
    }

    public string ModeofPayment
    {
        get;
        set;
    }


    public string CreditTerms
    {
        get;
        set;
    }


    public int Exchangerate
    {
        get;
        set;
    }

    public string Unit
    {
        get;
        set;
    }


    public int Quantity
    {
        get;
        set;
    }


    public float Unitrate
    {
        get;
        set;
    }

    public string Portofloading
    {
        get;
        set;
    }

    public string Portofdischarge
    {
        get;
        set;
    }

    public int ClientID
    {
        get;
        set;
    }
    public int UserID
    {
        get;
        set;
    }

    public string Incoterms
    {
        get;
        set;
    }

    public string Nominatepickup
    {
        get;
        set;
    }


    public float XWKSCostofinlandtransport
    {
        get;
        set;
    }

    public float XWKSOceanfreight
    {
        get;
        set;
    }
    public float XWKSCutomduty
    {
        get;
        set;
    }
    public float XWKSLocaltransportcost
    {
        get;
        set;
    }
    public float XWKSInsurance
    {
        get;
        set;
    }
    public float XWKSLandedcost
    {
        get;
        set;
    }
    public float FOBFreight
    {
        get;
        set;
    }
    public float FOBInsurance
    {
        get;
        set;
    }
    public float FOBCustomduty
    {
        get;
        set;
    }
    public float FOBLocaltransport
    {
        get;
        set;
    }
    public float FOBLandedcost
    {
        get;
        set;
    }
    public float CandFInsurance
    {
        get;
        set;
    }
    public float CandFCustomduty
    {
        get;
        set;
    }
    public float CandFLocaltransport
    {
        get;
        set;
    }
    public float CandFLandedcost
    {
        get;
        set;
    }
    public float CIFCustomduty
    {
        get;
        set;
    }
    public float CIFLocaltransport
    {
        get;
        set;
    }
    public float CIFLandedcost
    {
        get;
        set;
    }


    public int OrderID
    {
        get;
        set;
    }

    public string InvoiceNo
    {
        get;
        set;
    }

    public DateTime InvoiceDate
    {
        get;
        set;
    }

    public float InvoiceAmount
    {
        get;
        set;
    }

    public string BLorAWBNo
    {
        get;
        set;
    }

    public string VesselName
    {
        get;
        set;
    }

    public DateTime ETD
    {
        get;
        set;
    }

    public DateTime ETA
    {
        get;
        set;
    }

    public string IGM
    {
        get;
        set;
    }
    public string Billofentryno
    {
        get;
        set;
    }
    public DateTime Billofentrydate
    {
        get;
        set;
    }
    public float Assessablevalue
    {
        get;
        set;
    }
    public float Basicduty
    {
        get;
        set;
    }
    public string CVD
    {
        get;
        set;
    }
    public float EduCess
    {
        get;
        set;
    }
    public float ServiceCharge
    {
        get;
        set;
    }
    public float TotalDuty
    {
        get;
        set;
    }

    public string HSCodeno
    {
        get;
        set;
    }
    public string Dutypaymentpayorderno
    {
        get;
        set;
    }
    public DateTime Dutypaymentpayorderdate
    {
        get;
        set;
    }

    public int OutPut
    {
        get;
        set;
    }

    public string DeliveryChallanno
    {
        get;
        set;
    }
    public DateTime DeliveryChallanDate
    {
        get;
        set;
    }
    public float ShipmentclearanceCost
    {
        get;
        set;
    }

    public int ResultID
    {
        get;
        set;
    }


    public DateTime BLorAWBDate
    {
        get;
        set;
    }
    public string Docsent
    {
        get;
        set;
    }
    public string ORIDoccourierAWBno
    {
        get;
        set;
    }
    public DateTime ORIDoccourierAWBDate
    {
        get;
        set;
    }
    public string FRTFWDname
    {
        get;
        set;
    }
    public string CHAname
    {
        get;
        set;
    }
    public string Billofentrytype
    {
        get;
        set;
    }
    public string Homebillofentryno
    {
        get;
        set;
    }
    public float Exchrate
    {
        get;
        set;
    }
    public string Dutysctructure
    {
        get;
        set;
    }
    public DateTime Dutypaidon
    {
        get;
        set;
    }
    public string Licencedetail
    {
        get;
        set;
    }
    public string Transporter
    {
        get;
        set;
    }
    public string Vehicleno
    {
        get;
        set;
    }
    public string LRNo
    {
        get;
        set;
    }
    public DateTime LRDate
    {
        get;
        set;
    }
    public DateTime Deliveryon
    {
        get;
        set;
    }
    public string CHABillno
    {
        get;
        set;
    }
    public DateTime CHADate
    {
        get;
        set;
    }
    public float CHAAmount
    {
        get;
        set;
    }
    public string CHABillpaymentdetail
    {
        get;
        set;
    }


    public DateTime DeliveryDate
    {
        get;
        set;
    }
    public DateTime ThirdpartyInspectionDate
    {
        get;
        set;
    }
    public DateTime StuffingDate
    {
        get;
        set;
    }
    public string FreightForwardedName
    {
        get;
        set;
    }
    public string VehicleNo
    {
        get;
        set;
    }
    public string PreShipmentInvoiceNo
    {
        get;
        set;
    }
    public string CHA
    {
        get;
        set;
    }
    public DateTime PreShipmentInvoiceDate
    {
        get;
        set;
    }
    public DateTime ETDDetailToCustomerOn
    {
        get;
        set;
    }
    public DateTime PReShipmentDocSentToCHAOn
    {
        get;
        set;
    }

    public string ShippingBillNo
    {
        get;
        set;
    }
    public DateTime ShippingBillDate
    {
        get;
        set;
    }
    public DateTime CargoHandedOverToLinerOn
    {
        get;
        set;
    }
    public DateTime CargoOnBoard
    {
        get;
        set;
    }
    public DateTime ActualETD
    {
        get;
        set;
    }
    public DateTime COOorGSPAppliedOn
    {
        get;
        set;
    }
    public string DocSubmittedToConsulate
    {
        get;
        set;
    }


    public DateTime OriginalShippingDocReceivedOn
    {
        get;
        set;
    }

    public DateTime NNSentToCustomerOn
    {
        get;
        set;
    }

    public DateTime CommercialDocLodgedwithBankOn
    {
        get;
        set;
    }

    public DateTime LodmentRefDate
    {
        get;
        set;
    }

    public DateTime PaymentdueDate
    {
        get;
        set;
    }

    public DateTime TTRemittanceDate
    {
        get;
        set;
    }

    public DateTime DisbursementAdviseSentToBankOn
    {
        get;
        set;
    }

    public DateTime TransactionAdviseDate
    {
        get;
        set;
    }

    public DateTime BRCUploadedOn
    {
        get;
        set;
    }

    public DateTime DutyDrawbackReceivedOn
    {
        get;
        set;
    }

    public DateTime ProofOfExportDocReceivedOn
    {
        get;
        set;
    }

    public DateTime ProofOfExportDocSentToFactory
    {
        get;
        set;
    }

    public DateTime ProofOfExportDocSentToLicenceDept
    {
        get;
        set;
    }
    public string LodmentRefNo
    {
        get;
        set;
    }
    public string TTRemittanceNo
    {
        get;
        set;
    }

    public int ExportID
    {
        get;
        set;
    }

    public string Currency
    {
        get;
        set;
    }

    public string CHAName
    {
        get;
        set;
    }

    public string Internalworksorder
    {
        get;
        set;
    }

    public string LOTsize
    {
        get;
        set;
    }

    public string NetWeight
    {
        get;
        set;
    }

    public string Scheme
    {
        get;
        set;
    }

    public string CHAbillno
    {
        get;
        set;
    }
    public DateTime CHAbilldate
    {
        get;
        set;
    }
    public float CHAbillamount
    {
        get;
        set;
    }
    public float Freightamount
    {
        get;
        set;
    }
    public float Detention
    {
        get;
        set;
    }
    public float WHcharges
    {
        get;
        set;
    }


    public string CompanyName
    {
        get;
        set;
    }


    public string MarketingHead
    {
        get;
        set;
    }
    public string OperationHead
    {
        get;
        set;
    }
    public string MobileNo
    {
        get;
        set;
    }
    public string BoardLine
    {
        get;
        set;
    }

    public string LocationofBranches
    {
        get;
        set;
    }
    public Boolean CHALicence
    {
        get;
        set;
    }
    public string CHALicenceNo
    {
        get;
        set;
    }
    public Boolean IATAMember
    {
        get;
        set;
    }
    public Boolean IssueAWB
    {
        get;
        set;
    }

    public string CompetitiveSector
    {
        get;
        set;
    }
    public Boolean consolidationServices
    {
        get;
        set;
    }
    public string consolidationServicesSector
    {
        get;
        set;
    }
    public string ProductsSpecialisedIn
    {
        get;
        set;
    }

    public Boolean handlingAIRAndSeaClearance
    {
        get;
        set;
    }
    public string SpecialisedServices
    {
        get;
        set;
    }
    public string RegistrationType
    {
        get;
        set;
    }

    SqlConnection obj_conn = new SqlConnection();

	public ImportExport()
	{
        string conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        obj_conn.ConnectionString = conn;
        obj_conn.Open();
	}

    public DataTable Bizconnect_LoadProductName()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select distinct ProductName  from BizConnect_ProductMaster order by ProductName", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadUOM()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select distinct UnitID , Unit   from BizConnect_UnitOfMeasurementMaster order by Unit ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }

    public DataTable Bizconnect_LoadCountry()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select distinct Country,CountryID   from GSTWorkFlow .dbo.GST_CountryMaster order by Country ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadProductCodeByProductName(string ProductName)
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select productcode from BizConnect_ProductMaster where productname='" + ProductName + "'", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    // Insert Bizconnect_InsertImporExportBuyerDetails 
    public int Bizconnect_InsertImporExportBuyerDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertImporExportBuyerDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@Buyername", BuyerName);
                da.SelectCommand.Parameters.AddWithValue("@Contactperson", ContactPerson);
                da.SelectCommand.Parameters.AddWithValue("@Contactno", ContactNo);
                da.SelectCommand.Parameters.AddWithValue("@Emailid", EmailID);
                da.SelectCommand.Parameters.AddWithValue("@Address", Address);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }



    // Insert Bizconnect_InsertImportExportVendorDetails 
    public int Bizconnect_InsertImportExportVendorDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertImportExportVendorDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@Vendorname", VendorName);
                da.SelectCommand.Parameters.AddWithValue("@Contactperson", ContactPerson);
                da.SelectCommand.Parameters.AddWithValue("@Contactno", ContactNo);
                da.SelectCommand.Parameters.AddWithValue("@Emailid", EmailID);
                da.SelectCommand.Parameters.AddWithValue("@Address", Address);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }



    // Insert Bizconnect_InsertImportExportVendorDetails 
    public int Bizconnect_InsertImportExportAgencyDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertImportExportAgencyDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@AgencyName", AgencyName);
                da.SelectCommand.Parameters.AddWithValue("@Contactperson", ContactPerson);
                da.SelectCommand.Parameters.AddWithValue("@Contactno", ContactNo);
                da.SelectCommand.Parameters.AddWithValue("@Emailid", EmailID);
                da.SelectCommand.Parameters.AddWithValue("@Address", Address);
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return res;
        }
    }


    // Insert Bizconnect_InsertOrderManagementDetails 
    public int Bizconnect_InsertOrderManagementDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertOrderManagementDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@BuyerID", BuyerID);
                da.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
                da.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
                da.SelectCommand.Parameters.AddWithValue("@PoNumber", PoNumber);
                da.SelectCommand.Parameters.AddWithValue("@PoDate", PoDate);
                da.SelectCommand.Parameters.AddWithValue("@Product", Product);
                da.SelectCommand.Parameters.AddWithValue("@ProductDesc", ProductDesc);
                //da.SelectCommand.Parameters.AddWithValue("@ProductName", ProductName);
                //da.SelectCommand.Parameters.AddWithValue("@ProductCode", ProductCode);
                da.SelectCommand.Parameters.AddWithValue("@VendorID", VendorID);
                da.SelectCommand.Parameters.AddWithValue("@VendorCountry", Country);
                da.SelectCommand.Parameters.AddWithValue("@UOM", UOM);
                //da.SelectCommand.Parameters.AddWithValue("@Country", Country);
                da.SelectCommand.Parameters.AddWithValue("@ModeofShipment", ModeofShipment);
                da.SelectCommand.Parameters.AddWithValue("@ModeofPayment", ModeofPayment);
                da.SelectCommand.Parameters.AddWithValue("@CreditTerms", CreditTerms);
                da.SelectCommand.Parameters.AddWithValue("@BasicValue", BasicValue);
                da.SelectCommand.Parameters.AddWithValue("@CurrencyConversion", CurrencyConversion);
                //da.SelectCommand.Parameters.AddWithValue("@CustomDuties", CustomDuties);
                da.SelectCommand.Parameters.AddWithValue("@ExchangeRate", Exchangerate);
                da.SelectCommand.Parameters.AddWithValue("@Unit", Unit);
                da.SelectCommand.Parameters.AddWithValue("@Quantity", Quantity);
                da.SelectCommand.Parameters.AddWithValue("@UnitRate", Unitrate);
                //da.SelectCommand.Parameters.AddWithValue("@Portofloading", Portofloading);
                //da.SelectCommand.Parameters.AddWithValue("@Portofdischarge", Portofdischarge);
                da.SelectCommand.Parameters.AddWithValue("@IncoTerms", Incoterms);
                da.SelectCommand.Parameters.AddWithValue("@Nominatepickup", Nominatepickup);
                da.SelectCommand.Parameters.AddWithValue("@XWKSCostofinlandtransport", XWKSCostofinlandtransport);
                da.SelectCommand.Parameters.AddWithValue("@XWKSOceanfreight", XWKSOceanfreight);
                da.SelectCommand.Parameters.AddWithValue("@XWKSCutomduty", XWKSCutomduty);
                da.SelectCommand.Parameters.AddWithValue("@XWKSLocaltransportcost", XWKSLocaltransportcost);
                da.SelectCommand.Parameters.AddWithValue("@XWKSInsurance", XWKSInsurance);
                da.SelectCommand.Parameters.AddWithValue("@XWKSLandedcost", XWKSLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@FOBFreight", FOBFreight);
                da.SelectCommand.Parameters.AddWithValue("@FOBInsurance", FOBInsurance);
                da.SelectCommand.Parameters.AddWithValue("@FOBCustomduty", FOBCustomduty);
                da.SelectCommand.Parameters.AddWithValue("@FOBLocaltransport", FOBLocaltransport);
                da.SelectCommand.Parameters.AddWithValue("@FOBLandedcost", FOBLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@CandFInsurance", CandFInsurance);
                da.SelectCommand.Parameters.AddWithValue("@CandFCustomduty", CandFCustomduty);
                da.SelectCommand.Parameters.AddWithValue("@CandFLocaltransport", CandFLocaltransport);
                da.SelectCommand.Parameters.AddWithValue("@CandFLandedcost", CandFLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@CIFCustomduty", CIFCustomduty);
                da.SelectCommand.Parameters.AddWithValue("@CIFLocaltransport", CIFLocaltransport);
                da.SelectCommand.Parameters.AddWithValue("@CIFLandedcost", CIFLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@FileName", FileName);
                da.SelectCommand.Parameters.AddWithValue("@ScanCopy", ScanCopy);
                da.SelectCommand.Parameters.AddWithValue("@Status", Status);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return res;
        }
    }


    public DataTable Bizconnect_LoadBuyer()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select distinct buyerid,buyername from bizconnect_importexportbuyermaster order by  buyername ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadVendor()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select distinct VendorID ,Vendorname  from Bizconnect_ImportExportVendorMaster  order by Vendorname ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadPoNumber()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select OrderID ,PoNumber  from Bizconnect_OrderManagement order by OrderID desc", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    // Update Bizconnect_UpdateOrdermanagementInvoiceDetails 
    public int Bizconnect_UpdateOrdermanagementInvoiceDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateOrdermanagementInvoiceDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
                da.SelectCommand.Parameters.AddWithValue("@InvoiceNo", InvoiceNo);
                da.SelectCommand.Parameters.AddWithValue("@InvoiceDate", InvoiceDate);
                da.SelectCommand.Parameters.AddWithValue("@InvoiceAmount", InvoiceAmount);
                da.SelectCommand.Parameters.AddWithValue("@VesselName", VesselName);
                da.SelectCommand.Parameters.AddWithValue("@ETD", ETD);
                da.SelectCommand.Parameters.AddWithValue("@ETA", ETA);
                da.SelectCommand.Parameters.AddWithValue("@Portofloading", Portofloading);
                da.SelectCommand.Parameters.AddWithValue("@Portofdischarge", Portofdischarge);
                da.SelectCommand.Parameters.AddWithValue("@Docsent", Docsent);
                da.SelectCommand.Parameters.AddWithValue("@BLorAWBNo", BLorAWBNo);
                da.SelectCommand.Parameters.AddWithValue("@BLorAWBDate", BLorAWBDate);
                da.SelectCommand.Parameters.AddWithValue("@ORIDoccourierAWBno", ORIDoccourierAWBno);
                da.SelectCommand.Parameters.AddWithValue("@ORIDoccourierAWBDate", ORIDoccourierAWBDate);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }


    // Update Bizconnect_UpdateOrdermanagementCustomDocumentDetails 
    public int Bizconnect_UpdateOrdermanagementCustomDocumentDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateOrdermanagementCustomDocumentDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
                da.SelectCommand.Parameters.AddWithValue("@FRTFWDname", FRTFWDname);
                da.SelectCommand.Parameters.AddWithValue("@CHAname", CHAname);
                da.SelectCommand.Parameters.AddWithValue("@IGM", IGM);
                da.SelectCommand.Parameters.AddWithValue("@Billofentrytype", Billofentrytype);
                da.SelectCommand.Parameters.AddWithValue("@Homebillofentryno", Homebillofentryno);
                da.SelectCommand.Parameters.AddWithValue("@Billofentryno", Billofentryno);
                da.SelectCommand.Parameters.AddWithValue("@Billofentrydate", Billofentrydate);
                da.SelectCommand.Parameters.AddWithValue("@Exchrate", Exchrate);
                da.SelectCommand.Parameters.AddWithValue("@Assessablevalue", Assessablevalue);
                da.SelectCommand.Parameters.AddWithValue("@Dutysctructure", Dutysctructure);
                da.SelectCommand.Parameters.AddWithValue("@TotalDuty", TotalDuty);
                da.SelectCommand.Parameters.AddWithValue("@CVD", CVD);
                da.SelectCommand.Parameters.AddWithValue("@Dutypaymentpayorderno", Dutypaymentpayorderno);
                da.SelectCommand.Parameters.AddWithValue("@Dutypaymentpayorderdate", Dutypaymentpayorderdate);
                da.SelectCommand.Parameters.AddWithValue("@Dutypaidon", Dutypaidon);
                da.SelectCommand.Parameters.AddWithValue("@Licencedetail", Licencedetail);
                da.SelectCommand.Parameters.AddWithValue("@HSCodeno", HSCodeno);
                //da.SelectCommand.Parameters.AddWithValue("@Basicduty", Basicduty);
                //da.SelectCommand.Parameters.AddWithValue("@EduCess", EduCess);
                //da.SelectCommand.Parameters.AddWithValue("@ServiceCharge", ServiceCharge);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }


    public DataTable Bizconnect_LoadPoDetails()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_LoadPoDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }

    public DataTable Bizconnect_LoadInvoiceDetails()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_LoadInvoiceDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadCustomDocumentdetails()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select Billofentryno ,convert (varchar(20), Billofentrydate,103) as Billofentrydate,Assessablevalue ,Basicduty ,  TotalDuty ,Dutypaymentpayorderno ,CVD, ServiceCharge   from Bizconnect_OrderManagement where OrderID =" + OrderID, obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }

    // Update Bizconnect_UpdateOrdermanagementCHADeliveryDetails 
    public int Bizconnect_UpdateOrdermanagementCHADeliveryDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateOrdermanagementCHADeliveryDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@OrderID", OrderID);
                da.SelectCommand.Parameters.AddWithValue("@DeliveryChallanno", DeliveryChallanno);
                da.SelectCommand.Parameters.AddWithValue("@DeliveryChallanDate", DeliveryChallanDate);
                da.SelectCommand.Parameters.AddWithValue("@Transporter", Transporter);
                da.SelectCommand.Parameters.AddWithValue("@Vehicleno", Vehicleno);
                da.SelectCommand.Parameters.AddWithValue("@LRNo", LRNo);
                da.SelectCommand.Parameters.AddWithValue("@LRDate", LRDate);
                da.SelectCommand.Parameters.AddWithValue("@Deliveryon", Deliveryon);
                da.SelectCommand.Parameters.AddWithValue("@CHABillno", CHABillno);
                da.SelectCommand.Parameters.AddWithValue("@CHADate", CHADate);
                da.SelectCommand.Parameters.AddWithValue("@CHAAmount", CHAAmount);
                da.SelectCommand.Parameters.AddWithValue("@CHABillpaymentdetail", CHABillpaymentdetail);
                da.SelectCommand.Parameters.AddWithValue("@ShipmentclearanceCost", ShipmentclearanceCost);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }


    public DataTable Bizconnect_LoadInvoicedetailsForUpdate()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select InvoiceNo ,convert (varchar(20), InvoiceDate,103) as InvoiceDate ,InvoiceAmount ,[B/L(or)AWB No] ,VesselName , convert (varchar(20),  ETD,103) as ETD ,convert (varchar(20), ETA,103) as ETA,portofloading,Portofdischarge,docsent,convert (varchar(20),[B/L(or)AWB Date],103) as BlorAWBDate ,ORIDoccourierAWBno,convert (varchar(20),ORIDoccourierAWBDate,103) as ORIDoccourierAWBDate from Bizconnect_OrderManagement where OrderID=" + OrderID, obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadCustomDocDetailsForUpdate()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select FRTFWDname ,CHAName ,IGM ,Billentrytype ,Homebillofentryno ,Billofentryno ,convert (varchar(20), Billofentrydate,103) as Billofentrydate , ExchRate ,Assessablevalue,DutySctructure,TotalDuty ,CVDAmount,Dutypaymentpayorderno ,convert (varchar(20),Dutypaymentpayorderdate,103) as  Dutypaymentpayorderdate,convert (varchar(20), DutyPaidon ,103) as DutyPaidon  ,licencedetail ,Basicduty ,EduCess ,ServiceCharge,HSCodeno   from Bizconnect_OrderManagement where OrderID=" + OrderID, obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }

    public DataTable Bizconnect_LoadCHAChallanDetailsForUpdate()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select DeliveryChallanno ,convert (varchar(20), DeliveryChallanDate,103) as DeliveryChallanDate ,	Transporter ,Vehicleno ,LRNo ,convert (varchar(20), LRDate,103) as LRDate ,convert (varchar(20), Deliveryon,103) as Deliveryon ,CHABillno ,convert (varchar(20), CHADate,103) as CHADate ,CHAAmount ,CHABillpaymentdetail 	,ShipmentclearanceCost  from Bizconnect_OrderManagement  where OrderID=" + OrderID, obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    //Insert Export details


    // Insert InvoiceBilling 
    public int Bizconnect_InsertExportDetails()
    {
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertExportDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@Buyername", BuyerName);
                da.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
                da.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
                da.SelectCommand.Parameters.AddWithValue("@BuyerCountry", Country);
                da.SelectCommand.Parameters.AddWithValue("@PoNumber", PoNumber);
                da.SelectCommand.Parameters.AddWithValue("@PoDate", PoDate);
                da.SelectCommand.Parameters.AddWithValue("@ProductDesc", ProductDesc);
                da.SelectCommand.Parameters.AddWithValue("@UOM", UOM);
                da.SelectCommand.Parameters.AddWithValue("@CreditTerms", CreditTerms);
                da.SelectCommand.Parameters.AddWithValue("@Paymentterms", ModeofPayment);
                da.SelectCommand.Parameters.AddWithValue("@Quantity", Quantity);
                da.SelectCommand.Parameters.AddWithValue("@Currency", Currency);
                da.SelectCommand.Parameters.AddWithValue("@POValue", BasicValue);
                da.SelectCommand.Parameters.AddWithValue("@ModeofShipment", ModeofShipment);
                da.SelectCommand.Parameters.AddWithValue("@Portofloading", Portofloading);
                da.SelectCommand.Parameters.AddWithValue("@Portofdelivery", Portofdischarge);
                da.SelectCommand.Parameters.AddWithValue("@Internalworksorder", Internalworksorder);

                da.SelectCommand.Parameters.AddWithValue("@IncoTerms", Incoterms);
                da.SelectCommand.Parameters.AddWithValue("@Nominatepickup", Nominatepickup);
                da.SelectCommand.Parameters.AddWithValue("@XWKSCostofinlandtransport", XWKSCostofinlandtransport);
                da.SelectCommand.Parameters.AddWithValue("@XWKSOceanfreight", XWKSOceanfreight);
                da.SelectCommand.Parameters.AddWithValue("@XWKSCutomduty", XWKSCutomduty);
                da.SelectCommand.Parameters.AddWithValue("@XWKSLocaltransportcost", XWKSLocaltransportcost);
                da.SelectCommand.Parameters.AddWithValue("@XWKSInsurance", XWKSInsurance);
                da.SelectCommand.Parameters.AddWithValue("@XWKSLandedcost", XWKSLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@FOBFreight", FOBFreight);
                da.SelectCommand.Parameters.AddWithValue("@FOBInsurance", FOBInsurance);
                da.SelectCommand.Parameters.AddWithValue("@FOBCustomduty", FOBCustomduty);
                da.SelectCommand.Parameters.AddWithValue("@FOBLocaltransport", FOBLocaltransport);
                da.SelectCommand.Parameters.AddWithValue("@FOBLandedcost", FOBLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@CandFInsurance", CandFInsurance);
                da.SelectCommand.Parameters.AddWithValue("@CandFCustomduty", CandFCustomduty);
                da.SelectCommand.Parameters.AddWithValue("@CandFLocaltransport", CandFLocaltransport);
                da.SelectCommand.Parameters.AddWithValue("@CandFLandedcost", CandFLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@CIFCustomduty", CIFCustomduty);
                da.SelectCommand.Parameters.AddWithValue("@CIFLocaltransport", CIFLocaltransport);
                da.SelectCommand.Parameters.AddWithValue("@CIFLandedcost", CIFLandedcost);
                da.SelectCommand.Parameters.AddWithValue("@FileName", FileName);
                da.SelectCommand.Parameters.AddWithValue("@ScanCopy", ScanCopy);
                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }



    public DataTable Bizconnect_LoadExportPoNumber()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select ExportID  ,PoNo   from Bizconnect_ExportDetails order by ExportID desc", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    public DataTable Bizconnect_LoadExportPODetailsByPoNo()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_LoadExportPODetailsByPoNo", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@ExportID", ExportID);
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }



    // Update Bizconnect_UpdateOrdermanagementInvoiceDetails 
    public int Bizconnect_UpdateExportPreShipmentDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateExportPreShipmentDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@DeliveryDate", DeliveryDate);
                da.SelectCommand.Parameters.AddWithValue("@ThirdpartyInspectionDate", ThirdpartyInspectionDate);
                da.SelectCommand.Parameters.AddWithValue("@StuffingDate", StuffingDate);
                da.SelectCommand.Parameters.AddWithValue("@CHAName", CHAName);
                da.SelectCommand.Parameters.AddWithValue("@FreightForwardedName", FreightForwardedName);
                da.SelectCommand.Parameters.AddWithValue("@VehicleNo", VehicleNo);
                da.SelectCommand.Parameters.AddWithValue("@LOTsize", LOTsize);
                da.SelectCommand.Parameters.AddWithValue("@VesselName", VesselName);
                da.SelectCommand.Parameters.AddWithValue("@ETD", ETD);
                da.SelectCommand.Parameters.AddWithValue("@ETA", ETA);
                da.SelectCommand.Parameters.AddWithValue("@PreShipmentInvoiceNo", PreShipmentInvoiceNo);
                da.SelectCommand.Parameters.AddWithValue("@PreShipmentInvoiceDate", PreShipmentInvoiceDate);
                da.SelectCommand.Parameters.AddWithValue("@InvoiceAmount", InvoiceAmount);
                da.SelectCommand.Parameters.AddWithValue("@Netweight", NetWeight);
                da.SelectCommand.Parameters.AddWithValue("@ETDDetailToCustomerOn", ETDDetailToCustomerOn);
                da.SelectCommand.Parameters.AddWithValue("@PReShipmentDocSentToCHAOn", PReShipmentDocSentToCHAOn);
                da.SelectCommand.Parameters.AddWithValue("@ShippingBillNo", ShippingBillNo);
                da.SelectCommand.Parameters.AddWithValue("@ShippingBillDate", ShippingBillDate);
                da.SelectCommand.Parameters.AddWithValue("@Scheme", Scheme);
                da.SelectCommand.Parameters.AddWithValue("@CargoHandedOverToLinerOn", CargoHandedOverToLinerOn);
                da.SelectCommand.Parameters.AddWithValue("@CargoOnBoard", CargoOnBoard);
                da.SelectCommand.Parameters.AddWithValue("@ActualETD", ActualETD);
                da.SelectCommand.Parameters.AddWithValue("@COOorGSPAppliedOn", COOorGSPAppliedOn);
                da.SelectCommand.Parameters.AddWithValue("@DocSubmittedToConsulate", DocSubmittedToConsulate);
                da.SelectCommand.Parameters.AddWithValue("@ExportID", ExportID);

                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }

    public DataTable Bizconnect_LoadPreshipmentdetailsByPONo()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_LoadPreshipmentdetailsByPONo", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@ExportID", ExportID);
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }


    // Update Bizconnect_UpdateOrdermanagementInvoiceDetails 
    public int Bizconnect_UpdateExportPostShipmentDetails()
    {
        int res = 0;
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_UpdateExportPostShipmentDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@OriginalShippingDocReceivedOn", OriginalShippingDocReceivedOn);
                da.SelectCommand.Parameters.AddWithValue("@NNSentToCustomerOn", NNSentToCustomerOn);
                da.SelectCommand.Parameters.AddWithValue("@CommercialDocLodgedwithBankOn", CommercialDocLodgedwithBankOn);
                da.SelectCommand.Parameters.AddWithValue("@LodmentRefNo", LodmentRefNo);
                da.SelectCommand.Parameters.AddWithValue("@LodmentRefDate", LodmentRefDate);
                da.SelectCommand.Parameters.AddWithValue("@PaymentdueDate", PaymentdueDate);
                da.SelectCommand.Parameters.AddWithValue("@TTRemittanceNo", TTRemittanceNo);
                da.SelectCommand.Parameters.AddWithValue("@TTRemittanceDate", TTRemittanceDate);
                da.SelectCommand.Parameters.AddWithValue("@DisbursementAdviseSentToBankOn", DisbursementAdviseSentToBankOn);
                da.SelectCommand.Parameters.AddWithValue("@TransactionAdviseDate", TransactionAdviseDate);
                da.SelectCommand.Parameters.AddWithValue("@BRCUploadedOn", BRCUploadedOn);
                da.SelectCommand.Parameters.AddWithValue("@DutyDrawbackReceivedOn", DutyDrawbackReceivedOn);
                da.SelectCommand.Parameters.AddWithValue("@ProofOfExportDocReceivedOn", ProofOfExportDocReceivedOn);
                da.SelectCommand.Parameters.AddWithValue("@ProofOfExportDocSentToFactory", ProofOfExportDocSentToFactory);
                da.SelectCommand.Parameters.AddWithValue("@ProofOfExportDocSentToLicenceDept", ProofOfExportDocSentToLicenceDept);
                da.SelectCommand.Parameters.AddWithValue("@CHAbillno", CHAbillno);
                da.SelectCommand.Parameters.AddWithValue("@CHAbilldate", CHAbilldate);
                da.SelectCommand.Parameters.AddWithValue("@CHAbillamount", CHAbillamount);
                da.SelectCommand.Parameters.AddWithValue("@Freightamount", Freightamount);
                da.SelectCommand.Parameters.AddWithValue("@Dentention", Detention);
                da.SelectCommand.Parameters.AddWithValue("@WHcharges", WHcharges);

                da.SelectCommand.Parameters.AddWithValue("@ExportID", ExportID);

                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                res = 1;
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }


    public DataTable Bizconnect_LoadExportPostshipmentdetailsbyPONo()
    {
        DataTable dt_Product = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_LoadExportPostshipmentdetailsbyPONo", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@ExportID", ExportID);
                da.Fill(dt_Product);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Product;
        }
    }



    // Update Bizconnect_UpdateOrdermanagementInvoiceDetails 
    public int Bizconnect_Insert_ImportExportRegistration()
    {
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_Insert_ImportExportRegistration", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@CompanyName", CompanyName);
                da.SelectCommand.Parameters.AddWithValue("@Address", Address);
                da.SelectCommand.Parameters.AddWithValue("@ContactPerson", ContactPerson);
                da.SelectCommand.Parameters.AddWithValue("@MarketingHead", MarketingHead);
                da.SelectCommand.Parameters.AddWithValue("@OperationHead", OperationHead);
                da.SelectCommand.Parameters.AddWithValue("@MobileNo", MobileNo);
                da.SelectCommand.Parameters.AddWithValue("@BoardLine", BoardLine);
                da.SelectCommand.Parameters.AddWithValue("@EmailID", EmailID);
                da.SelectCommand.Parameters.AddWithValue("@Password", Password);
                da.SelectCommand.Parameters.AddWithValue("@LocationofBranches", LocationofBranches);
                da.SelectCommand.Parameters.AddWithValue("@CHALicence", CHALicence);
                da.SelectCommand.Parameters.AddWithValue("@CHALicenceNo", CHALicenceNo);
                da.SelectCommand.Parameters.AddWithValue("@IATAMember", IATAMember);
                da.SelectCommand.Parameters.AddWithValue("@IssueAWB", IssueAWB);
                da.SelectCommand.Parameters.AddWithValue("@CompetitiveSector", CompetitiveSector);
                da.SelectCommand.Parameters.AddWithValue("@consolidationServices", consolidationServices);
                da.SelectCommand.Parameters.AddWithValue("@consolidationServicesSector", consolidationServicesSector);
                da.SelectCommand.Parameters.AddWithValue("@ProductsSpecialisedIn", ProductsSpecialisedIn);
                da.SelectCommand.Parameters.AddWithValue("@handlingAIRAndSeaClearance", handlingAIRAndSeaClearance);
                da.SelectCommand.Parameters.AddWithValue("@SpecialisedServices", SpecialisedServices);
                da.SelectCommand.Parameters.AddWithValue("@RegistrationType", RegistrationType);

                da.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
                da.SelectCommand.ExecuteNonQuery();
                ResultID = Convert.ToInt32(da.SelectCommand.Parameters["@Result"].Value);
            }
            catch (Exception e)
            {
                ResultID = 0;
            }
            finally
            {

            }
            return ResultID;
        }
    }

}