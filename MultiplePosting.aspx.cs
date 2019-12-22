using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
public partial class MultiplePosting : System.Web.UI.Page
{
    BizConnectLogisticsPlan obj_BizConnectLogisticsPlanClass = new BizConnectLogisticsPlan();
    MailClass obj_mail = new MailClass();
    
    FindIDs obj_FindID = new FindIDs();
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataColumn myDataColumn;
    DataTable dt = new DataTable();
    DataTable dt2 = new DataTable();
    DataTable dt3 = new DataTable();
    DataTable TempDataTable = new DataTable();
    DataTable myDataTable = new DataTable();
    DataTable myDataTable2 = new DataTable();
    DataTable myDataTable3 = new DataTable();
    DataTable FoundDataTable = new DataTable();
    DataTable NotFoundDataTable = new DataTable();
    string obj_FileName, obj_Path;
    int obj_ClientID, obj_UserID, obj_CustomerID, obj_AarmsuserID, obj_LocationTypeID, obj_ProductTypeID, obj_ProductCategorID, obj_ProductID, obj_Quantity, obj_TravelTypeID, obj_TravelDistance, obj_TravelDistanceUnitID, obj_CostperTruck, obj_Weight, obj_WeightUnitID, obj_Height, obj_HeightUnitID, obj_Length, obj_LengthUnitID, obj_Width, obj_WidthUnitID, obj_Volume, obj_VolumeID, obj_NoofTrucks, obj_TruckTypeID, obj_EnclosureTypeID, obj_TruckBrandID, obj_TruckModelID, obj_ShipmentID, obj_TruckCapacityUnit, obj_TravelGroup, obj_ShipmentType, obj_LogisticsPlanID, obj_FromPinCode, obj_ToPinCode, obj_TransitDay,obj_ClientPrice;
    string obj_CustomerName, obj_JunctionID, obj_FromLocation, obj_ToLocation, obj_ProductCategory, obj_ProductName, obj_Comments,  obj_ReasonForFailed, obj_FromFirstName, obj_FromMiddleName, obj_FromLastName, obj_FromCity, obj_FromAddress, obj_FromState, obj_FromCountry, obj_FromCorporateEmail, obj_ToFirstName, obj_ToMiddleName, obj_ToLastName, obj_ToCity, obj_ToAddress, obj_ToState, obj_ToCountry, obj_ToCorporateEmail, obj_FromBoardNumber, obj_FromFax,obj_ToBoardNumber, obj_ToFax;
  DateTime  obj_TravelDate;
  double obj_TruckCapacity, obj_QuantityperTruck;
    int obj_resp =0;
    protected void Page_Load(object sender, EventArgs e)
    {
     
      if (Session["UserID"] != string.Empty && Convert.ToInt32(Session["UserID"].ToString()) > 0)
       {
        if (IsPostBack == false)
        {
            ChkAuthentication();
        }       
       
       } 
        else
        {
            Response.Redirect("Index.aspx");
        } 
    }
    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        obj_Navi = null;
        obj_Navihome = null;

        if (Session["Authenticated"] == null)
        {
            Session["Authenticated"] = "0";
        }
        else
        {
            obj_Authenticated = Session["Authenticated"].ToString();
        }


        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("loginheader1");

            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");

                // obj_Navi = (UserControl)obj_Tabs.FindControl("Navii");
                //obj_Navihome = (UserControl)obj_Tabs.FindControl("Navihome1");


                if (obj_LoginCtrl != null & obj_WelcomCtrl != null)
                {
                    if (obj_Authenticated == "1")
                    {
                        SetVisualON();


                    }
                    else
                    {
                        SetVisualOFF();

                    }


                }
            }
            else
            {

            }
        }
        else
        {

        }
    }
    public void SetVisualON()
    {
        obj_LoginCtrl.Visible = false;
        obj_WelcomCtrl.Visible = true;
      

    }
    public void SetVisualOFF()
    {
        obj_LoginCtrl.Visible = true;
        obj_WelcomCtrl.Visible = false;
      
    }
    private DataTable CreateTempDataTable()
    {

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "From";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "To";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CustomerName";
        myDataTable2.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DateofTravel";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductType";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelDistance";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductCategory";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductName";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Quantity";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelType";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TruckType";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "EnclosureType";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Capacity";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "NoofTrucks";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CostperTruck";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Remarks";
        myDataTable2.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TransitDay";
        myDataTable2.Columns.Add(myDataColumn);
        
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ClientPrice";
        myDataTable2.Columns.Add(myDataColumn);
       
        return myDataTable2;
    }
    private DataTable AddDataToTempTable(string FromLocation, string ToLocation,string CustomerName, string Dateoftravel, string Producttype, string TravelDistance, string ProductCategory, string ProductName, string Quantity, string TravelType,string TruckType, string EnclosureType, string Capacity, string NoofTrucks, string CostperTruck, string Remarks,string TransitDay, string ClientPrice, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["From"] = FromLocation;
        row["To"] = ToLocation;
        row["CustomerName"] = CustomerName;
        row["DateofTravel"] = Dateoftravel;
        row["ProductType"] = Producttype;
        row["TravelDistance"] = TravelDistance;
        row["ProductCategory"] = ProductCategory;
        row["ProductName"] = ProductName;
        row["Quantity"] = Quantity;
        row["TravelType"] = TravelType ;
        row["TruckType"] = TruckType;
        row["EnclosureType"] = EnclosureType;
        row["Capacity"] = Capacity;
        row["NoofTrucks"] = NoofTrucks;
        row["CostperTruck"] = CostperTruck;
        row["Remarks"] = Remarks;
        row["TransitDay"] = TransitDay;
        row["ClientPrice"]=ClientPrice;
        dt.Rows.Add(row);
        return dt;
    }

    private DataTable AddDataToNotFoundTable(string obj_Reason, string FromLocation, string ToLocation, string CustomerName, string Dateoftravel, string Producttype,string TravelDistance, string ProductCategory, string ProductName, string Quantity, string TravelType, string TruckType, string EnclosureType, string Capacity, string NoofTrucks, string CostperTruck, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["Reason"]=obj_Reason;
        row["From"] = FromLocation;
        row["To"] = ToLocation;
        row["CustomerName"] = CustomerName;
        row["DateofTravel"] = Dateoftravel;
        row["ProductType"] = Producttype;
        row["TravelDistance"] = TravelDistance;
        row["ProductCategory"] = ProductCategory;
        row["ProductName"] = ProductName;
        row["Quantity"] = Quantity;
        row["TravelType"] = TravelType;
        row["TruckType"] = TruckType;
        row["EnclosureType"] = EnclosureType;
        row["Capacity"] = Capacity;
        row["NoofTrucks"] = NoofTrucks;
        row["CostperTruck"] = CostperTruck;
      
        dt.Rows.Add(row);
        return dt;
    }

    private DataTable AddDataToFoundTable(string FromLocation, string ToLocation, string CustomerName, string Dateoftravel, string Producttype, string ProductCategory, string TravelDistance, string ProductName, string Quantity, string TravelType, string TruckType, string EnclosureType, string Capacity, string NoofTrucks, string CostperTruck, string Remarks, string TransitDay, string ClientPrice, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["From"] = FromLocation;
        row["To"] = ToLocation;
        row["CustomerName"] = CustomerName;
        row["DateofTravel"] = Dateoftravel;
        row["ProductType"] = Producttype;
        row["TravelDistance"] = ProductCategory ;
        row["ProductCategory"] = TravelDistance;
        row["ProductName"] = ProductName;
        row["Quantity"] = Quantity;
        row["TravelType"] = TravelType;
        row["TruckType"] = TruckType;
        row["EnclosureType"] = EnclosureType;
        row["Capacity"] = Capacity;
        row["NoofTrucks"] = NoofTrucks;
        row["CostperTruck"] = CostperTruck;
        row["Remarks"] = Remarks;
        row["TransitDay"] = TransitDay;
        row["ClientPrice"]=ClientPrice;
        dt.Rows.Add(row);
        return dt;
    }
    protected void cmdUploadAndDisplay_Click1(object sender, EventArgs e)
    {
  System.Threading.Thread.Sleep(1000);
  try
  {
      if (ExcelUpload.HasFile)
      {
          obj_FileName = ExcelUpload.PostedFile.FileName;
          ExcelUpload.SaveAs(Server.MapPath(@"temp\") + ExcelUpload.FileName);
          obj_Path = Server.MapPath(@"Excel\") + ExcelUpload.FileName;
          Session["obj_Path"] = Server.MapPath(@"temp\") + ExcelUpload.FileName;
      }
      string excelConnectionString = "";
      String Extension = System.IO.Path.GetExtension(ExcelUpload.PostedFile.FileName);
      try
      {
          switch (Extension)
          {
              case ".xls": //Excel 97-03
                //  excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath(@"Excel\" + ExcelUpload.FileName) + ";Extended Properties='Excel 8.0;HDR={1}'";
                  excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Session["obj_Path"].ToString() + ";Extended Properties='Excel 8.0;HDR={1}'";
                break;
              case ".xlsx": //Excel 07
                excelConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + Session["obj_Path"].ToString() + ";Extended Properties='Excel 8.0;HDR={1}'";
                  break;
          }
        //  Response.Write(Session["obj_Path"].ToString());
          OleDbConnection myExcelConnection = new OleDbConnection(excelConnectionString);
          myExcelConnection.Open();
          // Response.Write("connect");
          OleDbDataAdapter myAdapter = new OleDbDataAdapter("select * from [Sheet1$]", myExcelConnection);
          OleDbDataReader reader = myAdapter.SelectCommand.ExecuteReader();

          //Creating Data Table
          dt = CreateTempDataTable();
          while (reader.Read())
          {
              if (reader.ToString() != "")
              {
                  //AddDataToTable(obj_ClientID, obj_ClientName, obj_ClientAddressLocationID,obj_CustomerAddressLocationID, dt);
                  //TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(), reader.GetValue(13).ToString(),reader.GetValue(14).ToString(),reader.GetValue(15).ToString(), reader.GetValue(16).ToString(),dt);
                  TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(), reader.GetValue(13).ToString(), reader.GetValue(14).ToString(), reader.GetValue(15).ToString(), reader.GetValue(16).ToString(), reader.GetValue(17).ToString(), dt);

              }

          }
          reader.Close();
          reader.Dispose();
         
          myExcelConnection.Close();
        File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));

      }
      catch (Exception err)
      {

         File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));
      }
      FindProcess(TempDataTable);
  }
  catch (Exception ex)
  {
  }
    }
       
    
    public void FindProcess(DataTable tmpTable)
    {
       //Create Data Table
        dt2 = CreateDataTable();
       dt3 = CreateDataTable2();
        int ctr = 0;
        for (ctr = 0; ctr < tmpTable.Rows.Count; ctr++)
        {
            try
            {
                //Assigning and finding ID process
               obj_ClientID =Convert.ToInt32(Session["ClientID"].ToString());
               obj_UserID = Convert.ToInt32(Session["UserId"].ToString());
               obj_CustomerName=tmpTable.Rows[ctr][2].ToString();
               //obj_CustomerID = FindCustomerID(obj_CustomerName);
               obj_CustomerID = 1;
               obj_AarmsuserID = 0;
               obj_JunctionID = "0";
               obj_LocationTypeID = 1;//Check
               obj_FromLocation = tmpTable.Rows[ctr][0].ToString();
               obj_ToLocation = tmpTable.Rows[ctr][1].ToString();
             // obj_TravelDate = ValidateDate(tmpTable.Rows[ctr][3].ToString());
               obj_TravelDate = Convert.ToDateTime(tmpTable.Rows[ctr][3].ToString());
               //if (tmpTable.Rows[ctr][4].ToString() == "Solid")
               //{
               //    obj_ProductTypeID = 1;
               //}
               //else
               //{
               //    obj_ProductTypeID = 2;
               //}
               obj_ProductTypeID = 1;
               obj_ProductCategory = tmpTable.Rows[ctr][6].ToString();
              // obj_ProductCategorID = FindCategoryID(obj_ProductCategory);
               obj_ProductCategorID = 1;
               obj_ProductName = tmpTable.Rows[ctr][7].ToString();
              // obj_ProductID = FindProductID(obj_ProductName);
               obj_ProductID = 1;
                obj_Quantity =Convert.ToInt32(tmpTable.Rows[ctr][8].ToString());
               // if (tmpTable.Rows[ctr][8].ToString() == "One Way")
               //{
               //    obj_TravelTypeID  = 1;
               //}
               //else
               //{
               //    obj_TravelTypeID = 2;
               //}
                obj_TravelTypeID = 1;
                obj_TravelDistance = Convert.ToInt32(tmpTable.Rows[ctr][5].ToString());
                obj_TravelDistanceUnitID=0;
                obj_CostperTruck =Convert.ToInt32(tmpTable.Rows[ctr][14].ToString());
                obj_Weight=0;
                obj_WidthUnitID=0;
                obj_Length=0;
                obj_LengthUnitID =0;
                obj_Width=0;
                obj_WidthUnitID=0;
                obj_Height=0;
                obj_HeightUnitID=0;
                obj_Volume=0;
                obj_VolumeID=0;
              
                obj_QuantityperTruck = Convert.ToDouble (tmpTable.Rows[ctr][8].ToString());
                obj_TruckTypeID = FindTruckTypeID(tmpTable.Rows[ctr][10].ToString());
               // obj_TruckTypeID = 1;
                obj_NoofTrucks = Convert.ToInt32(tmpTable.Rows[ctr][13].ToString());
                //if (tmpTable.Rows[ctr][10].ToString() == "Open")
                //{
                //    obj_EnclosureTypeID = 1;
                //}
                //else
                //{
                //    obj_EnclosureTypeID = 2;
                //}
                obj_EnclosureTypeID = 2;
                obj_TruckBrandID =0;
                obj_TruckModelID = 0;
                obj_ShipmentID = 0;
                obj_TruckCapacity = Convert.ToDouble(tmpTable.Rows[ctr][12].ToString());
                obj_TruckCapacityUnit = 0;
                obj_TravelGroup = 0;
                obj_Comments = tmpTable.Rows[ctr][15].ToString();
                obj_TransitDay =Convert.ToInt16(tmpTable.Rows[ctr][16].ToString());
                obj_ClientPrice=Convert.ToInt32(tmpTable.Rows[ctr][17].ToString());
            }
            catch (Exception err)
            {
            }
            if (obj_ClientID == 0)
            {
                obj_ReasonForFailed = "Client Record Not Found in Database";

               // NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
                NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), obj_TravelDistance.ToString(), tmpTable.Rows[ctr][6].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), tmpTable.Rows[ctr][11].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
            }
            else if (obj_CustomerID == 0)
            {
                obj_ReasonForFailed = "Customer Record Not Found in Database";
               // NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
                NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), obj_TravelDistance.ToString(), tmpTable.Rows[ctr][6].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), tmpTable.Rows[ctr][11].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
            }

            else if (obj_ProductID == 0)
            {
                obj_ReasonForFailed = "Product Record Not Found in Database";
               // NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
                NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), obj_TravelDistance.ToString(), tmpTable.Rows[ctr][6].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), tmpTable.Rows[ctr][11].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
            }
            else if (obj_ProductCategorID == 0)
            {
                obj_ReasonForFailed = "Productcategory Record Not Found in Database";
              //  NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
                NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), obj_TravelDistance.ToString(), tmpTable.Rows[ctr][6].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), tmpTable.Rows[ctr][11].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
            }

            else if (obj_TruckTypeID == 0)
            {
                obj_ReasonForFailed = "Truck Type Record Not Found in Database";
              //  NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
                NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), obj_TravelDistance.ToString(), tmpTable.Rows[ctr][6].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), tmpTable.Rows[ctr][11].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
            }

            //else if(obj_TravelDate>DateTime.Now.Date )
            //{
            //     obj_ReasonForFailed = "Travel Date Should be greater than current date";
            //    NotFoundDataTable = AddDataToNotFoundTable(obj_ReasonForFailed, obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), dt2);
            //}
            else
            {
               // FoundDataTable = AddDataToFoundTable( obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), tmpTable.Rows[ctr][5].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][8].ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(),obj_Comments.ToString(),obj_TransitDay.ToString(), obj_ClientPrice.ToString(),dt3);
                FoundDataTable = AddDataToFoundTable(obj_FromLocation, obj_ToLocation, obj_CustomerName.ToString(), obj_TravelDate.ToString(), tmpTable.Rows[ctr][4].ToString(), obj_TravelDistance.ToString(), tmpTable.Rows[ctr][6].ToString(), obj_ProductName.ToString(), obj_Quantity.ToString(), tmpTable.Rows[ctr][9].ToString(), tmpTable.Rows[ctr][10].ToString(), tmpTable.Rows[ctr][11].ToString(), obj_TruckCapacity.ToString(), obj_NoofTrucks.ToString(), obj_CostperTruck.ToString(), obj_Comments.ToString(), obj_TransitDay.ToString(), obj_ClientPrice.ToString(), dt3);
            }
        }
        NotFoundGridview.DataSource = NotFoundDataTable;
        NotFoundGridview.DataBind();
      UploadGridview.DataSource = FoundDataTable;
      UploadGridview.DataBind();
      Upload.Enabled = true;
      lblRecordsFoundStatus.Text = FoundDataTable.Rows.Count.ToString() + " Valid Records";
      lblRecordsNotFoundStatus.Text = NotFoundDataTable.Rows.Count.ToString() + " Invalid Records ";

    }
    public void UploadProcess()
    {

        int ctr = 0;
        for (ctr = 0; ctr < UploadGridview.Rows.Count; ctr++)
        {
            try
            {
                //Assigning and finding ID process
                obj_ClientID = Convert.ToInt32(Session["ClientID"].ToString());
                obj_UserID = Convert.ToInt32(Session["UserId"].ToString());
                obj_CustomerName = UploadGridview.Rows[ctr].Cells[2].Text;
               // obj_CustomerID = FindCustomerID(obj_CustomerName);
                obj_CustomerID = 1;
                obj_AarmsuserID = 0;
                obj_JunctionID = "0";
                obj_LocationTypeID = 1;//Check
                obj_FromLocation = UploadGridview.Rows[ctr].Cells[0].Text;
                obj_ToLocation = UploadGridview.Rows[ctr].Cells[1].Text;
                // obj_TravelDate = ValidateDate(tmpTable.Rows[ctr][3].ToString());
                obj_TravelDate = Convert.ToDateTime(UploadGridview.Rows[ctr].Cells[3].Text);
                //if (UploadGridview.Rows[ctr].Cells[4].Text == "Solid")
                //{
                //    obj_ProductTypeID = 1;
                //}
                //else
                //{
                //    obj_ProductTypeID = 2;
                //}
                obj_ProductTypeID = 1;
                obj_ProductCategory = UploadGridview.Rows[ctr].Cells[6].Text;
                //obj_ProductCategorID = FindCategoryID(obj_ProductCategory);
                obj_ProductCategorID = 1;
                obj_ProductName = UploadGridview.Rows[ctr].Cells[7].Text;
                //obj_ProductID = FindProductID(obj_ProductName);
                obj_ProductID = 1;
                obj_Quantity = Convert.ToInt32(UploadGridview.Rows[ctr].Cells[8].Text);
                //if (UploadGridview.Rows[ctr].Cells[8].Text == "One Way")
                //{
                //    obj_TravelTypeID = 1;
                //}
                //else
                //{
                //    obj_TravelTypeID = 2;
                //}
                obj_TravelTypeID = 1;
                obj_TravelDistance = Convert.ToInt32(UploadGridview.Rows[ctr].Cells[5].Text);
                obj_TravelDistanceUnitID = 0;
                obj_CostperTruck = Convert.ToInt32(UploadGridview.Rows[ctr].Cells[14].Text);
                obj_Weight = 0;
                obj_WidthUnitID = 0;
                obj_Length = 0;
                obj_LengthUnitID = 0;
                obj_Width = 0;
                obj_WidthUnitID = 0;
                obj_Height = 0;
                obj_HeightUnitID = 0;
                obj_Volume = 0;
                obj_VolumeID = 0;
                obj_NoofTrucks = Convert.ToInt32(UploadGridview.Rows[ctr].Cells[13].Text);
                obj_QuantityperTruck = Convert.ToDouble(UploadGridview.Rows[ctr].Cells[12].Text);
                obj_TruckTypeID = FindTruckTypeID(UploadGridview.Rows[ctr].Cells[10].Text);
                //obj_TruckTypeID = 1;
                if (UploadGridview.Rows[ctr].Cells[11].Text == "Open")
                {
                    obj_EnclosureTypeID = 1;
                }
                else
                {
                    obj_EnclosureTypeID = 2;
                }
                //obj_EnclosureTypeID = Convert.ToInt16(UploadGridview.Rows[ctr].Cells[10].Text);
                obj_TruckBrandID = 0;
                obj_TruckModelID = 0;
                obj_ShipmentID = 0;
                obj_TruckCapacity = Convert.ToDouble(UploadGridview.Rows[ctr].Cells[12].Text);
                obj_TruckCapacityUnit = 0;
                obj_TravelGroup = 0;
                obj_Comments = UploadGridview.Rows[ctr].Cells[15].Text;
                obj_TransitDay = Convert.ToInt16 (UploadGridview.Rows[ctr].Cells[16].Text);
                obj_ClientPrice= Convert.ToInt16(UploadGridview.Rows[ctr].Cells[17].Text);
            }
            catch (Exception err)
            {
            }

            //Insert into Logistics plan
            int resp = 0;

            GenerateRandomString();
            resp = obj_BizConnectLogisticsPlanClass.Insert_LogisticsPlan(Session["LogisticsPlan"].ToString(), Convert.ToInt32(obj_ClientID), Convert.ToInt32(obj_UserID), Convert.ToInt32(obj_CustomerID), Convert.ToInt32(obj_AarmsuserID), Convert.ToString(obj_JunctionID), obj_LocationTypeID, Convert.ToString(obj_FromLocation), Convert.ToString(obj_ToLocation), Convert.ToDateTime(obj_TravelDate), Convert.ToInt32(obj_ProductTypeID.ToString()), Convert.ToInt32(obj_ProductCategorID.ToString()), Convert.ToInt32(obj_ProductID), Convert.ToString(obj_ProductName), Convert.ToDouble(obj_Quantity), Convert.ToInt32(obj_TravelTypeID), Convert.ToInt32(obj_TravelDistance), Convert.ToInt32(obj_TravelDistanceUnitID), Convert.ToDouble(obj_CostperTruck), Convert.ToDouble(obj_Weight), Convert.ToInt32(obj_WeightUnitID), Convert.ToDouble(obj_Length), Convert.ToInt32(obj_LengthUnitID), Convert.ToDouble(obj_Width), Convert.ToInt32(obj_WidthUnitID), Convert.ToDouble(obj_Height), Convert.ToInt32(obj_HeightUnitID), Convert.ToDouble(obj_Volume), Convert.ToInt32(obj_VolumeID), Convert.ToInt32(obj_NoofTrucks), Convert.ToDouble(obj_QuantityperTruck), Convert.ToInt32(obj_TruckTypeID), Convert.ToInt32(obj_EnclosureTypeID), Convert.ToInt32(obj_TruckBrandID), Convert.ToInt32(obj_TruckModelID), 0, Convert.ToDouble(obj_TruckCapacity), Convert.ToInt32(obj_TruckCapacityUnit), 0, Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToDateTime(obj_TravelDate), Convert.ToString(obj_Comments), 0, 1,Convert.ToInt32(obj_TransitDay.ToString()),Convert.ToString(obj_ToLocation),Convert.ToInt32(obj_ClientPrice.ToString()));

            if (resp == 1)
            {
                obj_ShipmentType = 1;
                //Insert client Record in Shipment Master
                ArrayList arr = new ArrayList();
                arr = obj_FindID.FindClientDetails(Convert.ToInt32(Session["ClientID"].ToString()), 1);
                if (arr[0].ToString() != "0")
                {
                    obj_FromFirstName = arr[0].ToString();
                    obj_FromMiddleName = "Null";
                    obj_FromLastName = "Null";
                    obj_FromCity = arr[1].ToString();
                    obj_FromAddress = arr[2].ToString();
                    obj_FromState = arr[3].ToString();
                    obj_FromCountry = arr[4].ToString();
                    obj_FromPinCode = Convert.ToInt32(arr[5].ToString());
                    obj_FromBoardNumber = arr[6].ToString();
                    obj_FromFax = arr[7].ToString();
                    obj_FromCorporateEmail = arr[8].ToString();
                



                obj_LogisticsPlanID = Convert.ToInt32(Session["LogisticsPlanID"]);
                obj_BizConnectLogisticsPlanClass.Insert_Shipment(obj_LogisticsPlanID, obj_ShipmentType, obj_FromFirstName, obj_FromMiddleName, obj_FromLastName, obj_FromCity, obj_FromAddress, obj_FromState, obj_FromCountry, obj_FromPinCode, obj_FromBoardNumber, obj_FromFax, obj_FromCorporateEmail, 1);
               
                }
                obj_ShipmentType = 2;
                //Insert customer Record in Shipment Master
                ArrayList arr1 = new ArrayList();
                arr1 = obj_FindID.FindCustomerDetails(obj_CustomerID, 5);
                if (arr1[0].ToString() != "0")
                {
                    obj_FromFirstName = arr1[0].ToString();
                    obj_FromMiddleName = "Null";
                    obj_FromLastName = "Null";
                    obj_FromCity = arr1[1].ToString();
                    obj_FromAddress = arr1[2].ToString();
                    obj_FromState = arr1[3].ToString();
                    obj_FromCountry = arr1[4].ToString();
                    obj_FromPinCode = Convert.ToInt32(arr1[5].ToString());
                    obj_FromBoardNumber = arr1[6].ToString();
                    obj_FromFax = arr1[7].ToString();
                    obj_FromCorporateEmail = arr1[8].ToString();
                    obj_BizConnectLogisticsPlanClass.Insert_Shipment(obj_LogisticsPlanID, obj_ShipmentType, obj_FromFirstName, obj_FromMiddleName, obj_FromLastName, obj_FromCity, obj_FromAddress, obj_FromState, obj_FromCountry, obj_FromPinCode, obj_FromBoardNumber, obj_FromFax, obj_FromCorporateEmail, 1);


                }
            }

        }

        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('ADs Posted Successfully');</script>");


    }
    protected void Upload_Click(object sender, EventArgs e)
    {
        try
        {
            UploadProcess();
        }
        catch (Exception ex)
        {
        }
    }


    //Generate String Randomly
    public void GenerateRandomString()
    {
        DateTime obj_CurrentDate;
        obj_CurrentDate = DateTime.Now.Date;
        String obj_DateStr;
        obj_DateStr = obj_CurrentDate.ToString("ddMMyyyy");
        String obj_LogosticsPlanString = "";
        obj_LogosticsPlanString = RandomString(4, false) + '-';

        int obj_LogisticsPlanID = obj_BizConnectLogisticsPlanClass.get_MaxLogisticsPlanID();
        Session["LogisticsPlanID"] = 0;
        Session["LogisticsPlanID"] = obj_LogisticsPlanID;
        obj_LogosticsPlanString += obj_DateStr + "-" + obj_LogisticsPlanID.ToString();
        Session["LogisticsPlan"] = obj_LogosticsPlanString;
       
    }

    //Random Generation of String
    private string RandomString(int size, bool lowerCase)
    {
        StringBuilder builder = new StringBuilder();
        Random random = new Random();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }
        if (lowerCase)
            return builder.ToString().ToLower();
        return builder.ToString();
    }

    //Finding Customer ID
    public int FindCustomerID(String obj_Customername)
    {
        //Int32 obj_ClientID = 0;
        ArrayList arr = new ArrayList();
        arr = obj_FindID.FindCustomerID (obj_Customername);
        if (arr[0].ToString() != "0")
        {
            obj_CustomerID  = Convert.ToInt32 (arr[0].ToString());
        }
        else
        {
            obj_CustomerID = 0;
        }
        return obj_CustomerID;
    }
    //Finding Product ID
    public int FindProductID(String obj_Productname)
    {
        //Int32 obj_ClientID = 0;
        ArrayList arr = new ArrayList();
        arr = obj_FindID.FindProductID (obj_Productname);
        if (arr[0].ToString() != "0")
        {
            obj_ProductID  = Convert.ToInt32(arr[0].ToString());
        }
        else
        {
            obj_ProductID = 0;
        }
        return obj_ProductID;
    }
    //Finding Category ID
    public int FindCategoryID(String obj_Categoryname)
    {
        
        ArrayList arr = new ArrayList();
        arr = obj_FindID.FindCategoryID(obj_Categoryname);
        if (arr[0].ToString() != "0")
        {
            obj_ProductCategorID = Convert.ToInt32(arr[0].ToString());
        }
        else
        {
            obj_ProductCategorID = 0;
        }
        return obj_ProductCategorID;
    }
    //Finding Truck ID
    public int FindTruckTypeID(String obj_Truckname)
    {

        ArrayList arr = new ArrayList();
        arr = obj_FindID.FindTruckTypeID(obj_Truckname);
        if (arr[0].ToString() != "0")
        {
            obj_TruckTypeID   = Convert.ToInt32(arr[0].ToString());
        }
        else
        {
            obj_TruckTypeID = 0;
        }
        return obj_TruckTypeID;
    }

    //Validate Invoice Date
    public Int32 ValidateDate(string obj_Date)
    {
        DateTime temp_Date;
        temp_Date = DateTime.Parse(obj_Date, System.Globalization.CultureInfo.CreateSpecificCulture("en-AU").DateTimeFormat);
        Int32 obj_Resp = 0;
        try
        {
            // for US, alter to suit if splitting on hyphen, comma, etc.
            string[] dateParts = temp_Date.ToString("dd/MM/yyyy").Split('/');

            // create new date from the parts; if this does not fail
            // the method will return true and the date is valid
            DateTime testDate = new
            DateTime(Convert.ToInt32(dateParts[2]),
            Convert.ToInt32(dateParts[0]),
            Convert.ToInt32(dateParts[1]));

            obj_Resp = 1;
        }
        catch (Exception err)
        {
            // if a test date cannot be created, the
            // method will return false
            obj_Resp = 0;
        }

        return obj_Resp;
    }
    private DataTable CreateDataTable()
    {

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Reason";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "From";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "To";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CustomerName";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DateofTravel";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductType";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelDistance";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductCategory";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductName";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Quantity";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelType";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TruckType";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "EnclosureType";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Capacity";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "NoofTrucks";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CostperTruck";
        myDataTable.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Remarks";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TransitDay";
        myDataTable.Columns.Add(myDataColumn);
        
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ClientPrice";
        myDataTable.Columns.Add(myDataColumn);
        
        
        return myDataTable;
        
        
        
    }
    private DataTable CreateDataTable2()
    {

       

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "From";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "To";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CustomerName";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DateofTravel";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductType";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelDistance";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductCategory";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProductName";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Quantity";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelType";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TruckType";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "EnclosureType";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Capacity";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "NoofTrucks";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "CostperTruck";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Remarks";
        myDataTable3.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TransitDay";
        myDataTable3.Columns.Add(myDataColumn);
        
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ClientPrice";
        myDataTable3.Columns.Add(myDataColumn);

        return myDataTable3;
    }
    protected void NotFoundGridview_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[0].ForeColor = System.Drawing.Color.Red;
        }
    }


    protected void ButSendMail_Click(object sender, EventArgs e)
    {
        try
        {
            DataSet ds = new DataSet();
            
            ds=obj_mail.MailForReBidPriceToTransporter();
        }
        catch (Exception ex)
        {
        }
    }

    public int SendMail(DataSet ds)
    {
        try
        {
            //Email Settings from Web Config
            string obj_FromEmail = ConfigurationManager.AppSettings.Get("fromemailid").ToString();
            string obj_BounceBakEmail = ConfigurationManager.AppSettings.Get("bouncebakemailid").ToString();
            string obj_ServerName = ConfigurationManager.AppSettings.Get("Server").ToString();
            string obj_Password = ConfigurationManager.AppSettings.Get("Password").ToString();
            string obj_PortNo = ConfigurationManager.AppSettings.Get("PortNo").ToString();
            string obj_AuthenticateMode = ConfigurationManager.AppSettings.Get("AuthenticateMode").ToString();
            string obj_SendUsingPort = ConfigurationManager.AppSettings.Get("SendUsingPort").ToString();
            string obj_SMTPUseSSL = ConfigurationManager.AppSettings.Get("SMTPUseSSL").ToString();
            Boolean SMTPUseSSL;
            string obj_AttachmentPath = ConfigurationManager.AppSettings.Get("AttachmentPath").ToString();
            string obj_Message = "";
            string BodyMiddle = "";
            string BodyHeader = "";
         string Transportername="";
              string obj_EmailID ="";
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {
                 obj_EmailID = ds.Tables[0].Rows[i].ItemArray[9].ToString();
                obj_Message = "Dear Sir/Madam,<br/>Many thanks for your Bid against the Quotes.  We have given the Rebid price as indicated by the Client for each routes for your perusal.We request you to confirm acceptance to the Rebid Price. Alternatively, you can give your best price for accepting the Bid.</b></br> <b> </b> <br/><br/>Thank You,<br/>Web Master,<br> SCM Junction<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
                BodyHeader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><font size=2 color=#003366><strong>Client Rebid Price</font></strong></td></tr>";
                Transportername = ds.Tables[0].Rows[i].ItemArray[8].ToString();
              
                  
                   BodyMiddle += "<tr><td align=center><<font size=2>" + ds.Tables[0].Rows[i].ItemArray[1].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[2].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[5].ToString() + "</font></td><td align=center><font size=2>" + ds.Tables[0].Rows[i].ItemArray[4].ToString() + "</font></td></tr>";

               }



                //Declaration Section for AARMEmail Control
                AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "New ADs posted in scmjunction", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                obj_resp = 1;
               
            }
           
       
        catch (Exception ex)
        {
        }
        return 0;
    }

}
