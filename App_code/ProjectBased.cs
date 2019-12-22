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
/// Summary description for ProjectBased
/// </summary>
public class ProjectBased
{
    int resp = 0;
    int Result, Output;
    SqlConnection obj_BizConn = new SqlConnection();
    SqlConnection obj_SCMConn = new SqlConnection();
	public ProjectBased()
	{
        string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
        string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
        obj_BizConn.ConnectionString = BizConnStr;
        obj_SCMConn.ConnectionString = SCMConnStr;

        obj_BizConn.Open();
        obj_SCMConn.Open();
	}
    //Get WBS
    public DataSet Get_WBS(string  obj_ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnet_Get_WBS", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("obj_ProjectNo", obj_ProjectNo);
          
            try
            {

                ada.Fill(ds, "TruckType");
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

    public DataSet Get_Tripindent(string obj_WBS)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_GetTripindent", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("obj_WBS", obj_WBS);

            try
            {

                ada.Fill(ds, "WBS");
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
    
    //Bizconnect_IndentDisplay
    public DataSet Bizconnect_IndentDisplay(String obj_Project,String obj_WBS)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_IndentDisplay", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_Project", obj_Project);
              ada.SelectCommand.Parameters.AddWithValue("@obj_WBS", obj_WBS);
            try
            {
                ada.Fill(ds, "WBS");
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
    
    
    
    //UpdateBizconnect_TripIndent
    public int UpdateBizconnect_TripIndent( int obj_qty,  string obj_from, int obj_noofvehicle,string TypeofVehicle, double obj_totalamount,int obj_transit,string obj_Address,DateTime obj_ScheduleDate, int obj_IndentID, String ModifiedBy)
    {
        try
        {
            int resp = 0;

            using (SqlCommand comm = new SqlCommand("UpdateBizconnect_TripIndent", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                //ada.SelectCommand.Parameters.AddWithValue("@obj_product", obj_product);
                ada.SelectCommand.Parameters.AddWithValue("@obj_qty", obj_qty);
                //ada.SelectCommand.Parameters.AddWithValue("@obj_unit", obj_unit);
                ada.SelectCommand.Parameters.AddWithValue("@obj_from", obj_from);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Noofvehicles", obj_noofvehicle);
                ada.SelectCommand.Parameters.AddWithValue("@obj_Typeofvehicle", TypeofVehicle);
                ada.SelectCommand.Parameters.AddWithValue("@obj_TotalAmount", obj_totalamount );

                ada.SelectCommand.Parameters.AddWithValue("@obj_Transit", obj_transit);
                ada.SelectCommand.Parameters.AddWithValue("@obj_LoadingAddress", obj_Address);
                 ada.SelectCommand.Parameters.AddWithValue("@obj_ScheduleDate", obj_ScheduleDate);
                
                ada.SelectCommand.Parameters.AddWithValue("@obj_IndentID", obj_IndentID);
                ada.SelectCommand.Parameters.AddWithValue("@obj_ModifiedBy", ModifiedBy );
                ada.SelectCommand.ExecuteNonQuery();
                resp = 1;

            }
          
        }
        catch (Exception ex)
        {
            resp = 0;
        }
        return resp;
    }  
    
    
      //Insert CollectionNote
    public int InsertBizconnect_CollectionNote(string ProjectNo, string WBSNo, DateTime Traveldate, string AutoNumber, string ProjectName, string Description, string TruckType, int TransitDays, double Length, double Width, double Height, double TotalWeight, string Buyer, string Contactperson, string ContactNumber, string Transporter, string Remarks, string LoadingPoint, string ToLocation, int VehiclePlanned, double AgreedPrice,  int CollectionNoteNumber ,DateTime CollectionNoteDate, int CollectionNoteFlag ,int SerialNo ,int SignID,double DifferentialAmount,string ApprovalReason,string Buyer1name,string Buyer1ContactNo)
    {
     int resp = 0;
        try
        {
           

            using (SqlCommand comm = new SqlCommand("InsertBizconnect_CollectionNote", obj_BizConn))
            {
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
                ada.SelectCommand.Parameters.AddWithValue("@WBSNo", WBSNo);
                ada.SelectCommand.Parameters.AddWithValue("@Traveldate", Traveldate);
                ada.SelectCommand.Parameters.AddWithValue("@AutoNumber", AutoNumber);
                ada.SelectCommand.Parameters.AddWithValue("@ProjectName", ProjectName);
                ada.SelectCommand.Parameters.AddWithValue("@Description", Description);
                ada.SelectCommand.Parameters.AddWithValue("@TruckType", TruckType);
                ada.SelectCommand.Parameters.AddWithValue("@TransitDays", TransitDays);
                ada.SelectCommand.Parameters.AddWithValue("@Length", Length );
                ada.SelectCommand.Parameters.AddWithValue("@Width", Width);
                ada.SelectCommand.Parameters.AddWithValue("@Height", Height);
                ada.SelectCommand.Parameters.AddWithValue("@TotalWeight", TotalWeight);
                ada.SelectCommand.Parameters.AddWithValue("@Buyer", Buyer);
                ada.SelectCommand.Parameters.AddWithValue("@Contactperson", Contactperson);
                ada.SelectCommand.Parameters.AddWithValue("@ContactNumber", ContactNumber);
                ada.SelectCommand.Parameters.AddWithValue("@Transporter", Transporter);
                ada.SelectCommand.Parameters.AddWithValue("@Remarks", Remarks);
                 ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteFlag", CollectionNoteFlag );
                ada.SelectCommand.Parameters.AddWithValue("@LoadingPoint", LoadingPoint);
                ada.SelectCommand.Parameters.AddWithValue("@ToLocation", ToLocation);
                ada.SelectCommand.Parameters.AddWithValue("@VehiclePlanned", VehiclePlanned);
                ada.SelectCommand.Parameters.AddWithValue("@AgreedPrice", AgreedPrice);
                
                 ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteNumber", CollectionNoteNumber);
                 ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteDate", CollectionNoteDate);
                  ada.SelectCommand.Parameters.AddWithValue("@SerialNo", SerialNo);
                  ada.SelectCommand.Parameters.AddWithValue("@SignID", SignID);
                   ada.SelectCommand.Parameters.AddWithValue("@DifferentialAmount", DifferentialAmount);
                   ada.SelectCommand.Parameters.AddWithValue("@ApprovalReason", ApprovalReason);
                   ada.SelectCommand.Parameters.AddWithValue("@Buyer1Name",Buyer1name);
                ada.SelectCommand.Parameters.AddWithValue("@Buyer1ContactNo",Buyer1ContactNo);
                ada.SelectCommand.ExecuteNonQuery();
                resp = 1;

            }

        }
        catch (Exception ex)
        {
           
        }
        return resp;
    }

 public DataSet Get_SerialNo(string obj_ProjectNo, string obj_WBS)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_Get_SerialNo", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", obj_ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_WBSNo ", obj_WBS);

            try
            {
                ada.Fill(ds, "WBS");
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





 //Get Tripindent details for CollectionNote

    public DataSet Bizconnet_GetIndentDetails(string obj_ProjectNo, string obj_WBS, int obj_SrNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnet_GetIndentDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", obj_ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@obj_WBSNo", obj_WBS);
          ada.SelectCommand.Parameters.AddWithValue("@obj_SrNo", obj_SrNo);

            try
            {
                ada.Fill(ds, "WBS");
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

    
     //Get Details of Collection Note
    public DataSet Bizconnet_GetCollectionNoteDetails(int CollectionNoteID,string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnet_GetCollectionNoteDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@obj_CollectionNoteID", CollectionNoteID);
            ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
        // ada.SelectCommand.Parameters.AddWithValue("@Mode", Mode);

            try
            {
                ada.Fill(ds, "CollectionNoteID");
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
    //Thermax DashBoard
     public DataSet Bizconnet_ThermaxDashBoard()
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxDashBoard", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
           

            try
            {
                ada.Fill(ds, "Dashboard");
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


    // get remaining Trucks
    public int Get_Remaining_Trucks(int SerialNo, string ProjNo ,string WBS)
    {

        using (SqlCommand comm = new SqlCommand("select SUM ( VehiclePlanned) as trucksplanned from CollectionNote where VehiclePlanned >0  and serialno=" + SerialNo + " and ProjectNo='" + ProjNo.ToString() + "' and WBSNo='" + WBS.ToString() + "' and CollectionNoteAcceptanceFlag in(0,1)", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            
            try
            {
                Result = (int)ada.SelectCommand.ExecuteScalar();
            }
            catch (Exception err)
            {

            }
            finally
            {

            }

        }
        return Result;
    }
    
      public DataSet Bizconnet_ThermaxDashBoard1()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxDashboard1", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "Dashboard1");
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
 public DataSet Bizconnet_ThermaxDashBoard2()
     {
         DataSet ds = new DataSet();
         ds.Clear();
         using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxDashBoard2", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             try
             {
                 ada.Fill(ds, "Dashboard2");
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

//cn generated

  public DataSet Get_CollectionNoteGeneated(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0  order by collectionNoteID", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and ProjectNo ='" + ProjectNo + "' order by collectionNoteID", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    } 
public DataSet Get_CollectionNoteConfirmed(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0  and CollectionNoteAcceptanceFlag=1", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=1", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    }

//cn not confirmed

 public DataSet Get_CnNotConfirmed(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        //SqlCommand comm = new SqlCommand();
        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0  and CollectionNoteAcceptanceFlag=0", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and ProjectNo ='"+ProjectNo+ "' and CollectionNoteAcceptanceFlag=0", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
            
        return ds;
    } 

 // Cn need Approval

public DataSet Get_CnNeedApproval(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and CollectionNoteAcceptanceFlag=4", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and ProjectNo ='" + ProjectNo + "'  and CollectionNoteAcceptanceFlag=4", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    } 

// cn Cancelled


public DataSet Get_CnCancelled(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();


        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and CollectionNoteAcceptanceFlag=3", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=3", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    } 


// cn Amendment


public DataSet Get_CnAmendment(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();


        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and CollectionNoteAcceptanceFlag=2", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select CollectionNoteID,ProjectNo,	WBSNo,convert (varchar(20),IssueDate,105)as IssueDate,	AutoNumber,	ProjectName,	Description,TruckType,	TransitDays,	Length,	Width,	Height,	TotalWeight,	Buyer,	ContactPerson,	ContactNo,	Transporter,	Remarks,convert (varchar(20),VehicleplacementDate,105)as VehicleplacementDate,convert (varchar(20),CreatedDateTimeStamp,105) as CreatedDateTimeStamp,LoadingPoint,	ToLocation,	VehiclePlanned,	AgreedPrice,	CollectionNoteNumber,	convert (varchar(20),CollectionNoteDate,105)as CollectionNoteDate,CollectionNoteAcceptanceFlag,	SerialNo,	SignID,	ApprovalNumber,	DifferentialAmount,	ApprovalReason,	ApprovalDate from CollectionNote cn where cn.SerialNo>0 and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=2", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    } 



//// vehicle Planned

 public DataSet Get_VehiclePlanned(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();


        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select ProjectNo,CollectionNoteNumber as CN_No ,LoadingPoint as fromLocation,ToLocation,Convert(varchar(20),VehicleplacementDate,105)  as VehicleRequirementDate , TruckType , Convert(varchar(20),IssueDate,105)   as AssignedDated from  CollectionNote   where SerialNo>0  and CollectionNoteAcceptanceFlag=1", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select ProjectNo,CollectionNoteNumber as CN_No ,LoadingPoint as fromLocation,ToLocation,Convert(varchar(20),VehicleplacementDate,105)  as VehicleRequirementDate , TruckType , Convert(varchar(20),IssueDate,105)   as AssignedDated from  CollectionNote   where SerialNo>0  and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=1", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    }

/// vehicle Placed

 public DataSet Get_VehiclePlaced(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();


        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select cn.ProjectNo ,CN.CollectionNoteNumber as CN_No ,(cn .LoadingPoint)as FromLocation ,cn.ToLocation  ,convert(varchar(20),cn .VehicleplacementDate,105) as VehicleRequirementDate ,  cn.TruckType  ,convert(varchar(20),cn.IssueDate,105)as AssignedDated from  BizConnect_TripAssign Ta inner join bizconnect_TripAcceptanceDetails TD  on ta.TripAssignID =td.TripAssignID and Assigned =1  inner join CollectionNote cn on ta.IndentID =cn.CollectionNoteID  where SerialNo>0  and CollectionNoteAcceptanceFlag=1 order by cn.ProjectNo", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select cn.ProjectNo ,CN.CollectionNoteNumber as CN_No ,(cn .LoadingPoint)as FromLocation ,cn.ToLocation  ,convert(varchar(20),cn .VehicleplacementDate,105) as VehicleRequirementDate ,  cn.TruckType  ,convert(varchar(20),cn.IssueDate,105)as AssignedDated from  BizConnect_TripAssign Ta inner join bizconnect_TripAcceptanceDetails TD  on ta.TripAssignID =td.TripAssignID and Assigned =1  inner join CollectionNote cn on ta.IndentID =cn.CollectionNoteID  where SerialNo>0 and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=1 order by cn.ProjectNo", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    }  

// Vehicle LoadedonTime

 public DataSet Get_VehLoadontime(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();


        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select cn.ProjectNo ,CN.CollectionNoteNumber as CN_No ,(cn .LoadingPoint)as FromLocation ,cn.ToLocation  ,convert(varchar(20),cn .VehicleplacementDate,105) as VehicleRequirementDate ,  cn.TruckType  ,convert(varchar(20),cn.IssueDate,105)as AssignedDated from  BizConnect_TripAssign Ta inner join bizconnect_TripAcceptanceDetails TD on ta.TripAssignID =td.TripAssignID and Assigned =1 and LoadedStatus=1 inner join CollectionNote cn on ta.IndentID =cn.CollectionNoteID  where SerialNo>0  and CollectionNoteAcceptanceFlag=1 order by cn.ProjectNo", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select cn.ProjectNo ,CN.CollectionNoteNumber as CN_No ,(cn .LoadingPoint)as FromLocation ,cn.ToLocation  ,convert(varchar(20),cn .VehicleplacementDate,105) as VehicleRequirementDate ,  cn.TruckType  ,convert(varchar(20),cn.IssueDate,105)as AssignedDated from  BizConnect_TripAssign Ta inner join bizconnect_TripAcceptanceDetails TD on ta.TripAssignID =td.TripAssignID and Assigned =1 and LoadedStatus=1 inner join CollectionNote cn on ta.IndentID =cn.CollectionNoteID  where SerialNo>0 and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=1 order by cn.ProjectNo", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    } 


/// vehicle Delayed

 public DataSet Get_VehDelayed(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();


        if (ProjectNo == "-Select-")
        {
            SqlCommand comm = new SqlCommand("select cn.ProjectNo ,CN.CollectionNoteNumber as CN_No ,(cn .LoadingPoint)as FromLocation ,cn.ToLocation  ,convert(varchar(20),cn .VehicleplacementDate,105) as VehicleRequirementDate ,  cn.TruckType  ,convert(varchar(20),cn.IssueDate,105)as AssignedDated from  BizConnect_TripAssign Ta inner join bizconnect_TripAcceptanceDetails TD on ta.TripAssignID =td.TripAssignID and Assigned =1 and LoadedStatus=0 inner join CollectionNote cn on ta.IndentID =cn.CollectionNoteID  where SerialNo>0  and CollectionNoteAcceptanceFlag=1 order by cn.ProjectNo", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        else
        {
            SqlCommand comm = new SqlCommand("select cn.ProjectNo ,CN.CollectionNoteNumber as CN_No ,(cn .LoadingPoint)as FromLocation ,cn.ToLocation  ,convert(varchar(20),cn .VehicleplacementDate,105) as VehicleRequirementDate ,  cn.TruckType  ,convert(varchar(20),cn.IssueDate,105)as AssignedDated from  BizConnect_TripAssign Ta inner join bizconnect_TripAcceptanceDetails TD on ta.TripAssignID =td.TripAssignID and Assigned =1 and LoadedStatus=0 inner join CollectionNote cn on ta.IndentID =cn.CollectionNoteID  where SerialNo>0  and ProjectNo ='" + ProjectNo + "' and CollectionNoteAcceptanceFlag=1 order by cn.ProjectNo", obj_BizConn);
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnnotConfirmed");
            }
            catch (Exception err)
            {

            }
        }
        return ds;
    } 

//get Dashboard BillSubmitted by Transporter
    public DataSet Get_BillSubmitted()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select Cofirmno,BillNo,CONVERT(varchar(15),BillDate ,105)as BillDate,BillValue ,LRNumber ,CONVERT(varchar(15),LRDate ,105)as LRDate,SubmissionAddress  from aarmjunction .dbo.scmjunction_BillSubmission where CLientID=1135", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "BillSubmit");
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

//get Dashboard Bill Validated by aarms
    public DataSet Get_BillvalidatebyAarms()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select BillNo ,CONVERT (varchar(15),BillDate,105) as BillDate ,LRNumber ,CONVERT (varchar(15),LRDate ,105) as LRDate,VehicleNo ,FromLocation ,ToLocation ,SubmissionAddress ,TransporterPrice ,ClientPrice ,TransNetValue as TransporterNetValue ,ClientNetValue ,Checkedby,CONVERT (varchar(15),ValidatedDateTimeStamp ,105) as ValidatedOn from dbo.Bizconnect_BillValidation  where ClientID=1135", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "BillValidated");
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

    //get Dashboard Bill Discrepancy
    public DataSet Get_BillDiscrepancy()
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select BillNo ,CONVERT (varchar(15),BillDate,105) as BillDate ,LRNumber ,CONVERT (varchar(15),LRDate ,105) as LRDate,VehicleNo ,FromLocation ,ToLocation ,SubmissionAddress ,TransporterPrice ,ClientPrice ,TransNetValue as TransporterNetValue ,ClientNetValue ,Checkedby,CONVERT (varchar(15),ValidatedDateTimeStamp ,105) as ValidatedOn from dbo.Bizconnect_BillValidation  where ClientID=1135 and AARMSRemarks like '%discrepancy%'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "BillDiscrepancy");
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

//Thermax DashBoard BillDetails
     
    public DataSet Get_ThermaxBilldetails()
    {
         
         DataSet ds = new DataSet();
         ds.Clear();
         using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxBillSubmDetails", obj_BizConn))
         {
             SqlDataAdapter ada = new SqlDataAdapter(comm);
             ada.SelectCommand.CommandType = CommandType.StoredProcedure;
             try
             {
                 ada.Fill(ds, "Dashboard2");
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
     
     public DataSet Bizconnect_ThermaxCNote_SearchonProject( string ProjectNo)
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxCNote_SearchonProject", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
            try
            {
                ada.Fill(ds, "ProjectNo");
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



public DataSet Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject(string ProjectNo)
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxCnote_LoadWBSNoBasedOnProject", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
            try
            {
                ada.Fill(ds, "ProjectNo");
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



public DataSet Bizconnect_ThermaxCNote_SearchOnWBSNo(string WBSNo,string ProjectNo)
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxCNote_SearchOnWBSNo", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@WBSNo", WBSNo);
            ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
            try
            {
                ada.Fill(ds, "WBSNo");
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

public DataSet Get_LoadWBSNoForCNoteConfirmed(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct  WBSNo  from CollectionNote where SerialNo >0 and CollectionNoteAcceptanceFlag =1 and projectno='"+ ProjectNo+"'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnConfirmed");
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


public DataSet Get_LoadWBSNoForCNNotConfirmed(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct  WBSNo  from CollectionNote where SerialNo >0 and CollectionNoteAcceptanceFlag =0 and projectno='" + ProjectNo + "'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "CnNotConfirmed");
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



public DataSet Get_LoadWBSNoForCNNeedApproval(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct  WBSNo  from CollectionNote where SerialNo >0 and CollectionNoteAcceptanceFlag =4 and projectno='" + ProjectNo + "'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "NeedApproval");
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



public DataSet Get_LoadWBSNoForCNCancelled(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct  WBSNo  from CollectionNote where SerialNo >0 and CollectionNoteAcceptanceFlag =3 and projectno='" + ProjectNo + "'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "cancelled");
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


public DataSet Get_LoadWBSNoForCNAmendment(string ProjectNo)
    {
        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("select distinct  WBSNo  from CollectionNote where SerialNo >0 and CollectionNoteAcceptanceFlag =2 and projectno='" + ProjectNo + "'", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            try
            {
                ada.Fill(ds, "Amendment");
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

public DataSet Bizconnect_ThermaxCNote_SearchByProjectNoAndWBSNo(string ProjectNo ,string WBSNo ,string PageName)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxCNote_SearchByProjectNoAndWBSNo", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@projectNo", ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@WBSNo", WBSNo);
            ada.SelectCommand.Parameters.AddWithValue("@PageName", PageName);
            try
            {
                ada.Fill(ds, "Thermax");
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


public DataSet Bizconnect_ThermaxVehPlacementSearchonPjtNo(string ProjectNo, string PageName)
    {
        DataSet ds = new DataSet();
        ds.Clear();

        using (SqlCommand comm = new SqlCommand("Bizconnect_ThermaxVehPlacementSearchonPjtNo", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@projectNo", ProjectNo);
            ada.SelectCommand.Parameters.AddWithValue("@PageName", PageName);
            try
            {
                ada.Fill(ds, "Thermax");
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
    
    public DataSet Bizconnect_GetParcekBillEntryDetails()
    {

        DataSet ds = new DataSet();
        ds.Clear();
        using (SqlCommand comm = new SqlCommand("Bizconnect_GetParcekBillEntryDetails", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            try
            {
                ada.Fill(ds, "BillparcelEntry");
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

    public int scmjunction_UpdateCuttOffTime(int UserID, string TravelDate, string CuttOffTime, string ECuttOffTime)
    {
        int resp = 0;
        using (SqlCommand comm = new SqlCommand("scmjunction_UpdateCuttOffTime", obj_BizConn))
        {
            SqlDataAdapter ada = new SqlDataAdapter(comm);
            ada.SelectCommand.CommandType = CommandType.StoredProcedure;
            ada.SelectCommand.Parameters.AddWithValue("@UserID", UserID);
            ada.SelectCommand.Parameters.AddWithValue("@TravelDate", TravelDate);
            ada.SelectCommand.Parameters.AddWithValue("@CutoffTime", CuttOffTime);
            ada.SelectCommand.Parameters.AddWithValue("@ECutoffTime", ECuttOffTime);
            try
            {
                ada.SelectCommand.ExecuteNonQuery();
                resp = 1;
            }
            catch (Exception err)
            {
                resp = 0;
            }
            finally
            {
            }
        }
        return resp;
    }

public DataTable Bizconnect_Get_ThermaxProjects( int ClientID)
{

    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("Bizconnect_Get_ThermaxProjects", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@obj_ClientID", ClientID);
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

    //  selecting no of Indent  on  2016-7-15

public DataTable Bizconnect_Get_Indent(int UserID, string FromDate)
{

    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("Bizconnect_Get_Indent", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@obj_UserID", UserID);
        ada.SelectCommand.Parameters.AddWithValue("@obj_FromDate", FromDate);
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





public DataTable Bizconnect_Search_ThermaxCollectNoteByProjectNo(string  ProjectNo)
{

    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("Bizconnect_Search_ThermaxCollectNoteByProjectNo", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
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



public DataTable Bizconnect_Search_ThermaxVehplacementbyProjectNo(string ProjectNo)
{

    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("Bizconnect_Search_ThermaxVehplacementbyProjectNo", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@obj_ProjectNo", ProjectNo);
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

public DataTable Bizconnect_Get_CnGeneratedNO()
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("select  CollectionNoteID ,AutoNumber   from CollectionNote where CollectionNoteAcceptanceFlag  in (0,1)", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text;
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

public DataTable Bizconnect_Get_CollectionDetails(string CNNo)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("Bizconnect_Get_CollectionDetails", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@CNNo", CNNo);
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

public int Bizconnect_UpdateCNAmendment(int CNID)
{
    int resp = 0;
    using (SqlCommand comm = new SqlCommand("Bizconnect_UpdateCNAmendment", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@CnID", CNID);
        try
        {
            ada.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception err)
        {
            resp = 0;
        }
        finally
        {
        }
    }
    return resp;
}

public int Bizconnect_UpdateCNasCancelled(int CNID,int SerialNo)
{
    int resp = 0;
    using (SqlCommand comm = new SqlCommand("update CollectionNote set CollectionNoteAcceptanceFlag =3,SerialNo="+SerialNo+" where CollectionNoteID =" + CNID, obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text ;
        try
        {
            ada.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception err)
        {
            resp = 0;
        }
        finally
        {
        }
    }
    return resp;
}

public int Bizconnect_UpdateProjectDetailsByPjtno(string ProjectNo, int ClientID, string ProjectName, string ProjectLocation, string WorkOrderNo, string Transporter, string TransporterEmailID, string ProjectManager, string ProjectManagerEmailID,
string PMMobileNo, string SiteIncharge, string SiteInchargeEmailID, string SiteInchargeMobileNo, string LogisticPerson, string LogisticPersonEmail, string Shipperperson, string ShippingPersonMail, string ApprovalPerson, string ApprovalPersonMail)
{
    int resp = 0;
    using (SqlCommand comm = new SqlCommand("Bizconnect_UpdateProjectDetailsByPjtno", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@ProjectNo", ProjectNo);
        ada.SelectCommand.Parameters.AddWithValue("@ClientID", ClientID);
        ada.SelectCommand.Parameters.AddWithValue("@ProjectName", ProjectName);
        ada.SelectCommand.Parameters.AddWithValue("@ProjectLocation", ProjectLocation);
        ada.SelectCommand.Parameters.AddWithValue("@WorkOrderNo", WorkOrderNo);
        ada.SelectCommand.Parameters.AddWithValue("@Transporter", Transporter);
        ada.SelectCommand.Parameters.AddWithValue("@TransporterEmailID", TransporterEmailID);
        ada.SelectCommand.Parameters.AddWithValue("@ProjectManager", ProjectManager);
        ada.SelectCommand.Parameters.AddWithValue("@ProjectManagerEmailID", ProjectManagerEmailID);
        ada.SelectCommand.Parameters.AddWithValue("@PMMobileNo", PMMobileNo);
        ada.SelectCommand.Parameters.AddWithValue("@SiteIncharge", SiteIncharge);
        ada.SelectCommand.Parameters.AddWithValue("@SiteInchargeEmailID", SiteInchargeEmailID);
        ada.SelectCommand.Parameters.AddWithValue("@SiteInchargeMobileNo", SiteInchargeMobileNo);
        ada.SelectCommand.Parameters.AddWithValue("@LogisticPerson", LogisticPerson);
        ada.SelectCommand.Parameters.AddWithValue("@LogisticPersonEmail", LogisticPersonEmail);

        ada.SelectCommand.Parameters.AddWithValue("@Shippingperson", Shipperperson);
        ada.SelectCommand.Parameters.AddWithValue("@ShippingpersonMail", ShippingPersonMail);
        ada.SelectCommand.Parameters.AddWithValue("@ApprovalPerson", ApprovalPerson);
        ada.SelectCommand.Parameters.AddWithValue("@ApprovalpersonMail", ApprovalPersonMail);
        try
        {
            ada.SelectCommand.ExecuteNonQuery();
            resp = 1;
        }
        catch (Exception err)
        {
            resp = 0;
        }
        finally
        {
        }
    }
    return resp;
}


public DataTable Bizconnect_Get_CNNumber()
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("select  CollectionNoteID ,CollectionNoteNumber   from CollectionNote where CollectionNoteAcceptanceFlag  in (0,1) order by CollectionNoteNumber", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text;
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

public DataTable Bizconnect_GetAccessPermitedUsers(int UserID)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("select UserID ,AccessID  from [dbo].[BizConnect_UserPermission] where UserID=" + UserID, obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text;
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

// get max collection noteID 
public DataTable Bizconnect_GetMaxCollectionNoteID()
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("select max(CollectionNoteID) as CollectionNoteID from CollectionNote", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text;
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

// Bizconnect_GetClientsTransporterEMailIDs
public DataTable Bizconnect_GetClientsTransporterEMailIDs(int ClientID)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("select TransporterID ,Transporter  from Bizconnect_ClientsTransporters where ClientID =" + ClientID, obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text;
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


// Bizconnect_GetClientsTransporterName by transporter emailid
public DataTable Bizconnect_GetTransporterByEMailID(int TransporterID)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("select EmailID  from Bizconnect_ClientsTransporters  where TransporterID =" + TransporterID, obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.Text;
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

// Bizconnect_CheckCNoteNumberExistsorNot
public int Bizconnect_CheckCNoteNumberExistsorNot(int CNNo)
{
    using (SqlCommand comm = new SqlCommand("Bizconnect_CheckCNoteNumberExistsorNot", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;

        try
        {
            ada.SelectCommand.Parameters.AddWithValue("@CollectionNoteNo", CNNo);
            ada.SelectCommand.Parameters.Add("@Result", SqlDbType.Int).Direction = ParameterDirection.Output;
            ada.SelectCommand.ExecuteScalar();
            Output = Convert.ToInt32(ada.SelectCommand.Parameters["@Result"].Value);
        }
        catch (Exception err)
        {

        }
        finally
        {

        }

    }
    return Output;
}


// Bizconnect_GetClientsTransporterName by transporter emailid
public DataTable Bizconnect_GetEmailForAlternateTransporter(int CnNo, int Case, string Transporter)
{
    DataTable dt = new DataTable();
    dt.Clear();
    using (SqlCommand comm = new SqlCommand("Bizconnect_GetEmailForAlternateTransporter", obj_BizConn))
    {
        SqlDataAdapter ada = new SqlDataAdapter(comm);
        ada.SelectCommand.CommandType = CommandType.StoredProcedure;
        ada.SelectCommand.Parameters.AddWithValue("@CNNo", CnNo);
        ada.SelectCommand.Parameters.AddWithValue("@Case", Case);
        ada.SelectCommand.Parameters.AddWithValue("@TransporterName", Transporter);
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
