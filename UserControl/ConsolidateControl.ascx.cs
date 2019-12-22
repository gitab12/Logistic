using System;
using System.Data;
using System.Data.SqlClient ;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using ExponantAARMSMS;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.IO;
public partial class UserControl_ConsolidateControl : System.Web.UI.UserControl
{
    string BizConnStr = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    string SCMConnStr = ConfigurationManager.ConnectionStrings["SCMCon"].ConnectionString;
    int obj_res=0;
    int NOofAD = 0;
    string obj_From, obj_To,obj_username,obj_pwd;
    BizConnectClass obj_class = new BizConnectClass();
    TMSInsertion obj_InsertRFQ = new TMSInsertion();
   DataSet ds=new DataSet();
   DateTime obj_TravelDate;
   DataTable Obj_PostedAdTable = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (!IsPostBack)
        {
            lbldisp.Visible = false;
            gridbind();
            bindwindow();

        }
      
    }
   
    public void gridbind()
    {
        string traveldate = ""; 
        DataTable dt = new DataTable("ConsolidateTripplan");
        DataRow dr;
        
        dt.Columns.Add("source");
        dt.Columns.Add("designation");
        dt.Columns.Add("truckcapacity");
        dt.Columns.Add("traveltype");
        dt.Columns.Add("truckreq");
        dt.Columns.Add("tdate");
        dt.Columns.Add("ttid");
        dt.Columns.Add("tktid");
        dt.Columns.Add("capacity");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("Encl");
        dt.Columns.Add("product");
        ds = obj_class.ConsolidationTripplan();
        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {

            if (traveldate != ds.Tables[0].Rows[i].ItemArray[0].ToString())
            {
                traveldate = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dr = dt.NewRow();
                dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
                dt.Rows.Add(dr);
                //goto x;
            }
           
            dr = dt.NewRow();


            dr[0] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[3].ToString() +"/"+ ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[6].ToString() + "Trucks";
            dr[5] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[7].ToString();
            dr[7] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
            dr[8] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[9] = ds.Tables[0].Rows[i].ItemArray[9].ToString();
            dr[10] = ds.Tables[0].Rows[i].ItemArray[10].ToString();
            dr[11] = ds.Tables[0].Rows[i].ItemArray[11].ToString();
            dt.Rows.Add(dr);
        }
      
        Gridclientplan.DataSource = dt;
        Gridclientplan.DataBind();

    }
    public void bindwindow()
    {
        try
        {

            string source = Request.QueryString["source"].ToString();
            string Desination = Request.QueryString["designation"].ToString();
            string tdate = Request.QueryString["tdate"].ToString();
            string Traveltype = Request.QueryString["Traveltype"].ToString();
            string Truckcapacity = Request.QueryString["Truckcapacity"].ToString();
            string Trucktype = Request.QueryString["Trucktype"].ToString();

            ds = obj_class.ShowClientsplan(source, Desination, tdate, Traveltype, Truckcapacity, Trucktype);
            Gridwindow.DataSource = ds;
            Gridwindow.DataBind();
            Gridwindow.Visible = true;
            // string val = HiddenField1.Value;
            //Gridwindow.Style.Add("top","450px");

        }




        catch (Exception err)
        {

        }
    }
   


    protected void Gridclientplan_RowDataBound(Object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
          
            Label Lblclient = (Label)e.Row.FindControl("lblsource");
            CheckBox chkitem = (CheckBox)e.Row.FindControl("Checkitem");
           // LinkButton view = (LinkButton)e.Row.FindControl("View");
            bool validDate = false;
            DateTime result;
            validDate = DateTime.TryParse(Lblclient.Text, out result);

          
           
            if (validDate == true)
            {
                e.Row.Cells[1].ForeColor = System.Drawing.Color.Red;
                e.Row.Cells[1].Font.Bold = true;
                chkitem.Visible = false;
              //  view.Visible = false;
            }

            if (Lblclient.Text.Substring(0, 3) == "Max")
            {
                chkitem.Visible = false;
            }

        }
        
    }



    //protected void View_Click(object sender, EventArgs e)
    //{
    //    string val1 = Request.QueryString["source"].ToString();
    //    string val2 = Request.QueryString["designation"].ToString();

    //   Gridwindow.Visible = true;
      
    //}
    protected void Butpostad1_Click(object sender, EventArgs e)
    {
        Int32 emailresp_all = 0;
        NOofAD = 0;
        for (int i = 0; i <= Gridclientplan.Rows.Count - 1; i++)
        {
            CheckBox check = (CheckBox)Gridclientplan.Rows[i].FindControl("Checkitem");
            Label source = (Label)Gridclientplan.Rows[i].FindControl("lblsource");
            Label desination = (Label)Gridclientplan.Rows[i].FindControl("lbldesignation");
            Label Tdate = (Label)Gridclientplan.Rows[i].FindControl("Lbltdate");
            Label Nooftrucks = (Label)Gridclientplan.Rows[i].FindControl("lbltruckreq");
            Label Capacity = (Label)Gridclientplan.Rows[i].FindControl("lblcapacity");
            Label Trucktypeid = (Label)Gridclientplan.Rows[i].FindControl("lbltktid");
            Label Traveltypeid = (Label)Gridclientplan.Rows[i].FindControl("lblttid");
            Label Comments = (Label)Gridclientplan.Rows[i].FindControl("LblRemaks");
            Label EnclID = (Label)Gridclientplan.Rows[i].FindControl("lblEncl");
            Label Product = (Label)Gridclientplan.Rows[i].FindControl("lblproduct");

            string result = Nooftrucks.Text;
           
            if (check.Checked)
            {
                if (check.Visible == true)
                {
                    Nooftrucks.Text = result.Replace(result.Substring(result.Length - 6, 6), "");
                    obj_From = source.Text;
                    obj_To = desination.Text;
                    obj_TravelDate = Convert.ToDateTime(Tdate.Text);
                    NOofAD = NOofAD + 1;
                    string AdID = AdIDProcess();
                    string obj_GroupID = Convert.ToString(Session["GroupID"]);

                    int obj_Response = obj_class.Insert_AdPost(AdID, 1, 2, obj_From, obj_To, obj_TravelDate, Product.Text.ToString(), 1, Convert.ToInt32(Nooftrucks.Text), Convert.ToString(Capacity.Text.Trim()), Convert.ToInt32(Trucktypeid.Text), Convert.ToInt32(EnclID.Text.ToString()), 0, 0, obj_TravelDate, obj_TravelDate, Comments.Text.ToString(), Convert.ToInt32(obj_GroupID), Convert.ToInt32(Traveltypeid.Text), 0, "Kgs",obj_To);
                    obj_res = obj_class.Update_JunctionADid(AdID, obj_TravelDate, obj_From, obj_To, Convert.ToDouble (Capacity.Text), Convert.ToInt32(Traveltypeid.Text), Convert.ToInt32(Trucktypeid.Text),string.Empty);
                    //emailresp_all = SendEmailALL(AdID, obj_From, obj_To, Nooftrucks.Text.Trim(), obj_TravelDate.ToString());

                    if (obj_res == 1)
                    {

                        // Response.Redirect(Request.Url.ToString());
                        lblmsg.Visible = true;
                        lblmsg.Text = NOofAD.ToString() + " AD Posted in junction successfully";

                    }
                    else
                    {
                        lblmsg.Visible = true;
                        lblmsg.Text = "Posting AD in junction is failed.....";
                    }
                }
            
            }
        }
        
    }

    public string AdIDProcess()
    {
        ArrayList arr = new ArrayList();
        Int32 obj_ID = 0;
        string obj_PostAdType = "VW";
        string obj_Temp = "";
       
        arr.Clear();
        arr = obj_class.get_PostID();
      
        if (arr[0].ToString() != "0")
        {
            obj_ID = Convert.ToInt32(arr[1]);
            obj_ID += 1;
            Session["GroupID"] = obj_ID;
        }
        else if (arr[0].ToString() != "1")
        {
            obj_ID = 1000;
            Session["GroupID"] = obj_ID;
        }
        
      obj_Temp = "#" + obj_From.Substring(0, 3) + "-" + obj_To.Substring(0, 3) + obj_TravelDate.ToString("-" + "MMyyyy") + "-" + obj_PostAdType + "-" + obj_ID.ToString();
        return obj_Temp;
    }



    protected void Butpostad_Click(object sender, EventArgs e)
    {
        try
        {
            Int32 emailresp_all = 0;
            NOofAD = 0;

            for (int i = 0; i <= Gridclientplan.Rows.Count - 1; i++)
            {
                CheckBox check = (CheckBox)Gridclientplan.Rows[i].FindControl("Checkitem");
                Label source = (Label)Gridclientplan.Rows[i].FindControl("lblsource");
                Label desination = (Label)Gridclientplan.Rows[i].FindControl("lbldesignation");
                Label Tdate = (Label)Gridclientplan.Rows[i].FindControl("Lbltdate");
                Label Nooftrucks = (Label)Gridclientplan.Rows[i].FindControl("lbltruckreq");
                Label Capacity = (Label)Gridclientplan.Rows[i].FindControl("lblcapacity");
                Label Trucktypeid = (Label)Gridclientplan.Rows[i].FindControl("lbltktid");
                Label Traveltypeid = (Label)Gridclientplan.Rows[i].FindControl("lblttid");
                Label Comments = (Label)Gridclientplan.Rows[i].FindControl("LblRemaks");
                Label EnclID = (Label)Gridclientplan.Rows[i].FindControl("lblEncl");
                Label Product = (Label)Gridclientplan.Rows[i].FindControl("lblproduct");
                string result = Nooftrucks.Text;

                if (check.Checked)
                {
                    if (check.Visible == true)
                    {
                        Nooftrucks.Text = result.Replace(result.Substring(result.Length - 6, 6), "");
                        obj_From = source.Text;
                        obj_To = desination.Text;
                        obj_TravelDate = Convert.ToDateTime(Tdate.Text);
                        NOofAD = NOofAD + 1;
                        string AdID = AdIDProcess();
                        string obj_GroupID = Convert.ToString(Session["GroupID"]);
                        //int obj_Response = obj_class.Insert_AdPost(AdID, Convert.ToInt16(Session["UserId"].ToString()), 2, obj_From, obj_To, obj_TravelDate, "All", 1, Convert.ToInt32(Nooftrucks.Text), Convert.ToString(Capacity.Text.Trim()), Convert.ToInt32(Trucktypeid.Text), 1, 0, 0, obj_TravelDate, obj_TravelDate, Comments.Text , Convert.ToInt32(obj_GroupID), Convert.ToInt32(Traveltypeid.Text), 0, "Kgs");
                        int obj_Response = obj_class.Insert_AdPost(AdID, 1, 2, obj_From, obj_To, obj_TravelDate, Product.Text.ToString(), 1, Convert.ToInt32(Nooftrucks.Text), Convert.ToString(Capacity.Text.Trim()), Convert.ToInt32(Trucktypeid.Text), Convert.ToInt32(EnclID.Text.ToString()), 0, 0, obj_TravelDate, obj_TravelDate, Comments.Text.ToString(), Convert.ToInt32(obj_GroupID), Convert.ToInt32(Traveltypeid.Text), 0, "Kgs",obj_To);

                        int obj_res = obj_class.Update_JunctionADid(AdID, obj_TravelDate, obj_From, obj_To, Convert.ToDouble (Capacity.Text), Convert.ToInt32(Traveltypeid.Text), Convert.ToInt32(Trucktypeid.Text),string.Empty);
                        if (obj_res == 1)
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = NOofAD.ToString() + " AD Posted in junction successfully";
                            // Response.Redirect(Request.Url.ToString());


                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Posting AD in junction is failed.....";
                        }

                        // emailresp_all = SendEmailALL(AdID, obj_From, obj_To, Nooftrucks.Text.Trim(), obj_TravelDate.ToString());

                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }
    //Sending Email to all users

    public Int32 SendEmailALL(DataTable obj_PostedData)
    {
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_EmailID;
        String cc = "";
        string  obj_Rid = "0";
        ArrayList arr = new ArrayList();
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
        //

        obj_EmailID = "Nil";
       // arr.Clear();
       // arr = obj_class.get_NameByPostByID(Convert.ToInt32(Session["UserID"].ToString()));

        //if (arr[1].ToString() != "0")
        //{
           // String obj_FullName = arr[0].ToString();
            //obj_Message = "Thank you for posting your Ad [" + obj_AdID + "] in scmjunction.com";
            //String x_AdID = obj_AdID;
           // obj_AdID = Regex.Replace(obj_AdID, "#", "X");
            DateTime obj_PostedDate = new DateTime();
            obj_PostedDate = DateTime.Now.Date;
            String dt;
            dt = obj_PostedDate.ToString("dd-MMM-yyyy");
            String obj_AdType;
            String Body = "";
            String BodyHeader = "";
            String BodyMiddle = "";
            String BodyFooter = "";
            obj_AdType = "Wanted Ads";
            int count = 0;
            //            String Body = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><font size=2 color=#003366><strong>Posted Date:&nbsp;</font><font size=2 color=Maroon>" + dt + "</strong></font></td><td align=center colspan=3><font size=3 color=#003366><strong><a href=http://www.scmjunction.com title=www.scmjunction.com target=_Blank>www.scmjunction.com<a></strong></font></td><td align=center><strong><font size=2 color=#003366>Ad Type:&nbsp;</font><font size=2 color=Maroon>" + obj_AdType + "</td></strong></font></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>Ad ID</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>From Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>No of Trucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Travel Date</strong></font></td></tr><tr><td align=center><a href=http://www.scmjunction.com/Viewnew.aspx?Adid=" + obj_AdID + " title=Click for View this Ad target=_Blank ><strong>" + x_AdID + "</strong></a></td><td align=center><font size=2>'from'</font></td><td align=center><font size=2>'To'</font></td><td align=center><font size=2>2</font></td><td align=center><font size=2>'obj_TravelDate'</font></td></tr><tr bgcolor=#585858><td align=center>&nbsp;</td><td align=center colspan=3><Font size=2 color=White><strong><font size=2>Total no of  Posted Ad : 01</font></strong></font></td><td align=center>&nbsp;</td></tr></table>";
            BodyHeader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><font size=2 color=#003366><strong>Posted Date:&nbsp;</font><font size=2 color=Maroon>" + dt + "</strong></font></td><td align=center colspan=3><font size=3 color=#003366><strong><a href=http://www.scmjunction.com title=www.scmjunction.com target=_Blank>www.scmjunction.com<a></strong></font></td><td align=center><strong><font size=2 color=#003366>Ad Type:&nbsp;</font><font size=2 color=Maroon>" + obj_AdType + "</td></strong></font></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>Ad ID</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>From Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To Location</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>No of Trucks</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Travel Date</strong></font></td></tr>";
            foreach (DataRow rw in obj_PostedData.Rows)
            {
                count = count + 1;
                String xID = Regex.Replace(rw[0].ToString(), "#", "X");
                BodyMiddle += "<tr><td align=center><a href=http://www.scmjunction.com/Viewnew.aspx?Adid=" + xID.Trim() + " title=Click for View this Ad target=_Blank ><strong>" + rw[0].ToString() + "</strong></a></td><td align=center><font size=2>" + rw[1].ToString() + "</font></td><td align=center><font size=2>" + rw[2].ToString() + "</font></td><td align=center><font size=2>"+rw[3].ToString()+"</font></td><td align=center><font size=2>" + rw[4].ToString() + "</font></td></tr>";

            }
            try
            {
             
            BodyFooter = "<tr bgcolor=#585858><td align=center>&nbsp;</td><td align=center colspan=3><Font size=2 color=White><strong><font size=2>Total no of  Posted Ad :&nbsp;&nbsp;" + count.ToString() + "</font></strong></font></td><td align=center>&nbsp;</td></tr></table>";
            Body = BodyHeader+BodyMiddle + BodyFooter;
            obj_Message = "Dear sir/madam,<br/>We are pleased to inform you that a new posting for various locations has been updated in SCM JUNCTION for trucks wanted.<a href=http://www.scmjunction.com/QuotePrice.aspx?Lid=" + obj_Rid + " Clid=0>Please Click the link to Bid your Quotes </a> <br/><br/>Note: IF TAURUS VEHICLE MOVEMENT IS LESS,PLEASE QUOTE FOR FTL 9MT OR 32FT CONTAINER VEHICLE ETC.<br/>If you have any queries please contact :0973987001/09980823571<br/>Please visit:<a href=http://www.scmjunction.com>www.scmjunction.com</a><br/><br/>Details of the Newly Posted Ad<br/><br/>" + Body + "<br/><br/>Thank You,<br/>Web Master,<br> SCM Junction<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a> <br/><center><img src=http://www.scmjunction.com:8084/ads/MMFSL-banner.jpg name=Rotating id=slide1 width=695 height=175 alt=ad banner/></center>";
                //---------------------------------------------------
                //For EBidding
           
            //string FileName;
            //FileName = "Thermax.htm";//Path.GetFileName(obj_HtmlPath);
            //StreamReader streamReader;
      
            //streamReader = File.OpenText(Server.MapPath(@"Documents\" + FileName));
            //string contents = streamReader.ReadToEnd();
            //streamReader.Close();
           
         
                
                
                //---------------------------------------------------------
            //ds = new DataSet();
                ds = obj_class.get_EmailIDByRID();
                for (int i = 0; i <=ds.Tables[0].Rows.Count - 1; i++)
               // for (int i = 0; i <= 0; i++)
                {
                 //  obj_EmailID = "nandha@aarmscmsolutions.com";
                    obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();

                   obj_Rid = ds.Tables[0].Rows[i].ItemArray[1].ToString();
                    obj_pwd = ds.Tables[0].Rows[i].ItemArray[2].ToString();
                    //obj_Message = contents.Replace("webaccesslink", "<a href=http://www.scmjunction.com/QuotePrice.aspx?Lid=" + obj_Rid + ">www.scmjunction.com</a>");
                  obj_Message = "Dear sir/madam,<br/>We are pleased to inform you that a new posting for various locations has been updated in SCM JUNCTION for trucks wanted.<br/>Note: IF TAURUS VEHICLE MOVEMENT IS LESS,PLEASE QUOTE FOR FTL 9MT OR 32FT CONTAINER VEHICLE ETC.<br/>If you have any queries please contact :0973987001/09980823571<br/>Please visit:<a href=http://www.scmjunction.com>www.scmjunction.com</a><br/><br/>Details of the Newly Posted Ad<br/><br/>" + Body + "<br/><br/>Thank You,<br/>Web Master,<br> SCM Junction<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a> <br/><center><img src=http://www.scmjunction.com:8084/ads/MMFSL-banner.jpg name=Rotating id=slide1 width=695 height=175 alt=ad banner/></center>";
                 //   obj_Message = "Dear sir/madam,<br/>We Sincerely thank you for participating in E-Bidding on behalf of our client.<br/>We have posted the expected rebid price for your kind consideration and confirmation.<a href=http://www.scmjunction.com/Rebid.aspx?Lid=" + obj_Rid + ">Please Click the link to ReBid your Quotes </a><br/>Your Confirmation is expected before 6pm on 19/Apr/2012.<br/>Please visit:<a href=http://www.scmjunction.com>www.scmjunction.com</a><br/> <br/><br/>Thank You,<br/>Web Master,<br> SCM Junction<br/><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
                    obj_AttachmentPath = "";//Server.MapPath(@"Documents\SCM-Junction-summary.doc");
                    DataSet dsc = new DataSet();
                   // dsc = obj_class.get_CCsByRID(Convert.ToInt32(obj_Rid));
                    //if (dsc.Tables[0].Rows.Count > 0)
                    //{
                    //    for (int j = 0; j <= dsc.Tables[0].Rows.Count - 1; j++)
                    //    {

                    //        cc = dsc.Tables[0].Rows[j].ItemArray[1].ToString() + "," + cc;
                    //    }
                    //}
                    //Declaration Section for AARMEmail Control
                    AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                   em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, cc, "", obj_FromEmail, obj_BounceBakEmail, "Very Urgent Requirement of Trucks on 20/Mar/2014", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());
                   //obj_resp = 1;


                   //AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                   //em.SendEmail("nandha@aarmscmsolutions.com", "connect@scmjunction.com", "scmjunction", "", "", "", "", "New ADs posted in scmjunction", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());

                   //obj_resp = 1;
                }
                if (obj_resp == 1)
                {
                    this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Mails sent successfully!');", true);
                }
            }
            catch (Exception err)
            {
                obj_resp = 3;
            }
       // }
        return obj_resp;
    }
    //Create Data Table
    public DataTable CreateTable()
    {
        DataTable tbl = new DataTable();
        DataColumn mcol;
        mcol = new DataColumn();
        mcol.DataType = Type.GetType("System.String");
        mcol.ColumnName = "AdID";
        tbl.Columns.Add(mcol);

        mcol = new DataColumn();
        mcol.DataType = Type.GetType("System.String");
        mcol.ColumnName = "From Location";
        tbl.Columns.Add(mcol);

        mcol = new DataColumn();
        mcol.DataType = Type.GetType("System.String");
        mcol.ColumnName = "To Location";
        tbl.Columns.Add(mcol);

        mcol = new DataColumn();
        mcol.DataType = Type.GetType("System.String");
        mcol.ColumnName = "No Of Trucks";
        tbl.Columns.Add(mcol);

        mcol = new DataColumn();
        mcol.DataType = Type.GetType("System.String");
        mcol.ColumnName = "Travel Date";
        tbl.Columns.Add(mcol);

        return tbl;

    }
    //Add records to Data table
    private DataTable AddDataToTable(string AdID, string frml, string tol, string nooftrucks, string trDate, DataTable myTable)
    {

       // myTable = (DataTable)Cache["myTable"];
        if (myTable != null)
        {
            DataRow row;
            row = myTable.NewRow();
            row["AdID"] = AdID;
            row["From Location"] = frml;
            row["To Location"] = tol;
            row["No Of Trucks"] = nooftrucks;
            row["Travel Date"] = trDate;
            myTable.Rows.Add(row);
            //Cache.Insert("myTable", myTable);
        }
        else
        {
            myTable = CreateTable();
            DataRow row;
            row = myTable.NewRow();
            row["AdID"] = AdID;
            row["From Location"] = frml;
            row["To Location"] = tol;
            row["No Of Trucks"] = nooftrucks;
            row["Travel Date"] = trDate;
            myTable.Rows.Add(row);
            //Cache.Insert("myTable", myTable);
        }

        return myTable;
    }
    public object connection_reader(string cmdstr)
    {

        string cmdstr1 = cmdstr;

        SqlConnection con = new SqlConnection(SCMConnStr);
        con.Open();
        SqlCommand cmd2 = new SqlCommand(cmdstr1, con);
        SqlDataReader reader;
        reader = cmd2.ExecuteReader();
        object resreader = reader;
        return resreader;
    }



    protected void sendmail_Click(object sender, EventArgs e)
    {
        Int32 emailresp_all = 0;
        //string sel = "select AdID,FromLocation,ToLocation,NumOfTrucks,CONVERT(varchar(20),RequirementDate,106) as traveldate from aarmjunction.dbo.scmJunction_PostAd where  CAST(CONVERT(varchar,PostedDateTimeStamp, 101) AS Date)=CAST(CONVERT(varchar,GETDATE()-1 , 101) AS Date) and PostTypeID='2'";
        string sel = "select AdID,FromLocation,ToLocation,TruckType+'/ Trucks Req. '+Convert(varchar(10),NumOfTrucks) as NoofTrucks,CONVERT(varchar(20),RequirementDate,106) as traveldate  from aarmjunction.dbo.scmJunction_PostAd PA inner join aarmjunction .dbo.scmJunction_TruckType TT on pa.TruckTypeID =tt.TruckTypeID where  DAY(RequirementDate)in(20)  and month(RequirementDate)=3 and year(RequirementDate)=2014 and postid in(44737,44738) order by PostID";
        
        SqlDataReader reader = (SqlDataReader)connection_reader(sel);
        Obj_PostedAdTable = CreateTable();
        while (reader.Read())
        {
            if (reader.ToString() != "")
            {
                string AdID = reader.GetValue(0).ToString();
                string obj_from = reader.GetValue(1).ToString();
                string obj_To = reader.GetValue(2).ToString();
                string Nooftrucks = reader.GetValue(3).ToString();
                string obj_TravelDate = reader.GetValue(4).ToString();
                Obj_PostedAdTable = AddDataToTable(AdID, obj_from, obj_To, Nooftrucks, obj_TravelDate.ToString(), Obj_PostedAdTable);
                // Cache.Insert("myTable", Obj_PostedAdTable);
            }
        }
        reader.Dispose();
        emailresp_all = SendEmailALL(Obj_PostedAdTable);
       // emailresp_all = Sendduediligence();
        
    }
    protected void CheckAll_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox chkall = (CheckBox)Gridclientplan.HeaderRow.FindControl("CheckAll");
        if (chkall.Checked)
        {
            for (int j = 0; j <= Gridclientplan.Rows.Count - 1; j++)
            {

                CheckBox chkAd = (CheckBox)Gridclientplan.Rows[j].FindControl("Checkitem");
                chkAd.Checked = true;
                

            }
        }
        else
        {
            for (int j = 0; j <= Gridclientplan.Rows.Count - 1; j++)
            {

                CheckBox chkAd = (CheckBox)Gridclientplan.Rows[j].FindControl("Checkitem");
                chkAd.Checked = false ;
                


            }
        }
    }
    public Int32 Sendduediligence()
    {
        Int32 obj_resp = 3;
        String obj_Message;
        String obj_EmailID;
        string obj_Rid = "0";
        ArrayList arr = new ArrayList();
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
        //

        obj_EmailID = "Nil";
        try
        {


            ds = new DataSet();
            ds = obj_class.get_EmailIDByRID();
            for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
            {

                obj_EmailID = ds.Tables[0].Rows[i].ItemArray[0].ToString();





                obj_Message = "Dear sir/madam,<br/>Greetings. We are glad to inform you that we have signed off with some of the leading companies for the vehicle requirement on a continuous basis.<br><br> To enable us to complete the agreement process with the client,we request you to provide us the enclosed Due Diligence details immediately.<br><br> You can either scan the filled format and mail us back or download the format and  courier the hardcopy with relavant details to the below metioned address. <br><br> Best regards and assuring you of the best services.</b></br> <b> </b> <br/><br/>Thank You,<br/><br> G.Jagannathan(MD)<br/>AARM SCM SOLUTIONS PRIVATE LIMITED<br>307, 2nd floor, 100 ft ring road,<br>ABOVE SAGAR CLINIC<br>7th block, BSK III STAGE<br> BANGALORE-560085<br>Ph:09845497950;09739960001<br><a href=http://www.scmjunction.com>www.scmjunction.com</a>";
                obj_AttachmentPath = Server.MapPath(@"Documents\due-diligence-signoff.doc");
                //Declaration Section for AARMEmail Control
                AARMEmail.EmailControl em = new AARMEmail.EmailControl();
                obj_resp = em.SendEmail(obj_EmailID, obj_FromEmail, obj_Password, "", "", obj_FromEmail, obj_BounceBakEmail, "Due Diligence Letter", obj_Message.ToString().Trim(), System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.Normal, obj_ServerName.ToString().Trim(), obj_PortNo.ToString().Trim(), obj_SendUsingPort.ToString().Trim(), obj_AuthenticateMode.ToString().Trim(), true, obj_AttachmentPath.ToString().Trim());


            }




            if (obj_resp == 1)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(Page), "notification", "window.alert('Mails sent successfully!');", true);
            }

        }
        catch (Exception err)
        {
            obj_resp = 3;
        }
        // }
        return obj_resp;

    }
    
    protected void btn_postrfq_Click(object sender, EventArgs e)
    {

        try
        {
            Int32 emailresp_all = 0;
            NOofAD = 0;

            for (int i = 0; i <= Gridclientplan.Rows.Count - 1; i++)
            {
                CheckBox check = (CheckBox)Gridclientplan.Rows[i].FindControl("Checkitem");
                Label source = (Label)Gridclientplan.Rows[i].FindControl("lblsource");
                Label desination = (Label)Gridclientplan.Rows[i].FindControl("lbldesignation");
                Label Tdate = (Label)Gridclientplan.Rows[i].FindControl("Lbltdate");
                Label Nooftrucks = (Label)Gridclientplan.Rows[i].FindControl("lbltruckreq");
                Label Capacity = (Label)Gridclientplan.Rows[i].FindControl("lblcapacity");
                Label Trucktypeid = (Label)Gridclientplan.Rows[i].FindControl("lbltktid");
                Label Traveltypeid = (Label)Gridclientplan.Rows[i].FindControl("lblttid");
                Label Comments = (Label)Gridclientplan.Rows[i].FindControl("LblRemaks");
                Label EnclID = (Label)Gridclientplan.Rows[i].FindControl("lblEncl");
                Label Product = (Label)Gridclientplan.Rows[i].FindControl("lblproduct");
                string result = Nooftrucks.Text;

               if (check.Checked)
                {
                   if (check.Visible == true)
                    {
                        Nooftrucks.Text = result.Replace(result.Substring(result.Length - 6, 6), "");
                        obj_From = source.Text;
                        obj_To = desination.Text;
                        obj_TravelDate = Convert.ToDateTime(Tdate.Text);
                        NOofAD = NOofAD + 1;
                        string AdID = AdIDProcess();
                        string obj_GroupID = Convert.ToString(Session["GroupID"]);
                        //int obj_Response = obj_class.Insert_AdPost(AdID, Convert.ToInt16(Session["UserId"].ToString()), 2, obj_From, obj_To, obj_TravelDate, "All", 1, Convert.ToInt32(Nooftrucks.Text), Convert.ToString(Capacity.Text.Trim()), Convert.ToInt32(Trucktypeid.Text), 1, 0, 0, obj_TravelDate, obj_TravelDate, Comments.Text , Convert.ToInt32(obj_GroupID), Convert.ToInt32(Traveltypeid.Text), 0, "Kgs");
                        int obj_Response = obj_class.Insert_AdPost(AdID, 1, 3, obj_From, obj_To, obj_TravelDate, Product.Text.ToString(), 1, Convert.ToInt32(Nooftrucks.Text), Convert.ToString(Capacity.Text.Trim()), Convert.ToInt32(Trucktypeid.Text), Convert.ToInt32(EnclID.Text.ToString()), 0, 0, obj_TravelDate, obj_TravelDate, Comments.Text.ToString(), Convert.ToInt32(obj_GroupID), Convert.ToInt32(Traveltypeid.Text), 0, "Kgs",obj_To);

                        int obj_res = obj_class.Update_JunctionADid(AdID, obj_TravelDate, obj_From, obj_To, Convert.ToDouble(Capacity.Text), Convert.ToInt32(Traveltypeid.Text), Convert.ToInt32(Trucktypeid.Text),"PostRFQ");

                        int obj_RFQ = obj_InsertRFQ.Insert_Into_New_RFQ(Session["UserId"].ToString(), obj_From, obj_To, AdID, Product.Text.ToString(), Trucktypeid.Text, EnclID.Text.ToString(),1,Convert.ToString(Capacity.Text.Trim()),ddl_period .SelectedValue .ToString (),Comments.Text.ToString());
                        if (obj_res == 1)
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = NOofAD.ToString() + " AD Posted in junction successfully";
                            // Response.Redirect(Request.Url.ToString());


                        }
                        else
                        {
                            lblmsg.Visible = true;
                            lblmsg.Text = "Posting AD in junction is failed.....";
                        }

                        // emailresp_all = SendEmailALL(AdID, obj_From, obj_To, Nooftrucks.Text.Trim(), obj_TravelDate.ToString());

                    }
                }
            }
        }
        catch (Exception ex)
        {
        }

    }

    
}
