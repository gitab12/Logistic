using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using AARMEmail;
using System.Globalization;
public partial class DashboardDetails : System.Web.UI.Page
{


    TripAssignment Trip_Assign = new TripAssignment();
    AARMEmail.EmailControl mail = new AARMEmail.EmailControl();
    int resp = 0;
    string Conn = ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString;
    BizCon_DB_ConnectionString con = new BizCon_DB_ConnectionString();
    string clientidd = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
       if (!IsPostBack)
        {    
          
            LoadDetails();
            foreach (GridViewRow row in GridView.Rows)
            {
                TextBox TrucksReqDatetime = (TextBox)GridView.Rows[row.RowIndex].FindControl("txt_TrucksReqDatetime");
                TrucksReqDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
            }
           
        }
      clientidd= Session["ClientID"].ToString();
    }
    
      public void LoadDetails()
    {
        DataTable dt = new DataTable();
        DataRow dr;
        dt.Columns.Add("LogisticsPlanID");
        dt.Columns.Add("LogisticsPlanNo");
        dt.Columns.Add("FromLocation");
        dt.Columns.Add("ToLocation");
        dt.Columns.Add("TruckType");
        dt.Columns.Add("EnclosureType");
        dt.Columns.Add("Capacity");
        dt.Columns.Add("QuotedPrice");

        dt.Columns.Add("DecidedPrice");
          
        dt.Columns.Add("PostedDate");
        dt.Columns.Add("Email");
        dt.Columns.Add("nooftrucks");
        dt.Columns.Add("TransporterName");
        dt.Columns.Add("ReplyByID");
        dt.Columns.Add("TravelDate");
        dt.Columns.Add("TripAssignID");
        dt.Columns.Add("AgreementRouteID");
        DataSet ds = new DataSet();
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BizCon"].ConnectionString);
        conn.Open();
        //string qry = "select distinct PA.PostID as LogisticsPlanID ,AdID as LogisticsPlanNo,pa.FromLocation,pa.ToLocation,TruckType,EnclosureType,pa.TruckCapacity as Capacity,PR.negotiablecost as DecidedPrice,SR.CompanyName as TransporterName ,ReplyByID ,pa.TruckTypeID , Pa.EnclosureTypeID,'T1'as Transporter_Name ,Convert(varchar(20),PR.ReplyDateTimeStamp  ,106)as QuoteDate,PR.negotiabletruck as nooftrucks ,Email +(',')+ isnull(secEmail,'') as Email ,Convert(varchar(20),PA.RequirementDate,106)as TravelDate,c.TripAssignID ,c.AgreementRouteID from aarmjunction.dbo.scmJunction_PostAd PA inner join aarmjunction.dbo.scmJunction_PostReply PR on PA.PostID=PR.PostID inner join aarmjunction.dbo.scmJunction_TruckType TT on pa.TruckTypeID  =TT.TruckTypeid inner join aarmjunction.dbo.scmJunction_EnclosureType ET on pa.EnclosureTypeID =ET.EnclosureTypeid inner join aarmjunction .dbo.scmjunction_registration SR on SR.rid=PR.ReplyByID left join(select TripAssignID ,indentid,TransporterID ,AgreementRouteID from BizConnect_TripAssign where IndentID= " + Convert.ToInt32(Request.QueryString["PostID"].ToString()) + " )c on c.IndentID =pa.PostID and c.TransporterID =pr.ReplyByID  where PA.PostID =" + Convert.ToInt32(Request.QueryString["PostID"].ToString()) + "  order by DecidedPrice asc,LogisticsPlanID desc,  QuoteDate desc ";
        string qry = "select distinct PA.PostID as LogisticsPlanID ,AdID as LogisticsPlanNo,pa.FromLocation,pa.ToLocation,TruckType,EnclosureType,pa.TruckCapacity as Capacity,PR.negotiablecost as DecidedPrice,PR.negotiablecost as QuotedPrice,  SR.CompanyName as TransporterName ,ReplyByID ,pa.TruckTypeID , Pa.EnclosureTypeID,'T1'as Transporter_Name ,Convert(varchar(20),PR.ReplyDateTimeStamp  ,106)as QuoteDate,PR.negotiabletruck as nooftrucks ,Email +(',')+ isnull(secEmail,'') as Email ,Convert(varchar(20),PA.RequirementDate,106)as TravelDate,c.TripAssignID ,c.AgreementRouteID from aarmjunction.dbo.scmJunction_PostAd PA inner join aarmjunction.dbo.scmJunction_PostReply PR on PA.PostID=PR.PostID inner join aarmjunction.dbo.scmJunction_TruckType TT on pa.TruckTypeID  =TT.TruckTypeid inner join aarmjunction.dbo.scmJunction_EnclosureType ET on pa.EnclosureTypeID =ET.EnclosureTypeid inner join aarmjunction .dbo.scmjunction_registration SR on SR.rid=PR.ReplyByID left join(select TripAssignID ,indentid,TransporterID ,AgreementRouteID from BizConnect_TripAssign where IndentID= " + Convert.ToInt32(Request.QueryString["PostID"].ToString()) + " )c on c.IndentID =pa.PostID and c.TransporterID =pr.ReplyByID  where PA.PostID =" + Convert.ToInt32(Request.QueryString["PostID"].ToString()) + "  order by DecidedPrice asc,LogisticsPlanID desc,  QuoteDate desc ";

        SqlCommand cmd = new SqlCommand(qry, conn);
        cmd.ExecuteNonQuery();
        SqlDataAdapter adp = new SqlDataAdapter(cmd);
        ds = new DataSet();
        adp.Fill(ds);

        for (int i = 0; i <= ds.Tables[0].Rows.Count - 1; i++)
        {
            dr = dt.NewRow();

            dr[0] = ds.Tables[0].Rows[i].ItemArray[0].ToString();
            dr[1] = ds.Tables[0].Rows[i].ItemArray[1].ToString();
            dr[2] = ds.Tables[0].Rows[i].ItemArray[2].ToString();
            dr[3] = ds.Tables[0].Rows[i].ItemArray[3].ToString();
            dr[4] = ds.Tables[0].Rows[i].ItemArray[4].ToString();
            dr[5] = ds.Tables[0].Rows[i].ItemArray[5].ToString();
            dr[6] = ds.Tables[0].Rows[i].ItemArray[6].ToString();
            dr[7] = ds.Tables[0].Rows[i].ItemArray[8].ToString();
            dr[8] = ds.Tables[0].Rows[i].ItemArray[7].ToString(); //QuotedPrice
            dr[9] = ds.Tables[0].Rows[i].ItemArray[14].ToString();
            dr[10] = ds.Tables[0].Rows[i].ItemArray[16].ToString();
            dr[11] = ds.Tables[0].Rows[i].ItemArray[15].ToString();
            dr[12] = ds.Tables[0].Rows[i].ItemArray[9].ToString() + " L" + (i + 1).ToString();
            dr[13] = ds.Tables[0].Rows[i].ItemArray[10].ToString();
			dr[14] = ds.Tables[0].Rows[i].ItemArray[17].ToString();
            dr[15] = ds.Tables[0].Rows[i].ItemArray[18].ToString();
            dr[16] = ds.Tables[0].Rows[i].ItemArray[19].ToString();
            dt.Rows.Add(dr);
        }

        GridView.DataSource = dt;
        GridView.DataBind();
    }

      protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
      {
          if (e.Row.RowType == DataControlRowType.DataRow)
          {
              Button buttonId = (Button)e.Row.FindControl("ButAssign");
			  Button buttonId1 = (Button)e.Row.FindControl("btn_cancel");
              Label lblAssignID = (Label)e.Row.FindControl("lblTripAssignID");
              if (lblAssignID.Text == "" || lblAssignID.Text == "0")
              {
                  buttonId.Enabled = true;
                  buttonId.Text = "Confirm";
                  buttonId1.Visible = false;
              }
              else
              {
                  string postid = Request.QueryString["PostID"].ToString();
                  //string qry = "select QuotedPrice from BizConnect_TripAssign where IndentID='" + Request.QueryString["PostID"].ToString() + " ' ";//'Request.QueryString["PostID"].ToString()'";
                  string[] args_ = { "@postid" };
                  string[] argsval_ = { postid };
                  DataSet _ds = new DataSet();
                  _ds = con.Sql_GetData("Bizconnect_Get_Decideprice", args_, argsval_);
                  if (_ds.Tables[0].Rows.Count > 0)
                  {
                      string _decideprice = _ds.Tables[0].Rows[0]["QuotedPrice"].ToString();
                      
                      //buttonId.Enabled = false;
                      //buttonId.Text = "Confirmed";
					   buttonId.Visible = false;
                      buttonId1.Visible = true;
					  GridView.Columns[15].Visible=true;
                      //(TextBox)e.Row.FindControl("txt_negcost") = "100";
                      ((TextBox)e.Row.FindControl("txt_negcost")).Text = _decideprice;
                  }

                  //buttonId.Enabled = false;
                  //buttonId.Text = "Confirmed";
              }
          }
      }

      protected void ButAssign_Click(object sender, EventArgs e)
      {
          try
          {
             
              Button b = (Button)sender;
              GridViewRow row = (GridViewRow)b.NamingContainer;
              if (row != null)
              {
                  b.Enabled = false;
                  Label lblplanID = (Label)GridView.Rows[row.RowIndex].FindControl("lblplanID");
                  Label lblFrom = (Label)GridView.Rows[row.RowIndex].FindControl("lblFromLoc");
                  Label lblTo = (Label)GridView.Rows[row.RowIndex].FindControl("lbltoloc");
                  Label lblTruckType = (Label)GridView.Rows[row.RowIndex].FindControl("lblTrucktype");
                  Label lblEnclType = (Label)GridView.Rows[row.RowIndex].FindControl("lblEncltype");
                  Label lblCapacity = (Label)GridView.Rows[row.RowIndex].FindControl("lblcapacity");
                  Label lblprice = (Label)GridView.Rows[row.RowIndex].FindControl("lblDecidePrice");
                  //Label txttruckreq = (Label)GridView.Rows[row.RowIndex].FindControl("txtTruckreq");
                  TextBox lbldecideprice_new = (TextBox)GridView.Rows[row.RowIndex].FindControl("txt_negcost");
                  string decideprice = lbldecideprice_new.Text;

                  Session["decideprice_s"] = decideprice;

                  TextBox txttruckreq = (TextBox)GridView.Rows[row.RowIndex].FindControl("txt_TrucksReq");
                  Label lbldate = (Label)GridView.Rows[row.RowIndex].FindControl("lbldate1");
                  Label lblTransporterID = (Label)GridView.Rows[row.RowIndex].FindControl("LblTransID");
                  Label lblEmail = (Label)GridView.Rows[row.RowIndex].FindControl("lblEmail");

                  TextBox TrucksReqDatetime = (TextBox)GridView.Rows[row.RowIndex].FindControl("txt_TrucksReqDatetime");
                  DropDownList Hours = (DropDownList)GridView.Rows[row.RowIndex].FindControl("ddl_Hours");
                  DropDownList Minutes = (DropDownList)GridView.Rows[row.RowIndex].FindControl("ddl_Minutes");
                  DropDownList Ampm = (DropDownList)GridView.Rows[row.RowIndex].FindControl("ddl_Ampm");
                  TextBox txt_sgs = (TextBox)GridView.Rows[row.RowIndex].FindControl("txt_sgs");
                 // TrucksReqDatetime.Text = DateTime.Now.ToString("dd/MM/yyyy");
                  DateTime TrucksReqDatetime2 = DateTime.ParseExact(TrucksReqDatetime.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                  string formattedDate = TrucksReqDatetime2.ToString("dd MMM yyyy"); 
                  if (txt_sgs.Text == "")
                  {
                      txt_sgs.Text = "0";
                  }

                  for (int i = 0; i < Convert.ToInt32(txttruckreq.Text); i++)
                  {
                      //resp = Trip_Assign.Bizconnect_InsertTripAssign(Convert.ToInt32(txt_sgs.Text), lblFrom.Text, lblTo.Text, lblTruckType.Text, lblEnclType.Text, lblCapacity.Text, Convert.ToInt32(lblprice.Text), Convert.ToInt32(lblTransporterID.Text), 1, TrucksReqDatetime2, "12 PM", Convert.ToInt32(Session["UserID"].ToString()), Convert.ToInt32(Request.QueryString["PostID"].ToString()));
                      string[] args = { "@agreementrouteid", "@fromlocation", "@tolocation", "@trucktype", "@enclosuretype", "@capacity", "@decideprice", "@quoteprice", "@transporterid", "@truckreq", "@traveldate", "@traveltime", "@userid", "@logisticsplanid" };
                      string[] argsval = { txt_sgs.Text, lblFrom.Text, lblTo.Text, lblTruckType.Text, lblEnclType.Text, lblCapacity.Text, lblprice.Text, decideprice, lblTransporterID.Text, "1", TrucksReqDatetime2.ToString(), "12 PM", Session["UserID"].ToString(), Request.QueryString["PostID"].ToString() };
                      int res = con.Sql_ExecuteNonQuery("Bizconnect_Insert_TripAssign", args, argsval);
                      
                  }
                  
                  //Email Portion
                  SqlConnection conn = new SqlConnection();
                  SqlCommand cmd;
                  conn.ConnectionString = Conn;
                  conn.Open();
                  SqlDataReader mydatareader;
                  string fromID;
                  string password;

                 string  qry = "select Emailid,password from Clients_EmailID where clientID='" + Session["ClientID"].ToString() + " ' ";
                        cmd = new SqlCommand(qry, conn);
                        mydatareader = cmd.ExecuteReader();

                        mydatareader.Read();
                        if (mydatareader.HasRows)
                        {
                            fromID = mydatareader.GetValue(0).ToString();
                            password = mydatareader.GetValue(1).ToString();
                        }
                        else
                        {
                            fromID = "tripschedule@scmbizconnect.com";
                            password = "tripschedule123";
                        }


                  string tableheader = "<table bgcolor=White bordercolor=#003366 border=1 style=width: 650px ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>DecidedPrice</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Time</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>VehicleRequirementTime</strong></font></td></tr>";
                  string mailbody = "Dear Sir,<br/><br/>Please arrange to place the vehicles as per below Schedule.  Please confirm with all the particulars of vehicle immediately.";

                  //string body = "<tr><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2 >" + lblTo.Text + "</font></td><td align=center><font size=2>" + lblTruckType.Text + "" + "/" + "" + lblEnclType.Text + "</font></td><td align=center><font size=2>" + lblprice.Text + "</font></td><td align=center><font size=2>" + lblCapacity.Text + "</font></td><td align=center><font size=2>" + txttruckreq.Text + "</font></td><td align=center><font size=2>12:9Pm</font></td><td align=center><font size=2>" + formattedDate.ToString() + "</font></td><td align=center><font size=2>" + TrucksReqDatetime.Text + " " + Hours.SelectedItem.Text + " : " + Minutes.SelectedItem.Text + " " + Ampm.SelectedItem.Text + "</font></td></tr>";
                  string body = "<tr><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2 >" + lblTo.Text + "</font></td><td align=center><font size=2>" + lblTruckType.Text + "" + "/" + "" + lblEnclType.Text + "</font></td><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2>" + lblCapacity.Text + "</font></td><td align=center><font size=2>" + txttruckreq.Text + "</font></td><td align=center><font size=2>12:9Pm</font></td><td align=center><font size=2>" + formattedDate.ToString() + "</font></td><td align=center><font size=2>" + TrucksReqDatetime.Text + " " + Hours.SelectedItem.Text + " : " + Minutes.SelectedItem.Text + " " + Ampm.SelectedItem.Text + "</font></td></tr>";
                //  body = mailbody + tableheader + body + "</table>" + "<a href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + lblTransporterID.Text + "&ClID=" + Session["ClientID"].ToString() + "&AGID=0>Click Here to Confirm the Routes</a>"; ;

                  body="<table style='background-color: #f6f6f6;width: 59%;'> <td  style='width: 750px; display: block !important;margin: 0 auto !important;clear: both !important;'><div style=' max-width: 600px;margin: 0 auto;display: block;padding: 20px;'><table cellpadding=0 cellspacing=0 style='width:100%;' > <tr> <td> <table  cellpadding=0 cellspacing=0><tr><td><center><img  src=http://www.scmbizconnect.com/images/logo.jpg /></center></td></tr> <tr><td style='padding: 0 0 20px';><h3>Dear Sir/madam,</h3></td></tr><tr><td style=' padding: 0 0 20px;'>Please arrange to place the vehicles as per below Schedule. Please confirm with all the particulars of vehicle immediately.</td></tr><tr><td style=' padding: 0 0 20px;'><table bgcolor=White bordercolor=#003366 border=1 style='width:650px;height: 293px;'  ><tr><td align=center><b>Trip Summary</b></td></tr><tr><td align=center bgcolor=#585858><Font size=2 color=White><strong>From</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>To</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TruckType</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>DecidedPrice</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Capacity</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>NoofTrucksReq.</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>Time</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>TravelDate</strong></font></td><td align=center bgcolor=#585858><Font size=2 color=White><strong>VehicleRequirementTime</strong></font></td></tr><tr><td align=center><font size=2>" + lblFrom.Text + "</font></td><td align=center><font size=2 >" + lblTo.Text + "</font></td><td align=center><font size=2>" + lblTruckType.Text + "" + "/" + "" + lblEnclType.Text + "</font></td><td align=center><font size=2>" + decideprice + "</font></td><td align=center><font size=2>" + lblCapacity.Text + "</font></td><td align=center><font size=2>" + txttruckreq.Text + "</font></td><td align=center><font size=2>12:9Pm</font></td><td align=center><font size=2>" + lbldate.Text + "</font></td><td align=center><font size=2>" + TrucksReqDatetime.Text + " " + Hours.SelectedItem.Text + " : " + Minutes.SelectedItem.Text + " " + Ampm.SelectedItem.Text + "</font></td></tr> </td></tr></table></br><center><a style='text-decoration: none;color: #FFF;background-color: #1a88b3;border: solid #1a88b3;border-width: 0px 1px;line-height: 2;font-weight: bold;text-align: center;cursor: pointer;display: inline-block; border-radius: 5px;text-transform: capitalize;' href=http://www.scmbizconnect.com/TripAcceptance.aspx?TransID=" + lblTransporterID.Text + "&ClID=" + Session["ClientID"].ToString() + "&AGID=0>Click Here to Confirm the Routes</a></center> </br><tr><td style=' padding: 0 0 20px;'>Thank You,</td></tr> <tr><td ><a href=http://www.scmbizconnect.com>www.scmbizconnect.com</a></td></tr> </table></td></tr></table></div></td> </table>";

                  if (clientidd == "1440")//manasa
                  {
                      string myccmail = "geethamiisky@gmail.com";
                      mail.SendEmail(lblEmail.Text, fromID.ToString(), password.ToString(), myccmail, "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                  }
                  else if (clientidd == "1132")//godrej
                  {
                      string myccmail1 = "geethamiisky@gmail.com,canoop@godrej.com,vkarthi@godrej.com,asu@godrej.com,vijayakrishna@scmjunction.com";
                      mail.SendEmail(lblEmail.Text, fromID.ToString(), password.ToString(), myccmail1, "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                  }
                  else
                  {
                      mail.SendEmail(lblEmail.Text, fromID.ToString(), password.ToString(), "", "connect@scmjunction.com", "connect@scmjunction.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                  }
                 
                 
                  // mail.SendEmail("nandha@aarmscmsolutions.com", "tripschedule@scmbizconnect.com", "tripschedule123", "", "", "tripschedule@scmbizconnect.com", "bounceback@scmjunction.com", "Placement of Vehicle", body, System.Web.Mail.MailFormat.Html, System.Web.Mail.MailPriority.High, "smtp.gmail.com", "465", "2", "1", true, "");
                  ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Assigned Successfully');</script>");
                  TrucksReqDatetime.Text = "";

              }

          }
          catch (Exception ex)
          {
          }
      }
	  
	  protected void btn_cancel_Click(object sender, EventArgs e)
      {
          try
          {
              Button b = (Button)sender;
              GridViewRow row = (GridViewRow)b.NamingContainer;
              if (row != null)
              {
                  Label lblAssignID = (Label)GridView.Rows[row.RowIndex].FindControl("lblTripAssignID");
                  string assignid = lblAssignID.Text;
                  string postid = Request.QueryString["PostID"].ToString();
                  Label lblTransporterID = (Label)GridView.Rows[row.RowIndex].FindControl("LblTransID");
                  string transid = lblTransporterID.Text;
                  TextBox message = (TextBox)GridView.Rows[row.RowIndex].FindControl("txt_remarks");
                  string remarks = message.Text;

                  string[] args = { "@assignid" };
                  string[] argsval = { assignid };
                  //DataSet ds = new DataSet();
                  int res = con.Sql_ExecuteNonQuery("SP_Cancel_Trip", args, argsval);
                   if (res > 0)
                  {
                      string[] args_ = { "@postid", "@transid", "@mesg" };
                      string[] argsval_ = { postid, transid, remarks };
                      int resp = con.Sql_ExecuteNonQuery("SP_Insert_Remarks_for_Cancel", args_, argsval_);
                      if (resp > 0)
                      {
                          ClientScript.RegisterStartupScript(this.GetType(), "alert", "<script>alert('Trip Cancelled Successfully');</script>");
                      } 
                  }   
                                
              }

          }
          catch(Exception ex)
          {


          }
          finally
          {

          }

      }
    
    
    
}
