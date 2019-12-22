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


public partial class UploadIndent : System.Web.UI.Page
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
    ProjectBased obj_Class = new ProjectBased();
    string obj_FileName, obj_Path;
    DataTable dt_CheckAccess = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            ChkAuthentication();
            dt_CheckAccess = obj_Class.Bizconnect_GetAccessPermitedUsers(Convert.ToInt32(Session["UserID"].ToString()));
            if (dt_CheckAccess.Rows.Count == 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Access Denied');</script>");
                pnl_Indent.Visible = false;
            }
            else
            {
                pnl_Indent.Visible = true;
            }
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
    protected void btn_UploadAndDisplay_Click1(object sender, EventArgs e)
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
                        TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(),
                            reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(),
                            reader.GetValue(9).ToString(),reader.GetValue(10).ToString(),reader.GetValue(11).ToString(),reader.GetValue(12).ToString(),reader.GetValue(13).ToString(),
                            reader.GetValue(14).ToString(),Convert.ToInt32(reader.GetValue(15).ToString()), dt);
                    }

                }
                reader.Dispose();
                reader.Close();
                grd_DisplayUploadfile.DataSource = TempDataTable;
                grd_DisplayUploadfile.DataBind();
                myExcelConnection.Close();
                btn_Upload.Enabled = true;
                File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));

            }
            catch (Exception err)
            {

                File.Delete(Server.MapPath(@"temp\" + ExcelUpload.FileName));
            }
        }
        catch (Exception ex)
        {
        }
    }

    private DataTable CreateTempDataTable()
    {
        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ProjNo";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "WBS";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DESCRIPTION";
        myDataTable.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Qty";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Unit";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DespatchPlace";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DeliveryPlace";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TotalWt.";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Length_M";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Width_M";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Height_M";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TruckType";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TrucksPlan";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "SlNo";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "IndentAmnt";
        myDataTable.Columns.Add(myDataColumn);
     
        
         myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TransitDays";
        myDataTable.Columns.Add(myDataColumn);
        return myDataTable;
        
    }
    private DataTable AddDataToTempTable(string ProjectNo, string WBS, string DESCRIPTION, string Qty, string Unit, string PlaceofDespatch, string PlaceofDelivery, string TotalWeightinTon, string Length_M, string Width_M,string Height_M,string TruckType,string TrucksPlanned,string SerialNo,string IndentAmount,int TransitDays, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["ProjNo"] = ProjectNo;
        row["WBS"] = WBS;
        row["DESCRIPTION"] = DESCRIPTION;
        row["Qty"] = Qty;
        row["Unit"] = Unit;
        row["DespatchPlace"] = PlaceofDespatch;
        row["DeliveryPlace"] = PlaceofDelivery;
        row["TotalWt."] = TotalWeightinTon;

        row["Length_M"] = Length_M;
        row["Width_M"] = Width_M;
        row["Height_M"] = Height_M;

        row["TruckType"] = TruckType;
        row["TrucksPlan"] = TrucksPlanned;
        row["SlNo"] = SerialNo;
        row["IndentAmnt"] = IndentAmount;
        row["TransitDays"] = TransitDays;
        dt.Rows.Add(row);
        return dt;
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            UploadProcess();
        }
        catch { }
    }

    public void UploadProcess()
    {
        try
        {
            int ctr = 0;
            for (ctr = 0; ctr < grd_DisplayUploadfile.Rows.Count; ctr++)
            {

                SqlConnection con = new SqlConnection(constr);
                con.Open();
                SqlCommand cmd = new SqlCommand("Bizconnect_InsertTripIndent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ProjectNo", grd_DisplayUploadfile.Rows[ctr].Cells[0].Text);
                cmd.Parameters.AddWithValue("@WBS", grd_DisplayUploadfile.Rows[ctr].Cells[1].Text);
                cmd.Parameters.AddWithValue("@Description", grd_DisplayUploadfile.Rows[ctr].Cells[2].Text);
                cmd.Parameters.AddWithValue("@Qty", grd_DisplayUploadfile.Rows[ctr].Cells[3].Text);
                cmd.Parameters.AddWithValue("@Unit", grd_DisplayUploadfile.Rows[ctr].Cells[4].Text);
                cmd.Parameters.AddWithValue("@PlaceofDespatch", grd_DisplayUploadfile.Rows[ctr].Cells[5].Text);
                cmd.Parameters.AddWithValue("@PlaceofDelivery",grd_DisplayUploadfile.Rows[ctr].Cells[6].Text);
                cmd.Parameters.AddWithValue("@TotalWeightinTon", grd_DisplayUploadfile.Rows[ctr].Cells[7].Text);
                cmd.Parameters.AddWithValue("@Length_M", grd_DisplayUploadfile.Rows[ctr].Cells[8].Text);
                cmd.Parameters.AddWithValue("@Width_M", grd_DisplayUploadfile.Rows[ctr].Cells[9].Text);
                cmd.Parameters.AddWithValue("@Height_M", grd_DisplayUploadfile.Rows[ctr].Cells[10].Text);
                cmd.Parameters.AddWithValue("@TruckType", grd_DisplayUploadfile.Rows[ctr].Cells[11].Text);
                cmd.Parameters.AddWithValue("@TruckdPlanned", grd_DisplayUploadfile.Rows[ctr].Cells[12].Text);
                cmd.Parameters.AddWithValue("@SerialNo", grd_DisplayUploadfile.Rows[ctr].Cells[13].Text);
                cmd.Parameters.AddWithValue("@IndentAmount", grd_DisplayUploadfile.Rows[ctr].Cells[14].Text);
                 cmd.Parameters.AddWithValue("@TransitDays", grd_DisplayUploadfile.Rows[ctr].Cells[15].Text);
                cmd.ExecuteNonQuery();
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Data Uploaded Successfully !');</script>");
        }

        catch (Exception ex)
        {
        }

    }
}