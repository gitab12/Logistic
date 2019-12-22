using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for TMSInsertion
/// </summary>
public class TMSInsertion
{
    SqlConnection Obj_Insert = new SqlConnection();
    int res = 0;
	public TMSInsertion()
	{
		//
		// TODO: Add constructor logic here
		//
        string Str_Insert = ConfigurationManager.ConnectionStrings["con1"].ConnectionString;  
        Obj_Insert.ConnectionString = Str_Insert;
	}
    public int Insert_Into_Client_Master(string Company_name,string Comp_Loc, string Tin_No, string CST_No, string key_person,
        string Contact_No, string Email, string Year_Of_Est,int No_Of_Trucks, int No_Of_Emp)
    {
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Client_Master]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Company_Name", Company_name);
                ada.SelectCommand.Parameters.AddWithValue("@Company_Location", Comp_Loc);
                ada.SelectCommand.Parameters.AddWithValue("@Tin_No", Tin_No);
                ada.SelectCommand.Parameters.AddWithValue("@CST_No", CST_No);
                ada.SelectCommand.Parameters.AddWithValue("@Key_Person", key_person);
                ada.SelectCommand.Parameters.AddWithValue("@Contact_No", Contact_No);
                ada.SelectCommand.Parameters.AddWithValue("@Email_ID", Email);
                ada.SelectCommand.Parameters.AddWithValue("@Year_Of_Est", Year_Of_Est);
                ada.SelectCommand.Parameters.AddWithValue("@No_Of_Trucks", No_Of_Trucks);
                ada.SelectCommand.Parameters.AddWithValue("@No_Of_Emp", No_Of_Emp);                
                res=ada.SelectCommand.ExecuteNonQuery();
                return res;
              //  comm.Dispose();
            }
        }

        catch (Exception err)
        {            
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
    public int Insert_Into_Branch_Master(int Company_ID, string Comp_Loc, string Branch_Name, string Branch_Manager, string Contact_No, string Email)
    {
        Company_ID = 1;
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Branch_Master]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Company_ID", Company_ID);
                ada.SelectCommand.Parameters.AddWithValue("@Company_Location", Comp_Loc);
                ada.SelectCommand.Parameters.AddWithValue("@Branch_Name", Branch_Name);
                ada.SelectCommand.Parameters.AddWithValue("@Branch_Manager", Branch_Manager);
                ada.SelectCommand.Parameters.AddWithValue("@Contact_No", Contact_No);
                ada.SelectCommand.Parameters.AddWithValue("@Email_ID", Email);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;                
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
    public int Insert_Into_Customer_Master(string Cust_Name,string Cust_Loc,string Contact_Person,string Contact_No, string Category)
    {   
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Customer_Master]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Customer_Name", Cust_Name);
                ada.SelectCommand.Parameters.AddWithValue("@Customer_Location", Cust_Loc);
                ada.SelectCommand.Parameters.AddWithValue("@Contact_Person", Contact_Person);
                ada.SelectCommand.Parameters.AddWithValue("@Contact_No", Contact_No);
                ada.SelectCommand.Parameters.AddWithValue("@Category", Category);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
    public int Insert_Into_Vendor_Master(string Vendor_Name, string Vendor_Loc, string Contact_Person, string Contact_No, string Email_ID,int No_Of_Trucks)
    {
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Vendor_Master]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Vendor_Loc", Vendor_Loc);
                ada.SelectCommand.Parameters.AddWithValue("@Contact_Person", Contact_Person);
                ada.SelectCommand.Parameters.AddWithValue("@Contact_No", Contact_No);
                ada.SelectCommand.Parameters.AddWithValue("@Email_ID", Email_ID);
                ada.SelectCommand.Parameters.AddWithValue("@No_Of_Trucks", No_Of_Trucks);
                ada.SelectCommand.Parameters.AddWithValue("@Vendor_Name", Vendor_Name);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
    public int Insert_Into_Fleet_Master(int Company_ID, string Truck_Type, string Capacity, string Enclosure_Type)
    {
        Company_ID = 1;
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Fleet_Master]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Company_ID", Company_ID);
                ada.SelectCommand.Parameters.AddWithValue("@Truck_Type", Truck_Type);
                ada.SelectCommand.Parameters.AddWithValue("@Capacity", Capacity);
                ada.SelectCommand.Parameters.AddWithValue("@Enclosure_Type", Enclosure_Type);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }

    public int Insert_Into_Cost_Master(float Diesel_Mileage_Per_Km, float Diesel_Rate, float Diesel_Cost_Per_Km, int Tyre_Avg_Life_Of_Tyre,
        int Tyre_No_Of_Tyre, float Tyre_Cost_Of_Each_Tyre, float Tyre_Cost_Per_KM, float Driver_Monthly_Sal,
        float Driver_Distance_Per_Month, float Driver_Cost_Per_KM, float Oil_Percentage, float Oil_Cost_Per_Km, float Other_Percentage, float Other_Cost_Per_KM, 
        float Total_Cost_Per_Km)
    {
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Cost_Master]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Diesel_Mileage_Per_Km", Diesel_Mileage_Per_Km);
                ada.SelectCommand.Parameters.AddWithValue("@Diesel_Rate", Diesel_Rate);
                ada.SelectCommand.Parameters.AddWithValue("@Diesel_Cost_Per_Km", Diesel_Cost_Per_Km);
                ada.SelectCommand.Parameters.AddWithValue("@Tyre_Avg_Life_Of_Tyre", Tyre_Avg_Life_Of_Tyre);
                ada.SelectCommand.Parameters.AddWithValue("@Tyre_No_Of_Tyre", Tyre_No_Of_Tyre);
                ada.SelectCommand.Parameters.AddWithValue("@Tyre_Cost_Of_Each_Tyre", Tyre_Cost_Of_Each_Tyre);
                ada.SelectCommand.Parameters.AddWithValue("@Tyre_Cost_Per_KM", Tyre_Cost_Per_KM);
                ada.SelectCommand.Parameters.AddWithValue("@Driver_Monthly_Sal", Driver_Monthly_Sal);
                ada.SelectCommand.Parameters.AddWithValue("@Driver_Distance_Per_Month", Driver_Distance_Per_Month);
                ada.SelectCommand.Parameters.AddWithValue("@Driver_Cost_Per_KM", Driver_Cost_Per_KM);
                ada.SelectCommand.Parameters.AddWithValue("@Oil_Percentage", Oil_Percentage);
                ada.SelectCommand.Parameters.AddWithValue("@Oil_Cost_Per_Km", Oil_Cost_Per_Km);
                ada.SelectCommand.Parameters.AddWithValue("@Other_Percentage", Other_Percentage);
                ada.SelectCommand.Parameters.AddWithValue("@Other_Cost_Per_KM", Other_Cost_Per_KM);
                ada.SelectCommand.Parameters.AddWithValue("@Total_Cost_Per_Km", Total_Cost_Per_Km);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
    public int Insert_Into_New_RFQ(string Client, string From_Location, string To_Location,string RFQ_NO,string Material, string Type_Of_Vehicle,
        string Enclosure_Type, int No_Of_Vehicles, string Capacity, string Period, string Remarks
        )
    {
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_New_RFQ]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@Client", Client);
                ada.SelectCommand.Parameters.AddWithValue("@From_Location", From_Location);
                ada.SelectCommand.Parameters.AddWithValue("@To_Location", To_Location);
                ada.SelectCommand.Parameters.AddWithValue("@RFQ_NO", RFQ_NO);
                ada.SelectCommand.Parameters.AddWithValue("@Material", Material);
                ada.SelectCommand.Parameters.AddWithValue("@Type_Of_Vehicle", Type_Of_Vehicle);
                ada.SelectCommand.Parameters.AddWithValue("@Enclosure_Type", Enclosure_Type);
                ada.SelectCommand.Parameters.AddWithValue("@No_Of_Vehicles", No_Of_Vehicles);
                ada.SelectCommand.Parameters.AddWithValue("@Capacity", Capacity);
                ada.SelectCommand.Parameters.AddWithValue("@Date_Of_Requirement", Period);
                ada.SelectCommand.Parameters.AddWithValue("@Remarks", Remarks);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
    public int Insert_Into_Quote_RFQ(int RFQ_ID,float Basic_Quote, float Detention_Charges, float Loading_Charges,float UnLoading_Charges,
        float Octroi, float Insurance, float Other_Charges,string Remarks, int Branch_ID
       )
    {
        try
        {
            using (SqlCommand comm = new SqlCommand("[Insert_Into_Quote_RFQ]", Obj_Insert))
            {
                Obj_Insert.Open();
                SqlDataAdapter ada = new SqlDataAdapter(comm);
                ada.SelectCommand.CommandType = CommandType.StoredProcedure;
                ada.SelectCommand.Parameters.AddWithValue("@RFQ_ID", RFQ_ID);
                ada.SelectCommand.Parameters.AddWithValue("@Basic_Quote", Basic_Quote);
                ada.SelectCommand.Parameters.AddWithValue("@Detention_Charges", Detention_Charges);
                ada.SelectCommand.Parameters.AddWithValue("@Loading_Charges", Loading_Charges);
                ada.SelectCommand.Parameters.AddWithValue("@UnLoading_Charges", UnLoading_Charges);
                ada.SelectCommand.Parameters.AddWithValue("@Octroi", Octroi);
                ada.SelectCommand.Parameters.AddWithValue("@Insurance", Insurance);
                ada.SelectCommand.Parameters.AddWithValue("@Other_Charges", Other_Charges);
                ada.SelectCommand.Parameters.AddWithValue("@Remarks", Remarks);
                ada.SelectCommand.Parameters.AddWithValue("@Branch_ID", Branch_ID);
                res = ada.SelectCommand.ExecuteNonQuery();
                return res;
            }
        }

        catch (Exception err)
        {
            err.ToString();
        }
        finally
        {
            Obj_Insert.Close();
        }
        return res;
    }
}