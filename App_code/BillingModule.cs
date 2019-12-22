using System;
using System.Collections.Generic;

using System.Web;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Data.Sql;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

/// <summary>
/// Summary description for BillingModule
/// </summary>
public class BillingModule
{

private int _ClientID;
    private int _ConfirmNo;
    private string _BillNo;
    private DateTime _BillDate;
    private string _LRNumber;
    private DateTime _LRDate;
    private string _VehicleNo;
    private string _FromLocation;
    private string _ToLocation;
    private string _SubmissionAddress;
    private float _TransporterPrice;
    private float _ClientPrice;
    private float _TransLoadingDetentionCharges;
    private float _ClientLoadingDetentionCharges;
    private float _TransUnLoadingDetentionCharges;
    private float _ClientUnLoadingDetentionCharges;
    private float _TransLoadingCharges;
    private float _ClientLoadingCharges;
    private float _TransUnLoadingCharges;
    private float _ClientUnLoadingCharges;
    private float _TransoctroiCharges;
    private float _ClientoctroiCharges;
    private float _TransoDimentionDiff;
    private float _ClientDimentionDiff;
    private float _TransOtherClaimsCharges;
    private float _ClientOtherClaimsCharges;
    private float _TransInsurance;
    private float _ClientInsurance;
    private float _TransDamages;
    private float _ClientDamages;
    private float _TransShortages;
    private float _ClientShortages;
    private float _TransOtherCharges;
    private float _ClientOtherCharges;
    private float _TransNetValue;
    private float _ClientNetValue;
    private string _AARMSRemarks;
    private string _CheckedBy;

    public int ClientID
    {
        get { return _ClientID; }
        set { _ClientID = value; }
    }
    public int ConfirmNo
    {
        get { return _ConfirmNo; }
        set { _ConfirmNo = value; }
    }
    public string BillNo
    {
        get { return _BillNo; }
        set { _BillNo = value; }
    }

    public DateTime BillDate
    {
        get { return _BillDate; }
        set { _BillDate = value; }
    }
    public string LRNumber
    {
        get { return _LRNumber; }
        set { _LRNumber = value; }
    }
    public DateTime LRDate
    {
        get { return _LRDate; }
        set { _LRDate = value; }
    }
    public string VehicleNo
    {
        get { return _VehicleNo; }
        set { _VehicleNo = value; }
    }
    public string FromLocation
    {
        get { return _FromLocation; }
        set { _FromLocation = value; }
    }
    public string ToLocation
    {
        get { return _ToLocation; }
        set { _ToLocation = value; }
    }
    public string SubmissionAddress
    {
        get { return _SubmissionAddress; }
        set { _SubmissionAddress = value; }
    }
    public float TransporterPrice
    {
        get { return _TransporterPrice; }
        set { _TransporterPrice = value; }
    }
    public float ClientPrice
    {
        get { return _ClientPrice; }
        set { _ClientPrice = value; }
    }
    public float TransLoadingDetentionCharges
    {
        get { return _TransLoadingDetentionCharges; }
        set { _TransLoadingDetentionCharges = value; }
    }
    public float ClientLoadingDetentionCharges
    {
        get { return _ClientLoadingDetentionCharges; }
        set { _ClientLoadingDetentionCharges = value; }
    }
    public float TransUnLoadingDetentionCharges
    {
        get { return _TransUnLoadingDetentionCharges; }
        set { _TransUnLoadingDetentionCharges = value; }
    }
    public float ClientUnLoadingDetentionCharges
    {
        get { return _ClientUnLoadingDetentionCharges; }
        set { _ClientUnLoadingDetentionCharges = value; }
    }
    public float TransLoadingCharges
    {
        get { return _TransLoadingCharges; }
        set { _TransLoadingCharges = value; }
    }
    public float ClientLoadingCharges
    {
        get { return _ClientLoadingCharges; }
        set { _ClientLoadingCharges = value; }
    }
    public float TransUnLoadingCharges
    {
        get { return _TransUnLoadingCharges; }
        set { _TransUnLoadingCharges = value; }
    }
    public float ClientUnLoadingCharges
    {
        get { return _ClientUnLoadingCharges; }
        set { _ClientUnLoadingCharges = value; }
    }
    public float TransoctroiCharges
    {
        get { return _TransoctroiCharges; }
        set { _TransoctroiCharges = value; }
    }
    public float ClientoctroiCharges
    {
        get { return _ClientoctroiCharges; }
        set { _ClientoctroiCharges = value; }
    }
    public float TransoDimentionDiff
    {
        get { return _TransoDimentionDiff; }
        set { _TransoDimentionDiff = value; }
    }
    public float ClientDimentionDiff
    {
        get { return _ClientDimentionDiff; }
        set { _ClientDimentionDiff = value; }
    }
    public float TransOtherClaimsCharges
    {
        get { return _TransOtherClaimsCharges; }
        set { _TransOtherClaimsCharges = value; }
    }
    public float ClientOtherClaimsCharges
    {
        get { return _ClientOtherClaimsCharges; }
        set { _ClientOtherClaimsCharges = value; }
    }
    public float TransInsurance
    {
        get { return _TransInsurance; }
        set { _TransInsurance = value; }
    }
    public float ClientInsurance
    {
        get { return _ClientInsurance; }
        set { _ClientInsurance = value; }
    }
    public float TransDamages
    {
        get { return _TransDamages; }
        set { _TransDamages = value; }
    }
    public float ClientDamages
    {
        get { return _ClientDamages; }
        set { _ClientDamages = value; }
    }
    public float TransShortages
    {
        get { return _TransShortages; }
        set { _TransShortages = value; }
    }
    public float ClientShortages
    {
        get { return _ClientShortages; }
        set { _ClientShortages = value; }
    }
    public float TransOtherCharges
    {
        get { return _TransOtherCharges; }
        set { _TransOtherCharges = value; }
    }
    public float ClientOtherCharges
    {
        get { return _ClientOtherCharges; }
        set { _ClientOtherCharges = value; }
    }
    public float TransNetValue
    {
        get { return _TransNetValue; }
        set { _TransNetValue = value; }
    }
    public float ClientNetValue
    {
        get { return _ClientNetValue; }
        set { _ClientNetValue = value; }
    }

    public string AARMSRemarks
    {
        get { return _AARMSRemarks; }
        set { _AARMSRemarks = value; }
    }
    public string CheckedBy
    {
        get { return _CheckedBy; }
        set { _CheckedBy = value; }
    }

    public int BillMatchFlag
    {
        get;
        set;
    }

    public float IncreasePrice
    {
        get;
        set;
    }

    public float Length
    {
        get;
        set;
    }


    public float Width
    {
        get;
        set;
    }


    public float Height
    {
        get;
        set;
    }


    public float TotalWeight
    {
        get;
        set;
    }


    public int CNNo
    {
        get;
        set;
    }


    string connStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    string Bizconn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    public BillingModule()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //Retrieving all Post Type
    public DataSet Get_ConfirmNumber(int Clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Get_ConfirmNumberForClient", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", Clientid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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


    //Get_BillDetailsForPayment
    public DataSet Get_BillDetailsForPayment(int ConfirmNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Get_BillDetailsForPayment", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ConfirmNo", ConfirmNo);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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
    //Insert_BillPayment
    public Int32 Insert_BillPayment(int BillID, string BillNo, DateTime BillDate, int ConfirmNo,int ModeofPayment,string ChequeNo,DateTime ChequeDate,double PaymentAmount,string Remarks)
    {
        int resp = 0;
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Insert_BillPayment", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@BillID", BillID);
                ada.SelectCommand.Parameters.AddWithValue("@BillNo", BillNo);
                ada.SelectCommand.Parameters.AddWithValue("@BillDate", BillDate);
                ada.SelectCommand.Parameters.AddWithValue("@ConfirmNo", ConfirmNo);
                ada.SelectCommand.Parameters.AddWithValue("@ModeofPayment", ModeofPayment);
                ada.SelectCommand.Parameters.AddWithValue("@ChequeNo", ChequeNo);
                ada.SelectCommand.Parameters.AddWithValue("@ChequeDate", ChequeDate);
                ada.SelectCommand.Parameters.AddWithValue("@PaymentAmount", PaymentAmount);
                ada.SelectCommand.Parameters.AddWithValue("@Remarks", Remarks);
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


    //Bizconnect_ViewDetail
    public DataSet Bizconnect_ViewDetail()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            conn.Open();
            using (SqlCommand comm = new SqlCommand("Bizconnect_ViewDetail", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_CNNo", CNNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@ConfirmationNo", ConfirmNo);
                
                try
                {
                    
                    ada.Fill(ds, "confirmno");
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



    //Bizconnect_ViewDetailReport
    public DataSet Bizconnect_ViewDetailReport(int ConfirmNo, int ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_ViewDetailReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                //ada.SelectCommand.Parameters.AddWithValue("@obj_CNNo", CNNo);
                ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
                ada.SelectCommand.Parameters.AddWithValue("@ConfirmNo", ConfirmNo);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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

//Bill Status Report

    public DataSet Bizconnect_BillstatusReport(int Clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_BillstatusReport", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", Clientid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "Bizconnect_BillstatusReport");
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


    

  public DataSet LoadConfirmNo(int ClientID)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_GetConfirmNo", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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
    
    
     //Get BillNumber for BillMatching
    public DataSet Get_BillNoForClient(int Clientid)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Get_BillNoForClient", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", Clientid);
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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



    //20_dec_2018 
    #region newcodeupdate
    public DataSet Get_BillDetailsForBillMatching_new(string obj_BillNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("SP_Get_BillDetailsForBillMatching_new", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                //ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_BillNo", obj_BillNo);
                ada.SelectCommand.CommandTimeout = 30000;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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
    #endregion

    //Get_BillDetailsForBillMatching
    public DataSet Get_BillDetailsForBillMatching(string ProjectNo, string obj_BillNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Get_BillDetailsForBillMatching", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
                ada.SelectCommand.Parameters.AddWithValue("@obj_BillNo", obj_BillNo);
                ada.SelectCommand.CommandTimeout = 30000;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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
//Bizconnect_GetCollectionNoteDetails
    public DataSet Bizconnect_GetCollectionNoteDetails(int obj_CofirmNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm = new SqlCommand("Bizconnect_GetCollectionNoteDetails", conn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@obj_ConfirmNo", obj_CofirmNo);
                ada.SelectCommand.CommandTimeout = 30000;
                try
                {
                    conn.Open();
                    ada.Fill(ds, "confirmno");
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
    
public int Bizconnect_InsertBillValidation()
    {
        int res = 0;
        using (SqlConnection conn = new SqlConnection(Bizconn))
        {
            using (SqlCommand comm1 = new SqlCommand("Bizconnect_InsertBillValidation", conn))
            {
                SqlDataAdapter da = new SqlDataAdapter(comm1);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                try
                {
                    conn.Open();
                    da.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
                    da.SelectCommand.Parameters.AddWithValue("@ConfirmNo", ConfirmNo);
                    da.SelectCommand.Parameters.AddWithValue("@BillNo", BillNo);
                    da.SelectCommand.Parameters.AddWithValue("@BillDate", BillDate);
                    da.SelectCommand.Parameters.AddWithValue("@LRNumber", LRNumber);
                    da.SelectCommand.Parameters.AddWithValue("@LRDate", LRDate);
                    da.SelectCommand.Parameters.AddWithValue("@VehicleNo", VehicleNo);
                    da.SelectCommand.Parameters.AddWithValue("@FromLocation", FromLocation);
                    da.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
                    da.SelectCommand.Parameters.AddWithValue("@SubmissionAddress", SubmissionAddress);
                    da.SelectCommand.Parameters.AddWithValue("@TransporterPrice", TransporterPrice);
                    da.SelectCommand.Parameters.AddWithValue("@ClientPrice", ClientPrice);
                    da.SelectCommand.Parameters.AddWithValue("@TransLoadingDetentionCharges", TransUnLoadingDetentionCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientLoadingDetentionCharges", ClientLoadingDetentionCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransUnLoadingDetentionCharges", TransUnLoadingDetentionCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientUnLoadingDetentionCharges", ClientUnLoadingDetentionCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransLoadingCharges", TransLoadingCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientLoadingCharges", ClientLoadingCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransUnLoadingCharges", TransUnLoadingCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientUnLoadingCharges", ClientUnLoadingCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransoctroiCharges", TransoctroiCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientoctroiCharges", ClientoctroiCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransoDimentionDiff", TransoDimentionDiff);
                    da.SelectCommand.Parameters.AddWithValue("@ClientDimentionDiff", ClientDimentionDiff);
                    da.SelectCommand.Parameters.AddWithValue("@TransOtherClaimsCharges", TransOtherClaimsCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientOtherClaimsCharges", ClientOtherClaimsCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransInsurance", TransInsurance);
                    da.SelectCommand.Parameters.AddWithValue("@ClientInsurance", ClientInsurance);
                    da.SelectCommand.Parameters.AddWithValue("@TransDamages", TransDamages);
                    da.SelectCommand.Parameters.AddWithValue("@ClientDamages", ClientDamages);
                    da.SelectCommand.Parameters.AddWithValue("@TransShortages", TransShortages);
                    da.SelectCommand.Parameters.AddWithValue("@ClientShortages", ClientShortages);
                    da.SelectCommand.Parameters.AddWithValue("@TransOtherCharges", TransOtherCharges);
                    da.SelectCommand.Parameters.AddWithValue("@ClientOtherCharges", ClientOtherCharges);
                    da.SelectCommand.Parameters.AddWithValue("@TransNetValue", TransNetValue);
                    da.SelectCommand.Parameters.AddWithValue("@ClientNetValue", ClientNetValue);
                    da.SelectCommand.Parameters.AddWithValue("@AARMSRemarks", AARMSRemarks);
                    da.SelectCommand.Parameters.AddWithValue("@CheckedBy", CheckedBy);
                    da.SelectCommand.Parameters.AddWithValue("@BillMatchFlag", BillMatchFlag);
                    da.SelectCommand.Parameters.AddWithValue("@IncreasePrice", IncreasePrice);

                    da.SelectCommand.Parameters.AddWithValue("@Length", Length);
                    da.SelectCommand.Parameters.AddWithValue("@Width", Width);
                    da.SelectCommand.Parameters.AddWithValue("@Height", Height);
                    da.SelectCommand.Parameters.AddWithValue("@TotalWeight", TotalWeight);

                    da.SelectCommand.ExecuteNonQuery();
                    res = 1;
                }
                catch (Exception e)
                {
                    res = 0;
                }
                finally
                {
                    conn.Close();
                }
                return res;
            }
        }
    }

public DataTable Bizconnect_AarmsBillingStatusReport()
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_AarmsBillingStatusReport", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
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

public DataTable Bizconnect_GetBillAmount(int InvoiceID)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select GrandTotal  from InvoiceBilling_Details where InvoiceID =" + InvoiceID, conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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

//Get ProjectName for BillApproval
public DataTable Get_BizconnectProjectName(int Clientid ,int BillMatchFlag)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select distinct left (cn.ProjectName,9) as ProjectName  from bizconnect_TripAcceptanceDetails TA  inner join BizConnect_TripAssign t on t.TripAssignID=ta.TripAssignID   inner join CollectionNote cn on  cn.CollectionNoteID=t.IndentID    inner join  Bizconnect_BillValidation bv on bv.ConfirmNo =ta.AcceptanceID  where ta.ClientID=" + Clientid + " and  bv.BillMatchFlag=" + BillMatchFlag, conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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


//Get ProjectNo for BillApproval
public DataTable Get_BizconnectProjectNo(int Clientid, string ProjectName,int BillMatchFlag)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select distinct  cn.ProjectNo   from bizconnect_TripAcceptanceDetails TA  inner join BizConnect_TripAssign t on t.TripAssignID=ta.TripAssignID   inner join CollectionNote cn on  cn.CollectionNoteID=t.IndentID    inner join  Bizconnect_BillValidation bv on bv.ConfirmNo =ta.AcceptanceID  where ta.ClientID=" + Clientid + " and  ProjectName like'%" + ProjectName + "%' and bv.BillMatchFlag="+BillMatchFlag+" order by cn.ProjectNo ", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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


//Get BillNumber by ProjectName and ProjectNos for BillMatching
public DataTable Bizconnect_GetBillNoByProjecNameAndNo(int Clientid, string ProjectName, string ProjectNo)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_GetBillNoByProjecNameAndNo", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ClientID", Clientid);
            ada.SelectCommand.Parameters.AddWithValue("@ProjectName", ProjectName);
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
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


//Get BillClient for Aarms billing
public DataTable Bizconnect_GetAarmsBillClient()
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_GetAarmsBillClient", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
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

//Bizconnect_SearchAarmsBillingStatusReportByClient
public DataTable Bizconnect_SearchAarmsBillingStatusReportByClient(string ClientName)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_SearchAarmsBillingStatusReportByClient", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.Add("@Client", ClientName);
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


//Bizconnect_CheckBilldetailsExistsor not
public DataTable Bizconnect_CheckBilldetailsExistsorNot(int ClientID, int ConfirmNo)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select BillValidationNo  from  Bizconnect_BillValidation where ClientID =" + ClientID + " and ConfirmNo =" + ConfirmNo + " and BillMatchFlag=1", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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

//Get BillNumber by ProjectName and ProjectNos for Bill Approval 
public DataTable Bizconnect_GetBillNoByProjecNameAndNoForBillApproval(int Clientid, string ProjectName, string ProjectNo, int BillMathFlag)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select distinct BS.BillNo as BillNo,bv.ConfirmNo,bs.BillSubmissionNo from bizconnect_TripAcceptanceDetails TA inner join aarmjunction .dbo. scmjunction_BillSubmission BS on BS.CofirmNo=TA.AcceptanceID inner join BizConnect_TripAssign t on t.TripAssignID=ta.TripAssignID inner join CollectionNote cn on cn.CollectionNoteID=t.IndentID inner join  Bizconnect_BillValidation bv on bv.ConfirmNo =ta.AcceptanceID where ta.ClientID=" + Clientid + " and ProjectName like'%" + ProjectName + "%' and ProjectNo ='" + ProjectNo + "' and bv.BillMatchFlag=" + BillMathFlag + " and bv.clientid not in (0) order by BillNo ", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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

//Bizconnect_CheckBilldetailsExistsor not
public DataTable Bizconnect_CheckBilldetailsExistsorNotForBillApproval(int ClientID, int ConfirmNo)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select BillValidationNo  from  Bizconnect_BillValidation where ClientID =" + ClientID + " and ConfirmNo =" + ConfirmNo + " and BillMatchFlag=2", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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

//Bizconnect_SearchAarmsBillingReportByClientAndStatus
public DataTable Bizconnect_SearchAarmsBillingReportByClientAndStatus(string ClientName, int StatusID)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_SearchAarmsBillingReportByClientAndStatus", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.Add("@Client", ClientName);
            ada.SelectCommand.Parameters.Add("@Status", StatusID);
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


//Update scmjunction_BillSubmission Bill Status as 1
public int Update_scmjunction_BillSubmissionStaus(int ClientID, int ConfirmNo, string BillNo, int BillStatus)
{
    int result = 0;
    using (SqlConnection conn = new SqlConnection(connStr))
    {
        using (SqlCommand comm = new SqlCommand("update  aarmjunction .dbo.scmjunction_BillSubmission set BillStatus =" + BillStatus + ",LastUpdatedDateTime=getdate () where ClientID =" + ClientID + " and CofirmNo =" + ConfirmNo + " and BillNo='" + BillNo + "'", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            try
            {
                conn.Open();
                ada.SelectCommand.ExecuteNonQuery();
                result = 1;
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
    return result;
}



//Get ProjectNo for BillMatching
public DataTable Get_BizconnectProjectNoForBillMatching(int Clientid)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select distinct left (ProjectName,9) as ProjectName   from  Bizconnect_ProjectMaster where ClientID ="+Clientid, conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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

//Get ProjectNo for BillApproval
public DataTable Get_BizconnectProjectNoForBillMatching(string ProjectName)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select distinct ProjectNo  from CollectionNote where ProjectName like'%" + ProjectName + "%' order by ProjectNo ", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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



//Bizconnect_GetCollectionNoteDetailsFor Bill Approval
public DataSet Bizconnect_GetCollectionNoteDetailsForBillApproval(int obj_CofirmNo)
{
    DataSet ds = new DataSet();
    ds.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select AcceptanceID as ConfirmNo,CollectionNoteNumber,Convert(varchar(20),CollectionNoteDate ,106)as CollectionNoteDate,AutoNumber,ProjectNo,WBSNo,Description ,cn.TruckType,TransitDays,cn.Length,cn.Width,cn.Height,TotalWeight ,Buyer,ContactPerson ,ContactNo ,VehiclePlanned ,ta.FromLocation ,cn.ToLocation  ,DifferentialAmount , (AgreedPrice/VehiclePlanned) as AgreedPrice ,clientprice as ClientNetValue,cn.Transporter,IncreasePrice from bizconnect_TripAcceptanceDetails TD inner join BizConnect_TripAssign TA on TD.TripAssignID=TA.TripAssignID inner join CollectionNote CN on ta.IndentID =CN.CollectionNoteID inner join  Bizconnect_BillValidation Bv on td.AcceptanceID =bv.ConfirmNo  and td.AcceptanceID=" + obj_CofirmNo, conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            ada.SelectCommand.CommandTimeout = 30000;
            try
            {
                conn.Open();
                ada.Fill(ds, "confirmno");
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

//Load Transporters for bill verification from billvalidation table
public DataTable Bizconnect_LoadTransportersForBillVerification(int ClientID)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select TransporterID ,Transporter  from Bizconnect_ClientsTransporters where ClientID =" + ClientID + " order by Transporter", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            //ada.SelectCommand.CommandTimeout = 30000;
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


//Load Project nos for bill verification from billvalidation table
public DataTable Bizconnect_LoadProjectNosForBillVerification(int TransporterID)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select distinct ProjectNo    from BizConnect_TripAssign TA inner join bizconnect_TripAcceptanceDetails TAD on ta.TripAssignID =TAD .TripAssignID inner join CollectionNote CN on cn.CollectionNoteID =ta.IndentID inner join Bizconnect_BillValidation BV on TAD .AcceptanceID =bv.ConfirmNo where Billmatchflag =2 and TAD.TransporterID =" + TransporterID + " order by ProjectNo  ", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            //ada.SelectCommand.CommandTimeout = 30000;
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

//Load Bill no and lr no for bill verification from billvalidation table based on project no
public DataTable Bizconnect_LoadBillNoandLrNoForBillVerificationByProjectNo(string ProjectNo)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select   BillNo ,LRNumber from BizConnect_TripAssign TA inner join bizconnect_TripAcceptanceDetails TAD on ta.TripAssignID =TAD .TripAssignID inner join CollectionNote CN on cn.CollectionNoteID =ta.IndentID inner join Bizconnect_BillValidation BV on TAD .AcceptanceID =bv.ConfirmNo where Billmatchflag =2 and ProjectNo ='" + ProjectNo + "' order by BillNo ", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.Text;
            //ada.SelectCommand.CommandTimeout = 30000;
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


public DataTable Bizconnect_SearchBillingDetailsByBillNoOrLrNo(string BillNo, string LrNo)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_SearchBillingDetailsByBillNoOrLrNo", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.Add("@BillNo", BillNo);
            ada.SelectCommand.Parameters.Add("@LrNo", LrNo);
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


public DataTable Bizconnect_GetLrNumberandConfirmnoByLrno(int ClientID, string LrNo)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_GetLrNumberandConfirmnoByLrno", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.Add("@ClientID", ClientID);
            ada.SelectCommand.Parameters.Add("@LRNumber", LrNo);
            ada.SelectCommand.CommandTimeout = 3000;
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




public DataTable Bizconnect_GetBillDetailsByConfirmNo(int ConfirmNo)
{
    DataTable dt = new DataTable();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("select billno,convert(varchar(20), BillDate,103) as BillDate ,BillValue ,LRNumber ,convert(varchar(20), LRDate,103) as LRDate ,CofirmNo ,AgreementValue ,OtherCharges ,BasicFreight ,	 LoadingDetention ,UnloadingDetention ,Loadingcharges ,Unloadingchareges,Octroid ,DimensionDifference ,otherclaims ,Insurance ,Damages ,Shortages 	 from aarmjunction .dbo.scmjunction_BillSubmission where CofirmNo=" + ConfirmNo, conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
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


//Update scmjunction_BillSubmission details by confirm no
public int Bizconnect_EditBillSubmissionDetailsByConfirmNo(float AgreementValue, float BasicFreight)
{
    int result = 0;
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_EditBillSubmissionDetailsByConfirmNo", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.Add("@ConfirmNo", ConfirmNo);
            ada.SelectCommand.Parameters.Add("@billno", BillNo);
            ada.SelectCommand.Parameters.Add("@BillDate", BillDate);
            ada.SelectCommand.Parameters.Add("@BillValue", TransNetValue);
            ada.SelectCommand.Parameters.Add("@LRNumber", LRNumber);
            ada.SelectCommand.Parameters.Add("@LRDate", LRDate);
            ada.SelectCommand.Parameters.Add("@AgreementValue", AgreementValue);
            ada.SelectCommand.Parameters.Add("@OtherCharges", TransOtherCharges);
            ada.SelectCommand.Parameters.Add("@BasicFreight", BasicFreight);
            ada.SelectCommand.Parameters.Add("@LoadingDetention", TransLoadingDetentionCharges);
            ada.SelectCommand.Parameters.Add("@UnloadingDetention", TransUnLoadingDetentionCharges);
            ada.SelectCommand.Parameters.Add("@Loadingcharges", TransLoadingCharges);
            ada.SelectCommand.Parameters.Add("@Unloadingcharges", TransUnLoadingCharges);
            ada.SelectCommand.Parameters.Add("@Octroid", TransoctroiCharges);
            ada.SelectCommand.Parameters.Add("@DimensionDifference", TransoDimentionDiff);
            ada.SelectCommand.Parameters.Add("@otherclaims", TransOtherClaimsCharges);
            ada.SelectCommand.Parameters.Add("@Insurance", TransInsurance);
            ada.SelectCommand.Parameters.Add("@Damages", TransDamages);
            ada.SelectCommand.Parameters.Add("@Shortages", TransShortages);
            try
            {
                conn.Open();
                ada.SelectCommand.ExecuteNonQuery();
                result = 1;
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
    return result;
}



//Bizconnect_DeleteBillDetailsByConfirmNo
public int Bizconnect_DeleteBillDetailsByConfirmNo()
{
    int result = 0;
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_DeleteBillDetailsByConfirmNo", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.Add("@ConfirmNo", ConfirmNo);
            try
            {
                conn.Open();
                ada.SelectCommand.ExecuteNonQuery();
                result = 1;
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
    return result;
}



public DataSet Bizconnect_CollectionViewDetail()
{
    DataSet DataView = new DataSet();
    DataView.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_CollectionViewDetail", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_CNNo", CNNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
            try
            {
                conn.Open();
                ada.Fill(DataView, "confirmno");
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
    return DataView;
}

public DataSet Bizconnect_CofirmNoViewDetail()
{
    DataSet DataView = new DataSet();
    DataView.Clear();
    using (SqlConnection conn = new SqlConnection(Bizconn))
    {
        using (SqlCommand comm = new SqlCommand("Bizconnect_CofirmNoViewDetail", conn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ConfirmationNo", CNNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
            try
            {
                conn.Open();
                ada.Fill(DataView, "confirmno");
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
    return DataView;
}
}
