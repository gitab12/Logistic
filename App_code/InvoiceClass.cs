
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

/// <summary>
/// Summary description for InvoiceClass
/// </summary>
public class InvoiceClass
{

    // Invoice 
    private int _InvoiceID;
    private DateTime _Dated;
    private string _Domain;
    private string _OtherReferences;
    private string _InvoiceRemarks;
    private string _BuyerorTo;
    private string _BuyerorToDetails;
    private string _Particulars;
    private int _QuantityNoofTrucks;
    private float _Rate;
    private float _Amount;
    private string _BillNo;

    private float _Total;
    private float _Tax12percent;
    private float _Tax2percent;
    private float _Tax1percent;
    private float _GrandTotal;
    
    private float _ServiceTax;
    private float _EducationCess;
    private float _HigherEducationCess;
    private string _AmountInwords;
        private int _InvoiceBillID;


    // Invoice

    public int InvoiceID
    {
        get { return _InvoiceID; }
        set { _InvoiceID = value; }
    }

    public DateTime Dated
    {
        get { return _Dated; }
        set { _Dated = value; }
    }
    public string Domain
    {
        get { return _Domain; }
        set { _Domain = value; }
    }

    public string OtherReferences
    {
        get { return _OtherReferences; }
        set { _OtherReferences = value; }
    }
    public string InvoiceRemarks
    {
        get { return _InvoiceRemarks; }
        set { _InvoiceRemarks = value; }
    }
    public string BuyerorTo
    {
        get { return _BuyerorTo; }
        set { _BuyerorTo = value; }
    }
    public string BuyerorToDetails
    {
        get { return _BuyerorToDetails; }
        set { _BuyerorToDetails = value; }
    }
    public string Particulars
    {
        get { return _Particulars; }
        set { _Particulars = value; }
    }
    public int QuantityNoofTrucks
    {
        get { return _QuantityNoofTrucks; }
        set { _QuantityNoofTrucks = value; }
    }
    public float Rate
    {
        get { return _Rate; }
        set { _Rate = value; }
    }
    public float Amount
    {
        get { return _Amount; }
        set { _Amount = value; }
    }


    public string BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }
    
    public float Total
    {
        get { return _Total ; }
        set {  _Total = value; }
    }
     public float Tax12percent
    {
        get {  return _Tax12percent  ; }
        set {  _Tax12percent = value; }
    }
     public float Tax2percent
    {
        get { return _Tax2percent ; }
        set { _Tax2percent  = value; }
    }
     public float Tax1percent
    {
        get { return _Tax1percent ; }
        set {  _Tax1percent = value; }
    }
     public float GrandTotal
    {
        get { return _GrandTotal ; }
        set {  _GrandTotal = value; }
    }


 public float ServiceTax
    {
        get { return _ServiceTax ; }
        set {  _ServiceTax = value; }
    }
     public float EducationCess
    {
        get { return _EducationCess ; }
        set {  _EducationCess = value; }
    }
     public float HigherEducationCess
    {
        get { return _HigherEducationCess ; }
        set {  _HigherEducationCess = value; }
    }

public string AmountInwords
     {
         get { return _AmountInwords;}
         set { _AmountInwords = value;}
     }
     public int InvoiceBillID
     {
         get { return _InvoiceBillID ; }
         set { _InvoiceBillID  = value; }
     }

     public int Status
     {
         get;
         set;
     }

    SqlConnection obj_conn = new SqlConnection();
    int InvoiceIDBill = 0, InvID = 0;

	public InvoiceClass()
	{
        string conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        obj_conn.ConnectionString = conn;
        obj_conn.Open();
	}



    // get invoiceId 
    public DataSet Get_InvoiceID()
    {
        DataSet ds_InvoiceID = new DataSet();
        using (SqlCommand comm1 = new SqlCommand("select max (InvoiceID)+1 from InvoiceBilling  ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(ds_InvoiceID);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return ds_InvoiceID;
        }
    }

    // Insert InvoiceBilling 
    public int Insert_InvoiceBilling()
    {
        using (SqlCommand comm1 = new SqlCommand("Insert_InvoiceBilling ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
				da.SelectCommand.Parameters.AddWithValue("@InvoiceID",InvoiceID);
                da.SelectCommand.Parameters.AddWithValue("@BillNo ", BillNo);
                da.SelectCommand.Parameters.AddWithValue("@Dated ", Dated);
                da.SelectCommand.Parameters.AddWithValue("@Domain", Domain);
                da.SelectCommand.Parameters.AddWithValue("@OtherReferences ", OtherReferences);
                da.SelectCommand.Parameters.AddWithValue("@Remarks ", InvoiceRemarks);
                da.SelectCommand.Parameters.AddWithValue("@BuyerorTo", BuyerorTo);
                da.SelectCommand.Parameters.AddWithValue("@BuyerOrToDetails ", BuyerorToDetails);
                da.SelectCommand.Parameters.AddWithValue("@Status", Status);
                
                da.SelectCommand.ExecuteNonQuery();
                InvID = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return InvID;
        }
    }


    // Insert InvoiceBillin_Details 
    public int Insert_InvoiceBilling_Details()
    {
        using (SqlCommand comm1 = new SqlCommand("Insert_InvoiceBilling_Details", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                da.SelectCommand.Parameters.AddWithValue("@Particulars", Particulars);
                da.SelectCommand.Parameters.AddWithValue("@QuantityOrNoOfTrucks", QuantityNoofTrucks);
                da.SelectCommand.Parameters.AddWithValue("@Rate", Rate);
                da.SelectCommand.Parameters.AddWithValue("@Amount", Amount);
                da.SelectCommand.Parameters.AddWithValue("@Total", Total);
                da.SelectCommand.Parameters.AddWithValue("@Tax12Per", Convert.ToSingle(Tax12percent));
                da.SelectCommand.Parameters.AddWithValue("@Tax2per", Tax2percent);
                da.SelectCommand.Parameters.AddWithValue("@Tax1per",Tax1percent);
                da.SelectCommand.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                da.SelectCommand.Parameters.AddWithValue("@ServiceTax",ServiceTax);
                da.SelectCommand.Parameters.AddWithValue("@EducationCess", EducationCess);
                da.SelectCommand.Parameters.AddWithValue("@HigherEducationCess",HigherEducationCess);
                da.SelectCommand.Parameters.AddWithValue("@AmountInWords",AmountInwords);
                da.SelectCommand.ExecuteNonQuery();
                InvoiceIDBill = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return InvoiceIDBill;
        }
    }

    // get invoiceBilling for search  options 
    public DataSet Search_InvoiceBilling(int InvoiceID )
    {
        DataSet ds_InvBilling = new DataSet();
        using (SqlCommand comm1 = new SqlCommand("Search_InvoiceBilling", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                da.Fill(ds_InvBilling);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return ds_InvBilling;
        }
    }

    // get invoiceBillingDetails for search  options 
    public DataSet Search_InvoiceBillingDetails(int InvoiceID)
    {
        DataSet ds_InvBillingDetails = new DataSet();
        using (SqlCommand comm1 = new SqlCommand("Search_InvoiceBillingDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                da.Fill(ds_InvBillingDetails);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return ds_InvBillingDetails;
        }
    }

 public DataTable  Bizconnect_Get_OptDispatchplanDetails()
    {
        DataTable dt_Dispatch = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select GTNNo ,OrderNo ,InvoiceNo , convert (varchar(20),ActualGIDate,106) as ActualGIDate,SupplierPlant ,PlantName ,ReceivingPlantCode ,ReceivingPlantName,  MaterialCode ,MaterialDescription ,DispatchQuantity ,DispatchUnit ,round( Weight,2) as  Weight ,TruckNo,Transporter from Bizconnect_OptDispatchPlan", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_Dispatch);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_Dispatch;
        }
    }

    public DataTable Bizconnect_Get_GTNNo(string FromLocation)
    {
        DataTable dt_GTNNo = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select distinct GTNNo  from Bizconnect_OptDispatchPlan where PlantName ='"+FromLocation+"' order by GTNNo", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_GTNNo);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_GTNNo;
        }
    }


    public DataTable Bizconnect_Search_OptDispatchplanDetails(string GTNNo)
    {
        DataTable dt_GTNNo = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select GTNNo ,OrderNo ,InvoiceNo , convert (varchar(20),ActualGIDate,106) as ActualGIDate,SupplierPlant ,PlantName ,ReceivingPlantCode ,ReceivingPlantName,  MaterialCode ,MaterialDescription ,DispatchQuantity ,DispatchUnit ,round( Weight,2)*DispatchQuantity/1000 as  Weight,TruckNo,Transporter  from Bizconnect_OptDispatchPlan where GTNNo ='"+GTNNo +"'", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt_GTNNo);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt_GTNNo;
        }
    }

public DataSet  Bizconnect_Get_DespatchOptimizDetails(string GTNNo)
    {
        DataSet ds_Despopt = new DataSet();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_Search_OptDespatchdetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
              da.SelectCommand.CommandType = CommandType.StoredProcedure;
            da.SelectCommand.Parameters.AddWithValue("@GTNNo", GTNNo);
            try
            {
                da.Fill(ds_Despopt);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return ds_Despopt;
        }
    }

public DataTable Bizconnect_Get_OptimizationLBH(string MaterialCode)
{
    DataTable dt_LBH = new DataTable();
    using (SqlCommand comm1 = new SqlCommand("select  distinct optdis .MaterialCode , optmas.Length ,optmas .Breadth  ,optmas .Height   from Bizconnect_Optimization_Master optmas inner join Bizconnect_OptDispatchPlan optdis on optmas .ParentCode =optdis.MaterialCode where optdis.MaterialCode ='" + MaterialCode + "'", obj_conn))
    {
        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.Text;
        try
        {
            da.Fill(dt_LBH);
        }
        catch (Exception e)
        {
        }
        finally
        {

        }
        return dt_LBH;
    }
}

public DataTable Bizconnect_Get_FromLocation()
{
    DataTable dt_FromLoc = new DataTable();
    using (SqlCommand comm1 = new SqlCommand("select distinct PlantName   from Bizconnect_OptDispatchPlan order by PlantName ", obj_conn))
    {
        SqlDataAdapter da = new SqlDataAdapter(comm1);
        da.SelectCommand.CommandType = CommandType.Text;
        try
        {
            da.Fill(dt_FromLoc);
        }
        catch (Exception e)
        {
        }
        finally
        {

        }
        return dt_FromLoc;
    }
}


public int Update_InvoiceBilling()
    {
        using (SqlCommand comm1 = new SqlCommand("Update_InvoiceBilling ", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                da.SelectCommand.Parameters.AddWithValue("@Domain", Domain);
                da.SelectCommand.Parameters.AddWithValue("@OtherReference", OtherReferences);
                da.SelectCommand.Parameters.AddWithValue("@Remarks", InvoiceRemarks);
                da.SelectCommand.Parameters.AddWithValue("@BuyerorTo", BuyerorTo);
                da.SelectCommand.Parameters.AddWithValue("@BuyerorToDetails", BuyerorToDetails);
                da.SelectCommand.Parameters.AddWithValue("@Status", Status);

                da.SelectCommand.ExecuteNonQuery();
                InvID = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return InvID;
        }
    }


    public int Update_InvoiceBilling_Details()
    {
        using (SqlCommand comm1 = new SqlCommand("Update_InvoiceBilling_Details", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceBillID", InvoiceBillID);
                da.SelectCommand.Parameters.AddWithValue("@Particulars", Particulars);
                da.SelectCommand.Parameters.AddWithValue("@QuantityOrNoOfTrucks", QuantityNoofTrucks);
                da.SelectCommand.Parameters.AddWithValue("@Rate", Rate);
                da.SelectCommand.Parameters.AddWithValue("@Amount", Amount);
                da.SelectCommand.Parameters.AddWithValue("@Total", Total);
                da.SelectCommand.Parameters.AddWithValue("@Tax12Percent", Convert.ToSingle(Tax12percent));
                da.SelectCommand.Parameters.AddWithValue("@Tax2percent", Tax2percent);
                da.SelectCommand.Parameters.AddWithValue("@Tax1Percent", Tax1percent);
                da.SelectCommand.Parameters.AddWithValue("@ServiceTax", ServiceTax);
                da.SelectCommand.Parameters.AddWithValue("@EducationCess", EducationCess);
                da.SelectCommand.Parameters.AddWithValue("@HigherEducationCess", HigherEducationCess);
                da.SelectCommand.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                da.SelectCommand.Parameters.AddWithValue("@AmountInWords",AmountInwords);
                da.SelectCommand.ExecuteNonQuery();
                InvoiceIDBill = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return InvoiceIDBill;
        }
    }

    //update invoice without particulars(txt_Desc1)
    public int Update_InvoiceBilling_DetailsWithoutFirstParticulars()
    {
        using (SqlCommand comm1 = new SqlCommand("Update_InvoiceBilling_DetailsWithoutFirstParticulars", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceBillID", InvoiceBillID);
                //da.SelectCommand.Parameters.AddWithValue("@Particulars", Particulars);
                da.SelectCommand.Parameters.AddWithValue("@QuantityOrNoOfTrucks", QuantityNoofTrucks);
                da.SelectCommand.Parameters.AddWithValue("@Rate", Rate);
                da.SelectCommand.Parameters.AddWithValue("@Amount", Amount);
                da.SelectCommand.Parameters.AddWithValue("@Total", Total);
                da.SelectCommand.Parameters.AddWithValue("@Tax12Percent", Convert.ToSingle(Tax12percent));
                da.SelectCommand.Parameters.AddWithValue("@Tax2percent", Tax2percent);
                da.SelectCommand.Parameters.AddWithValue("@Tax1Percent", Tax1percent);
                da.SelectCommand.Parameters.AddWithValue("@ServiceTax", ServiceTax);
                da.SelectCommand.Parameters.AddWithValue("@EducationCess", EducationCess);
                da.SelectCommand.Parameters.AddWithValue("@HigherEducationCess", HigherEducationCess);
                da.SelectCommand.Parameters.AddWithValue("@GrandTotal", GrandTotal);
                da.SelectCommand.Parameters.AddWithValue("@AmountInWords", AmountInwords);
                da.SelectCommand.ExecuteNonQuery();
                InvoiceIDBill = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return InvoiceIDBill;
        }
    }


    public DataTable Bizconnect_InvoiceBillingReport()
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InvoiceBillingReport", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.Fill(dt);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt;
        }
    }


    public int Bizconnect_InsertInvoiceBillPaymentDetails(string PaymentMode, float AmountPaid, float AmountPayment)
    {
        using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertInvoiceBillPaymentDetails", obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                da.SelectCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                da.SelectCommand.Parameters.AddWithValue("@PaymentDate", Dated);
                da.SelectCommand.Parameters.AddWithValue("@ReceivedFrom", BuyerorToDetails);
                da.SelectCommand.Parameters.AddWithValue("@PaymentMode", PaymentMode);
                da.SelectCommand.Parameters.AddWithValue("@BillAmount", GrandTotal);
                da.SelectCommand.Parameters.AddWithValue("@AmountPaid", AmountPaid);
                da.SelectCommand.Parameters.AddWithValue("@AmountPayment", AmountPayment);
                da.SelectCommand.Parameters.AddWithValue("@Remarks", InvoiceRemarks);

                da.SelectCommand.ExecuteNonQuery();
                InvoiceIDBill = 1;
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return InvoiceIDBill;
        }
    }


    public DataTable Bizconnect_InvoiceBillPaidAmount()
    {
        DataTable dt = new DataTable();
        using (SqlCommand comm1 = new SqlCommand("select convert(varchar(20), PaymentDate,103)as PaymentDate ,ReceivedFrom ,PaymentMode ,BillAmount ,AmountPaid,AmountPayment,Remarks   from Invoice_BillPayment where InvoiceID =" + InvoiceID, obj_conn))
        {
            SqlDataAdapter da = new SqlDataAdapter(comm1);
            da.SelectCommand.CommandType = CommandType.Text;
            try
            {
                da.Fill(dt);
            }
            catch (Exception e)
            {
            }
            finally
            {

            }
            return dt;
        }
    }


}