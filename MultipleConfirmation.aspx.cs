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
using System.Net;


public partial class MultipleConfirmation : System.Web.UI.Page
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

    TripAssignment Trip_Assign = new TripAssignment();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    int res = 0;
    DataTable dt_Email = new DataTable();
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            if (Convert.ToInt32(Session["UserID"].ToString()) > 0)
            {
                ChkAuthentication();
            }
            else
            {
                Response.Redirect("~/Index.html");
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
                        //TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(),
                           // reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(),
                           // reader.GetValue(9).ToString(), reader.GetValue(10).ToString(),reader.GetValue(11).ToString(),reader.GetValue(12).ToString() ,dt);

                        TempDataTable = AddDataToTempTable(reader.GetValue(0).ToString(), reader.GetValue(1).ToString(), reader.GetValue(2).ToString(), reader.GetValue(3).ToString(),
                           reader.GetValue(4).ToString(), reader.GetValue(5).ToString(), reader.GetValue(6).ToString(), reader.GetValue(7).ToString(), reader.GetValue(8).ToString(),
                           reader.GetValue(9).ToString(), reader.GetValue(10).ToString(), reader.GetValue(11).ToString(), reader.GetValue(12).ToString(),reader.GetValue(13).ToString(), dt);
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
        myDataColumn.ColumnName = "FromLocation";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "ToLocation";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TruckType";
        myDataTable.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "EnclType";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "Capacity";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "QuotedPrice";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "DecidePrice";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TransporterID";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "NoofTrucksReq";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TravelDate";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "TruckPlacementdatetime";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "City";
        myDataTable.Columns.Add(myDataColumn);

        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "PostID";
        myDataTable.Columns.Add(myDataColumn);


        myDataColumn = new DataColumn();
        myDataColumn.DataType = Type.GetType("System.String");
        myDataColumn.ColumnName = "AgreementRouteID";
        myDataTable.Columns.Add(myDataColumn);
        
        return myDataTable;

    }
    private DataTable AddDataToTempTable(string FromLoc, string ToLoc, string TruckType, string EnclType, string Capacity,string QuotedPrice, string DecidePrice, string TransporterID, string NoofTrucksReq, string TravelDate, string TruckPlacementdatetime, string City,string PostID,string AgreementRouteID, DataTable dt)
    {
        DataRow row;
        row = dt.NewRow();
        row["FromLocation"] = FromLoc;
        row["ToLocation"] = ToLoc;
        row["TruckType"] = TruckType;
        row["EnclType"] = EnclType;
        row["Capacity"] = Capacity;
        row["QuotedPrice"]=QuotedPrice;
        row["DecidePrice"] = DecidePrice;
        row["TransporterID"] = TransporterID;
        row["NoofTrucksReq"] = NoofTrucksReq;
        row["TravelDate"] = TravelDate;
        row["TruckPlacementdatetime"] = TruckPlacementdatetime;
        row["City"] = City;
        row["PostID"] = PostID;
        row["AgreementRouteID"] = AgreementRouteID;
        dt.Rows.Add(row);
        return dt;
    }

    protected void btn_Upload_Click(object sender, EventArgs e)
    {
        try
        {
            //UploadProcess();
            if (Convert.ToInt32(Session["UserID"].ToString()) > 0)
            {
                InsertIntoTripAssingtable();
            }
            else
            {
                Response.Redirect("~/Index.html");
            }
        }
        catch { }
    }

    public void InsertIntoTripAssingtable()
    {
        try
        {
            for (int ctr = 0; ctr < grd_DisplayUploadfile.Rows.Count; ctr++)
            {

                for (int i = 0; i < Convert.ToInt32(grd_DisplayUploadfile.Rows[ctr].Cells[7].Text); i++)
                {
                   // res = Trip_Assign.Bizconnect_InsertTripAssign(Convert.ToInt32(grd_DisplayUploadfile.Rows[ctr].Cells[12].Text), grd_DisplayUploadfile.Rows[ctr].Cells[0].Text, grd_DisplayUploadfile.Rows[ctr].Cells[1].Text, grd_DisplayUploadfile.Rows[ctr].Cells[2].Text, grd_DisplayUploadfile.Rows[ctr].Cells[3].Text, grd_DisplayUploadfile.Rows[ctr].Cells[4].Text, Convert.ToInt32(grd_DisplayUploadfile.Rows[ctr].Cells[5].Text), Convert.ToInt32(grd_DisplayUploadfile.Rows[ctr].Cells[6].Text), 1, Convert.ToDateTime(grd_DisplayUploadfile.Rows[ctr].Cells[8].Text), "12 PM", Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(grd_DisplayUploadfile.Rows[ctr].Cells[11].Text));
                    string[] args = { "@agreementrouteid", "@fromlocation", "@tolocation", "@trucktype", "@enclosuretype", "@capacity", "@decideprice", "@quoteprice", "@transporterid", "@truckreq", "@traveldate", "@traveltime", "@userid", "@logisticsplanid" };
                    string[] argsval = { grd_DisplayUploadfile.Rows[ctr].Cells[12].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[0].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[1].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[2].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[3].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[4].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[6].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[5].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[7].ToString(), "1", grd_DisplayUploadfile.Rows[ctr].Cells[8].ToString(), "12 PM", Session["UserID"].ToString(), grd_DisplayUploadfile.Rows[ctr].Cells[12].ToString() };
                    res = con.Sql_ExecuteNonQuery("Bizconnect_Insert_TripAssign", args, argsval);
                }
                    if (res == 1)
                    {
                        //Email Portion
                        string tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>DecidedPrice</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Time</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>VehiclePlacementTime</strong></font></td></tr>";
                        string mailbody = "Dear Sir/Madam,<br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";
                        dt_Email = Trip_Assign.Bizconnect_GetTransporterEmailIDForSendingTripConfirmMail(Convert.ToInt32(grd_DisplayUploadfile.Rows[ctr].Cells[6].Text));
                        string Email = dt_Email.Rows[0][0].ToString();
                        string body = "<tr><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[0].Text + "</font></td><td align=center><font size=2 >" + grd_DisplayUploadfile.Rows[ctr].Cells[1].Text + "</font></td><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[2].Text + "" + "/" + "" + grd_DisplayUploadfile.Rows[ctr].Cells[3].Text + "</font></td><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[6].Text + "</font></td><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[4].Text + "</font></td><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[8].Text + "</font></td><td align=center><font size=2>12:9Pm</font></td><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[9].Text + "</font></td><td align=center><font size=2>" + grd_DisplayUploadfile.Rows[ctr].Cells[10].Text + "</font></td></tr>";
                        body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + grd_DisplayUploadfile.Rows[ctr].Cells[7].Text + "&ClID=" + Session["ClientID"].ToString() + "&AGID=0>Click Here to Confirm the Routes</a> <br/><br/>Regards,<br/>ScmBizconnect Team."; ;
                        //mail.SendEmail(Email, "godrej@scmbizconnect.com", "godrej123", "rajendar@godrej.com", "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                    //    mail.SendEmail(lblEmail.Text, fromID.ToString(), password.ToString(), "", "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                        mail.SendEmail(Email, "tripschedule@scmbizconnect.com", "tripschedule123", "rajendar@godrej.com", "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                        //mail.SendEmail("krishna@aarmsvaluechain.com", "godrej@scmbizconnect.com", "godrej123", "", "", "", "", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                        // mail.SendEmail("nandha@aarmscmsolutions.com", "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                    }
                    if (res == 1)
                    {
                        //Sending SMS to Transporters mobile no
                        try
                        {
                            string result="";
                            string mobile1 = dt_Email.Rows[0][1].ToString();
                            string message1 = "Dear Transporter your route to " + grd_DisplayUploadfile.Rows[ctr].Cells[10].Text + "(" + grd_DisplayUploadfile.Rows[ctr].Cells[2].Text + ") has confirmed for Rs." + grd_DisplayUploadfile.Rows[ctr].Cells[5].Text + " and placement date on " + grd_DisplayUploadfile.Rows[ctr].Cells[9].Text + "";
                            string username1 = "aarmscm";
                            string password1 = "demo1234";
                            string senderid = "AARMSA";
                            string domian1 = "sms.cannyinfotech.com";
                            if (mobile1 != "")
                            {
                               result = apicall("http://" + domian1 + "/sendsms.jsp?user=" + username1 + "&password=" + password1 + "&mobiles=91" + mobile1 + "&sms=" + message1 + "&unicode=0&senderid=" + senderid + "&version=3");
                            }
                            if (!result.StartsWith("Wrong Username or Password"))
                            {
                            }
                            else
                            {
                            }
                        }
                        catch
                        {
                        }
                    }
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('All Trips Assigned Successfully');</script>");
            grd_DisplayUploadfile.DataSource = null;
            grd_DisplayUploadfile.DataBind();
        }
        catch (Exception ex)
        {

        }
    }

    public string apicall(string url)
    {
        HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
        try
        {
            HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
            StreamReader sr = new StreamReader(httpres.GetResponseStream());
            string results = sr.ReadToEnd();
            sr.Close();
            return results;
        }
        catch
        {
            return "0";
        }
    }

}