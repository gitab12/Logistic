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

public partial class MultipleRoutePriceUpload : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataColumn myDataColumn;
    DataTable dt = new DataTable();
    string constr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    DataTable TempDataTable = new DataTable();
    DataTable myDataTable = new DataTable();
  
    DataTable FoundDataTable = new DataTable();
 
    string obj_FileName, obj_Path;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            ChkAuthentication();
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
                OleDbDataAdapter myAdapter = new OleDbDataAdapter("select * from [Sheet1$]", myExcelConnection);
                OleDbDataReader reader = myAdapter.SelectCommand.ExecuteReader();

                //Creating Data Table
                dt = CreateTempDataTable();
                while (reader.Read())
                {
                    if (reader.ToString() != "")
                    {
                        //AddDataToTable(obj_ClientID, obj_ClientName, obj_ClientAddressLocationID,obj_CustomerAddressLocationID, dt);
                        TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(), reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(), reader.GetValue(9).ToString(), dt);

                    }

                }
                reader.Dispose();
                reader.Close();
                UploadGridview.DataSource = TempDataTable;
                UploadGridview.DataBind();
                myExcelConnection.Close();
                Upload.Enabled = true;
                File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));

            }
            catch (Exception err)
            {

                File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));
            }
           // FindProcess(TempDataTable);
        }
        catch (Exception ex)
        {
        }
    }

    private DataTable CreateTempDataTable()
    {

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Transporter_ID";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Transporter_Name";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "From_loc";
        myDataTable.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "To_loc";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Truck_Type_ID";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Enclosure_type";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Capacity";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Unit";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Oneway_Price";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Twoway_Price";
        myDataTable.Columns.Add(myDataColumn);

       

        return myDataTable;
    }
    private DataTable AddDataToTempTable(string TransporterID, string TransporterName, string FromLoc, string ToLoc,  string TruckType, string EnclosureType, string Capacity, string Unit, string Onewayprice, string Twowayprice, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["Transporter_ID"] = TransporterID;
        row["Transporter_Name"] = TransporterName;
        row["From_loc"] = FromLoc;
        row["To_loc"] = ToLoc;
        row["Truck_Type_ID"] = TruckType;
        row["Enclosure_type"] = EnclosureType;
        row["Capacity"] = Capacity;
        row["Unit"] = Unit;

        row["Oneway_Price"] = Onewayprice;
        row["Twoway_Price"] = Twowayprice;
        dt.Rows.Add(row);
        return dt;
    }


    protected void Upload_Click(object sender, EventArgs e)
    {
        try
        {
            UploadProcess();
        }
        catch {}
    }


    public void UploadProcess()
    {
        try
            {
        int ctr = 0;
        for (ctr = 0; ctr < UploadGridview.Rows.Count; ctr++)
        {
            
                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Insert_BizConnect_routeprice", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Transporter_ID", UploadGridview.Rows[ctr].Cells[0].Text);
                cmd.Parameters.AddWithValue("@Transporter_Name", UploadGridview.Rows[ctr].Cells[1].Text);
                cmd.Parameters.AddWithValue("@From_Loc", UploadGridview.Rows[ctr].Cells[2].Text);
                cmd.Parameters.AddWithValue("@To_Loc", UploadGridview.Rows[ctr].Cells[3].Text);
                cmd.Parameters.AddWithValue("@Trucktype_ID", UploadGridview.Rows[ctr].Cells[4].Text);
                cmd.Parameters.AddWithValue("@Enclosure_ID", UploadGridview.Rows[ctr].Cells[5].Text);
                cmd.Parameters.AddWithValue("@Capacity",Convert.ToDouble(UploadGridview.Rows[ctr].Cells[6].Text));
                cmd.Parameters.AddWithValue("@Unit", UploadGridview.Rows[ctr].Cells[7].Text);
                cmd.Parameters.AddWithValue("@Oneway_price", UploadGridview.Rows[ctr].Cells[8].Text);
                cmd.Parameters.AddWithValue("@Toway_price", UploadGridview.Rows[ctr].Cells[9].Text);
                cmd.ExecuteNonQuery();



           
        }
        ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Upload Successfully !');</script>");
            }

        catch (Exception ex)
        {
        }

    }
}
