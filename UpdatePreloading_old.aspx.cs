using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;
using AjaxControlToolkit;
using System.Globalization;
using System.Threading;

public partial class UpdatePreloading : System.Web.UI.Page
{
    string obj_Authenticated;
    PlaceHolder maPlaceHolder;
    UserControl obj_Tabs;
    UserControl obj_LoginCtrl;
    UserControl obj_WelcomCtrl;
    UserControl obj_Navi;
    UserControl obj_Navihome;
    DataSet ds = new DataSet();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    string Email = "";
    string toemail;
    string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    TripAcceptance obj_class = new TripAcceptance();
    ClientsReport obj_Class2 = new ClientsReport();
    DataTable dt = new DataTable();
    byte[] bytes1, bytes2, bytes3, bytes4;
    string ext, filename;
    EncryptAndDecryot obj = new EncryptAndDecryot();
    string imagePath = "", WBSNo;
    InvoiceClass obj_InvoiceBill = new InvoiceClass();
    int InvoiceID, AcceptID, resp, AcptID, ClientID, ClientAddLocID;
    DataSet ds_InvoiceID = new DataSet();
    DateTime Expectdt = new DateTime();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            MultipleUploadClass.staticvar = "";
            ChkAuthentication();
            AcceptID = Convert.ToInt32(Request.QueryString["AcptID"]);
            LoadDetails();
        }
    }
    public void LoadDetails()
    {
        try
        {
            if (Convert.ToInt32(Session["ClientID"].ToString()) > 0 && Convert.ToInt32(Session["ClientAdrID"].ToString()) > 0)
            {
                 dt = obj_class.Get_PreloadingDetailsByAcceptanceID(Convert.ToInt32(Session["ClientID"].ToString()), Convert.ToInt32(Session["ClientAdrID"].ToString()), AcceptID);
                if (dt.Rows.Count > 0)
                {
                    Gridwindow.DataSource = dt;
                    Gridwindow.DataBind();
                    Session["FileCtrl"] = "0";
                }
                else
                {
                    Gridwindow.DataSource = null;
                    Gridwindow.DataBind();
                }
            }
            else
            {
                if (Request.QueryString.ToString().Contains("CLiID") && Request.QueryString.ToString().Contains("CLiAddLID"))
                {
                    ClientID = Convert.ToInt32(Request.QueryString["CLiID"].ToString());
                    ClientAddLocID = Convert.ToInt32(Request.QueryString["CLiAddLID"].ToString());
                    if (ClientID > 0 && ClientAddLocID > 0)
                    {
                        dt = obj_class.Get_PreloadingDetailsByAcceptanceID(ClientID, ClientAddLocID, AcceptID);
                    }
                    if (dt.Rows.Count > 0)
                    {
                        Gridwindow.DataSource = dt;
                        Gridwindow.DataBind();
                        Session["FileCtrl"] = "0";
                    }
                    else
                    {
                        Gridwindow.DataSource = null;
                        Gridwindow.DataBind();
                    }
                }
                else
                {
                    Response.Redirect("~/Index.aspx");
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
    public void ChkAuthentication()
    {
        obj_LoginCtrl = null;
        obj_WelcomCtrl = null;

        obj_Navi = null;
        obj_Navihome = null;

        obj_Authenticated = Session["Authenticated"].ToString();
        maPlaceHolder = (PlaceHolder)Master.FindControl("P1");
        if (maPlaceHolder != null)
        {
            obj_Tabs = (UserControl)maPlaceHolder.FindControl("right1");

            if (obj_Tabs != null)
            {
                obj_LoginCtrl = (UserControl)obj_Tabs.FindControl("login1");
                obj_WelcomCtrl = (UserControl)obj_Tabs.FindControl("welcome1");
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

    public void Get_InvoiceID()
    {
        ds_InvoiceID = obj_InvoiceBill.Get_InvoiceID();
        InvoiceID = Convert.ToInt32(ds_InvoiceID.Tables[0].Rows[0][0]);
        obj_InvoiceBill.InvoiceID = InvoiceID;
    }

    public void AssignBillAmountAsZero()
    {
        obj_InvoiceBill.Total = 0;
        obj_InvoiceBill.GrandTotal = 0;
        obj_InvoiceBill.Rate = 0;
        obj_InvoiceBill.Amount = 0;
        obj_InvoiceBill.QuantityNoofTrucks = 0;
        obj_InvoiceBill.Particulars = "";
    }

    protected void ButSubmit_Click(object sender, EventArgs e)
    {
        try
        {

            Button b = (Button)sender;
            GridViewRow row = (GridViewRow)b.NamingContainer;
            if (row != null)
            {
                Label Accepid = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblplanID");
                Label AgreedPrice = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblAgreedPrice");
                Label VehicleNo = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblVehicleno");
                Session["ConfID"] = Accepid.Text;
                TextBox LoadingTime = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtReportTime");
                TextBox TripTime = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtTripTime");
                TextBox LRNumber = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("TxtLRno");
                if (LRNumber.Text == "")
                {
                    this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please enter LR No');", true);
                }
                else
                {
                    Session["LRNo"] = LRNumber.Text;
                    TextBox lblDeliverydate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblDeliverydate");
                    Session["Deliverydate"] = lblDeliverydate.Text;
                    TextBox lblLoadingDate = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("lblLoadingDate");
                    Session["LoadDate"] = lblLoadingDate.Text;
                    TextBox txtweight = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txtweight");
                    TextBox speedometer = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("txt_SpeedoMeter");
                    TextBox TxtEroadNo = (TextBox)Gridwindow.Rows[row.RowIndex].FindControl("TxtEroadNo");
                    Label lblFromLoc = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblFromLoc");
                    Session["FromLoc"] = lblFromLoc.Text;
                    Label lbltoloc = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lbltoloc");
                    Session["ToLoc"] = lbltoloc.Text;
                    Label lblAgreementRouteID = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblAgreementRouteID");
                    Session["AgreementRouteID"] = lblAgreementRouteID.Text;
                    Label lblProject = (Label)Gridwindow.Rows[row.RowIndex].FindControl("lblProject");
                    Session["ProjectNo"] = lblProject.Text;

                    //assigning InvoiceBilling
                    Get_InvoiceID();
                    obj_InvoiceBill.Dated = Convert.ToDateTime(lblLoadingDate.Text);
                    obj_InvoiceBill.Domain = "SCMBizconnect1";
                    obj_InvoiceBill.OtherReferences = Accepid.Text;
                    obj_InvoiceBill.InvoiceRemarks = "NA";
                    obj_InvoiceBill.BuyerorTo = "NA";
                    obj_InvoiceBill.BuyerorToDetails = "NA";
                    obj_InvoiceBill.BillNo = "ARM/BIZ-2014/";
                    obj_InvoiceBill.Status = 0;


                    //assigning InvoiceBilling Details
                    obj_InvoiceBill.Total = Convert.ToSingle(AgreedPrice.Text);
                    obj_InvoiceBill.Tax12percent = 0;
                    obj_InvoiceBill.Tax2percent = 0;
                    obj_InvoiceBill.Tax1percent = 0;
                    obj_InvoiceBill.GrandTotal = Convert.ToSingle(AgreedPrice.Text);
                    obj_InvoiceBill.ServiceTax = 0;
                    obj_InvoiceBill.EducationCess = 0;
                    obj_InvoiceBill.HigherEducationCess = 0;
                    string Words = retWord(Convert.ToInt32(AgreedPrice.Text));// assign decided price
                    obj_InvoiceBill.AmountInwords = Words + " Only";
                    obj_InvoiceBill.Particulars = "LR NO:" + LRNumber.Text.ToString() + "\r\n" + "LRDT:" + Convert.ToDateTime(lblLoadingDate.Text) + " VH :" + VehicleNo.Text + "\r\n" + lblFromLoc.Text + " TO " + lbltoloc.Text;
                    obj_InvoiceBill.QuantityNoofTrucks = 1;
                    obj_InvoiceBill.Rate = Convert.ToSingle(AgreedPrice.Text);
                    obj_InvoiceBill.Amount = Convert.ToSingle(AgreedPrice.Text);


                    if (Session["FileCtrl"] == "0")
                    {
                        FileUpload FileCtrl1 = (FileUpload)Gridwindow.Rows[row.RowIndex].FindControl("FileUpload1");
                        Session["FileCtrl"] = (FileUpload)FileCtrl1;

                    }


                    FileUpload FileCtrl = (FileUpload)Session["FileCtrl"];
                    // Read the file and convert it to Byte Array

                    string[] arr = new string[5];
                    string[] patharray = new string[5];
                    patharray = MultipleUploadClass.staticvar.Split('@');
                    string[] filenamearray = new string[5];
                    if (patharray.Length == 1)
                    {
                         dt.Clear();
                            dt = obj_class.Bizconnect_CheckAcceptIDExistsOrNot(Convert.ToInt32(Accepid.Text));
                            if (dt.Rows.Count > 0)
                            {
                                AcptID = Convert.ToInt32(dt.Rows[0][0]);
                            }
                            if (AcptID != 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('These loading details already Saved');", true);
                            }
                            else
                            {
                                if (Convert.ToInt32(Session["ClientID"].ToString()) == 1135)
                                {
                                    Expectdt = Convert.ToDateTime(lblLoadingDate.Text).AddDays(2);
                                    //Expectdt = DateTime.Parse(Expectdt.ToString("dd MM yyyy"));
                                    resp = obj_class.Bizconnect_InsertLoadingDetailswithoutimage(Convert.ToInt32(Accepid.Text), Convert.ToDateTime(LoadingTime.Text), Convert.ToDateTime(TripTime.Text), LRNumber.Text, Expectdt, Convert.ToDouble(txtweight.Text), Convert.ToDateTime(lblLoadingDate.Text), TxtEroadNo.Text, Convert.ToInt32(speedometer.Text));
                                }
                                else
                                {
                                    resp = obj_class.Bizconnect_InsertLoadingDetailswithoutimage(Convert.ToInt32(Accepid.Text), Convert.ToDateTime(LoadingTime.Text), Convert.ToDateTime(TripTime.Text), LRNumber.Text, Convert.ToDateTime(lblDeliverydate.Text), Convert.ToDouble(txtweight.Text), Convert.ToDateTime(lblLoadingDate.Text), TxtEroadNo.Text, Convert.ToInt32(speedometer.Text));
                                }
                                // Inserting into both InvoiceBilling & InvoiceBilling Details
                                obj_InvoiceBill.Insert_InvoiceBilling();
                                obj_InvoiceBill.Insert_InvoiceBilling_Details();

                                for (int i = 0; i <= 2; i++)
                                {
                                    AssignBillAmountAsZero();
                                    obj_InvoiceBill.Insert_InvoiceBilling_Details();
                                }
                            }
                    }
                    else
                    {
                        if (patharray.Length == 5)
                        {
                            for (int i = 1; i <= 4; i++)
                            {
                                string filePath = patharray[i];
                                filename = Path.GetFileName(filePath);
                                filenamearray[i] = filename;
                                ext = Path.GetExtension(filename);
                                string contenttype = String.Empty;
                                //Set the contenttype based on File Extension

                                switch (ext)
                                {

                                    case ".JPG":

                                        contenttype = "image/jpg";

                                        break;
                                    case ".jpg":

                                        contenttype = "image/jpg";

                                        break;
                                    case ".png":

                                        contenttype = "image/png";

                                        break;

                                    case ".gif":

                                        contenttype = "image/gif";

                                        break;
                                }

                                if (contenttype != String.Empty)
                                {
                                    arr[i] = "1";
                                    if (patharray[1] != null && i == 1)
                                    {
                                        FileStream fs1 = new FileStream(patharray[1], FileMode.Open, FileAccess.Read);
                                        BinaryReader br1 = new BinaryReader(fs1);
                                        if (fs1.Length <= 512000)
                                        {
                                            bytes1 = br1.ReadBytes((Int32)fs1.Length);
                                        }
                                        else
                                        {
                                            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please upload image size less than 0.5MB');", true);
                                        }
                                    }
                                    else
                                    {
                                        //bytes1 = null;
                                    }
                                    if (patharray[2] != null && i == 2)
                                    {
                                        FileStream fs2 = new FileStream(patharray[2], FileMode.Open, FileAccess.Read);
                                        BinaryReader br2 = new BinaryReader(fs2);
                                        if (fs2.Length <= 512000)
                                        {
                                            bytes2 = br2.ReadBytes((Int32)fs2.Length);
                                        }
                                        else
                                        {
                                            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please upload image size less than 0.5MB');", true);
                                        }
                                    }
                                    else
                                    {
                                        //bytes2 = null;
                                    }
                                    if (patharray[3] != null && i == 3)
                                    {
                                        FileStream fs3 = new FileStream(patharray[3], FileMode.Open, FileAccess.Read);
                                        BinaryReader br3 = new BinaryReader(fs3);

                                        if (fs3.Length <= 512000)
                                        {
                                            bytes3 = br3.ReadBytes((Int32)fs3.Length);
                                        }
                                        else
                                        {
                                            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please upload image size less than 0.5MB');", true);
                                        }
                                    }
                                    else
                                    {
                                        //bytes3 = null;
                                    }
                                    if (patharray[4] != null && i == 4)
                                    {
                                        FileStream fs4 = new FileStream(patharray[4], FileMode.Open, FileAccess.Read);
                                        BinaryReader br4 = new BinaryReader(fs4);

                                        if (fs4.Length <= 512000)
                                        {
                                            bytes4 = br4.ReadBytes((Int32)fs4.Length);
                                        }
                                        else
                                        {
                                            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please upload image size less than 0.5MB');", true);
                                        }
                                    }
                                    else
                                    {
                                        //bytes4 = null;
                                    }

                                }
                                else
                                {
                                    arr[i] = "0";

                                    //// int resp = obj_class.Bizconnect_InsertLoadingDetailswithoutimage (Convert.ToInt32(Accepid.Text), Convert.ToDateTime(LoadingTime.Text), Convert.ToDateTime(TripTime.Text), LRNumber.Text, Convert.ToDateTime(lblDeliverydate.Text), Convert.ToDouble(txtweight.Text), Convert.ToDateTime(lblLoadingDate.Text),TxtEroadNo.Text);

                                }


                            }
                             dt.Clear();
                            dt = obj_class.Bizconnect_CheckAcceptIDExistsOrNot(Convert.ToInt32(Accepid.Text));
                            if (dt.Rows.Count > 0)
                            {
                                AcptID = Convert.ToInt32(dt.Rows[0][0]);
                            }
                            if (AcptID != 0)
                            {
                                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('These loading details already Saved');", true);
                            }
                            else
                            {

                                if (Convert.ToInt32(Session["ClientID"].ToString()) == 1135)
                                {
                                    Expectdt = Convert.ToDateTime(lblLoadingDate.Text).AddDays(2);
                                    Expectdt = DateTime.Parse(Expectdt.ToString("dd MM yyyy"));
                                    resp = obj_class.Bizconnect_InsertLoadingDetails(Convert.ToInt32(Accepid.Text), Convert.ToDateTime(LoadingTime.Text), Convert.ToDateTime(TripTime.Text), LRNumber.Text, Expectdt, bytes1, ext.ToString(), filename.ToString(), bytes2, bytes3, bytes4, TxtEroadNo.Text, Convert.ToDateTime(lblLoadingDate.Text), Convert.ToInt32(speedometer.Text));
                                }
                                else
                                {
                                    resp = obj_class.Bizconnect_InsertLoadingDetails(Convert.ToInt32(Accepid.Text), Convert.ToDateTime(LoadingTime.Text), Convert.ToDateTime(TripTime.Text), LRNumber.Text, Convert.ToDateTime(lblDeliverydate.Text), bytes1, ext.ToString(), filename.ToString(), bytes2, bytes3, bytes4, TxtEroadNo.Text, Convert.ToDateTime(lblLoadingDate.Text), Convert.ToInt32(speedometer.Text));
                                }
                                // Inserting into both InvoiceBilling & InvoiceBilling Details
                                obj_InvoiceBill.Insert_InvoiceBilling();
                                obj_InvoiceBill.Insert_InvoiceBilling_Details();
                                for (int i = 0; i <= 2; i++)
                                {
                                    AssignBillAmountAsZero();
                                    obj_InvoiceBill.Insert_InvoiceBilling_Details();
                                }
                            }
                        }
                        else
                        {
                            this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Please Select 4 Images');", true);
                        }
                    }
                    MultipleUploadClass.staticvar = "";
                    if (resp == 1)
                    {
                        
                        this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Data Stored Successfully');", true);
                         Sendmail();
                    }
                    else
                    {
                        LoadDetails();
                    }

                }

            }
        }
        catch (Exception ex)
        {
            MultipleUploadClass.staticvar = "";
        }
    }
   
    public void Sendmail()
    {
        string cc = "";
        DataTable ds = new DataTable();
        ds = obj_class.Bizconnect_GetReceivingPointEmail(Convert.ToInt32(Session["AgreementRouteID"].ToString()));
        if (ds.Rows.Count > 0)
        {
        }
        else
        {

            ds = obj_class.Bizconnect_GetClientEmailForReceivingPoint(Convert.ToInt32(Session["ClientID"].ToString()), Session["ProjectNo"].ToString());
        }
        string obj_Message = "<pre>" + "<font size=4>" + "Dear Sir/Madam\n Please be informed that the vehicle has been loaded from " + Session["FromLoc"].ToString() + " on " + Session["LoadDate"].ToString() + "\nExpected Delivery Date on " + Session["Deliverydate"].ToString() + "  Please Click on the link to update the receiving infomation" + "<a href=http://www.scmbizconnect.com/ReceivingInfo.aspx?Cid=" + Server.UrlEncode(obj.Encrypt(Session["ClientID"].ToString())) + "&ConfID=" + Server.UrlEncode(obj.Encrypt(Session["ConfID"].ToString())) + "> Click the link to view Receiving Information</a> </b><br/><br/>Thank You,<br/>AARMSCM SOLUTIONS PRIVATE LIMITED<br>307, 2nd floor, 100 ft ring road,<br>(above sagar clinic)<br>7th block, BSK III STAGE<br> BANGALORE-560085<br>Ph:09845497950;09739960001<br><a href=http://www.scmjunction.com>www.scmjunction.com</a> </font><br/><br/><center><a href=http://www.aaumconnect.com/> <img src=http://www.scmjunction.com/images/AaumLogo.jpg alt=ad banner></center>";
        SqlConnection conn = new SqlConnection();
        conn.ConnectionString = Conn;
        conn.Open();
        SqlCommand cmd = new SqlCommand();
        string qry = "select Emailid,password from Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
        cmd = new SqlCommand(qry, conn);
        SqlDataReader mydatareader;
        mydatareader = cmd.ExecuteReader();
        mydatareader.Read();
        for (int i = 0; i < ds.Rows.Count; i++)
        {

            toemail = ds.Rows[i].ItemArray[0].ToString() + "," + toemail;
        }
        //CC To Client
        DataSet dsc = new DataSet();
        dsc = obj_class.get_EmailIDCCstoClient(Convert.ToInt32(Session["ClientID"].ToString()));
        cc = dsc.Tables[0].Rows[0].ItemArray[0].ToString();



        if (mydatareader.HasRows)
        {
            string fromemail = mydatareader.GetValue(0).ToString();
            string Password = mydatareader.GetValue(1).ToString();
            mail.SendEmail(toemail, fromemail.ToString(), Password.ToString(), "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Loading Information-LRNumber: " + Session["LRNo"].ToString() + " Destination:" + Session["ToLoc"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }

        else
        {
            mail.SendEmail(toemail.ToString(), "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Loading Information-LRNumber: " + Session["LRNo"].ToString() + " Destination:" + Session["ToLoc"].ToString() + "", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
        }
        cc = "";

    }

    public string retWord(int number)
    {

        if (number == 0) return "Zero";

        if (number == -2147483648) return "Minus Two Hundred and Fourteen Crore Seventy Four Lakh Eighty Three Thousand Six Hundred and Forty Eight";

        int[] num = new int[4];

        int first = 0;

        int u, h, t;

        System.Text.StringBuilder sb = new System.Text.StringBuilder();

        if (number < 0)
        {

            sb.Append("Minus");

            number = -number;

        }

        string[] words0 = { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine " };

        string[] words = { "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "Nineteen " };

        string[] words2 = { "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };

        string[] words3 = { "Thousand ", "Lakh ", "Crore " };

        num[0] = number % 1000; // units

        num[1] = number / 1000;

        num[2] = number / 100000;

        num[1] = num[1] - 100 * num[2]; // thousands

        num[3] = number / 10000000; // crores

        num[2] = num[2] - 100 * num[3]; // lakhs



        for (int i = 3; i > 0; i--)
        {

            if (num[i] != 0)
            {

                first = i;

                break;

            }

        }

        for (int i = first; i >= 0; i--)
        {

            if (num[i] == 0) continue;

            u = num[i] % 10; // ones

            t = num[i] / 10;

            h = num[i] / 100; // hundreds

            t = t - 10 * h; // tens

            if (h > 0) sb.Append(words0[h] + "Hundred ");

            if (u > 0 || t > 0)
            {

                if (h > 0 || i == 0) sb.Append("and ");

                if (t == 0)

                    sb.Append(words0[u]);

                else if (t == 1)

                    sb.Append(words[u]);

                else

                    sb.Append(words2[t - 2] + words0[u]);

            }

            if (i != 0) sb.Append(words3[i - 1]);

        }

        return sb.ToString().TrimEnd();

    }
   
    protected void Gridwindow_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (Convert.ToInt32(Session["ClientID"].ToString()) == 1135)
        {
            ((DataControlField)Gridwindow.Columns
                .Cast<DataControlField>()
                .Where(obj => obj.HeaderText == "TotalWt in Tons")
                .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
                .Cast<DataControlField>()
                .Where(obj => obj.HeaderText == "ERoad Permit No./Way Bill No")
                .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
              .Cast<DataControlField>()
              .Where(obj => obj.HeaderText == "Speedometer Reading")
              .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
              .Cast<DataControlField>()
              .Where(obj => obj.HeaderText == "Expected DeliveryDate")
              .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
             .Cast<DataControlField>()
             .Where(obj => obj.HeaderText == "CN No")
             .SingleOrDefault()).Visible = true;


            ((DataControlField)Gridwindow.Columns
             .Cast<DataControlField>()
             .Where(obj => obj.HeaderText == "WBS No")
             .SingleOrDefault()).Visible = true;

            ((DataControlField)Gridwindow.Columns
          .Cast<DataControlField>()
          .Where(obj => obj.HeaderText == "Project No")
          .SingleOrDefault()).Visible = true;
        }
        else
        {
            ((DataControlField)Gridwindow.Columns
             .Cast<DataControlField>()
             .Where(obj => obj.HeaderText == "CN No")
             .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
            .Cast<DataControlField>()
            .Where(obj => obj.HeaderText == "WBS No")
            .SingleOrDefault()).Visible = false;

            ((DataControlField)Gridwindow.Columns
          .Cast<DataControlField>()
          .Where(obj => obj.HeaderText == "Project No")
          .SingleOrDefault()).Visible = false;
        }
    }
}
